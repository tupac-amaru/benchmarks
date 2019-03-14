﻿using BenchmarkDotNet.Running;

namespace TupacAmaru.Yacep.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
            => BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args);
    }
}
