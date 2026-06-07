using Noesis;

namespace Loaf
{
	public class DiodeTool : UserControl
	{
		public double forwardVoltage;

		public double leakage;

		public double zVoltage;

		public int type;

		public bool zener;

		private Brush ogBorder;

		public TextBlock WiringHint;

		public Grid ZGrid;

		public Button UpdateButton;

		public TextBox FVInput;

		public TextBox LeakageInput;

		public TextBox ZInput;

		public Image DiodeImage;

		public Image ZenerImage;

		public Run MainDescRun;

		public DiodeTool()
		{
		}

		public DiodeTool(double fV, double l, double zV, bool z, bool editor = false)
		{
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
