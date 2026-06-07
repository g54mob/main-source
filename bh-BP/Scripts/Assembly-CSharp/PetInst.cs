using System;

[Serializable]
public class PetInst
{
	public int Id;

	public string Name;

	public int FoundDay;

	public int Lvl;

	public int CurXP;

	public PetType Type;

	public PetState CurState;

	public float CurStateProgress;

	public float CurStateTgtProgress;

	public bool SeenInMenu;

	public int GetProperty(PropertyType pt, int lvl = -1)
	{
		return 0;
	}

	public int GetRangeProperty(PropertyType ptMin, Random rnd)
	{
		return 0;
	}
}
