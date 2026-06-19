using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int COyCImCDIScQFsgeVWYAwbEwNxl = 4;

		private const int uUhzeCghKrHapwAWQOSSTNpULpa = 8;

		private const int tCBEBJGJZRCuioFDNkXnJqhrFZr = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int GuSdimNNDTWFWcklIpLPLjDkINW = 4;

		private const int fKxPESWYRUUWFXwiNcmjvisullP = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int AqhoTdiUENXHatyZqgreEsdafU;

		private int rVYednFAWMyyCdseuzQUGHWBwloT;

		private int RJpArmCUtRiPnVeoaamBjjbTBEHe;

		private int MDubFYbjOLCfRZZbwLKXEtHRwAHJ;

		private int iQnPMjBCPZGvLnZwzfCzvRZUPCQ;

		private int suiEFWrJUiTlRPLVXgLYEgQOIrI;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => rVYednFAWMyyCdseuzQUGHWBwloT;

		public int axisCount => RJpArmCUtRiPnVeoaamBjjbTBEHe;

		public int byteIndex_axesStart => MDubFYbjOLCfRZZbwLKXEtHRwAHJ;

		public int byteIndex_buttonsStart => iQnPMjBCPZGvLnZwzfCzvRZUPCQ;

		public int byteIndex_hatsStart => suiEFWrJUiTlRPLVXgLYEgQOIrI;

		public LowLevelInputEvent(IntPtr buffer, int buttonCount, int axisCount, int hatCount)
		{
			if (buttonCount == 0 && axisCount == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = buffer;
			rVYednFAWMyyCdseuzQUGHWBwloT = buttonCount;
			RJpArmCUtRiPnVeoaamBjjbTBEHe = axisCount;
			iQnPMjBCPZGvLnZwzfCzvRZUPCQ = 12;
			MDubFYbjOLCfRZZbwLKXEtHRwAHJ = iQnPMjBCPZGvLnZwzfCzvRZUPCQ + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0);
			suiEFWrJUiTlRPLVXgLYEgQOIrI = MDubFYbjOLCfRZZbwLKXEtHRwAHJ + axisCount * 4;
			AqhoTdiUENXHatyZqgreEsdafU = GetReportSize(buttonCount, axisCount, hatCount);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, iQnPMjBCPZGvLnZwzfCzvRZUPCQ + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU > 0)
			{
				Marshal.WriteInt32(_buffer, MDubFYbjOLCfRZZbwLKXEtHRwAHJ + index * 4, new vIAxrSRutHHlKLKXzybedQfwSDa(value).AtCpsPqXKROQCfagvWtskiAZxym);
			}
		}

		public void SetId(uint id)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new oIIbYxhcRQTOoHykfeumjCuUEHXn(value).oOViPvSeokUxOQBijGgKkbzwLHD);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU <= 0)
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
			return (Marshal.ReadByte(_buffer, iQnPMjBCPZGvLnZwzfCzvRZUPCQ + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, iQnPMjBCPZGvLnZwzfCzvRZUPCQ + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (AqhoTdiUENXHatyZqgreEsdafU <= 0)
			{
				return 0f;
			}
			return new vIAxrSRutHHlKLKXzybedQfwSDa(Marshal.ReadInt32(_buffer, MDubFYbjOLCfRZZbwLKXEtHRwAHJ + index * 4)).VLsVdAusIYSFclcZQWXkyWFXkz;
		}

		public uint GetId()
		{
			if (AqhoTdiUENXHatyZqgreEsdafU <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (AqhoTdiUENXHatyZqgreEsdafU <= 0)
			{
				return 0.0;
			}
			return new oIIbYxhcRQTOoHykfeumjCuUEHXn(Marshal.ReadInt64(_buffer, 4)).OamWJIREoxpGELdtwrmHsIPTjWE;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
