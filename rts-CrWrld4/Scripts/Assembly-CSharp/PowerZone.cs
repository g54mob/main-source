using NBT.Tags;
using UnityEngine;

public class PowerZone : UnitManager
{
	public Mesh activeMesh;

	public Mesh inactiveMesh;

	private Vector2 deployedPZPosition;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	private void UpdateUnits()
	{
	}

	private bool IsDeployed()
	{
		return false;
	}

	public void DeployPZ(bool deploy)
	{
	}

	private void DeployPZ(bool deploy, int gsx, int gsy)
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
