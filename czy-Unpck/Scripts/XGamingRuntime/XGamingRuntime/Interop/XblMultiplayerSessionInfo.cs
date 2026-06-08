namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionInfo
	{
		internal readonly uint ContractVersion;

		private unsafe fixed byte Branch[40];

		internal readonly ulong ChangeNumber;

		private unsafe fixed byte CorrelationId[40];

		internal readonly TimeT StartTime;

		internal readonly TimeT NextTimer;

		private unsafe fixed byte SearchHandleId[40];

		internal unsafe string GetBranch()
		{
			fixed (byte* branch = Branch)
			{
				return Converters.BytePointerToString(branch, 40);
			}
		}

		internal unsafe string GetCorrelationId()
		{
			fixed (byte* correlationId = CorrelationId)
			{
				return Converters.BytePointerToString(correlationId, 40);
			}
		}

		internal unsafe string GetSearchHandleId()
		{
			fixed (byte* searchHandleId = SearchHandleId)
			{
				return Converters.BytePointerToString(searchHandleId, 40);
			}
		}

		internal unsafe XblMultiplayerSessionInfo(XGamingRuntime.XblMultiplayerSessionInfo publicObject)
		{
			ContractVersion = publicObject.ContractVersion;
			fixed (byte* branch = Branch)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Branch, branch, 40);
			}
			ChangeNumber = publicObject.ChangeNumber;
			fixed (byte* correlationId = CorrelationId)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.CorrelationId, correlationId, 40);
			}
			StartTime = new TimeT(publicObject.StartTime);
			NextTimer = new TimeT(publicObject.NextTimer);
			fixed (byte* searchHandleId = SearchHandleId)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SearchHandleId, searchHandleId, 40);
			}
		}
	}
}
