using Noesis;

namespace Loaf
{
	public class _7SegDisplayTool : UserControl
	{
		public double forwardVoltage;

		public double maxCurrent;

		public int type;

		private Brush ogBorder;

		public Button UpdateButton;

		public Button CreateButton;

		public TextBox FVInput;

		public TextBox CurrentInput;

		public ComboBox TypeCombo;

		public _7SegDisplayTool()
		{
		}

		private void CreateButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public _7SegDisplayTool(double fV, double maxI, int t, bool editor = false)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
