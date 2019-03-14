@echo off

set solutionName=TupacAmaru.Benchmark
set targetFramework=netcoreapp2.1
set appDir=/app

set install=dotnet tool install -g BenchmarkDotNet.Tool
set export=export PATH=$PATH:/root/.dotnet/tools
set build=dotnet build --configuration Release %appDir%/%solutionName%.csproj
set tree=dotnet benchmark %appDir%/bin/Release/%targetFramework%/%solutionName%.dll --list Tree
set benchmark=dotnet benchmark %appDir%/bin/Release/%targetFramework%/%solutionName%.dll ^
    --warmupCount 1 -r %targetFramework% --stopOnFirstError true ^
	--launchCount 1 --unrollFactor 4 --invocationCount 8 --iterationCount 50 --filter "\*"

docker run ^
     --rm -it ^
     -v %~dp0%solutionName%:%appDir% ^
      mcr.microsoft.com/dotnet/core/sdk:2.2 ^
      sh -c "%install%&&%export%&&%build%&&%tree%&&%benchmark%"