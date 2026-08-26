[![Build](https://github.com/Mrchazaaa/SimpleX/actions/workflows/build.yml/badge.svg)](https://github.com/Mrchazaaa/SimpleX/actions/workflows/build.yml)
[![Tests](https://github.com/Mrchazaaa/SimpleX/actions/workflows/test.yml/badge.svg)](https://github.com/Mrchazaaa/SimpleX/actions/workflows/test.yml)

# SimpleX

A Windows Forms application for solving linear-programming problems with the simplex method, including single-stage and two-stage workflows.

## Development

The project targets .NET Framework 4.0 (x86). Open `SimpleX.sln` in Visual Studio, or build locally with Mono:

```bash
xbuild SimpleX.sln /property:Configuration=Debug /property:Platform=x86
```

## Tests

The NUnit test suite covers simplex pivot and completion behaviour.

```bash
xbuild Tests/SimpleX.Tests.csproj /target:Rebuild /property:Configuration=Debug /property:Platform=x86
mono Tests/bin/Debug/SimpleX.Tests.exe --labels=All
```
