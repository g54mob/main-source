using System;
using Unity.Entities;
using Unity.NetCode;

public struct PlayerConnectRequestRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public bool isOwner;

	public uint serverVersion;

	public uint serverMinorVersion;

	public ulong ghostCollectionHash;

	public byte platform;

	public bool allowCrossPlay;

	public void SetVersion(string version, string minorVersion)
	{
		serverVersion = GetVersionHash(version);
		serverMinorVersion = GetVersionHash(minorVersion);
	}

	public static uint GetVersionHash(string version)
	{
		if (string.IsNullOrEmpty(version))
		{
			return 0u;
		}
		return (uint)version.GetHashCode(StringComparison.Ordinal);
	}
}
