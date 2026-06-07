using DV.CabControls;

namespace DV.HUD
{
	public class ToggleSwitchZeroOneNames : ControlNameHolderBase
	{
		private ToggleSwitchBase toggle;

		private void Start()
		{
			toggle = GetComponent<ToggleSwitchBase>();
		}

		public override (string value, string unit) GetName()
		{
			return (value: toggle.IsOn ? "1" : "0", unit: "");
		}
	}
}
