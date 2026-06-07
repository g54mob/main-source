namespace Simulation
{
	public class VarRailElm : VoltageInput
	{
		public double output { get; set; }

		protected override double GetVoltage()
		{
			return 0.0;
		}
	}
}
