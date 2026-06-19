using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[ComVisible(true)]
	[Guid("D111D8A9-A14F-4835-B318-46A3E787E845")]
	public enum TextContentType : byte
	{
		Other = 0,
		Lyrics = 1,
		TextTranscription = 2,
		MovementPartName = 3,
		Event = 4,
		Chord = 5,
		TriviaPopup = 6,
		URLsToWebpages = 7,
		URLsToImages = 8
	}
}
