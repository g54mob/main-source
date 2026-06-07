using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	[CallbackIdentity(4504)]
	public struct HTML_CloseBrowser_t
	{
		public const int k_iCallback = 4504;

		public HHTMLBrowser unBrowserHandle;
	}
}
