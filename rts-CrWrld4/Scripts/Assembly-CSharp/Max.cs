using NBT.Tags;
using UnityEngine;

public class Max : UnitManager
{
	public GameObject barrel;

	private float targetX;

	private float targetY;

	private int coolDown;

	private float gunHeat;

	private float angularVelocity;

	private int starvation;

	private float FIRE_COST => 0f;

	private int COOL_DOWN => 0;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void OnLanded()
	{
	}

	public override void GameUpdate()
	{
	}

	public void FireGameUpdate()
	{
	}

	private void Fire(float targetX, float targetY)
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
