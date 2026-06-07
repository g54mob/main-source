using DV.Simulation.Ports;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class LampPortReadersController : ARefreshableChildrenController<LampPortReader>
	{
		private void Start()
		{
			SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring LampPortReadersController initialization!");
				return;
			}
			LampPortReader[] array = entries;
			foreach (LampPortReader lampPortReader in array)
			{
				if (simulationFlow.TryGetPort(lampPortReader.lampStatePortId, out var port))
				{
					lampPortReader.Init(port);
				}
			}
		}

		private void OnDestroy()
		{
			LampPortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
