using DV.Simulation.Ports;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class OilingPointsPortController : ARefreshableChildrenController<OilingPointPortFeederReader>
	{
		private void Start()
		{
			SimulationFlow simulationFlow = (TrainCar.Resolve(base.transform)?.SimController)?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring InteractablePortFeedersController initialization!");
				return;
			}
			OilingPointPortFeederReader[] array = entries;
			foreach (OilingPointPortFeederReader oilingPointPortFeederReader in array)
			{
				if (simulationFlow.TryGetPort(oilingPointPortFeederReader.refillPortId, out var port) && simulationFlow.TryGetPort(oilingPointPortFeederReader.refillingFlowNormalizedPortId, out var port2))
				{
					oilingPointPortFeederReader.Init(port, port2);
				}
			}
		}

		private void OnDestroy()
		{
			OilingPointPortFeederReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
