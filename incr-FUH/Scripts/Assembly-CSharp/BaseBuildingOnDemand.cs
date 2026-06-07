using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuildingOnDemand : BaseBuilding
{
	public List<CharV2> Workers = new List<CharV2>();

	public List<CharV2> Working = new List<CharV2>();

	public virtual int GetMaximumWorker()
	{
		return 1;
	}

	public override Vector3 GetEnterLocation()
	{
		return Vector3.zero;
	}

	public override bool CanEnter(CharV2 c)
	{
		if (Workers.Count >= GetMaximumWorker())
		{
			return Workers.Contains(c);
		}
		return true;
	}

	public override bool AddWorker(CharV2 c)
	{
		if (Workers.Count < GetMaximumWorker())
		{
			Workers.Add(c);
			c.SetTempJob(this);
			return true;
		}
		return false;
	}

	public override bool RemoveWorker(CharV2 c)
	{
		if (Workers.Contains(c))
		{
			if (Working.Contains(c))
			{
				ExitBuilding(c);
			}
			return true;
		}
		return false;
	}

	public override void PrepareEnter(CharV2 c)
	{
		if (CanEnter(c))
		{
			AddWorker(c);
		}
	}

	public override void EnterBuilding(CharV2 c)
	{
		Working.Add(c);
		c.EnterBuilding(this);
	}

	public override void ExitBuilding(CharV2 c)
	{
		Workers.Remove(c);
		Working.Remove(c);
		c.RemoveOutOfBuilding(this, GetEnterLocation());
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
		for (int num = Working.Count - 1; num >= 0; num--)
		{
			CharV2 charV = Working[num];
			ExitBuilding(charV);
			charV.Fly();
		}
		for (int num2 = Workers.Count - 1; num2 >= 0; num2--)
		{
			RemoveWorker(Workers[num2]);
		}
		base.gameObject.SetActive(value: false);
		Object.Destroy(base.gameObject);
	}
}
