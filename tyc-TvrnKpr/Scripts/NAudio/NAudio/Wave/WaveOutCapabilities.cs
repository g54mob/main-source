using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0, CharSet = CharSet.Auto)]
	public struct WaveOutCapabilities
	{
		private short manufacturerId;

		private short productId;

		private int driverVersion;

		private string productName;

		private SupportedWaveFormat supportedFormats;

		private short channels;

		private short reserved;

		private WaveOutSupport support;

		private Guid manufacturerGuid;

		private Guid productGuid;

		private Guid nameGuid;

		private const int MaxProductNameLength = 32;

		public int Channels => 0;

		public bool SupportsPlaybackRateControl => false;

		public string ProductName => null;

		public Guid NameGuid => default(Guid);

		public Guid ProductGuid => default(Guid);

		public Guid ManufacturerGuid => default(Guid);

		public bool SupportsWaveFormat(SupportedWaveFormat waveFormat)
		{
			return false;
		}
	}
}
