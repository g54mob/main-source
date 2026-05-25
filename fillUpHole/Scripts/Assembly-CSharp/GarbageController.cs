using System.Collections.Generic;
using UnityEngine;

public class GarbageController : MonoBehaviour
{
	private class PreLoadedGarbage
	{
		public Vector3 Pos;

		public int Weight;

		public GarbageInfo.GarbageTypeEnum Type;

		public GarbageInfo.CameFromEnum CameFrom;

		public bool IsEvil;

		public bool IsZap;
	}

	public Garbage GarbageSPrefab;

	public Garbage GarbageMPrefab;

	public Garbage GarbageLPrefab;

	public Garbage GarbageXLPrefab;

	public Garbage GarbageEvilSPrefab;

	public Garbage GarbageEvilMPrefab;

	public Garbage GarbageEvilLPrefab;

	public Garbage GarbageEvilXLPrefab;

	public Garbage ShardBluePrefab;

	public Garbage ShardRedPrefab;

	public Garbage ShardYellowPrefab;

	public Garbage BookPrefab;

	public Garbage GolemPrefab;

	public List<Garbage> ActiveGarbages = new List<Garbage>();

	private Dictionary<Garbage.GarbageTemplateTypeEnum, Stack<Garbage>> InactiveGarbages;

	private Dictionary<Garbage.GarbageTemplateTypeEnum, Garbage> Templates;

	private Vector3 _topLeft = new Vector3(9999f, -9999f, 0f);

	private Vector3 _bottomRight = new Vector3(-9999f, 9999f, 0f);

	private List<PreLoadedGarbage> _preLoadedGarbage;

