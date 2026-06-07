using System;
using System.Runtime.InteropServices;

namespace NAudio.Midi
{
	[StructLayout((LayoutKind)0, CharSet = CharSet.Auto)]
	public struct MidiOutCapabilities
	{
		[Flags]
		private enum MidiOutCapabilityFlags
		{
			Volume = 1,
			LeftRightVolume = 2,
			PatchCaching = 4,
			Stream = 8
		}

		private short manufacturerId;

		private short productId;

		private int driverVersion;

		private string productName;

		private short wTechnology;

		private short wVoices;

		private short wNotes;

		private ushort wChannelMask;

		private MidiOutCapabilityFlags dwSupport;

		private const int MaxProductNameLength = 32;

		public Manufacturers Manufacturer => default(Manufacturers);

		public short ProductId => 0;

		public string ProductName => null;

		public int Voices => 0;

		public int Notes => 0;

		public bool SupportsAllChannels => false;

		public bool SupportsPatchCaching => false;

		public bool SupportsSeparateLeftAndRightVolume => false;

		public bool SupportsMidiStreamOut => false;

		public bool SupportsVolumeControl => false;

		public MidiOutTechnology Technology => default(MidiOutTechnology);

		public bool SupportsChannel(int channel)
		{
			return false;
		}
	}
}
