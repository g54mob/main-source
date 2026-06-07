using System.Collections;
using DV.Simulation.Cars;
using DV.Simulation.Ports;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class InteractablePortFeedersController : ARefreshableChildrenController<InteractablePortFeeder>
	{
		public bool IsCurrentlySettingInitialValues { get; private set; }

		private IEnumerator Start()
		{
			IsCurrentlySettingInitialValues = true;
			SimController simController = TrainCar.Resolve(base.transform)?.SimController;
			SimulationFlow simFlow = simController?.simFlow;
			if (simFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring InteractablePortFeedersController initialization!");
				yield break;
			}
			ControlsBlockController controlsBlocker = simController?.controlsBlocker;
			yield return null;
			yield return null;
			InteractablePortFeeder[] array = entries;
			foreach (InteractablePortFeeder interactablePortFeeder in array)
			{
				if (simFlow.TryGetPort(interactablePortFeeder.portId, out var port))
				{
					ControlBlocker controlBlocker = ((controlsBlocker != null) ? controlsBlocker.GetBlockDefinition(interactablePortFeeder.portId) : null);
					interactablePortFeeder.Init(port, controlBlocker);
				}
			}
			yield return null;
			array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetupControlChangedListeners();
			}
			IsCurrentlySettingInitialValues = false;
		}

		private void OnDestroy()
		{
			InteractablePortFeeder[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
