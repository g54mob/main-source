using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[StructLayout((LayoutKind)0)]
	internal class XblPresenceQueryFiltersRef
	{
		private readonly IntPtr deviceTypes;

		private readonly SizeT deviceTypesCount;

		private readonly IntPtr titleIds;

		private readonly SizeT titleIdsCount;

		internal readonly XblPresenceDetailLevel detailLevel;

		internal bool onlineOnly;

		internal bool broadcastingOnly;

		internal XblPresenceQueryFiltersRef(XblPresenceQueryFilters filters, DisposableCollection disposableCollection)
		{
		}
	}
}
