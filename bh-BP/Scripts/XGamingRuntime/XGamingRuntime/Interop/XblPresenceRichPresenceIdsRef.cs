using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[StructLayout((LayoutKind)0)]
	internal class XblPresenceRichPresenceIdsRef
	{
		internal readonly byte[] scid;

		internal readonly UTF8StringPtr presenceId;

		private readonly IntPtr presenceTokenIds;

		private readonly SizeT presenceTokenIdsCount;

		internal XblPresenceRichPresenceIdsRef(XblPresenceRichPresenceIds richPresenceIds, DisposableCollection disposableCollection)
		{
		}

		internal static bool ValidateFields(string scid)
		{
			return false;
		}
	}
}
