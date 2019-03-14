using System;
using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TupacAmaru.Benchmark
{
    public class CustomThreadSafetyDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        private readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        public void Add(TKey key, TValue value)
        {
            rwLock.EnterWriteLock();
            try
            {
                dictionary.Add(key, value);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            rwLock.EnterReadLock();
            try
            {
                return dictionary.TryGetValue(key, out value);
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
    }
    public class CustomThreadSafetySortedDictionary<TKey, TValue>
    {
        private readonly SortedDictionary<TKey, TValue> dictionary = new SortedDictionary<TKey, TValue>();
        private readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        public void Add(TKey key, TValue value)
        {
            rwLock.EnterWriteLock();
            try
            {
                dictionary.Add(key, value);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            rwLock.EnterReadLock();
            try
            {
                return dictionary.TryGetValue(key, out value);
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
    }
    public class LockerThreadSafetyDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        public void Add(TKey key, TValue value)
        {
            lock (this)
            {
                dictionary.Add(key, value);
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (this)
            {
                return dictionary.TryGetValue(key, out value);
            }
        }
    }

    public class ThreadSafetyDictionary
    {
        private static readonly char[] chars = Enumerable.Range('0', 10)
            .Union(Enumerable.Range('a', 26))
            .Union(Enumerable.Range('A', 26))
            .Select(c => (char)c).ToArray();
        private static readonly Random random = new Random();
        private readonly ConcurrentDictionary<string, int> concurrentDictionary =
            new ConcurrentDictionary<string, int>();
        private readonly CustomThreadSafetyDictionary<string, int> customThreadSafetyDictionary =
            new CustomThreadSafetyDictionary<string, int>();
        private readonly LockerThreadSafetyDictionary<string, int> lockerThreadSafetyDictionary =
            new LockerThreadSafetyDictionary<string, int>();
        private readonly CustomThreadSafetySortedDictionary<string, int> customThreadSafetySortedDictionary =
            new CustomThreadSafetySortedDictionary<string, int>();

        [Params(1, 2, 10, 50)]
        public int ParallelTaskCount;

        [Params(50, 500, 5000, 10000)]
        public int ElementCount;

        [Params("W", "R")]
        public string Mode;

        [GlobalSetup]
        public void Setup()
        {
            if (Mode == "R")
            {
                for (var i = 0; i < ElementCount; i++)
                {
                    var key = $"k{i}";
                    customThreadSafetyDictionary.Add(key, i);
                    customThreadSafetySortedDictionary.Add(key, i);
                    lockerThreadSafetyDictionary.Add(key, i);
                    concurrentDictionary.TryAdd(key, i);
                }
            }
        }

        [Benchmark]
        public void CustomThreadSafetySortedDictionary()
        {
            if (Mode == "R")
            {
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    var index = random.Next(0, ElementCount);
                    var key = $"k{index}";
                    if (customThreadSafetySortedDictionary.TryGetValue(key, out var v) && v == index)
                        return;
                    throw new Exception("evaluate failed");
                });
            }
            else
            {
                var dictionary = new CustomThreadSafetySortedDictionary<string, int>();
                var totalElementCount = ElementCount / ParallelTaskCount;
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    for (var j = 0; j < totalElementCount; j++)
                    {
                        var key = $"k{(i + 1) * totalElementCount + j}";
                        dictionary.Add(key, i);
                    }
                });
            }
        }

        [Benchmark]
        public void CustomThreadSafetyDictionary()
        {
            if (Mode == "R")
            {
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    var index = random.Next(0, ElementCount);
                    var key = $"k{index}";
                    if (customThreadSafetyDictionary.TryGetValue(key, out var v) && v == index)
                        return;
                    throw new Exception("evaluate failed");
                });
            }
            else
            {
                var dictionary = new CustomThreadSafetyDictionary<string, int>();
                var totalElementCount = ElementCount / ParallelTaskCount;
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    for (var j = 0; j < totalElementCount; j++)
                    {
                        var key = $"k{(i + 1) * totalElementCount + j}";
                        dictionary.Add(key, i);
                    }
                });
            }
        }

        [Benchmark]
        public void LockerThreadSafetyDictionary()
        {
            if (Mode == "R")
            {
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    var index = random.Next(0, ElementCount);
                    var key = $"k{index}";
                    if (lockerThreadSafetyDictionary.TryGetValue(key, out var v) && v == index)
                        return;
                    throw new Exception("evaluate failed");
                });
            }
            else
            {
                var dictionary = new LockerThreadSafetyDictionary<string, int>();
                var totalElementCount = ElementCount / ParallelTaskCount;
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    for (var j = 0; j < totalElementCount; j++)
                    {
                        var key = $"k{(i + 1) * totalElementCount + j}";
                        dictionary.Add(key, i);
                    }
                });
            }
        }

        [Benchmark]
        public void ConcurrentDictionary()
        {
            if (Mode == "R")
            {
                Parallel.For(0, ParallelTaskCount, i =>
                {
                    var index = random.Next(0, ElementCount);
                    var key = $"k{index}";
                    if (concurrentDictionary.TryGetValue(key, out var v) && v == index)
                        return;
                    throw new Exception("evaluate failed");
                });
            }
            else
            {
                var dictionary = new ConcurrentDictionary<string, int>();
                var totalElementCount = ElementCount / ParallelTaskCount;
                Parallel.For(0, ParallelTaskCount, i =>
                 {
                     for (var j = 0; j < totalElementCount; j++)
                     {
                         var key = $"k{(i + 1) * totalElementCount + j}";
                         if (!dictionary.TryAdd(key, i))
                             throw new Exception("evaluate failed");
                     }
                 });
            }
        }
    }
}
