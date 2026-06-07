using System;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int rXSiOnbitPjUMGvZjOLmMPfpboZK = 4;

		private const int LeZbZKQUHWPGcifcxadIdVPtlEps = 8;

		private const int ZusBGIsYnFOKcxiljineGGvtagBPA = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int lRIAacnGxnTdOSGoKJZuOSeOuWKD = 4;

		private const int hpmJXySwXNnkRNqxxcHHpWhbUeXo = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int NivtwMczsQEuPVBCIlUDsnciEzJF;

		private int RTXKjDZGbmEHWeAbXuvEBTsRKJOA;

		private int jGYdNtQTokDBioKXEySPhVHyyGgJ;

		private int RiamXWSrXujuGZHIJepLHCtyuSrc;

		private int PABFLSXMoSixzAMZPThKNPCgHLpnA;

		private int qcJbMDmpshNzbBzSibtofBSDLRXs;

		public bool isValid => false;

		public int buttonCount => 0;

		public int axisCount => 0;

		public int byteIndex_axesStart => 0;

		public int byteIndex_buttonsStart => 0;

		public int byteIndex_hatsStart => 0;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			_buffer = (IntPtr)0;
			NivtwMczsQEuPVBCIlUDsnciEzJF = 0;
			RTXKjDZGbmEHWeAbXuvEBTsRKJOA = 0;
			jGYdNtQTokDBioKXEySPhVHyyGgJ = 0;
			RiamXWSrXujuGZHIJepLHCtyuSrc = 0;
			PABFLSXMoSixzAMZPThKNPCgHLpnA = 0;
			qcJbMDmpshNzbBzSibtofBSDLRXs = 0;
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
