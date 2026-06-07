using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SimulationRegistry", fileName = "SimulationRegistry")]
public class SimulationRegistry : ScriptableObject
{
	[SerializeField]
	public List<ScriptableObject> simulations = new List<ScriptableObject>();

	private IEnumerable<Type> GetIncrementalSimulationTypes()
	{
		return from x in typeof(IIncrementalSimulation).Assembly.GetTypes()
			where !x.IsAbstract
			where !x.IsGenericTypeDefinition
			where !x.IsInterface
			where typeof(IIncrementalSimulation).IsAssignableFrom(x)
			select x;
	}
}
