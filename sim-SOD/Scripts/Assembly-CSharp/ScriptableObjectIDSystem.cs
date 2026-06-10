using UnityEngine;

public class ScriptableObjectIDSystem : ScriptableObject
{
	[Tooltip("Used as a replacement for names for smaller save data sizes")]
	[Header("ID System")]
	public string id;

	public bool Equals(DoorPairPreset other)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public static bool operator ==(ScriptableObjectIDSystem c1, ScriptableObjectIDSystem c2)
	{
		return false;
	}

	public static bool operator !=(ScriptableObjectIDSystem c1, ScriptableObjectIDSystem c2)
	{
		return false;
	}
}
