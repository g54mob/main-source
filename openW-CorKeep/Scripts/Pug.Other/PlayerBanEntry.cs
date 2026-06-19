using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public struct PlayerBanEntry : IEquatable<PlayerBanEntry>
{
	public int index;

	[SerializeField]
	private string name;

	public ulong steamId;

	[OptionalField]
	public ulong crossPlatformId;

	public string Name
	{
		get
		{
			if (name == null)
			{
				return "";
			}
			return name;
		}
		set
		{
			name = value;
		}
	}

	public bool IsValid()
	{
		if (steamId == 0L)
		{
			return crossPlatformId != 0;
		}
		return true;
	}

	public bool Equals(PlayerBanEntry other)
	{
		if (steamId != other.steamId)
		{
			if (crossPlatformId != 0L && other.crossPlatformId != 0L)
			{
				return crossPlatformId == other.crossPlatformId;
			}
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj is PlayerBanEntry other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return steamId.GetHashCode() + crossPlatformId.GetHashCode();
	}
}
