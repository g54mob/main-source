using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct LowLevelInputEvent
	{
		private const int mQyfTewXWtcskHWAhZVHAUfCgLTpA = 4;

		private const int SIhUmUMGIQNEQQcmygZHenIyrfIlA = 8;

		private const int ZLLAQDFuPqfmLxQvfAUyixOVbFHVA = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int uqOUuwbBTsrovWjFutcElKuSxSqN = 4;

		private const int ZbnhASHcDtIuobpSfzrsJTDASxviB = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int gUwjiTJXMfAtcQfYzdjeDMBDcmoZA;

		private int BhCbgrefAhFSrJIISsNLWhvlnnANA;

		private int hTtWFqoKfkIVSdGOWffSHmWvCWjfA;

		private int gGeMfATWWmDtipbPSHbUFwslYZjJ;

		private int OSnqOxbvEcfkqJshRvggJbgsHZiZ;

		private int OSizVEVHEJsfkvkjlBtLGkbkxxyBA;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => BhCbgrefAhFSrJIISsNLWhvlnnANA;

		public int axisCount => hTtWFqoKfkIVSdGOWffSHmWvCWjfA;

		public int byteIndex_axesStart => gGeMfATWWmDtipbPSHbUFwslYZjJ;

		public int byteIndex_buttonsStart => OSnqOxbvEcfkqJshRvggJbgsHZiZ;

		public int byteIndex_hatsStart => OSizVEVHEJsfkvkjlBtLGkbkxxyBA;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			BhCbgrefAhFSrJIISsNLWhvlnnANA = P_1;
			hTtWFqoKfkIVSdGOWffSHmWvCWjfA = P_2;
			OSnqOxbvEcfkqJshRvggJbgsHZiZ = 12;
			gGeMfATWWmDtipbPSHbUFwslYZjJ = OSnqOxbvEcfkqJshRvggJbgsHZiZ + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			OSizVEVHEJsfkvkjlBtLGkbkxxyBA = gGeMfATWWmDtipbPSHbUFwslYZjJ + P_2 * 4;
			gUwjiTJXMfAtcQfYzdjeDMBDcmoZA = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, OSnqOxbvEcfkqJshRvggJbgsHZiZ + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA > 0)
			{
				Marshal.WriteInt32(_buffer, gGeMfATWWmDtipbPSHbUFwslYZjJ + index * 4, new XTAWmQhXpkHzzvqvLihzDrWEQCIv(value).kjUxCLCeOmwTdVmEFkCbUvpvkNGL);
			}
		}

		public void SetId(uint id)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new ETACFlGzLpkmJUgQBNxlitBebFfv(value).OnRGbxwuqPGkvbuWZezLZSOCqLpib);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA <= 0)
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
			return (Marshal.ReadByte(_buffer, OSnqOxbvEcfkqJshRvggJbgsHZiZ + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, OSnqOxbvEcfkqJshRvggJbgsHZiZ + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA <= 0)
			{
				return 0f;
			}
			return new XTAWmQhXpkHzzvqvLihzDrWEQCIv(Marshal.ReadInt32(_buffer, gGeMfATWWmDtipbPSHbUFwslYZjJ + index * 4)).jLPJCpCUsfRocRiCfzZICodpJeXV;
		}

		public uint GetId()
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (gUwjiTJXMfAtcQfYzdjeDMBDcmoZA <= 0)
			{
				return 0.0;
			}
			return new ETACFlGzLpkmJUgQBNxlitBebFfv(Marshal.ReadInt64(_buffer, 4)).wXyFFYzIEQJuvlxLCqiYQPkffbuk;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
