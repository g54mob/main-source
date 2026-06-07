using UnityEngine;

public class HyperPathBuilder
{
	public float cost;

	private UnitManager holder;

	private float amtBuilt;

	public UnitManager targetUnit;

	private WorldLine tmpBuildLine;

	private Color buildLineColor;

	public const int MAX_DIST = 100;

	public void Init(UnitManager holder, float cost, UnitManager targetUnit)
	{
	}

	public void GameUpdate()
	{
	}

	public void ApplyPacket(float amt)
	{
	}

	public void Destroy()
	{
	}
}
