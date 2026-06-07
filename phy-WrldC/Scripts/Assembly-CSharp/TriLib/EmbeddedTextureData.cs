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

		public int NumChannels = 4;

		[Obsolete("Now all EmbeddedTextureData instances must contain raw data")]
		public bool IsRawData;

		public void Dispose()
		{
			if (DataPointer != IntPtr.Zero)
			{
				if (OnDataDisposal != null)
				{
					OnDataDisposal(DataPointer);
				}
				DataPointer = IntPtr.Zero;
			}
		}
	}
}
