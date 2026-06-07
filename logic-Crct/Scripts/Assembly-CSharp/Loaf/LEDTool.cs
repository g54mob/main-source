using Noesis;

namespace Loaf
{
	public class LEDTool : UserControl
	{
		public double forwardVoltage;

		public double maxCurrent;

		private Button[] colorButtons;

		private int currentColId;

		private Brush ogBorder;

		public TextBlock WiringHint;

		public Button UpdateButton;

		public TextBox FVInput;

		public TextBox MaxCurrentInput;

		public Button BlueButton;

		public Button PurpleButton;

		public Button WhiteButton;

		public Button GreenButton;

		public Button YellowButton;

		public Button OrangeButton;

		public Button RedButton;

		public LEDTool()
		{
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public LEDTool(double fV, double maxI, int col, bool editor = false)
		{
		}

		private void UpdateButtons(int i)
		{
		}

		private void RedButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void OrangeButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void YellowButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void GreenButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void WhiteButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void PurpleButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void BlueButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
