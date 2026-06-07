using System;

[Serializable]
public class DungeonCellData
{
	public int x;

	public int y;

	public eDoorFlags doors;

	public eDungeonCellState state;

	public bool isPortalHere;

	public int portalIndex;

	public Obj_PayToCreateGround_Statue statueObj;

	public int stepToCenter;

	public DungeonCellData(int x, int y)
	{
	}

	public int DoorCount()
	{
		return 0;
	}
}
