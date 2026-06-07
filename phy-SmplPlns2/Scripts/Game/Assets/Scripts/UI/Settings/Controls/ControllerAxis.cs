using Jundroo.Juicy.Widgets;
using Rewired;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class ControllerAxis
	{
		public Widget Button { get; set; }

		public AxisCalibration Calibration { get; set; }

		public Controller.Axis InputAxis { get; set; }

		public ControllerWithAxes Controller { get; set; }

		public string Name { get; set; }
	}
}
