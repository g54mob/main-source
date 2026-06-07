using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int dFWrVfpVIcKEFlSmwbBIGAXymRtv = 4;

		private const int ZzDzYSUOunHknZURuiiivHryEeRCA = 8;

		private const int XkwftCegOkKjdiUKeToGHCZceSpjc = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int hkMIfmjxbAuqZhmtJyOIYYoJsMax = 4;

		private const int zrkeasIyUiREjoIauYnclTHkCjbC = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int XxxAYMcuRpMjENunDymfNsMzOohbb;

		private int BKDipfJYzAOvARNtsGbPJZrnyuzBA;

		private int xBAOSxUqyXacnNMgVbpdbtpxAGOSA;

		private int NSglFQMpADeCJoImOhnnINmxUQsmA;

		private int XeDGwIiFLpCOazrsStcyVrwhWhNM;

		private int eCLhnFiuVUWYunapxmgKYnqWDlvTA;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => BKDipfJYzAOvARNtsGbPJZrnyuzBA;

		public int axisCount => xBAOSxUqyXacnNMgVbpdbtpxAGOSA;

		public int byteIndex_axesStart => NSglFQMpADeCJoImOhnnINmxUQsmA;

		public int byteIndex_buttonsStart => XeDGwIiFLpCOazrsStcyVrwhWhNM;

		public int byteIndex_hatsStart => eCLhnFiuVUWYunapxmgKYnqWDlvTA;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			BKDipfJYzAOvARNtsGbPJZrnyuzBA = P_1;
			xBAOSxUqyXacnNMgVbpdbtpxAGOSA = P_2;
			XeDGwIiFLpCOazrsStcyVrwhWhNM = 12;
			NSglFQMpADeCJoImOhnnINmxUQsmA = XeDGwIiFLpCOazrsStcyVrwhWhNM + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			eCLhnFiuVUWYunapxmgKYnqWDlvTA = NSglFQMpADeCJoImOhnnINmxUQsmA + P_2 * 4;
			XxxAYMcuRpMjENunDymfNsMzOohbb = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, XeDGwIiFLpCOazrsStcyVrwhWhNM + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb > 0)
			{
				Marshal.WriteInt32(_buffer, NSglFQMpADeCJoImOhnnINmxUQsmA + index * 4, new bAekjaaItWpGfFFAWrkCRgrbDBDJ(value).WRypziGtoGiyhYNHZTRuommeDdcz);
			}
		}

		public void SetId(uint id)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new qtyfXZTwmZMmJyIbWTlEopqZHSar(value).UZmNcURxZrCoxBfgCDQlzsKuefUEA);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb <= 0)
			{
				return false;
			}
			if (buttonCount == 0)
			{
				return false;
			}
			int num = index / 32;
			int num2 = (index - num * 32) / 8;
			int num3 = index % 8;
			return (Marshal.ReadByte(_buffer, XeDGwIiFLpCOazrsStcyVrwhWhNM + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, XeDGwIiFLpCOazrsStcyVrwhWhNM + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb <= 0)
			{
				return 0f;
			}
			return new bAekjaaItWpGfFFAWrkCRgrbDBDJ(Marshal.ReadInt32(_buffer, NSglFQMpADeCJoImOhnnINmxUQsmA + index * 4)).cMwOOcTwzeqQuLmZLGzAFBytKDhXA;
		}

		public uint GetId()
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (XxxAYMcuRpMjENunDymfNsMzOohbb <= 0)
			{
				return 0.0;
			}
			return new qtyfXZTwmZMmJyIbWTlEopqZHSar(Marshal.ReadInt64(_buffer, 4)).VsZplzfANPgCXExAfUeOgIkRUFBv;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