	private int _preLoadedIndex;

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (InactiveGarbages == null)
		{
			InactiveGarbages = new Dictionary<Garbage.GarbageTemplateTypeEnum, Stack<Garbage>>();
			Templates = new Dictionary<Garbage.GarbageTemplateTypeEnum, Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.GarbageS] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.GarbageM] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.GarbageL] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.GarbageXL] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.EvilGarbageS] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.EvilGarbageM] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.EvilGarbageL] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.EvilGarbageXL] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.BlueShard] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.RedShard] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.YellowShard] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.Book] = new Stack<Garbage>();
			InactiveGarbages[Garbage.GarbageTemplateTypeEnum.Golem] = new Stack<Garbage>();
			Templates[Garbage.GarbageTemplateTypeEnum.GarbageS] = GarbageSPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.GarbageM] = GarbageMPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.GarbageL] = GarbageLPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.GarbageXL] = GarbageXLPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.EvilGarbageS] = GarbageEvilSPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.EvilGarbageM] = GarbageEvilMPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.EvilGarbageL] = GarbageEvilLPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.EvilGarbageXL] = GarbageEvilXLPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.BlueShard] = ShardBluePrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.RedShard] = ShardRedPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.YellowShard] = ShardYellowPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.Book] = BookPrefab;
			Templates[Garbage.GarbageTemplateTypeEnum.Golem] = GolemPrefab;
		}
	}

	private void FixedUpdate()
	{
		for (int num = ActiveGarbages.Count - 1; num >= 0; num--)
		{
			if (ActiveGarbages[num].transform.position.x < _topLeft.x)
			{
				DestroyGarbage(ActiveGarbages[num]);
				ActiveGarbages.RemoveAt(num);
			}
			if (ActiveGarbages[num].transform.position.x > _bottomRight.x || ActiveGarbages[num].transform.position.y < _bottomRight.y)
			{
				GameController.Instance.Hole.ProcessGarbage(ActiveGarbages[num]);
			}
		}
		if (_preLoadedGarbage == null)
		{
			return;
		}
		if (_preLoadedIndex < _preLoadedGarbage.Count - 1)
		{
			for (int i = 0; i < 10; i++)
			{
				if (_preLoadedIndex >= _preLoadedGarbage.Count)
				{
					break;
				}
				Garbage garbage = Generate(_preLoadedGarbage[_preLoadedIndex].Pos, _preLoadedGarbage[_preLoadedIndex].Weight, _preLoadedGarbage[_preLoadedIndex].Type, _preLoadedGarbage[_preLoadedIndex].CameFrom, _preLoadedGarbage[_preLoadedIndex].IsEvil);
				if (_preLoadedGarbage[_preLoadedIndex].IsZap)
				{
					garbage.Info.ForceZap();
				}
				_preLoadedIndex++;
			}
		}
		else
		{
			_preLoadedGarbage = null;
		}
	}

	public void PreLoadGarbage(Vector3 pos, int weight, GarbageInfo.GarbageTypeEnum type, GarbageInfo.CameFromEnum cameFrom, bool isEvil, bool isZap)
	{
		PreLoadedGarbage preLoadedGarbage = new PreLoadedGarbage();
		preLoadedGarbage.Pos = pos;
		preLoadedGarbage.Weight = weight;
		preLoadedGarbage.Type = type;
		preLoadedGarbage.CameFrom = cameFrom;
		preLoadedGarbage.IsEvil = isEvil;
		preLoadedGarbage.IsZap = isZap;
		if (_preLoadedGarbage == null)
		{
			_preLoadedGarbage = new List<PreLoadedGarbage>();
		}
		_preLoadedGarbage.Add(preLoadedGarbage);
	}

	public bool HasALotOnScreen()
	{
		if (ActiveGarbages.Count > 3000)
		{
			return true;
		}
		return false;
	}

	public int GetTotalMoney()
	{
		int num = 0;
		foreach (Garbage activeGarbage in ActiveGarbages)
		{
			num += activeGarbage.Info.Weight;
		}
		return num;
	}

	public void SetBounds(Vector3 topLeft, Vector3 bottomRight)
	{
		_topLeft = topLeft;
		_bottomRight = bottomRight;
	}

	public float FindFartestGarbage()
	{
		float num = 0f;
		foreach (Garbage activeGarbage in ActiveGarbages)
		{
			if (activeGarbage.transform.position.x < num)
			{
				num = activeGarbage.transform.position.x;
			}
		}
		return num;
	}

	public Garbage FindFreeGarbage(Vector3 origin, bool canBeShard)
	{
		Garbage result = null;
		float num = 9999f;
		foreach (Garbage activeGarbage in ActiveGarbages)
		{
			if (!activeGarbage.IsReserved && !activeGarbage.IsFalling() && !activeGarbage.IsStatic() && activeGarbage.transform.position.y < -3f)
			{
				if (Mathf.Abs(activeGarbage.transform.position.x - origin.x) < num)
				{
					num = Mathf.Abs(activeGarbage.transform.position.x - origin.x);
					result = activeGarbage;
				}
				if (canBeShard && (activeGarbage.Info.IsShard || activeGarbage.Info.IsBook))
				{
					num = 0f;
					result = activeGarbage;
				}
			}
		}
		return result;
	}

	public List<Garbage> FindRandomInRangeNotZap(float fromX, float toX, int count)
	{
		List<Garbage> list = new List<Garbage>();
		List<Garbage> list2 = new List<Garbage>();
		foreach (Garbage activeGarbage in ActiveGarbages)
		{
			if (activeGarbage.transform.position.x > fromX && activeGarbage.transform.position.x < toX && !activeGarbage.Info.IsZap)
			{
				list.Add(activeGarbage);
			}
		}
		for (int i = 0; i < count; i++)
		{
			if (list.Count == 1)
			{
				list2.Add(list[0]);
				list.RemoveAt(0);
			}
			else if (list.Count > 1)
			{
				int index = Random.Range(0, list.Count);
				list2.Add(list[index]);
				list.RemoveAt(index);
			}
		}
		return list2;
	}

	public void DestroyGarbage(Garbage g)
	{
		g.RemoveDrag();
		if (g.IsReserved)
		{
			GameController.Instance.PeonController.RemoveReserveGarbage(g);
			g.IsReserved = false;
		}
		ActiveGarbages.Remove(g);
		g.gameObject.SetActive(value: false);
		InactiveGarbages[g.GarbageTemplateType].Push(g);
	}

	public Garbage Generate(Vector3 location, GarbageInfo gi)
	{
		return Generate(location, gi.Weight, gi.GarbageType, gi.CameFrom, gi.IsEvil);
	}

	public void UnreserveAll()
	{
		foreach (Garbage activeGarbage in ActiveGarbages)
		{
			activeGarbage.IsReserved = false;
		}
	}

	public Garbage Generate(Vector3 location, int weight, GarbageInfo.GarbageTypeEnum garbateType, GarbageInfo.CameFromEnum cameFrom, bool isEvil)
	{
		Garbage garbage = null;
		Initialize();
		GameController.TotalGarbageCreated++;
		if (isEvil && !Installation.CanGenerateEvilGarbage())
		{
			isEvil = false;
		}
		Garbage.GarbageTemplateTypeEnum key = Garbage.GarbageTemplateTypeEnum.None;
		switch (garbateType)
		{
		case GarbageInfo.GarbageTypeEnum.GarbageS:
			key = ((!isEvil) ? Garbage.GarbageTemplateTypeEnum.GarbageS : Garbage.GarbageTemplateTypeEnum.EvilGarbageS);
			break;
		case GarbageInfo.GarbageTypeEnum.GarbageM:
			key = ((!isEvil) ? Garbage.GarbageTemplateTypeEnum.GarbageM : Garbage.GarbageTemplateTypeEnum.EvilGarbageM);
			break;
		case GarbageInfo.GarbageTypeEnum.GarbageL:
			key = ((!isEvil) ? Garbage.GarbageTemplateTypeEnum.GarbageL : Garbage.GarbageTemplateTypeEnum.EvilGarbageL);
			break;
		case GarbageInfo.GarbageTypeEnum.GarbageXL:
			key = ((!isEvil) ? Garbage.GarbageTemplateTypeEnum.GarbageXL : Garbage.GarbageTemplateTypeEnum.EvilGarbageXL);
			break;
		case GarbageInfo.GarbageTypeEnum.ShardBlue:
			key = Garbage.GarbageTemplateTypeEnum.BlueShard;
			break;
		case GarbageInfo.GarbageTypeEnum.ShardYellow:
			key = Garbage.GarbageTemplateTypeEnum.YellowShard;
			break;
		case GarbageInfo.GarbageTypeEnum.ShardRed:
			key = Garbage.GarbageTemplateTypeEnum.RedShard;
			break;
		case GarbageInfo.GarbageTypeEnum.Book:
			key = Garbage.GarbageTemplateTypeEnum.Book;
			break;
		case GarbageInfo.GarbageTypeEnum.Golem:
			key = Garbage.GarbageTemplateTypeEnum.Golem;
			break;
		}
		if (InactiveGarbages[key].Count > 0)
		{
			garbage = InactiveGarbages[key].Pop();
			garbage.transform.position = location;
			garbage.RestartDelay();
			garbage.SetAsDynamic();
		}
		else
		{
			garbage = Object.Instantiate(Templates[key], location, Quaternion.identity);
		}
		garbage.SetInfo(weight, garbateType, cameFrom, isEvil);
		garbage.transform.parent = base.transform;
		ActiveGarbages.Add(garbage);
		garbage.IsReserved = false;
		garbage.GetComponent<TrailRenderer>().Clear();
		garbage.gameObject.SetActive(value: true);
		return garbage;
	}

	public void BringBack(Garbage g)
	{
		g.GetComponent<TrailRenderer>().enabled = true;
		ActiveGarbages.Add(g);
		g.transform.SetParent(base.transform);
		g.SetAsDynamic();
	}

	public void Remove(Garbage g)
	{
		g.GetComponent<TrailRenderer>().enabled = false;
		ActiveGarbages.Remove(g);
	}

	public void ExecuteZapAllAbility()
	{
		foreach (Garbage activeGarbage in ActiveGarbages)
		{
			activeGarbage.SetAsZap();
		}
	}

	public void ExecuteCompressAbility()
	{
		List<Garbage> list = new List<Garbage>();
		List<Garbage> list2 = new List<Garbage>();
		for (int num = ActiveGarbages.Count - 1; num >= 0; num--)
		{
			Garbage garbage = ActiveGarbages[num];
			if (garbage.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageS)
			{
				list2.Add(garbage);
			}
			if (list2.Count == 5)
			{
				int num2 = 0;
				float num3 = 0f;
				foreach (Garbage item in list2)
				{
					num2 += item.Info.Weight;
					num3 += item.gameObject.transform.position.x;
					list.Add(item);
				}
				num3 /= 5f;
				list2.Clear();
				Generate(new Vector3(num3, 3f, 0f), num2, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Compressed, isEvil: false);
			}
		}
		foreach (Garbage item2 in list)
		{
			DestroyGarbage(item2);
		}
	}

	public int GetTotalGarbageOnScreen()
	{
		return ActiveGarbages.Count;
	}
}
