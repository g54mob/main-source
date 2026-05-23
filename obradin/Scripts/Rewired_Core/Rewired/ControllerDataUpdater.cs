using System;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ControllerDataUpdater
	{
		public readonly InputSource source;

		public readonly int axisCount;

		public readonly int buttonCount;

		public readonly float[] axisValues;

		public readonly bool[] buttonValues;

		public readonly float[] buttonPressureValues;

		public readonly bool[] axisHasBeenPressedOSXLinux;

		private readonly UnknownControllerHat[] AEKggMXYaAjkhvdIpTgwtPgMhWUg;

		public bool hasReceivedInput;

		public ControllerDataUpdater(InputSource source, int axisCount, int buttonCount, UnknownControllerHat[] unknownControllerHats)
		{
			if (axisCount < 0 || buttonCount < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.source = source;
			this.axisCount = axisCount;
			this.buttonCount = buttonCount;
			AEKggMXYaAjkhvdIpTgwtPgMhWUg = unknownControllerHats;
			axisValues = new float[axisCount];
			buttonValues = new bool[buttonCount];
			buttonPressureValues = new float[buttonCount];
			axisHasBeenPressedOSXLinux = new bool[axisCount];
		}

		public bool IsUnknownHatCardinal(int buttonIndex)
		{
			if (AEKggMXYaAjkhvdIpTgwtPgMhWUg == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= AEKggMXYaAjkhvdIpTgwtPgMhWUg.Length)
				{
					num2 = -857627992;
					num3 = num2;
				}
				else
				{
					num2 = -857627990;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -857627991)
					{
					case 2:
						num2 = -857627990;
						continue;
					case 3:
						if (AEKggMXYaAjkhvdIpTgwtPgMhWUg[num].IsButtonIndexCardinal(buttonIndex))
						{
							return true;
						}
						num++;
						num2 = -857627991;
						continue;
					case 0:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public UnknownControllerHat.HatButtons GetUnknownHatButtons(int buttonIndex)
		{
			if (AEKggMXYaAjkhvdIpTgwtPgMhWUg == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1554635063;
				while (true)
				{
					switch (num2 ^ -1554635062)
					{
					case 0:
						break;
					case 2:
					{
						int num3;
						if (num < AEKggMXYaAjkhvdIpTgwtPgMhWUg.Length)
						{
							num2 = -1554635061;
							num3 = num2;
						}
						else
						{
							num2 = -1554635058;
							num3 = num2;
						}
						continue;
					}
					case 1:
						if (AEKggMXYaAjkhvdIpTgwtPgMhWUg[num].ContainsButtonIndex(buttonIndex))
						{
							return AEKggMXYaAjkhvdIpTgwtPgMhWUg[num].GetButtons();
						}
						num++;
						num2 = -1554635064;
						continue;
					case 3:
						num2 = -1554635064;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public void ClearData()
		{
			Array.Clear(axisValues, 0, axisValues.Length);
			Array.Clear(buttonValues, 0, buttonValues.Length);
			Array.Clear(buttonPressureValues, 0, buttonPressureValues.Length);
			Array.Clear(axisHasBeenPressedOSXLinux, 0, axisHasBeenPressedOSXLinux.Length);
			hasReceivedInput = false;
		}
	}
}
