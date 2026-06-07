using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int jxWPWVnkAZXjxHjsrRifHTMhvHeI = 4;

		private const int BcHMoiGciEnxDxBZbcjBeIcpSXSi = 8;

		private const int BYmlGckAoZwVDgCQpozbLIjjadyG = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int bCUFfYzlrpljnLHlWVUdNOpSwubv = 4;

		private const int rqgFqUAGeHAIkdAWjzEMDkKClmgaE = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int ZLzYkcwJUEqirUdMAqAnhDRyAsab;

		private int PqNlHDZGphKekzifnnpgUjgsbCwcA;

		private int rgOGdDKOoenvHrmuSlnColqqiiBm;

		private int BKiBuyCNQkZmjECaLbdYAqhiAapz;

		private int LsNmmQFVHODkAVerHqIVEvvqTqUE;

		private int uDHvjzgXqxZdOEbVkuNfgzJJVmeD;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => PqNlHDZGphKekzifnnpgUjgsbCwcA;

		public int axisCount => rgOGdDKOoenvHrmuSlnColqqiiBm;

		public int byteIndex_axesStart => BKiBuyCNQkZmjECaLbdYAqhiAapz;

		public int byteIndex_buttonsStart => LsNmmQFVHODkAVerHqIVEvvqTqUE;

		public int byteIndex_hatsStart => uDHvjzgXqxZdOEbVkuNfgzJJVmeD;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			PqNlHDZGphKekzifnnpgUjgsbCwcA = P_1;
			rgOGdDKOoenvHrmuSlnColqqiiBm = P_2;
			LsNmmQFVHODkAVerHqIVEvvqTqUE = 12;
			BKiBuyCNQkZmjECaLbdYAqhiAapz = LsNmmQFVHODkAVerHqIVEvvqTqUE + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			uDHvjzgXqxZdOEbVkuNfgzJJVmeD = BKiBuyCNQkZmjECaLbdYAqhiAapz + P_2 * 4;
			ZLzYkcwJUEqirUdMAqAnhDRyAsab = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, LsNmmQFVHODkAVerHqIVEvvqTqUE + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab > 0)
			{
				Marshal.WriteInt32(_buffer, BKiBuyCNQkZmjECaLbdYAqhiAapz + index * 4, new pkqsyCeiOpeyJhDMJthvAjsyMfKR(value).KJilWQAMgzdwTiaDYLpNdotbDOpm);
			}
		}

		public void SetId(uint id)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new qmwPQjVFyieflEqzPCxrxmfYhgpR(value).QRiaeaLGJOIhPrOaLOYCsIHpkTJP);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab <= 0)
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
			return (Marshal.ReadByte(_buffer, LsNmmQFVHODkAVerHqIVEvvqTqUE + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, LsNmmQFVHODkAVerHqIVEvvqTqUE + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab <= 0)
			{
				return 0f;
			}
			return new pkqsyCeiOpeyJhDMJthvAjsyMfKR(Marshal.ReadInt32(_buffer, BKiBuyCNQkZmjECaLbdYAqhiAapz + index * 4)).gQyOWSPhpJJPAdALInsnOahefrmm;
		}

		public uint GetId()
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (ZLzYkcwJUEqirUdMAqAnhDRyAsab <= 0)
			{
				return 0.0;
			}
			return new qmwPQjVFyieflEqzPCxrxmfYhgpR(Marshal.ReadInt64(_buffer, 4)).NnXGdPnOZwZVxaZAeuSxbtxAzLMi;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
