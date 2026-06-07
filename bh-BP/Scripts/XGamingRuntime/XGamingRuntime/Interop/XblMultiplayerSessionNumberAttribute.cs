namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionNumberAttribute
	{
		private unsafe fixed byte name[100];

		internal readonly double value;

		internal string GetName()
		{
			return null;
		}

		internal XblMultiplayerSessionNumberAttribute(XGamingRuntime.XblMultiplayerSessionNumberAttribute publicObject)
		{
			value = 0.0;
		}
	}
}
