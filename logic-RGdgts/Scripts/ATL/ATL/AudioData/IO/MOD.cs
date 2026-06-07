using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class MOD : MetaDataIO, IAudioDataIO
	{
		internal class Sample
		{
			public string Name;

			public int Size;

			public sbyte Finetune;

			public byte Volume;

			public int RepeatOffset;

			public int RepeatLength;
		}

		internal class ModFormat
		{
			public readonly string Name;

			public readonly string Signature;

			public readonly byte NbSamples;

			public readonly byte NbChannels;

			public ModFormat(string name, string sig, byte nbSamples, byte nbChannels)
			{
			}
		}

		private static IDictionary<string, ModFormat> modFormats;

		private IList<Sample> FSamples;

		private IList<IList<IList<int>>> FPatterns;

		private IList<byte> FPatternTable;

		private byte nbValidPatterns;

		private string formatTag;

		private byte nbChannels;

		private double bitrate;

		private double duration;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private readonly Format audioFormat;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		private void resetData()
		{
		}

		public MOD(string filePath, Format format)
		{
		}

		private double calculateDuration()
		{
			return 0.0;
		}

		private byte detectNbSamples(BufferedBinaryReader source)
		{
			return 0;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, ReadTagParams readTagParams)
		{
			return false;
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
