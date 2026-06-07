using UnityEngine;

public class HoleThrow : BaseBuildingNoWorker
{
	public GameObject InputLocation;

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Hole;

	public override Vector3 GetEnterLocation()
	{
		return InputLocation.transform.position;
	}

	public override bool CanEnter(CharV2 c)
	{
		if (c.IsSuperSad)
		{
			return true;
		}
		return false;
	}

	public override void EnterBuilding(CharV2 c)
	{
		c.Fly(rightOnly: true);
	}

	public override bool CanDumbGarbage(Garbage g, bool ignoreBan)
	{
		return true;
	}

	public override void DumpGarbage(Garbage g)
	{
		GameController.TotalPeonTrashThrow++;
		g.Throw(Random.Range(0f, 2f));
	}

	public override bool HasPower()
	{
		return false;
	}
}
