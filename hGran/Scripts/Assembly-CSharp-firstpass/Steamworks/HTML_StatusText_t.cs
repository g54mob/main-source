using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(4523)]
	public struct HTML_StatusText_t
	{
		public const int k_iCallback = 4523;

		public HHTMLBrowser unBrowserHandle;

		public string pchMsg;
	}
}
