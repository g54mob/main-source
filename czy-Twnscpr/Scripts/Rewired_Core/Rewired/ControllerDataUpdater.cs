namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class ControllerDataUpdater
	{
		public readonly InputSource source;

		public readonly int axisCount;

		public readonly int buttonCount;

		public readonly float[] axisValues;

		public readonly bool[] buttonValues;

		public readonly float[] buttonPressureValues;

		public readonly bool[] axisHasBeenPressedOSXLinux;

		private readonly UnknownControllerHat[] xtqdDCNGuTDwJdSUWmYrwlMTOOa;

		public bool hasReceivedInput;

		public ControllerDataUpdater(InputSource source, int axisCount, int buttonCount, UnknownControllerHat[] unknownControllerHats)
		{
		}

		public bool IsUnknownHatCardinal(int buttonIndex)
		{
			return false;
		}

		public UnknownControllerHat.HatButtons GetUnknownHatButtons(int buttonIndex)
		{
			return null;
		}

		public void ClearData()
		{
		}
	}
}
