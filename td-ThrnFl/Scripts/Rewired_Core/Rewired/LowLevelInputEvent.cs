using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int UOcPuPhpVmyLIAlbUMddCMeISBus = 4;

		private const int aWlUjcUnhpxveiIUAqGPlvCWOkEx = 8;

		private const int kNQcEgbiRyneiRbJCzGpSGyCGUquA = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int UjsGGGvLcSPhKWmwlOqlALFtyEhq = 4;

		private const int KcSDWUYppcCZzHLUOuOOveiYIoCB = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int eaZInkGcSnpcXkRotxEUyshLBugGA;

		private int uitJAPBlwMRcDslkSPTyVlEBTuav;

		private int QYsNtHAMfLhnocunjfVCcvObVYVHB;

		private int oWGQeqINVXdNSdFrkdJASLXROGzqA;

		private int oObDXiJOSpWBhIYncqGLTWJLepEw;

		private int BqvaYrdoMABRtWHePhKpOzJoadamA;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => uitJAPBlwMRcDslkSPTyVlEBTuav;

		public int axisCount => QYsNtHAMfLhnocunjfVCcvObVYVHB;

		public int byteIndex_axesStart => oWGQeqINVXdNSdFrkdJASLXROGzqA;

		public int byteIndex_buttonsStart => oObDXiJOSpWBhIYncqGLTWJLepEw;

		public int byteIndex_hatsStart => BqvaYrdoMABRtWHePhKpOzJoadamA;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			uitJAPBlwMRcDslkSPTyVlEBTuav = P_1;
			QYsNtHAMfLhnocunjfVCcvObVYVHB = P_2;
			oObDXiJOSpWBhIYncqGLTWJLepEw = 12;
			oWGQeqINVXdNSdFrkdJASLXROGzqA = oObDXiJOSpWBhIYncqGLTWJLepEw + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			BqvaYrdoMABRtWHePhKpOzJoadamA = oWGQeqINVXdNSdFrkdJASLXROGzqA + P_2 * 4;
			eaZInkGcSnpcXkRotxEUyshLBugGA = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, oObDXiJOSpWBhIYncqGLTWJLepEw + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA > 0)
			{
				Marshal.WriteInt32(_buffer, oWGQeqINVXdNSdFrkdJASLXROGzqA + index * 4, new OPANEYsaDIokuqCRkCLtLOWDgVIW(value).vDUOIYQpbOyhazNKhjpBuBFUxbfw);
			}
		}

		public void SetId(uint id)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new JUQJmnTMpXjdIPvmejNhqBHfoOnW(value).tAQoNmPjIjEhwfcpqpoKZtlSfvZfb);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA <= 0)
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
			return (Marshal.ReadByte(_buffer, oObDXiJOSpWBhIYncqGLTWJLepEw + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, oObDXiJOSpWBhIYncqGLTWJLepEw + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA <= 0)
			{
				return 0f;
			}
			return new OPANEYsaDIokuqCRkCLtLOWDgVIW(Marshal.ReadInt32(_buffer, oWGQeqINVXdNSdFrkdJASLXROGzqA + index * 4)).ZCCsbWDGayrHpkmIrqLdXqTLvNgw;
		}

		public uint GetId()
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (eaZInkGcSnpcXkRotxEUyshLBugGA <= 0)
			{
				return 0.0;
			}
			return new JUQJmnTMpXjdIPvmejNhqBHfoOnW(Marshal.ReadInt64(_buffer, 4)).cuddAZvlYNCTInnNBICnwVFpEBKn;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
