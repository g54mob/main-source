using System.IO;

namespace ATL.AudioData.IO
{
	public class DummyReader : IAudioDataIO
	{
		private readonly string filePath;

		public string FileName => null;

		public double BitRate => 0.0;

		public double Duration => 0.0;

		public int SampleRate => 0;

		public int BitDepth => 0;

		public bool IsVBR => false;

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public long AudioDataOffset { get; }

		public long AudioDataSize { get; }

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public DummyReader(string filePath)
		{
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
