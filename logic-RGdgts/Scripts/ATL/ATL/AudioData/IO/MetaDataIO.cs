using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	public abstract class MetaDataIO : MetaDataHolder, IMetaDataIO, IMetaData
	{
		public class ReadTagParams
		{
			public bool ReadTag { get; set; }

			public bool ReadAllMetaFrames { get; set; }

			public bool ReadPictures { get; set; }

			public bool PrepareForWriting { get; set; }

			public long Offset { get; set; }

			public ReadTagParams(bool readPictures, bool readAllMetaFrames)
			{
			}
		}

		protected bool tagExists;

		protected int tagVersion;

		private IList<KeyValuePair<string, int>> picturePositions;

		internal FileStructureHelper structureHelper;

		public bool Exists => false;

		public override IList<Format> MetadataFormats => null;

		public long Size => 0L;

		public ICollection<FileStructureHelper.Zone> Zones => null;

		protected virtual byte ratingConvention => 0;

		protected virtual bool isLittleEndian => false;

		protected int takePicturePosition(PictureInfo.PIC_TYPE picType)
		{
			return 0;
		}

		protected int takePicturePosition(MetaDataIOFactory.TagType tagType, byte nativePicCode)
		{
			return 0;
		}

		protected int takePicturePosition(MetaDataIOFactory.TagType tagType, string nativePicCode)
		{
			return 0;
		}

		protected int takePicturePosition(PictureInfo picInfo)
		{
			return 0;
		}

		protected abstract bool read(Stream source, ReadTagParams readTagParams);

		protected abstract TagData.Field getFrameMapping(string zone, string ID, byte tagVersion);

		protected void ResetData()
		{
		}

		public void SetMetaField(string ID, string data, bool readAllMetaFrames, string zone = "default", byte tagVersion = 0, ushort streamNumber = 0, string language = "")
		{
		}

		protected void setMetaField(TagData.Field ID, string dataIn)
		{
		}

		public void Clear()
		{
		}

		public bool Read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
