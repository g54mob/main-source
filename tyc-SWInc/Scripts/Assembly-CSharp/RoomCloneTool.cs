using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;

public class RoomCloneTool : MonoBehaviour
{
	public enum GroupOption
	{
		Copy = 0,
		Ignore = 1,
		Replace = 2
	}

	public enum Intersection
	{
		None = 0,
		Room = 1,
		Roof = 2,
		Road = 3,
		Plot = 4,
		Path = 5
	}

	public static RoomCloneTool Instance;

	public Material ValidMat;

	public Material InvalidMat;

	public Material ValidMat2;

	[NonSerialized]
	public BuildingPrefab Prefab;

	public MeshFilter BasementRend;

	public Renderer rend;

	public Renderer BasementRender;

	private float PreCost;

	private float PreCostBase;

	private Vector2[][] BasementBounds;

	private Vector2[][][] Bounds;

	private bool[][] IsRoofBound;

	[NonSerialized]
	public Vector2 Center;

	private int Height;

	private bool _outdoorAreaOnFirst;

	public GameObject ArrowX;

	public GameObject ArrowY;

	public bool MirrorX;

	public bool MirrorY;

	public bool AddTrashCans;

	public MiniMapMaker MapMaker;

	[NonSerialized]
	private Dictionary<string, string> _replacements = new Dictionary<string, string>();

	[NonSerialized]
	private bool _furnished = true;

	[NonSerialized]
	private bool _createGroups = true;

	[NonSerialized]
	private RoomGroup _groupReplacement;

	[NonSerialized]
	private GroupOption _groupOption;

	private Vector2 LastPos;

