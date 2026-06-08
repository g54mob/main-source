using System;
using System.Runtime.InteropServices;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct NonNetworkedTarget : INetworkTarget, IEquatable<INetworkTarget>, IPlatformSpecificIdentifier, IEquatable<IPlatformSpecificIdentifier>
	{
		public static NonNetworkedTarget Host => default(NonNetworkedTarget);

		public bool IsHostMode => true;

		public bool IsValid => true;

		public bool Equals(INetworkTarget other)
		{
			return other is NonNetworkedTarget;
		}

		public bool Equals(IPlatformSpecificIdentifier other)
		{
			return other is NonNetworkedTarget;
		}

		public bool IsEquivalent(INetworkTarget other)
		{
			return Equals(other);
		}
	}
}
