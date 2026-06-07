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

		private readonly UnknownControllerHat[] xDAljZdVmQkFYZMJDvkyWEyQENNA;

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
			xDAljZdVmQkFYZMJDvkyWEyQENNA = unknownControllerHats;
			axisValues = new float[axisCount];
			buttonValues = new bool[buttonCount];
			buttonPressureValues = new float[buttonCount];
			axisHasBeenPressedOSXLinux = new bool[axisCount];
		}

		public bool IsUnknownHatCardinal(int buttonIndex)
		{
			if (xDAljZdVmQkFYZMJDvkyWEyQENNA == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1481949113;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x5854BFBB)
				{
				case 0:
					break;
				case 1:
					if (xDAljZdVmQkFYZMJDvkyWEyQENNA[num].IsButtonIndexCardinal(buttonIndex))
					{
						return true;
					}
					num++;
					num2 = 1481949119;
					continue;
				case 2:
					num2 = 1481949119;
					continue;
				case 3:
					return false;
				default:
					if (num >= xDAljZdVmQkFYZMJDvkyWEyQENNA.Length)
					{
						return false;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1481949112;
			goto IL_000d;
		}

		public UnknownControllerHat.HatButtons GetUnknownHatButtons(int buttonIndex)
		{
			if (xDAljZdVmQkFYZMJDvkyWEyQENNA == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < xDAljZdVmQkFYZMJDvkyWEyQENNA.Length)
				{
					num2 = -1415052493;
					num3 = num2;
				}
				else
				{
					num2 = -1415052496;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1415052495)
					{
					case 0:
						num2 = -1415052493;
						continue;
					case 2:
						if (xDAljZdVmQkFYZMJDvkyWEyQENNA[num].ContainsButtonIndex(buttonIndex))
						{
							return xDAljZdVmQkFYZMJDvkyWEyQENNA[num].GetButtons();
						}
						num++;
						num2 = -1415052494;
						continue;
					case 3:
						break;
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
