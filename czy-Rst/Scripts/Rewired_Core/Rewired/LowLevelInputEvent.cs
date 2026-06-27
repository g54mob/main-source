using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int cehDWysaLsfsmTqiLdiQhOYXJvMq = 4;

		private const int AamCPDJxtRCOrfBPUBiKcoThGkJA = 8;

		private const int KYTtRHfJxqRWIaIYVPHQtCTFuWWC = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int kYpbFnswsMSDmXCteatIzMveeiHcA = 4;

		private const int gqBVijJabmdpdbQCLDbruCGZYuQqA = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int ImCUmFtIMfFPzSafeTnjVwLKElUl;

		private int QwyfioUsmYJjzffvTATZwNcIQSWF;

		private int qHtCAkPjlZpUYvjcuaShbEySOgjY;

		private int SKJdJRJVLVaVeUYgxUPdqjbKyRVl;

		private int OZwuJHWAHxcIVFeMxJjeitEMPIif;

		private int bbmlUEvIYUseVWjqITGUOfVbRDSD;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => QwyfioUsmYJjzffvTATZwNcIQSWF;

		public int axisCount => qHtCAkPjlZpUYvjcuaShbEySOgjY;

		public int byteIndex_axesStart => SKJdJRJVLVaVeUYgxUPdqjbKyRVl;

		public int byteIndex_buttonsStart => OZwuJHWAHxcIVFeMxJjeitEMPIif;

		public int byteIndex_hatsStart => bbmlUEvIYUseVWjqITGUOfVbRDSD;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			QwyfioUsmYJjzffvTATZwNcIQSWF = P_1;
			qHtCAkPjlZpUYvjcuaShbEySOgjY = P_2;
			OZwuJHWAHxcIVFeMxJjeitEMPIif = 12;
			SKJdJRJVLVaVeUYgxUPdqjbKyRVl = OZwuJHWAHxcIVFeMxJjeitEMPIif + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			bbmlUEvIYUseVWjqITGUOfVbRDSD = SKJdJRJVLVaVeUYgxUPdqjbKyRVl + P_2 * 4;
			ImCUmFtIMfFPzSafeTnjVwLKElUl = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, OZwuJHWAHxcIVFeMxJjeitEMPIif + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl > 0)
			{
				Marshal.WriteInt32(_buffer, SKJdJRJVLVaVeUYgxUPdqjbKyRVl + index * 4, new oEZEuxEvLWmPGtfYpTEKLcmUmlqWA(value).VMRlRlDAfOHMAicBwfgmGBpNODDSA);
			}
		}

		public void SetId(uint id)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new nINRtQYtjZQcuSIjzSvEVPractZL(value).ZiTAgRUPUzkAGphsjdzvdSDDRZfuA);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl <= 0)
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
			return (Marshal.ReadByte(_buffer, OZwuJHWAHxcIVFeMxJjeitEMPIif + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, OZwuJHWAHxcIVFeMxJjeitEMPIif + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl <= 0)
			{
				return 0f;
			}
			return new oEZEuxEvLWmPGtfYpTEKLcmUmlqWA(Marshal.ReadInt32(_buffer, SKJdJRJVLVaVeUYgxUPdqjbKyRVl + index * 4)).drJWXjOFskhyJfaNwEGYImbWQhESA;
		}

		public uint GetId()
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (ImCUmFtIMfFPzSafeTnjVwLKElUl <= 0)
			{
				return 0.0;
			}
			return new nINRtQYtjZQcuSIjzSvEVPractZL(Marshal.ReadInt64(_buffer, 4)).KlaQtaiuUZtkugoEASXITRpeGdgo;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
