using System.Collections.Generic;

public class MiningGemInstance
{
	public readonly MiningGemShape parentShape;

	public readonly List<Coord> formationCoords;

	public readonly Coord center;

	public readonly ItemType itemType;

	public int numRevealed;

	public bool isExcavated;

	public MiningGemInstance(ItemType t, MiningGemShape parent, Coord centerCoord, List<Coord> coords)
	{
		itemType = t;
		parentShape = parent;
		center = centerCoord;
		formationCoords = coords;
	}

	public bool IsFullyUncovered()
	{
		return numRevealed >= formationCoords.Count;
	}

	public void Excavate()
	{
		isExcavated = true;
	}
}
