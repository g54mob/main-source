using System.Collections.Generic;
using System.Linq;

public static class IncrementalSimulation
{
	private class IntervalEntry
	{
		public readonly IIntervalIncrementalSimulation Simulation;

		public float Accumulator;

		public IntervalEntry(IIntervalIncrementalSimulation simulation)
		{
			Simulation = simulation;
			Accumulator = 0f;
		}
	}

	private static readonly List<IIncrementalSimulation> simulations = new List<IIncrementalSimulation>();

	private static readonly List<IntervalEntry> intervalSimulations = new List<IntervalEntry>();

	public static void RegisterSystem(IIncrementalSimulation simulation, UIRegistry? registry)
	{
		IIntervalIncrementalSimulation intervalSimulation = simulation as IIntervalIncrementalSimulation;
		if (intervalSimulation != null)
		{
			if (intervalSimulations.FindIndex((IntervalEntry x) => x.Simulation == intervalSimulation) == -1)
			{
				intervalSimulations.Add(new IntervalEntry(intervalSimulation));
				intervalSimulation.Registered(registry);
			}
		}
		else if (!simulations.Contains(simulation))
		{
			simulations.Add(simulation);
			simulation.Registered(registry);
		}
	}

	public static void UnregisterSystem(IIncrementalSimulation simulation)
	{
		IIntervalIncrementalSimulation intervalSimulation = simulation as IIntervalIncrementalSimulation;
		if (intervalSimulation != null)
		{
			int num = intervalSimulations.FindIndex((IntervalEntry x) => x.Simulation == intervalSimulation);
			if (num != -1)
			{
				intervalSimulations.RemoveAt(num);
				simulation.Unregistered();
			}
		}
		else if (simulations.Contains(simulation))
		{
			simulations.Remove(simulation);
			simulation.Unregistered();
		}
	}

	public static void ClearSystems()
	{
		foreach (IIncrementalSimulation simulation in simulations)
		{
			simulation.Unregistered();
		}
		foreach (IIntervalIncrementalSimulation item in intervalSimulations.Select((IntervalEntry s) => s.Simulation))
		{
			item.Unregistered();
		}
		simulations.Clear();
		intervalSimulations.Clear();
	}

	public static void AdvanceTime(float deltaTime)
	{
		Database.Commands.AdvanceTime(deltaTime);
		foreach (IIncrementalSimulation simulation in simulations)
		{
			simulation.OnUpdateSimulation(deltaTime);
		}
		foreach (IntervalEntry intervalSimulation in intervalSimulations)
		{
			intervalSimulation.Accumulator += deltaTime;
			if (!(intervalSimulation.Accumulator < intervalSimulation.Simulation.UpdateInterval))
			{
				intervalSimulation.Simulation.OnUpdateSimulation(intervalSimulation.Accumulator);
				intervalSimulation.Accumulator = 0f;
			}
		}
	}
}
