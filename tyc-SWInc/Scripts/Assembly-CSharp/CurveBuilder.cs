using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurveBuilder : MonoBehaviour
{
	public float MinSmoothingAngle = 155f;

	public static CurveBuilder Instance;

	public GameObject WallPrefab;

	[NonSerialized]
	public Room RoomCorner;

	[NonSerialized]
	public WallEdge Edge1;

	[NonSerialized]
	public WallEdge Edge2;

	public float DistanceLimit;

	public MeshRenderer MeshRend;

	public MeshFilter MeshFilt;

	public int Segs = 2;

	public float LastAngle;

	private float _lastDist;

	[NonSerialized]
	private List<GameObject> _wallPool = new List<GameObject>();

	private List<Vector2> _points = new List<Vector2>();

	private Vector2 _lastCenter;

	private bool _shouldSmooth;

	private int _maxSeg;

	[NonSerialized]
	private MeshCombiner _meshComb;

	[NonSerialized]
	private Mesh _mesh;

	private static List<Vector2> _pricePoints = new List<Vector2>();

	private float _lastMag;

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
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		base.gameObject.SetActive(false);
		_meshComb = new MeshCombiner("", false);
		_mesh = new Mesh();
		_mesh.MarkDynamic();
		MeshFilt.sharedMesh = _mesh;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		UnityEngine.Object.Destroy(_mesh);
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		if (HUD.Instance != null)
		{
			BuildController.Instance.ClearBuild(false, false, false, false, false, true);
			HUD.Instance.ShortcutPanel.AddShortcut("CurveChangeSeg".Loc(), "MouseScroll".Loc());
			HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
			HUD.Instance.UpdateBorderOverlay();
		}
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
		MeshRend.enabled = false;
		for (int i = 0; i < _wallPool.Count; i++)
		{
			_wallPool[i].SetActive(false);
		}
	}

	private void SetWalls(Vector2 a, Vector2 b)
	{
		if (_wallPool.Count == 0)
		{
			GameObject item = UnityEngine.Object.Instantiate(WallPrefab);
			_wallPool.Add(item);
		}
		SetDim(_wallPool[0], a, b);
		for (int i = 1; i < _wallPool.Count; i++)
		{
			_wallPool[i].SetActive(false);
		}
	}

	private void SetDim(GameObject wallObj, Vector2 a, Vector2 b)
	{
		wallObj.transform.SetPositionAndRotation(((a + b) * 0.5f).ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + 1f), Quaternion.LookRotation((a - b).ToVector3(0f)));
		wallObj.transform.localScale = new Vector3(Room.WallOffset + 0.01f, 2.1f, (a - b).magnitude);
		wallObj.SetActive(true);
	}

	private Vector4 TangentFromNormal(Vector3 normal, bool ext)
	{
		if (!ext)
		{
			return new Vector4(normal.z, 0f, 0f - normal.x, 1f);
		}
		return new Vector4(0f - normal.z, 0f, normal.x, -1f);
	}

	private void SetWalls(IList<Vector2> points)
	{
		for (int i = 0; i < _wallPool.Count; i++)
		{
			_wallPool[i].SetActive(false);
		}
		MeshRend.enabled = true;
		_meshComb.Clear("");
		List<Vector2> list = new List<Vector2>();
		List<Vector2> list2 = new List<Vector2>();
		List<Vector3> list3 = new List<Vector3>();
		List<Vector4> list4 = new List<Vector4>();
		Room room = RoomCorner ?? Edge1.GetRoom(Edge2);
		WallEdge wallEdge = Edge1.FindConnectionIn(room);
		WallEdge wallEdge2 = ((RoomCorner == null) ? Edge2.Links[room] : Edge1.Links[room]);
		Vector2 vector = Utilities.GetOffset(wallEdge.Pos, points[0], points[1], (0f - Room.WallOffset) / 2f, true);
		Vector2 vector2 = Utilities.GetOffset(wallEdge.Pos, points[0], points[1], Room.WallOffset / 2f, true);
		Vector3 vector3 = (wallEdge.Pos - points[0]).Turn90().ToVector3(0f).normalized;
		for (int j = 1; j < points.Count; j++)
		{
			Vector2 first = ((j == 0) ? wallEdge.Pos : points[j - 1]);
			Vector2 vector4 = points[j];
			Vector2 third = ((j == points.Count - 1) ? wallEdge2.Pos : points[j + 1]);
			Vector2 offset = Utilities.GetOffset(first, vector4, third, (0f - Room.WallOffset) / 2f - 0.01f, true);
			Vector2 offset2 = Utilities.GetOffset(first, vector4, third, Room.WallOffset / 2f + 0.01f, true);
			list.Add(vector);
			list.Add(offset);
			list2.Add(vector2);
			list2.Add(offset2);
			_meshComb.MakeFace(vector2.ToVector3(2f), offset2.ToVector3(2f), offset.ToVector3(2f), vector.ToVector3(2f), Vector3.up, Color.white, Vector3.right);
			if (_shouldSmooth)
			{
				Vector3 normalized = (_lastCenter - offset).ToVector3(0f).normalized;
				list3.Add(vector3);
				list3.Add(normalized);
				list4.Add(TangentFromNormal(vector3, true));
				list4.Add(TangentFromNormal(normalized, true));
				vector3 = normalized;
			}
			else
			{
				Vector3 normalized2 = (vector4 - offset).ToVector3(0f).normalized;
				list3.Add(normalized2);
				list3.Add(normalized2);
				Vector4 item = TangentFromNormal(normalized2, true);
				list4.Add(item);
				list4.Add(item);
			}
			vector = offset;
			vector2 = offset2;
		}
		_meshComb.AddWall(list, list3, list4, null, Vector2.zero, false);
		_meshComb.AddWall(list2, list3.SelectInPlaceList((Vector3 x) => -x), list3.SelectInPlaceList((Vector3 x) => TangentFromNormal(-x, false)), null, Vector2.zero, true);
		_meshComb.CreateMesh(_mesh);
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
		Vector2 mouse = HUD.Instance.GetMouseProj(1f);
		if (!GUICheck.OverGUI && RoomCorner == null)
		{
			Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, mouse);
			if (roomFromPoint != null && !roomFromPoint.Outside && roomFromPoint.Burn <= 0f && roomFromPoint.AtriumParent == null)
			{
				WallEdge wallEdge = roomFromPoint.Edges.MinInstance((WallEdge x) => (x.Pos - mouse).sqrMagnitude);
				if ((wallEdge.Pos - mouse).magnitude <= DistanceLimit)
				{
					WallEdge wallEdge2 = wallEdge.FindConnectionIn(roomFromPoint);
					WallEdge wallEdge3 = wallEdge.Links[roomFromPoint];
					if (!wallEdge2.HasSegments(wallEdge) && !wallEdge.HasSegments(wallEdge3) && (wallEdge2.Pos - wallEdge.Pos).magnitude >= 2f && (wallEdge3.Pos - wallEdge.Pos).magnitude >= 2f)
					{
						Vector2 vector = wallEdge.Pos + (wallEdge2.Pos - wallEdge.Pos).normalized * 2f;
						Vector2 vector2 = wallEdge.Pos + (wallEdge3.Pos - wallEdge.Pos).normalized * 2f;
						if ((vector - vector2).magnitude >= 2f && wallEdge.Pos.AngleBetween(wallEdge2.Pos, wallEdge3.Pos) <= 90.02f)
						{
							RoomCorner = roomFromPoint;
							Edge1 = wallEdge;
							Edge2 = null;
							SetWalls(new Vector2[3]
							{
								Edge1.Pos + (wallEdge2.Pos - Edge1.Pos).normalized,
								Edge1.Pos,
								Edge1.Pos + (wallEdge3.Pos - Edge1.Pos).normalized
							});
							Segs = 2;
							_lastDist = -1f;
							UISoundFX.PlaySFX("HighlightTick", true);
						}
					}
				}
				if (RoomCorner != null)
				{
					WallEdge wallEdge4 = Edge1.FindConnectionIn(RoomCorner);
					WallEdge wallEdge5 = Edge1.Links[RoomCorner];
					WindowManager.SetCursorOverride(Utilities.UIDirectionToIcon(Utilities.WorldToUIDirection(Utilities.ProjectToLineEndless(Edge1.Pos, wallEdge4.Pos, wallEdge5.Pos).ToVector3((float)Edge1.Floor * 2f), Edge1.Pos.ToVector3((float)Edge1.Floor * 2f))));
				}
				else if (Edge1 == null)
				{
					WindowManager.SetCursorOverride(null);
				}
			}
		}
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
					if (!item.IsReadonly(room2, room) && room2.Burn <= 0f && (room == null || room.Burn <= 0f))
					{
						HashSet<WallSnap> orDefault = item.Children.GetOrDefault(link.Value);
						HashSet<WallSnap> orDefault2 = link.Value.Children.GetOrDefault(item);
						if ((orDefault == null || orDefault.Count == 0) && (orDefault2 == null || orDefault2.Count == 0))
						{
							float magnitude = (item.Pos - link.Value.Pos).magnitude;
							Vector2 res;
							if (magnitude >= 3f && Utilities.ProjectToLine(mouse, item.Pos, link.Value.Pos, out res) && (res - mouse).magnitude <= DistanceLimit)
							{
								Edge1 = item;
								Edge2 = link.Value;
								RoomCorner = null;
								SetWalls(Edge1.Pos, Edge2.Pos);
								Segs = (_maxSeg = Mathf.FloorToInt(magnitude) - 1);
								UISoundFX.PlaySFX("HighlightTick", true);
								break;
							}
						}
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
		}
		else if (RoomCorner != null)
		{
			PointDragCode(mouse);
		}
		else
		{
			EdgeDragCode(mouse);
		}
	}

	private float GetCornerCost(bool asSplit)
	{
		return BuildController.GetRoomCost(_points, RoomCorner.Outdoors, RoomCorner.Pillar, RoomCorner.Floor, asSplit, false, false);
	}

	private List<WallEdge> GetCurveSplit()
	{
		List<WallEdge> list = new List<WallEdge>();
		for (int i = 0; i < _points.Count; i++)
		{
			WallEdge wallEdge = null;
			for (int j = 0; j < RoomCorner.Edges.Count; j++)
			{
				WallEdge wallEdge2 = RoomCorner.Edges[j];
				if ((wallEdge2.Pos - _points[i]).sqrMagnitude < 0.001f)
				{
					wallEdge = wallEdge2;
					break;
				}
			}
			if (wallEdge == null)
			{
				for (int k = 0; k < RoomCorner.Edges.Count; k++)
				{
					WallEdge wallEdge3 = RoomCorner.Edges[k];
					WallEdge wallEdge4 = RoomCorner.Edges[(k + 1) % RoomCorner.Edges.Count];
					Vector2 res;
					if (Utilities.ProjectToLine(_points[i], wallEdge3.Pos, wallEdge4.Pos, out res) && (res - _points[i]).sqrMagnitude < 0.001f)
					{
						wallEdge = new WallEdge(res, RoomCorner.Floor);
						wallEdge.SetSplit(wallEdge3, RoomCorner);
					}
				}
			}
			if (wallEdge == null)
			{
				wallEdge = new WallEdge(_points[i], RoomCorner.Floor);
			}
			list.Add(wallEdge);
		}
		if (_shouldSmooth)
		{
			for (int l = 0; l < list.Count - 1; l++)
			{
				list[l].Smooth.Add(list[l + 1]);
			}
		}
		return list;
	}

	private List<WallEdge> GetCurveOpen(List<UndoObject.UndoAction> undo)
	{
		List<WallEdge> list = new List<WallEdge>();
		for (int i = 0; i < _points.Count; i++)
		{
			Vector2 vector = _points[i];
			WallEdge wallEdge = null;
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(RoomCorner.Floor))
			{
				if ((item.Pos - vector).sqrMagnitude < 0.001f)
				{
					wallEdge = item;
					break;
				}
			}
			if (wallEdge == null)
			{
				foreach (WallEdge item2 in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(RoomCorner.Floor))
				{
					foreach (KeyValuePair<IRoom, WallEdge> link in item2.Links)
					{
						Vector2 res;
						if (Utilities.ProjectToLine(vector, item2.Pos, link.Value.Pos, out res) && (res - vector).sqrMagnitude < 0.001f)
						{
							wallEdge = new WallEdge(res, RoomCorner.Floor);
							wallEdge.SetSplit(item2, (Room)link.Key);
							break;
						}
					}
				}
			}
			if (wallEdge == null)
			{
				wallEdge = new WallEdge(vector, RoomCorner.Floor);
			}
			list.Add(wallEdge);
		}
		BuildController.Instance.CurrentSegments = list;
		BuildController.Instance.FinalizeCuts(false, RoomCorner.Floor, undo, true);
		BuildController.Instance.CurrentSegments = null;
		for (int j = 0; j < list.Count - 1; j++)
		{
			WallEdge wallEdge2 = list[j];
			if (_shouldSmooth)
			{
				wallEdge2.Smooth.Add(list[j + 1]);
			}
			wallEdge2.Links[RoomCorner] = list[j + 1];
		}
		return list;
	}

	public void PointDragCode(Vector2 mouse)
	{
		WallEdge wallEdge = Edge1.FindConnectionIn(RoomCorner);
		WallEdge wallEdge2 = Edge1.Links[RoomCorner];
		WindowManager.SetCursorOverride(Utilities.UIDirectionToIcon(Utilities.WorldToUIDirection(Utilities.ProjectToLineEndless(Edge1.Pos, wallEdge.Pos, wallEdge2.Pos).ToVector3((float)Edge1.Floor * 2f), Edge1.Pos.ToVector3((float)Edge1.Floor * 2f))));
		if (Input.GetMouseButtonUp(0) && _lastDist >= 2f)
		{
			ValueTuple<Vector2, float, float, float> pointAndRad = GetPointAndRad(Edge1, RoomCorner, _lastDist);
			Vector2 item = pointAndRad.Item1;
			float item2 = pointAndRad.Item2;
			float item3 = pointAndRad.Item3;
			float item4 = pointAndRad.Item4;
			CalculatePoints(item, item2, item3, item4, Segs);
			Vector2 vector = (Edge1.Pos + _points[_points.Count / 2]) * 0.5f;
			Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(RoomCorner.Floor, vector);
			bool flag = true;
			if (roomFromPoint == null || roomFromPoint.Outside)
			{
				if (!GameSettings.Instance.PlayerOwnedArea(_points))
				{
					ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
					flag = false;
				}
				if (flag && RoomCloneTool.Intersects(_points, RoomCorner.Floor, true, true, true, true, RoomCorner) != RoomCloneTool.Intersection.None)
				{
					ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
					flag = false;
				}
				if (flag)
				{
					List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
					List<WallEdge> curveOpen = GetCurveOpen(list);
					float cornerCost = GetCornerCost(false);
					GameSettings.Instance.MyCompany.MakeTransaction(0f - cornerCost, Company.TransactionCategory.Construction, true, "Room");
					CostDisplay.Instance.FloatAway(cornerCost);
					UISoundFX.PlaySFX("PlaceRoom", true);
					UISoundFX.PlaySFX("Kaching");
					wallEdge.Links[RoomCorner] = curveOpen[0];
					curveOpen.Last().Links[RoomCorner] = wallEdge2;
					int index = RoomCorner.Edges.IndexOf(Edge1);
					RoomCorner.Edges.RemoveAt(index);
					RoomCorner.Edges.InsertRange(index, curveOpen);
					GameSettings.Instance.sRoomManager.AllSegments.Remove(Edge1);
					GameSettings.Instance.sRoomManager.AllSegments.AddRange(curveOpen);
					RoomCorner.OptimizeSegments();
					RoomCorner.DirtyOuterMesh = (RoomCorner.DirtyInnerMesh = (RoomCorner.DirtyNavMesh = (RoomCorner.DirtyPathNodes = true)));
					RoomCorner.UpdateBounds(false);
					RoomCorner.QueueEdgeNetworkUpdate();
					if (RoomCorner.Floor == 0)
					{
						GrassSystem.Instance.InvalidateArea();
						RoomCorner.RemoveTrees(list);
						GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
						GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
					}
					list.Insert(0, new UndoObject.UndoAction(RoomCorner, null, curveOpen[0], curveOpen.Last(), false, cornerCost, Edge1.Pos));
					GameSettings.Instance.AddUndo(list.ToArray());
				}
			}
			else
			{
				Room room = Edge1.GetRoom(wallEdge);
				Room room2 = wallEdge2.GetRoom(Edge1);
				if (room != null && room == room2)
				{
					Room room3;
					Room room4;
					if (roomFromPoint == RoomCorner)
					{
						room3 = RoomCorner;
						room4 = room;
					}
					else
					{
						room3 = room;
						room4 = RoomCorner;
						_points.Reverse();
					}
					List<UndoObject.UndoAction> undos = new List<UndoObject.UndoAction>();
					float cornerCost2 = GetCornerCost(true);
					List<WallEdge> curveSplit = GetCurveSplit();
					if (ValidSelfIntersect(curveSplit, room3))
					{
						Room room5 = BuildController.Instance.MakeSplit(curveSplit, room3, vector, undos, cornerCost2, true, null, false, false);
						if (room5 != null)
						{
							room4.MergeWith(room5, room4.PrepareSplit(true), undos);
							GameSettings.Instance.MyCompany.MakeTransaction(0f - cornerCost2, Company.TransactionCategory.Construction, true);
							CostDisplay.Instance.FloatAway(cornerCost2);
							GameSettings.Instance.AddUndo(new UndoObject.UndoAction(room3, room4, curveSplit[0].Pos, curveSplit.Last().Pos, Edge1.Pos, cornerCost2));
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					List<WallEdge> curveSplit2 = GetCurveSplit();
					if (ValidPointDistance(curveSplit2) && ValidSelfIntersect(curveSplit2, RoomCorner))
					{
						List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
						float cornerCost3 = GetCornerCost(true);
						Room room6 = BuildController.Instance.MakeSplit(curveSplit2, RoomCorner, vector, list2, cornerCost3, true, null, false, false, true);
						if (room6 != null)
						{
							GameSettings.Instance.MyCompany.MakeTransaction(0f - cornerCost3, Company.TransactionCategory.Construction, true);
							CostDisplay.Instance.FloatAway(cornerCost3);
							foreach (Furniture item9 in from x in room6.GetFurnitures()
								orderby x.GetSnappingDepth()
								select x)
							{
								list2.Add(new UndoObject.UndoAction(item9, false));
							}
							list2.Insert(0, new UndoObject.UndoAction(room6, false, 0f));
							room6.DestroyGO();
							GameSettings.Instance.AddUndo(list2.ToArray());
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				Edge1 = null;
				RoomCorner = null;
				SetWalls();
				BuildingHUD.Instance.Enable(false, false, false);
				UISoundFX.PlaySFX("PlaceRoom", true);
				UISoundFX.PlaySFX("Kaching");
			}
			else
			{
				UISoundFX.PlaySFX("BuildError");
			}
		}
		else if (!Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0) && (Edge1.Pos - mouse).magnitude > DistanceLimit * 2f)
		{
			Edge1 = null;
			RoomCorner = null;
			BuildingHUD.Instance.Enable(false, false, false);
			SetWalls();
			CostDisplay.Instance.Hide();
		}
		if (Edge1 == null)
		{
			return;
		}
		float magnitude = (Edge1.Pos - wallEdge.Pos).magnitude;
		float magnitude2 = (Edge1.Pos - wallEdge2.Pos).magnitude;
		float num = Mathf.Min(magnitude, magnitude2);
		float gridSize = BuildController.Instance.GetGridSize();
		float num2 = Mathf.Clamp((float)Mathf.RoundToInt((Edge1.Pos - mouse).magnitude * gridSize) / gridSize, 2f, num);
		if (num2 > num - 1f)
		{
			num2 = num;
		}
		Vector2 vector2 = Edge1.Pos + (wallEdge.Pos - Edge1.Pos).normalized * num2;
		Vector2 vector3 = Edge1.Pos + (wallEdge2.Pos - Edge1.Pos).normalized * num2;
		int segs = Segs;
		int num3 = Mathf.Max(2, Mathf.FloorToInt((vector2 - vector3).magnitude) - 1);
		Segs = Mathf.Clamp(Segs + Mathf.RoundToInt(Input.mouseScrollDelta.y), 2, num3);
		if (segs != Segs)
		{
			UISoundFX.PlaySFX("HighlightTick", Mathf.Clamp(1f + ((float)Segs - 2f) / 10f, 1f, 2f), 0f, true);
		}
		if (Input.GetMouseButton(0))
		{
			if (num2 != _lastDist)
			{
				Segs = num3;
				float pitch = 1f + Mathf.Min(_lastDist / 16f, 1f);
				UISoundFX.PlaySFX("Tick", pitch, 0f, true);
			}
			_lastDist = num2;
			ValueTuple<Vector2, float, float, float> pointAndRad2 = GetPointAndRad(Edge1, RoomCorner, _lastDist);
			Vector2 item5 = pointAndRad2.Item1;
			float item6 = pointAndRad2.Item2;
			float item7 = pointAndRad2.Item3;
			float item8 = pointAndRad2.Item4;
			CalculatePoints(item5, item6, item7, item8, Segs);
			SetWalls(_points);
			float num4 = (float)GameSettings.Instance.ActiveFloor * 2f;
			CostDisplay.Instance.Show(GetCornerCost(true), mouse.ToVector3(num4 + 2f));
			BuildingHUD.Instance.Enable(true, true, true);
			Vector3 vector4 = (Edge1.Pos + (wallEdge.Pos - Edge1.Pos).normalized * num2).ToVector3(num4);
			Vector3 vector5 = Edge1.Pos.ToVector3(num4);
			Vector3 vector6 = (Edge1.Pos + (wallEdge2.Pos - Edge1.Pos).normalized * num2).ToVector3(num4);
			BuildingHUD.Instance.SetDimension(vector5, vector4);
			BuildingHUD.Instance.SetDimension(vector5, vector6, false);
			BuildingHUD.Instance.SetRot(vector4, vector5, vector6);
		}
	}

	public bool ValidPointDistance(List<WallEdge> edges)
	{
		foreach (WallEdge edge in edges)
		{
			foreach (WallEdge allSegment in GameSettings.Instance.sRoomManager.AllSegments)
			{
				if (allSegment.Floor == GameSettings.Instance.ActiveFloor && allSegment != Edge1 && edge != allSegment && (edge.Pos - allSegment.Pos).magnitude.VeryStrictlyBelow(BuildController.Instance.MinWallDistance))
				{
					ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
					return false;
				}
			}
		}
		return true;
	}

	public bool ValidSelfIntersect(List<WallEdge> edges, Room r)
	{
		for (int i = 0; i < edges.Count - 1; i++)
		{
			WallEdge wallEdge = edges[i];
			WallEdge wallEdge2 = edges[(i + 1) % edges.Count];
			for (int j = 0; j < r.Edges.Count; j++)
			{
				WallEdge wallEdge3 = r.Edges[j];
				WallEdge wallEdge4 = r.Edges[(j + 1) % r.Edges.Count];
				if (wallEdge3 != wallEdge && wallEdge3 != wallEdge2 && wallEdge4 != wallEdge && wallEdge4 != wallEdge2 && Utilities.LinesIntersect(wallEdge.Pos, wallEdge2.Pos, wallEdge3.Pos, wallEdge4.Pos, true, false))
				{
					ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
					return false;
				}
			}
		}
		return true;
	}

	public void EdgeDragCode(Vector2 mouse)
	{
		WindowManager.SetCursorOverride(Utilities.UIDirectionToIcon(Utilities.WorldToUIDirection(Edge1.Pos.ToVector3((float)Edge1.Floor * 2f), Edge2.Pos.ToVector3((float)Edge2.Floor * 2f)) + 90f));
		Vector2 vector = Utilities.ProjectToLineEndlessClamped(mouse, Edge1.Pos, Edge2.Pos);
		if (!Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0) && (vector - mouse).magnitude > DistanceLimit)
		{
			Edge1 = null;
			SetWalls();
			CostDisplay.Instance.Hide();
		}
		if (Edge1 == null)
		{
			return;
		}
		bool flag = Utilities.IsLeft(Edge1.Pos, Edge2.Pos, mouse) > 0;
		float magnitude = (vector - mouse).magnitude;
		Vector2 vector2 = BuildController.Instance.CorrectMousePos(mouse);
		float magnitude2 = (Utilities.ProjectToLineEndlessClamped(vector2, Edge1.Pos, Edge2.Pos) - vector2).magnitude;
		Room room = Edge1.GetRoom(Edge2);
		Room room2 = Edge2.GetRoom(Edge1);
		int segs = Segs;
		Segs = Mathf.Clamp(Segs + Mathf.RoundToInt(Input.mouseScrollDelta.y), 2, _maxSeg);
		if (segs != Segs)
		{
			UISoundFX.PlaySFX("HighlightTick", Mathf.Clamp(1f + ((float)Segs - 2f) / 10f, 1f, 2f), 0f, true);
		}
		if (room == null)
		{
			Edge1 = null;
			SetWalls();
			CostDisplay.Instance.Hide();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			CalculatePoints(magnitude2, magnitude, Segs, flag);
			float price = GetPrice(room, room2, !flag);
			if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - price))
			{
				bool flag2 = true;
				List<Vector2> list = new List<Vector2>(_points);
				list.Insert(0, Edge1.Pos);
				list.Add(Edge2.Pos);
				if (room2 == null && !flag)
				{
					if (!GameSettings.Instance.PlayerOwnedArea(list))
					{
						ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
						flag2 = false;
					}
					if (flag2 && RoomCloneTool.Intersects(list, room.Floor, true, true, true, true, room) != RoomCloneTool.Intersection.None)
					{
						ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
						flag2 = false;
					}
					if (flag2 && !CheckSupport(room, room.Edges.IndexOf(Edge1)))
					{
						ErrorOverlay.Instance.ShowError("UnsupportedStructure", false, true, 4f);
						flag2 = false;
					}
				}
				if (flag2)
				{
					List<KeyValuePair<Room, int>> list2 = new List<KeyValuePair<Room, int>>();
					list2.Add(new KeyValuePair<Room, int>(room, room.Edges.IndexOf(Edge2)));
					if (room2 != null)
					{
						list2.Add(new KeyValuePair<Room, int>(room2, room2.Edges.IndexOf(Edge1)));
					}
					if (CheckSelfIntersection(list, list2))
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					if (flag)
					{
						if (!CheckValidAngle(room, Edge1, Edge2, false))
						{
							flag2 = false;
						}
					}
					else if (room2 != null && !CheckValidAngle(room2, Edge2, Edge1, true))
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					List<UndoObject.UndoAction> list3 = new List<UndoObject.UndoAction>();
					List<WallEdge> edges = GetEdges(room.Floor, room, room2, list3);
					if (edges != null)
					{
						List<WallEdge> list4 = new List<WallEdge>();
						list4.Add(Edge1);
						list4.AddRange(edges);
						list4.Add(Edge2);
						Room.EmitDirt(list4, room.Floor, false);
						GameSettings.Instance.MyCompany.MakeTransaction(0f - price, Company.TransactionCategory.Construction, true, "Room");
						CostDisplay.Instance.FloatAway(price);
						UISoundFX.PlaySFX("PlaceRoom", true);
						UISoundFX.PlaySFX("Kaching");
						GameSettings.Instance.sRoomManager.AllSegments.AddRange(edges);
						int num = room.Edges.IndexOf(Edge1) + 1;
						Edge1.Links[room] = edges[0];
						if (_shouldSmooth)
						{
							Edge1.Smooth.Add(edges[0]);
							edges[0].Smooth.Add(Edge1);
						}
						else
						{
							Edge1.Smooth.Remove(Edge2);
							Edge2.Smooth.Remove(Edge1);
						}
						for (int i = 0; i < edges.Count; i++)
						{
							WallEdge wallEdge = edges[i];
							WallEdge wallEdge2 = ((i == edges.Count - 1) ? Edge2 : edges[i + 1]);
							wallEdge.Links[room] = wallEdge2;
							if (_shouldSmooth)
							{
								wallEdge.Smooth.Add(wallEdge2);
								wallEdge2.Smooth.Add(wallEdge);
							}
							room.Edges.Insert(num, wallEdge);
							num++;
						}
						if (room2 != null)
						{
							num = room2.Edges.IndexOf(Edge2) + 1;
							Edge2.Links[room2] = edges.Last();
							for (int num2 = edges.Count - 1; num2 >= 0; num2--)
							{
								WallEdge wallEdge3 = edges[num2];
								WallEdge value = ((num2 == 0) ? Edge1 : edges[num2 - 1]);
								wallEdge3.Links[room2] = value;
								room2.Edges.Insert(num, wallEdge3);
								num++;
							}
						}
						room.OptimizeSegments();
						room.DirtyOuterMesh = (room.DirtyInnerMesh = (room.DirtyNavMesh = (room.DirtyPathNodes = true)));
						room.UpdateBounds(false);
						room.QueueEdgeNetworkUpdate();
						if (room2 != null)
						{
							room2.OptimizeSegments();
							room2.DirtyOuterMesh = (room2.DirtyInnerMesh = (room2.DirtyNavMesh = (room2.DirtyPathNodes = true)));
							room2.UpdateBounds(false);
							room2.QueueEdgeNetworkUpdate();
						}
						else
						{
							foreach (Room item in room.Edges.SelectMany((WallEdge x) => x.Links.Keys).OfType<Room>().Distinct())
							{
								item.DirtyOuterMesh = true;
							}
							if (room.Floor == 0)
							{
								GrassSystem.Instance.InvalidateArea();
								room.RemoveTrees(list3);
								GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
								GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
							}
						}
						HandleFurnAndDirt(flag ? room : room2, flag ? room2 : room, list3);
						list3.Insert(0, new UndoObject.UndoAction(room, room2, Edge1, Edge2, flag, price));
						GameSettings.Instance.AddUndo(list3.ToArray());
					}
				}
				else
				{
					UISoundFX.PlaySFX("BuildError");
				}
			}
			else
			{
				UISoundFX.PlaySFX("BuildError");
				HUD.FlashMoney();
			}
			Edge1 = null;
			Edge2 = null;
			SetWalls();
		}
		else if (Input.GetMouseButton(0))
		{
			CalculatePoints(magnitude2, magnitude, Segs, flag);
			CostDisplay.Instance.Show(GetPrice(room, room2, !flag), mouse.ToVector3(GameSettings.Instance.ActiveFloor * 2 + 2));
			_points.Insert(0, Edge1.Pos);
			_points.Add(Edge2.Pos);
			SetWalls(_points);
		}
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
		Vector2 a = (rev ? _points.Last() : _points[0]);
		Vector2 pos = e1.Pos;
		Vector2 pos2 = e1.FindConnectionIn(r).Pos;
		if (pos.AngleBetween(a, pos2) < BuildController.Instance.MinAngle)
		{
			ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(BuildController.Instance.MinAngle), false, true, 4f, false);
			return false;
		}
		a = (rev ? _points[0] : _points.Last());
		Vector2 pos3 = e2.Pos;
		pos2 = e2.Links[r].Pos;
		if (pos3.AngleBetween(a, pos2) < BuildController.Instance.MinAngle)
		{
			ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(BuildController.Instance.MinAngle), false, true, 4f, false);
			return false;
		}
		return true;
	}

	private bool CheckSupport(Room r, int idx)
	{
		List<Vector2> list = r.Edges.SelectInPlaceList((WallEdge x) => x.Pos);
		list.InsertRange(idx + 1, _points);
		return GameSettings.Instance.sRoomManager.IsSupported(list, r.Floor, null);
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

	private List<WallEdge> GetEdges(int floor, Room r1, Room r2, List<UndoObject.UndoAction> undo)
	{
		List<WallEdge> list = new List<WallEdge>();
		for (int i = 0; i < _points.Count; i++)
		{
			Vector2 vector = _points[i];
			WallEdge wallEdge = null;
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(floor))
			{
				if ((item.Pos - vector).magnitude < BuildController.GetSnapDistance())
				{
					wallEdge = item;
					break;
				}
			}
			if (wallEdge == null)
			{
				foreach (WallEdge item2 in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(floor))
				{
					foreach (KeyValuePair<IRoom, WallEdge> link in item2.Links)
					{
						Vector2 res;
						if (Utilities.ProjectToLine(vector, item2.Pos, link.Value.Pos, out res) && (res - vector).magnitude < BuildController.GetSnapDistance())
						{
							if (link.Key == r1 || link.Key == r2)
							{
								ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
								return null;
							}
							wallEdge = new WallEdge(res, floor);
							wallEdge.SetSplit(item2, (Room)link.Key);
							break;
						}
					}
				}
			}
			if (wallEdge == null)
			{
				wallEdge = new WallEdge(vector, floor);
			}
			list.Add(wallEdge);
		}
		BuildController.Instance.CurrentSegments = list;
		BuildController.Instance.FinalizeCuts(false, floor, undo);
		BuildController.Instance.CurrentSegments = null;
		return list;
	}

	private float GetPrice(Room r1, Room r2, bool fromFirst)
	{
		_pricePoints.Clear();
		_pricePoints.Add(Edge1.Pos);
		_pricePoints.AddRange(_points);
		_pricePoints.Add(Edge2.Pos);
		Room room = ((fromFirst || r2 == null) ? r1 : r2);
		return BuildController.GetRoomCost(_pricePoints, room.Outdoors || room.IsUpperAtrium, room.Pillar, r1.Floor, r2 != null && !r1.IsUpperAtriumNotBalcony && !r2.IsUpperAtriumNotBalcony, false, false);
	}

	private void UpdateSmooth()
	{
		LastAngle = 0f;
		bool num = !(RoomCorner == null);
		int num2 = ((RoomCorner == null) ? _points.Count : (_points.Count - 1));
		for (int i = (num ? 1 : 0); i < num2; i++)
		{
			Vector2 a = ((i == 0) ? Edge1.Pos : _points[i - 1]);
			Vector2 b = _points[i];
			Vector2 c = ((i == _points.Count - 1) ? Edge2.Pos : _points[i + 1]);
			LastAngle += b.AngleBetween(a, c);
		}
		LastAngle /= ((RoomCorner == null) ? _points.Count : (_points.Count - 2));
		_shouldSmooth = LastAngle >= MinSmoothingAngle;
	}

	private void CalculatePoints(Vector2 c, float radius, float ang1, float ang2, int segs)
	{
		_points.Clear();
		float num = Mathf.DeltaAngle(ang1 * 57.29578f, ang2 * 57.29578f) * ((float)Math.PI / 180f) / (float)segs;
		float num2 = 1f;
		for (int i = 0; i <= segs; i++)
		{
			float f = ang1 + num * num2 * (float)i;
			_points.Add(c + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius);
		}
		UpdateSmooth();
	}

	private ValueTuple<Vector2, float, float, float> GetPointAndRad(WallEdge b, Room r, float dist)
	{
		Vector2 pos = b.Pos;
		WallEdge wallEdge = b.FindConnectionIn(r);
		WallEdge wallEdge2 = b.Links[r];
		Vector2 vector = pos + (wallEdge.Pos - b.Pos).normalized * dist;
		Vector2 b2 = pos + (wallEdge2.Pos - b.Pos).normalized * dist;
		Vector2 vector2 = Utilities.ProjectToLineEndless(pos, vector, b2);
		Vector2 vector3 = vector2 + (vector2 - pos);
		float magnitude = (vector3 - vector).magnitude;
		float num = Mathf.Atan2(vector.y - vector3.y, vector.x - vector3.x);
		if (num < 0f)
		{
			num += (float)Math.PI * 2f;
		}
		float num2 = Mathf.Atan2(b2.y - vector3.y, b2.x - vector3.x);
		if (num2 < 0f)
		{
			num2 += (float)Math.PI * 2f;
		}
		return new ValueTuple<Vector2, float, float, float>(vector3, magnitude, num, num2);
	}

	private void CalculatePoints(float offDist, float realOff, int segs, bool reverse)
	{
		_points.Clear();
		float num = 0f;
		Vector2 vector = (Edge1.Pos + Edge2.Pos) * 0.5f;
		float num2 = (Edge1.Pos - Edge2.Pos).magnitude / 2f;
		float num3 = Mathf.Sqrt(num2 * num2 * 2f);
		Quaternion quaternion = Quaternion.LookRotation((Edge2.Pos - Edge1.Pos).ToVector3(0f));
		if (reverse)
		{
			quaternion *= Quaternion.Euler(0f, 180f, 0f);
		}
		Vector2 vector2 = vector - (quaternion * new Vector3(num2, 0f, 0f)).FlattenVector3();
		Vector2 b = vector + (quaternion * new Vector3(num3 - num2, 0f, 0f)).FlattenVector3();
		_lastCenter = vector2;
		if (Mathf.Abs(realOff - (num3 - num2)) < 0.5f)
		{
			num = num3 - num2;
			PathBuilder.Instance.DrawLine(vector2, b, null, (float)GameSettings.Instance.ActiveFloor * 2f);
			float num4 = num2 / num3 * 2f;
			float num5 = ((float)Math.PI - num4) / 2f;
			float num6 = num4 / (float)segs;
			for (int i = 1; i < segs; i++)
			{
				float f = num5 + num6 * (float)i;
				Vector3 v = quaternion * new Vector3(Mathf.Sin(f) * num3 - num2, 0f, Mathf.Cos(f) * num3);
				_points.Add(vector + v.FlattenVector3());
			}
		}
		else
		{
			float num7 = (num = Mathf.Clamp(offDist, 1f / BuildController.Instance.GetGridSize(), num2 * 2f));
			float num8 = num2;
			b = vector + (quaternion * new Vector3(num7, 0f, 0f)).FlattenVector3();
			PathBuilder.Instance.DrawLine(vector, b, null, (float)GameSettings.Instance.ActiveFloor * 2f);
			if (realOff - (num3 - num2) > 0f)
			{
				_lastCenter = vector;
			}
			float num9 = (float)Math.PI * (3f * (num7 + num8) - Mathf.Sqrt((3f * num7 + num8) * (num7 + 3f * num8)));
			num9 /= (float)segs * 2f;
			Vector2 vector3 = new Vector2(0f, num8);
			float num10 = 0f;
			for (int j = 1; j < segs; j++)
			{
				float num11 = 0f;
				Vector2 vector4 = vector3;
				while (num11 < num9)
				{
					num10 += 0.00031415926f;
					vector4 = new Vector2(Mathf.Sin(num10) * num7, Mathf.Cos(num10) * num8);
					num11 += (vector4 - vector3).magnitude;
					vector3 = vector4;
				}
				Vector3 v2 = quaternion * new Vector3(vector4.x, 0f, vector4.y);
				_points.Add(vector + v2.FlattenVector3());
				vector3 = vector4;
			}
		}
		if (_lastMag != num)
		{
			float pitch = 1f + Mathf.Min(num / 16f, 1f);
			UISoundFX.PlaySFX("Tick", pitch, 0f, true);
			_lastMag = num;
		}
		if (!reverse)
		{
			_points.Reverse();
		}
		UpdateSmooth();
	}

	public void CalculateNextPoint(float rad, float otherRad, float circ, ref float angle, ref Vector2 last)
	{
		float num = 0f;
		float num2 = (float)Math.PI * 2f;
		float num3 = (num + num2) / 2f;
		Vector2 vector = new Vector2(Mathf.Sin(angle + num3) * rad, Mathf.Cos(angle + num3) * otherRad);
		float magnitude = (vector - last).magnitude;
		for (int i = 0; i < 1000; i++)
		{
			float num4 = magnitude - circ;
			if (num4 > 0f)
			{
				num2 = (num + num2) / 2f;
			}
			else
			{
				if (!(num4 < 0f))
				{
					break;
				}
				num = (num + num2) / 2f;
			}
			num3 = (num + num2) / 2f;
			vector = new Vector2(Mathf.Sin(angle + num3) * rad, Mathf.Cos(angle + num3) * otherRad);
			float num5 = magnitude;
			magnitude = (vector - last).magnitude;
			if (num5 == magnitude)
			{
				break;
			}
		}
		angle += num3;
		last = vector;
	}
}
