using FullInspector;

namespace TH20
{
	public class RadioSong : RadioPlaylistItem
	{
		public LocalisedString SongNameLoc;

		public LocalisedString ArtistNameLoc;

		public string ArtistName;

		public string SongName;

		[InspectorTooltip("Whether this song is enabled by default in the song playlist")]
		public bool EnabledByDefault = true;

		public string GetArtistDisplayName()
		{
			if (ArtistNameLoc.Term == null)
			{
				return ArtistName;
			}
			return ArtistNameLoc.Translation;
		}

		public string GetSongDisplayName()
		{
			if (SongNameLoc.Term == null)
			{
				return SongName;
			}
			return SongNameLoc.Translation;
		}
	}
}
