namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionInfo
	{
		internal readonly uint ContractVersion;

		private unsafe fixed byte Branch[40];

		internal readonly ulong ChangeNumber;

		private unsafe fixed byte CorrelationId[40];

		internal readonly TimeT StartTime;

		internal readonly TimeT NextTimer;

		private unsafe fixed byte SearchHandleId[40];

		internal string GetBranch()
		{
			return null;
		}

		internal string GetCorrelationId()
		{
			return null;
		}

		public string GetSearchHandleId()
		{
			return null;
		}

		internal XblMultiplayerSessionInfo(XGamingRuntime.XblMultiplayerSessionInfo publicObject)
		{
			ContractVersion = 0u;
			ChangeNumber = 0uL;
			StartTime = default(TimeT);
			NextTimer = default(TimeT);
		}
	}
}
