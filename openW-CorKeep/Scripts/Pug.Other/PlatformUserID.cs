using System;
using UnityEngine;

public class PlatformUserID : IEquatable<PlatformUserID>
{
	protected ulong _platformId;

	public PlatformUserID()
	{
		_platformId = 0uL;
	}

	public PlatformUserID(ulong platformId)
	{
		_platformId = platformId;
	}

	public virtual ulong GetLocalUserId()
	{
		Debug.LogError("PlatformUserID.GetLocalUserId should be overriden in platform specific implementations. Returning 0.");
		return 0uL;
	}

	public virtual ulong GetPlatformOnlineId()
	{
		return _platformId;
	}

	public bool Equals(PlatformUserID other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		return _platformId == other._platformId;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((PlatformUserID)obj);
	}

	public override int GetHashCode()
	{
		return _platformId.GetHashCode();
	}
}
