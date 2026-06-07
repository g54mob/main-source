using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using UnityEngine;
using UnityEngine.Rendering;

public class PathBuilder : MonoBehaviour
{
	public static float MinWidth = 2f;

	public static float MaxWidth = 3f;

	public static float PathCost = 100f;

	public bool Bezier;

	public bool DeleteMode;

	public Mesh LineHelperMesh;

	public Mesh CylinderMesh;

	public Material LineHelperMat;

	public Material LineHelperMat2;

	public Material CylinderMat;

	private float _currentWidth;

	private float _cost;

	public PathCubeObject PathBuildPrefab;

	private List<PathCubeObject> _currentPath = new List<PathCubeObject>();

	public static PathBuilder Instance;

	public Color BuildHUDColor;

	[NonSerialized]
	private List<List<Vector2>> _outlines = new List<List<Vector2>>();

	private Vector2 _lastM;

	private bool _shiftGrid;

	private Matrix4x4[] _allPaths = new Matrix4x4[512];

	private int _allPathCount;

	private Vector3 _pos = Vector3.zero;

	private Vector3 _scale = new Vector3(2f, 0.05f, 2f);

	private bool _renderSelf = true;

	private HashSet<PathController.PathPoint> _deleteCache = new HashSet<PathController.PathPoint>();

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		base.enabled = false;
	}

	private void InitAllPaths()
	{
		int c = 0;
		HashSet<PathController.PathPoint> hashSet = new HashSet<PathController.PathPoint>();
		foreach (PathObject allPathObject in GameSettings.Instance.sRoomManager.PathController.AllPathObjects)
		{
			if (allPathObject.Path.Count > 0)
			{
				hashSet.Clear();
				if (DiscoverPath(null, allPathObject.Path.First(), hashSet, ref c))
				{
					break;
				}
			}
		}
		_allPathCount = c;
	}

	private bool DiscoverPath(PathController.PathPoint from, PathController.PathPoint p, HashSet<PathController.PathPoint> visited, ref int c)
	{
		if (visited.Add(p))
		{
			for (int i = 0; i < p.Connections.Count; i++)
			{
				KeyValuePair<PathController.PathPoint, float> keyValuePair = p.Connections[i];
				if (from != keyValuePair.Key && !visited.Contains(keyValuePair.Key) && AddPath(p.Point, keyValuePair.Key.Point, ref c))
				{
					return true;
				}
			}
			for (int j = 0; j < p.Connections.Count; j++)
			{
				KeyValuePair<PathController.PathPoint, float> keyValuePair2 = p.Connections[j];
				if (from != keyValuePair2.Key && DiscoverPath(p, keyValuePair2.Key, visited, ref c))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool AddPath(Vector2 a, Vector2 b, ref int c)
	{
		Vector2 v = a - b;
		if (v.x.Appx(0f) && v.y.Appx(0f))
		{
			return false;
		}
		_allPaths[c] = Matrix4x4.TRS(((a + b) * 0.5f).ToVector3(0f), Quaternion.LookRotation(v.ToVector3(0f)), new Vector3(0.05f, 0.05f, v.magnitude));
		c++;
		return c == _allPaths.Length;
	}

	private void OnPreCull()
	{
		if (_allPathCount > 0)
		{
			if (!SystemInfo.supportsInstancing)
			{
				for (int i = 0; i < _allPathCount; i++)
				{
					Graphics.DrawMesh(LineHelperMesh, _allPaths[i], LineHelperMat2, 0, CameraScript.Instance.mainCam, 0, null, ShadowCastingMode.Off);
				}
			}
			else
			{
				Graphics.DrawMeshInstanced(LineHelperMesh, 0, LineHelperMat2, _allPaths, _allPathCount, null, ShadowCastingMode.Off, false, 0, CameraScript.Instance.mainCam);
			}
		}
		if (_renderSelf)
		{
			Graphics.DrawMesh(CylinderMesh, Matrix4x4.TRS(_pos, Quaternion.identity, _scale), CylinderMat, 0, CameraScript.Instance.mainCam, 0);
		}
	}

	public void Show(bool bezier, bool delete)
	{
		Deactivate();
		if (!delete)
		{
			BuildingPrefab b = BuildingPrefab.SaveRooms(GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.Floor == 0).ToArray(), new Roof[0], false, true);
			_outlines = RoomManager.CombineRoomEdges(b, 0, 0f, false);
		}
		base.enabled = true;
		Bezier = bezier;
		DeleteMode = delete;
		_renderSelf = !delete;
		WindowManager.SetCursorOverride("Place");
		MaterialPreviewer.Instance.RefreshState();
		InitAllPaths();
		AchievementController.SetInteraction(AchievementController.Mechanics.Paths);
	}

	private void OnEnable()
	{
		_cost = 0f;
		_currentWidth = MinWidth;
		BuildController.Instance.ClearBuild(false, false, false, false, true);
		GameSettings.Instance.ActiveFloor = 0;
		Furniture.UpdateEdgeDetection();
		GameSettings.Instance.sRoomManager.ChangeFloor();
		if (!DeleteMode)
		{
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.ShiftGrid);
		}
	}

	private void OnDisable()
	{
		if (!GameSettings.IsQuitting)
		{
			_shiftGrid = false;
			if (HUD.Instance != null)
			{
				HUD.Instance.ShortcutPanel.Hide();
				ClearPaths();
				BuildingHUD.Instance.Enable(false, false, false);
				CostDisplay.Instance.Hide();
				HUD.Instance.UpdateBorderOverlay();
			}
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void DrawLine(Vector2 a, Vector2 b, Color? c = null, float y = 0f, float w = 0.2f)
	{
		Vector2 v = a - b;
		if (c.HasValue)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetColor("_Color", c.Value);
			Graphics.DrawMesh(LineHelperMesh, Matrix4x4.TRS(((a + b) * 0.5f).ToVector3(y), Quaternion.LookRotation(v.ToVector3(0f)), new Vector3(w, w, v.magnitude)), LineHelperMat, 0, CameraScript.Instance.mainCam, 0, materialPropertyBlock);
		}
		else
		{
			Graphics.DrawMesh(LineHelperMesh, Matrix4x4.TRS(((a + b) * 0.5f).ToVector3(y), Quaternion.LookRotation(v.ToVector3(0f)), new Vector3(w, w, v.magnitude)), LineHelperMat, 0, CameraScript.Instance.mainCam);
		}
	}

	private void ClearPaths()
	{
		_currentPath.ForEach(delegate(PathCubeObject x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		_currentPath.Clear();
	}

	private void Deactivate()
	{
		WindowManager.SetCursorOverride(null);
		base.enabled = false;
		MaterialPreviewer.Instance.RefreshState();
	}

	public static void FindDeletionSegment(PathController.PathPoint a, PathController.PathPoint b, HashSet<PathController.PathPoint> res, HashSet<PathController.PathPoint> allowed = null)
	{
		res.Add(a);
		res.Add(b);
		PathController.PathPoint nextPoint = GetNextPoint(a, b, allowed);
		if (nextPoint != null)
		{
			FindPath(nextPoint, a, a, res, allowed);
		}
		nextPoint = GetNextPoint(b, a, allowed);
		if (nextPoint != null)
		{
			FindPath(nextPoint, b, b, res, allowed);
		}
	}

	private static PathController.PathPoint GetNextPoint(PathController.PathPoint p, PathController.PathPoint other, HashSet<PathController.PathPoint> allowed)
	{
		if (allowed == null && p.Connections.Count != 2)
		{
			return null;
		}
		PathController.PathPoint pathPoint = null;
		for (int i = 0; i < p.Connections.Count; i++)
		{
			PathController.PathPoint key = p.Connections[i].Key;
			if (key != other && (allowed == null || allowed.Contains(key)))
			{
				if (pathPoint != null)
				{
					return null;
				}
				pathPoint = key;
			}
		}
		return pathPoint;
	}

	private void FindCurrentDelete()
	{
		Vector2 p = HUD.Instance.GetMouseProj();
		PathController pathController = GameSettings.Instance.sRoomManager.PathController;
		_deleteCache.Clear();
		PathController.PathPoint[] path = pathController.GetPath(ref p, 1f, true);
		if (path != null)
		{
			FindDeletionSegment(path[0], path[1], _deleteCache);
		}
	}

	private static void FindPath(PathController.PathPoint node, PathController.PathPoint from, PathController.PathPoint original, HashSet<PathController.PathPoint> res, HashSet<PathController.PathPoint> allowed)
	{
		if (node == original || (allowed != null && !allowed.Contains(node)))
		{
			return;
		}
		res.Add(node);
		if (node.Connections.Count == 2)
		{
			FindPath(node.Connections.FirstOrDefaultOf((KeyValuePair<PathController.PathPoint, float> x) => x.Key != from, (KeyValuePair<PathController.PathPoint, float> x) => x.Key), node, original, res, allowed);
		}
	}

	private void DrawDeletionPath()
	{
		foreach (PathController.PathPoint item in _deleteCache)
		{
			for (int i = 0; i < item.Connections.Count; i++)
			{
				PathController.PathPoint key = item.Connections[i].Key;
				if (item.ID > key.ID && _deleteCache.Contains(key))
				{
					DrawLine(item.Point, key.Point);
				}
			}
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.FreezeGame)
		{
			return;
		}
		bool flag = !GUICheck.OverGUI;
		if (DeleteMode)
		{
			if (!CameraScript.WasDragging && flag && Input.GetMouseButtonUp(1))
			{
				base.enabled = false;
			}
			FindCurrentDelete();
			DrawDeletionPath();
			if (flag && Input.GetMouseButtonUp(0) && _deleteCache.Count > 0)
			{
				UISoundFX.PlaySFX("PlaceWallRev", true);
				GameSettings.Instance.AddUndo(new UndoObject.UndoAction(_deleteCache));
				GameSettings.Instance.sRoomManager.PathController.DeletePath(_deleteCache);
				_deleteCache.Clear();
				InitAllPaths();
			}
			return;
		}
		if (InputController.GetKeyDown(InputController.Keys.ShiftGrid))
		{
			_shiftGrid = !_shiftGrid;
		}
		if (!CameraScript.WasDragging && flag && Input.GetMouseButtonUp(1))
		{
			if (_currentPath.Count <= 0)
			{
				Deactivate();
				return;
			}
			UISoundFX.PlaySFX("PlaceWallRev", true);
			UnityEngine.Object.Destroy(_currentPath[_currentPath.Count - 1].gameObject);
			_currentPath.RemoveAt(_currentPath.Count - 1);
			if (_currentPath.Count > 0)
			{
				_cost -= GetCost(_currentPath[_currentPath.Count - 1].PathCube.localScale.z);
			}
			else
			{
				_cost = 0f;
			}
		}
		bool autoFinish = false;
		Vector2[] snapped;
		Vector2 vector = CheckSnap(HUD.Instance.GetMouseProj(), out snapped, ref autoFinish);
		if (snapped != null)
		{
			if (snapped[0] == snapped[1])
			{
				_scale = new Vector3(3f, _scale.y, 3f);
			}
			else
			{
				for (int i = 0; i < snapped.Length - 1; i++)
				{
					DrawLine(snapped[i], snapped[i + 1]);
				}
				_scale = new Vector3(2f, _scale.y, 2f);
			}
		}
		else
		{
			_scale = new Vector3(2f, _scale.y, 2f);
		}
		if (_currentPath.Count > 0)
		{
			Vector2 a = _currentPath[_currentPath.Count - 1].transform.position.FlattenVector3();
			foreach (RoomSegment roomSegment in GameSettings.Instance.sRoomManager.RoomSegments)
			{
				if (roomSegment.IsConnectedToOutside() && roomSegment.ConnectedPath == null)
				{
					Vector2 vector2 = roomSegment.transform.position.FlattenVector3();
					Vector2 res;
					if (Utilities.ProjectToLine(vector2, a, vector, out res) && (res - vector2).sqrMagnitude < PathController.PathSegSnapDist)
					{
						DrawLine(res, vector2, Color.magenta);
					}
				}
			}
		}
		_pos = vector.ToVector3(0f);
		if (vector != _lastM)
		{
			if (_currentPath.Count > 0)
			{
				float pitch = 1f + Mathf.Min((vector - _currentPath.Last().transform.position.FlattenVector3()).magnitude / 32f, 1f);
				UISoundFX.PlaySFX("Tick", pitch, 0f, true);
			}
			else
			{
				UISoundFX.PlaySFX("Tick", true);
			}
		}
		_lastM = vector;
		if (flag && Input.GetMouseButtonUp(0))
		{
			if (!CheckValid((_currentPath.Count > 0) ? _currentPath[_currentPath.Count - 1].transform.position.FlattenVector3() : vector, vector))
			{
				UISoundFX.PlaySFX("BuildError");
				return;
			}
			if (_currentPath.Count > 1 || (autoFinish && _currentPath.Count > 0))
			{
				_currentPath[_currentPath.Count - 1].Set(vector, _currentWidth);
				if (autoFinish || (_currentPath[_currentPath.Count - 1].transform.position.FlattenVector3() - vector).sqrMagnitude < 0.25f)
				{
					List<Vector2> list = _currentPath.Select((PathCubeObject x) => x.transform.position.FlattenVector3()).ToList();
					if (autoFinish)
					{
						_cost += GetCost(_currentPath[_currentPath.Count - 1].transform.position.FlattenVector3(), vector);
						list.Add(vector);
					}
					if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - _cost))
					{
						UISoundFX.PlaySFX("PlaceRoom", true);
						UISoundFX.PlaySFX("Kaching");
						EmitDirt(list);
						float num = GameSettings.Instance.sRoomManager.PathController.AddPath(list, Bezier);
						CostDisplay.Instance.FloatAway(num);
						GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Construction, true, "Path");
						GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
						InitAllPaths();
						_cost = 0f;
						if (!BuildController.PlaceMulti())
						{
							Deactivate();
						}
						else
						{
							ClearPaths();
						}
					}
					else
					{
						HUD.FlashMoney();
						UISoundFX.PlaySFX("BuildError");
					}
					return;
				}
			}
			if (_currentPath.Count == 0 || (_currentPath[_currentPath.Count - 1].transform.position.FlattenVector3() - vector).sqrMagnitude > 1f)
			{
				if (_currentPath.Count > 0)
				{
					PathCubeObject pathCubeObject = _currentPath[_currentPath.Count - 1];
					pathCubeObject.Set(vector);
					_cost += GetCost(pathCubeObject.transform.position.FlattenVector3(), vector);
				}
				UISoundFX.PlaySFX("PlaceWall", true);
				PathCubeObject pathCubeObject2 = UnityEngine.Object.Instantiate(PathBuildPrefab);
				pathCubeObject2.transform.position = vector.ToVector3(0f);
				_currentPath.Add(pathCubeObject2);
			}
		}
		if (_currentPath.Count > 0)
		{
			CostDisplay.Instance.Show(_cost + GetCost(_currentPath[_currentPath.Count - 1].transform.position.FlattenVector3(), vector), vector.ToVector3(0.5f));
			BuildingHUD.Instance.Enable(true, false, true);
			PathCubeObject pathCubeObject3 = _currentPath.Last();
			Vector3 vector3 = vector.ToVector3(0f);
			BuildingHUD.Instance.SetDimension(pathCubeObject3.transform.position, vector3, BuildHUDColor);
			if (_currentPath.Count > 1)
			{
				Vector3 position = _currentPath[_currentPath.Count - 2].transform.position;
				BuildingHUD.Instance.SetRot(position, pathCubeObject3.transform.position, vector3, BuildHUDColor);
			}
			else
			{
				Vector3 vector4 = BuildController.Instance.GridMatrix.MultiplyVector(Vector3.forward);
				Vector3 p = pathCubeObject3.transform.position + vector4;
				BuildingHUD.Instance.SetRot(p, pathCubeObject3.transform.position, vector3, BuildHUDColor);
			}
			_currentPath[_currentPath.Count - 1].Set(vector, _currentWidth);
		}
		else
		{
			CostDisplay.Instance.Hide();
			BuildingHUD.Instance.Enable(false, false, false);
		}
	}

	public static float GetCost(Vector2 a, Vector2 b)
	{
		return GetCost((a - b).magnitude);
	}

	public static float GetCost(float d)
	{
		return d * PathCost;
	}

	private void EmitDirt(List<Vector2> path)
	{
		for (int i = 1; i < path.Count; i++)
		{
			Vector2 vector = path[i - 1];
			Vector2 vector2 = path[i];
			Vector2 vector3 = vector - vector2;
			float num = vector3.magnitude;
			vector3 /= num;
			if (i > 1)
			{
				num -= 0.5f;
			}
			for (float num2 = ((i == path.Count - 1) ? 0f : 0.5f); num2 < num - 0.5f; num2 += 0.1f)
			{
				Vector2 vector4 = UnityEngine.Random.Range(0.8f, 1.2f) * vector3.Turn90();
				if (UnityEngine.Random.value > 0.5f)
				{
					vector4 = -vector4;
				}
				BuildController.Instance.DirtEmitter.Emit(new ParticleSystem.EmitParams
				{
					position = (vector2 + vector3 * num2 + vector4).ToVector3(-0.2f),
					velocity = Vector3.up * UnityEngine.Random.Range(1f, 2f) + vector4.ToVector3(0f)
				}, 1);
			}
		}
	}

	private bool CheckValid(Vector2 p1, Vector2 p2)
	{
		Rect rect = new Rect(1f, 1f, 254f, 254f);
		if (!rect.Contains(p1) || !rect.Contains(p2))
		{
			ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
			return false;
		}
		bool flag = p1 == p2;
		if (!flag && !GameSettings.Instance.PlayerOwnedLine(p1, p2, true, null, true))
		{
			ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
			return false;
		}
		if (flag && !GameSettings.Instance.PlayerOwnedPoint(p1, true, null, true))
		{
			ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
			return false;
		}
		if (!flag)
		{
			PathController pathController = GameSettings.Instance.sRoomManager.PathController;
			Vector2 normalized = (p1 - p2).normalized;
			if (_currentPath.Count > 1)
			{
				Vector2 c = _currentPath[0].transform.position.FlattenVector3();
				for (int i = 1; i < _currentPath.Count; i++)
				{
					Vector2 vector = _currentPath[i].transform.position.FlattenVector3();
					if (!CheckPathSeg(p1, p2, c, vector, normalized))
					{
						ErrorOverlay.Instance.ShowError("PathOnPath", false, true, 4f);
						return false;
					}
					c = vector;
				}
			}
			for (int j = 0; j < pathController.AllPoints.Count; j++)
			{
				PathController.PathPoint pathPoint = pathController.AllPoints[j];
				for (int k = 0; k < pathPoint.Connections.Count; k++)
				{
					PathController.PathPoint key = pathPoint.Connections[k].Key;
					if (pathPoint.ID > key.ID && !CheckPathSeg(p1, p2, pathPoint.Point, key.Point, normalized))
					{
						ErrorOverlay.Instance.ShowError("PathOnPath", false, true, 4f);
						return false;
					}
				}
			}
		}
		for (int l = 0; l < GameSettings.Instance.sRoomManager.Rooms.Count; l++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[l];
			if (room.Floor != 0)
			{
				continue;
			}
			Vector2 vector2 = (flag ? p1 : p2);
			if (room.IsInside(vector2, Room.WallOffset))
			{
				ErrorOverlay.Instance.ShowError("PathInRoom", false, true, 4f);
				return false;
			}
			WallEdge wallEdge = room.Edges[room.Edges.Count - 1];
			for (int m = 0; m < room.Edges.Count; m++)
			{
				WallEdge wallEdge2 = room.Edges[m];
				if (vector2 == wallEdge2.Pos)
				{
					ErrorOverlay.Instance.ShowError("PathInRoom", false, true, 4f);
					return false;
				}
				if (!flag)
				{
					if (Utilities.LinesIntersect(p1, p2, wallEdge.Pos, wallEdge2.Pos, false, false, true))
					{
						ErrorOverlay.Instance.ShowError("PathInRoom", false, true, 4f);
						return false;
					}
					wallEdge = wallEdge2;
				}
			}
		}
		List<Furniture> furnitures = GameSettings.Instance.sRoomManager.Outside.GetFurnitures();
		for (int n = 0; n < furnitures.Count; n++)
		{
			Furniture furniture = furnitures[n];
			Vector2 vector3 = furniture.transform.position.FlattenVector3();
			if (!((Utilities.ProjectToLineEndlessClamped(vector3, p1, p2) - vector3).sqrMagnitude < 16f))
			{
				continue;
			}
			Vector2[] offset = furniture.FinalBoundary.GetOffset(-1f);
			for (int num = 0; num < offset.Length; num++)
			{
				Vector2 q = offset[num];
				Vector2 q2 = offset[(num + 1) % offset.Length];
				if (Utilities.LinesIntersect(p1, p2, q, q2, false, false, true))
				{
					ErrorOverlay.Instance.ShowError("FurnitureOccupied", false, true, 4f);
					return false;
				}
			}
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		while (GameSettings.Instance.sRoomManager.Outside.GetNavMeshRunning() && Time.realtimeSinceStartup - realtimeSinceStartup < 1f)
		{
		}
		if (GameSettings.Instance.sRoomManager.Outside.GetNodeAt(p2) == null)
		{
			ErrorOverlay.Instance.ShowError("UnreachablePath", false, true, 4f);
			return false;
		}
		return true;
	}

	private bool CheckPathSeg(Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 normAB)
	{
		if (Mathf.Abs(Vector2.Dot(normAB, (c - d).normalized)) > 0.8f)
		{
			Vector2 res;
			Vector2? vector = CheckProj(a, Utilities.ProjectToLine(a, c, d, out res), res);
			Vector2? vector2 = CheckProj(b, Utilities.ProjectToLine(b, c, d, out res), res);
			Vector2? vector3 = CheckProj(c, Utilities.ProjectToLine(c, a, b, out res), res);
			Vector2? vector4 = CheckProj(d, Utilities.ProjectToLine(d, a, b, out res), res);
			if (MaxDist(vector, vector2, vector3, vector4) > 0f)
			{
				return false;
			}
		}
		return true;
	}

	private Vector2? CheckProj(Vector2 p, bool value, Vector2 proj)
	{
		if (value && (p - proj).sqrMagnitude < 1.03f)
		{
			return proj;
		}
		return null;
	}

	private float MaxDist(params Vector2?[] points)
	{
		float num = 0f;
		for (int i = 0; i < points.Length; i++)
		{
			Vector2? vector = points[i];
			if (!vector.HasValue)
			{
				continue;
			}
			for (int j = i + 1; j < points.Length; j++)
			{
				Vector2? vector2 = points[j];
				if (vector2.HasValue)
				{
					num = Mathf.Max(num, (vector.Value - vector2.Value).sqrMagnitude);
				}
			}
		}
		return num;
	}

	private Vector2 CheckSnap(Vector2 p, out Vector2[] snapped, ref bool autoFinish)
	{
		Vector2 vector = BuildController.Instance.CorrectMousePos(p, _shiftGrid);
		Vector2 p2 = vector;
		PathController.PathPoint[] path = GameSettings.Instance.sRoomManager.PathController.GetPath(ref p2, 4f);
		if (path != null)
		{
			if (path.Length == 1)
			{
				snapped = new Vector2[2]
				{
					path[0].Point,
					path[0].Point
				};
				autoFinish = true;
				return path[0].Point;
			}
			snapped = new Vector2[2]
			{
				path[0].Point,
				path[1].Point
			};
			autoFinish = true;
			return p2;
		}
		foreach (RoomSegment roomSegment in GameSettings.Instance.sRoomManager.RoomSegments)
		{
			if (roomSegment.IsConnectedToOutside() && (roomSegment.transform.position.FlattenVector3() - p).sqrMagnitude < 0.5f)
			{
				Vector2 vector2 = (roomSegment.transform.rotation * Vector3.forward * roomSegment.WallWidth * 0.5f).FlattenVector3().Turn90();
				Vector2 vector3 = roomSegment.transform.position.FlattenVector3();
				snapped = new Vector2[2]
				{
					vector3 + vector2,
					vector3 - vector2
				};
				autoFinish = true;
				return roomSegment.GetOffsetPos(GameSettings.Instance.sRoomManager.Outside).FlattenVector3();
			}
		}
		float roadSize = RoadManager.Instance.RoadSize;
		int num = Mathf.RoundToInt(vector.x / roadSize);
		int num2 = Mathf.RoundToInt(vector.y / roadSize);
		float num3 = Mathf.Abs((float)num * roadSize - vector.x);
		float num4 = Mathf.Abs((float)num2 * roadSize - vector.y);
		if (num3 < 1f || num4 < 1f)
		{
			if (num3 <= num4)
			{
				num2 = Mathf.FloorToInt(vector.y / roadSize);
				bool num5 = RoadManager.Instance.GetRoad(num, num2, 0) == 0;
				bool flag = RoadManager.Instance.GetRoad(num - 1, num2, 0) == 0;
				if (num5 != flag)
				{
					snapped = new Vector2[2]
					{
						new Vector2((float)num * roadSize, (float)num2 * roadSize),
						new Vector2((float)num * roadSize, (float)num2 * roadSize + roadSize)
					};
					autoFinish = true;
					return new Vector2((float)num * roadSize, vector.y);
				}
			}
			if (num4 <= num3)
			{
				num = Mathf.FloorToInt(vector.x / roadSize);
				bool num6 = RoadManager.Instance.GetRoad(num, num2, 0) == 0;
				bool flag2 = RoadManager.Instance.GetRoad(num, num2 - 1, 0) == 0;
				if (num6 != flag2)
				{
					snapped = new Vector2[2]
					{
						new Vector2((float)num * roadSize, (float)num2 * roadSize),
						new Vector2((float)num * roadSize + roadSize, (float)num2 * roadSize)
					};
					autoFinish = true;
					return new Vector2(vector.x, (float)num2 * roadSize);
				}
			}
		}
		for (int i = 0; i < _outlines.Count; i++)
		{
			List<Vector2> list = _outlines[i];
			Vector2 vector4 = list[list.Count - 1];
			for (int j = 0; j < list.Count; j++)
			{
				Vector2 vector5 = list[j];
				Vector2 vector6 = list[(j + 1) % list.Count];
				if ((vector5 - vector).sqrMagnitude < 0.01f)
				{
					snapped = new Vector2[3] { vector4, vector5, vector6 };
					return Utilities.GetOffset(vector4, vector5, vector6, 0f - (PathController.PathWalkOffset + Room.WallOffset), true);
				}
				vector4 = vector5;
			}
		}
		for (int k = 0; k < _outlines.Count; k++)
		{
			List<Vector2> list2 = _outlines[k];
			for (int l = 0; l < list2.Count; l++)
			{
				Vector2 vector7 = list2[l];
				Vector2 vector8 = list2[(l + 1) % list2.Count];
				Vector2 res;
				if (Utilities.ProjectToLine(vector, vector7, vector8, out res) && (vector - res).sqrMagnitude < 0.01f)
				{
					snapped = new Vector2[2] { vector7, vector8 };
					return res - (vector8 - vector7).Turn90().normalized * (PathController.PathWalkOffset + Room.WallOffset);
				}
			}
		}
		snapped = null;
		return vector;
	}
}
