using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[ComVisible(true)]
	[Guid("D7ADEAC4-A9DD-4a69-A4BC-6B9163D44833")]
	public enum AudioScramblingMode
	{
		Default = 0,
		Unsynchronization = 1,
		Scrambling = 2,
		None = 3
	}
}
