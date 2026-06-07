using DV.LocoRestoration;
using DV.ThingTypes;
using UnityEngine;

namespace DV.PitStops
{
	public class PitStopRefresherForLocoRestoration : MonoBehaviour
	{
		private PitStop pitStopToRefresh;

		public LocoRestorationController[] restorationControllers;

		private void Awake()
		{
			pitStopToRefresh = GetComponent<PitStop>();
			if (pitStopToRefresh == null)
			{
				Debug.LogError("Unexpected state: no PitStop found. PitStopRefresherForLocoRestoration can't function.");
				Object.Destroy(this);
				return;
			}
			if (restorationControllers == null || restorationControllers.Length == 0)
			{
				Debug.LogError("Unexpected state: no restorationControllers set. PitStopRefresherForLocoRestoration can't function.");
				Object.Destroy(this);
				return;
			}
			LocoRestorationController[] array = restorationControllers;
			foreach (LocoRestorationController locoRestorationController in array)
			{
				if (locoRestorationController.State < LocoRestorationController.RestorationState.S8_PartInstalled)
				{
					locoRestorationController.StateChanged += OnLocoRestorationStateChanged;
				}
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && restorationControllers != null)
			{
				LocoRestorationController[] array = restorationControllers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].StateChanged -= OnLocoRestorationStateChanged;
				}
			}
		}

		private void OnLocoRestorationStateChanged(LocoRestorationController rc, TrainCarLivery __, LocoRestorationController.RestorationState state)
		{
			if (state >= LocoRestorationController.RestorationState.S8_PartInstalled)
			{
				pitStopToRefresh.RefreshPitStopCarPresence();
				rc.StateChanged -= OnLocoRestorationStateChanged;
			}
		}
	}
}
