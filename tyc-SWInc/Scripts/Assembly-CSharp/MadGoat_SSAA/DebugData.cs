namespace MadGoat_SSAA
{
	public class DebugData
	{
		public MadGoatSSAA instance;

		public Mode renderMode
		{
			get
			{
				return instance.renderMode;
			}
		}

		public float multiplier
		{
			get
			{
				return instance.multiplier;
			}
		}

		public bool fssaa
		{
			get
			{
				return instance.ssaaUltra;
			}
		}

		public DebugData(MadGoatSSAA instance)
		{
			this.instance = instance;
		}
	}
}
