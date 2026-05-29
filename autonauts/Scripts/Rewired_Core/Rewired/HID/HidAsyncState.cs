namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HidAsyncState
	{
		private readonly object ikzakZGUhQoCdAnryqKBGVrYVptN;

		private readonly object UjPcFMETpNUoCCkoBSDwBQFlIdUf;

		public object CallerDelegate
		{
			get
			{
				return ikzakZGUhQoCdAnryqKBGVrYVptN;
			}
		}

		public object CallbackDelegate
		{
			get
			{
				return UjPcFMETpNUoCCkoBSDwBQFlIdUf;
			}
		}

		public HidAsyncState(object callerDelegate, object callbackDelegate)
		{
			ikzakZGUhQoCdAnryqKBGVrYVptN = callerDelegate;
			UjPcFMETpNUoCCkoBSDwBQFlIdUf = callbackDelegate;
		}
	}
}
