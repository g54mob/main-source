namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HidAsyncState
	{
		private readonly object TfbVlUstfWPzGTQsQGIFsExIbeuH;

		private readonly object nWJKmBuPnLBgpaarxEZaaUZzTmN;

		public object CallerDelegate
		{
			get
			{
				return TfbVlUstfWPzGTQsQGIFsExIbeuH;
			}
		}

		public object CallbackDelegate
		{
			get
			{
				return nWJKmBuPnLBgpaarxEZaaUZzTmN;
			}
		}

		public HidAsyncState(object callerDelegate, object callbackDelegate)
		{
			TfbVlUstfWPzGTQsQGIFsExIbeuH = callerDelegate;
			nWJKmBuPnLBgpaarxEZaaUZzTmN = callbackDelegate;
		}
	}
}
