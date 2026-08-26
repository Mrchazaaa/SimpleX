[![Build](https://github.com/Mrchazaaa/SimpleX/actions/workflows/build.yml/badge.svg)](https://github.com/Mrchazaaa/SimpleX/actions/workflows/build.yml)
[![Tests](https://github.com/Mrchazaaa/SimpleX/actions/workflows/test.yml/badge.svg)](https://github.com/Mrchazaaa/SimpleX/actions/workflows/test.yml)

# SimpleX

SimpleX is a tool implementing the simplex method of linear programming. It is intended for Further Mathematics students and teachers who want to enter a tableau, inspect the algorithm's working, and compare it with their own solution.

## What it does

- Solves single-stage and two-stage simplex problems.
- Shows every generated tableau, with pivot rows and columns highlighted.
- Displays values as fractions or decimals.
- Draws the graphical interpretation of each iteration for two-variable (`x`, `y`) problems; axis scales are adjustable.
- Supports multiple open solution windows.
- Prints filled tableaus, blank practice tableaus, and eligible graphs.

## Using the application

1. From **File → New**, open a problem window.
2. Choose **Single Stage** or **Two Stage**, set the tableau dimensions, and enter the initial tableau.
3. Select **Accept**. Blank or invalid cells can be replaced with `0`, or corrected before continuing.
4. Browse the resulting iterations with the iteration control. For two-variable problems, use **Graphical Solution** to view the corresponding graph.
5. Select **Print** from a solution window to choose tableaus (filled, blank, or none) and graphs (where available).

The solver stops after 100 tableaus to prevent an invalid or non-terminating problem from running indefinitely. Graphs are limited to two-variable problems.

## Requirements

The original application targets Windows and .NET Framework 4.0 (x86). A keyboard, mouse, and display are required; a printer is optional for worksheet and solution output.

## Development

Open `SimpleX.sln` in Visual Studio, or build with Mono:

```bash
xbuild SimpleX.sln /property:Configuration=Debug /property:Platform=x86
```

## Tests

The NUnit suite covers simplex pivot selection and completion behaviour.

```bash
xbuild Tests/SimpleX.Tests.csproj /target:Rebuild /property:Configuration=Debug /property:Platform=x86
mono Tests/bin/Debug/SimpleX.Tests.exe --labels=All
```

