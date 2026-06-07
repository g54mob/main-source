using System.IO;
using ATL.AudioData.IO;

namespace ATL.AudioData
{
	public interface IAudioDataIO
	{
		string FileName { get; }

		double BitRate { get; }

		double Duration { get; }

		int SampleRate { get; }

		int BitDepth { get; }

		bool IsVBR { get; }

		Format AudioFormat { get; }

		int CodecFamily { get; }

		ChannelsArrangements.ChannelsArrangement ChannelsArrangement { get; }

		long AudioDataOffset { get; }

		long AudioDataSize { get; }

		bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType);

		bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams);
	}
}
