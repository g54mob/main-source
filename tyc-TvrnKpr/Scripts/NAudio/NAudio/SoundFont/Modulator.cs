namespace NAudio.SoundFont
{
	public class Modulator
	{
		private ModulatorType sourceModulationData;

		private GeneratorEnum destinationGenerator;

		private short amount;

		private ModulatorType sourceModulationAmount;

		private TransformEnum sourceTransform;

		public ModulatorType SourceModulationData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GeneratorEnum DestinationGenerator
		{
			get
			{
				return default(GeneratorEnum);
			}
			set
			{
			}
		}

		public short Amount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ModulatorType SourceModulationAmount
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TransformEnum SourceTransform
		{
			get
			{
				return default(TransformEnum);
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
