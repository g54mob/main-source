using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallDragTool : MonoBehaviour
{
	public static WallDragTool Instance;

	public WallEdge Edge1;

	public WallEdge Edge2;

	public float DistanceLimit;

	public Transform Wall;

	public Transform LeftWall;

	public Transform RightWall;

	public Transform Arrow1;

	public Transform Arrow2;

	private Vector2[] _points = new Vector2[4];

	private float _lastDist;

	public static bool CanChangeFloor()
	{
		if (Instance.gameObject.activeSelf)
		{
			return Instance.Edge1 == null;
		}
		return true;
	}

	public static bool DisableScroll()
	{
		if (Instance.gameObject.activeSelf && Instance.Edge1 != null)
		{
			return Input.GetMouseButton(0);
		}
		return false;
	}

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		if (HUD.Instance != null)
		{
			BuildController.Instance.ClearBuild(false, false, false, false, false, false, false, true);
			SetShortcuts();
			HUD.Instance.UpdateBorderOverlay();
		}
	}

	private void SetShortcuts()
	{
		HUD.Instance.ShortcutPanel.AddShortcut("DragSplitLeft".Loc(), KeyCode.LeftControl, true);
		HUD.Instance.ShortcutPanel.AddShortcut("DragSplitRight".Loc(), KeyCode.LeftShift, true);
		HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
	}

	private void OnDisable()
	{
		if (HUD.Instance != null && !GameSettings.IsQuitting)
		{
			HUD.Instance.UpdateBorderOverlay();
			Edge1 = null;
			Edge2 = null;
			BuildingHUD.Instance.Enable(false, false, false);
			SetWalls();
		}
	}

	private void SetWalls()
	{
		Wall.gameObject.SetActive(false);
		RightWall.gameObject.SetActive(false);
		LeftWall.gameObject.SetActive(false);
		Arrow1.gameObject.SetActive(false);
		Arrow2.gameObject.SetActive(false);
	}

	private void SetWalls(Vector2 a, Vector2 b, Room room)
	{
		float num = ((room != null && room.Outdoors) ? room.FenceHeight : 2f);
		Wall.position = ((a + b) * 0.5f).ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + num / 2f);
		Wall.rotation = (b.ToVector3(0f) - a.ToVector3(0f)).LookDir();
		Wall.localScale = new Vector3(Room.WallOffset + 0.01f, num + 0.1f, (b - a).magnitude);
		Wall.gameObject.SetActive(true);
		Vector2 v = (a - b).normalized.Turn90();
		Vector3 vector = ((a + b) * 0.5f).ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + num / 2f);
		Arrow1.position = vector + v.ToVector3(0f) * 0.5f;
		Arrow2.position = vector - v.ToVector3(0f) * 0.5f;
		v = v.Turn90();
		Arrow1.rotation = v.ToVector3(0f).LookDir();
		Arrow2.rotation = (-v).ToVector3(0f).LookDir();
		Arrow1.gameObject.SetActive(true);
		Arrow2.gameObject.SetActive(true);
		RightWall.gameObject.SetActive(false);
		LeftWall.gameObject.SetActive(false);
	}

	private void SetWalls(Vector2 a, Vector2 b, float w, Room room)
	{
		float num = ((room != null && room.Outdoors) ? room.FenceHeight : 2f);
		Wall.position = b.ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + num / 2f);
		Wall.rotation = (b.ToVector3(0f) - a.ToVector3(0f)).LookDir();
		Wall.localScale = new Vector3(w, num + 0.1f, Room.WallOffset + 0.01f);
		Vector2 vector = (a + b) * 0.5f;
		Vector2 vector2 = (a - b).normalized.Turn90();
		RightWall.position = (vector + vector2 * w * 0.5f).ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + num / 2f);
		LeftWall.position = (vector - vector2 * w * 0.5f).ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + num / 2f);
		Transform rightWall = RightWall;
		Quaternion rotation = (LeftWall.rotation = vector2.ToVector3(0f).LookDir());
		rightWall.rotation = rotation;
		Transform rightWall2 = RightWall;
		Vector3 localScale = (LeftWall.localScale = new Vector3((a - b).magnitude, num + 0.1f, Room.WallOffset + 0.01f));
		rightWall2.localScale = localScale;
		Vector3 vector4 = b.ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + num / 2f);
		Vector2 normalized = (a - b).normalized;
		Arrow1.position = vector4 + normalized.ToVector3(0f) * 0.5f;
		Arrow2.position = vector4 - normalized.ToVector3(0f) * 0.5f;
		normalized = normalized.Turn90();
		Arrow1.rotation = normalized.ToVector3(0f).LookDir();
		Arrow2.rotation = (-normalized).ToVector3(0f).LookDir();
		Wall.gameObject.SetActive(true);
		Arrow1.gameObject.SetActive(true);
		Arrow2.gameObject.SetActive(true);
		RightWall.gameObject.SetActive(true);
		LeftWall.gameObject.SetActive(true);
	}

	private int IsSplitting()
	{
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			return 1;
		}
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			return 2;
		}
		return 0;
	}

	public Vector2[] GetSplitPoints(float split, int splitPref)
	{
		switch (splitPref)
		{
		case 0:
			return new Vector2[2] { Edge1.Pos, Edge2.Pos };
		case 1:
			return new Vector2[2]
			{
				Edge1.Pos,
				Edge1.Pos + (Edge2.Pos - Edge1.Pos).normalized * split
			};
		default:
			return new Vector2[2]
			{
				Edge2.Pos + (Edge1.Pos - Edge2.Pos).normalized * split,
				Edge2.Pos
			};
		}
	}

	private bool GetSplitOptions(Vector2 projectedFixedMouse, out float split, int splitPref)
	{
		split = 0f;
		if (splitPref != 0)
		{
			float magnitude = (Edge1.Pos - Edge2.Pos).magnitude;
			if (magnitude < 2f)
			{
				return false;
			}
			split = Mathf.Clamp((Edge1.Pos - projectedFixedMouse).magnitude, 1f, magnitude - 1f);
			if (splitPref == 2)
			{
				split = magnitude - split;
			}
		}
		return true;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			CostDisplay.Instance.Hide();
			HUD.Instance.ShortcutPanel.Hide();
			WindowManager.SetCursorOverride(null);
			base.gameObject.SetActive(false);
			return;
		}
		base.transform.position = new Vector3(0f, (float)GameSettings.Instance.ActiveFloor * 2f, 0f);
		Vector2 mouseProj = HUD.Instance.GetMouseProj(1f);
		int num = IsSplitting();
		BuildingHUD.Instance.Enable(false, false, false);
		if (Edge1 == null)
		{
			if (GUICheck.OverGUI)
			{
				return;
			}
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor))
			{
				foreach (KeyValuePair<IRoom, WallEdge> link in item.Links)
				{
					Room room = link.Value.GetRoom(item);
					Room room2 = (Room)link.Key;
					Vector2 res;
					if (!item.IsReadonly2(room2, room) && room2.Burn <= 0f && (room == null || room.Burn <= 0f) && (num == 0 || (item.Pos - link.Value.Pos).sqrMagnitude >= 2f) && Utilities.ProjectToLine(mouseProj, item.Pos, link.Value.Pos, out res) && (res - mouseProj).magnitude <= DistanceLimit)
					{
						Edge1 = item;
						Edge2 = link.Value;
						float split;
						GetSplitOptions(Utilities.ProjectToLineEndlessClamped(BuildController.Instance.CorrectMousePos(mouseProj), Edge1.Pos, Edge2.Pos), out split, num);
						Vector2[] splitPoints = GetSplitPoints(split, num);
						SetWalls(splitPoints[0], splitPoints[1], Edge1.GetRoom(Edge2));
						UISoundFX.PlaySFX("HighlightTick", true);
						break;
					}
					if (Edge1 != null)
					{
						break;
					}
				}
				if (Edge1 != null)
				{
					break;
				}
			}
			if (Edge1 != null)
			{
				WindowManager.SetCursorOverride(Utilities.UIDirectionToIcon(Utilities.WorldToUIDirection(Edge1.Pos.ToVector3((float)Edge1.Floor * 2f), Edge2.Pos.ToVector3((float)Edge2.Floor * 2f)) + 90f));
			}
			else
			{
				WindowManager.SetCursorOverride(null);
			}
			return;
		}
		WindowManager.SetCursorOverride(Utilities.UIDirectionToIcon(Utilities.WorldToUIDirection(Edge1.Pos.ToVector3((float)Edge1.Floor * 2f), Edge2.Pos.ToVector3((float)Edge2.Floor * 2f)) + 90f));
		Vector2 vector = Utilities.ProjectToLineEndlessClamped(mouseProj, Edge1.Pos, Edge2.Pos);
		if (!Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0) && (vector - mouseProj).magnitude > DistanceLimit)
		{
			Edge1 = null;
			SetWalls();
			CostDisplay.Instance.Hide();
		}
		if (Edge1 == null)
		{
			return;
		}
		bool flag = Utilities.IsLeft(Edge1.Pos, Edge2.Pos, mouseProj) > 0;
		Vector2 vector2 = BuildController.Instance.CorrectMousePos(mouseProj);
		Vector2 vector3 = Utilities.ProjectToLineEndlessClamped(vector2, Edge1.Pos, Edge2.Pos);
		float split2;
		if (!GetSplitOptions(vector3, out split2, num))
		{
			Edge1 = null;
			SetWalls();
			CostDisplay.Instance.Hide();
			return;
		}
		float num2 = ((Input.GetMouseButton(0) || Input.GetMouseButtonUp(0)) ? (vector3 - vector2).magnitude : 0f);
		if (num2 != _lastDist)
		{
			_lastDist = num2;
			float pitch = 1f + Mathf.Min(num2 / 16f, 1f);
			UISoundFX.PlaySFX("Tick", pitch, 0f, true);
		}
		if (flag)
		{
			num2 *= -1f;
		}
		Room room3 = Edge1.GetRoom(Edge2);
		Room room4 = Edge2.GetRoom(Edge1);
		if (room3 == null)
		{
			Edge1 = null;
			SetWalls();
			CostDisplay.Instance.Hide();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			if (!Mathf.Approximately(num2, 0f))
			{
				GetPoints(num2, split2, num);
				if (CheckAtriumValid(room3, room4))
				{
					Vector2 me1 = Edge1.Pos;
					Vector2 me2 = Edge2.Pos;
					List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
					Rect roomBounds = room3.RoomBounds;
					Rect r = ((room4 != null) ? room4.RoomBounds : new Rect(-1f, -1f, 0f, 0f));
					List<UndoObject.UndoAction> undos;
					Room removedSection;
					if (DoDrag(room3, room4, flag, num2, split2, num, false, out undos, out removedSection))
					{
						if (undos != null)
						{
							list.AddRange(undos);
						}
						bool flag2 = true;
						if (!GameSettings.Instance.sRoomManager.IsSupported(room3.Edges.Select((WallEdge x) => x.Pos), room3.Floor, null) || (room4 != null && !GameSettings.Instance.sRoomManager.IsSupported(room4.Edges.Select((WallEdge x) => x.Pos), room4.Floor, null)) || (removedSection != null && removedSection.AtriumParent == null && AnyNowUnsupported(room3.Floor + 1, removedSection, roomBounds, r)))
						{
							new UndoObject(list.ToArray()).Execute(true);
							ErrorOverlay.Instance.ShowError("UnsupportedStructure", false, true, 4f);
							UISoundFX.PlaySFX("BuildError");
							CostDisplay.Instance.ClearFloaters();
							flag2 = false;
						}
						else if (removedSection == null && room3.AtriumParent == room3)
						{
							for (int num3 = 0; num3 < room3.AtriumChildren.Count; num3++)
							{
								Room room5 = room3.AtriumChildren[num3];
								WallEdge other = room5.Edges.First((WallEdge x) => x.Pos == me1);
								Room room6 = room5.Edges.First((WallEdge x) => x.Pos == me2).GetRoom(other);
								List<UndoObject.UndoAction> undos2;
								Room removedSection2;
								DoDrag(room5, room6, flag, num2, split2, num, true, out undos2, out removedSection2);
								if (undos2 != null)
								{
									list.AddRange(undos2);
								}
							}
						}
						if (flag2 && list.Count > 0)
						{
							GameSettings.Instance.AddUndo(list.ToArray());
						}
					}
				}
			}
			Edge1 = null;
			Edge2 = null;
			SetWalls();
		}
		else
		{
			GetPoints(num2, split2, num);
			if (num2 != 0f)
			{
				BuildingHUD.Instance.Enable(true, false, false);
				float y = (float)GameSettings.Instance.ActiveFloor * 2f;
				BuildingHUD.Instance.SetDimension(((_points[0] + _points[1]) * 0.5f).ToVector3(y), ((_points[2] + _points[3]) * 0.5f).ToVector3(y));
			}
			else
			{
				BuildingHUD.Instance.Enable(false, false, false);
			}
			Vector2[] splitPoints2 = GetSplitPoints(split2, num);
			if (num2 == 0f)
			{
				CostDisplay.Instance.Hide();
				SetWalls(splitPoints2[0], splitPoints2[1], (!flag || room4 == null) ? room3 : room4);
			}
			else
			{
				CostDisplay.Instance.Show(GetPrice(room3, room4, !flag), mouseProj.ToVector3(GameSettings.Instance.ActiveFloor * 2 + 2));
				Vector2 vector4 = (splitPoints2[0] + splitPoints2[1]) * 0.5f;
				SetWalls(vector4, vector4 + GetOffset(num2), (splitPoints2[0] - splitPoints2[1]).magnitude, (!flag || room4 == null) ? room3 : room4);
			}
		}
	}

	private bool AnyNowUnsupported(int floor, Room removed, Rect r1, Rect r2)
	{
		if (floor < 1)
		{
			return false;
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room.Floor == floor && (room.RoomBounds.Overlaps(r1) || room.RoomBounds.Overlaps(r2)) && !GameSettings.Instance.sRoomManager.IsSupported(room.Edges.Select((WallEdge x) => x.Pos), floor, removed))
			{
				return true;
			}
		}
		return false;
	}

	private bool CheckAtriumValid(Room r, Room r2)
	{
		if (r.AtriumParent == r)
		{
			if (r2 != null)
			{
				return false;
			}
			for (int i = 0; i < r.AtriumChildren.Count; i++)
			{
				int floor = r.Floor + i + 1;
				Room room = r.AtriumChildren[i];
				if (RoomCloneTool.Intersects(_points, floor, false, true, true, false, room) != RoomCloneTool.Intersection.None)
				{
					return false;
				}
				WallEdge wallEdge = room.Edges.FirstOrDefault((WallEdge x) => x.Pos == Edge1.Pos);
				if (wallEdge == null)
				{
					return false;
				}
				WallEdge wallEdge2 = room.Edges.FirstOrDefault((WallEdge x) => x.Pos == Edge2.Pos);
				if (wallEdge2 == null || wallEdge.Links[room] != wallEdge2)
				{
					return false;
				}
			}
		}
		else if (r.AtriumParent == null && r2 != null && r2.AtriumParent != null)
		{
			return false;
		}
		return true;
	}

	private bool DoDrag(Room r, Room r2, bool reverse, float fixedDist, float splitEdge, int splitPref, bool upperAtrium, out List<UndoObject.UndoAction> undos, out Room removedSection)
	{
		undos = null;
		removedSection = null;
		bool flag = false;
		if (r2 != null)
		{
			bool flag2 = r.CanMerge(r2);
			bool flag3 = false;
			if (!flag2 && r2.CanMerge(r))
			{
				Room room = r;
				r = r2;
				r2 = room;
				flag2 = true;
				flag3 = true;
			}
			if (flag2)
			{
				List<Vector2> list = r.Edges.SelectInPlaceList((WallEdge x) => x.Pos);
				if (SitsOn(list, _points) && SitsOn(_points, list))
				{
					if (r2.CanMerge(r))
					{
						Room room2 = r;
						r = r2;
						r2 = room2;
					}
					flag = true;
				}
				else
				{
					list.Clear();
					list.AddRange(r2.Edges.Select((WallEdge x) => x.Pos));
					if (SitsOn(list, _points) && SitsOn(_points, list))
					{
						flag = true;
					}
				}
				if (flag)
				{
					undos = new List<UndoObject.UndoAction>();
					List<Vector2> split = r.MergeWith(r2, r2.PrepareSplit(true, r.PrepareSplit(true)), undos);
					undos.Add(new UndoObject.UndoAction(r, r2, split));
					undos.Reverse();
				}
				else if (flag3)
				{
					Room room3 = r;
					r = r2;
					r2 = room3;
				}
			}
		}
		if (!flag)
		{
			float cost = GetPrice(r, r2, !reverse);
			if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - cost))
			{
				HashSet<uint> moved = new HashSet<uint>();
				HashSet<WallSnap> orNull = Edge1.Children.GetOrNull(Edge2);
				Dictionary<WallSnap, float> dictionary = ((orNull != null) ? orNull.ToDictionary((WallSnap x) => x, (WallSnap x) => x.WallPosition[Edge1]) : null);
				Vector2 p = new Vector2(_points.AverageOrDefault((Vector2 x) => x.x), _points.AverageOrDefault((Vector2 x) => x.y));
				bool flag4 = r.IsInside(p);
				undos = new List<UndoObject.UndoAction>();
				Room room4 = ((!reverse || r2 == null) ? r : r2);
				HashSet<Vector2> before = room4.Edges.Select((WallEdge x) => x.Pos).ToHashSet();
				Room edges = GetEdges(!reverse, ref cost, r, r2, true, undos);
				if (edges != null)
				{
					bool flag5 = r2 == null && flag4 && IsSame(before, room4.Edges.Select((WallEdge x) => x.Pos).ToHashSet(), edges.Edges.Select((WallEdge x) => x.Pos).ToHashSet());
					bool flag6 = !flag5 && (room4.CanMerge(edges) || room4.AtriumParent == room4 || upperAtrium);
					Vector2 offset = GetOffset(fixedDist);
					Vector2[] splitPoints = GetSplitPoints(splitEdge, splitPref);
					Vector2 p2 = splitPoints[0] + offset;
					Vector2 p3 = splitPoints[1] + offset;
					WallEdge wallEdge = edges.Edges.FirstOrDefault((WallEdge x) => x.Pos == p2);
					WallEdge wallEdge2 = edges.Edges.FirstOrDefault((WallEdge x) => x.Pos == p3);
					if (dictionary != null && dictionary.Count > 0 && (flag5 || flag6) && wallEdge != null && wallEdge2 != null)
					{
						int num = 0;
						if (wallEdge.Links.GetOrNull(edges) == wallEdge2)
						{
							num = ((!reverse) ? 1 : 2);
						}
						else if (wallEdge2.Links.GetOrNull(edges) == wallEdge)
						{
							num = (reverse ? 1 : 2);
						}
						if (num > 0)
						{
							HashSet<WallSnap> orNull2 = wallEdge.Children.GetOrNull(wallEdge2);
							if (orNull2 == null || orNull2.Count == 0)
							{
								float magnitude = (Edge1.Pos - Edge2.Pos).magnitude;
								float magnitude2 = (p2 - p3).magnitude;
								foreach (KeyValuePair<WallSnap, float> f in dictionary)
								{
									if (!(f.Key != null) || !f.Key.IsAliveNotNull())
									{
										continue;
									}
									float num2 = f.Value;
									switch (splitPref)
									{
									case 1:
										if (num2 > splitEdge)
										{
											continue;
										}
										break;
									case 2:
										if (magnitude - num2 > splitEdge)
										{
											continue;
										}
										num2 -= magnitude - splitEdge;
										break;
									}
									bool flag7 = (num == 2) ^ (f.Key.FirstEdge != Edge1);
									WallEdge edge = ((f.Key.FirstEdge == Edge1) ? wallEdge : wallEdge2);
									WallEdge edge2 = ((f.Key.FirstEdge == Edge1) ? wallEdge2 : wallEdge);
									undos.Insert(0, new UndoObject.UndoAction(f.Key));
									moved.Add(f.Key.DID);
									undos.RemoveAll((UndoObject.UndoAction x) => x.Type == UndoObject.UndoAction.ActionType.CreateSegment && x.Dictionary.Get("ID", 0u) == f.Key.DID);
									f.Key.Init(edge, edge2, ((!flag7) ? num2 : (magnitude2 - num2)) / magnitude2, true);
									Furniture furniture;
									if ((object)(furniture = f.Key as Furniture) != null)
									{
										furniture.OriginalPosition = furniture.transform.position;
										furniture.UpdateBoundaryPoints();
										FurnitureBuilder.TraverseMove(furniture, furniture.Parent, null, null, 0f, null);
									}
								}
							}
						}
					}
					if (flag5)
					{
						CostDisplay.Instance.ClearFloaters();
						GameSettings.Instance.MyCompany.MakeTransaction(cost, Company.TransactionCategory.Construction, true);
						undos.Insert(0, new UndoObject.UndoAction(edges, false, 0f - cost));
						undos.InsertRange(1, from x in edges.GetFurnitures()
							select new UndoObject.UndoAction(x, false));
						undos.InsertRange(1, from x in edges.GetSegments()
							where !moved.Contains(x.DID)
							select new UndoObject.UndoAction(x, false));
						if (edges.AtriumParent == edges)
						{
							undos.InsertRange(1, edges.AtriumChildren.Select((Room x) => new UndoObject.UndoAction(x, false, 0f)));
						}
						edges.DestroyGO();
						removedSection = edges;
					}
					else if (flag6)
					{
						List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
						List<Vector2> split2 = room4.MergeWith(edges, edges.PrepareSplit(true, room4.PrepareSplit(true)), list2, true);
						list2.Add(new UndoObject.UndoAction(room4, edges, split2));
						list2.Reverse();
						undos.InsertRange(0, list2);
					}
					else
					{
						if (edges.Floor > 0 && !GameSettings.Instance.sRoomManager.IsSupported(edges.Edges.Select((WallEdge x) => x.Pos), edges.Floor, null))
						{
							new UndoObject(undos.ToArray()).Execute(true);
							ErrorOverlay.Instance.ShowError("UnsupportedStructure", false, true, 4f);
							UISoundFX.PlaySFX("BuildError");
							CostDisplay.Instance.ClearFloaters();
							return false;
						}
						room4.GetStyle().Apply(edges, null);
					}
				}
				SetShortcuts();
				return edges != null;
			}
			UISoundFX.PlaySFX("BuildError");
			HUD.FlashMoney();
			return false;
		}
		return true;
	}

	private bool IsSame(HashSet<Vector2> before, HashSet<Vector2> a, HashSet<Vector2> b)
	{
		foreach (Vector2 item in a.ToList())
		{
			if (b.Contains(item))
			{
				b.Remove(item);
				a.Remove(item);
			}
		}
		a.AddRange(b);
		foreach (Vector2 item2 in a)
		{
			if (!before.Contains(item2))
			{
				return false;
			}
		}
		return true;
	}

	public void HandleFurnAndDirt(Room r1, Room r2, List<UndoObject.UndoAction> undos)
	{
		if (r1 == null)
		{
			return;
		}
		for (int i = 0; i < r1.Dirts.Count; i++)
		{
			if (!r1.IsInside(r1.Dirts[i].Pos))
			{
				Vector2 pos = r1.Dirts[i].Pos;
				float amount = r1.Dirts[i].Amount;
				float rot = r1.Dirts[i].Rot;
				r1.RemoveDirt(i);
				if (r2 != null && r2.IsInside(pos))
				{
					r2.AddNewDirt(pos, amount, r1.Dirts[i].Type, rot);
				}
				i--;
			}
		}
		foreach (Furniture item in from x in r1.GetFurnitures().ToList()
			orderby x.GetSnappingDepth()
			select x)
		{
			if (item.IsAliveNotNull() && !item.UpdateParent(true, false))
			{
				item.UndoDestroyWithChildren(undos);
			}
		}
		r1.RecalculateTableGroupsNow();
		r1.UpdateDirtScore(false);
		if (r2 != null)
		{
			r2.UpdateDirtScore(false);
			r2.RecalculateTableGroupsNow();
		}
	}

	private bool CheckValidAngle(Room r, WallEdge e1, WallEdge e2, bool rev)
	{
		return true;
	}

	private bool CheckSupport(Room r)
	{
		return GameSettings.Instance.sRoomManager.IsSupported(_points, r.Floor, null);
	}

	private bool CheckSelfIntersection(List<Vector2> ps, IList<KeyValuePair<Room, int>> rooms)
	{
		for (int i = 0; i < ps.Count - 1; i++)
		{
			Vector2 vector = ps[i];
			Vector2 vector2 = ps[i + 1];
			for (int j = 0; j < rooms.Count; j++)
			{
				KeyValuePair<Room, int> keyValuePair = rooms[j];
				Room key = keyValuePair.Key;
				int value = keyValuePair.Value;
				for (int k = 0; k < key.Edges.Count - 1; k++)
				{
					int num = (k + value) % key.Edges.Count;
					WallEdge wallEdge = key.Edges[num];
					WallEdge wallEdge2 = key.Edges[(num + 1) % key.Edges.Count];
					Vector2 res;
					if (k > 0 && Utilities.ProjectToLine(wallEdge.Pos, vector, vector2, out res) && (res - wallEdge.Pos).magnitude.VeryStrictlyBelow(BuildController.Instance.MinWallDistance))
					{
						ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
						return true;
					}
					if (i > 0)
					{
						Vector2 res2;
						if (Utilities.ProjectToLine(vector, wallEdge.Pos, wallEdge2.Pos, out res2) && (res2 - vector).magnitude.VeryStrictlyBelow(BuildController.Instance.MinWallDistance))
						{
							ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
							return true;
						}
						if (k > 0 && (wallEdge.Pos - vector).magnitude.VeryStrictlyBelow(BuildController.Instance.MinWallDistance))
						{
							ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
							return true;
						}
					}
					if (Utilities.LinesIntersect(vector, vector2, wallEdge.Pos, wallEdge2.Pos, false, i > 0, i < ps.Count - 2))
					{
						ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
						return true;
					}
				}
			}
		}
		return false;
	}

	private Room GetEdges(bool fromFirst, ref float cost, Room r1, Room r2, bool ignoreSupport, List<UndoObject.UndoAction> undo)
	{
		Room room = ((fromFirst || r2 == null) ? r1 : r2);
		Room ignore = null;
		if (r1.IsBalcony)
		{
			ignore = r1;
			if (r2 != null && r2.IsBalcony)
			{
				ignore = null;
			}
		}
		else if (r2 != null && r2.IsBalcony)
		{
			ignore = r2;
		}
		Room result = BuildController.Instance.FinalizeRect(_points, ref cost, false, room.Outdoors, room.Pillar, undo, true, ignoreSupport, ignore, r1.Floor);
		BuildController.Instance.ClearBuild(false, false, false, false, false, false, false, true);
		return result;
	}

	private Vector2 GetOffset(float dist)
	{
		return (Edge1.Pos - Edge2.Pos).normalized.Turn90() * dist;
	}

	private void GetPoints(float dist, float split, int splitPref)
	{
		Vector2[] splitPoints = GetSplitPoints(split, splitPref);
		_points[0] = splitPoints[0];
		_points[1] = splitPoints[1];
		Vector2 offset = GetOffset(dist);
		_points[2] = splitPoints[1] + offset;
		_points[3] = splitPoints[0] + offset;
		if (Utilities.Clockwise(_points))
		{
			_points.ReverseArray();
		}
	}

	private float GetPrice(Room r1, Room r2, bool fromFirst)
	{
		Room room = ((fromFirst || r2 == null) ? r1 : r2);
		return BuildController.GetRoomCost(_points, room.Outdoors || room.IsUpperAtrium, room.Pillar, r1.Floor, r2 != null && !r1.IsUpperAtriumNotBalcony && !r2.IsUpperAtriumNotBalcony, false, false);
	}

	public static bool SitsOn(IList<Vector2> a, IList<Vector2> b)
	{
		for (int i = 0; i < a.Count; i++)
		{
			Vector2 vector = a[i];
			bool flag = false;
			for (int j = 0; j < b.Count; j++)
			{
				Vector2 vector2 = b[j];
				if (vector == vector2)
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
				Vector2 a2 = b[k];
				Vector2 b2 = b[(k + 1) % b.Count];
				Vector2 res;
				if (Utilities.ProjectToLine(vector, a2, b2, out res) && (res - vector).magnitude < BuildController.GetSnapDistance())
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
}
