using System.IO;

namespace ATL.AudioData
{
	internal static class FlacHelper
	{
		public sealed class FlacHeader
		{
			private byte[] StreamMarker;

			private readonly byte[] MetaDataBlockHeader;

			private readonly byte[] Info;

			public bool MetadataExists => false;

			public int SampleRate => 0;

			public byte BitsPerSample => 0;

			public long NbSamples => 0L;

			public void Reset()
			{
			}

			public void fromStream(Stream source)
			{
			}

			public bool IsValid()
			{
				return false;
			}

			public ChannelsArrangements.ChannelsArrangement getChannelsArrangement()
			{
				return null;
			}
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		public static FlacHeader readHeader(Stream source)
		{
			return null;
		}
	}
}
