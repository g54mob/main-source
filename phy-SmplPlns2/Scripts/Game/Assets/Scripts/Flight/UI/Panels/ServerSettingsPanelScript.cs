using Assets.Scripts.UI.Controls;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class ServerSettingsPanelScript : FlightPanelScript
	{
		private SliderControl _maxPartCountSlider;

		private ToggleControl _peacefulModeToggle;

		private SliderControl _tickRateSlider;

		public override void InitializeFlightPanel(FlightUIScript flightUI)
		{
			base.InitializeFlightPanel(flightUI);
			_tickRateSlider = new SliderControl(base.Widget.FindWidget("tick-rate-slider"));
			_tickRateSlider.Slider.MinValue = 10f;
			_tickRateSlider.Slider.MaxValue = 50f;
			_tickRateSlider.Slider.NumberOfSteps = (int)((_tickRateSlider.Slider.MaxValue - _tickRateSlider.Slider.MinValue) / 5f) + 1;
			_tickRateSlider.Slider.ValueChanged += delegate(float x)
			{
				FlightSceneScript.Instance.FlightSceneNetwork.ServerTickRate = (ushort)x;
			};
			_maxPartCountSlider = new SliderControl(base.Widget.FindWidget("max-part-count-slider"));
			_maxPartCountSlider.Slider.MinValue = 0f;
			_maxPartCountSlider.Slider.MaxValue = 1000f;
			_maxPartCountSlider.Slider.NumberOfSteps = (int)((_maxPartCountSlider.Slider.MaxValue - _maxPartCountSlider.Slider.MinValue) / 25f) + 1;
			_maxPartCountSlider.ValueFormatter = (float x) => (x != 0f) ? x.ToString() : "No Limit";
			_maxPartCountSlider.Slider.ValueChanged += delegate(float x)
			{
				FlightSceneScript.Instance.FlightSceneNetwork.ServerMaxPartCount = (ushort)x;
			};
			_peacefulModeToggle = new ToggleControl(base.Widget.FindWidget("peaceful-mode-toggle"));
			_peacefulModeToggle.Toggle.ValueChanged += delegate(bool x)
			{
				FlightSceneScript.IsPeacefulMode = x;
			};
			base.Flyout.Opened += delegate
			{
				_tickRateSlider.Slider.Value = (int)FlightSceneScript.Instance.FlightSceneNetwork.ServerTickRate;
				_maxPartCountSlider.Slider.Value = (int)FlightSceneScript.Instance.FlightSceneNetwork.ServerMaxPartCount;
				_peacefulModeToggle.Toggle.IsOn = FlightSceneScript.IsPeacefulMode;
			};
		}
	}
}
