using NBT.Tags;
using UnityEngine;

public class MoveTarget
{
	public UnitManager um;

	private bool temp;

	private bool createGhost;

	private bool dead;

	private MoveTarget linkTarget;

	private WaypointLineManager linkLine;

	private WaypointLineManager unitLinkLine;

	private int autoLinkCount;

	public bool waypoint;

	public bool autoLink;

	public float cellX;

	public float cellY;

	public UnitMoveGhost ghost;

	public bool ghostActive
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector3 position => default(Vector3);

	public MoveTarget(UnitManager um)
	{
	}

	public MoveTarget(UnitManager um, int cellX, int cellY, bool waypoint, bool temp)
	{
	}

	public MoveTarget(UnitManager um, float cellX, float cellY, bool waypoint, bool temp, bool createGhost)
	{
	}

	private void Init(UnitManager um, float cellX, float cellY, bool waypoint, bool temp, bool createGhost)
	{
	}

	public void UpdatePosition()
	{
	}

	private void CreateGhost(bool temp)
	{
	}

	public bool IsLegal()
	{
		return false;
	}

	public bool IsLegal(bool waypoint)
	{
		return false;
	}

	public void DeployFootprint(bool dep)
	{
	}

	public bool IsFootprintDeployed()
	{
		return false;
	}

	public void DestroyMoveTarget()
	{
	}

	public Tag Serialize()
	{
		return null;
	}

	public void Deserialize(Tag t)
	{
	}
}
