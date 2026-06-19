using System;

namespace CgSDK
{
	internal struct ProtocolDetails
	{
		internal IntPtr sdkVersion;

		internal IntPtr serverVersion;

		internal int sdkProtocolVersion;

		internal int serverProtocolVersion;

		internal bool breakingChanges;
	}
}
