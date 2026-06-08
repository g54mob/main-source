using System;

namespace Kitchen
{
	public interface INetworkTarget : IEquatable<INetworkTarget>, IPlatformSpecificIdentifier, IEquatable<IPlatformSpecificIdentifier>
	{
		bool IsHostMode { get; }

		bool IsValid { get; }

		bool IsEquivalent(INetworkTarget other);
	}
}
