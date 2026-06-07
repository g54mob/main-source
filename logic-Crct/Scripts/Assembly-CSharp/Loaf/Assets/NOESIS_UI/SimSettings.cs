using Noesis;

namespace Loaf.Assets.NOESIS_UI
{
	public class SimSettings : UserControl
	{
		private static SimSettings inst;

		private static bool loading;

		private static bool settingFreq;

		private static float freq;

		private static float timeStep;

		private static float realtime;

		private static bool throttle;

		private bool sliderLock;

		private static float rtMin;

		private static float rtMax;

		private static float rtRange;

		private static float rtExponent;

		private static float freqMin;

		private static float freqMax;

		private static float freqRange;

		private static float freqExponent;

		public Noesis.Label FreqValueLabel;

		public Noesis.Label RealTimeValueLabel;

		public Noesis.Label MultiplierLabel;

		public Slider FreqSlider;

		public Slider RealTimeSlider;

		public CheckBox AutoCheck;

		public Button CancelButton;

		public Button DefaultsButton;

		public Button ApplyButton;

		public CheckBox DPICheck;

		public Slider ScaleSlider;

		public Noesis.Label ScaleLabel;

		private void ScaleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<float> e)
		{
		}

		private void DPICheck_Click(object sender, RoutedEventArgs args)
		{
		}

		private void RealTimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<float> e)
		{
		}

		private void FreqSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<float> e)
		{
		}

		public static void LoadSettings(bool defaults = false)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
