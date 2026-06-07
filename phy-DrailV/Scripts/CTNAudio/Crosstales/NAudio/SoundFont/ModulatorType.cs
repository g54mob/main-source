namespace Crosstales.NAudio.SoundFont
{
	public class ModulatorType
	{
		private bool midiContinuousController;

		private ControllerSourceEnum controllerSource;

		private SourceTypeEnum sourceType;

		private ushort midiContinuousControllerNumber;

		internal ModulatorType(ushort raw)
		{
			midiContinuousController = (raw & 0x80) == 128;
			sourceType = (SourceTypeEnum)((raw & 0xFC00) >> 10);
			controllerSource = (ControllerSourceEnum)(raw & 0x7F);
			midiContinuousControllerNumber = (ushort)(raw & 0x7F);
		}

		public override string ToString()
		{
			if (midiContinuousController)
			{
				return $"{sourceType} CC{midiContinuousControllerNumber}";
			}
			return $"{sourceType} {controllerSource}";
		}
	}
}
