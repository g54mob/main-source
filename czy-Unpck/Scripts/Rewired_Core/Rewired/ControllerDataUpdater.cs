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

		private readonly UnknownControllerHat[] YECYJYNyHEIQBsagKiPbSLCXPQy;

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
			YECYJYNyHEIQBsagKiPbSLCXPQy = unknownControllerHats;
			axisValues = new float[axisCount];
			buttonValues = new bool[buttonCount];
			buttonPressureValues = new float[buttonCount];
			axisHasBeenPressedOSXLinux = new bool[axisCount];
		}

		public bool IsUnknownHatCardinal(int buttonIndex)
		{
			if (YECYJYNyHEIQBsagKiPbSLCXPQy == null)
			{
				return false;
			}
			int num = 0;
			while (num < YECYJYNyHEIQBsagKiPbSLCXPQy.Length)
			{
				while (true)
				{
					int num2;
					if (YECYJYNyHEIQBsagKiPbSLCXPQy[num].IsButtonIndexCardinal(buttonIndex))
					{
						num2 = -1570897915;
					}
					else
					{
						num++;
						num2 = -1570897913;
					}
					while (true)
					{
						switch (num2 ^ -1570897913)
						{
						case 3:
							num2 = -1570897914;
							continue;
						case 1:
							break;
						case 2:
							return true;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return false;
		}

		public UnknownControllerHat.HatButtons GetUnknownHatButtons(int buttonIndex)
		{
			if (YECYJYNyHEIQBsagKiPbSLCXPQy == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < YECYJYNyHEIQBsagKiPbSLCXPQy.Length)
				{
					num2 = -816107718;
					num3 = num2;
				}
				else
				{
					num2 = -816107719;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -816107717)
					{
					case 0:
						num2 = -816107718;
						continue;
					case 1:
						if (YECYJYNyHEIQBsagKiPbSLCXPQy[num].ContainsButtonIndex(buttonIndex))
						{
							return YECYJYNyHEIQBsagKiPbSLCXPQy[num].GetButtons();
						}
						num++;
						num2 = -816107720;
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
			while (true)
			{
				int num = -1793777095;
				while (true)
				{
					switch (num ^ -1793777093)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0032;
					case 1:
						return;
					}
					break;
					IL_0032:
					Array.Clear(buttonValues, 0, buttonValues.Length);
					Array.Clear(buttonPressureValues, 0, buttonPressureValues.Length);
					Array.Clear(axisHasBeenPressedOSXLinux, 0, axisHasBeenPressedOSXLinux.Length);
					hasReceivedInput = false;
					num = -1793777094;
				}
			}
		}
	}
}
