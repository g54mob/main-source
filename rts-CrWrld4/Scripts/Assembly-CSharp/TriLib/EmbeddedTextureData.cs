using System;

namespace TriLib
{
	public class EmbeddedTextureData : IDisposable
	{
		public byte[] Data;

		public IntPtr DataPointer;

		public int DataLength;

		public DataDisposalCallback OnDataDisposal;

		public int Width;

		public int Height;

		public int NumChannels;

		[Obsolete]
		public bool IsRawData;

		public void Dispose()
		{
		}
	}
}
