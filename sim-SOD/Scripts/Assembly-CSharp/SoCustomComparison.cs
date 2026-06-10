using UnityEngine;

public class SoCustomComparison : ScriptableObject
{
	[Tooltip("We need a internal reference to ID the file based on name (can't access name outside main threads)")]
	public string presetName;

	public bool Equals(SoCustomComparison other)
	{
		return false;
	}

	public virtual string GetPresetName()
	{
		return null;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public static bool operator ==(SoCustomComparison c1, SoCustomComparison c2)
	{
		return false;
	}

	public static bool operator !=(SoCustomComparison c1, SoCustomComparison c2)
	{
		return false;
	}
}
