#!/bin/bash

solutionName="TupacAmaru.Benchmark"
targetFramework="netcoreapp2.1"

dotnet build --force --configuration Release ./$solutionName.csproj
dotnet benchmark ./$solutionName/bin/Release/$targetFramework/$solutionName.dll --list Tree
dotnet benchmark ./$solutionName/bin/Release/$targetFramework/$solutionName.dll \
    -a ./results/benchmark/ \
    --warmupCount 1 --stopOnFirstError true -e html \
	--launchCount 1 --unrollFactor 4 --invocationCount 8 --iterationCount 50 --filter "*"