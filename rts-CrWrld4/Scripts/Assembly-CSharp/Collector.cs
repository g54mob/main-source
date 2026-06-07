using NBT.Tags;
using UnityEngine;

public class Collector : UnitManager
{
	public const int PLACEMENT_RANGE = 11;

	private const float PRODUCTION_RATE = 0.4f;

	public CollectorZone collectorZone;

	public CollectorZoneIndicator collectorZoneIndicator;

	public GameObject bar;

	private int showRangeTime;

	public void ShowRange()
	{
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void Refresh()
	{
	}

	public override void GameUpdate()
	{
	}

	public void LateUpdate()
	{
	}

	public override void OnMouseOver()
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
