# Public Research Summary

## Title

Comparing the Ideal Gas Law and Real Gas Liquefaction Using a Unity 3D Particle Simulation

## Motivation

The ideal gas law, `PV = nRT`, explains the relationship between pressure, volume, amount of gas, and temperature. However, real gases do not always follow ideal behavior. In low-temperature conditions, molecular motion slows down and intermolecular attraction becomes more significant. Under such conditions, real gases may begin to liquefy.

This project was designed to visualize that difference. Instead of only explaining the concept with formulas, the simulation shows gas particles moving inside a container, colliding with walls, and changing behavior when the temperature becomes low.

## Simulation Design

The simulation uses a closed 3D container made from six wall objects. Gas particles are represented as spheres with physics components. Their motion is controlled so that particle speed changes according to temperature.

The key temperature-speed relationship is:

```text
v(T) = v0 * sqrt(T / T0)
```

This is based on the idea that the average kinetic energy of gas particles is proportional to absolute temperature.

## Pressure Model

The ideal pressure is calculated using:

```text
P_ideal = nRT / V
```

The real pressure is approximated from wall-collision impulse:

```text
P_real ~= sum(J) / (A * delta_t)
```

Here, `J` represents impulse, `A` represents the surface area of the container, and `delta_t` represents the measurement interval.

The error percentage is calculated as:

```text
Error = abs(P_ideal - P_real) / P_ideal * 100
```

## Liquefaction Model

The simulation uses a simplified liquefaction model. Below a critical temperature, gas particles can convert into a liquid-like state after collisions with other particles. Liquefied particles are visually distinguished and contribute less to wall-collision pressure.

This simplified model does not attempt to reproduce all molecular interactions. Instead, it is designed to show the conceptual reason why real gases deviate from the ideal gas law at low temperature.

## Expected Result

At high temperature, most particles remain in the gas phase and collide actively with the walls. In this condition, the simulated real pressure is expected to remain closer to the ideal pressure.

At low temperature, more particles enter the simplified liquid state. As fewer gas-like particles collide with the walls, the real pressure decreases relative to the ideal pressure, and the error percentage increases.

## Limitations

This simulation is an educational model. It does not calculate detailed intermolecular forces or use a full thermodynamic phase-transition model. The pressure values are best interpreted as comparative simulation data rather than exact real-world pressure measurements.

Future improvements could include:

- comparison with the van der Waals equation
- gas-specific critical temperature values
- more detailed intermolecular force modeling
- automated graph generation from CSV output

