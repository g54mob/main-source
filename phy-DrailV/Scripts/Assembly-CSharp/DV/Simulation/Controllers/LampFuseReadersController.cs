using DV.Simulation.Fuses;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class LampFuseReadersController : ARefreshableChildrenController<LampFuseReader>
	{
		private void Start()
		{
			SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring LampFuseReadersController initialization!");
				return;
			}
			LampFuseReader[] array = entries;
			foreach (LampFuseReader lampFuseReader in array)
			{
				if (simulationFlow.TryGetFuse(lampFuseReader.fuseId, out var fuse))
				{
					simulationFlow.TryGetFuse(lampFuseReader.powerFuseId, out var fuse2, canBeNull: true);
					lampFuseReader.Init(fuse, fuse2);
				}
			}
		}

		private void OnDestroy()
		{
			LampFuseReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
