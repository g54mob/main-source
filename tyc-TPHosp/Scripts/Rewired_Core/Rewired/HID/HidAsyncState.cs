namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HidAsyncState
	{
		private readonly object FRsCuhmxRshfSdGuAQwJrOXLJdV;

		private readonly object deCankcmzrHFhSGdvNVyddzGiLco;

		public object CallerDelegate => FRsCuhmxRshfSdGuAQwJrOXLJdV;

		public object CallbackDelegate => deCankcmzrHFhSGdvNVyddzGiLco;

		public HidAsyncState(object callerDelegate, object callbackDelegate)
		{
			FRsCuhmxRshfSdGuAQwJrOXLJdV = callerDelegate;
			deCankcmzrHFhSGdvNVyddzGiLco = callbackDelegate;
		}
	}
}
