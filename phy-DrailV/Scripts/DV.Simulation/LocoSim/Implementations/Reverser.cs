using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class Reverser : SimComponent
	{
		public const float FORWARD_VALUE = 1f;

		public const float NEUTRAL_VALUE = 0f;

		public const float REVERSE_VALUE = -1f;

		private const float FORWARD_POSITION = 1f;

		private const float NEUTRAL_POSITION = 0.5f;

		private const float REVERSE_POSITION = 0f;

		public readonly bool isAnalog;

		public readonly Port controlExtIn;

		public readonly Port reverserReadOut;

		public Reverser(ReverserDefinition rDef)
			: base(rDef.ID)
		{
			isAnalog = rDef.isAnalog;
			controlExtIn = AddPort(rDef.controlExtIn, 0.5f);
			reverserReadOut = AddPort(rDef.reverserReadOut);
		}

		public override void Tick(float delta)
		{
			float num = reverserReadOut.Value;
			float value = controlExtIn.Value;
			if (isAnalog)
			{
				num = value * 2f - 1f;
			}
			else if (num != -1f && value == 0f)
			{
				num = -1f;
			}
			else if (num != 0f && value == 0.5f)
			{
				num = 0f;
			}
			else if (num != 1f && value == 1f)
			{
				num = 1f;
			}
			reverserReadOut.Value = num;
		}
	}
}
