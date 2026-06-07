using DV.Simulation.Ports;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class IndicatorPortReadersController : ARefreshableChildrenController<IndicatorPortReader>
	{
		private void Start()
		{
			SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring IndicatorPortReadersController initialization!");
				return;
			}
			IndicatorPortReader[] array = entries;
			foreach (IndicatorPortReader indicatorPortReader in array)
			{
				if (simulationFlow.TryGetPort(indicatorPortReader.portId, out var port))
				{
					simulationFlow.TryGetFuse(indicatorPortReader.fuseId, out var fuse, canBeNull: true);
					simulationFlow.TryGetPort(indicatorPortReader.indicatorRangeScalerPortId, out var port2, canBeNullOrEmpty: true);
					indicatorPortReader.Init(port, fuse, port2);
				}
			}
		}

		private void OnDestroy()
		{
			IndicatorPortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
