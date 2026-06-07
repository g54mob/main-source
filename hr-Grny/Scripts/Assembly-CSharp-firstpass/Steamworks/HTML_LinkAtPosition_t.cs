using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	[CallbackIdentity(4513)]
	public struct HTML_LinkAtPosition_t
	{
		public const int k_iCallback = 4513;

		public HHTMLBrowser unBrowserHandle;

		public uint x;

		public uint y;

		public string pchURL;

		public bool bInput;

		public bool bLiveLink;
	}
}
