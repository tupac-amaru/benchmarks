``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i7-4710MQ CPU 2.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.104
  [Host] : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

Toolchain=InProcessEmitToolchain  InvocationCount=8  IterationCount=10  
LaunchCount=1  RunStrategy=ColdStart  UnrollFactor=4  
WarmupCount=1  

```
|                             Method | ParallelTaskCount | ElementCount | Mode |          Mean |       Error |      StdDev |        Median |
|----------------------------------- |------------------ |------------- |----- |--------------:|------------:|------------:|--------------:|
| **CustomThreadSafetySortedDictionary** |                 **1** |           **50** |    **R** |      **85.13 us** |   **289.82 us** |   **191.70 us** |      **23.24 us** |
|       CustomThreadSafetyDictionary |                 1 |           50 |    R |      44.05 us |   111.25 us |    73.59 us |      22.19 us |
|       LockerThreadSafetyDictionary |                 1 |           50 |    R |      57.76 us |   181.58 us |   120.11 us |      20.76 us |
|               ConcurrentDictionary |                 1 |           50 |    R |      50.95 us |   158.54 us |   104.87 us |      17.32 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |           **50** |    **W** |     **106.56 us** |    **77.63 us** |    **51.34 us** |      **87.03 us** |
|       CustomThreadSafetyDictionary |                 1 |           50 |    W |      44.83 us |    53.27 us |    35.23 us |      31.52 us |
|       LockerThreadSafetyDictionary |                 1 |           50 |    W |      48.24 us |    64.58 us |    42.72 us |      32.58 us |
|               ConcurrentDictionary |                 1 |           50 |    W |      48.03 us |    67.58 us |    44.70 us |      32.59 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |          **500** |    **R** |      **29.40 us** |    **21.03 us** |    **13.91 us** |      **25.81 us** |
|       CustomThreadSafetyDictionary |                 1 |          500 |    R |      24.85 us |    21.92 us |    14.50 us |      20.23 us |
|       LockerThreadSafetyDictionary |                 1 |          500 |    R |      25.46 us |    36.47 us |    24.13 us |      18.34 us |
|               ConcurrentDictionary |                 1 |          500 |    R |      25.04 us |    19.78 us |    13.08 us |      20.37 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |          **500** |    **W** |   **1,325.81 us** |   **691.00 us** |   **457.05 us** |   **1,176.33 us** |
|       CustomThreadSafetyDictionary |                 1 |          500 |    W |     143.72 us |    54.94 us |    36.34 us |     132.11 us |
|       LockerThreadSafetyDictionary |                 1 |          500 |    W |     174.83 us |   165.63 us |   109.55 us |     125.46 us |
|               ConcurrentDictionary |                 1 |          500 |    W |     193.54 us |    98.07 us |    64.87 us |     168.88 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |         **5000** |    **R** |      **31.10 us** |    **27.35 us** |    **18.09 us** |      **25.67 us** |
|       CustomThreadSafetyDictionary |                 1 |         5000 |    R |      22.67 us |    20.28 us |    13.41 us |      19.38 us |
|       LockerThreadSafetyDictionary |                 1 |         5000 |    R |      24.32 us |    20.11 us |    13.30 us |      19.39 us |
|               ConcurrentDictionary |                 1 |         5000 |    R |      29.01 us |    30.60 us |    20.24 us |      21.36 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |         **5000** |    **W** |  **16,500.00 us** |   **489.84 us** |   **324.00 us** |  **16,481.59 us** |
|       CustomThreadSafetyDictionary |                 1 |         5000 |    W |   2,025.35 us |   196.76 us |   130.15 us |   2,017.59 us |
|       LockerThreadSafetyDictionary |                 1 |         5000 |    W |   2,251.89 us | 1,009.45 us |   667.69 us |   2,021.93 us |
|               ConcurrentDictionary |                 1 |         5000 |    W |   3,816.08 us | 1,393.36 us |   921.62 us |   3,740.18 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |        **10000** |    **R** |      **28.92 us** |    **19.01 us** |    **12.57 us** |      **24.57 us** |
|       CustomThreadSafetyDictionary |                 1 |        10000 |    R |      26.19 us |    26.90 us |    17.80 us |      19.26 us |
|       LockerThreadSafetyDictionary |                 1 |        10000 |    R |      25.37 us |    28.24 us |    18.68 us |      19.26 us |
|               ConcurrentDictionary |                 1 |        10000 |    R |      27.23 us |    16.78 us |    11.10 us |      25.85 us |
| **CustomThreadSafetySortedDictionary** |                 **1** |        **10000** |    **W** |  **39,067.92 us** |   **819.64 us** |   **542.14 us** |  **39,090.69 us** |
|       CustomThreadSafetyDictionary |                 1 |        10000 |    W |   4,167.89 us |   411.09 us |   271.91 us |   4,070.43 us |
|       LockerThreadSafetyDictionary |                 1 |        10000 |    W |   4,068.29 us |   488.03 us |   322.80 us |   3,989.77 us |
|               ConcurrentDictionary |                 1 |        10000 |    W |   8,677.25 us | 1,303.91 us |   862.45 us |   8,492.58 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |           **50** |    **R** |      **29.80 us** |    **19.95 us** |    **13.20 us** |      **27.79 us** |
|       CustomThreadSafetyDictionary |                 2 |           50 |    R |      26.22 us |    28.17 us |    18.63 us |      21.23 us |
|       LockerThreadSafetyDictionary |                 2 |           50 |    R |      29.83 us |    23.33 us |    15.43 us |      23.93 us |
|               ConcurrentDictionary |                 2 |           50 |    R |      23.57 us |    18.19 us |    12.03 us |      19.29 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |           **50** |    **W** |     **137.68 us** |    **31.84 us** |    **21.06 us** |     **133.83 us** |
|       CustomThreadSafetyDictionary |                 2 |           50 |    W |      42.98 us |    32.76 us |    21.67 us |      35.80 us |
|       LockerThreadSafetyDictionary |                 2 |           50 |    W |      43.80 us |    44.23 us |    29.26 us |      33.78 us |
|               ConcurrentDictionary |                 2 |           50 |    W |      46.76 us |    17.37 us |    11.49 us |      44.33 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |          **500** |    **R** |      **34.29 us** |    **23.99 us** |    **15.87 us** |      **29.62 us** |
|       CustomThreadSafetyDictionary |                 2 |          500 |    R |      26.28 us |    19.41 us |    12.84 us |      23.23 us |
|       LockerThreadSafetyDictionary |                 2 |          500 |    R |      27.73 us |    33.11 us |    21.90 us |      21.22 us |
|               ConcurrentDictionary |                 2 |          500 |    R |      26.51 us |    18.62 us |    12.32 us |      22.89 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |          **500** |    **W** |   **1,528.84 us** |   **128.70 us** |    **85.13 us** |   **1,550.03 us** |
|       CustomThreadSafetyDictionary |                 2 |          500 |    W |     252.42 us |    78.29 us |    51.78 us |     241.68 us |
|       LockerThreadSafetyDictionary |                 2 |          500 |    W |     204.15 us |    72.00 us |    47.62 us |     191.79 us |
|               ConcurrentDictionary |                 2 |          500 |    W |     224.52 us |    46.65 us |    30.86 us |     228.04 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |         **5000** |    **R** |     **130.58 us** |   **483.76 us** |   **319.98 us** |      **29.04 us** |
|       CustomThreadSafetyDictionary |                 2 |         5000 |    R |      31.54 us |    23.87 us |    15.79 us |      26.57 us |
|       LockerThreadSafetyDictionary |                 2 |         5000 |    R |      33.98 us |    37.31 us |    24.68 us |      24.65 us |
|               ConcurrentDictionary |                 2 |         5000 |    R |      26.20 us |    22.25 us |    14.72 us |      22.73 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |         **5000** |    **W** |  **22,888.46 us** | **1,240.03 us** |   **820.20 us** |  **22,530.10 us** |
|       CustomThreadSafetyDictionary |                 2 |         5000 |    W |   2,962.03 us |   464.41 us |   307.18 us |   2,941.27 us |
|       LockerThreadSafetyDictionary |                 2 |         5000 |    W |   2,439.25 us |   416.38 us |   275.41 us |   2,347.84 us |
|               ConcurrentDictionary |                 2 |         5000 |    W |   2,673.39 us |   547.99 us |   362.46 us |   2,718.96 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |        **10000** |    **R** |      **40.40 us** |    **32.25 us** |    **21.33 us** |      **35.10 us** |
|       CustomThreadSafetyDictionary |                 2 |        10000 |    R |      27.16 us |    25.00 us |    16.53 us |      21.06 us |
|       LockerThreadSafetyDictionary |                 2 |        10000 |    R |      29.00 us |    22.84 us |    15.10 us |      23.64 us |
|               ConcurrentDictionary |                 2 |        10000 |    R |      27.60 us |    23.10 us |    15.28 us |      23.84 us |
| **CustomThreadSafetySortedDictionary** |                 **2** |        **10000** |    **W** |  **48,449.36 us** | **2,652.02 us** | **1,754.15 us** |  **48,159.48 us** |
|       CustomThreadSafetyDictionary |                 2 |        10000 |    W |   4,739.81 us |   270.99 us |   179.24 us |   4,701.15 us |
|       LockerThreadSafetyDictionary |                 2 |        10000 |    W |   3,693.49 us |   199.09 us |   131.69 us |   3,648.88 us |
|               ConcurrentDictionary |                 2 |        10000 |    W |   7,519.12 us | 1,054.78 us |   697.67 us |   7,273.24 us |
| **CustomThreadSafetySortedDictionary** |                **10** |           **50** |    **R** |      **38.38 us** |    **21.70 us** |    **14.36 us** |      **32.35 us** |
|       CustomThreadSafetyDictionary |                10 |           50 |    R |      33.48 us |    23.52 us |    15.56 us |      29.01 us |
|       LockerThreadSafetyDictionary |                10 |           50 |    R |      28.23 us |    21.75 us |    14.39 us |      24.64 us |
|               ConcurrentDictionary |                10 |           50 |    R |      25.89 us |    20.03 us |    13.25 us |      21.43 us |
| **CustomThreadSafetySortedDictionary** |                **10** |           **50** |    **W** |     **159.32 us** |    **27.11 us** |    **17.93 us** |     **156.98 us** |
|       CustomThreadSafetyDictionary |                10 |           50 |    W |      43.27 us |    22.17 us |    14.67 us |      37.31 us |
|       LockerThreadSafetyDictionary |                10 |           50 |    W |      37.69 us |    20.75 us |    13.72 us |      33.56 us |
|               ConcurrentDictionary |                10 |           50 |    W |      55.17 us |    24.44 us |    16.17 us |      49.38 us |
| **CustomThreadSafetySortedDictionary** |                **10** |          **500** |    **R** |      **40.60 us** |    **25.05 us** |    **16.57 us** |      **36.71 us** |
|       CustomThreadSafetyDictionary |                10 |          500 |    R |      29.22 us |    20.09 us |    13.29 us |      25.03 us |
|       LockerThreadSafetyDictionary |                10 |          500 |    R |      29.27 us |    18.04 us |    11.93 us |      24.58 us |
|               ConcurrentDictionary |                10 |          500 |    R |      28.34 us |    22.18 us |    14.67 us |      23.37 us |
| **CustomThreadSafetySortedDictionary** |                **10** |          **500** |    **W** |   **3,341.29 us** |   **345.62 us** |   **228.61 us** |   **3,430.18 us** |
|       CustomThreadSafetyDictionary |                10 |          500 |    W |     364.64 us |    46.98 us |    31.07 us |     355.29 us |
|       LockerThreadSafetyDictionary |                10 |          500 |    W |     233.07 us |    44.06 us |    29.14 us |     225.38 us |
|               ConcurrentDictionary |                10 |          500 |    W |     271.81 us |    64.03 us |    42.35 us |     255.99 us |
| **CustomThreadSafetySortedDictionary** |                **10** |         **5000** |    **R** |      **47.77 us** |    **22.44 us** |    **14.84 us** |      **43.38 us** |
|       CustomThreadSafetyDictionary |                10 |         5000 |    R |      30.80 us |    19.91 us |    13.17 us |      27.04 us |
|       LockerThreadSafetyDictionary |                10 |         5000 |    R |      29.81 us |    21.36 us |    14.13 us |      25.27 us |
|               ConcurrentDictionary |                10 |         5000 |    R |      31.60 us |    17.53 us |    11.60 us |      28.49 us |
| **CustomThreadSafetySortedDictionary** |                **10** |         **5000** |    **W** |  **47,508.13 us** | **2,568.08 us** | **1,698.63 us** |  **47,862.54 us** |
|       CustomThreadSafetyDictionary |                10 |         5000 |    W |   5,220.41 us | 2,183.82 us | 1,444.46 us |   4,709.84 us |
|       LockerThreadSafetyDictionary |                10 |         5000 |    W |   2,412.11 us |   209.40 us |   138.51 us |   2,431.04 us |
|               ConcurrentDictionary |                10 |         5000 |    W |   2,655.56 us |   465.43 us |   307.85 us |   2,700.01 us |
| **CustomThreadSafetySortedDictionary** |                **10** |        **10000** |    **R** |      **50.62 us** |    **30.46 us** |    **20.15 us** |      **44.18 us** |
|       CustomThreadSafetyDictionary |                10 |        10000 |    R |      29.35 us |    23.13 us |    15.30 us |      24.89 us |
|       LockerThreadSafetyDictionary |                10 |        10000 |    R |      29.99 us |    21.07 us |    13.93 us |      25.98 us |
|               ConcurrentDictionary |                10 |        10000 |    R |      28.88 us |    21.51 us |    14.23 us |      24.12 us |
| **CustomThreadSafetySortedDictionary** |                **10** |        **10000** |    **W** |  **99,365.06 us** | **4,067.58 us** | **2,690.45 us** |  **99,263.50 us** |
|       CustomThreadSafetyDictionary |                10 |        10000 |    W |   9,136.48 us |   713.90 us |   472.20 us |   9,042.51 us |
|       LockerThreadSafetyDictionary |                10 |        10000 |    W |   4,794.56 us |   421.29 us |   278.66 us |   4,734.09 us |
|               ConcurrentDictionary |                10 |        10000 |    W |   7,365.40 us | 1,569.70 us | 1,038.26 us |   6,919.04 us |
| **CustomThreadSafetySortedDictionary** |                **50** |           **50** |    **R** |      **59.88 us** |    **24.27 us** |    **16.05 us** |      **56.06 us** |
|       CustomThreadSafetyDictionary |                50 |           50 |    R |      38.81 us |    22.19 us |    14.68 us |      34.97 us |
|       LockerThreadSafetyDictionary |                50 |           50 |    R |      36.13 us |    20.27 us |    13.41 us |      32.91 us |
|               ConcurrentDictionary |                50 |           50 |    R |      34.07 us |    19.50 us |    12.90 us |      31.04 us |
| **CustomThreadSafetySortedDictionary** |                **50** |           **50** |    **W** |     **168.80 us** |    **25.78 us** |    **17.05 us** |     **170.30 us** |
|       CustomThreadSafetyDictionary |                50 |           50 |    W |      46.01 us |    19.84 us |    13.13 us |      42.94 us |
|       LockerThreadSafetyDictionary |                50 |           50 |    W |      40.17 us |    16.57 us |    10.96 us |      38.02 us |
|               ConcurrentDictionary |                50 |           50 |    W |      37.80 us |    20.34 us |    13.45 us |      33.00 us |
| **CustomThreadSafetySortedDictionary** |                **50** |          **500** |    **R** |      **70.54 us** |    **20.28 us** |    **13.42 us** |      **67.87 us** |
|       CustomThreadSafetyDictionary |                50 |          500 |    R |      42.22 us |    21.01 us |    13.90 us |      38.99 us |
|       LockerThreadSafetyDictionary |                50 |          500 |    R |      48.64 us |    56.08 us |    37.09 us |      33.74 us |
|               ConcurrentDictionary |                50 |          500 |    R |      38.22 us |    21.53 us |    14.24 us |      34.71 us |
| **CustomThreadSafetySortedDictionary** |                **50** |          **500** |    **W** |   **3,683.54 us** |   **239.37 us** |   **158.33 us** |   **3,652.58 us** |
|       CustomThreadSafetyDictionary |                50 |          500 |    W |     395.93 us |    78.78 us |    52.11 us |     372.58 us |
|       LockerThreadSafetyDictionary |                50 |          500 |    W |     270.95 us |    44.43 us |    29.39 us |     260.55 us |
|               ConcurrentDictionary |                50 |          500 |    W |     332.48 us |   115.06 us |    76.11 us |     326.40 us |
| **CustomThreadSafetySortedDictionary** |                **50** |         **5000** |    **R** |      **87.86 us** |    **20.89 us** |    **13.82 us** |      **85.18 us** |
|       CustomThreadSafetyDictionary |                50 |         5000 |    R |      44.42 us |    18.21 us |    12.05 us |      41.28 us |
|       LockerThreadSafetyDictionary |                50 |         5000 |    R |      42.48 us |    21.07 us |    13.94 us |      39.61 us |
|               ConcurrentDictionary |                50 |         5000 |    R |      36.86 us |    19.09 us |    12.63 us |      34.31 us |
| **CustomThreadSafetySortedDictionary** |                **50** |         **5000** |    **W** |  **50,251.64 us** | **2,689.02 us** | **1,778.62 us** |  **50,504.41 us** |
|       CustomThreadSafetyDictionary |                50 |         5000 |    W |   4,979.09 us |   389.81 us |   257.84 us |   5,041.14 us |
|       LockerThreadSafetyDictionary |                50 |         5000 |    W |   2,607.86 us |   305.78 us |   202.25 us |   2,591.91 us |
|               ConcurrentDictionary |                50 |         5000 |    W |   2,668.23 us |   812.42 us |   537.37 us |   2,566.95 us |
| **CustomThreadSafetySortedDictionary** |                **50** |        **10000** |    **R** |      **84.06 us** |    **28.71 us** |    **18.99 us** |      **76.81 us** |
|       CustomThreadSafetyDictionary |                50 |        10000 |    R |      42.40 us |    23.49 us |    15.54 us |      36.92 us |
|       LockerThreadSafetyDictionary |                50 |        10000 |    R |      46.63 us |    22.06 us |    14.59 us |      40.71 us |
|               ConcurrentDictionary |                50 |        10000 |    R |      38.05 us |    20.67 us |    13.67 us |      34.36 us |
| **CustomThreadSafetySortedDictionary** |                **50** |        **10000** |    **W** | **105,015.16 us** | **3,140.79 us** | **2,077.44 us** | **104,689.63 us** |
|       CustomThreadSafetyDictionary |                50 |        10000 |    W |  10,342.02 us | 2,566.48 us | 1,697.57 us |   9,784.49 us |
|       LockerThreadSafetyDictionary |                50 |        10000 |    W |   4,882.65 us |   609.69 us |   403.28 us |   4,832.34 us |
|               ConcurrentDictionary |                50 |        10000 |    W |   7,224.16 us | 1,468.94 us |   971.62 us |   7,008.99 us |
