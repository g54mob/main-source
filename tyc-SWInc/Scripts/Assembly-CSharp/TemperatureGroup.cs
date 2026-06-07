using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TemperatureGroup
{
	[Flags]
	public enum TempType
	{
		None = 0,
		Heat = 1,
		Cool = 2,
		Both = 3
	}

	private static Vector4[] _tangents;

	private static Vector3[] _vertices;

	private static Vector3[] _normals;

	private static int[] _triangles;

	public HashSet<Room> Rooms = new HashSet<Room>();

	public HashSet<Furniture> Heaters = new HashSet<Furniture>();

	public HashSet<Furniture> Coolers = new HashSet<Furniture>();

	public HashSet<Furniture> HeaterOuputs = new HashSet<Furniture>();

	public HashSet<Furniture> CoolerOutputs = new HashSet<Furniture>();

	public bool IsValid = true;

	public TempType Selected;

	public TempType ForceHighlight;

	public float HeatCapacity;

	public float CoolCapacity;

	public float HeatCapacitySum;

	public float CoolCapacitySum;

	public float HeatOutput;

	public float CoolOutput;

	public float HeatUse;

	public float CoolUse;

	public Dictionary<Furniture, List<Vector3>> CoolLines = new Dictionary<Furniture, List<Vector3>>();

	public Dictionary<Furniture, List<Vector3>> HeatLines = new Dictionary<Furniture, List<Vector3>>();

	private MeshCombiner _meshCombiner;

	private Mesh _mesh;

	public GameObject MeshObject;

	private static ObjectPool<List<Vector3>> _linePool = new ObjectPool<List<Vector3>>(() => new List<Vector3>(), delegate(List<Vector3> x)
	{
		x.Clear();
	});

	private static HashSet<Furniture> _cachedHeaters = new HashSet<Furniture>();

	private static HashSet<Furniture> _cachedCoolers = new HashSet<Furniture>();

	private static HashSet<Furniture> _cachedHeaterOuputs = new HashSet<Furniture>();

	private static HashSet<Furniture> _cachedCoolerOutputs = new HashSet<Furniture>();

	private static HashSet<WallEdge> _openList = new HashSet<WallEdge>();

	private static HashSet<WallEdge> _closedList = new HashSet<WallEdge>();

	private static Dictionary<WallEdge, WallEdge> _cameFrom = new Dictionary<WallEdge, WallEdge>();

	private static Dictionary<WallEdge, float> _cost = new Dictionary<WallEdge, float>();

	private static SortedLinkedList<float, WallEdge> _ecost = new SortedLinkedList<float, WallEdge>(Comparer<float>.Default);

	private static List<WallEdge> _result = new List<WallEdge>();

	private static Dictionary<Room, float> _reqCache = new Dictionary<Room, float>();

	public TemperatureGroup()
	{
		_meshCombiner = new MeshCombiner("TempGroup", false, false, true);
		InitializeMesh();
	}

	private void InitializeMesh()
	{
		if (_tangents == null)
		{
			Mesh pipeMesh = GameSettings.Instance.PipeMesh;
			_tangents = pipeMesh.tangents;
			_vertices = pipeMesh.vertices;
			_normals = pipeMesh.normals;
			_triangles = pipeMesh.triangles;
		}
	}

	public void RemoveFurniture(Furniture furn)
	{
		GetApplicableList(furn).Remove(furn);
	}

	private void CachePreviousFurniture()
	{
		_cachedHeaters.Clear();
		_cachedCoolers.Clear();
		_cachedHeaterOuputs.Clear();
		_cachedCoolerOutputs.Clear();
		_cachedHeaters.AddRange(Heaters);
		_cachedCoolers.AddRange(Coolers);
		_cachedHeaterOuputs.AddRange(HeaterOuputs);
		_cachedCoolerOutputs.AddRange(CoolerOutputs);
	}

	public void UpdateFurniture()
	{
		CachePreviousFurniture();
		ClearFurniture();
		bool forceTempUpdate = false;
		foreach (Room room in Rooms)
		{
			if (room.AtriumChildren.Count > 0)
			{
				foreach (Room item in room.GetAtriumChildrenAndSelf())
				{
					UpdateFurnitureSub(item, ref forceTempUpdate);
				}
			}
			else
			{
				UpdateFurnitureSub(room, ref forceTempUpdate);
			}
		}
		RefreshWarnings(HeaterOuputs, Heaters);
		RefreshWarnings(CoolerOutputs, Coolers);
		if (forceTempUpdate || !Heaters.SetEquals(_cachedHeaters) || !Coolers.SetEquals(_cachedCoolers) || !HeaterOuputs.SetEquals(_cachedHeaterOuputs) || !CoolerOutputs.SetEquals(_cachedCoolerOutputs))
		{
			RefreshLines();
		}
	}

	private void UpdateFurnitureSub(Room room, ref bool forceTempUpdate)
	{
		List<Furniture> furnitures = room.GetFurnitures();
		for (int i = 0; i < furnitures.Count; i++)
		{
			Furniture furniture = furnitures[i];
			HashSet<Furniture> applicableList = GetApplicableList(furniture);
			if (applicableList != null)
			{
				applicableList.Add(furniture);
				furniture.TempGroup = this;
				forceTempUpdate |= furniture.ForceTempUpdate;
				furniture.ForceTempUpdate = false;
				room.DirtyStateVariables = true;
			}
		}
	}

	private void RefreshLines()
	{
		InitLineMesh();
		RemovedUnusuedLines(CoolLines);
		RemovedUnusuedLines(HeatLines);
		List<Furniture> list = new List<Furniture>();
		list.AddRange(Coolers);
		list.AddRange(CoolerOutputs);
		List<MinimumSpanningTree<Furniture, Vector3>.TreeNode> res = new List<MinimumSpanningTree<Furniture, Vector3>.TreeNode>();
		RefreshSubLines(list, CoolLines, res, Vector3.zero);
		list.Clear();
		list.AddRange(Heaters);
		list.AddRange(HeaterOuputs);
		RefreshSubLines(list, HeatLines, res, Vector3.one * 0.03f);
		CreateMesh();
	}

	private void RemovedUnusuedLines(Dictionary<Furniture, List<Vector3>> lines)
	{
		List<Furniture> list = lines.Keys.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			HashSet<Furniture> applicableList = GetApplicableList(furniture);
			if (applicableList == null || !applicableList.Contains(furniture))
			{
				furniture.TempPointTo = null;
				List<Vector3> o = lines[furniture];
				_linePool.Release(o);
				lines.Remove(furniture);
			}
		}
	}

	private void RefreshSubLines(List<Furniture> furniture, Dictionary<Furniture, List<Vector3>> lineOutput, List<MinimumSpanningTree<Furniture, Vector3>.TreeNode> res, Vector3 offset)
	{
		MinimumSpanningTree<Furniture, Vector3>.Run(furniture, (Furniture x) => x.transform.position, (Vector3 pos) => pos.x + pos.y + pos.z, (Vector3 p1, Vector3 p2) => Mathf.Abs(p1.x - p2.x) + Mathf.Abs(p1.y - p2.y) + Mathf.Abs(p1.z - p2.z), res);
		for (int num = 0; num < res.Count; num++)
		{
			MinimumSpanningTree<Furniture, Vector3>.TreeNode treeNode = res[num];
			if (!ValidConnection(treeNode.S, treeNode.PointTo, lineOutput))
			{
				treeNode.S.TempPointTo = treeNode.PointTo;
				List<Vector3> value;
				if (treeNode.PointTo != null)
				{
					CreateLines(treeNode.S, treeNode.PointTo, lineOutput, offset);
				}
				else if (lineOutput.TryGetValue(treeNode.S, out value))
				{
					lineOutput.Remove(treeNode.S);
					_linePool.Release(value);
				}
			}
		}
		MinimumSpanningTree<Furniture, Vector3>.Finish(res);
	}

	private bool ValidConnection(Furniture a, Furniture b, Dictionary<Furniture, List<Vector3>> lines)
	{
		if ((object)a.TempPointTo == b)
		{
			if (b != null)
			{
				List<Vector3> value;
				if (!lines.TryGetValue(a, out value))
				{
					return false;
				}
				if (value[0] != AccessPoint(a) || value.Last() != AccessPoint(b))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private void CreateMesh()
	{
		_meshCombiner.Clear("TempGroup");
		AddLinesToMesh(CoolLines, Color.blue);
		AddLinesToMesh(HeatLines, Color.red);
		_meshCombiner.CreateMesh(_mesh);
	}

	private void AddLinesToMesh(Dictionary<Furniture, List<Vector3>> lines, Color color)
	{
		foreach (List<Vector3> value in lines.Values)
		{
			for (int i = 0; i < value.Count - 1; i++)
			{
				Vector3 vector = value[i];
				Vector3 vector2 = value[i + 1];
				if (vector2 != vector)
				{
					Vector3 forward = vector2 - vector;
					float magnitude = forward.magnitude;
					Quaternion q = Quaternion.LookRotation(forward);
					_meshCombiner.AddMesh(_vertices, _normals, _tangents, _triangles, Matrix4x4.TRS(vector, q, new Vector3(0.05f, 0.05f, magnitude)), color);
				}
			}
		}
	}

	public void TogglePipes(bool enable, bool force, TempType type)
	{
		if (force)
		{
			if (enable)
			{
				ForceHighlight |= type;
			}
			else
			{
				ForceHighlight &= ~type;
			}
		}
		else if (enable)
		{
			Selected |= type;
		}
		else
		{
			Selected &= ~type;
		}
		bool flag = (ForceHighlight | Selected) > TempType.None;
		if (!MeshObject.IsReferenceNull() && MeshObject.activeSelf != flag)
		{
			MeshObject.SetActive(flag);
		}
	}

	private void InitLineMesh()
	{
		if (_mesh == null)
		{
			_mesh = new Mesh();
			MeshObject = new GameObject("TempGroupMesh");
			MeshObject.SetActive(false);
			MeshObject.AddComponent<MeshFilter>().sharedMesh = _mesh;
			MeshObject.AddComponent<MeshRenderer>().sharedMaterial = GameSettings.Instance.PipeMat;
		}
	}

	private List<Vector3> AddLine(Furniture furn, Dictionary<Furniture, List<Vector3>> lines)
	{
		List<Vector3> value;
		if (!lines.TryGetValue(furn, out value))
		{
			value = (lines[furn] = _linePool.Get());
		}
		else
		{
			value.Clear();
		}
		return value;
	}

	private void CreateLines(Furniture a, Furniture b, Dictionary<Furniture, List<Vector3>> lines, Vector3 offset)
	{
		if (a.Parent == b.Parent && !a.WallFurn && !b.WallFurn)
		{
			AddLine(a, lines).AddRange(AccessPoint(a), AccessPoint(b));
			return;
		}
		if (a.WallFurn && b.WallFurn)
		{
			if (CheckCrissCross(a.FirstEdge, a.SecondEdge, b.FirstEdge, b.SecondEdge))
			{
				List<Vector3> list = AddLine(a, lines);
				list.Add(AccessPoint(a));
				WallEdge aEdge;
				WallEdge bEdge;
				Vector3 vector = IntermediatePoint(a, offset, out aEdge, out bEdge);
				Vector3 item = IntermediatePoint(b, offset, out aEdge, out bEdge);
				list.Add(vector);
				if (!vector.y.Appx(item.y, 0.05f))
				{
					list.Add(vector.ReplaceY(item.y));
				}
				list.Add(item);
				list.Add(AccessPoint(b));
				return;
			}
			WallEdge wallEdge = CheckSharedEdge(a, b);
			if (wallEdge != null)
			{
				List<Vector3> list2 = AddLine(a, lines);
				Vector3 item2 = AccessPoint(a);
				list2.Add(item2);
				WallEdge aEdge2;
				WallEdge bEdge2;
				list2.Add(IntermediatePoint(a, offset, out aEdge2, out bEdge2));
				list2.Add(wallEdge.Pos.ToVector3(item2.y) + offset);
				Vector3 item3 = IntermediatePoint(b, offset, out aEdge2, out bEdge2);
				Vector3 v = list2.Last();
				if (!v.y.Appx(item3.y, 0.05f))
				{
					list2.Add(v.ReplaceY(item3.y));
				}
				list2.Add(item3);
				list2.Add(AccessPoint(b));
				return;
			}
		}
		WallEdge aEdge3;
		WallEdge bEdge3;
		Vector3 item4 = IntermediatePoint(a, offset, out aEdge3, out bEdge3);
		WallEdge aEdge4;
		WallEdge bEdge4;
		Vector3 vector2 = IntermediatePoint(b, offset, out aEdge4, out bEdge4);
		WallEdge start = ClosestEdge(a, aEdge3, bEdge3);
		WallEdge end = ClosestEdge(b, aEdge4, bEdge4);
		bool sameFloor = a.Parent.Floor == b.Parent.Floor;
		List<WallEdge> list3 = FindPathDynamic(start, end, (WallEdge x, WallEdge wallEdge3) => (x.Pos - wallEdge3.Pos).magnitude, (WallEdge x, WallEdge wallEdge3) => (x.Pos - wallEdge3.Pos).magnitude, (WallEdge x) => GetConnections(x, sameFloor));
		if (list3 == null && sameFloor)
		{
			list3 = FindPathDynamic(start, end, (WallEdge x, WallEdge wallEdge3) => (x.Pos - wallEdge3.Pos).magnitude, (WallEdge x, WallEdge wallEdge3) => (x.Pos - wallEdge3.Pos).magnitude, (WallEdge x) => GetConnections(x, false));
		}
		float y = AccessPoint(a).y;
		List<Vector3> value;
		if (list3 != null && list3.Count > 0)
		{
			List<Vector3> list4 = AddLine(a, lines);
			list4.Add(AccessPoint(a));
			list4.Add(item4);
			bool flag = list3.Count > 1 && CheckCrissCross(aEdge3, bEdge3, list3[0], list3[1]);
			if (list3.Count > 1 && CheckCrissCross(aEdge4, bEdge4, list3[list3.Count - 1], list3[list3.Count - 2]))
			{
				list3.RemoveAt(list3.Count - 1);
			}
			if (list3.Count > 0 && flag)
			{
				list3.RemoveAt(0);
			}
			if (list3.Count > 0)
			{
				int floor = list3[0].Floor;
				for (int num = 0; num < list3.Count; num++)
				{
					WallEdge wallEdge2 = list3[num];
					if (wallEdge2.Floor == floor && BreakEarly(num, list3, list4.Last(), vector2))
					{
						break;
					}
					if (wallEdge2.Floor < floor)
					{
						list4.Add(list4.Last().ReplaceY((float)floor * 2f + offset.y));
						list4.Add(wallEdge2.Pos.ToVector3((float)floor * 2f) + offset);
						y = (float)wallEdge2.Floor * 2f + 1.9f;
					}
					else if (wallEdge2.Floor > floor)
					{
						list4.Add(list4.Last().ReplaceY((float)wallEdge2.Floor * 2f + offset.y));
						y = (float)wallEdge2.Floor * 2f;
					}
					list4.Add(wallEdge2.Pos.ToVector3(y) + offset);
					floor = wallEdge2.Floor;
				}
			}
			Vector3 v2 = list4.Last();
			if (!v2.y.Appx(vector2.y, 0.05f))
			{
				list4.Add(v2.ReplaceY(vector2.y));
			}
			list4.AddRange(vector2, AccessPoint(b));
		}
		else if (lines.TryGetValue(a, out value))
		{
			lines.Remove(a);
			_linePool.Release(value);
		}
	}

	private bool BreakEarly(int i, List<WallEdge> e, Vector3 lastPos, Vector3 dst)
	{
		if (i != e.Count - 1)
		{
			return false;
		}
		Vector2 vector = lastPos.FlattenVector3();
		Vector2 vector2 = dst.FlattenVector3();
		return (vector - vector2).sqrMagnitude < (e[i].Pos - vector2).sqrMagnitude;
	}

	private bool CheckCrissCross(WallEdge fe1, WallEdge fe2, WallEdge e, WallEdge e2)
	{
		if (e == fe1 && e2 == fe2)
		{
			return true;
		}
		if (e == fe2 && e2 == fe1)
		{
			return true;
		}
		return false;
	}

	private WallEdge CheckSharedEdge(Furniture a, Furniture b)
	{
		if (a.FirstEdge == b.FirstEdge)
		{
			return a.FirstEdge;
		}
		if (a.FirstEdge == b.SecondEdge)
		{
			return a.FirstEdge;
		}
		if (a.SecondEdge == b.FirstEdge)
		{
			return a.SecondEdge;
		}
		if (a.SecondEdge == b.SecondEdge)
		{
			return a.SecondEdge;
		}
		return null;
	}

	private Vector3 IntermediatePoint(Furniture furn, Vector3 offset, out WallEdge aEdge, out WallEdge bEdge)
	{
		Vector3 vector = AccessPoint(furn);
		Vector3 result = vector;
		Vector2 vector2 = vector.FlattenVector3();
		if (furn.WallFurn)
		{
			aEdge = furn.FirstEdge;
			bEdge = furn.SecondEdge;
			result = Utilities.ProjectToLineEndlessClamped(vector2, furn.FirstEdge.Pos, furn.SecondEdge.Pos).ToVector3(vector.y) + offset;
		}
		else
		{
			float num = float.MaxValue;
			aEdge = null;
			bEdge = null;
			for (int i = 0; i < furn.Parent.Edges.Count; i++)
			{
				WallEdge wallEdge = furn.Parent.Edges[i];
				WallEdge wallEdge2 = furn.Parent.Edges[(i + 1) % furn.Parent.Edges.Count];
				Vector2 vector3 = Utilities.ProjectToLineEndlessClamped(vector2, wallEdge.Pos, wallEdge2.Pos);
				float sqrMagnitude = (vector3 - vector2).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					aEdge = wallEdge;
					bEdge = wallEdge2;
					num = sqrMagnitude;
					result = vector3.ToVector3(vector.y) + offset;
				}
			}
		}
		return result;
	}

	private WallEdge ClosestEdge(Furniture f, WallEdge a, WallEdge b)
	{
		if (f.WallFurn)
		{
			if (!(f.WallPosition[f.FirstEdge] < f.WallPosition[f.SecondEdge]))
			{
				return f.SecondEdge;
			}
			return f.FirstEdge;
		}
		Vector2 vector = AccessPoint(f).FlattenVector3();
		if (!((vector - a.Pos).sqrMagnitude < (vector - b.Pos).sqrMagnitude))
		{
			return b;
		}
		return a;
	}

	private IEnumerable<WallEdge> GetConnections(WallEdge e, bool sameFloor)
	{
		foreach (KeyValuePair<IRoom, WallEdge> link in e.Links)
		{
			if (link.Value != null)
			{
				yield return link.Value;
			}
		}
		foreach (WallEdge item in e.FindAllConnectionIn())
		{
			if (item != null)
			{
				yield return item;
			}
		}
		if (sameFloor)
		{
			yield break;
		}
		WallEdge eU = null;
		WallEdge eD = null;
		float dU = float.MaxValue;
		float dD = float.MaxValue;
		foreach (Room room in Rooms)
		{
			ConnectionSubCheck(room, ref e, ref dU, ref dD, ref eD, ref eU);
			for (int i = 0; i < room.AtriumChildren.Count; i++)
			{
				ConnectionSubCheck(room.AtriumChildren[i], ref e, ref dU, ref dD, ref eD, ref eU);
			}
		}
		if (eU != null)
		{
			yield return eU;
		}
		if (eD != null)
		{
			yield return eD;
		}
	}

	private void ConnectionSubCheck(Room room, ref WallEdge e, ref float dU, ref float dD, ref WallEdge eD, ref WallEdge eU)
	{
		if (room.Floor == e.Floor - 1)
		{
			for (int i = 0; i < room.Edges.Count; i++)
			{
				WallEdge wallEdge = room.Edges[i];
				float sqrMagnitude = (wallEdge.Pos - e.Pos).sqrMagnitude;
				if (sqrMagnitude < dD)
				{
					dD = sqrMagnitude;
					eD = wallEdge;
				}
			}
		}
		else
		{
			if (room.Floor != e.Floor + 1)
			{
				return;
			}
			for (int j = 0; j < room.Edges.Count; j++)
			{
				WallEdge wallEdge2 = room.Edges[j];
				float sqrMagnitude2 = (wallEdge2.Pos - e.Pos).sqrMagnitude;
				if (sqrMagnitude2 < dU)
				{
					dU = sqrMagnitude2;
					eU = wallEdge2;
				}
			}
		}
	}

	private static List<WallEdge> FindPathDynamic(WallEdge start, WallEdge end, Func<WallEdge, WallEdge, float> Distance, Func<WallEdge, WallEdge, float> Heuristic, Func<WallEdge, IEnumerable<WallEdge>> GetConnections)
	{
		_openList.Clear();
		_closedList.Clear();
		_cameFrom.Clear();
		_cost.Clear();
		_ecost.Clear();
		_openList.Add(start);
		_cost[start] = 0f;
		_ecost.Add(Heuristic(start, end), start);
		_result.Clear();
		while (_openList.Count > 0)
		{
			WallEdge wallEdge = _ecost.Pop();
			if (wallEdge.Equals(end))
			{
				ReconstructPath(wallEdge);
				return _result;
			}
			_openList.Remove(wallEdge);
			_closedList.Add(wallEdge);
			foreach (WallEdge item in GetConnections(wallEdge))
			{
				if (!_closedList.Contains(item))
				{
					float num = _cost[wallEdge] + Distance(wallEdge, item);
					if (!_openList.Contains(item) || num < _cost[item])
					{
						_cameFrom[item] = wallEdge;
						_cost[item] = num;
						_ecost.Add(_cost[item] + Heuristic(item, end), item);
						_openList.Add(item);
					}
				}
			}
		}
		return null;
	}

	private static void ReconstructPath(WallEdge currentNode)
	{
		if (_cameFrom.ContainsKey(currentNode))
		{
			ReconstructPath(_cameFrom[currentNode]);
		}
		_result.Add(currentNode);
	}

	private Vector3 AccessPoint(Furniture f)
	{
		return (f.TempAccessPoint ?? f.transform).position;
	}

	private void RefreshWarnings(HashSet<Furniture> output, HashSet<Furniture> sources)
	{
		bool flag = sources.Count == 0;
		foreach (Furniture item in output)
		{
			if (flag)
			{
				HUD.Instance.NoInputTemp.Add(item);
			}
			else
			{
				HUD.Instance.NoInputTemp.Remove(item);
			}
		}
	}

	public void RefreshTemperatureValues()
	{
		RefreshTempValues(Heaters, HeaterOuputs, ref HeatCapacity, ref HeatOutput, ref HeatCapacitySum, false);
		RefreshTempValues(Coolers, CoolerOutputs, ref CoolCapacity, ref CoolOutput, ref CoolCapacitySum, true);
		foreach (Room room in Rooms)
		{
			room.UpdateTemperatureValues();
			room.ResetTempUsage();
			room.UpdateTemperature(true);
		}
		RefreshUseValues();
		foreach (Furniture cooler in Coolers)
		{
			cooler.UseModifier = CoolUse;
		}
		foreach (Furniture heater in Heaters)
		{
			heater.UseModifier = HeatUse;
		}
	}

	public void RefreshUseValues()
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		foreach (Room room in Rooms)
		{
			num += room.TempCoolControlUsage * room.GetAtriumArea();
			num2 += room.TempHeatControlUsage * room.GetAtriumArea();
			num3 += room.Area;
		}
		if (num3 > 0f)
		{
			if (CoolCapacitySum > 0f)
			{
				CoolUse = num / CoolCapacitySum;
			}
			else
			{
				CoolUse = 0f;
			}
			if (HeatCapacitySum > 0f)
			{
				HeatUse = num2 / HeatCapacitySum;
			}
			else
			{
				HeatUse = 0f;
			}
		}
		else
		{
			CoolUse = 0f;
			HeatUse = 0f;
		}
	}

	private void RefreshTempValues(HashSet<Furniture> source, HashSet<Furniture> dest, ref float capacity, ref float output, ref float capacitySum, bool cooling)
	{
		_reqCache.Clear();
		foreach (Furniture item in dest)
		{
			if (item.Parent != null)
			{
				_reqCache.AddUp(item.Parent.GetMainAtriumParentOrSelf(), item.HeatCoolArea);
			}
		}
		float num = 0f;
		foreach (KeyValuePair<Room, float> item2 in _reqCache)
		{
			num += Mathf.Min(item2.Value, item2.Key.GetTemperatureArea(cooling));
		}
		float num2 = source.SumSafe((Furniture x) => x.HeatCoolArea);
		capacity = ((num2 > 0f) ? Mathf.Min(1.5f, num / num2) : 0f);
		capacitySum = num2 * Mathf.Max(1f, capacity);
		if (capacity > 1f)
		{
			if (!NotificationManager.CheckAggregates<TemperatureOveruseNotification>(source))
			{
				NotificationManager.AddNotification(new TemperatureOveruseNotification(source));
			}
			num2 *= capacity;
		}
		output = ((num > 0f) ? Mathf.Min(1f, num2 / num) : 0f);
	}

	public void Clear()
	{
		ClearFurniture();
		ClearRooms();
		UnityEngine.Object.Destroy(MeshObject);
		UnityEngine.Object.Destroy(_mesh);
		_mesh = null;
		MeshObject = null;
		IsValid = true;
		Selected = TempType.None;
		ForceHighlight = TempType.None;
		foreach (KeyValuePair<Furniture, List<Vector3>> coolLine in CoolLines)
		{
			_linePool.Release(coolLine.Value);
		}
		foreach (KeyValuePair<Furniture, List<Vector3>> heatLine in HeatLines)
		{
			_linePool.Release(heatLine.Value);
		}
		CoolLines.Clear();
		HeatLines.Clear();
	}

	public void ClearFurniture()
	{
		ClearList(Heaters);
		ClearList(Coolers);
		ClearList(HeaterOuputs, true);
		ClearList(CoolerOutputs, true);
	}

	public void ClearRooms()
	{
		foreach (Room room in Rooms)
		{
			if (room.TempGroup == this)
			{
				room.TempGroup = null;
			}
		}
		Rooms.Clear();
	}

	private void ClearList(HashSet<Furniture> f, bool withWarning = false)
	{
		withWarning &= HUD.Instance != null;
		foreach (Furniture item in f)
		{
			if (item.TempGroup == this)
			{
				item.TempGroup = null;
				if (withWarning && item != null)
				{
					HUD.Instance.NoInputTemp.Add(item);
				}
			}
		}
		f.Clear();
	}

	private HashSet<Furniture> GetApplicableList(Furniture furn)
	{
		if (furn.TemperatureController)
		{
			if (furn.TempControlType == Furniture.TemperatureType.Cooling)
			{
				return Coolers;
			}
			if (furn.TempControlType == Furniture.TemperatureType.Heating)
			{
				return Heaters;
			}
		}
		else if (furn.TemperatureOutput)
		{
			if (furn.TempControlType == Furniture.TemperatureType.Cooling)
			{
				return CoolerOutputs;
			}
			if (furn.TempControlType == Furniture.TemperatureType.Heating)
			{
				return HeaterOuputs;
			}
		}
		return null;
	}
}
