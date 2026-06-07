using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int nAJOTJiRWfsoSRjyLwkofsbiJGCd = 4;

		private const int JIGCLoHibeOEUvOMZIXSWNOcBqcu = 8;

		private const int XUvoUorqTxZIWazDLPTsbDamQtSg = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int jwRshSwHqZIogDkyahFafcBBUuTG = 4;

		private const int fTtrfSTbtzRjhGqTFDbTAzquiMGv = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int LImJpaxvUcXhfQaosCRZRIhboiKw;

		private int PTQusTGiLJTGzrGiBUGtiGEpigGy;

		private int fPVZTXFhWtWGbGruAMDkGMteQpYA;

		private int TDdEyrJZFUgkpKjBbQIHqDvpMaBC;

		private int PYMrCaSAQkCaXVEdnvDSaLTletsfA;

		private int qaSesffqSLwvNOoyYDMmEUFItYWf;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => PTQusTGiLJTGzrGiBUGtiGEpigGy;

		public int axisCount => fPVZTXFhWtWGbGruAMDkGMteQpYA;

		public int byteIndex_axesStart => TDdEyrJZFUgkpKjBbQIHqDvpMaBC;

		public int byteIndex_buttonsStart => PYMrCaSAQkCaXVEdnvDSaLTletsfA;

		public int byteIndex_hatsStart => qaSesffqSLwvNOoyYDMmEUFItYWf;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			PTQusTGiLJTGzrGiBUGtiGEpigGy = P_1;
			fPVZTXFhWtWGbGruAMDkGMteQpYA = P_2;
			PYMrCaSAQkCaXVEdnvDSaLTletsfA = 12;
			TDdEyrJZFUgkpKjBbQIHqDvpMaBC = PYMrCaSAQkCaXVEdnvDSaLTletsfA + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			qaSesffqSLwvNOoyYDMmEUFItYWf = TDdEyrJZFUgkpKjBbQIHqDvpMaBC + P_2 * 4;
			LImJpaxvUcXhfQaosCRZRIhboiKw = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, PYMrCaSAQkCaXVEdnvDSaLTletsfA + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw > 0)
			{
				Marshal.WriteInt32(_buffer, TDdEyrJZFUgkpKjBbQIHqDvpMaBC + index * 4, new xDvFzWjdJBqRYlfRfYMcaTSnTBmx(value).YMrmhWPfWHWYxuSFsubMVPjezdNG);
			}
		}

		public void SetId(uint id)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new cgvOFpIIfYUtaYRylEMaBxNTQfDI(value).IlzxmXCSBgMFGhxEprPNYdYsvKnC);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw <= 0)
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
			return (Marshal.ReadByte(_buffer, PYMrCaSAQkCaXVEdnvDSaLTletsfA + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, PYMrCaSAQkCaXVEdnvDSaLTletsfA + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw <= 0)
			{
				return 0f;
			}
			return new xDvFzWjdJBqRYlfRfYMcaTSnTBmx(Marshal.ReadInt32(_buffer, TDdEyrJZFUgkpKjBbQIHqDvpMaBC + index * 4)).sdzDCIOqhAgXzPEohCyEyDjXRQfA;
		}

		public uint GetId()
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (LImJpaxvUcXhfQaosCRZRIhboiKw <= 0)
			{
				return 0.0;
			}
			return new cgvOFpIIfYUtaYRylEMaBxNTQfDI(Marshal.ReadInt64(_buffer, 4)).NJKwuPeESYMioqdTYcZyeRLPKRilA;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
