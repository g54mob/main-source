namespace NAudio.SoundFont
{
	public class Zone
	{
		internal ushort generatorIndex;

		internal ushort modulatorIndex;

		internal ushort generatorCount;

		internal ushort modulatorCount;

		private Modulator[] modulators;

		private Generator[] generators;

		public Modulator[] Modulators
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Generator[] Generators
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string ToString()
		{
			return null;
		}
	}
}
