using System;
using System.Collections;
using System.Collections.Generic;

namespace QRCoder
{
	public class QRCodeData : IDisposable
	{
		public enum Compression
		{
			Uncompressed = 0,
			Deflate = 1,
			GZip = 2
		}

		public List<BitArray> ModuleMatrix { get; set; }

		public int Version { get; private set; }

		public QRCodeData(int version)
		{
		}

		public QRCodeData(byte[] rawData, Compression compressMode)
		{
		}

		public byte[] GetRawData(Compression compressMode)
		{
			return null;
		}

		private static int ModulesPerSideFromVersion(int version)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
