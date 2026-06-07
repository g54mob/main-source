using DV.Damage;
using DV.Openables;
using UnityEngine;

namespace DV
{
	public class InternalExternalSnapshotSwitcherDoorsAndWindows : InternalExternalSnapshotSwitcher
	{
		private WindowsBreakingController windowsBreakingController;

		private DoorsAndWindowsController doorsAndWindowsController;

		private TrainCar trainCar;

		protected override void Start()
		{
			base.Start();
			trainCar = TrainCar.Resolve(base.transform);
			if (trainCar == null)
			{
				Debug.LogError("Unexpected state: TrainCar not found, can't check internality. Disabling self.", this);
				base.enabled = false;
			}
			else
			{
				trainCar.ExternalInteractableLoaded += OnExternalInteractablesLoaded;
				windowsBreakingController = trainCar.GetComponent<WindowsBreakingController>();
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && trainCar != null)
			{
				trainCar.ExternalInteractableLoaded -= OnExternalInteractablesLoaded;
			}
		}

		public override bool IsInside()
		{
			if (base.IsInside() && (windowsBreakingController == null || !windowsBreakingController.windowsBroken))
			{
				if (!(doorsAndWindowsController == null))
				{
					return !doorsAndWindowsController.AnythingOpen();
				}
				return true;
			}
			return false;
		}

		private void OnExternalInteractablesLoaded(GameObject loadedExternalInteractables)
		{
			if (loadedExternalInteractables != null)
			{
				doorsAndWindowsController = trainCar.loadedExternalInteractables.GetComponent<DoorsAndWindowsController>();
				if (doorsAndWindowsController == null)
				{
					Debug.LogError("Unexpected state: Can't find DoorsAndWindowsController! Doors/Windows will be ignored for internality", base.gameObject);
				}
			}
			else
			{
				doorsAndWindowsController = null;
			}
		}
	}
}
