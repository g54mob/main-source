namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionChangeEventArgs
	{
		internal XblMultiplayerSessionReference SessionReference;

		internal byte[] Branch;

		internal readonly ulong ChangeNumber;

		internal string GetBranch()
		{
			return null;
		}
	}
}
