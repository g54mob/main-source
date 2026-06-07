using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	[CallbackIdentity(4505)]
	public struct HTML_URLChanged_t
	{
		public const int k_iCallback = 4505;

		public HHTMLBrowser unBrowserHandle;

		public string pchURL;

		public string pchPostData;

		public bool bIsRedirect;

		public string pchPageTitle;

		public bool bNewNavigation;
	}
}
