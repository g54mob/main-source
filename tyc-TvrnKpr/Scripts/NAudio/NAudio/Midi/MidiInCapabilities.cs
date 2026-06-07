using System.Runtime.InteropServices;

namespace NAudio.Midi
{
	[StructLayout((LayoutKind)0, CharSet = CharSet.Auto)]
	public struct MidiInCapabilities
	{
		private ushort manufacturerId;

		private ushort productId;

		private uint driverVersion;

		private string productName;

		private int support;

		private const int MaxProductNameLength = 32;

		public Manufacturers Manufacturer => default(Manufacturers);

		public int ProductId => 0;

		public string ProductName => null;
	}
}
