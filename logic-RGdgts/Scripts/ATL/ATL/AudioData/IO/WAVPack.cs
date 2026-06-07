using System.IO;

namespace ATL.AudioData.IO
{
	internal class WAVPack : IAudioDataIO
	{
		private sealed class WavpackHeader3
		{
			public byte[] ckID;

			public uint ckSize;

			public ushort version;

			public ushort bits;

			public ushort flags;

			public ushort shift;

			public uint total_samples;

			public uint crc;

			public uint crc2;

			public char[] extension;

			public byte extra_bc;

			public char[] extras;

			public void Reset()
			{
			}
		}

		private sealed class WavPackHeader4
		{
			public byte[] ckID;

			public uint ckSize;

			public ushort version;

			public byte track_no;

			public byte index_no;

			public uint total_samples;

			public uint block_index;

			public uint block_samples;

			public uint flags;

			public uint crc;

			public void Reset()
			{
			}
		}

		private struct FormatChunk
		{
			public ushort wformattag;

			public ushort wchannels;

			public uint dwsamplespersec;

			public uint dwavgbytespersec;

			public ushort wblockalign;

			public ushort wbitspersample;
		}

		private sealed class RiffChunk
		{
			public char[] id;

			public uint size;

			public void Reset()
			{
			}
		}

		private static readonly byte[] WAVPACK_HEADER;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private int bits;

		private int sampleRate;

		private double bitrate;

		private double duration;

		private int codecFamily;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private static readonly int[] sample_rates;

		public Format AudioFormat { get; }

		public int SampleRate => 0;

		public bool IsVBR => false;

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

		private void resetData()
		{
		}

		public WAVPack(string filePath, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		private bool _ReadV4(BufferedBinaryReader source)
		{
			return false;
		}

		private bool _ReadV3(BufferedBinaryReader r)
		{
			return false;
		}
	}
}
