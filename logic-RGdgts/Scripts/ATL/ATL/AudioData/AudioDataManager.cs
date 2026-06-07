using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using ATL.AudioData.IO;

namespace ATL.AudioData
{
	public class AudioDataManager
	{
		public class SizeInfo
		{
			private readonly IDictionary<MetaDataIOFactory.TagType, long> TagSizes;

			private long audioDataSize;

			[CompilerGenerated]
			private long _003CAudioDataOffset_003Ek__BackingField;

			public long ID3v1Size => 0L;

			public long ID3v2Size => 0L;

			public long APESize => 0L;

			public long NativeSize => 0L;

			public long TotalTagSize => 0L;

			public long FileSize { get; set; }

			public long AudioDataOffset
			{
				[CompilerGenerated]
				set
				{
					_003CAudioDataOffset_003Ek__BackingField = value;
				}
			}

			public long AudioDataSize
			{
				set
				{
				}
			}

			public void ResetData()
			{
			}

			public void SetSize(MetaDataIOFactory.TagType type, long size)
			{
			}
		}

		private static int bufferSize;

		private static FileOptions fileOptions;

		private IMetaDataIO iD3v1;

		private IMetaDataIO iD3v2;

		private IMetaDataIO aPEtag;

		private IMetaDataIO nativeTag;

		private readonly IAudioDataIO audioDataIO;

		private readonly Stream stream;

		private readonly SizeInfo sizeInfo;

		private string fileName => null;

		public IMetaDataIO ID3v1 => null;

		public IMetaDataIO ID3v2 => null;

		public IMetaDataIO APEtag => null;

		public IMetaDataIO NativeTag => null;

		internal AudioDataManager(IAudioDataIO audioDataReader)
		{
		}

		internal AudioDataManager(IAudioDataIO audioDataReader, Stream stream)
		{
		}

		private void resetData()
		{
		}

		public bool hasMeta(MetaDataIOFactory.TagType type)
		{
			return false;
		}

		public bool HasNativeMeta()
		{
			return false;
		}

		public IList<MetaDataIOFactory.TagType> getAvailableMetas()
		{
			return null;
		}

		public bool ReadFromFile(bool readEmbeddedPictures = false, bool readAllMetaFrames = false)
		{
			return false;
		}

		private bool read(Stream source, bool readEmbeddedPictures = false, bool readAllMetaFrames = false, bool prepareForWriting = false)
		{
			return false;
		}

		private bool read(Stream source, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
