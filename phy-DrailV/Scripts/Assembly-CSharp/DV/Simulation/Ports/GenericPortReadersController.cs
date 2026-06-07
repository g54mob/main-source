using DV.Simulation.Controllers;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class GenericPortReadersController : ARefreshableChildrenController<AGenericPortReader>
	{
		private void Start()
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			SimulationFlow simulationFlow = trainCar?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring IndicatorPortReadersController initialization!");
				return;
			}
			AGenericPortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(trainCar, simulationFlow);
			}
		}

		private void Update()
		{
			AGenericPortReader[] array = entries;
			foreach (AGenericPortReader aGenericPortReader in array)
			{
				if (aGenericPortReader.ExternalTickCall)
				{
					aGenericPortReader.Tick();
				}
			}
		}

		private void OnDestroy()
		{
			AGenericPortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
