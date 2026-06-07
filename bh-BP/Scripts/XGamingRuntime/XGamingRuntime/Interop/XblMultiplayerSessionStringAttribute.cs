namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionStringAttribute
	{
		private unsafe fixed byte name[100];

		private unsafe fixed byte value[100];

		internal string GetName()
		{
			return null;
		}

		internal string GetValue()
		{
			return null;
		}

		internal XblMultiplayerSessionStringAttribute(XGamingRuntime.XblMultiplayerSessionStringAttribute publicObject)
		{
		}
	}
}
