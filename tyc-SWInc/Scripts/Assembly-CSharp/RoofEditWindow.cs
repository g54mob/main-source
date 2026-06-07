using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class RoofEditWindow : MonoBehaviour
{
	public class RoofNode
	{
		public RoofPointObject Point;

		public Dictionary<RoofNode, RoofEdgeObject> Connections = new Dictionary<RoofNode, RoofEdgeObject>();

		public bool EndPoint;

		public bool visited;

		public RoofNode(RoofPointObject point)
		{
			Point = point;
		}
	}

	public GUIWindow Window;

	public RoofPointObject DotPrefab;

	public RoofEdgeObject LinePrefab;

	public Rect AreaRect;

	public Slider HeightSlider;

	public Slider BulgeSlider;

	public Material RoofMat;

	public Material GableMat;

	public Roof CurrentRoof;

	public Roof RoofPrefab;

	public float ClickRadius = 0.05f;

	[NonSerialized]
	private UndoObject.UndoAction _undo;

	private List<RoofPointObject> _points = new List<RoofPointObject>();

	private List<RoofEdgeObject> _edges = new List<RoofEdgeObject>();

	private HashSet<Room> _encompassingRooms;

	private List<Vector2> _outline;

	public bool DestroyOnClose;

	public Button FinalizeButton;

	public Text FinalizeLabel;

	public Color RoomOutlineColor;

	public MonoBehaviour CurrentHighlight;

	public Toggle TopDownView;

	public Toggle SnapToGrid;

	[NonSerialized]
	private IStyle _lastStyle;

	public float Test;

	private Vector2 _initialClick;

	private Vector2 _initialOffset;

	private int _clickButton;

	private bool _clicked;

	private bool _dragging;

	private RoofEdgeObject _edgeHit;

	private RoofPointObject _pointHit;

	private RoofPointObject _lastPointHit;

	[NonSerialized]
	private List<RoofBuilder.MeshTriangle> _buildResult;

	[NonSerialized]
	private bool _disableRoundnessRefresh;

	public bool DrawDebugLineIndex;

	public bool HasRoom(Room room)
	{
		if (Window.Shown && _encompassingRooms != null)
		{
			return _encompassingRooms.Contains(room);
		}
		return false;
	}

	public void Show(Roof roof)
	{
		BuildController.Instance.ClearBuild();
		_undo = new UndoObject.UndoAction(new List<Roof>(new Roof[1] { roof }));
		CurrentRoof = roof;
		_encompassingRooms = roof.RoofOf.OfType<Room>().ToHashSet();
		_outline = roof.Area.ToList();
		AreaRect = _outline.GetBounds();
		InitEditor(roof.RoofLine);
		InitTopdown();
		Window.Show();
		DestroyOnClose = false;
		HeightSlider.value = roof.Height;
		BulgeSlider.value = roof.Bulge;
		_buildResult = RoofBuilder.BuildRoof(_outline.ToArray(), GenerateRoofLine(), Roof.CheckRoofRoomIntersect(_outline, Roof.GetBounds(_outline), roof.Floor));
		GameSettings.Instance.ActiveFloor = roof.Floor;
		Furniture.UpdateEdgeDetection();
		GameSettings.Instance.sRoomManager.ChangeFloor();
		MaterialPreviewer.Instance.RefreshState();
		_lastStyle = new RoomStyle("", roof);
	}

	public string Show(Room[] rooms)
	{
		int? num = null;
		foreach (Room room in rooms)
		{
			if (room.Floor < 0)
			{
				return "RoofBasementError";
			}
			if (room.Floor >= GameSettings.MaxFloor)
			{
				return "RoofHighError";
			}
			if (room.Roofing != null)
			{
				return "RoofAlreadyPresentError";
			}
			if (!num.HasValue)
			{
				num = room.Floor;
			}
			else if (num.Value != room.Floor)
			{
				return "RoofAcrossFloorError";
			}
		}
		if (!num.HasValue)
		{
			return "RoofNoRoomError";
		}
		HashSet<Room> chosenRooms = new HashSet<Room>(rooms);
		Room r;
		int idx;
		if (FindFirstPoint(rooms, chosenRooms, out r, out idx) && FindPerimeter(r, idx, out _outline, chosenRooms, out _encompassingRooms))
		{
			HeightSlider.value = 1f;
			BulgeSlider.value = 1f;
			Vector2[] offset = _outline.GetOffset(0.1f);
			List<Room> rooms2 = GameSettings.Instance.sRoomManager.GetRooms();
			for (int j = 0; j < rooms2.Count; j++)
			{
				Room room2 = rooms2[j];
				if (room2.Floor == r.Floor && !_encompassingRooms.Contains(room2) && Utilities.IsInside(room2.Edges[0].Pos, offset))
				{
					_encompassingRooms.Add(room2);
				}
			}
			if (!rooms.All((Room x) => _encompassingRooms.Contains(x)))
			{
				return "RoofAdjacentError";
			}
			if (RoomCloneTool.Intersects(_outline.GetOffset(Roof.SideBuildDistance), rooms[0].Floor + 1, false, false, false, false) != RoomCloneTool.Intersection.None)
			{
				return "RoofIntersectError";
			}
			BuildController.Instance.ClearBuild();
			AreaRect = _outline.GetBounds();
			List<RoofBuilder.RoofEdge> list = RoofBuilder.SuggestRoofLine(_outline.ToArray(), false);
			List<RoofBuilder.RoofEdge[]> loops = RoofBuilder.FindLoops(list, false);
			RoofBuilder.CollapseLoops(list, loops);
			InitEditor(list);
			InitTopdown();
			RemoveStraights();
			Window.Show();
			DestroyOnClose = true;
			GameSettings.Instance.ActiveFloor = rooms[0].Floor + 1;
			Furniture.UpdateEdgeDetection();
			GameSettings.Instance.sRoomManager.ChangeFloor();
			BuildRoof();
			MaterialPreviewer.Instance.RefreshState();
			_lastStyle = null;
			return null;
		}
		return "RoofAdjacentError";
	}

	public void Finish()
	{
		if (CurrentRoof != null)
		{
			if (DestroyOnClose)
			{
				List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
				for (int i = 0; i < CurrentRoof.RoofOf.Count; i++)
				{
					List<Furniture> furnitures = ((Room)CurrentRoof.RoofOf[i]).GetFurnitures();
					for (int j = 0; j < furnitures.Count; j++)
					{
						Furniture furniture = furnitures[j];
						if (furniture.PokesThroughRoof)
						{
							list.Add(new UndoObject.UndoAction(furniture, false));
							furniture.DestroyGO();
						}
					}
				}
				list.Add(new UndoObject.UndoAction(true, CurrentRoof));
				GameSettings.Instance.AddUndo(list.ToArray());
			}
			if (NetworkManager.Instance.Connected)
			{
				NetworkMessaging.SendNewRoom(BuildingPrefab.SaveRoomsForNetwork(Array.Empty<Room>(), new Roof[1] { CurrentRoof }, false), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			AchievementController.SetInteraction(AchievementController.Mechanics.Roofs);
		}
		if (_undo != null)
		{
			GameSettings.Instance.AddUndo(_undo);
			_undo = null;
		}
		CurrentRoof = null;
		Window.Close();
	}

	private void ClearEditor()
	{
		foreach (RoofPointObject point in _points)
		{
			UnityEngine.Object.Destroy(point.gameObject);
		}
		foreach (RoofEdgeObject edge in _edges)
		{
			UnityEngine.Object.Destroy(edge.gameObject);
		}
		_points.Clear();
		_edges.Clear();
	}

	private void InitEditor(List<RoofBuilder.RoofEdge> edges)
	{
		if (edges.Count > 0)
		{
			Dictionary<RoofBuilder.RoofPoint, RoofPointObject> dictionary = new Dictionary<RoofBuilder.RoofPoint, RoofPointObject>();
			foreach (RoofBuilder.RoofPoint item in edges.SelectMany((RoofBuilder.RoofEdge x) => x.Points).Distinct())
			{
				dictionary[item] = AddPoint(item.Point);
			}
			{
				foreach (RoofBuilder.RoofEdge edge in edges)
				{
					AddEdge(dictionary[edge.A], dictionary[edge.B]);
				}
				return;
			}
		}
		AddPoint(Utilities.GetPolygonCentroid(_outline));
	}

	private void InitTopdown()
	{
		TopDownView.GetComponent<GUIToolTipper>().ToolTipValue = InputController.GetFullKeyBindString(InputController.Keys.TopDown, false);
		TopDownView.isOn = CameraScript.Instance.TopDown;
	}

	private void InitEditor(List<Roof.RoofEdge> edges)
	{
		ClearEditor();
		if (edges.Count == 1 && edges[0].A == edges[0].B)
		{
			AddPoint(edges[0].A.V);
			return;
		}
		Dictionary<Roof.RoofPoint, RoofPointObject> dictionary = new Dictionary<Roof.RoofPoint, RoofPointObject>();
		foreach (Roof.RoofPoint item in edges.SelectMany((Roof.RoofEdge x) => new Roof.RoofPoint[2] { x.A, x.B }).Distinct())
		{
			dictionary[item] = AddPoint(item.V);
		}
		for (int num = 0; num < edges.Count; num++)
		{
			Roof.RoofEdge roofEdge = edges[num];
			AddEdge(dictionary[roofEdge.A], dictionary[roofEdge.B]);
		}
	}

	public void TopdownToggle()
	{
		CameraScript.Instance.TopDown = TopDownView.isOn;
	}

	private void RefreshPositions()
	{
		for (int i = 0; i < _points.Count; i++)
		{
			_points[i].UpdatePosition();
		}
		for (int j = 0; j < _edges.Count; j++)
		{
			_edges[j].RefreshPosition();
		}
	}

	public static bool FindPerimeter(Room start, int edge, out List<Vector2> outline, HashSet<Room> chosenRooms, out HashSet<Room> edgeRooms)
	{
		outline = new List<Vector2>();
		edgeRooms = new HashSet<Room>();
		edgeRooms.Add(start);
		WallEdge wallEdge = start.Edges[edge];
		WallEdge wallEdge2 = wallEdge;
		HashSet<WallEdge> hashSet = new HashSet<WallEdge>();
		outline.Add(wallEdge2.Pos);
		while (true)
		{
			if (!hashSet.Add(wallEdge2))
			{
				if (wallEdge2 == wallEdge)
				{
					break;
				}
				return false;
			}
			WallEdge edge2 = wallEdge2;
			WallEdge next = wallEdge2.Links.FirstOrDefaultOf((KeyValuePair<IRoom, WallEdge> x) => chosenRooms.Contains(x.Key) && CanTraverse(edge2, x.Value, chosenRooms), (KeyValuePair<IRoom, WallEdge> x) => x.Value);
			if (next == null)
			{
				return false;
			}
			edgeRooms.Add((Room)wallEdge2.Links.First((KeyValuePair<IRoom, WallEdge> x) => x.Value == next).Key);
			wallEdge2 = next;
			outline.Add(wallEdge2.Pos);
		}
		outline.CleanUpPolygon();
		return true;
	}

	public static bool FindPerimeterEdge(Room start, int edge, out List<WallEdge> outline, HashSet<Room> chosenRooms, out HashSet<Room> edgeRooms)
	{
		outline = new List<WallEdge>();
		edgeRooms = new HashSet<Room>();
		edgeRooms.Add(start);
		WallEdge wallEdge = start.Edges[edge];
		WallEdge wallEdge2 = wallEdge;
		HashSet<WallEdge> hashSet = new HashSet<WallEdge>();
		outline.Add(wallEdge2);
		while (true)
		{
			if (!hashSet.Add(wallEdge2))
			{
				if (wallEdge2 == wallEdge)
				{
					break;
				}
				return false;
			}
			WallEdge edge2 = wallEdge2;
			WallEdge next = wallEdge2.Links.FirstOrDefaultOf((KeyValuePair<IRoom, WallEdge> x) => chosenRooms.Contains(x.Key) && CanTraverse(edge2, x.Value, chosenRooms), (KeyValuePair<IRoom, WallEdge> x) => x.Value);
			if (next == null)
			{
				return false;
			}
			edgeRooms.Add((Room)wallEdge2.Links.First((KeyValuePair<IRoom, WallEdge> x) => x.Value == next).Key);
			wallEdge2 = next;
			outline.Add(wallEdge2);
		}
		for (int num = 0; num < outline.Count; num++)
		{
			WallEdge wallEdge3 = outline[num];
			WallEdge wallEdge4 = outline[(num + 1) % outline.Count];
			if (wallEdge3 == wallEdge4)
			{
				outline.RemoveAt(num);
				num--;
			}
		}
		return true;
	}

	public static bool CanTraverse(WallEdge from, WallEdge to, HashSet<Room> chosenRooms)
	{
		IRoom room = to.Links.FirstOrDefaultOf((KeyValuePair<IRoom, WallEdge> x) => x.Value == from, (KeyValuePair<IRoom, WallEdge> x) => x.Key);
		if (room != null)
		{
			return !chosenRooms.Contains(room);
		}
		return true;
	}

	public static bool FindFirstPoint(Room[] rooms, HashSet<Room> chosenRooms, out Room r, out int idx)
	{
		r = null;
		idx = 0;
		foreach (Room room in rooms)
		{
			for (int j = 0; j < room.Edges.Count; j++)
			{
				if (room.Edges[j].Links.Count((KeyValuePair<IRoom, WallEdge> x) => chosenRooms.Contains(x.Key)) == 1)
				{
					r = room;
					idx = j;
					return true;
				}
			}
		}
		return false;
	}

	private void Start()
	{
		Window.OnClose = delegate
		{
			ClearEditor();
			_buildResult = null;
			if (CurrentRoof != null)
			{
				if (DestroyOnClose)
				{
					CurrentRoof.DestroyGO();
				}
				if (_undo != null)
				{
					new UndoObject(_undo).Execute();
					_undo = null;
				}
				CurrentRoof = null;
			}
			MaterialPreviewer.Instance.RefreshState();
		};
	}

	public Vector2 MakeValidPosition(Vector2 p)
	{
		if (Utilities.IsInside(p, _outline))
		{
			return p;
		}
		float num = float.MaxValue;
		Vector2 result = p;
		for (int i = 0; i < _outline.Count; i++)
		{
			Vector2 a = _outline[i];
			Vector2 b = _outline[(i + 1) % _outline.Count];
			Vector2 vector = Utilities.ProjectToLineEndlessClamped(p, a, b);
			float sqrMagnitude = (vector - p).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = vector;
			}
		}
		return result;
	}

	public void ShowNow()
	{
		if (Window.Shown)
		{
			Window.Close();
			return;
		}
		Roof[] array = SelectorController.Instance.Selected.OfType<Roof>().ToArray();
		if (array.Length == 1)
		{
			Show(array[0]);
			return;
		}
		Room[] array2 = SelectorController.Instance.Selected.OfType<Room>().ToArray();
		array = array2.Select((Room x) => x.Roofing).Distinct().ToArray();
		if (array.Length == 1 && array[0] != null)
		{
			Show(array[0]);
			return;
		}
		string text = Show(array2);
		if (text != null)
		{
			WindowManager.Instance.ShowMessageBox(text.Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private void Update()
	{
		if (CurrentRoof != null && MaterialPreviewer.Instance.gameObject.activeSelf && (_lastStyle == null || !_lastStyle.Match(MaterialPreviewer.Instance.GetActiveStyle())))
		{
			_lastStyle = MaterialPreviewer.Instance.GetActiveStyle();
			_lastStyle.Apply(CurrentRoof, null);
		}
		for (int i = 0; i < _edges.Count; i++)
		{
			_edges[i].LowLight(false);
		}
		for (int j = 0; j < _points.Count; j++)
		{
			_points[j].LowLight(false);
		}
		Vector2 mouseProj = HUD.Instance.GetMouseProj(HeightSlider.value);
		RoofPointObject pointAt = GetPointAt(mouseProj);
		if (pointAt != null)
		{
			pointAt.LowLight(true);
			CurrentHighlight = pointAt;
		}
		else
		{
			RoofEdgeObject lineAt = GetLineAt(mouseProj);
			if (lineAt != null)
			{
				lineAt.LowLight(true);
				CurrentHighlight = lineAt;
			}
			else
			{
				CurrentHighlight = null;
			}
		}
		if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !GUICheck.OverGUI && AreaRect.Expand(0.5f, 0.5f).Contains(mouseProj))
		{
			HandleClickDown(mouseProj, (!Input.GetMouseButtonDown(0)) ? 1 : 0);
		}
		if (_dragging)
		{
			mouseProj = MakeValidPosition(FixMouseGrid(mouseProj + _initialOffset));
			if (_pointHit != null)
			{
				_pointHit.SetPosition(mouseProj);
			}
			else if (_edgeHit != null)
			{
				Vector3 v = _edgeHit.A.transform.position - _edgeHit.B.transform.position;
				_edgeHit.A.SetPosition(mouseProj);
				_edgeHit.B.SetPosition(MakeValidPosition(mouseProj - v.FlattenVector3()));
			}
		}
		else if (_clicked && (mouseProj - _initialClick).magnitude > ClickRadius)
		{
			_dragging = true;
		}
		if ((_dragging || _clicked) && Input.GetMouseButtonUp(_clickButton))
		{
			_clicked = false;
			_dragging = false;
			BuildRoof();
		}
		RefreshPositions();
	}

	private Vector2 FixMouseGrid(Vector2 pos)
	{
		if (!SnapToGrid.isOn)
		{
			return pos;
		}
		return BuildController.Instance.CorrectMousePos(pos);
	}

	public RoofPointObject AddPoint(Vector2 pos)
	{
		RoofPointObject roofPointObject = UnityEngine.Object.Instantiate(DotPrefab);
		roofPointObject.Init(this, pos);
		_points.Add(roofPointObject);
		return roofPointObject;
	}

	public RoofEdgeObject AddEdge(RoofPointObject a, RoofPointObject b)
	{
		if (_edges.None((RoofEdgeObject x) => (x.A == a && x.B == b) || (x.B == a && x.A == b)))
		{
			RoofEdgeObject roofEdgeObject = UnityEngine.Object.Instantiate(LinePrefab);
			roofEdgeObject.Init(this, a, b);
			_edges.Add(roofEdgeObject);
			return roofEdgeObject;
		}
		return null;
	}

	public void HandleClick()
	{
		SelectorController.CanClick = false;
	}

	public void ChangeRoundness()
	{
		if (!_disableRoundnessRefresh && _buildResult != null)
		{
			_disableRoundnessRefresh = true;
			if (Mathf.Abs(BulgeSlider.value - 1f) < 0.1f)
			{
				BulgeSlider.value = 1f;
			}
			MakeRoofMesh();
			CurrentRoof.Bulge = BulgeSlider.value;
			_disableRoundnessRefresh = false;
		}
	}

	public void BuildRoof()
	{
		bool flag = _points.Count > 0;
		if (flag)
		{
			for (int i = 0; i < _edges.Count; i++)
			{
				RoofEdgeObject roofEdgeObject = _edges[i];
				Vector2 p = roofEdgeObject.A.P;
				Vector2 p2 = roofEdgeObject.B.P;
				for (int j = 0; j < _outline.Count; j++)
				{
					Vector2 vector = _outline[j];
					Vector2 vector2 = _outline[(j + 1) % _outline.Count];
					Vector2 res;
					if (Utilities.LinesIntersect(p, p2, vector, vector2, false, true) && (!Utilities.ProjectToLine(p, vector, vector2, out res) || !((res - p).magnitude < 0.001f)) && (!Utilities.ProjectToLine(p2, vector, vector2, out res) || !((res - p2).magnitude < 0.001f)))
					{
						roofEdgeObject.Error(true);
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}
		_buildResult = (flag ? RoofBuilder.BuildRoof(_outline.ToArray(), GenerateRoofLine(), Roof.CheckRoofRoomIntersect(_outline, Roof.GetBounds(_outline), GameSettings.Instance.ActiveFloor)) : null);
		FinalizeButton.interactable = _buildResult != null;
		FinalizeLabel.text = ((_buildResult != null) ? "Finishroof".Loc() : "Invalidroof".Loc());
		MakeRoofMesh();
	}

	private void MakeRoofMesh()
	{
		if (_buildResult != null)
		{
			if (CurrentRoof == null)
			{
				CurrentRoof = UnityEngine.Object.Instantiate(RoofPrefab);
				CurrentRoof.Init(_encompassingRooms.Cast<IRoom>().ToList(), _outline.ToList(), _encompassingRooms.First().Floor + 1);
				CurrentRoof.Bulge = BulgeSlider.value;
				CurrentRoof.Height = HeightSlider.value;
			}
			CurrentRoof.SetRoofLine(_points, _edges);
			Mesh[] array = RoofBuilder.BuildRoofMesh(RoofBuilder.Subdivide(BulgeSlider.value, _buildResult), HeightSlider.value / 2f, false);
			CurrentRoof.SetRoof(array[0]);
			CurrentRoof.SetGable((array.Length > 1) ? array[1] : null);
			CurrentRoof.transform.localScale = new Vector3(1f, HeightSlider.value, 1f);
		}
	}

	public void ChangeHeight()
	{
		if (_buildResult != null)
		{
			CurrentRoof.Height = HeightSlider.value;
			if (_buildResult.Any((RoofBuilder.MeshTriangle x) => x.Gable))
			{
				Mesh[] array = RoofBuilder.BuildRoofMesh(RoofBuilder.Subdivide(BulgeSlider.value, _buildResult), HeightSlider.value / 2f, true);
				CurrentRoof.SetGable((array == null) ? null : array[0]);
			}
			CurrentRoof.transform.localScale = new Vector3(1f, HeightSlider.value, 1f);
			RefreshPositions();
		}
	}

	private void OnDrawGizmos()
	{
		if (_buildResult == null)
		{
			return;
		}
		for (int i = 0; i < _buildResult.Count; i++)
		{
			RoofBuilder.MeshTriangle meshTriangle = _buildResult[i];
			Gizmos.color = ((meshTriangle.Rect != null) ? Color.green : (meshTriangle.FromRoofLine ? Color.cyan : Color.red));
			if (DrawDebugLineIndex)
			{
				Gizmos.color = (Gizmos.color * ((float)i / ((float)_buildResult.Count - 1f))).Alpha(1f);
			}
			Matrix4x4 matrix4x = ((CurrentRoof != null) ? CurrentRoof.transform.localToWorldMatrix : Matrix4x4.TRS(Vector3.up * 2f, Quaternion.identity, Vector3.one));
			if (meshTriangle.Rect != null)
			{
				RoofBuilder.MeshTriangle meshTriangle2 = _buildResult[i + 1];
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle.A.FinalPoint), matrix4x.MultiplyPoint(meshTriangle.B.FinalPoint));
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle.B.FinalPoint), matrix4x.MultiplyPoint(meshTriangle.C.FinalPoint));
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle.C.FinalPoint), matrix4x.MultiplyPoint(meshTriangle2.B.FinalPoint));
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle2.B.FinalPoint), matrix4x.MultiplyPoint(meshTriangle.A.FinalPoint));
				i++;
			}
			else
			{
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle.A.FinalPoint), matrix4x.MultiplyPoint(meshTriangle.B.FinalPoint));
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle.B.FinalPoint), matrix4x.MultiplyPoint(meshTriangle.C.FinalPoint));
				Gizmos.DrawLine(matrix4x.MultiplyPoint(meshTriangle.C.FinalPoint), matrix4x.MultiplyPoint(meshTriangle.A.FinalPoint));
			}
		}
	}

	private List<RoofBuilder.RoofEdge> GenerateRoofLine()
	{
		Dictionary<RoofPointObject, RoofBuilder.RoofPoint> dictionary = new Dictionary<RoofPointObject, RoofBuilder.RoofPoint>();
		for (int i = 0; i < _points.Count; i++)
		{
			RoofPointObject roofPointObject = _points[i];
			roofPointObject.Error(false);
			RoofBuilder.RoofPoint value = new RoofBuilder.RoofPoint(roofPointObject.P, true, roofPointObject);
			dictionary[roofPointObject] = value;
		}
		List<RoofBuilder.RoofEdge> list = new List<RoofBuilder.RoofEdge>();
		for (int j = 0; j < _edges.Count; j++)
		{
			RoofEdgeObject roofEdgeObject = _edges[j];
			roofEdgeObject.Error(false);
			list.Add(new RoofBuilder.RoofEdge(dictionary[roofEdgeObject.A], dictionary[roofEdgeObject.B], roofEdgeObject));
		}
		if (list.Count == 0 && _points.Count > 0)
		{
			RoofBuilder.RoofPoint value2 = dictionary.First().Value;
			list.Add(new RoofBuilder.RoofEdge(value2, value2));
		}
		return list;
	}

	public void AlignPoints()
	{
		List<Vector2> list = new List<Vector2>();
		Vector2[] offset = _outline.GetOffset(-0.01f);
		for (int i = 0; i < _points.Count; i++)
		{
			RoofPointObject roofPointObject = _points[i];
			Vector2 p = roofPointObject.P;
			list.AddRange(_outline);
			for (int j = 0; j < _outline.Count; j++)
			{
				Vector2 vector = _outline[j];
				Vector2 vector2 = _outline[(j + 1) % _outline.Count];
				if (Utilities.IsLeft(vector, vector2, p) > 0)
				{
					list.Add(Utilities.ProjectToLineEndlessClamped(p, vector, vector2));
				}
			}
			bool flag = false;
			for (int k = 0; k < _outline.Count; k++)
			{
				Vector2 vector3 = _outline[k];
				Vector2 vector4 = _outline[(k + 1) % _outline.Count];
				Vector2 res;
				if (Utilities.ProjectToLine(p, vector3, vector4, out res) && (res - p).magnitude < 0.01f)
				{
					roofPointObject.SetPosition((vector3 + vector4) * 0.5f);
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			Vector2 vector5 = Vector2.zero;
			float num = -1f;
			for (int l = 0; l < list.Count; l++)
			{
				Vector2 vector6 = list[l];
				for (int m = l + 1; m < list.Count; m++)
				{
					Vector2 vector7 = list[m];
					Vector2 vector8 = (vector6 + vector7) * 0.5f;
					float num2 = (vector6 - vector7).magnitude / 4f;
					float magnitude = (p - vector8).magnitude;
					if (magnitude <= num2)
					{
						magnitude *= num2;
						if (num < 0f || magnitude < num)
						{
							num = magnitude;
							vector5 = vector8;
						}
					}
				}
			}
			if (num > 0f && Utilities.IsInside(vector5, offset))
			{
				roofPointObject.SetPosition(vector5);
			}
			list.Clear();
		}
		BuildRoof();
	}

	public void HandleClickDown(Vector2 mp, int button)
	{
		_initialClick = MakeValidPosition(mp);
		if (_pointHit != null)
		{
			_pointHit.Highlight(false);
		}
		_lastPointHit = _pointHit;
		_clickButton = button;
		_pointHit = CurrentHighlight as RoofPointObject;
		_edgeHit = ((_pointHit == null) ? (CurrentHighlight as RoofEdgeObject) : null);
		if (_pointHit != null)
		{
			_pointHit.Highlight(true);
			_initialOffset = _pointHit.P - _initialClick;
		}
		else if (_edgeHit != null)
		{
			_initialOffset = _edgeHit.A.P - _initialClick;
		}
		if (_clickButton == 0 && Input.GetKey(KeyCode.LeftShift))
		{
			if (_pointHit != null && _lastPointHit != null && _lastPointHit != _pointHit)
			{
				AddEdge(_pointHit, _lastPointHit);
			}
			else if (_edgeHit != null)
			{
				RoofPointObject roofPointObject = AddPoint(FixMouseGrid(_initialClick));
				AddEdge(_edgeHit.A, roofPointObject);
				AddEdge(roofPointObject, _edgeHit.B);
				_edges.Remove(_edgeHit);
				UnityEngine.Object.Destroy(_edgeHit.gameObject);
				_edgeHit = null;
				_pointHit = roofPointObject;
				_initialOffset = Vector2.zero;
				_pointHit.Highlight(true);
				_clicked = true;
			}
			else if (_pointHit != null)
			{
				_pointHit.Highlight(false);
				RoofPointObject roofPointObject2 = AddPoint(FixMouseGrid(_initialClick));
				AddEdge(_pointHit, roofPointObject2);
				_pointHit = roofPointObject2;
				_initialOffset = Vector2.zero;
				_pointHit.Highlight(true);
				_clicked = true;
			}
			else
			{
				RoofPointObject roofPointObject3 = AddPoint(FixMouseGrid(_initialClick));
				if (_lastPointHit != null)
				{
					AddEdge(_lastPointHit, roofPointObject3);
				}
				_pointHit = roofPointObject3;
				_initialOffset = Vector2.zero;
				_pointHit.Highlight(true);
				_clicked = true;
			}
			BuildRoof();
		}
		else
		{
			if (_pointHit == null && _edgeHit == null)
			{
				return;
			}
			if (_clickButton == 1)
			{
				if (_pointHit != null)
				{
					int num = 0;
					RoofPointObject roofPointObject4 = null;
					RoofPointObject b = null;
					for (int i = 0; i < _edges.Count; i++)
					{
						RoofEdgeObject roofEdgeObject = _edges[i];
						if (roofEdgeObject.A == _pointHit || roofEdgeObject.B == _pointHit)
						{
							num++;
							RoofPointObject roofPointObject5 = ((roofEdgeObject.A == _pointHit) ? roofEdgeObject.B : roofEdgeObject.A);
							if (roofPointObject4 == null)
							{
								roofPointObject4 = roofPointObject5;
							}
							else
							{
								b = roofPointObject5;
							}
							_edges.RemoveAt(i);
							UnityEngine.Object.Destroy(roofEdgeObject.gameObject);
							i--;
						}
					}
					_points.Remove(_pointHit);
					UnityEngine.Object.Destroy(_pointHit.gameObject);
					_pointHit = null;
					if (Input.GetKey(KeyCode.LeftShift) && num == 2)
					{
						AddEdge(roofPointObject4, b);
					}
					BuildRoof();
					return;
				}
				if (_edgeHit != null)
				{
					if (Input.GetKey(KeyCode.LeftShift))
					{
						RoofPointObject roofPointObject6 = AddPoint((_edgeHit.A.P + _edgeHit.B.P) * 0.5f);
						int num2 = _edges.Count;
						for (int j = 0; j < num2; j++)
						{
							RoofEdgeObject roofEdgeObject2 = _edges[j];
							if (!(roofEdgeObject2 == _edgeHit))
							{
								if (roofEdgeObject2.A == _edgeHit.A || roofEdgeObject2.A == _edgeHit.B)
								{
									UnityEngine.Object.Destroy(roofEdgeObject2.gameObject);
									_edges.RemoveAt(j);
									j--;
									num2--;
									AddEdge(roofPointObject6, roofEdgeObject2.B);
								}
								else if (roofEdgeObject2.B == _edgeHit.A || roofEdgeObject2.B == _edgeHit.B)
								{
									UnityEngine.Object.Destroy(roofEdgeObject2.gameObject);
									_edges.RemoveAt(j);
									j--;
									num2--;
									AddEdge(roofEdgeObject2.A, roofPointObject6);
								}
							}
						}
						_points.Remove(_edgeHit.A);
						_points.Remove(_edgeHit.B);
						UnityEngine.Object.Destroy(_edgeHit.A.gameObject);
						UnityEngine.Object.Destroy(_edgeHit.B.gameObject);
					}
					_edges.Remove(_edgeHit);
					UnityEngine.Object.Destroy(_edgeHit.gameObject);
					_edgeHit = null;
					BuildRoof();
					return;
				}
			}
			_clicked = true;
		}
	}

	private RoofPointObject GetPointAt(Vector2 p)
	{
		for (int i = 0; i < _points.Count; i++)
		{
			RoofPointObject roofPointObject = _points[i];
			if ((p - roofPointObject.P).magnitude < ClickRadius)
			{
				return roofPointObject;
			}
		}
		return null;
	}

	private RoofEdgeObject GetLineAt(Vector2 p)
	{
		foreach (RoofEdgeObject edge in _edges)
		{
			Vector2 res;
			if (Utilities.ProjectToLine(p, edge.A.P, edge.B.P, out res) && (p - res).magnitude < ClickRadius)
			{
				return edge;
			}
		}
		return null;
	}

	private Dictionary<RoofPointObject, RoofNode> GetRoofPointNetwork(List<RoofEdgeObject> edges)
	{
		Dictionary<RoofPointObject, RoofNode> dictionary = new Dictionary<RoofPointObject, RoofNode>();
		foreach (RoofEdgeObject edge in edges)
		{
			RoofNode orAdd = dictionary.GetOrAdd(edge.A, (RoofPointObject x) => new RoofNode(x));
			RoofNode orAdd2 = dictionary.GetOrAdd(edge.B, (RoofPointObject x) => new RoofNode(x));
			orAdd.Connections.Add(orAdd2, edge);
			orAdd2.Connections.Add(orAdd, edge);
		}
		return dictionary;
	}

	public void Straighten()
	{
		List<RoofNode> list = GetRoofPointNetwork(_edges).Values.Where((RoofNode x) => x.Connections.Count != 2).ToList();
		list.ForEach(delegate(RoofNode x)
		{
			x.EndPoint = true;
		});
		List<List<RoofNode>> list2 = new List<List<RoofNode>>();
		foreach (RoofNode item in list)
		{
			foreach (KeyValuePair<RoofNode, RoofEdgeObject> connection in item.Connections)
			{
				List<RoofNode> list3 = new List<RoofNode>();
				list3.Add(item);
				list3.AddRange(GetLine(item, connection.Key));
				if (list3.Count > 2)
				{
					list2.Add(list3);
				}
			}
		}
		foreach (List<RoofNode> item2 in list2.OrderByDescending((List<RoofNode> x) => x.Count))
		{
			if (item2.Any((RoofNode x) => x.visited))
			{
				continue;
			}
			Vector2 p = item2[0].Point.P;
			Vector2 p2 = item2[item2.Count - 1].Point.P;
			for (int num = 1; num < item2.Count - 1; num++)
			{
				RoofNode roofNode = item2[num];
				roofNode.visited = true;
				Vector2 vector = Utilities.ProjectToLineEndless(roofNode.Point.P, p, p2);
				if (Utilities.IsInside(vector, _outline))
				{
					roofNode.Point.SetPosition(vector);
				}
			}
		}
		BuildRoof();
	}

	public void RemoveStraights()
	{
		List<RoofNode> list = GetRoofPointNetwork(_edges).Values.Where((RoofNode x) => x.Connections.Count != 2).ToList();
		list.ForEach(delegate(RoofNode x)
		{
			x.EndPoint = true;
		});
		List<List<RoofNode>> list2 = new List<List<RoofNode>>();
		foreach (RoofNode item in list)
		{
			foreach (KeyValuePair<RoofNode, RoofEdgeObject> connection in item.Connections)
			{
				List<RoofNode> list3 = new List<RoofNode>();
				list3.Add(item);
				list3.AddRange(GetLine(item, connection.Key));
				if (list3.Count > 2)
				{
					list2.Add(list3);
				}
			}
		}
		foreach (List<RoofNode> item2 in list2.OrderByDescending((List<RoofNode> x) => x.Count))
		{
			if (item2.Any((RoofNode x) => x.visited))
			{
				continue;
			}
			for (int num = 0; num < item2.Count - 1; num++)
			{
				RoofNode roofNode = item2[num];
				RoofNode roofNode2 = item2[num + 1];
				if (num > 0)
				{
					roofNode.visited = true;
				}
				if (num < item2.Count - 2)
				{
					_points.Remove(roofNode2.Point);
					UnityEngine.Object.Destroy(roofNode2.Point.gameObject);
				}
				RoofEdgeObject roofEdgeObject = roofNode.Connections[roofNode2];
				_edges.Remove(roofEdgeObject);
				UnityEngine.Object.Destroy(roofEdgeObject.gameObject);
			}
			AddEdge(item2[0].Point, item2[item2.Count - 1].Point);
		}
	}

	private IEnumerable<RoofNode> GetLine(RoofNode from, RoofNode node)
	{
		while (node.Connections.Count == 2)
		{
			yield return node;
			RoofNode roofNode = node.Connections.Keys.FirstOrDefault((RoofNode x) => x != from);
			if (roofNode == null || Mathf.Abs(Vector2.Dot((node.Point.P - from.Point.P).normalized, (roofNode.Point.P - node.Point.P).normalized)) < 0.6f)
			{
				yield break;
			}
			from = node;
			node = roofNode;
		}
		yield return node;
	}
}
