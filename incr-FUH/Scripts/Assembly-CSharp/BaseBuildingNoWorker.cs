using UnityEngine;

public abstract class BaseBuildingNoWorker : BaseBuilding
{
	public virtual int GetMaximumWorker()
	{
		return 0;
	}

	public override Vector3 GetEnterLocation()
	{
		return Vector3.zero;
	}

	public override bool CanEnter(CharV2 c)
	{
		return false;
	}

	public override bool AddWorker(CharV2 c)
	{
		return false;
	}

	public override bool RemoveWorker(CharV2 c)
	{
		return false;
	}

	public override void PrepareEnter(CharV2 c)
	{
	}

	public override void EnterBuilding(CharV2 c)
	{
	}

	public override void ExitBuilding(CharV2 c)
	{
	}

	public override bool CanDumbGarbage(Garbage g, bool ignoreBan)
	{
		return false;
	}

	public override void DumpGarbage(Garbage g)
	{
	}

	public override bool CanHaveThrowGarbage(Garbage g)
	{
		return false;
	}

	public override Vector3 ThrowGarbageLocation()
	{
		return Vector3.zero;
	}

	public override void DirectDestroyBuilding()
	{
		base.gameObject.SetActive(value: false);
		Object.Destroy(base.gameObject);
	}
}
