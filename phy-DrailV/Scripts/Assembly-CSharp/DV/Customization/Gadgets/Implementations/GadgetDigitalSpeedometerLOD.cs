using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetDigitalSpeedometerLOD : CustomizerLODObject<GadgetBase>
	{
		public LCDDriver display;

		private void Update()
		{
			string s = string.Empty;
			if (base.Base.PowerState)
			{
				s = (base.Base.TryReadPort(STDSimPort.WheelSpeedKMH, out var value) ? Mathf.RoundToInt(value) : 0).ToString().PadLeft(display.numDigits);
			}
			display.Display(s);
		}
	}
}
