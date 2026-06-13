# Ideal Gas vs Real Gas Liquefaction Simulation

This repository summarizes a Unity 3D gas particle motion simulation created for a high school Chemistry II research presentation.

> This is a public version of the project.  
> Core Unity C# implementation files are not included.  
> This repository provides the research summary, experiment structure, graphing guide, CSV format, and screenshot guide only.

## Research Topic

This project compares the ideal gas law, `PV = nRT`, with the liquefaction behavior of a real gas at low temperature using a Unity 3D gas particle simulation.

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
P_real ≈ ΣJ / (AΔt)
```

The real pressure is approximated by accumulating the impulse `J` transferred when particles collide with the container walls, then dividing by the surface area `A` and measurement time `Δt`.

## Recommended Function Forms

For the report and presentation, it is better to use simple functions with clear independent and dependent variables instead of overly complicated formulas.

| Purpose | Recommended form | Meaning |
|---|---|---|
| Temperature-speed relationship | `v(T)=v0√(T/T0)` | Particle speed increases as temperature increases |
| Ideal gas pressure | `P_ideal(T,V)=nRT/V` | Pressure increases with temperature and decreases with volume |
| Real pressure approximation | `P_real≈ΣJ/(AΔt)` | Real pressure is approximated from wall-collision impulse |
| Error rate | `Error=|P_ideal-P_real|/P_ideal×100` | Difference between ideal gas behavior and real gas behavior |

For the final report, graphs made from CSV data are more convincing than formulas alone.

Recommended graphs:

1. Compare `P_ideal` and `P_real` over `time`
2. Plot `error_percent` over `time`
3. Plot `liquid_count` over `time`

## Repository Structure

```text
.
├─ README.md
├─ docs/
│  └─ report_public.md
├─ data/
│  └─ sample_csv_template.csv
└─ assets/
   └─ screenshots/
      └─ README.md
```

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
- Core C# scripts
- Personal local file paths
- Unity `Library`, `Temp`, or `Logs` cache files

Only the public research explanation and report materials are included.

