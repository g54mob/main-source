using DV.Utils;
using UnityEngine;

namespace DV
{
	public class InternalExternalSnapshotSwitcher : MonoBehaviour
	{
		public CameraTrigger trigger;

		protected virtual void Start()
		{
			if (!SingletonBehaviour<AudioManager>.Instance || !trigger)
			{
				Debug.LogError("AudioManager instance or camera trigger not found. This should not happen. Disabling self.", this);
				base.enabled = false;
			}
		}

		private void OnEnable()
		{
			SingletonBehaviour<InternalExternalSnapshotSwitcherManager>.Instance.AddSwitcher(this);
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<InternalExternalSnapshotSwitcherManager>.Instance.RemoveSwitcher(this);
			}
		}

		public virtual bool IsInside()
		{
			return trigger.IsMainCameraInside;
		}
	}
}
