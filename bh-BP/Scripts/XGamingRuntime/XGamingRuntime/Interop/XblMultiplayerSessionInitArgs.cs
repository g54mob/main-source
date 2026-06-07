using System;

namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionInitArgs
	{
		internal readonly uint MaxMembersInSession;

		internal readonly XblMultiplayerSessionVisibility Visibility;

		private unsafe readonly ulong* InitiatorXuids;

		internal readonly SizeT InitiatorXuidsCount;

		internal readonly UTF8StringPtr CustomJson;

		internal T[] GetInitiatorXuids<T>(Func<ulong, T> ctor)
		{
			return null;
		}

		internal unsafe XblMultiplayerSessionInitArgs(XGamingRuntime.XblMultiplayerSessionInitArgs publicObject, DisposableCollection disposableCollection)
		{
			MaxMembersInSession = 0u;
			Visibility = default(XblMultiplayerSessionVisibility);
			InitiatorXuids = null;
			InitiatorXuidsCount = default(SizeT);
			CustomJson = default(UTF8StringPtr);
		}
	}
}
