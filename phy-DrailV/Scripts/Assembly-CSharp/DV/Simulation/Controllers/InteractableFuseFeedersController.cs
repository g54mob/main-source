using System.Collections;
using DV.Simulation.Fuses;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class InteractableFuseFeedersController : ARefreshableChildrenController<InteractableFuseFeeder>
	{
		private IEnumerator Start()
		{
			SimulationFlow simFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring InteractableFuseFeedersController initialization!");
				yield break;
			}
			yield return null;
			yield return null;
			InteractableFuseFeeder[] array = entries;
			foreach (InteractableFuseFeeder interactableFuseFeeder in array)
			{
				if (simFlow.TryGetFuse(interactableFuseFeeder.fuseId, out var fuse))
				{
					interactableFuseFeeder.Init(fuse);
				}
			}
			yield return null;
			array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetupInputChangedListeners();
			}
		}

		private void OnDestroy()
		{
			InteractableFuseFeeder[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
