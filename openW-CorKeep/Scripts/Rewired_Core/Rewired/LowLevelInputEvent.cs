using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int tiUSPyXfyiUCdElInoWhVcBJmSpT = 4;

		private const int ZBNNKVmbQnwwXqTpphnVocnHhdNbA = 8;

		private const int HLaFnNKjawbpTEnmjvxfsLVVQFffA = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int voYAxzGBPYPmreCJMUDbWRqepHkxA = 4;

		private const int druiFxexQsNKaNCcxFbMmIVDdBrq = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int TXngIVQndddvkBuXIbbKzsKEJxnp;

		private int PQTfrqGfRQvhoQoRjEikQWxIjtzdA;

		private int bZAZMqqCYTJcViWKSpgIkibOSJGv;

		private int PXgwFJqNaHNCpLCOFieYHGoYeNkXA;

		private int RfReeXfDbrHKUBGKFdhDcAkMvcDYA;

		private int oDXhtKUDbIeCUATXmbbfocyxRkbgA;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => PQTfrqGfRQvhoQoRjEikQWxIjtzdA;

		public int axisCount => bZAZMqqCYTJcViWKSpgIkibOSJGv;

		public int byteIndex_axesStart => PXgwFJqNaHNCpLCOFieYHGoYeNkXA;

		public int byteIndex_buttonsStart => RfReeXfDbrHKUBGKFdhDcAkMvcDYA;

		public int byteIndex_hatsStart => oDXhtKUDbIeCUATXmbbfocyxRkbgA;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			PQTfrqGfRQvhoQoRjEikQWxIjtzdA = P_1;
			bZAZMqqCYTJcViWKSpgIkibOSJGv = P_2;
			RfReeXfDbrHKUBGKFdhDcAkMvcDYA = 12;
			PXgwFJqNaHNCpLCOFieYHGoYeNkXA = RfReeXfDbrHKUBGKFdhDcAkMvcDYA + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			oDXhtKUDbIeCUATXmbbfocyxRkbgA = PXgwFJqNaHNCpLCOFieYHGoYeNkXA + P_2 * 4;
			TXngIVQndddvkBuXIbbKzsKEJxnp = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, RfReeXfDbrHKUBGKFdhDcAkMvcDYA + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp > 0)
			{
				Marshal.WriteInt32(_buffer, PXgwFJqNaHNCpLCOFieYHGoYeNkXA + index * 4, new lXoaYvYIaGlhRmQyXsxhUjLWIQHd(value).MOwSllgFKExgTpldGGCZGxsBCyoJA);
			}
		}

		public void SetId(uint id)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new iZwCJSGdSLGmxIDHkBqfHzexmByJc(value).SXgugZhxrdCqDsTGHsFQarINuiGR);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp <= 0)
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
			return (Marshal.ReadByte(_buffer, RfReeXfDbrHKUBGKFdhDcAkMvcDYA + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, RfReeXfDbrHKUBGKFdhDcAkMvcDYA + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp <= 0)
			{
				return 0f;
			}
			return new lXoaYvYIaGlhRmQyXsxhUjLWIQHd(Marshal.ReadInt32(_buffer, PXgwFJqNaHNCpLCOFieYHGoYeNkXA + index * 4)).sroXShdWRsqOEwmzUTuxIFiWFEzZ;
		}

		public uint GetId()
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (TXngIVQndddvkBuXIbbKzsKEJxnp <= 0)
			{
				return 0.0;
			}
			return new iZwCJSGdSLGmxIDHkBqfHzexmByJc(Marshal.ReadInt64(_buffer, 4)).XuHziPDxcXUzRvkfshvkvopqYVOb;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
