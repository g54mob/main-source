using Noesis;

namespace Loaf
{
	public class CapacitorTool : UserControl
	{
		public double farads;

		public int type;

		private Brush ogBorder;

		public TextBlock WiringHint;

		public ComboBox FaradUnitCombo;

		public ComboBox TypeCombo;

		public Button UpdateButton;

		public TextBox FaradInput;

		public CapacitorTool()
		{
		}

		public CapacitorTool(double f, int t, bool editor = false)
		{
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void FaradReverseConversion(double f, ref TextBox input, ref ComboBox drop)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
