using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[Guid("652A237B-A0B6-4ed4-ACDA-C3DD7F299195")]
	[ComVisible(true)]
	public enum ReceivedAs : byte
	{
		Other = 0,
		StandardCDAlbumWithOtherSongs = 1,
		CompressedAudioOnCD = 2,
		FileOverTheInternet = 3,
		StreamOverTheInternet = 4,
		AsNoteSheets = 5,
		AsNoteSheetsInABookWithOtherSheets = 6,
		MusicOnOtherMedia = 7,
		NonmusicalMerchandise = 8
	}
}
