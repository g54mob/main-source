using System;
using System.Collections.Generic;
using System.IO;
using ATL.AudioData.IO;

namespace ATL.AudioData
{
	internal class CrossMetadataReader : IMetaDataIO, IMetaData
	{
		private readonly IList<IMetaDataIO> metaReaders;

		public bool Exists => false;

		public IList<Format> MetadataFormats => null;

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

		public string Album => null;

		public string Copyright => null;

		public string AlbumArtist => null;

		public string Conductor => null;

		public string Publisher => null;

		public DateTime PublishingDate => default(DateTime);

		public string GeneralDescription => null;

		public string OriginalArtist => null;

		public string OriginalAlbum => null;

		public string ProductId => null;

		public string SortAlbum => null;

		public string SortAlbumArtist => null;

		public string SortArtist => null;

		public string SortTitle => null;

		public string Group => null;

		public string SeriesTitle => null;

		public string SeriesPart => null;

		public string LongDescription => null;

		public float? Popularity => null;

		public string ChaptersTableDescription => null;

		public IDictionary<string, string> AdditionalFields => null;

		public IList<ChapterInfo> Chapters => null;

		public LyricsInfo Lyrics => null;

		public IList<PictureInfo> EmbeddedPictures => null;

		public long Size => 0L;

		public CrossMetadataReader(AudioDataManager audioManager, MetaDataIOFactory.TagType[] tagPriority)
		{
		}

		public bool Read(Stream source, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
