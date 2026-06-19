using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[Guid("21720D9F-E868-4a1d-BABA-65F53163B29C")]
	[ComVisible(true)]
	public enum PictureType : byte
	{
		Other = 0,
		FileIcon32x32Png = 1,
		OtherFileIcon = 2,
		CoverFront = 3,
		CoverBack = 4,
		LeafletPage = 5,
		MediaLabelSideOfCD = 6,
		LeadArtistPerformer = 7,
		ArtistPerformer = 8,
		Conductor = 9,
		BandOrchestra = 10,
		Composer = 11,
		Lyricist = 12,
		RecordingLocation = 13,
		DuringRecording = 14,
		DuringPerformance = 15,
		MovieVideoScreenCapture = 16,
		ABrightColoredFish = 17,
		Illustration = 18,
		BandArtistLogo = 19,
		PublisherStudioLogo = 20
	}
}
