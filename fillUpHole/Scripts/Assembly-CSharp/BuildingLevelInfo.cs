using System.Collections.Generic;
using UnityEngine;

public class BuildingLevelInfo : MonoBehaviour
{
	public CharDisplay Peon;

	public List<BuildingOutputV2> OutputsV2;

	public ParticleSystem BuildDust;

	private bool _hasPeon;

	public bool HasPeon => _hasPeon;

	private void Start()
	{
		PeonExit();
		Peon.IgnoreBubble();
	}

	public void PeonEnter()
	{
		_hasPeon = true;
		Peon.gameObject.SetActive(value: true);
	}

	public void PeonExit()
	{
		_hasPeon = false;
		Peon.gameObject.SetActive(value: false);
	}

	public bool ExecuteOutput(Garbage garbage, float dustPercentage)
	{
		List<Garbage> list = new List<Garbage>();
		list.Add(garbage);
		return ExecuteOutput(list, dustPercentage);
	}

	public bool ExecuteOutput(List<Garbage> garbages, float dustPercentage)
	{
		bool result = true;
		List<BuildingOutputV2> list = new List<BuildingOutputV2>();
		foreach (BuildingOutputV2 item in OutputsV2)
		{
			if (item.CanOutput())
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			foreach (Garbage garbage in garbages)
			{
				list[Random.Range(0, list.Count)].StoreGarbage(garbage);
			}
		}
		else
		{
			result = false;
			foreach (Garbage garbage2 in garbages)
			{
				GameController.Instance.GarbageController.DestroyGarbage(garbage2);
			}
		}
		foreach (BuildingOutputV2 item2 in list)
		{
			item2.OutputGarbage(dustPercentage);
		}
		return result;
	}

	public bool ExecuteOutput(int amount, int size, float dustPercentage, GarbageInfo.GarbageTypeEnum garbageType, GarbageInfo.CameFromEnum cameFrom, bool isEvil)
	{
		bool result = true;
		List<BuildingOutputV2> list = new List<BuildingOutputV2>();
		foreach (BuildingOutputV2 item in OutputsV2)
		{
			if (item.CanOutput())
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			for (int i = 0; i < amount; i++)
			{
				list[Random.Range(0, list.Count)].StoreGarbage(size, garbageType, cameFrom, isEvil);
			}
		}
		else
		{
			result = false;
		}
		foreach (BuildingOutputV2 item2 in list)
		{
			item2.OutputGarbage(dustPercentage);
		}
		return result;
	}

	public void ExecuteDust(float dustPercentage)
	{
		foreach (BuildingOutputV2 item in OutputsV2)
		{
			item.OutputDust(dustPercentage);
		}
	}

	public void SetIsThrowing(bool canThrow)
	{
		foreach (BuildingOutputV2 item in OutputsV2)
		{
			item.SetIsThrowing(canThrow);
		}
	}

	public void SetCanClose(bool canClose)
	{
		foreach (BuildingOutputV2 item in OutputsV2)
		{
			item.SetCanClose(canClose);
		}
	}

	public bool HasOpenPipe()
	{
		foreach (BuildingOutputV2 item in OutputsV2)
		{
			if (item.CanOutput())
			{
				return true;
			}
		}
		return false;
	}

	public void GenerateLevelDust()
	{
		if (BuildDust != null)
		{
			BuildDust.Play();
		}
	}
}