	private void Start()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void Show(Room[] rooms, Roof[] roofs)
	{
		if (BuildController.Instance.ActivePrefab != null)
		{
			WindowManager.Instance.ShowMessageBox("ForcedPrefabError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		if (!BuildingPrefab.ValidCheck(rooms))
		{
			WindowManager.Instance.ShowMessageBox("UnsupportedStructure".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
			{
			}), new KeyValuePair<string, Action>("Select unsupported rooms", delegate
			{
				SelectorController.Instance.SetSelection(BuildingPrefab.GetInvalid(rooms));
			}));
			return;
		}
		BuildingPrefab buildingPrefab = BuildingPrefab.SaveRooms(rooms, roofs, true, false, true, false, true);
		if (buildingPrefab.Rooms.Length != 0)
		{
			Show(buildingPrefab, true);
			MaterialPreviewer.Instance.RefreshState();
		}
	}

	private void CalculateBounds(bool withBasement)
	{
		BuildingPrefab.RoomObject[] list = Prefab.Rooms.Where((BuildingPrefab.RoomObject x) => x.Floor >= 0).ToArray();
		BuildingPrefab.RoomObject[] array = Prefab.Rooms.Where((BuildingPrefab.RoomObject x) => x.Floor < 0).ToArray();
		int num = list.Min((BuildingPrefab.RoomObject x) => x.Floor);
		int num2 = Mathf.Max(list.Max((BuildingPrefab.RoomObject x) => x.Floor), (Prefab.Roofs.Length != 0) ? Prefab.Roofs.Max((BuildingPrefab.RoofObject x) => x.Floor) : 0);
		Bounds = new Vector2[num2 - num + 1][][];
		IsRoofBound = new bool[num2 - num + 1][];
		int i;
		for (i = num; i <= num2; i++)
		{
			List<List<Vector2>> list2 = RoomManager.CombineRoomEdges(Prefab, i, 0.01f, true);
			Vector2[][] array2 = (from x in Prefab.Roofs
				where x.Floor == i
				select x.Area.SelectInPlace((SVector3 z) => z.ToVector2())).ToArray();
			Bounds[i - num] = new Vector2[list2.Count + array2.Length][];
			IsRoofBound[i - num] = new bool[list2.Count + array2.Length];
			for (int num3 = 0; num3 < list2.Count; num3++)
			{
				Bounds[i - num][num3] = list2[num3].ToArray();
				IsRoofBound[i - num][num3] = false;
			}
			for (int num4 = 0; num4 < array2.Length; num4++)
			{
				Bounds[i - num][num4 + list2.Count] = array2[num4];
				IsRoofBound[i - num][num4 + list2.Count] = true;
			}
		}
		if (withBasement && array.Length != 0)
		{
			List<List<Vector2>> list3 = RoomManager.CombineRoomEdges(Prefab, -1, 0.01f, true);
			BasementBounds = new Vector2[list3.Count][];
			for (int num5 = 0; num5 < list3.Count; num5++)
			{
				BasementBounds[num5] = list3[num5].ToArray();
			}
		}
		else
		{
			BasementBounds = null;
		}
	}

	private void Shortcuts()
	{
		if (Options.ShiftToPlace)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceMultiple".Loc(), KeyCode.LeftShift, true);
		}
		else
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceSingle".Loc(), KeyCode.LeftShift, true);
			HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
		}
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureClock);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureAntiClock);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.MirrorRoomHor);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.MirrorRoomVert);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.DisableGrid);
	}

	public string GetFurniture(string furniture)
	{
		if (_replacements == null)
		{
			return furniture;
		}
		return _replacements.GetOrDefault(furniture, furniture);
	}

	public void SetOptions(Dictionary<string, string> furnReplacements, bool furnished, GroupOption gr, string groupRep, bool createGroups)
	{
		_replacements = furnReplacements;
		_furnished = furnished;
		_groupOption = gr;
		_groupReplacement = GameSettings.Instance.GetRoomGroup(groupRep);
		_createGroups = createGroups;
	}

	public void Show(BuildingPrefab rooms, bool withBasement, Dictionary<string, string> furnReplacements = null, bool furnished = true, GroupOption gr = GroupOption.Copy, string groupRep = null, bool createGroups = false, bool addTrashCans = false)
	{
		if (BuildController.Instance.ActivePrefab != null)
		{
			WindowManager.Instance.ShowMessageBox("ForcedPrefabError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		base.transform.rotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
		MirrorX = false;
		MirrorY = false;
		BuildController.Instance.ClearBuild(true);
		WindowManager.SetCursorOverride("Place");
		Prefab = rooms;
		CalculateBounds(withBasement);
		int minAbove = Prefab.Rooms.GetMinAbove(-1, (BuildingPrefab.RoomObject x) => x.Floor);
		Height = Mathf.Max(Prefab.Rooms.Max((BuildingPrefab.RoomObject x) => x.Floor), (Prefab.Roofs.Length != 0) ? Prefab.Roofs.Max((BuildingPrefab.RoofObject x) => x.Floor) : 0) - minAbove;
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		for (int num4 = 0; num4 < Bounds[0].Length; num4++)
		{
			for (int num5 = 0; num5 < Bounds[0][num4].Length; num5++)
			{
				num += Bounds[0][num4][num5].x;
				num2 += Bounds[0][num4][num5].y;
				num3++;
			}
		}
		Center = new Vector3(num / (float)num3, num2 / (float)num3);
		if (!BuildController.NoGrid())
		{
			Center = BuildController.Instance.CorrectMousePos(Center);
		}
		MeshFilter component = GetComponent<MeshFilter>();
		if (component.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(component.sharedMesh);
		}
		component.sharedMesh = MapMaker.CreateBuildingMesh(MapMaker.MapDescFromRooms(Prefab, false), Center);
		if (BasementRend.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(BasementRend.sharedMesh);
		}
		if (BasementBounds != null)
		{
			if (BasementRend.sharedMesh != null)
			{
				UnityEngine.Object.Destroy(BasementRend.sharedMesh);
			}
			BasementRend.sharedMesh = MapMaker.CreateBuildingMesh(MapMaker.MapDescFromRooms(Prefab, true), Center);
			BasementRend.transform.localPosition = -Vector3.up * ((float)minAbove + 1.001f) * 2f;
		}
		base.gameObject.SetActive(true);
		PreCost = 0f;
		PreCostBase = 0f;
		_outdoorAreaOnFirst = false;
		_replacements = furnReplacements;
		_furnished = furnished;
		_groupOption = gr;
		_groupReplacement = GameSettings.Instance.GetRoomGroup(groupRep);
		_createGroups = createGroups;
		AddTrashCans = rooms.AddTrashCans && addTrashCans;
		BuildingPrefab.RoomObject[] rooms2 = Prefab.Rooms;
		foreach (BuildingPrefab.RoomObject roomObject in rooms2)
		{
			if ((roomObject.Outdoor || roomObject.Atrium >= 0) && roomObject.Floor - minAbove == 0)
			{
				_outdoorAreaOnFirst = true;
			}
			BuildingPrefab.FurnitureObject[] furniture = roomObject.Furniture;
			foreach (BuildingPrefab.FurnitureObject furnitureObject in furniture)
			{
				Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(GetFurniture(furnitureObject.Name));
				if (furnitureComponent != null)
				{
					if (roomObject.Floor >= 0)
					{
						PreCost += furnitureComponent.GetCost();
					}
					PreCostBase += furnitureComponent.GetCost();
				}
			}
			BuildingPrefab.SegmentObject[] segments = roomObject.Segments;
			foreach (BuildingPrefab.SegmentObject segmentObject in segments)
			{
				RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(segmentObject.Name);
				if (segmentComponent != null)
				{
					float num8 = segmentComponent.Cost * (segmentObject.Width / segmentComponent.WallWidth);
					if (roomObject.Floor >= 0)
					{
						PreCost += num8;
					}
					PreCostBase += num8;
				}
			}
		}
		ArrowX.transform.localPosition = new Vector3(0f, (float)((Height + 1) * 2) + 0.1f, 0.7f);
		ArrowY.transform.localPosition = new Vector3(0.7f, (float)((Height + 1) * 2) + 0.1f, 0f);
		MaterialPreviewer.Instance.RefreshState();
		Shortcuts();
	}

	private Vector2 CorrectPos(Vector2 p)
	{
		Vector2 vector = p - Center;
		Vector3 vector2 = base.transform.rotation * new Vector3(MirrorX ? (0f - vector.x) : vector.x, 0f, MirrorY ? (0f - vector.y) : vector.y);
		return new Vector2(vector2.x + base.transform.position.x, vector2.z + base.transform.position.z);
	}

	private bool Valid(int floor, int bound, bool doRooms = true)
	{
		if (GameSettings.Instance.ActiveFloor + Height > GameSettings.MaxFloor)
		{
			ErrorOverlay.Instance.ShowError("BuildingTooHigh");
			return false;
		}
		bool flag = floor >= 0 && IsRoofBound[floor][bound];
		switch (Intersects(((floor < 0) ? BasementBounds[bound] : Bounds[floor][bound]).Select(CorrectPos), (floor < 0) ? floor : (GameSettings.Instance.ActiveFloor + floor), !flag, !flag, !flag, !flag))
		{
		case Intersection.Room:
			if (doRooms)
			{
				ErrorOverlay.Instance.ShowError(flag ? "RoofIntersectError" : "RoomIntersectError", false, true, 4f);
				return false;
			}
			break;
		case Intersection.Roof:
			ErrorOverlay.Instance.ShowError("RoofIntersectError", false, true, 4f);
			return false;
		case Intersection.Road:
			ErrorOverlay.Instance.ShowError("RoomOnRoad2");
			return false;
		case Intersection.Plot:
			ErrorOverlay.Instance.ShowError("RoomOutOfPlot");
			return false;
		case Intersection.Path:
			ErrorOverlay.Instance.ShowError("RoomOnPath");
			return false;
		}
		if (!flag && floor == 0 && !GameSettings.Instance.sRoomManager.IsSupported(Bounds[floor][bound].Select(CorrectPos), GameSettings.Instance.ActiveFloor, null))
		{
			ErrorOverlay.Instance.ShowError("UnsupportedStructure");
			return false;
		}
		return true;
	}

	public static Intersection Intersects(IEnumerable<Vector2> polygon, int floor, bool plot, bool roof, bool road, bool path, Room ignore = null)
	{
		List<Vector2> list = polygon.ToList();
		if (path && floor == 0)
		{
			Vector2 p = list[list.Count - 1];
			for (int i = 0; i < list.Count; i++)
			{
				Vector2 vector = list[i];
				if (BuildController.IsOnPath(p, vector, floor))
				{
					return Intersection.Path;
				}
				p = vector;
			}
			if (BuildController.ContainsPath(list, floor))
			{
				return Intersection.Path;
			}
		}
		for (int j = 0; j < list.Count; j += 2)
		{
			list.Insert(j + 1, (list[j] + list[(j + 1) % list.Count]) * 0.5f);
		}
		if (plot && !GameSettings.Instance.PlayerOwnedArea(list, true))
		{
			return Intersection.Plot;
		}
		if (road)
		{
			for (int k = 0; k < list.Count; k++)
			{
				Vector2 vector2 = list[k];
				float num = vector2.x / RoadManager.Instance.RoadSize;
				float num2 = vector2.y / RoadManager.Instance.RoadSize;
				if (num < 0.9999f || num2 < 0.9999f || num > (float)RoadManager.Instance.GridSize - 0.9999f || num2 > (float)RoadManager.Instance.GridSize - 0.9999f)
				{
					return Intersection.Road;
				}
			}
			if (floor >= 0 && floor <= RoadManager.Floors * 2 + 2)
			{
				for (int l = 0; l < list.Count; l++)
				{
					Vector2 p2 = list[l];
					Vector2 p3 = list[(l + 1) % list.Count];
					if (BuildController.IsOnRoad(p2, p3, floor))
					{
						return Intersection.Road;
					}
				}
			}
		}
		bool[] cba = new bool[list.Count];
		List<bool> oba = new List<bool>();
		List<Room> rooms = GameSettings.Instance.sRoomManager.GetRooms();
		for (int m = 0; m < rooms.Count; m++)
		{
			Room room = rooms[m];
			if (room.Floor != floor || !(room != ignore))
			{
				continue;
			}
			if (IntersectionCheckInside(list, room.Edges, (WallEdge x) => x.Pos, cba, oba))
			{
				return Intersection.Room;
			}
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				if (room.IsInside(list[num3], 0.02f))
				{
					return Intersection.Room;
				}
			}
		}
		HashSet<WallEdge> hashSet = new HashSet<WallEdge>();
		for (int num4 = 0; num4 < rooms.Count; num4++)
		{
			Room room2 = rooms[num4];
			if (room2.Floor != floor || !(room2 != ignore))
			{
				continue;
			}
			for (int num5 = 0; num5 < room2.Edges.Count; num5++)
			{
				WallEdge wallEdge = room2.Edges[num5];
				if (hashSet.Contains(wallEdge))
				{
					continue;
				}
				hashSet.Add(wallEdge);
				foreach (WallEdge value in wallEdge.Links.Values)
				{
					for (int num6 = 0; num6 < list.Count; num6++)
					{
						Vector2 p4 = list[num6];
						Vector2 p5 = list[(num6 + 1) % list.Count];
						if (Utilities.LinesIntersect(p4, p5, wallEdge.Pos, value.Pos, true, false))
						{
							return Intersection.Room;
						}
					}
				}
			}
		}
		if (roof && floor >= 1)
		{
			List<Roof> roofs = GameSettings.Instance.sRoomManager.Roofs;
			for (int num7 = 0; num7 < roofs.Count; num7++)
			{
				Roof roof2 = roofs[num7];
				if (roof2.Floor != floor)
				{
					continue;
				}
				if (IntersectionCheckInside(list, roof2.Area, (Vector2 x) => x, cba, oba))
				{
					return Intersection.Roof;
				}
				for (int num8 = 0; num8 < list.Count; num8++)
				{
					if (Utilities.IsInside(list[num8], roof2.Area, Roof.SideBuildDistance))
					{
						return Intersection.Roof;
					}
				}
			}
			for (int num9 = 0; num9 < roofs.Count; num9++)
			{
				Roof roof3 = roofs[num9];
				if (roof3.Floor != floor)
				{
					continue;
				}
				for (int num10 = 0; num10 < roof3.Area.Count; num10++)
				{
					Vector2 p6 = roof3.Area[num10];
					Vector2 p7 = roof3.Area[(num10 + 1) % roof3.Area.Count];
					for (int num11 = 0; num11 < list.Count; num11++)
					{
						Vector2 q = list[num11];
						Vector2 q2 = list[(num11 + 1) % list.Count];
						if (Utilities.LinesIntersect(p6, p7, q, q2, true, false))
						{
							return Intersection.Roof;
						}
					}
				}
			}
		}
		return Intersection.None;
	}

	private static bool IntersectionCheckInside<T>(List<Vector2> poly, IList<T> against, Func<T, Vector2> convert, bool[] cba, List<bool> oba)
	{
		for (int i = 0; i < cba.Length; i++)
		{
			cba[i] = false;
		}
		for (int j = 0; j < against.Count; j++)
		{
			oba.InsertResize(j, false);
		}
		bool flag = false;
		for (int k = 0; k < against.Count; k++)
		{
			Vector2 vector = convert(against[k]);
			if (Utilities.IsInside(vector, poly))
			{
				bool flag2 = false;
				for (int l = 0; l < poly.Count; l++)
				{
					if (poly[l] == vector)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			for (int m = 0; m < cba.Length; m++)
			{
				if (!cba[m] && !oba[k])
				{
					int index = k;
					bool flag3;
					cba[m] = (flag3 = vector.x.Appx(poly[m].x, 0.015f) && vector.y.Appx(poly[m].y, 0.015f));
					if (oba[index] = flag3)
					{
						flag = true;
						break;
					}
				}
			}
		}
		for (int n = 0; n < cba.Length; n++)
		{
			if (cba[n])
			{
				continue;
			}
			for (int num = 0; num < against.Count; num++)
			{
				Vector2 res;
				if (Utilities.ProjectToLine(poly[n], convert(against[num]), convert(against[(num + 1) % against.Count]), out res) && (res - poly[n]).sqrMagnitude < 0.000225f)
				{
					cba[n] = true;
					flag = true;
					break;
				}
			}
		}
		bool flag5 = true;
		for (int num2 = 0; num2 < cba.Length; num2++)
		{
			if (!cba[num2])
			{
				flag5 = false;
				break;
			}
		}
		if (!flag5 && flag)
		{
			flag5 = true;
			for (int num3 = 0; num3 < against.Count; num3++)
			{
				if (oba[num3])
				{
					continue;
				}
				for (int num4 = 0; num4 < cba.Length; num4++)
				{
					Vector2 vector2 = convert(against[num3]);
					Vector2 res2;
					if (Utilities.ProjectToLine(vector2, poly[num4], poly[(num4 + 1) % poly.Count], out res2) && (res2 - vector2).sqrMagnitude < 0.000225f)
					{
						oba[num3] = true;
						break;
					}
				}
				if (!oba[num3])
				{
					flag5 = false;
					break;
				}
			}
			if (flag5)
			{
				Vector2[] array = against.SelectInPlace(convert);
				int[] array2 = new Triangulator(array).Triangulate();
				flag5 = false;
				for (int num5 = 0; num5 < array2.Length; num5 += 3)
				{
					if (Utilities.IsInside(Utilities.GetTriangleCentroid(array[array2[num5]], array[array2[num5 + 1]], array[array2[num5 + 2]]), poly))
					{
						flag5 = true;
						break;
					}
				}
			}
		}
		return flag5;
	}

	private void OnDisable()
	{
		if (CostDisplay.Instance != null)
		{
			CostDisplay.Instance.Hide();
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		SelectorController.CanClick = false;
		if (GameSettings.FreezeGame)
		{
			CostDisplay.Instance.Hide();
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			HUD.Instance.ShortcutPanel.Hide();
			WindowManager.SetCursorOverride(null);
			base.gameObject.SetActive(false);
			MaterialPreviewer.Instance.RefreshState();
			return;
		}
		if (InputController.GetKeyUp(InputController.Keys.FurnitureClock))
		{
			base.transform.rotation *= Quaternion.Euler(0f, BuildController.Instance.FurnitureAngle, 0f);
			UISoundFX.PlaySFX("FurnRotate", true);
		}
		if (InputController.GetKeyUp(InputController.Keys.FurnitureAntiClock))
		{
			base.transform.rotation *= Quaternion.Euler(0f, 0f - BuildController.Instance.FurnitureAngle, 0f);
			UISoundFX.PlaySFX("FurnRotate", true);
		}
		if (InputController.GetKeyUp(InputController.Keys.MirrorRoomHor))
		{
			MirrorX = !MirrorX;
			base.transform.localScale = new Vector3((!MirrorX) ? 1 : (-1), 1f, (!MirrorY) ? 1 : (-1));
			UISoundFX.PlaySFX("FurnRotate", true);
		}
		if (InputController.GetKeyUp(InputController.Keys.MirrorRoomVert))
		{
			MirrorY = !MirrorY;
			base.transform.localScale = new Vector3((!MirrorX) ? 1 : (-1), 1f, (!MirrorY) ? 1 : (-1));
			UISoundFX.PlaySFX("FurnRotate", true);
		}
		int minAbove = Prefab.Rooms.GetMinAbove(-1, (BuildingPrefab.RoomObject x) => x.Floor);
		bool flag = GameSettings.Instance.ActiveFloor == minAbove && BasementBounds != null;
		BasementRend.gameObject.SetActive(flag);
		float num = (flag ? PreCostBase : PreCost);
		for (int num2 = 0; num2 < Prefab.Rooms.Length; num2++)
		{
			BuildingPrefab.RoomObject roomObject = Prefab.Rooms[num2];
			if (flag || roomObject.Floor >= 0)
			{
				BuildingPrefab.RoomObject.AtriumType atriumType = roomObject.GetAtriumType(num2, Prefab.Rooms);
				int floor = roomObject.Floor - minAbove + GameSettings.Instance.ActiveFloor;
				num += BuildController.GetRoomCost(roomObject.Edges.Select((int x) => Prefab.Edges[x].ToVector2()).ToList(), roomObject.Area, roomObject.Outdoor || atriumType == BuildingPrefab.RoomObject.AtriumType.Balcony, roomObject.Pillar, floor, false, false, atriumType == BuildingPrefab.RoomObject.AtriumType.Upper);
			}
		}
		Vector2 vector = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * GameSettings.Instance.ActiveFloor * 2f));
		if (!BuildController.NoGrid())
		{
			vector = BuildController.Instance.CorrectMousePos(vector);
			if (vector != LastPos)
			{
				UISoundFX.PlaySFX("Tick", true);
			}
		}
		LastPos = vector;
		base.transform.position = new Vector3(vector.x, GameSettings.Instance.ActiveFloor * 2, vector.y);
		CostDisplay.Instance.Show(num, new Vector3(vector.x, GameSettings.Instance.ActiveFloor * 2 + 1, vector.y));
		bool flag2 = GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num);
		bool flag3 = flag2;
		if (flag3 && GameSettings.Instance.ActiveFloor < 0 && _outdoorAreaOnFirst)
		{
			ErrorOverlay.Instance.ShowError("OutdoorBasementError");
			flag3 = false;
		}
		if (Prefab.Rooms.Length > 1 && flag3)
		{
			if (flag)
			{
				for (int num3 = 0; num3 < BasementBounds.Length; num3++)
				{
					flag3 = Valid(-1, num3);
					if (!flag3)
					{
						break;
					}
				}
			}
			if (flag3)
			{
				for (int num4 = 0; num4 < Bounds.Length; num4++)
				{
					for (int num5 = 0; num5 < Bounds[num4].Length; num5++)
					{
						flag3 = Valid(num4, num5);
						if (!flag3)
						{
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
				}
			}
		}
		else if (flag3)
		{
			for (int num6 = 0; num6 < Bounds.Length; num6++)
			{
				for (int num7 = 0; num7 < Bounds[num6].Length; num7++)
				{
					flag3 = Valid(num6, num7, false);
					if (!flag3)
					{
						break;
					}
				}
				if (!flag3)
				{
					break;
				}
			}
		}
		rend.sharedMaterial = (flag3 ? ValidMat : InvalidMat);
		BasementRender.sharedMaterial = (flag3 ? ValidMat2 : InvalidMat);
		if (flag3)
		{
			ErrorOverlay.Instance.Clear();
		}
		if (!Input.GetMouseButtonUp(0) || GUICheck.OverGUI)
		{
			return;
		}
		if (flag3)
		{
			if (BuildPrefab(Prefab, GameSettings.Instance.ActiveFloor - minAbove, flag, true, true, true).Count > 0)
			{
				UISoundFX.PlaySFX("PlaceRoom", true);
				UISoundFX.PlaySFX("Kaching");
				if (!BuildController.PlaceMulti())
				{
					HUD.Instance.ShortcutPanel.Hide();
					WindowManager.SetCursorOverride(null);
					base.gameObject.SetActive(false);
					MaterialPreviewer.Instance.RefreshState();
				}
			}
		}
		else
		{
			if (!flag2)
			{
				HUD.FlashMoney();
			}
			UISoundFX.PlaySFX("BuildError");
		}
	}

	private bool SitsOn(List<WallEdge> a, List<WallEdge> b)
	{
		for (int i = 0; i < a.Count; i++)
		{
			WallEdge wallEdge = a[i];
			bool flag = false;
			for (int j = 0; j < b.Count; j++)
			{
				WallEdge wallEdge2 = b[j];
				if (wallEdge == wallEdge2)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			for (int k = 0; k < b.Count; k++)
			{
				WallEdge wallEdge3 = b[k];
				WallEdge wallEdge4 = b[(k + 1) % b.Count];
				Vector2 res;
				if (Utilities.ProjectToLine(wallEdge.Pos, wallEdge3.Pos, wallEdge4.Pos, out res) && (res - wallEdge.Pos).magnitude < BuildController.GetSnapDistance())
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	public List<KeyValuePair<Room, BuildingPrefab.RoomObject>> BuildPrefab(BuildingPrefab prefab, int floorOffset, bool withBasement, bool cost, bool correctPos, bool undo, uint[] ids = null, bool supportCheck = true, bool ignoreValidChecks = false, bool preciseEdgeOptimization = false)
	{
		List<UndoObject.UndoAction> list = (undo ? new List<UndoObject.UndoAction>() : null);
		List<UndoObject.UndoAction> list2 = (undo ? new List<UndoObject.UndoAction>() : null);
		float num = 0f;
		float num2 = 0f;
		List<KeyValuePair<Room, BuildingPrefab.RoomObject>> list3 = new List<KeyValuePair<Room, BuildingPrefab.RoomObject>>();
		List<Room> list4 = (undo ? new List<Room>() : null);
		Room[] actualRooms = new Room[prefab.Rooms.Length];
		List<KeyValuePair<int, BuildingPrefab.RoomObject>> list5 = (from x in prefab.Rooms.Select((BuildingPrefab.RoomObject x, int i) => new KeyValuePair<int, BuildingPrefab.RoomObject>(i, x))
			orderby x.Value.Floor
			select x).ToList();
		List<Vector2> list6 = new List<Vector2>();
		Dictionary<int, WallEdge> dictionary = new Dictionary<int, WallEdge>();
		HashSet<WallEdge> hashSet = new HashSet<WallEdge>();
		HashSet<Room> hashSet2 = new HashSet<Room>();
		Dictionary<string, RoomGroup> dictionary2 = null;
		if (_groupOption == GroupOption.Copy)
		{
			dictionary2 = new Dictionary<string, RoomGroup>();
			HashSet<string> hashSet3 = GameSettings.Instance.GetRoomGroups(true).ToHashSet();
			foreach (string item2 in prefab.Rooms.SelectNotNull((BuildingPrefab.RoomObject x) => x.Group).Distinct().ToList())
			{
				if (hashSet3.Contains(item2))
				{
					bool flag = _createGroups;
					if (!_createGroups)
					{
						RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(item2);
						if (roomGroup.SaveMe)
						{
							dictionary2[item2] = roomGroup;
						}
						else
						{
							flag = true;
						}
					}
					if (flag)
					{
						int num3 = 2;
						string item = item2 + " " + num3;
						while (hashSet3.Contains(item))
						{
							num3++;
							item = item2 + " " + num3;
						}
						dictionary2[item2] = GameSettings.Instance.AddRoomGroup(item);
					}
				}
				else
				{
					dictionary2[item2] = GameSettings.Instance.AddRoomGroup(item2);
				}
			}
		}
		for (int num4 = 0; num4 < list5.Count; num4++)
		{
			BuildingPrefab.RoomObject room = list5[num4].Value;
			if (room.Atrium >= 0 && room.Atrium != list5[num4].Key)
			{
				BuildingPrefab.RoomObject p = prefab.Rooms[room.Atrium];
				if (list3.None((KeyValuePair<Room, BuildingPrefab.RoomObject> x) => x.Value == p))
				{
					continue;
				}
			}
			if (!withBasement && room.Floor < 0)
			{
				continue;
			}
			int num5 = room.Floor + floorOffset;
			List<WallEdge> list7 = new List<WallEdge>();
			bool flag2 = true;
			for (int num6 = 0; num6 < room.Edges.Length && (num6 != room.Edges.Length - 1 || room.Edges[0] != room.Edges[num6]); num6++)
			{
				Vector2 vector = (correctPos ? CorrectPos(prefab.Edges[room.Edges[num6]]) : prefab.Edges[room.Edges[num6]].ToVector2());
				WallEdge wallEdge = null;
				foreach (WallEdge item3 in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(num5))
				{
					if ((item3.Pos - vector).magnitude < BuildController.GetSnapDistance(preciseEdgeOptimization))
					{
						wallEdge = item3;
						break;
					}
				}
				if (list7.Count > 0 && wallEdge == list7[list7.Count - 1])
				{
					flag2 = false;
					break;
				}
				if (wallEdge == null)
				{
					foreach (WallEdge item4 in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(num5))
					{
						foreach (KeyValuePair<IRoom, WallEdge> link in item4.Links)
						{
							Vector2 res;
							if (Utilities.ProjectToLine(vector, item4.Pos, link.Value.Pos, out res) && (res - vector).magnitude < BuildController.GetSnapDistance(preciseEdgeOptimization))
							{
								wallEdge = new WallEdge(res, num5);
								wallEdge.SetSplit(item4, (Room)link.Key);
								break;
							}
						}
						if (wallEdge != null)
						{
							break;
						}
					}
				}
				if (wallEdge == null)
				{
					wallEdge = new WallEdge(vector, num5);
				}
				dictionary[room.Edges[num6]] = wallEdge;
				list7.Add(wallEdge);
			}
			if (flag2)
			{
				hashSet.Clear();
				hashSet.AddRange(list7);
				if (hashSet.Count != list7.Count)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				list6.Clear();
				for (int num7 = 0; num7 < list7.Count; num7++)
				{
					list6.Add(list7[num7].Pos);
				}
			}
			if (!ignoreValidChecks && Utilities.PolygonArea(list6) < 1f)
			{
				flag2 = false;
			}
			if (!ignoreValidChecks && flag2)
			{
				for (int num8 = 0; num8 < list6.Count; num8++)
				{
					Vector2 a = list6[num8];
					Vector2 b = list6[(num8 + 1) % list6.Count];
					Vector2 c = list6[(num8 + 2) % list6.Count];
					if (b.AngleBetween(a, c) < BuildController.Instance.MinAngle)
					{
						flag2 = false;
						break;
					}
				}
			}
			if (!ignoreValidChecks && flag2)
			{
				for (int num9 = 0; num9 < list6.Count; num9++)
				{
					Vector2 p2 = list6[num9];
					Vector2 p3 = list6[(num9 + 1) % list6.Count];
					for (int num10 = num9 + 1; num10 < list6.Count; num10++)
					{
						Vector2 q = list6[num10];
						Vector2 q2 = list6[(num10 + 1) % list6.Count];
						if (Utilities.LinesIntersect(p2, p3, q, q2, false, false))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
				}
			}
			Room r = null;
			float num11 = 0f;
			bool flag3 = true;
			if (list5.Count == 1)
			{
				Vector2 polygonCentroid = Utilities.GetPolygonCentroid(list7);
				Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(num5, polygonCentroid);
				if (roomFromPoint != null && !roomFromPoint.Outside && !roomFromPoint.Pillar && roomFromPoint.AtriumParent == null && roomFromPoint.Outdoors == room.Outdoor && SitsOn(roomFromPoint.Edges, list7) && SitsOn(list7, roomFromPoint.Edges))
				{
					r = roomFromPoint;
					List<Room> rooms = new List<Room> { r };
					if (undo)
					{
						list.Add(new UndoObject.UndoAction(rooms, true));
						list.Add(new UndoObject.UndoAction(rooms, false));
					}
					flag3 = false;
				}
				if (r == null)
				{
					Room r2;
					List<WallEdge> list8 = BuildController.Instance.CheckSplit(list7, num5, out r2);
					if (list8 != null && r2 != null && !r2.Pillar && r2.AtriumParent == null && r2.Outdoors == room.Outdoor)
					{
						r = BuildController.Instance.MakeSplit(list8, r2, polygonCentroid, list, 0f, false);
						if (r != null)
						{
							num11 = BuildController.GetRoomCost(list8.Select((WallEdge x) => x.Pos).ToList(), r2.Outdoors, false, r2.Floor, true, false, false);
							flag3 = false;
						}
					}
				}
			}
			if (r == null)
			{
				if (!flag2 || (supportCheck && !GameSettings.Instance.sRoomManager.IsSupported(list7.Select((WallEdge x) => x.Pos), num5, null)))
				{
					list5.RemoveAt(num4);
					num4--;
					continue;
				}
				if (undo && list5.Count == 1 && !Valid(0, 0))
				{
					UISoundFX.PlaySFX("BuildError");
					return new List<KeyValuePair<Room, BuildingPrefab.RoomObject>>();
				}
				BuildController.Instance.CurrentSegments = list7;
				BuildController.Instance.FinalizeCuts(false, num5, list, preciseEdgeOptimization);
				BuildController.Instance.CurrentSegments = null;
				GameSettings.Instance.sRoomManager.AllSegments.AddRange(list7);
				BuildController instance = BuildController.Instance;
				bool outdoor = room.Outdoor;
				bool pillar = room.Pillar;
				WriteDictionary roomData = room.RoomData;
				r = instance.MakeRoom(list7, num5, list2, true, false, false, outdoor, pillar, (roomData != null) ? roomData.Get("NetworkID", 0u) : 0u);
				hashSet2.AddRange(r.GetTouchingRooms());
				if (room.Atrium >= 0)
				{
					if (room.Atrium == list5[num4].Key)
					{
						r.AtriumParent = r;
					}
					else
					{
						r.AtriumParent = list3.First((KeyValuePair<Room, BuildingPrefab.RoomObject> x) => x.Value == prefab.Rooms[room.Atrium]).Key;
						r.AtriumParent.AtriumChildren.Add(r);
						r.AtriumParent.UpdateAtriumNetwork();
						r.AtriumParent.RefreshTextureTiling();
					}
				}
				if (undo)
				{
					list4.Add(r);
				}
			}
			if (_groupOption == GroupOption.Replace && _groupReplacement != null)
			{
				_groupReplacement.AddRoom(r);
			}
			r.Rentable = room.Rentable;
			if (ids != null)
			{
				r.DID = ids[num4];
				Writeable.DeserializedObjects[r.DID] = r;
			}
			list3.Add(new KeyValuePair<Room, BuildingPrefab.RoomObject>(r, room));
			actualRooms[list5[num4].Key] = r;
			GameSettings.Instance.sRoomManager.AddRoom(r);
			GameSettings.Instance.sRoomManager.UpdateSupport(r);
			if (cost)
			{
				if (flag3)
				{
					num11 = BuildController.GetRoomCost(r.Edges.Select((WallEdge x) => x.Pos).ToList(), r.Area, r.Outdoors || r.IsBalcony, r.Pillar, r.Floor, false, false, r.IsUpperAtriumNotBalcony);
				}
				num += num11;
				num2 += num11;
				GameSettings.Instance.MyCompany.MakeTransaction(0f - num11, Company.TransactionCategory.Construction, true, "Room");
			}
			if (room.RoomData != null)
			{
				r.DeserializeThis(room.RoomData, false);
				RoomGroup roomGroup2 = GameSettings.Instance.GetRoomGroup(r.RoomGroup);
				if (roomGroup2 != null)
				{
					roomGroup2.AddRoom(r);
				}
			}
			else
			{
				if (r.SetFenceStyle(room.Materials[3], null))
				{
					if (RoomMaterialController.AllowSecondaryRecolor(room.Materials[2]))
					{
						r.FloorColor2 = room.EColor1 ?? room.Colors[2].GetDefaultSecondaryColor();
					}
					if (r.IsBalcony)
					{
						if (RoomMaterialController.AllowSecondaryRecolor(room.Materials[1]))
						{
							r.OutsideColor2 = r.AtriumParent.OutsideColor2;
						}
						if (RoomMaterialController.AllowSecondaryRecolor(room.Materials[0]))
						{
							r.InsideColor2 = r.AtriumParent.InsideColor2;
						}
					}
				}
				else
				{
					if (RoomMaterialController.AllowSecondaryRecolor(room.Materials[0]))
					{
						r.InsideColor2 = room.EColor1 ?? room.Colors[0].GetDefaultSecondaryColor();
					}
					if (RoomMaterialController.AllowSecondaryRecolor(room.Materials[1]))
					{
						r.OutsideColor2 = room.EColor2 ?? room.Colors[1].GetDefaultSecondaryColor();
					}
					if (RoomMaterialController.AllowSecondaryRecolor(room.Materials[2]))
					{
						r.FloorColor2 = room.EColor3 ?? room.Colors[2].GetDefaultSecondaryColor();
					}
				}
				r.FloorMat = room.Materials[2];
				r.FloorColor = room.Colors[2];
				r.InsideMat = room.Materials[0];
				r.InsideColor = room.Colors[0];
				r.OutsideMat = room.Materials[1];
				if (r.IsBalcony)
				{
					r.FenceColor = room.Colors[1];
					r.OutsideColor = r.AtriumParent.OutsideColor;
				}
				else
				{
					Room room2 = r;
					Color fenceColor = (r.OutsideColor = room.Colors[1]);
					room2.FenceColor = fenceColor;
				}
				r.FloorOffset = new SVector3(room.Offset.x.Clamp(), room.Offset.y.Clamp(), 0f);
				r.FloorRotation = room.Offset.z.Clamp(0f, 360f);
				r.FloorScale = room.Offset.w.Clamp(0.5f, 1.5f);
			}
			list7.RemoveAll((WallEdge x) => !r.Edges.Contains(x));
			for (int num12 = 0; num12 < room.Segments.Length; num12++)
			{
				BuildingPrefab.SegmentObject segmentObject = room.Segments[num12];
				RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(segmentObject.Name);
				if (!(segmentComponent != null))
				{
					continue;
				}
				Vector2 vector2 = (correctPos ? CorrectPos(new Vector2(segmentObject.Position.x, segmentObject.Position.z)) : new Vector2(segmentObject.Position.x, segmentObject.Position.z));
				for (int num13 = 0; num13 < list7.Count; num13++)
				{
					WallEdge wallEdge2 = list7[num13];
					WallEdge wallEdge3 = list7[num13].Links[r];
					Vector2 pos = Vector2.zero;
					Vector2 res2;
					bool num14 = Utilities.ProjectToLine(vector2, wallEdge2.Pos, wallEdge3.Pos, out res2);
					if (num14)
					{
						pos = res2;
					}
					float height = 0f;
					if (!num14 || !((vector2 - res2).magnitude < 0.1f) || !wallEdge2.ValidSegment(ref pos, ref height, segmentObject.Width, wallEdge3, false, segmentComponent.IsConnecter, false, false, !segmentComponent.InsideSegment, segmentComponent.Height1, segmentComponent.Height2, true) || !(pos == res2))
					{
						continue;
					}
					if (segmentObject.Reversed ^ (MirrorX ^ MirrorY))
					{
						WallEdge wallEdge4 = wallEdge2;
						wallEdge2 = wallEdge3;
						wallEdge3 = wallEdge4;
					}
					float num15 = segmentObject.Width / 2f;
					float num16 = res2.Dist(wallEdge2.Pos);
					float num17 = res2.Dist(wallEdge3.Pos);
					if ((num16.Appx(num15) || num16 >= num15) && (num17.Appx(num15) || num17 >= num15))
					{
						GameObject obj = UnityEngine.Object.Instantiate(segmentComponent.gameObject);
						obj.name = segmentComponent.name;
						RoomSegment component = obj.GetComponent<RoomSegment>();
						if (segmentComponent.DynamicWidth)
						{
							component.FixDynamicWidth(segmentObject.Width);
						}
						component.Floor = num5;
						component.transform.position = new Vector3(component.transform.position.x, num5 * 2, component.transform.position.z);
						component.Init(wallEdge2, wallEdge3, (wallEdge2.Pos - res2).magnitude / (wallEdge2.Pos - wallEdge3.Pos).magnitude, true);
						if (segmentObject.Colors != null)
						{
							component.ColorPrimary = (component.ColorPrimaryEnabled ? segmentObject.Colors[0].ToColor() : component.ColorPrimaryDefault);
							component.ColorSecondary = (component.ColorSecondaryEnabled ? segmentObject.Colors[1].ToColor() : component.ColorSecondaryDefault);
							component.ColorTertiary = (component.ColorTertiaryEnabled ? segmentObject.Colors[2].ToColor() : component.ColorTertiaryDefault);
							component.AtlasIndex = segmentObject.AtlasIndex;
							component.DisableInitColor = true;
						}
						if (cost)
						{
							float num18 = segmentComponent.Cost / segmentComponent.WallWidth * segmentObject.Width;
							num += num18;
							GameSettings.Instance.MyCompany.MakeTransaction(0f - num18, Company.TransactionCategory.Construction, true, "Segment");
						}
						if (undo)
						{
							list.Add(new UndoObject.UndoAction(component, true));
						}
						break;
					}
				}
			}
		}
		if (dictionary2 != null)
		{
			for (int num19 = 0; num19 < list3.Count; num19++)
			{
				KeyValuePair<Room, BuildingPrefab.RoomObject> keyValuePair = list3[num19];
				RoomGroup value;
				if (keyValuePair.Value.Group != null && dictionary2.TryGetValue(keyValuePair.Value.Group, out value))
				{
					value.AddRoom(keyValuePair.Key);
				}
			}
		}
		foreach (KeyValuePair<int, int[]> item5 in prefab.Smoothing)
		{
			WallEdge orDefault = dictionary.GetOrDefault(item5.Key);
			if (orDefault == null)
			{
				continue;
			}
			for (int num20 = 0; num20 < item5.Value.Length; num20++)
			{
				WallEdge orDefault2 = dictionary.GetOrDefault(item5.Value[num20]);
				if (orDefault2 != null)
				{
					orDefault.Smooth.Add(orDefault2);
				}
			}
		}
		Dictionary<int, Server> dictionary3 = new Dictionary<int, Server>();
		for (int num21 = 0; num21 < list3.Count; num21++)
		{
			BuildingPrefab.RoomObject value2 = list3[num21].Value;
			Room key = list3[num21].Key;
			int floor = key.Floor;
			List<WallEdge> edges = key.Edges;
			Dictionary<uint, Furniture> dictionary4 = new Dictionary<uint, Furniture>();
			BuildingPrefab.FurnitureObject[] furniture = value2.Furniture;
			foreach (BuildingPrefab.FurnitureObject furniture2 in furniture)
			{
				Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(GetFurniture(furniture2.Name));
				if (furnitureComponent == null || !furnitureComponent.IsPurchasable() || !furnitureComponent.IsUnlocked() || (floor < 0 && !furnitureComponent.BasementValid) || (!_furnished && !furnitureComponent.IsConstructionFurniture()))
				{
					continue;
				}
				Vector2 vector3 = (correctPos ? CorrectPos(new Vector2(furniture2.Position.x, furniture2.Position.z)) : new Vector2(furniture2.Position.x, furniture2.Position.z));
				float height2 = furniture2.Position.y.GetFloorOffset(value2.Floor);
				if (furnitureComponent.CustomHeight && height2 == 0f)
				{
					height2 = furnitureComponent.WallHeight;
				}
				Vector3 vector4 = new Vector3(vector3.x, (float)(floor * 2) + height2, vector3.y);
				SnapPoint snapPoint = null;
				bool flag4 = furnitureComponent.IsSnapping && (!furnitureComponent.CanNotSnap || furniture2.Parent != 0);
				if (flag4)
				{
					Furniture value3;
					if (!dictionary4.TryGetValue(furniture2.Parent, out value3))
					{
						continue;
					}
					snapPoint = value3.SnapPoints.FirstOrDefault((SnapPoint x) => x.Id == furniture2.SnapID);
					if (snapPoint == null)
					{
						continue;
					}
					vector4 = snapPoint.FixPosition(furniture2.SnapPointOffset);
				}
				WallEdge wallEdge5 = null;
				WallEdge edge = null;
				float wallPos = 0f;
				if (furnitureComponent.WallFurn)
				{
					for (int num23 = 0; num23 < edges.Count; num23++)
					{
						WallEdge wallEdge6 = edges[num23];
						WallEdge wallEdge7 = edges[(num23 + 1) % edges.Count];
						Vector2 res3;
						bool num24 = Utilities.ProjectToLine(vector3, wallEdge6.Pos, wallEdge7.Pos, out res3);
						Vector2 pos2 = Vector2.zero;
						if (num24)
						{
							pos2 = res3;
						}
						if (num24 && (vector3 - res3).magnitude < 0.1f && wallEdge6.ValidSegment(ref pos2, ref height2, furnitureComponent.WallWidth, wallEdge7, !furnitureComponent.PokesThroughWall, furnitureComponent.IsConnecter, furniture2.IsReversed ^ furnitureComponent.ReverseWallSide, true, furnitureComponent.ValidOnFence, furnitureComponent.Height1, furnitureComponent.Height2, false, 0f, 0f, false, null, false, 0f, 0f, false))
						{
							wallEdge5 = wallEdge6;
							edge = wallEdge7;
							wallPos = (wallEdge6.Pos - res3).magnitude / (wallEdge6.Pos - wallEdge7.Pos).magnitude;
							break;
						}
					}
					if (wallEdge5 == null)
					{
						continue;
					}
				}
				Quaternion identity = Quaternion.identity;
				if (flag4)
				{
					identity = Quaternion.Euler(0f, furniture2.RotationOffset, 0f) * snapPoint.transform.rotation;
				}
				else
				{
					Vector3 vector5 = furniture2.Rotation.ToQuaternion() * Vector3.forward;
					vector5 = base.transform.rotation * new Vector3(MirrorX ? (0f - vector5.x) : vector5.x, 0f, MirrorY ? (0f - vector5.z) : vector5.z);
					if ((MirrorX ^ MirrorY) && furnitureComponent.MirrorRotationOffset != 0f)
					{
						vector5 = Quaternion.Euler(0f, furnitureComponent.MirrorRotationOffset, 0f) * vector5;
					}
					identity = Quaternion.LookRotation(vector5);
				}
				Matrix4x4 matrix = Matrix4x4.TRS(vector4, identity, Vector3.one);
				Vector2[] ps = ((furnitureComponent.BuildBoundary == null) ? Array.Empty<Vector2>() : furnitureComponent.BuildBoundary.SelectInPlace((Vector2 x) => matrix.MultiplyPoint(x.ToVector3(0f)).FlattenVector3()));
				if (!CheckRoad(ps, key.Floor, furnitureComponent.PokesThroughRoof) || !FurnitureBuilder.IsValid(furnitureComponent, vector4, ps, height2 + furnitureComponent.Height1, height2 + furnitureComponent.Height2, key, false, (!flag4) ? Array.Empty<Furniture>() : new Furniture[1] { snapPoint.Parent }) || (furnitureComponent.TwoFloors && !FurnitureBuilder.IsValid(furnitureComponent, vector4, ps, height2 + furnitureComponent.Height1, height2 + furnitureComponent.Height2, FurnitureBuilder.GetBestRoom(floor + 1, vector4.FlattenVector3(), furnitureComponent, matrix), false)) || (furnitureComponent.PokesThroughRoof && !FurnitureBuilder.IsValid(furnitureComponent, vector4, ps, height2 + furnitureComponent.Height1, height2 + furnitureComponent.Height2, FurnitureBuilder.GetBestRoom(floor + 1, vector4.FlattenVector3(), furnitureComponent, matrix), true)))
				{
					continue;
				}
				bool inventory;
				Furniture furniture3 = FurnitureBuilder.MakeFurn(vector4, identity, key, wallEdge5, edge, wallPos, furniture2.IsReversed, snapPoint, furnitureComponent.gameObject, furniture2.RotationOffset, true, out inventory, !cost);
				if (cost && !inventory)
				{
					num += furnitureComponent.GetCost();
				}
				if (undo)
				{
					list.Add(new UndoObject.UndoAction(furniture3, true, inventory));
				}
				FurnitureBuilder.CopyStyle(furniture2, furniture3);
				furniture3.BoostValue = furniture2.BoostValue;
				dictionary4[furniture2.ID] = furniture3;
				if (furniture2.ServerID <= 0)
				{
					continue;
				}
				Server component2 = furniture3.GetComponent<Server>();
				if (component2 != null)
				{
					component2.PreWired = true;
					Server value4;
					if (dictionary3.TryGetValue(furniture2.ServerID, out value4))
					{
						component2.WireTo(value4);
						continue;
					}
					component2.ServerName = GameSettings.Instance.GenerateServerName();
					GameSettings.CalculateServerPowerNow.Add(component2.ServerName);
					dictionary3[furniture2.ServerID] = component2;
				}
			}
		}
		if (dictionary3.Count > 0)
		{
			CameraScript.Instance.WireRender.ForceDirty = true;
			HUD.Instance.serverWindow.UpdateServerList();
			EventHandler onServersChanged = GameSettings.Instance.OnServersChanged;
			if (onServersChanged != null)
			{
				onServersChanged(GameSettings.Instance, null);
			}
		}
		list3.ForEach(delegate(KeyValuePair<Room, BuildingPrefab.RoomObject> x)
		{
			x.Key.OptimizeSegments();
			x.Key.RefreshNoise();
		});
		foreach (List<Room> item6 in (from x in list3
			group x by x.Value.RoomGroupID).ToDictionary((IGrouping<uint, KeyValuePair<Room, BuildingPrefab.RoomObject>> x) => x.Key, (IGrouping<uint, KeyValuePair<Room, BuildingPrefab.RoomObject>> x) => x.Select((KeyValuePair<Room, BuildingPrefab.RoomObject> y) => y.Key).ToList()).Values.Where((List<Room> x) => x.Count > 1))
		{
			Room room3 = item6[0];
			for (int num25 = 1; num25 < item6.Count; num25++)
			{
				item6[num25].ParentRoom = room3;
				room3.ChildrenRooms.Add(item6[num25]);
			}
		}
		List<Roof> list9 = new List<Roof>();
		if (prefab.Roofs != null)
		{
			for (int num26 = 0; num26 < prefab.Roofs.Length; num26++)
			{
				BuildingPrefab.RoofObject roofObject = prefab.Roofs[num26];
				bool flag5 = true;
				for (int num27 = 0; num27 < roofObject.RoofOf.Length; num27++)
				{
					Room room4 = actualRooms[roofObject.RoofOf[num27]];
					if (room4 == null || room4.Floor < 0)
					{
						flag5 = false;
						break;
					}
				}
				if (!flag5)
				{
					continue;
				}
				Roof roof = UnityEngine.Object.Instantiate(HUD.Instance.roofEditWindow.RoofPrefab);
				roof.Height = roofObject.Height;
				roof.Bulge = roofObject.Slope;
				List<Vector2> list10 = roofObject.Area.Select((SVector3 x) => (!correctPos) ? x.ToVector2() : CorrectPos(x)).ToList();
				if (Utilities.Clockwise(list10))
				{
					list10.Reverse();
				}
				roof.Init(((IList<int>)roofObject.RoofOf).Select((Func<int, IRoom>)((int x) => actualRooms[x])).ToList(), list10, roofObject.Floor);
				roof.InitWritable();
				roof.RoofColor = roofObject.RoofColor;
				roof.GableColor = roofObject.GableColor;
				if (RoomMaterialController.AllowSecondaryRecolor(roofObject.RoofMaterial))
				{
					roof.RoofColor2 = roofObject.RoofColor2 ?? roofObject.RoofColor.GetDefaultSecondaryColor();
				}
				if (RoomMaterialController.AllowSecondaryRecolor(roofObject.GableMaterial))
				{
					roof.GableColor2 = roofObject.GableColor2 ?? roofObject.GableColor.GetDefaultSecondaryColor();
				}
				roof.RoofMaterial = roofObject.RoofMaterial;
				roof.GableMaterial = roofObject.GableMaterial;
				Roof.RoofPoint[] ps2 = roofObject.RoofPoints.SelectInPlace((SVector3 x) => new Roof.RoofPoint(correctPos ? CorrectPos(x) : x.ToVector2()));
				roof.RoofLine = roofObject.RoofEdges.ZipList((int x, int y) => new Roof.RoofEdge(ps2[x], ps2[y]));
				if (roof.GenerateRoofing())
				{
					list9.Add(roof);
					if (NetworkManager.Instance.Connected)
					{
						NetworkMessaging.SendNewRoom(BuildingPrefab.SaveRoomsForNetwork(Array.Empty<Room>(), new Roof[1] { roof }, false), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}
				}
				else
				{
					roof.DestroyGO();
				}
			}
		}
		if (AddTrashCans)
		{
			Furniture furnitureComponent2 = ObjectDatabase.Instance.GetFurnitureComponent("Trash Can");
			foreach (Room room5 in actualRooms)
			{
				if (!(room5 != null) || room5.GetFurniture("Computer").Count <= 0)
				{
					continue;
				}
				foreach (FurnitureAutoPlacement.PlacementData item7 in FurnitureAutoPlacement.AutoPlacementFunctions["Trashcan"].F(furnitureComponent2, room5, Quaternion.identity))
				{
					bool inventory2;
					FurnitureBuilder.MakeFurn(item7.P, item7.R, room5, null, null, 0f, false, null, furnitureComponent2.gameObject, 0f, false, out inventory2);
					if (!inventory2)
					{
						num += furnitureComponent2.Cost;
					}
				}
			}
		}
		HashSet<Room> hashSet4 = list3.Select((KeyValuePair<Room, BuildingPrefab.RoomObject> x) => x.Key).ToHashSet();
		foreach (Room item8 in hashSet2)
		{
			if (!hashSet4.Contains(item8))
			{
				item8.RefreshEdges(list, false);
			}
		}
		if (cost)
		{
			CostDisplay.Instance.FloatAway(num);
		}
		if (undo)
		{
			list.Add(new UndoObject.UndoAction(list4.ToArray(), num2));
			list.AddRange(list2);
			if (list9.Count > 0)
			{
				list.Add(new UndoObject.UndoAction(true, list9.ToArray()));
			}
			if (list.Count > 0)
			{
				GameSettings.Instance.AddUndo(list.ToArray());
			}
		}
		ErrorOverlay.Instance.Clear();
		return list3;
	}

	private bool CheckRoad(Vector2[] ps, int floor, bool pokeRoof)
	{
		if (floor == -1 && pokeRoof)
		{
			for (int i = 0; i < ps.Length; i++)
			{
				if (RoadManager.Instance.GetRoad(ps[i], 0) > 0)
				{
					return false;
				}
			}
		}
		return true;
	}
}
