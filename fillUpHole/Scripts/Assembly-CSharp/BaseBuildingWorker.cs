using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuildingWorker : BaseBuilding
{
	public List<CharV2> Workers = new List<CharV2>();

	public List<CharV2> Working = new List<CharV2>();

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
		if (Workers.Contains(c))
		{
			return true;
		}
		return false;
	}

	public override bool AddWorker(CharV2 c)
	{
		if (Workers.Count < GetMaximumWorker() && !Workers.Contains(c))
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
			Workers.Remove(c);
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
	}

	public override void EnterBuilding(CharV2 c)
	{
		Working.Add(c);
		c.EnterBuilding(this);
	}

	public override void ExitBuilding(CharV2 c)
	{
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

	public bool RemoveOneWorker()
	{
		CharV2 charV = null;
		foreach (CharV2 worker in Workers)
		{
			if (!Working.Contains(worker))
			{
				charV = worker;
			}
		}
		if (charV == null && Workers.Count > 0)
		{
			charV = Workers[0];
		}
		if (charV != null)
		{
			RemoveWorker(charV);
			return true;
		}
		return false;
	}

	public override void DirectDestroyBuilding()
	{
		for (int num = Working.Count - 1; num >= 0; num--)
		{
			CharV2 charV = Working[num];
			ExitBuilding(charV);
			if (!(this is Rock))
			{
				charV.Fly();
			}
		}
		for (int num2 = Workers.Count - 1; num2 >= 0; num2--)
		{
			RemoveWorker(Workers[num2]);
		}
		base.gameObject.SetActive(value: false);
		Object.Destroy(base.gameObject);
	}

	public override void SetData(Dictionary<string, int> data)
	{
		base.SetData(data);
	}

	public override Dictionary<string, int> GetData()
	{
		Dictionary<string, int> data = base.GetData();
		data.Add("WorkingCount", Working.Count);
		return data;
	}
}
