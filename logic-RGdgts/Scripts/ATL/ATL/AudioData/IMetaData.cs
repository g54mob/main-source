using System;
using System.Collections.Generic;

namespace ATL.AudioData
{
	public interface IMetaData
	{
		IList<Format> MetadataFormats { get; }

		string Title { get; }

		string Artist { get; }

		string Composer { get; }

		string Comment { get; }

		string Genre { get; }

		ushort TrackNumber { get; }

		ushort TrackTotal { get; }

		ushort DiscNumber { get; }

		ushort DiscTotal { get; }

		DateTime Date { get; }

		bool IsDateYearOnly { get; }

		string Album { get; }

		float? Popularity { get; }

		string Copyright { get; }

		string OriginalArtist { get; }

		string OriginalAlbum { get; }

		string GeneralDescription { get; }

		string Publisher { get; }

		DateTime PublishingDate { get; }

		string AlbumArtist { get; }

		string Conductor { get; }

		string ProductId { get; }

		string SortAlbum { get; }

		string SortAlbumArtist { get; }

		string SortArtist { get; }

		string SortTitle { get; }

		string Group { get; }

		string SeriesTitle { get; }

		string SeriesPart { get; }

		string LongDescription { get; }

		IDictionary<string, string> AdditionalFields { get; }

		string ChaptersTableDescription { get; }

		IList<ChapterInfo> Chapters { get; }

		LyricsInfo Lyrics { get; }

		IList<PictureInfo> EmbeddedPictures { get; }
	}
}
