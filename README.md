# Ideal Gas and Real Gas Liquefaction Simulation

This repository documents a Unity-based gas particle simulation designed to compare ideal gas behavior with simplified real-gas liquefaction behavior.

The project focuses on the relationship between temperature, molecular motion, pressure, and liquefaction. It is intended as a public research summary rather than a full source-code release.

## Overview

The simulation models gas particles moving inside a closed 3D container. The ideal pressure is calculated using the ideal gas law, while the real pressure is approximated from particle-wall collision impulse.

At high temperature, most particles remain in the gas phase and the simulated pressure trend is closer to the ideal gas model. At low temperature, some particles undergo simplified liquefaction, reducing their contribution to wall collisions and increasing the difference between ideal and real pressure.

## Core Model

The simulation is organized around four main relationships.

```text
v(T) = v0 * sqrt(T / T0)
```

Particle speed is modeled as proportional to the square root of absolute temperature.

```text
P_ideal = nRT / V
```

The ideal pressure is calculated from the ideal gas equation.

```text
P_real ~= sum(J) / (A * delta_t)
```

The real pressure is approximated from the total impulse transferred to the container walls.

```text
Error = abs(P_ideal - P_real) / P_ideal * 100
```

The error percentage is used to compare ideal-gas prediction with the simulated real-gas behavior.

## Repository Structure

```text
.
+-- README.md
+-- docs/
|   +-- report_public.md
+-- src/
|   +-- WallController.cs
|   +-- GasManagerPressureExcerpt.cs
+-- data/
|   +-- sample_csv_template.csv
+-- assets/
    +-- screenshots/
        +-- README.md
```

## Included Source Files

Only selected, review-friendly C# files are included.

| File | Purpose |
|---|---|
| `WallController.cs` | Shows how the six container walls are resized and positioned |
| `GasManagerPressureExcerpt.cs` | Shows the pressure and error-rate calculations used in the model |

Particle behavior and full scene-management logic are intentionally excluded from this public repository.

## CSV Output Format

The experiment records data in the following CSV format:

```csv
time,temperature,volume,p_ideal,p_real,error_percent,liquid_count
```

| Column | Description |
|---|---|
| `time` | Elapsed simulation time |
| `temperature` | Current simulation temperature |
| `volume` | Container volume |
| `p_ideal` | Pressure calculated from the ideal gas equation |
| `p_real` | Pressure approximated from wall-collision impulse |
| `error_percent` | Difference between ideal and real pressure |
| `liquid_count` | Number of particles converted to the simplified liquid state |

## Suggested Graphs

For analysis, the CSV data can be opened in Excel, Google Sheets, or another plotting tool.

Recommended graphs:

1. `P_ideal` and `P_real` over time
2. `error_percent` over time
3. `liquid_count` over time

These graphs help show how low-temperature liquefaction increases the gap between the ideal-gas prediction and the simulated real-gas pressure.

## Screenshots

Suggested screenshots are listed in [assets/screenshots/README.md](assets/screenshots/README.md).

Recommended visuals:

1. Unity Hierarchy
2. High-temperature simulation state
3. Low-temperature liquefaction state
4. Pressure comparison graph from CSV data

## Public Release Scope

This public repository excludes:

- Full Unity project files
- Unity `Library`, `Temp`, and `Logs` folders
- Local machine paths
- Build artifacts
- Full particle-behavior implementation

The repository is intended to present the research structure, selected implementation excerpts, and analysis workflow in a clean public format.

