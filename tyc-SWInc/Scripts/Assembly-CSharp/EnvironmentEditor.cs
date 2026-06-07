using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEditor : MonoBehaviour
{
	public enum EditorType
	{
		Skyscraper = 0,
		House = 1,
		Trees = 2,
		Lake = 3
	}

	public static EnvironmentEditor Instance;

	public Transform SkyscraperViz;

	public Transform HouseViz;

	public Transform TreeViz;

	private Vector2 _skyP1;

	private Vector2 _skyP2;

	private Vector2 _lastPlace;

	private float _skyHeight = 4f;

	private float _TreeDrawSize = 1f;

	private int _skyscraperState;

	private int _currentHouse;

	private int _lakeState;

	private bool _addedTrees;

	public MeshFilter HouseMesh;

	public Rect Bounds;

	private List<Transform> _lakeViz = new List<Transform>();

	private List<Vector2> _lakeBounds = new List<Vector2>();

	public EditorType CurrentType;

	[NonSerialized]
	private List<TreeInstance> _treeRes = new List<TreeInstance>();

	[NonSerialized]
	private List<TreeInstance> _treeAddUndos = new List<TreeInstance>();

	[NonSerialized]
	private List<TreeInstance> _treeRemoveUndos = new List<TreeInstance>();

	public void Show(EditorType type)
	{
		CurrentType = type;
		switch (CurrentType)
		{
		default:
			return;
		case EditorType.Skyscraper:
			InitLake(false);
			InitSkyscraper(true);
			InitHouse(false);
			InitTrees(false);
			break;
		case EditorType.House:
			InitSkyscraper(false);
			InitLake(false);
			InitHouse(true);
			InitTrees(false);
			break;
		case EditorType.Trees:
			InitSkyscraper(false);
			InitLake(false);
			InitHouse(false);
			InitTrees(true);
			break;
		case EditorType.Lake:
			InitSkyscraper(false);
			InitLake(true);
			InitHouse(false);
			InitTrees(false);
			break;
		}
		BuildController.Instance.ClearBuild(false, false, false, true);
		base.gameObject.SetActive(true);
		if (GameSettings.Instance.ActiveFloor != 0)
		{
			GameSettings.Instance.ActiveFloor = 0;
			Furniture.UpdateEdgeDetection();
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
		MaterialPreviewer.Instance.RefreshState();
		switch (CurrentType)
		{
		case EditorType.House:
			HUD.Instance.ShortcutPanel.AddShortcut("ChangeStyle".Loc(), "MouseScroll".Loc());
			break;
		case EditorType.Trees:
			HUD.Instance.ShortcutPanel.AddShortcut("ChangeStyle".Loc(), "MouseScroll".Loc());
			break;
		case EditorType.Skyscraper:
			HUD.Instance.ShortcutPanel.AddShortcut("ChangeStyle".Loc(), KeyCode.LeftControl, KeyCode.Mouse0);
			break;
		}
		HUD.Instance.ShortcutPanel.AddShortcut("Remove".Loc(), KeyCode.LeftShift, KeyCode.Mouse0);
		HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
	}

	private void InitSkyscraper(bool active)
	{
		SkyscraperViz.gameObject.SetActive(active);
		_skyscraperState = 0;
		_skyHeight = 4f;
	}

	private void InitHouse(bool active)
	{
		HouseMesh.gameObject.SetActive(active);
		if (active)
		{
			SetHouseMesh();
		}
	}

	private void SetHouseMesh(int idx = -1, float scale = 1f)
	{
		if (idx == -1)
		{
			idx = _currentHouse;
		}
		BurbHouse burbHouse = RoadManager.Instance.BurbHousePrefabs[idx];
		HouseMesh.sharedMesh = burbHouse.Rend.GetComponent<MeshFilter>().sharedMesh;
		HouseMesh.transform.localPosition = burbHouse.Rend.transform.localPosition;
		HouseMesh.transform.localRotation = burbHouse.Rend.transform.localRotation;
		HouseMesh.transform.localScale = burbHouse.Rend.transform.localScale * scale;
	}

	private void InitTrees(bool active)
	{
		TreeViz.gameObject.SetActive(active);
	}

	private void InitLake(bool active)
	{
		_lakeBounds.Clear();
		_lakeViz.ForEach(delegate(Transform x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		_lakeViz.Clear();
		_lakeState = 0;
		if (active)
		{
			Transform transform = UnityEngine.Object.Instantiate(SkyscraperViz);
			transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			transform.localScale = Vector3.one;
			transform.gameObject.SetActive(true);
			_lakeViz.Add(transform);
		}
	}

	public static bool DisableScroll()
	{
		if (Instance != null)
		{
			if (Instance.gameObject.activeSelf)
			{
				if (Instance.CurrentType != EditorType.House)
				{
					return Instance.CurrentType == EditorType.Trees;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
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

	private void Update()
	{
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			if (_addedTrees)
			{
				_addedTrees = false;
				GameSettings.Instance.BatchTempTrees();
			}
			CleanUpTreeUndos();
			InitSkyscraper(false);
			InitLake(false);
			InitHouse(false);
			InitTrees(false);
			base.gameObject.SetActive(false);
			HUD.Instance.ShortcutPanel.Hide();
			MaterialPreviewer.Instance.RefreshState();
		}
		else if (!GUICheck.OverGUI)
		{
			switch (CurrentType)
			{
			case EditorType.Skyscraper:
				SkyscraperEditor();
				break;
			case EditorType.House:
				HouseEditor();
				break;
			case EditorType.Trees:
				TreeEditor();
				break;
			case EditorType.Lake:
				LakeEditor();
				break;
			default:
				base.gameObject.SetActive(false);
				break;
			}
		}
	}

	private void LakeEditor()
	{
		if (_lakeState == 0)
		{
			Vector2 mouseProj = HUD.Instance.GetMouseProj(0f, false);
			Lake lake = null;
			for (int i = 0; i < RoadManager.Instance.Landmarks.Count; i++)
			{
				Lake lake2 = RoadManager.Instance.Landmarks[i] as Lake;
				if (lake2 != null && lake2.LakeArea.Contains(mouseProj))
				{
					lake = lake2;
					_skyP1 = lake2.LakeArea.min - Vector2.one * 0.1f;
					_skyP2 = lake2.LakeArea.max + Vector2.one * 0.1f;
					break;
				}
			}
			if (lake != null)
			{
				_lakeViz[0].position = lake.LakeArea.center.ToVector3(0.5f);
				_lakeViz[0].rotation = Quaternion.identity;
				_lakeViz[0].localScale = lake.LakeArea.size.ToVector3(1f);
				if (Input.GetMouseButtonUp(0) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
				{
					GameSettings.Instance.AddUndo(new UndoObject.UndoAction(lake, true));
					lake.DestroyLandmark();
				}
				return;
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			Vector2 mouseProj2 = HUD.Instance.GetMouseProj(0f, false);
			mouseProj2 = new Vector2(Mathf.Floor(mouseProj2.x) + 0.5f, Mathf.Floor(mouseProj2.y) + 0.5f);
			if (_lakeBounds.Count > 0 && (mouseProj2 - _lakeBounds[0]).magnitude < 2f)
			{
				Rect bounds = _lakeBounds.GetBounds();
				if (bounds.width > 6f && bounds.height > 6f)
				{
					bool flag = true;
					Rect other = bounds.Expand(2f, 2f);
					for (int j = 0; j < RoadManager.Instance.Landmarks.Count; j++)
					{
						Lake lake3 = RoadManager.Instance.Landmarks[j] as Lake;
						if (lake3 != null && lake3.LakeArea.Overlaps(other))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						if (Utilities.Clockwise(_lakeBounds))
						{
							_lakeBounds.Reverse();
						}
						Lake lake4 = RoadManager.Instance.CreateLake(_lakeBounds);
						lake4.InitWritable();
						GrassSystem.Instance.InvalidateArea();
						GameSettings.Instance.AddUndo(new UndoObject.UndoAction(lake4, false));
						_lakeState = 0;
						InitLake(true);
					}
				}
			}
			else if (_lakeBounds.Count == 0 || (mouseProj2 - _lakeBounds.Last()).magnitude > 2f)
			{
				_lakeBounds.Add(mouseProj2);
				if (_lakeState > 0)
				{
					Transform transform = UnityEngine.Object.Instantiate(SkyscraperViz);
					transform.gameObject.SetActive(true);
					_lakeViz.Add(transform);
					transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
					transform.localScale = Vector3.one;
				}
				_lakeState = 1;
			}
		}
		else
		{
			Vector2 mouseProj3 = HUD.Instance.GetMouseProj(0f, false);
			mouseProj3 = new Vector2(Mathf.Floor(mouseProj3.x) + 0.5f, Mathf.Floor(mouseProj3.y) + 0.5f);
			if (_lakeState == 0)
			{
				_lakeViz[0].position = mouseProj3.ToVector3(0.5f);
				_lakeViz[0].rotation = Quaternion.identity;
				_lakeViz[0].localScale = Vector3.one;
			}
			else
			{
				Vector2 vector = _lakeBounds.Last();
				Transform obj = _lakeViz.Last();
				obj.position = ((mouseProj3 + vector) * 0.5f).ToVector3(0.5f);
				obj.rotation = Quaternion.LookRotation((mouseProj3 - vector).ToVector3(0f));
				obj.localScale = new Vector3(0.2f, 1f, (mouseProj3 - vector).magnitude);
			}
		}
		UpdateSkyscraperViz();
	}

	private void SkyscraperEditor()
	{
		if (_skyscraperState == 0)
		{
			Vector2 mouseProj = HUD.Instance.GetMouseProj(0f, false);
			SkraperGen skraperGen = null;
			for (int i = 0; i < RoadManager.Instance.Landmarks.Count; i++)
			{
				SkraperGen skraperGen2 = RoadManager.Instance.Landmarks[i] as SkraperGen;
				if (skraperGen2 != null && skraperGen2.Blob.Contains(mouseProj))
				{
					skraperGen = skraperGen2;
					_skyP1 = skraperGen2.Blob.min - Vector2.one * 0.1f;
					_skyP2 = skraperGen2.Blob.max + Vector2.one * 0.1f;
					_skyHeight = skraperGen2.Height + 0.1f;
					break;
				}
			}
			if (skraperGen != null)
			{
				if (Input.GetMouseButtonUp(0) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
				{
					GameSettings.Instance.AddUndo(new UndoObject.UndoAction(skraperGen, true));
					skraperGen.DestroyLandmark();
				}
				if (Input.GetMouseButtonUp(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
				{
					SkraperGen skraperGen3 = RoadManager.Instance.PlaceBuilding(skraperGen.Blob);
					skraperGen3.InitWritable();
					GrassSystem.Instance.InvalidateArea();
					GameSettings.Instance.AddUndo(new UndoObject.UndoAction(skraperGen3, false), new UndoObject.UndoAction(skraperGen, true));
					skraperGen.DestroyLandmark();
				}
				UpdateSkyscraperViz();
				return;
			}
			_skyHeight = 4f;
		}
		if (Input.GetMouseButtonUp(0))
		{
			_skyscraperState++;
			if (_skyscraperState == 2)
			{
				float num = Mathf.Floor(Mathf.Min(_skyP1.x, _skyP2.x)) - 1f;
				float num2 = Mathf.Floor(Mathf.Min(_skyP1.y, _skyP2.y)) - 1f;
				float num3 = Mathf.Ceil(Mathf.Max(_skyP1.x, _skyP2.x)) + 1f;
				float num4 = Mathf.Ceil(Mathf.Max(_skyP1.y, _skyP2.y)) + 1f;
				if (num3 - num > 12f && num4 - num2 > 12f)
				{
					SkraperGen skraperGen4 = RoadManager.Instance.PlaceBuilding(Rect.MinMaxRect(num, num2, num3, num4));
					skraperGen4.InitWritable();
					GrassSystem.Instance.InvalidateArea();
					GameSettings.Instance.AddUndo(new UndoObject.UndoAction(skraperGen4, false));
					_skyscraperState = 0;
				}
				else
				{
					_skyscraperState = 1;
				}
				_skyHeight = 4f;
			}
		}
		else if (_skyscraperState == 2)
		{
			Vector3 inPoint = ((_skyP1 + _skyP2) * 0.5f).ToVector3(0f);
			Vector3 forward = CameraScript.Instance.mainCam.transform.forward;
			forward = new Vector3(forward.x, 0f, forward.z).normalized;
			Plane plane = new Plane(forward, inPoint);
			Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
			float enter = 0f;
			plane.Raycast(ray, out enter);
			_skyHeight = Mathf.Clamp(Mathf.Round(ray.GetPoint(enter).y / 2f) * 2f, 4f, 30f);
		}
		else
		{
			Vector2 mouseProj2 = HUD.Instance.GetMouseProj(0f, false);
			mouseProj2 = new Vector2(Mathf.Floor(mouseProj2.x) + 0.5f, Mathf.Floor(mouseProj2.y) + 0.5f);
			_skyP2 = Clamp(mouseProj2, Bounds.Expand(-3f, -3f));
			if (_skyscraperState == 0)
			{
				_skyP1 = _skyP2;
			}
		}
		UpdateSkyscraperViz();
	}

	private Vector2 Clamp(Vector2 v, Rect r)
	{
		return new Vector2(Mathf.Clamp(v.x, r.xMin, r.xMax), Mathf.Clamp(v.y, r.yMin, r.yMax));
	}

	private void UpdateSkyscraperViz()
	{
		float num = Mathf.Floor(Mathf.Min(_skyP1.x, _skyP2.x)) - 1f;
		float num2 = Mathf.Floor(Mathf.Min(_skyP1.y, _skyP2.y)) - 1f;
		float num3 = Mathf.Ceil(Mathf.Max(_skyP1.x, _skyP2.x)) + 1f;
		float num4 = Mathf.Ceil(Mathf.Max(_skyP1.y, _skyP2.y)) + 1f;
		SkyscraperViz.position = new Vector3((num + num3) / 2f, _skyHeight / 2f, (num2 + num4) / 2f);
		SkyscraperViz.localScale = new Vector3(num3 - num, _skyHeight, num4 - num2);
	}

	private void HouseEditor()
	{
		if (Input.mouseScrollDelta.y > 0f)
		{
			_currentHouse = (_currentHouse + 1) % RoadManager.Instance.BurbHousePrefabs.Length;
		}
		if (Input.mouseScrollDelta.y < 0f)
		{
			_currentHouse--;
			if (_currentHouse < 0)
			{
				_currentHouse = RoadManager.Instance.BurbHousePrefabs.Length - 1;
			}
		}
		Vector2 vector = HUD.Instance.GetMouseProj(0f, false);
		for (int i = 0; i < RoadManager.Instance.Landmarks.Count; i++)
		{
			BurbHouse burbHouse = RoadManager.Instance.Landmarks[i] as BurbHouse;
			if (burbHouse != null && ((IList<Vector2>)burbHouse.NavMesh).GetBounds().Contains(vector))
			{
				if (Input.GetMouseButtonUp(0) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
				{
					GameSettings.Instance.AddUndo(new UndoObject.UndoAction(burbHouse, true));
					burbHouse.DestroyLandmark();
				}
				else
				{
					SetHouseMesh(burbHouse.Idx, 1.1f);
					HouseViz.position = burbHouse.transform.position;
					HouseViz.rotation = burbHouse.transform.rotation;
				}
				return;
			}
		}
		float roadSize = RoadManager.Instance.RoadSize;
		int num = Mathf.FloorToInt(vector.x / roadSize);
		int num2 = Mathf.FloorToInt(vector.y / roadSize);
		Vector3 forward = Vector3.left;
		float num3 = ((GetRoad(num - 1, num2) > 0) ? (vector.x % roadSize) : 9f);
		int num4 = 0;
		float num5 = ((GetRoad(num, num2 - 1) > 0) ? (vector.y % roadSize) : 9f);
		if (num5 < num3)
		{
			num4 = 1;
			num3 = num5;
		}
		num5 = ((GetRoad(num + 1, num2) > 0) ? (roadSize - vector.x % roadSize) : 9f);
		if (num5 < num3)
		{
			num4 = 2;
			num3 = num5;
		}
		num5 = ((GetRoad(num, num2 + 1) > 0) ? (roadSize - vector.y % roadSize) : 9f);
		if (num5 < num3)
		{
			num4 = 3;
		}
		switch (num4)
		{
		case 0:
			vector = new Vector2(Mathf.Floor(vector.x / roadSize) * roadSize, vector.y);
			forward = Vector3.left;
			break;
		case 1:
			vector = new Vector2(vector.x, Mathf.Floor(vector.y / roadSize) * roadSize);
			forward = Vector3.back;
			break;
		case 2:
			vector = new Vector2(Mathf.Ceil(vector.x / roadSize) * roadSize, vector.y);
			forward = Vector3.right;
			break;
		case 3:
			vector = new Vector2(vector.x, Mathf.Ceil(vector.y / roadSize) * roadSize);
			forward = Vector3.forward;
			break;
		}
		HouseViz.position = Clamp(vector, Bounds).ToVector3(0f);
		HouseViz.rotation = Quaternion.LookRotation(forward);
		if (Input.GetMouseButtonUp(0))
		{
			BurbHouse burbHouse2 = RoadManager.Instance.PlaceHouse(_currentHouse, HouseViz.position, HouseViz.rotation);
			GrassSystem.Instance.InvalidateArea();
			burbHouse2.InitWritable();
			GameSettings.Instance.AddUndo(new UndoObject.UndoAction(burbHouse2, false));
		}
		SetHouseMesh();
	}

	public byte GetRoad(int x, int y)
	{
		return RoadManager.Instance.GetRoad(x, y, 0);
	}

	private void CleanUpTreeUndos()
	{
		if (_treeAddUndos.Count != 0 || _treeRemoveUndos.Count != 0)
		{
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			if (_treeAddUndos.Count > 0)
			{
				list.Add(new UndoObject.UndoAction(_treeAddUndos.ToArray(), true));
				_treeAddUndos.Clear();
			}
			if (_treeRemoveUndos.Count > 0)
			{
				list.Add(new UndoObject.UndoAction(_treeRemoveUndos.ToArray(), false));
				_treeRemoveUndos.Clear();
			}
			if (list.Count > 0)
			{
				GameSettings.Instance.AddUndo(list.ToArray());
			}
		}
	}

	private void TreeEditor()
	{
		_TreeDrawSize = Mathf.Clamp(_TreeDrawSize + Input.mouseScrollDelta.y, 1f, 15f);
		Vector2 mouseProj = HUD.Instance.GetMouseProj(0f, false);
		TreeViz.position = mouseProj.ToVector3(0f);
		TreeViz.localScale = new Vector3(_TreeDrawSize, 1f, _TreeDrawSize);
		if (Input.GetMouseButton(0))
		{
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				_lastPlace = Vector2.one * -10f;
				Vector2 vector = Vector2.one * _TreeDrawSize;
				_treeRes.Clear();
				GameSettings.Instance.TreeTree.Query(new Rect(mouseProj - vector * 0.5f, Vector2.one * _TreeDrawSize), _treeRes);
				float num = Mathf.Pow(_TreeDrawSize / 2f, 2f);
				for (int i = 0; i < _treeRes.Count; i++)
				{
					if ((mouseProj - _treeRes[i].GetPos()).sqrMagnitude > num)
					{
						_treeRes.RemoveAt(i);
						i--;
					}
				}
				if (_treeRes.Count > 0)
				{
					for (int j = 0; j < _treeRes.Count; j++)
					{
						TreeInstance treeInstance = _treeRes[j];
						_treeAddUndos.Add(treeInstance);
						GameSettings.Instance.RemoveTree(treeInstance);
					}
				}
				return;
			}
			float num2 = Mathf.Max(2f, _TreeDrawSize);
			if (!((mouseProj - _lastPlace).magnitude > num2))
			{
				return;
			}
			_addedTrees = true;
			int num3 = Mathf.Max(1, Mathf.FloorToInt(num2 / 4f));
			Vector2 vector2 = mouseProj - Vector2.one * num2 / 2f;
			float num4 = num2 / (float)num3;
			for (int k = 0; k < num3; k++)
			{
				for (int l = 0; l < num3; l++)
				{
					Vector2 vector3 = new Vector2((UnityEngine.Random.value - 0.5f) * (num4 / 2f - 1f), (UnityEngine.Random.value - 0.5f) * (num4 / 2f - 1f));
					Vector2 vector4 = vector2 + new Vector2((float)k * num4 + num4 / 2f, (float)l * num4 + num4 / 2f) + vector3;
					if (Bounds.Contains(vector4))
					{
						_treeRemoveUndos.Add(GameSettings.Instance.AddTree(vector4.ToVector3(0f), true));
					}
				}
			}
			_lastPlace = mouseProj;
		}
		else
		{
			_lastPlace = Vector2.one * -10f;
			if (_addedTrees)
			{
				_addedTrees = false;
				GameSettings.Instance.BatchTempTrees();
			}
			CleanUpTreeUndos();
		}
	}
}
