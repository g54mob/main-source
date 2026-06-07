using DV.CabControls.VRTK;
using UnityEngine;

namespace DV.CabControls
{
	public class DoorClosedVRTouchDisable : MonoBehaviour
	{
		public GameObject door;

		public float closedValue;

		public float threshold = 0.1f;

		public bool offWhenClosed = true;

		private ControlImplBase doorControl;

		private VRTK_ControlImplBaseInteractableObject thisControl;

		private void Start()
		{
			if (!VRManager.IsVREnabled())
			{
				Object.Destroy(this);
				return;
			}
			if (!door)
			{
				Debug.LogError("Did not assign door field!");
				base.enabled = false;
				return;
			}
			doorControl = door.GetComponent<ControlImplBase>();
			if (!doorControl)
			{
				Debug.LogError("Could not find ControlImplBase on door!", base.gameObject);
				base.enabled = false;
			}
			thisControl = GetComponent<VRTK_ControlImplBaseInteractableObject>();
			if (!thisControl)
			{
				Debug.LogError("Could not find VRTK_ControlImplBaseInteractableObject on this!", base.gameObject);
				base.enabled = false;
			}
			doorControl.ValueChanged += DoorControlOnValueChanged;
			Refresh();
		}

		private void DoorControlOnValueChanged(ValueChangedEventArgs _)
		{
			Refresh();
		}

		private void Refresh()
		{
			bool flag = doorControl.Value.IsInRange(closedValue - threshold, closedValue + threshold) != offWhenClosed;
			thisControl.touchDisabled = !flag;
		}
	}
}
