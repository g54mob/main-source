using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int cHYhnOvhKPrRttEbASfZmpoIRSL = 4;

		private const int UNTOeoVdciRlfruiXSlDVOlkbOW = 8;

		private const int RmxwHthfaCbUmvBfUTtgTOGXLsB = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int eXwUAdkeQGpOulVQPdClTgpSWwi = 4;

		private const int DoBuQmbeKHdxFCUpUoHanLqArlx = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int stOGUfKErForNjACGEeaiMVXgwi;

		private int BIqrSHxnfVeJEnjKdnGBTolrmbG;

		private int hdPfWCbEBCXchGQqzkLUjCOtChr;

		private int iNCKkoMOhSKSZYdRloAYzWgfbSr;

		private int CdVoiJmAfIHzVmOxyapufRscdRc;

		private int YUlOgGSfdmCNMFnWDgREvtkDdw;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => BIqrSHxnfVeJEnjKdnGBTolrmbG;

		public int axisCount => hdPfWCbEBCXchGQqzkLUjCOtChr;

		public int byteIndex_axesStart => iNCKkoMOhSKSZYdRloAYzWgfbSr;

		public int byteIndex_buttonsStart => CdVoiJmAfIHzVmOxyapufRscdRc;

		public int byteIndex_hatsStart => YUlOgGSfdmCNMFnWDgREvtkDdw;

		public LowLevelInputEvent(IntPtr buffer, int buttonCount, int axisCount, int hatCount)
		{
			if (buttonCount == 0 && axisCount == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = buffer;
			BIqrSHxnfVeJEnjKdnGBTolrmbG = buttonCount;
			hdPfWCbEBCXchGQqzkLUjCOtChr = axisCount;
			CdVoiJmAfIHzVmOxyapufRscdRc = 12;
			iNCKkoMOhSKSZYdRloAYzWgfbSr = CdVoiJmAfIHzVmOxyapufRscdRc + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0);
			YUlOgGSfdmCNMFnWDgREvtkDdw = iNCKkoMOhSKSZYdRloAYzWgfbSr + axisCount * 4;
			stOGUfKErForNjACGEeaiMVXgwi = GetReportSize(buttonCount, axisCount, hatCount);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, CdVoiJmAfIHzVmOxyapufRscdRc + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi > 0)
			{
				Marshal.WriteInt32(_buffer, iNCKkoMOhSKSZYdRloAYzWgfbSr + index * 4, new RCyIeAcScIofAKfrkyAdhSxUKuK(value).oIaGVvfPjMJdYbsCfcvdJkbTtaYr);
			}
		}

		public void SetId(uint id)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new WVmnpFDJwPmzyhvKiUobEZFqTVt(value).CIhLRHbNmxbiODSTgixLqIuOBCv);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi <= 0)
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
			return (Marshal.ReadByte(_buffer, CdVoiJmAfIHzVmOxyapufRscdRc + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, CdVoiJmAfIHzVmOxyapufRscdRc + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (stOGUfKErForNjACGEeaiMVXgwi <= 0)
			{
				return 0f;
			}
			return new RCyIeAcScIofAKfrkyAdhSxUKuK(Marshal.ReadInt32(_buffer, iNCKkoMOhSKSZYdRloAYzWgfbSr + index * 4)).fldmGDRRLDtBHaRUMMwEqlnzqvX;
		}

		public uint GetId()
		{
			if (stOGUfKErForNjACGEeaiMVXgwi <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (stOGUfKErForNjACGEeaiMVXgwi <= 0)
			{
				return 0.0;
			}
			return new WVmnpFDJwPmzyhvKiUobEZFqTVt(Marshal.ReadInt64(_buffer, 4)).swKzOkuntsMzCGUTtnEYwKavvvk;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
