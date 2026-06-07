using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct LowLevelInputEvent
	{
		private const int TTiAGbWOqjmNQlJuWHnnZpMTtTDw = 4;

		private const int xzzraLeVcWvMktaERcjvomrlJnCR = 8;

		private const int ycRATIQvngoPzxmPGkkWuWdUsFJs = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int FTGpbhBOhuZHPrixPEKsgLQBYbaG = 4;

		private const int iEfCPZYgvvCLQgSmUHFKdIuiDnzoc = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int ZXkxWghoDpMbCbcIQRSIFkxQcdwC;

		private int sqOAjqiYgpyrLlQchddtcgIsmpGfb;

		private int KkbOXxEuXwhRkKpefZpsKkvoQFpI;

		private int BDmvNRrkiktcMSRbtdzcSZRkQPvL;

		private int hwxJcmTJomNfIgdXmcKUMrDlIFaU;

		private int hwuIIDdnqHQjEKhZUhJpnHOrMtgx;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => sqOAjqiYgpyrLlQchddtcgIsmpGfb;

		public int axisCount => KkbOXxEuXwhRkKpefZpsKkvoQFpI;

		public int byteIndex_axesStart => BDmvNRrkiktcMSRbtdzcSZRkQPvL;

		public int byteIndex_buttonsStart => hwxJcmTJomNfIgdXmcKUMrDlIFaU;

		public int byteIndex_hatsStart => hwuIIDdnqHQjEKhZUhJpnHOrMtgx;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			sqOAjqiYgpyrLlQchddtcgIsmpGfb = P_1;
			KkbOXxEuXwhRkKpefZpsKkvoQFpI = P_2;
			hwxJcmTJomNfIgdXmcKUMrDlIFaU = 12;
			BDmvNRrkiktcMSRbtdzcSZRkQPvL = hwxJcmTJomNfIgdXmcKUMrDlIFaU + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			hwuIIDdnqHQjEKhZUhJpnHOrMtgx = BDmvNRrkiktcMSRbtdzcSZRkQPvL + P_2 * 4;
			ZXkxWghoDpMbCbcIQRSIFkxQcdwC = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, hwxJcmTJomNfIgdXmcKUMrDlIFaU + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC > 0)
			{
				Marshal.WriteInt32(_buffer, BDmvNRrkiktcMSRbtdzcSZRkQPvL + index * 4, new aKMbUZDTJgAyRWaLsNCZUPtPKgWI(value).ZsSlaOgmwaaNNmQowHIHJpMmUeAq);
			}
		}

		public void SetId(uint id)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new bdSEGseWrfaLnEdwyDJJrdsvgXdMA(value).dQHwweSgELcNRVougQRxVvjHwXxp);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC <= 0)
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
			return (Marshal.ReadByte(_buffer, hwxJcmTJomNfIgdXmcKUMrDlIFaU + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, hwxJcmTJomNfIgdXmcKUMrDlIFaU + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC <= 0)
			{
				return 0f;
			}
			return new aKMbUZDTJgAyRWaLsNCZUPtPKgWI(Marshal.ReadInt32(_buffer, BDmvNRrkiktcMSRbtdzcSZRkQPvL + index * 4)).OOBHaVuOxQLUYaeWMfscJSdqmZwB;
		}

		public uint GetId()
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (ZXkxWghoDpMbCbcIQRSIFkxQcdwC <= 0)
			{
				return 0.0;
			}
			return new bdSEGseWrfaLnEdwyDJJrdsvgXdMA(Marshal.ReadInt64(_buffer, 4)).HaUePFesYkgJSEzpObaDcNqtPuh;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
