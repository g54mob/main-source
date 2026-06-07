using System;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal struct LowLevelInputEvent
	{
		private const int zuBsWEEbcrKzMCsmkCEkgEpgwuA = 4;

		private const int DaERswyKsONRaQgErIqkTyQGYXB = 8;

		private const int EdidwnIhdcGdfIpZcdDZHhQfsyY = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int zSrPvKVDhstkXIYfzfwdTQwunpt = 4;

		private const int OfObzeOIlhBtSdrycqgRzXPcGWw = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int txVDvFxitvsUKEmfeaFEcXbnTgn;

		private int MPfcFHBAqdEVRKAwFPIsRPrJOKNM;

		private int qKQydGYzZiFdavuuXkrbxuGVdee;

		private int heDWfelTeoNOQfJbThSzjtsRShi;

		private int NWOdZBHmdedQENBiGdnRxskOuvf;

		private int BVLwryjTaZuhGhPwisIkUChIKJl;

		public bool isValid => false;

		public int buttonCount => 0;

		public int axisCount => 0;

		public int byteIndex_axesStart => 0;

		public int byteIndex_buttonsStart => 0;

		public int byteIndex_hatsStart => 0;

		public LowLevelInputEvent(IntPtr buffer, int buttonCount, int axisCount, int hatCount)
		{
			_buffer = (IntPtr)0;
			txVDvFxitvsUKEmfeaFEcXbnTgn = 0;
			MPfcFHBAqdEVRKAwFPIsRPrJOKNM = 0;
			qKQydGYzZiFdavuuXkrbxuGVdee = 0;
			heDWfelTeoNOQfJbThSzjtsRShi = 0;
			NWOdZBHmdedQENBiGdnRxskOuvf = 0;
			BVLwryjTaZuhGhPwisIkUChIKJl = 0;
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
		}

		public void SetAxisValue(int index, float value)
		{
		}

		public void SetId(uint id)
		{
		}

		public void SetTimestamp(double value)
		{
		}

		public bool GetButtonValue(int index)
		{
			return false;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			return 0;
		}

		public float GetAxisValue(int index)
		{
			return 0f;
		}

		public uint GetId()
		{
			return 0u;
		}

		public double GetTimestamp()
		{
			return 0.0;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 0;
		}
	}
}
