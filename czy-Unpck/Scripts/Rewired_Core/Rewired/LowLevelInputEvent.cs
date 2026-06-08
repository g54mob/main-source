using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int QveFBODhqrgrDLKaKlFUmYkAiq = 4;

		private const int koggVpiHfPIoNJOwpfcLpuzSCZd = 8;

		private const int pKWADyUaEnaBGBduekSkjzIlqsw = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int GzTuUJFuOdkLqJHUrMnGjZqidjR = 4;

		private const int rkJSjgKwuHirgaCsWLiaXowuEEi = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int EUheJgpizodhxRBAiAFyMzafsNH;

		private int bIVKqEWQlcsQuBjQNcfTnhQBcMzH;

		private int HdwDFHEjYnWvNocUPRQUFfWDpFW;

		private int YNjROrnsffLBnysLXAzAXOBTLdE;

		private int qBiUwOBhtxwunGfjMEZgXARYeQF;

		private int kfrXspjvkGfDlgbQkReTcgYOOyV;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => bIVKqEWQlcsQuBjQNcfTnhQBcMzH;

		public int axisCount => HdwDFHEjYnWvNocUPRQUFfWDpFW;

		public int byteIndex_axesStart => YNjROrnsffLBnysLXAzAXOBTLdE;

		public int byteIndex_buttonsStart => qBiUwOBhtxwunGfjMEZgXARYeQF;

		public int byteIndex_hatsStart => kfrXspjvkGfDlgbQkReTcgYOOyV;

		public LowLevelInputEvent(IntPtr buffer, int buttonCount, int axisCount, int hatCount)
		{
			if (buttonCount == 0 && axisCount == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = buffer;
			bIVKqEWQlcsQuBjQNcfTnhQBcMzH = buttonCount;
			HdwDFHEjYnWvNocUPRQUFfWDpFW = axisCount;
			qBiUwOBhtxwunGfjMEZgXARYeQF = 12;
			YNjROrnsffLBnysLXAzAXOBTLdE = qBiUwOBhtxwunGfjMEZgXARYeQF + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0);
			kfrXspjvkGfDlgbQkReTcgYOOyV = YNjROrnsffLBnysLXAzAXOBTLdE + axisCount * 4;
			EUheJgpizodhxRBAiAFyMzafsNH = GetReportSize(buttonCount, axisCount, hatCount);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				goto IL_0009;
			}
			goto IL_004c;
			IL_0009:
			int num = -2014190847;
			goto IL_000e;
			IL_000e:
			switch (num ^ -2014190848)
			{
			case 3:
				break;
			default:
				return;
			case 4:
				goto IL_002f;
			case 2:
				goto IL_004c;
			case 1:
				return;
			case 0:
				return;
			}
			goto IL_0009;
			IL_004c:
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			goto IL_002f;
			IL_002f:
			Marshal.WriteInt32(_buffer, qBiUwOBhtxwunGfjMEZgXARYeQF + startButtonIndex / 4, bitMask);
			num = -2014190848;
			goto IL_000e;
		}

		public void SetAxisValue(int index, float value)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				goto IL_0009;
			}
			goto IL_0033;
			IL_0009:
			int num = -1614752246;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1614752245)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_0033;
			case 3:
				return;
			}
			goto IL_0009;
			IL_0033:
			Marshal.WriteInt32(_buffer, YNjROrnsffLBnysLXAzAXOBTLdE + index * 4, new deFkfjHJIndjmwybARqvXpzyvbn(value).OIPYdeiAtjrgmUOEAKGdQjUXXZz);
			num = -1614752248;
			goto IL_000e;
		}

		public void SetId(uint id)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				return;
			}
			while (true)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
				int num = 76679048;
				while (true)
				{
					switch (num ^ 0x4920788)
					{
					case 2:
						goto IL_000a;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000a:
					num = 76679049;
				}
			}
		}

		public void SetTimestamp(double value)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				return;
			}
			while (true)
			{
				Marshal.WriteInt64(_buffer, 4, new uuZEVAsssygoWDnMEtLzeloUKkC(value).cCsxCABHQVoqpNKCtTBYcfylgG);
				int num = 2078737156;
				while (true)
				{
					switch (num ^ 0x7BE70306)
					{
					case 0:
						goto IL_000a;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000a:
					num = 2078737159;
				}
			}
		}

		public bool GetButtonValue(int index)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				goto IL_0009;
			}
			int num;
			if (buttonCount == 0)
			{
				num = -1973179276;
				goto IL_000e;
			}
			int num2 = index / 32;
			int num3 = (index - num2 * 32) / 8;
			int num4 = index % 8;
			return (Marshal.ReadByte(_buffer, qBiUwOBhtxwunGfjMEZgXARYeQF + num2 * 4 + num3) & (1 << num4)) != 0;
			IL_0009:
			num = -1973179275;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1973179276)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0009;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, qBiUwOBhtxwunGfjMEZgXARYeQF + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				return 0f;
			}
			return new deFkfjHJIndjmwybARqvXpzyvbn(Marshal.ReadInt32(_buffer, YNjROrnsffLBnysLXAzAXOBTLdE + index * 4)).VlYIlGajNcGszIOIaHnUWsGNPwm;
		}

		public uint GetId()
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (EUheJgpizodhxRBAiAFyMzafsNH <= 0)
			{
				return 0.0;
			}
			return new uuZEVAsssygoWDnMEtLzeloUKkC(Marshal.ReadInt64(_buffer, 4)).UXdbVhPdvRMFwgXLHmAEWhFVQOJ;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
