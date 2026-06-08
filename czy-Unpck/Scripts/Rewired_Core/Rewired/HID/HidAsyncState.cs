namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HidAsyncState
	{
		private readonly object DdxPkWuGpULheYQqrlAGTFVJsEM;

		private readonly object jNNqgZuUWJutTppRWekbHZdmNyff;

		public object CallerDelegate => DdxPkWuGpULheYQqrlAGTFVJsEM;

		public object CallbackDelegate => jNNqgZuUWJutTppRWekbHZdmNyff;

		public HidAsyncState(object callerDelegate, object callbackDelegate)
		{
			DdxPkWuGpULheYQqrlAGTFVJsEM = callerDelegate;
			jNNqgZuUWJutTppRWekbHZdmNyff = callbackDelegate;
		}
	}
}
