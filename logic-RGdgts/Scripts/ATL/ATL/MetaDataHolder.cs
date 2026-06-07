using System;
using System.Collections.Generic;
using ATL.AudioData;

namespace ATL
{
	public abstract class MetaDataHolder : IMetaData
	{
		internal TagData tagData { get; set; }

		public string Title => null;

		public string Artist => null;

		public string Composer => null;

		public string Comment => null;

		public string Genre => null;

		public ushort TrackNumber => 0;

		public ushort TrackTotal => 0;

		public ushort DiscNumber => 0;

		public ushort DiscTotal => 0;

		public DateTime Date => default(DateTime);

		public bool IsDateYearOnly => false;

		public DateTime PublishingDate => default(DateTime);

		public string Album => null;

		public float? Popularity => null;

		public string Copyright => null;

		public string OriginalArtist => null;

		public string OriginalAlbum => null;

		public string GeneralDescription => null;

		public string Publisher => null;

		public string AlbumArtist => null;

		public string Conductor => null;

		public string ProductId => null;

		public string SortAlbum => null;

		public string SortAlbumArtist => null;

		public string SortArtist => null;

		public string SortTitle => null;

		public string Group => null;

		public string SeriesTitle => null;

		public string SeriesPart => null;

		public string LongDescription => null;

		public IDictionary<string, string> AdditionalFields => null;

		public IList<PictureInfo> EmbeddedPictures => null;

		public IList<ChapterInfo> Chapters => null;

		public string ChaptersTableDescription => null;

		public LyricsInfo Lyrics => null;

		public virtual IList<Format> MetadataFormats => null;

		protected abstract MetaDataIOFactory.TagType getImplementedTagType();

		public IList<MetaFieldInfo> GetAdditionalFields(int streamNumber = -1, string language = "")
		{
			return null;
		}
	}
}
