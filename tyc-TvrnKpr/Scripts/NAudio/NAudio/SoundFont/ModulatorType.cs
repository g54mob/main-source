namespace NAudio.SoundFont
{
	public class ModulatorType
	{
		private bool polarity;

		private bool direction;

		private bool midiContinuousController;

		private ControllerSourceEnum controllerSource;

		private SourceTypeEnum sourceType;

		private ushort midiContinuousControllerNumber;

		internal ModulatorType(ushort raw)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
