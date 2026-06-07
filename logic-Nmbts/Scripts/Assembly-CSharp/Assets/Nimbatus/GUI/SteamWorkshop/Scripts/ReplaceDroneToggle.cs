using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class ReplaceDroneToggle : MonoBehaviour
	{
		private UIToggle _toggle;

		private SubmitSelectedDrone _submitDrone;

		public void Init(SubmitSelectedDrone submitDrone, bool isToggled)
		{
			_submitDrone = submitDrone;
			_toggle = GetComponent<UIToggle>();
			_toggle.value = isToggled;
			EventDelegate.Add(_toggle.onChange, OnChange, false);
		}

		public void OnDisable()
		{
			EventDelegate.Remove(_toggle.onChange, OnChange);
		}

		public void OnChange()
		{
		}
	}
}
