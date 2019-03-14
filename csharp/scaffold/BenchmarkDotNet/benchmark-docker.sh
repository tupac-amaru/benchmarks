#!/bin/sh

solutionName=TupacAmaru.Benchmark
targetFramework=netcoreapp2.1
appDir=/app

install="dotnet tool install -g BenchmarkDotNet.Tool"
export="export PATH=$PATH:/root/.dotnet/tools"
build="dotnet build --configuration Release $appDir/$solutionName.csproj"
tree="dotnet benchmark $appDir/bin/Release/$targetFramework/$solutionName.dll --list Tree"
benchmark="dotnet benchmark $appDir/bin/Release/$targetFramework/$solutionName.dll \
    --warmupCount 1 -r $targetFramework --stopOnFirstError true \
    --launchCount 1 --unrollFactor 4 --invocationCount 8 --iterationCount 50 --filter "

command="$install && $export && $build && $tree &&$benchmark \"*\""

echo $command

docker run \
     --rm -it \
     -v $(pwd)/$solutionName:$appDir \
     mcr.microsoft.com/dotnet/core/sdk:2.2 \
     sh -c "$command"