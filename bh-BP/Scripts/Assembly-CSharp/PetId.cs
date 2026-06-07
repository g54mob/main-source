using System;

[Serializable]
public struct PetId
{
	public int Id;

	public PetId(int id = 0)
	{
		Id = 0;
	}

	public PetId(PetInst p)
	{
		Id = 0;
	}

	public bool IsNull()
	{
		return false;
	}

	public static bool operator ==(PetId id1, int id2)
	{
		return false;
	}

	public static bool operator !=(PetId id1, int id2)
	{
		return false;
	}

	public static bool operator ==(PetId id1, PetId id2)
	{
		return false;
	}

	public static bool operator !=(PetId id1, PetId id2)
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
}
