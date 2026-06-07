using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ToggleBorders : ToggleButton
	{
		public GameObject BorderParent;

		private static bool _isToggled = true;

		public override void Start()
		{
			base.Start();
			BorderParent.SetActive(_isToggled);
		}

		protected override void Toggle(bool toggle)
		{
			_isToggled = toggle;
			BorderParent.SetActive(_isToggled);
		}

		protected override bool IsToggled()
		{
			return _isToggled;
		}
	}
}
