namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionReference
	{
		private unsafe fixed byte Scid[40];

		private unsafe fixed byte SessionTemplateName[100];

		private unsafe fixed byte SessionName[100];

		public string GetScid()
		{
			return null;
		}

		public string GetSessionTemplateName()
		{
			return null;
		}

		public string GetSessionName()
		{
			return null;
		}

		public XblMultiplayerSessionReference(XGamingRuntime.XblMultiplayerSessionReference publicObject)
		{
		}
	}
}
