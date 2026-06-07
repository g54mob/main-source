using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class NetworkRoom : MonoBehaviour, IRoom
{
	public uint NetworkID;

	public int FloorHeight = 1;

	[NonSerialized]
	private int _dirty = -1;

	public bool StructureDirty;

	private float RoofBaseHeight = 2f;

	public Renderer WallObject;

	public Renderer RoofFloorObject;

	public Renderer SubFence;

	public List<Renderer> Atriums = new List<Renderer>();

	public List<List<WallEdge>> AtriumEdges = new List<List<WallEdge>>();

	[NonSerialized]
	public PlayerMap Map;

	[NonSerialized]
	public string WallMaterial;

	[NonSerialized]
	public string FloorMaterial;

	[NonSerialized]
	private int _wallColorID = -1;

	[NonSerialized]
	private int _floorColorID = -1;

	[NonSerialized]
	public Color FenceColor;

	[NonSerialized]
	public Color OutsideColor1;

	[NonSerialized]
	public Color OutsideColor2;

	[NonSerialized]
	public Color FloorColor1;

	[NonSerialized]
	public Color FloorColor2;

	public bool Outdoors { get; set; }

	public bool Outside { get; set; }

	public bool Pillar { get; set; }

	public bool Rentable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool PlayerOwned
	{
		get
		{
			return false;
		}
	}

	public float FenceHeight { get; set; }

	public int Floor { get; set; }

	public List<WallEdge> Edges { get; set; }

	public Roof Roofing { get; set; }

	public SVector3 FloorOffset { get; set; } = SVector3.Zero;

	public float FloorRotation { get; set; }

	public float FloorScale { get; set; } = 1f;

	public int AtriumChildrenCount
	{
		get
		{
			return FloorHeight - 1;
		}
	}

	public void MakeDirty()
	{
		if (_dirty >= 0)
		{
			_dirty = 2;
		}
	}

	public void SetData(BuildingPrefab prefab, int room)
	{
		BuildingPrefab.RoomObject roomObject = prefab.Rooms[room];
		NetworkID = roomObject.RoomGroupID;
		Outdoors = roomObject.Outdoor;
		Floor = roomObject.Floor;
		Edges = roomObject.Edges.SelectInPlaceList((int x) => Map.GetEdge(prefab.Edges[x], Floor, true));
		for (int num = 0; num < Edges.Count; num++)
		{
			Edges[num].Links[this] = Edges[(num + 1) % Edges.Count];
		}
		if (Outdoors)
		{
			_wallColorID = RoomMaterialController.TakeColor();
			_floorColorID = RoomMaterialController.Take2Colors();
		}
		else
		{
			_wallColorID = RoomMaterialController.Take2Colors();
		}
		FloorHeight = roomObject.RoomHeight;
		FloorOffset = new SVector3(roomObject.Offset.x.Clamp(), roomObject.Offset.y.Clamp(), 0f);
		FloorRotation = roomObject.Offset.z.Clamp(0f, 360f);
		FloorScale = roomObject.Offset.w.Clamp(0.5f, 1.5f);
		SetColor(roomObject.Colors[1], (Outdoors ? null : roomObject.EColor2) ?? ((SVector3)Color.black), true);
		SetColor(roomObject.Colors[2], roomObject.EColor1 ?? ((SVector3)Color.black), false);
		SetOutsideMaterial(Outdoors ? roomObject.Materials[3] : roomObject.Materials[1]);
		SetInsideMaterial(roomObject.Materials[2]);
		for (int num2 = 0; num2 < roomObject.Edges.Length; num2++)
		{
			int key = roomObject.Edges[num2];
			int[] value;
			if (!prefab.Smoothing.TryGetValue(key, out value))
			{
				continue;
			}
			for (int num3 = 0; num3 < value.Length; num3++)
			{
				int num4 = Array.IndexOf(roomObject.Edges, value[num3]);
				if (num4 >= 0)
				{
					Edges[num2].Smooth.Add(Edges[num4]);
				}
			}
		}
		MakeDirty();
		DirtyAllSurrounding(Edges);
	}

	public void SetEdges(Vector2[] ps, bool[] smoothing)
	{
		Map.DirtyAllSnaps(this);
		Edges.ForEach(delegate(WallEdge x)
		{
			Map.CleanEdge(x, this);
		});
		Edges.Clear();
		Edges = ps.SelectInPlaceList((Vector2 x) => Map.GetEdge(x, Floor, true));
		for (int num = 0; num < Edges.Count; num++)
		{
			WallEdge wallEdge = Edges[num];
			WallEdge wallEdge2 = Edges[(num + 1) % Edges.Count];
			wallEdge.Links[this] = wallEdge2;
			if (smoothing[num])
			{
				wallEdge.Smooth.Add(wallEdge2);
			}
		}
		DirtyAllSurrounding(Edges);
		MakeDirty();
		StructureDirty = true;
	}

	public void Init(PlayerMap map, BuildingPrefab prefab, int room)
	{
		Map = map;
		SetData(prefab, room);
		RemoveTrees();
	}

	public void SetOutsideMaterial(string mat)
	{
		if (mat.Equals(WallMaterial))
		{
			return;
		}
		WallMaterial = mat;
		if (Outdoors)
		{
			FenceHeight = ObjectDatabase.Instance.FenceStyles.First((ObjectDatabase.FenceStyle x) => x.Name.Equals(WallMaterial)).Height;
			MakeDirty();
		}
		else if (WallObject != null)
		{
			Room.SetMaterial(this, WallObject.GetComponent<MeshFilter>(), WallMaterial, _wallColorID, false);
			for (int num = 0; num < Atriums.Count; num++)
			{
				if (Atriums[num] != null)
				{
					Room.SetMaterial(this, Atriums[num].GetComponent<MeshFilter>(), WallMaterial, _wallColorID, false);
				}
			}
		}
		else
		{
			MakeDirty();
		}
	}

	public void SetInsideMaterial(string mat)
	{
		if (Outdoors && !mat.Equals(FloorMaterial))
		{
			FloorMaterial = mat;
			if (RoofFloorObject != null)
			{
				Room.SetMaterial(this, RoofFloorObject.GetComponent<MeshFilter>(), FloorMaterial, _floorColorID, false);
			}
			else
			{
				MakeDirty();
			}
		}
	}

	public void SetColor(Color c, Color c2, bool outer)
	{
		if (Outdoors)
		{
			if (outer)
			{
				if (FenceColor != c)
				{
					MakeDirty();
				}
				FenceColor = c;
			}
			else
			{
				FloorColor1 = c;
				FloorColor2 = c2;
				RoomMaterialController.WriteColor(_floorColorID, c);
				RoomMaterialController.WriteColor(_floorColorID + 1, c2);
			}
		}
		else if (outer)
		{
			OutsideColor1 = c;
			OutsideColor2 = c2;
			RoomMaterialController.WriteColor(_wallColorID, c);
			RoomMaterialController.WriteColor(_wallColorID + 1, c2);
		}
	}

	public void UpdateMe()
	{
		if (_dirty > 0)
		{
			_dirty--;
			if (_dirty == 0)
			{
				GenerateMeshes();
			}
		}
		else if (_dirty < 0)
		{
			GenerateMeshes();
			_dirty = 0;
		}
		bool flag = (CameraScript.Instance.FlyMode ? (CameraScript.Instance.mainCam.transform.position.y < 0f) : Utilities.InBasement(GameSettings.Instance.ActiveFloor)) == Utilities.InBasement(Floor);
		bool flag2 = false;
		if (flag)
		{
			WallObject.enabled = true;
			flag2 = Floor > GameSettings.Instance.ActiveFloor;
			if (Outdoors)
			{
				WallObject.shadowCastingMode = ((!flag2) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
			}
			else
			{
				WallObject.sharedMaterial = (flag2 ? RoomMaterialController.Instance.ShadowsOnly : RoomMaterialController.Instance.MainMat);
			}
		}
		else
		{
			WallObject.enabled = false;
		}
		RefreshAtriumVisibility();
		if (Outdoors && SubFence != null)
		{
			SubFence.enabled = WallObject.enabled && !flag2;
		}
		if (!(RoofFloorObject != null))
		{
			return;
		}
		if (Outdoors)
		{
			RoofFloorObject.shadowCastingMode = ShadowCastingMode.TwoSided;
			if (Floor > 0 && Floor > GameSettings.Instance.ActiveFloor)
			{
				RoofFloorObject.enabled = true;
				RoofFloorObject.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			}
			else
			{
				RoofFloorObject.enabled = Floor <= GameSettings.Instance.ActiveFloor && flag;
			}
		}
		else
		{
			RoofFloorObject.enabled = WallObject.enabled;
			RoofFloorObject.sharedMaterial = (flag2 ? RoomMaterialController.Instance.ShadowsOnly : RoomMaterialController.Instance.StandardRoof);
		}
	}

	private void RefreshAtriumVisibility()
	{
		if (Outdoors)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < Atriums.Count; i++)
		{
			int num2 = Floor + i + 1;
			if (CameraScript.Instance.FlyMode ? (CameraScript.Instance.mainCam.transform.position.y >= 0f) : (!Utilities.InBasement(GameSettings.Instance.ActiveFloor)))
			{
				Atriums[i].enabled = true;
				bool flag = num2 > GameSettings.Instance.ActiveFloor;
				Atriums[i].sharedMaterial = (flag ? RoomMaterialController.Instance.ShadowsOnly : RoomMaterialController.Instance.MainMat);
				if (!flag)
				{
					num = i + 1;
				}
			}
			else
			{
				Atriums[i].enabled = false;
			}
		}
		RoofFloorObject.transform.position = new Vector3(RoofFloorObject.transform.position.x, RoofBaseHeight + (float)num * 2f, RoofFloorObject.transform.position.z);
	}

	private void OnDestroy()
	{
		if (RoomMaterialController.Instance == null)
		{
			return;
		}
		Edges.ForEach(delegate(WallEdge x)
		{
			Map.CleanEdge(x, this);
		});
		if (_wallColorID >= 0)
		{
			if (Outdoors)
			{
				RoomMaterialController.FreeColor(_wallColorID);
				RoomMaterialController.Free2Colors(_floorColorID);
			}
			else
			{
				RoomMaterialController.Free2Colors(_wallColorID);
			}
		}
		if (WallObject != null)
		{
			UnityEngine.Object.Destroy(WallObject.GetComponent<MeshFilter>().sharedMesh);
		}
		if (RoofFloorObject != null)
		{
			UnityEngine.Object.Destroy(RoofFloorObject.GetComponent<MeshFilter>().sharedMesh);
		}
		if (SubFence != null)
		{
			UnityEngine.Object.Destroy(SubFence.GetComponent<MeshFilter>().sharedMesh);
		}
	}

	public uint GetUniqueID()
	{
		return NetworkID;
	}

	public uint GetRoomNetworkID()
	{
		return NetworkID;
	}

	public bool MakeBlack()
	{
		return false;
	}

	public IRoom GetAtriumParent(bool returnNull)
	{
		return this;
	}

	public bool IsContentVisible()
	{
		if (Outdoors)
		{
			return Floor <= GameSettings.Instance.ActiveFloor;
		}
		if (Floor < 0 && GameSettings.Instance.ActiveFloor >= 0)
		{
			return false;
		}
		if (Floor >= 0 && GameSettings.Instance.ActiveFloor < 0)
		{
			return false;
		}
		if (GameSettings.Instance.ActiveFloor >= Floor)
		{
			return GameSettings.Instance.ActiveFloor <= Floor + FloorHeight - 1;
		}
		return false;
	}

	public IRoom FindCeilingAtrium(Vector2 p)
	{
		return this;
	}

	public IEnumerable<IRoom> GetSelfAndAtriumsAbove()
	{
		yield return this;
	}

	public List<WallEdge> CloneEdges(int floor)
	{
		List<WallEdge> list = new List<WallEdge>(Edges.Count);
		for (int i = 0; i < Edges.Count; i++)
		{
			list.Add(Map.GetEdge(Edges[i].Pos, floor, true));
		}
		for (int j = 0; j < list.Count; j++)
		{
			WallEdge wallEdge = list[j];
			WallEdge wallEdge2 = list[(j + 1) % list.Count];
			wallEdge.Links[this] = wallEdge2;
			if (Edges[j].Smooth.Contains(Edges[(j + 1) % Edges.Count]))
			{
				wallEdge.Smooth.Add(wallEdge2);
			}
		}
		DirtyAllSurrounding(list);
		return list;
	}

	public void RefreshAtriums(bool meshDirty)
	{
		bool flag = false;
		if (AtriumEdges.Count != FloorHeight - 1 || StructureDirty)
		{
			if (StructureDirty)
			{
				int num = Mathf.Min(AtriumEdges.Count, FloorHeight - 1);
				for (int i = 0; i < num; i++)
				{
					AtriumEdges[i].ForEach(delegate(WallEdge x)
					{
						Map.CleanEdge(x, this);
					});
					AtriumEdges[i] = CloneEdges(i + Floor + 1);
					meshDirty = true;
				}
				StructureDirty = false;
			}
			int count = AtriumEdges.Count;
			for (int num2 = count; num2 < FloorHeight - 1; num2++)
			{
				AtriumEdges.Add(CloneEdges(num2 + Floor + 1));
				flag = true;
			}
			count = AtriumEdges.Count;
			for (int num3 = FloorHeight - 1; num3 < count; num3++)
			{
				int index = AtriumEdges.Count - 1;
				AtriumEdges[index].ForEach(delegate(WallEdge x)
				{
					Map.CleanEdge(x, this);
				});
				AtriumEdges.RemoveAt(index);
				flag = true;
			}
		}
		if (flag || meshDirty)
		{
			RefreshAtriumMeshes(meshDirty);
		}
	}

	private void DirtyAllSurrounding(List<WallEdge> edges)
	{
		for (int i = 0; i < edges.Count; i++)
		{
			foreach (KeyValuePair<IRoom, WallEdge> link in edges[i].Links)
			{
				NetworkRoom networkRoom;
				if ((object)(networkRoom = link.Key as NetworkRoom) != null && networkRoom != this)
				{
					MakeDirty();
				}
			}
		}
	}

	private void RefreshAtriumMeshes(bool meshDirty)
	{
		for (int i = Atriums.Count; i < AtriumEdges.Count; i++)
		{
			Atriums.Add(null);
			if (!meshDirty)
			{
				GenerateAtriumMesh(i);
			}
		}
		int count = Atriums.Count;
		for (int j = AtriumEdges.Count; j < count; j++)
		{
			int index = Atriums.Count - 1;
			UnityEngine.Object.Destroy(Atriums[index].GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(Atriums[index].gameObject);
			Atriums.RemoveAt(index);
		}
		if (meshDirty)
		{
			for (int k = 0; k < Atriums.Count; k++)
			{
				GenerateAtriumMesh(k);
			}
		}
	}

	private void GenerateAtriumMesh(int i)
	{
		if (Atriums[i] != null)
		{
			UnityEngine.Object.Destroy(Atriums[i].GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(Atriums[i].gameObject);
		}
		List<WallEdge> edges = Edges;
		int floor = Floor;
		Floor = floor + i + 1;
		Edges = AtriumEdges[i];
		GameObject gameObject = Room.GenerateOuterWalls(this, _wallColorID, WallMaterial);
		gameObject.name = "Atrium " + (i + 1);
		gameObject.transform.SetParent(base.transform);
		Atriums[i] = gameObject.GetComponent<MeshRenderer>();
		Floor = floor;
		Edges = edges;
		if (i == Atriums.Count - 1)
		{
			GenerateRoof();
		}
	}

	private void GenerateRoof()
	{
		if (RoofFloorObject != null)
		{
			UnityEngine.Object.Destroy(RoofFloorObject.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(RoofFloorObject.gameObject);
		}
		List<WallEdge> edges = Edges;
		if (AtriumEdges.Count > 0)
		{
			Edges = AtriumEdges.Last();
		}
		GameObject gameObject = Room.GenerateRoofObject(this, _wallColorID);
		RoofFloorObject = ((gameObject != null) ? gameObject.GetComponent<Renderer>() : null);
		if (RoofFloorObject != null)
		{
			RoofBaseHeight = RoofFloorObject.transform.position.y;
			RoofFloorObject.transform.SetParent(base.transform);
		}
		Edges = edges;
	}

	private void GenerateMeshes()
	{
		if (WallObject != null)
		{
			UnityEngine.Object.Destroy(WallObject.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(WallObject.gameObject);
		}
		if (RoofFloorObject != null)
		{
			UnityEngine.Object.Destroy(RoofFloorObject.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(RoofFloorObject.gameObject);
		}
		if (Outdoors)
		{
			if (SubFence != null)
			{
				UnityEngine.Object.Destroy(SubFence.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(SubFence.gameObject);
			}
			KeyValuePair<GameObject, GameObject> keyValuePair = Room.GenerateFenceObjects(this, WallMaterial, FenceColor);
			WallObject = keyValuePair.Key.GetComponent<Renderer>();
			SubFence = ((keyValuePair.Value != null) ? keyValuePair.Value.GetComponent<Renderer>() : null);
			if (WallObject != null)
			{
				WallObject.transform.SetParent(base.transform);
			}
			if (SubFence != null)
			{
				SubFence.transform.SetParent(base.transform);
			}
			GameObject gameObject = Room.GenerateFloor(this, _floorColorID, FloorMaterial);
			RoofFloorObject = ((gameObject != null) ? gameObject.GetComponent<Renderer>() : null);
			if (RoofFloorObject != null)
			{
				RoofFloorObject.sharedMaterial = RoomMaterialController.Instance.MainMat;
				RoofFloorObject.transform.SetParent(base.transform);
			}
		}
		else
		{
			GameObject gameObject2 = Room.GenerateOuterWalls(this, _wallColorID, WallMaterial);
			WallObject = ((gameObject2 != null) ? gameObject2.GetComponent<Renderer>() : null);
			if (WallObject != null)
			{
				WallObject.sharedMaterial = RoomMaterialController.Instance.MainMat;
				WallObject.transform.SetParent(base.transform);
			}
			GenerateRoof();
		}
		RefreshAtriums(true);
		if (Floor == 0)
		{
			GrassSystem.Instance.InvalidateArea();
		}
	}

	public List<RoomSegment> GetSegments()
	{
		HashSet<RoomSegment> hashSet = new HashSet<RoomSegment>();
		if (Edges == null || Edges.Count == 0)
		{
			return new List<RoomSegment>();
		}
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge;
		int num = 0;
		do
		{
			WallEdge value;
			if (!wallEdge.Links.TryGetValue(this, out value))
			{
				return new List<RoomSegment>();
			}
			HashSet<WallSnap> value2;
			if (wallEdge.Children.TryGetValue(value, out value2))
			{
				hashSet.AddRange(value2.OfType<RoomSegment>());
			}
			wallEdge = value;
			num++;
			if (num > Edges.Count * 2)
			{
				return new List<RoomSegment>();
			}
		}
		while (wallEdge != wallEdge2);
		return hashSet.ToList();
	}

	public IEnumerable<WallSnap> GetSnaps()
	{
		HashSet<WallSnap> result = new HashSet<WallSnap>();
		if (Edges == null || Edges.Count == 0)
		{
			yield break;
		}
		WallEdge wallEdge = Edges[0];
		WallEdge breaker = wallEdge;
		int i = 0;
		WallEdge next;
		while (wallEdge.Links.TryGetValue(this, out next))
		{
			HashSet<WallSnap> value;
			if (wallEdge.Children.TryGetValue(next, out value))
			{
				foreach (WallSnap item in value)
				{
					if (item != null && result.Add(item))
					{
						yield return item;
					}
				}
			}
			wallEdge = next;
			i++;
			if (i <= Edges.Count * 2)
			{
				next = null;
				if (wallEdge == breaker)
				{
					break;
				}
				continue;
			}
			break;
		}
	}

	public override string ToString()
	{
		return Map.Player + ": " + NetworkID;
	}

	public Vector2[] GetExpanded(float expansion, bool ignoreBalcony = false)
	{
		if (Edges == null || Edges.Count == 0)
		{
			return Array.Empty<Vector2>();
		}
		Vector2[] array = new Vector2[Edges.Count];
		int num = 0;
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge;
		do
		{
			if (num >= Edges.Count)
			{
				return array;
			}
			WallEdge value;
			WallEdge value2;
			if (!wallEdge.Links.TryGetValue(this, out value) || !value.Links.TryGetValue(this, out value2))
			{
				return array;
			}
			array[num] = Room.GetOffset(wallEdge, value, value2, expansion);
			wallEdge = value;
			num++;
		}
		while (wallEdge != wallEdge2);
		return array;
	}

	public bool IsInside(Vector2 p, float expansion, bool isRect, Rect bounds)
	{
		if (Outside)
		{
			return true;
		}
		if (Edges == null || Edges.Count == 0)
		{
			return false;
		}
		if (p.x < bounds.xMin + expansion - 0.01f || p.x > bounds.xMax - expansion + 0.01f || p.y < bounds.yMin + expansion - 0.01f || p.y > bounds.yMax - expansion + 0.01f)
		{
			return false;
		}
		if (isRect)
		{
			return true;
		}
		bool flag = expansion != 0f;
		int num = 0;
		Vector2 p2 = (flag ? Room.GetOffset(Edges[Edges.Count - 1], Edges[0], Edges[1], expansion) : Edges[Edges.Count - 1].Pos);
		for (int i = 0; i < Edges.Count; i++)
		{
			Vector2 vector;
			if (flag)
			{
				WallEdge first = Edges[i];
				WallEdge second = Edges[(i + 1) % Edges.Count];
				WallEdge third = Edges[(i + 2) % Edges.Count];
				vector = Room.GetOffset(first, second, third, expansion);
			}
			else
			{
				vector = Edges[i].Pos;
			}
			if (p2.y <= p.y)
			{
				if (vector.y > p.y && Utilities.IsLeft(p2, vector, p) > 0)
				{
					num++;
				}
			}
			else if (vector.y <= p.y && Utilities.IsLeft(p2, vector, p) < 0)
			{
				num--;
			}
			p2 = vector;
		}
		return num != 0;
	}

	public void RemoveTrees()
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			if (wallEdge.Pos.x < num)
			{
				num = wallEdge.Pos.x;
			}
			if (wallEdge.Pos.y < num2)
			{
				num2 = wallEdge.Pos.y;
			}
			if (wallEdge.Pos.x > num3)
			{
				num3 = wallEdge.Pos.x;
			}
			if (wallEdge.Pos.y > num4)
			{
				num4 = wallEdge.Pos.y;
			}
		}
		Rect rect = new Rect(num, num2, num3 - num, num4 - num2);
		HashSet<TreeInstance> hashSet = new HashSet<TreeInstance>();
		bool flag = false;
		bool isRect = Edges.IsAlignedRectangle();
		foreach (TreeInstance item in GameSettings.Instance.TreeTree.Query(rect.Expand(6f, 6f)))
		{
			Vector2 pos = item.GetPos();
			StaticTree treeMesh = item.TreeMesh;
			float num5 = Mathf.Max(treeMesh.bounds.size.x, treeMesh.bounds.size.z);
			if (rect.ContainsEntirely(pos, num5 / 2f) && IsInside(pos, 0f - num5, isRect, rect))
			{
				hashSet.Add(item);
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (TreeInstance item2 in hashSet)
		{
			GameSettings.Instance.RemoveTree(item2);
		}
	}
}
