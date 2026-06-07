using DV.Simulation.Ports;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class AnimatorPortReadersController : ARefreshableChildrenController<AnimatorPortReader>
	{
		private void Start()
		{
			SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring AnimatorPortReadersController initialization!");
				return;
			}
			AnimatorPortReader[] array = entries;
			foreach (AnimatorPortReader animatorPortReader in array)
			{
				if (simulationFlow.TryGetPort(animatorPortReader.portId, out var port))
				{
					animatorPortReader.Init(port);
				}
			}
		}

		private void OnDestroy()
		{
			AnimatorPortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
