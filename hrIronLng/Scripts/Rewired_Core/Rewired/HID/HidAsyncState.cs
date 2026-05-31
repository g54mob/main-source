namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HidAsyncState
	{
		private readonly object rQhNDNGbxCaMqWsLSdMtfatZBb;

		private readonly object TnkjCKRrOqexpFGHijNfnnAIARY;

		public object CallerDelegate => rQhNDNGbxCaMqWsLSdMtfatZBb;

		public object CallbackDelegate => TnkjCKRrOqexpFGHijNfnnAIARY;

		public HidAsyncState(object callerDelegate, object callbackDelegate)
		{
			rQhNDNGbxCaMqWsLSdMtfatZBb = callerDelegate;
			TnkjCKRrOqexpFGHijNfnnAIARY = callbackDelegate;
		}
	}
}
