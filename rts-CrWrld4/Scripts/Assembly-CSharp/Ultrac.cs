using NBT.Tags;
using UnityEngine;

public class Ultrac : UnitManager
{
	public Transform barrel;

	public override float ammo
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	public void UpdateBarrel()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
