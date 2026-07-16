using System;

[Serializable]
public class Dirt
{
	public enum DirtType
	{
		Dish = 0,
		BrokenObject = 1,
		BroomableDirt = 2,
		SwifferDirt = 3
	}

	public DirtType dirtType;

	public Item dirtReferenceItem;

	public Dirt()
	{
		dirtType = DirtType.BroomableDirt;
	}

	public Dirt(DirtType type)
	{
		dirtType = type;
	}
}
