namespace NAudio.SoundFont
{
	public class Generator
	{
		private GeneratorEnum generatorType;

		private ushort rawAmount;

		private Instrument instrument;

		private SampleHeader sampleHeader;

		public GeneratorEnum GeneratorType
		{
			get
			{
				return default(GeneratorEnum);
			}
			set
			{
			}
		}

		public ushort UInt16Amount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public short Int16Amount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte LowByteAmount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte HighByteAmount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Instrument Instrument
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SampleHeader SampleHeader
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
