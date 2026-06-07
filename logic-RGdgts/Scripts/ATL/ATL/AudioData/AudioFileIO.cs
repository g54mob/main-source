using System.IO;
using ATL.AudioData.IO;

namespace ATL.AudioData
{
	internal class AudioFileIO : IAudioDataIO
	{
		private readonly IAudioDataIO audioData;

		private readonly IMetaDataIO metaData;

		private readonly AudioDataManager audioManager;

		public IMetaDataIO Metadata => null;

		public string FileName => null;

		public int IntBitRate => 0;

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public bool IsVBR => false;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public int SampleRate => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset => 0L;

		public long AudioDataSize => 0L;

		public AudioFileIO(string path, bool readEmbeddedPictures, bool readAllMetaFrames = false)
		{
		}

		public AudioFileIO(Stream stream, string mimeType, bool readEmbeddedPictures, bool readAllMetaFrames = false)
		{
		}

		private IMetaDataIO getAndCheckMetadata()
		{
			return null;
		}

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
