# Ideal Gas vs Real Gas Liquefaction Simulation

This repository summarizes a Unity 3D gas particle motion simulation created for a high school Chemistry II research presentation.

This is a public version of the project. The full Unity project is not included, but several selected C# scripts and public explanation materials are provided.

## Research Topic

This project compares the ideal gas law, `PV = nRT`, with the low-temperature liquefaction behavior of a real gas using a Unity 3D gas particle simulation.

## Key Concepts

The simulation is based on three main relationships.

```text
v(T) = v0 * sqrt(T / T0)
```

The representative speed of gas particles is modeled as proportional to `sqrt(T)`.

```text
P_ideal = nRT / V
```

The ideal gas pressure is calculated from the ideal gas law.

```text
P_real ~= sum(J) / (A * delta_t)
```

The real pressure is approximated by accumulating the impulse `J` transferred when particles collide with the container walls, then dividing by the surface area `A` and measurement time `delta_t`.

## Recommended Function Forms

For the report and presentation, simple functions with clear independent and dependent variables are easier to explain than overly complicated formulas.

| Purpose | Recommended form | Meaning |
|---|---|---|
| Temperature-speed relationship | `v(T)=v0*sqrt(T/T0)` | Particle speed increases as temperature increases |
| Ideal gas pressure | `P_ideal(T,V)=nRT/V` | Pressure increases with temperature and decreases with volume |
| Real pressure approximation | `P_real~=sum(J)/(A*delta_t)` | Real pressure is approximated from wall-collision impulse |
| Error rate | `Error=abs(P_ideal-P_real)/P_ideal*100` | Difference between ideal gas behavior and real gas behavior |

For the final report, graphs made from CSV data are more convincing than formulas alone.

Recommended graphs:

1. Compare `P_ideal` and `P_real` over `time`
2. Plot `error_percent` over `time`
3. Plot `liquid_count` over `time`

## Repository Structure

```text
.
+-- README.md
+-- docs/
|   +-- report_public.md
+-- src/
|   +-- GasParticle.cs
|   +-- WallController.cs
|   +-- GasManagerPressureExcerpt.cs
+-- data/
|   +-- sample_csv_template.csv
+-- assets/
    +-- screenshots/
        +-- README.md
```

## Included C# Files

The `src/` folder contains selected scripts used to explain the simulation logic.

| File | Description |
|---|---|
| `GasParticle.cs` | Controls particle speed, wall collisions, and simplified liquefaction behavior |
| `WallController.cs` | Controls the six walls of the 3D container and volume changes |
| `GasManagerPressureExcerpt.cs` | Public excerpt showing the pressure and error calculations |

The full Unity project and all local generated files are intentionally excluded.

## CSV Data Format

```csv
time,temperature,volume,p_ideal,p_real,error_percent,liquid_count
```

Column descriptions:

| Column | Meaning |
|---|---|
| `time` | Elapsed experiment time |
| `temperature` | Current temperature |
| `volume` | Container volume |
| `p_ideal` | Pressure calculated from the ideal gas law |
| `p_real` | Real pressure approximated from wall-collision impulse |
| `error_percent` | Error rate between ideal and real pressure |
| `liquid_count` | Number of liquefied particles |

## Screenshots to Include

Screenshots should be captured directly from the Unity simulation and placed in `assets/screenshots/`.

Recommended screenshots:

1. Unity Hierarchy view
2. High-temperature simulation view
3. Low-temperature liquefaction view
4. CSV file or pressure comparison graph

For more details, see [assets/screenshots/README.md](assets/screenshots/README.md).

## Public Scope

This repository does not include:

- The full Unity project
- Unity `Library`, `Temp`, or `Logs` cache files
- Personal local file paths
- Generated build files

Only selected public scripts, research explanations, CSV examples, and screenshot guides are included.
