namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class ControllerDataUpdater
	{
		public readonly InputSource source;

		public readonly int axisCount;

		public readonly int buttonCount;

		public readonly float[] axisValues;

		public readonly bool[] buttonValues;

		public readonly float[] buttonPressureValues;

		public readonly bool[] axisHasBeenPressedOSXLinux;

		private readonly UnknownControllerHat[] XxwzVhLfcTvhQIjapzuMJXLhbIqg;

		public bool hasReceivedInput;

		public ControllerDataUpdater(InputSource P_0, int P_1, int P_2, UnknownControllerHat[] P_3)
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
