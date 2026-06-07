using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using ATL.AudioData;

namespace ATL
{
	public class Track
	{
		public readonly string Path;

		[CompilerGenerated]
		private string _003CChaptersTableDescription_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ChapterInfo> _003CChapters_003Ek__BackingField;

		[CompilerGenerated]
		private LyricsInfo _003CLyrics_003Ek__BackingField;

		private LyricsInfo initialLyrics;

		private ICollection<string> initialAdditionalFields;

		private ICollection<PictureInfo> initialEmbeddedPictures;

		private DateTime? date;

		private bool isYearExplicit;

		[CompilerGenerated]
		private IList<Format> _003CMetadataFormats_003Ek__BackingField;

		[CompilerGenerated]
		private int _003CCodecFamily_003Ek__BackingField;

		[CompilerGenerated]
		private Format _003CAudioFormat_003Ek__BackingField;

		[CompilerGenerated]
		private ChannelsArrangements.ChannelsArrangement _003CChannelsArrangement_003Ek__BackingField;

		[CompilerGenerated]
		private TechnicalInfo _003CTechnicalInformation_003Ek__BackingField;

		private readonly Stream stream;

		private readonly string mimeType;

		private AudioFileIO fileIO;

		public string Title { get; set; }

		public string Artist { get; set; }

		public string Composer { get; set; }

		public string Comment { get; set; }

		public string Genre { get; set; }

		public string Album { get; set; }

		public string OriginalAlbum { get; set; }

		public string OriginalArtist { get; set; }

		public string Copyright { get; set; }

		public string Description { get; set; }

		public string Publisher { get; set; }

		public DateTime? PublishingDate { get; set; }

		public string AlbumArtist { get; set; }

		public string Conductor { get; set; }

		public string ProductId { get; set; }

		public string SortAlbum { get; set; }

		public string SortAlbumArtist { get; set; }

		public string SortArtist { get; set; }

		public string SortTitle { get; set; }

		public string Group { get; set; }

		public string SeriesTitle { get; set; }

		public string SeriesPart { get; set; }

		public string LongDescription { get; set; }

		public DateTime? Date
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? Year
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? TrackNumber { get; set; }

		public int? TrackTotal { get; set; }

		public int? DiscNumber { get; set; }

		public int? DiscTotal { get; set; }

		public float? Popularity { get; set; }

		public string ChaptersTableDescription
		{
			[CompilerGenerated]
			set
			{
				_003CChaptersTableDescription_003Ek__BackingField = value;
			}
		}

		public IList<ChapterInfo> Chapters
		{
			[CompilerGenerated]
			set
			{
				_003CChapters_003Ek__BackingField = value;
			}
		}

		public LyricsInfo Lyrics
		{
			[CompilerGenerated]
			set
			{
				_003CLyrics_003Ek__BackingField = value;
			}
		}

		public IDictionary<string, string> AdditionalFields { get; set; }

		private IList<PictureInfo> currentEmbeddedPictures { get; set; }

		internal IList<Format> MetadataFormats
		{
			[CompilerGenerated]
			set
			{
				_003CMetadataFormats_003Ek__BackingField = value;
			}
		}

		public int Bitrate { get; internal set; }

		public int BitDepth { get; internal set; }

		public double SampleRate { get; internal set; }

		public bool IsVBR { get; internal set; }

		internal int CodecFamily
		{
			[CompilerGenerated]
			set
			{
				_003CCodecFamily_003Ek__BackingField = value;
			}
		}

		internal Format AudioFormat
		{
			[CompilerGenerated]
			set
			{
				_003CAudioFormat_003Ek__BackingField = value;
			}
		}

		public int Duration => 0;

		public double DurationMs { get; internal set; }

		internal ChannelsArrangements.ChannelsArrangement ChannelsArrangement
		{
			[CompilerGenerated]
			set
			{
				_003CChannelsArrangement_003Ek__BackingField = value;
			}
		}

		internal TechnicalInfo TechnicalInformation
		{
			[CompilerGenerated]
			set
			{
				_003CTechnicalInformation_003Ek__BackingField = value;
			}
		}

		public Track(string path, bool load = true)
		{
		}

		protected void Update(bool onlyReadEmbeddedPictures = false)
		{
		}

		private string processString(string value)
		{
			return null;
		}

		private DateTime? update(DateTime value)
		{
			return null;
		}

		private int? update(int value)
		{
			return null;
		}

		private bool canUseValue(DateTime? value)
		{
			return false;
		}

		private bool canUseValue(int? value)
		{
			return false;
		}
	}
}
