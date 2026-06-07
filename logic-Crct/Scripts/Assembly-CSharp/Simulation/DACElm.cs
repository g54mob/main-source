using Unity.Burst;

namespace Simulation
{
	public class DACElm : Chip
	{
		public override string GetName()
		{
			return null;
		}

		public override bool needsBits()
		{
			return false;
		}

		public override void SetupPins()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override int GetLeadCount()
		{
			return 0;
		}
	}
}
