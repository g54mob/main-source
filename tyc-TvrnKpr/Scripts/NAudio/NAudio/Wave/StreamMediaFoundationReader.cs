using System.IO;
using NAudio.MediaFoundation;

namespace NAudio.Wave
{
	public class StreamMediaFoundationReader : MediaFoundationReader
	{
		private readonly Stream stream;

		public StreamMediaFoundationReader(Stream stream, MediaFoundationReaderSettings settings = null)
		{
		}

		protected override IMFSourceReader CreateReader(MediaFoundationReaderSettings settings)
		{
			return null;
		}
	}
}
