using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
	public static float FencePrice = 50f;

	public static float WallPrice = 250f;

	public static float OutdoorPrice = 100f;

	public static float RoomPrice = 600f;

	public static float PillarPrice = 300f;

	public static float OutdoorRentPrice = 15f;

	public static float RoomRentPrice = 80f;

	public GameObject TempWallPrefab;

	public GameObject RoomPrefab;

	public GameObject TempWallSegmentPrefab;

	public GameObject WallSegmentPrefab;

	public GameObject FurnitureBuilderPrefab;

	public GameObject PillarPrefab;

	public PathObject PathObjectPrefab;

	public ParticleSystem DirtEmitter;

	public ParticleSystem FireEmitter;

	[NonSerialized]
	public List<WallEdge> CurrentSegments;

	[NonSerialized]
	public Vector2[] RectPoints;

	public List<GameObject> TempWallList = new List<GameObject>();

	public GameObject CurrentTempWall;

	public GameObject CurrentTempSegment;

	public FurnitureBuilder CurrentFurnitureBuilder;

	public Room SelectedRoom;

	public bool mergeNow;

	public bool alignNow;

	public bool FenceMode;

	public Room isCutting;

	[NonSerialized]
	private float _instanceSnap = 0.5f;

	private static float _snapDistance = 0.5f;

	private static float _preciseSnapDistance = 0.1f;

	public static BuildController Instance;

	public Matrix4x4 GridMatrix;

	private Matrix4x4 OldMatrix;

	[NonSerialized]
	private bool _gridInit;

	[SerializeField]
	private Material _mainGridMaterial;

	public float MinAngle;

	public float MinWallDistance;

	public Camera MainCamera;

	public Mesh AlignMesh;

	public Material AlignMaterial;

	public float FurnitureAngle = 45f;

	public float[] Angles;

	public Sprite[] AngleSprites;

	public Image AngleButton;

	public int AngleNum;

	public Vector2 LastPos;

	public bool InTempGrid;

	public GameObject Arrow;

	public GameObject AutoCompletePrompt;

	public Material ForcedPrefabMaterial;

	public Material ForcedPrefabMaterialHighlight;

	[NonSerialized]
	public ForcedPrefab ActivePrefab;

	public Mesh ForcedPrefabBox;

	public FloorGizmo AnchorGizmo;

	public Text AutoCompleteLabel;

	public GameObject RestoreFurnButton;

	public Text RestoreFurnitureText;

	public Image RestoreFurnImage;

	[NonSerialized]
	private bool _restoreButtonDirty;

	private bool _shiftGrid;

	private bool _validateForcedPrefab;

	public GameObject AutoPlacePanel;

	public GameObject AutoPlaceScroll;

	public Text AutoPlaceAlgo;

	[NonSerialized]
	private WallEdge _ang1;

	[NonSerialized]
	private List<WallEdge> _autoCompletion;

	private bool RectDragging;

	private static List<Vector2> _pathCheckCache = new List<Vector2>();

	private float DynSegmentPos;

	private Vector2 DynSegmentVec;

	private WallEdge DynSegmentE1;

	private WallEdge DynSegmentE2;

	private const float SegmentProjectionEps = 0.001f;

	private static HashSet<WallEdge> _projectCache = new HashSet<WallEdge>();

	public Material MainGridMaterial
	{
		get
		{
			if (!_gridInit)
			{
				_mainGridMaterial = new Material(_mainGridMaterial);
				_gridInit = true;
			}
			return _mainGridMaterial;
		}
	}

	public static float GetSnapDistance(bool precise = false)
	{
		if (!precise)
		{
			return _snapDistance;
		}
		return _preciseSnapDistance;
	}

	public void SetAutoPlace(string algo, int num = 0, int amount = 1)
	{
		if (algo != null)
		{
			AutoPlacePanel.SetActive(true);
			AutoPlaceAlgo.text = algo.Loc() + ((amount > 1) ? (" " + (num + 1) + "/" + amount) : "");
			AutoPlaceScroll.SetActive(amount > 1);
		}
		else
		{
			AutoPlacePanel.SetActive(false);
		}
	}

	public ForcedPrefab CreateForcedPrefab()
	{
		if (ActivePrefab != null)
		{
			UnityEngine.Object.Destroy(ActivePrefab.gameObject);
		}
		return ActivePrefab = new GameObject("ForcedPrefab").AddComponent<ForcedPrefab>();
	}

	public void ValidateForcedPrefab()
	{
		if (ActivePrefab != null)
		{
			_validateForcedPrefab = true;
		}
	}

	public void RestoreFurniture()
	{
		bool flag = GameSettings.Instance.AnyDestructionUndos;
		if (flag)
		{
			GameSettings.Instance.UndoDestruction();
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room.IsPlayerControlled() && !room.IsOnFire && room.Burn > 0f)
			{
				GameSettings.Instance.MyCompany.MakeTransaction(0f - room.GetFireRepairCost(), Company.TransactionCategory.Construction, true);
				room.RepairFireDamage();
				flag = true;
			}
			flag |= room.RestoreFurniture();
		}
		if (flag)
		{
			UISoundFX.PlaySFX("Kaching");
		}
		RestoreFurnButton.SetActive(false);
	}

	private void ActuallyRefreshRestoreButton()
	{
		float num = GameSettings.Instance.DestructionUndoCost;
		bool flag = GameSettings.Instance.AnyDestructionUndos;
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room != null)
			{
				if (room.IsPlayerControlled() && !room.IsOnFire && room.Burn > 0f)
				{
					num += room.GetFireRepairCost();
					flag = true;
				}
				if (room.AnyFurnitureRestoration())
				{
					num += room.GetRestoreFurnitureCost();
					flag = true;
				}
			}
		}
		if (flag)
		{
			RestoreFurnButton.SetActive(true);
			RestoreFurnitureText.text = "RestoreAndRepair".Loc(num.Currency());
		}
		else
		{
			RestoreFurnButton.SetActive(false);
		}
		_restoreButtonDirty = false;
	}

	public void RefreshRestoreButton()
	{
		_restoreButtonDirty = true;
	}

	private void Awake()
	{
		MainGridMaterial.SetShaderPassEnabled("Vertex", Options.GrassQuality > 0);
		UpdateGridHighlight();
	}

	public void UpdateGridHighlight()
	{
		MainGridMaterial.SetFloat("_HighlightDistance", Options.HideGrid ? 2f : 1.2f);
		MainGridMaterial.SetFloat("_HighlightLow", Options.HideGrid ? 0f : 0.6f);
	}

	private void Start()
	{
		OldMatrix = GridMatrix;
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
	}

	public static bool PlaceMulti()
	{
		return Options.ShiftToPlace == (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift));
	}

	public void AngleToggle()
	{
		AngleNum = (AngleNum + 1) % Angles.Length;
		FurnitureAngle = Angles[AngleNum];
		AngleButton.sprite = AngleSprites[AngleNum];
		if (CurrentFurnitureBuilder != null)
		{
			CurrentFurnitureBuilder.RotationSnap = FurnitureAngle;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void SetTempGrid(Vector2 p1, Vector2 p2, bool invert)
	{
		if (!InTempGrid)
		{
			OldMatrix = GridMatrix;
			InTempGrid = true;
		}
		float num = 1f / GetGridSize();
		Vector3 vector = (p2 - p1).Turn90().ToVector3(0f);
		if (invert)
		{
			vector = -vector;
		}
		GridMatrix = Matrix4x4.TRS(p1.ToVector3(0f), Quaternion.LookRotation(vector), Vector3.one * num).inverse;
		UpdateGridVisual();
	}

	public void ResetTempGrid()
	{
		if (InTempGrid)
		{
			InTempGrid = false;
			GridMatrix = OldMatrix;
			UpdateGridVisual();
		}
	}

	public bool IsBuildingRoom()
	{
		if (CurrentSegments == null)
		{
			return RectPoints != null;
		}
		return true;
	}

	public Room MakeRoom(IEnumerable<WallEdge> s, bool outdoors, bool pillar, List<UndoObject.UndoAction> undos, bool dust = true, bool optimize = true, int floor = int.MinValue, uint networkID = 0u)
	{
		if (floor == int.MinValue)
		{
			floor = GameSettings.Instance.ActiveFloor;
		}
		return MakeRoom(s, floor, undos, false, dust, optimize, outdoors, pillar, networkID);
	}

	public Room MakeRoom(IEnumerable<WallEdge> s, int floor, List<UndoObject.UndoAction> undos, bool clone, bool dust = true, bool optimize = true, bool outdoors = false, bool pillar = false, uint networkID = 0u)
	{
		Room component = UnityEngine.Object.Instantiate(RoomPrefab).GetComponent<Room>();
		component.Outdoors = outdoors;
		component.Pillar = pillar;
		component.NetworkID = networkID;
		component.Init(s, floor, dust, undos, false, optimize);
		component.RefreshEdges(undos, clone);
		if (undos != null)
		{
			if (floor >= 0)
			{
				List<Furniture> furnitures = GameSettings.Instance.sRoomManager.Outside.GetFurnitures();
				for (int i = 0; i < furnitures.Count; i++)
				{
					Furniture furniture = furnitures[i];
					if (furniture.IsAliveNotNull() && Mathf.FloorToInt(furniture.Height2 / 2f) >= floor && !FurnitureBuilder.IsValid(furniture, component, true))
					{
						undos.Add(new UndoObject.UndoAction(furniture, false));
						furniture.DestroyGO();
					}
				}
			}
			if (floor > 0)
			{
				for (int j = 0; j < GameSettings.Instance.sRoomManager.Rooms.Count; j++)
				{
					Room room = GameSettings.Instance.sRoomManager.Rooms[j];
					if (room.Floor != floor - 1 || !room.RoomBounds.Overlaps(component.RoomBounds))
					{
						continue;
					}
					List<Furniture> furnitures2 = room.GetFurnitures();
					for (int k = 0; k < furnitures2.Count; k++)
					{
						Furniture furniture2 = furnitures2[k];
						if (furniture2.IsAliveNotNull() && furniture2.PokesThroughRoof && !FurnitureBuilder.IsValid(furniture2, component, true))
						{
							undos.Add(new UndoObject.UndoAction(furniture2, false));
							furniture2.DestroyGO();
						}
					}
				}
			}
		}
		return component;
	}

	public void StartMerge()
	{
		ClearBuild();
		mergeNow = true;
	}

	public void StartAlign()
	{
		OldMatrix = GridMatrix;
		ClearBuild();
		alignNow = true;
		HUD.Instance.UpdateBorderOverlay();
	}

	public float GetGridRotation()
	{
		return Mathf.Atan2(GridMatrix.m20, GridMatrix.m00) * 57.29578f;
	}

	public float GetGridSize()
	{
		return Mathf.Round(GridMatrix.GetColumn(0).FlattenVector4().magnitude);
	}

	public void ApplyMatrix()
	{
		OldMatrix = GridMatrix;
	}

	public void RotateGrid(float deg)
	{
		OldMatrix = (GridMatrix *= Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, deg, 0f), Vector3.one));
		UpdateGridVisual();
	}

	public void SizeGrid(float size)
	{
		float magnitude = (Matrix4x4.Scale(new Vector3(size, 1f, size)) * GridMatrix).GetColumn(0).FlattenVector4().magnitude;
		if ((!(magnitude < 1f) || magnitude.Appx(1f)) && (!(magnitude > 9f) || magnitude.Appx(9f)))
		{
			OldMatrix = (GridMatrix = Matrix4x4.Scale(new Vector3(size, 1f, size)) * GridMatrix);
			UpdateGridVisual();
		}
	}

	public void TranslateGridX(float x)
	{
		OldMatrix = (GridMatrix = Matrix4x4.TRS(new Vector3(x, 0f, 0f), Quaternion.identity, Vector3.one) * GridMatrix);
		UpdateGridVisual();
	}

	public void TranslateGridY(float y)
	{
		OldMatrix = (GridMatrix = Matrix4x4.TRS(new Vector3(0f, 0f, y), Quaternion.identity, Vector3.one) * GridMatrix);
		UpdateGridVisual();
	}

	public void ResetGrid()
	{
		OldMatrix = (GridMatrix = Matrix4x4.identity);
		InTempGrid = false;
		UpdateGridVisual();
	}

	public void UpdateGridVisual()
	{
		MainGridMaterial.SetMatrix("_TextureRotation", GridMatrix);
		_instanceSnap = Mathf.Max(0.5f, 0.5f / GetGridSize());
	}

	private void UpdateTempWall(Vector2 mousePos)
	{
		if (CurrentTempWall == null)
		{
			return;
		}
		Vector2 vector = mousePos;
		if (CurrentSegments.Count == 0)
		{
			CurrentTempWall.transform.SetPositionAndRotation(new Vector3(vector.x, (float)(GameSettings.Instance.ActiveFloor * 2) + (FenceMode ? 0.5f : 1f), vector.y), Quaternion.identity);
			CurrentTempWall.transform.localScale = new Vector3(Room.WallOffset + 0.01f, FenceMode ? 1.01f : 2.01f, Room.WallOffset + 0.01f);
			return;
		}
		Vector2 pos = CurrentSegments.Last().Pos;
		vector = (pos + mousePos) * 0.5f;
		Vector2 vector2 = mousePos - pos;
		if (vector2 != Vector2.zero)
		{
			float magnitude = vector2.magnitude;
			CurrentTempWall.transform.SetPositionAndRotation(new Vector3(vector.x, (float)(GameSettings.Instance.ActiveFloor * 2) + (FenceMode ? 0.5f : 1f), vector.y), Quaternion.LookRotation(new Vector3(vector2.x, 0f, vector2.y)));
			CurrentTempWall.transform.localScale = new Vector3(Room.WallOffset + 0.01f, FenceMode ? 1.01f : 2.01f, magnitude);
		}
	}

	public void AddSegment(WallEdge s)
	{
		if (CurrentTempWall != null)
		{
			UpdateTempWall(s.Pos);
		}
		CurrentSegments.Add(s);
		if (CurrentSegments.Count > 1)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(TempWallPrefab);
			TempWallList.Add(gameObject);
			CurrentTempWall = gameObject;
		}
	}

	private bool TooClose(Vector2 pos, WallEdge ignore = null)
	{
		if (CurrentSegments != null)
		{
			if (CurrentSegments.Any((WallEdge x) => x != ignore && x.Pos.Dist(pos).VeryStrictlyBelow(MinWallDistance)))
			{
				ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
				return true;
			}
			if (isCutting != null)
			{
				if (isCutting.Edges.Any(delegate(WallEdge x)
				{
					float num4 = x.Pos.Dist(pos);
					return num4 >= _instanceSnap && num4.VeryStrictlyBelow(MinWallDistance);
				}))
				{
					ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
					return true;
				}
				for (int num = 0; num < isCutting.Edges.Count; num++)
				{
					Vector2 pos2 = isCutting.Edges[num].Pos;
					Vector2 pos3 = isCutting.Edges[(num + 1) % isCutting.Edges.Count].Pos;
					Vector2 res;
					if (Utilities.ProjectToLine(pos, pos2, pos3, out res))
					{
						float num2 = res.Dist(pos);
						if (num2 >= _instanceSnap && num2.VeryStrictlyBelow(MinWallDistance))
						{
							ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
							return true;
						}
					}
				}
			}
			for (int num3 = 0; num3 < CurrentSegments.Count - 1; num3++)
			{
				if (CurrentSegments[num3] != ignore && CurrentSegments[num3 + 1] != ignore)
				{
					Vector2 pos4 = CurrentSegments[num3].Pos;
					Vector2 pos5 = CurrentSegments[num3 + 1].Pos;
					Vector2 res2;
					if (Utilities.ProjectToLine(pos, pos4, pos5, out res2) && res2.Dist(pos).VeryStrictlyBelow(MinWallDistance))
					{
						ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
						return true;
					}
				}
			}
		}
		return false;
	}

	public void ActivateBuildMode(bool fence)
	{
		ClearBuild();
		WindowManager.SetCursorOverride("Place");
		FenceMode = fence;
		if (FenceMode && GameSettings.Instance.ActiveFloor < 0)
		{
			GameSettings.Instance.ActiveFloor = 0;
			Furniture.UpdateEdgeDetection();
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
		CurrentSegments = new List<WallEdge>();
		GameObject gameObject = UnityEngine.Object.Instantiate(TempWallPrefab);
		TempWallList.Add(gameObject);
		CurrentTempWall = gameObject;
		MaterialPreviewer.Instance.RefreshState();
		if (Options.ShiftToPlace)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceMultiple".Loc(), KeyCode.LeftShift, true);
		}
		else
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceSingle".Loc(), KeyCode.LeftShift, true);
			HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
		}
		if (!fence)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("CreatePillar".Loc(), KeyCode.LeftControl, true);
		}
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.DisableGrid);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.ShiftGrid);
	}

	public Vector2 GetMousePos(Plane plane)
	{
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		float enter = 0f;
		plane.Raycast(ray, out enter);
		Vector3 point = ray.GetPoint(enter);
		return new Vector2(point.x, point.z);
	}

	public Vector2 CorrectMousePos(Vector2 mouse, Vector2 Offset)
	{
		Vector3 vector = GridMatrix.MultiplyPoint(new Vector3(mouse.x, 0f, mouse.y));
		vector = new Vector3(Mathf.Round(vector.x - Offset.x) + Offset.x, Mathf.Round(vector.y), Mathf.Round(vector.z - Offset.y) + Offset.y);
		vector = GridMatrix.inverse.MultiplyPoint(vector);
		return new Vector2(vector.x, vector.z);
	}

	public Vector2 CorrectMousePos(Vector2 mouse, bool offset = false, float sizeOverride = -1f)
	{
		Matrix4x4 matrix4x = GridMatrix;
		if (sizeOverride > 0f)
		{
			float gridSize = GetGridSize();
			if (gridSize < sizeOverride)
			{
				matrix4x = Matrix4x4.Scale(Vector3.one * (sizeOverride / gridSize)) * matrix4x;
			}
		}
		Vector3 vector = matrix4x.MultiplyPoint(new Vector3(mouse.x, 0f, mouse.y));
		vector = ((!offset) ? new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z)) : new Vector3(Mathf.Round(vector.x - 0.5f) + 0.5f, Mathf.Round(vector.y), Mathf.Round(vector.z - 0.5f) + 0.5f));
		vector = matrix4x.inverse.MultiplyPoint(vector);
		return new Vector2(vector.x, vector.z);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_validateForcedPrefab)
		{
			if (ActivePrefab != null)
			{
				ActivePrefab.CheckCompletedValid();
			}
			_validateForcedPrefab = false;
		}
		if (RestoreFurnButton.activeSelf)
		{
			RestoreFurnImage.color = SelectorController.Instance.PanelActionPulse.Evaluate(Time.realtimeSinceStartup * SelectorController.Instance.PanelActionPulseSpeed % 1f);
		}
		if (_restoreButtonDirty)
		{
			ActuallyRefreshRestoreButton();
		}
		if (IsActive())
		{
			SelectorController.CanClick = false;
		}
		if (HUD.Instance.BuildMode && InputController.GetKeyUp(InputController.Keys.AnchorGrid))
		{
			AnchorGizmo.StartMove();
		}
		if (InputController.GetKeyUp(InputController.Keys.ResetGrid))
		{
			ResetGrid();
		}
		Plane plane = new Plane(Vector3.up, Vector3.up * GameSettings.Instance.ActiveFloor * 2f);
		Vector2 mousePos = GetMousePos(plane);
		Vector2 vector = (NoGrid() ? mousePos : CorrectMousePos(mousePos, _shiftGrid));
		MainGridMaterial.SetVector("_HighlightPos", CorrectMousePos(mousePos, true));
		Vector2 vector2 = vector;
		WallEdge a = null;
		WallEdge b = null;
		if (CurrentSegments != null)
		{
			vector2 = SnapToWall(vector2, out a, out b);
			UpdateTempWall(vector2);
			if (!HUD.Instance.pauseWindow.Panel.activeSelf && !CameraScript.WasDragging && Input.GetMouseButtonUp(1))
			{
				if (CurrentSegments.Count > 0)
				{
					UISoundFX.PlaySFX("PlaceWallRev", true);
					if (CurrentSegments.Count > 1)
					{
						TempWallList.Remove(CurrentTempWall);
						UnityEngine.Object.Destroy(CurrentTempWall);
					}
					else
					{
						isCutting = null;
					}
					CurrentSegments.RemoveAt(CurrentSegments.Count - 1);
					CurrentTempWall = (TempWallList.Any() ? TempWallList.Last() : null);
					ResetAutoComplete();
				}
				else
				{
					ClearBuild();
				}
			}
			if (_autoCompletion != null && InputController.GetKeyDown(InputController.Keys.AutoCompleteRoom))
			{
				int count = CurrentSegments.Count;
				CurrentSegments.AddRange(_autoCompletion);
				if (!BuildRoomNow())
				{
					int num = CurrentSegments.Count - count;
					for (int i = 0; i < num; i++)
					{
						CurrentSegments.RemoveAt(CurrentSegments.Count - 1);
					}
				}
			}
		}
		if ((CurrentSegments != null || CurrentTempSegment != null || RectPoints != null) && InputController.GetKeyDown(InputController.Keys.ShiftGrid))
		{
			_shiftGrid = !_shiftGrid;
		}
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			RoomBuildingCode(vector2, a, b);
			SegmentBuildCode();
			AlignCode(mousePos);
		}
		UpdateRectBuilding(vector);
	}

	public void BeginRectBuilding(bool fence)
	{
		ClearBuild();
		WindowManager.SetCursorOverride("Place");
		FenceMode = fence;
		if (FenceMode && GameSettings.Instance.ActiveFloor < 0)
		{
			GameSettings.Instance.ActiveFloor = 0;
			Furniture.UpdateEdgeDetection();
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
		for (int i = 0; i < 4; i++)
		{
			GameObject item = UnityEngine.Object.Instantiate(TempWallPrefab);
			TempWallList.Add(item);
		}
		RectPoints = new Vector2[4]
		{
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero
		};
		MaterialPreviewer.Instance.RefreshState();
		if (Options.ShiftToPlace)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceMultiple".Loc(), KeyCode.LeftShift, true);
		}
		else
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceSingle".Loc(), KeyCode.LeftShift, true);
			HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
		}
		if (!fence)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("CreatePillar".Loc(), KeyCode.LeftControl, true);
		}
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.DisableGrid);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.ShiftGrid);
	}

	private void UpdateRectBuilding(Vector2 p)
	{
		if (RectPoints == null)
		{
			return;
		}
		if (LastPos != p && !NoGrid())
		{
			if (RectDragging)
			{
				float pitch = 1f + Mathf.Clamp(((RectPoints[0] - RectPoints[2]).magnitude - 4f) / 12f, 0f, 2f);
				UISoundFX.PlaySFX("Tick", pitch, 0f, true);
			}
			else
			{
				UISoundFX.PlaySFX("Tick", true);
			}
		}
		LastPos = p;
		if (RectDragging)
		{
			if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
			{
				RectDragging = false;
				BuildingHUD.Instance.Enable(false, false, false);
				CostDisplay.Instance.Hide();
				return;
			}
			if (p == RectPoints[0])
			{
				BuildingHUD.Instance.Enable(false, false, false);
				CostDisplay.Instance.Hide();
				return;
			}
			RectPoints[2] = p;
			Matrix4x4 inverse = GridMatrix.inverse;
			Vector3 vector = GridMatrix.MultiplyPoint(new Vector3(RectPoints[0].x, 0f, RectPoints[0].y));
			Vector3 vector2 = GridMatrix.MultiplyPoint(new Vector3(RectPoints[2].x, 0f, RectPoints[2].y));
			Vector3 vector3 = inverse.MultiplyPoint(new Vector3(vector2.x, 0f, vector.z));
			Vector3 vector4 = inverse.MultiplyPoint(new Vector3(vector.x, 0f, vector2.z));
			RectPoints[1] = new Vector2(vector3.x, vector3.z);
			RectPoints[3] = new Vector2(vector4.x, vector4.z);
			float num = Mathf.Abs(RectPoints[0].x - RectPoints[2].x);
			float num2 = Mathf.Abs(RectPoints[0].y - RectPoints[2].y);
			float cost = GetRoomCost(num * 2f + num2 * 2f, num * num2, FenceMode, IsPillar(), GameSettings.Instance.ActiveFloor, false, false, false);
			if (cost < 4f)
			{
				BuildingHUD.Instance.Enable(false, false, false);
				CostDisplay.Instance.Hide();
				return;
			}
			CostDisplay.Instance.Show(cost, ((RectPoints[0] + RectPoints[2]) * 0.5f).ToVector3(GameSettings.Instance.ActiveFloor * 2 + 2), GameSettings.Instance.MyCompany.CanMakeTransaction(0f - cost) ? Color.white : Color.red);
			for (int i = 0; i < 4; i++)
			{
				int num3 = (i + 1) % 4;
				Vector2 vector5 = (RectPoints[i] + RectPoints[num3]) * 0.5f;
				Vector2 vector6 = RectPoints[i] - RectPoints[num3];
				TempWallList[i].transform.SetPositionAndRotation(new Vector3(vector5.x, (float)(GameSettings.Instance.ActiveFloor * 2) + (FenceMode ? 0.5f : 1f), vector5.y), (vector6 == Vector2.zero) ? Quaternion.identity : Quaternion.LookRotation(vector6.ToVector3(0f)));
				TempWallList[i].transform.localScale = new Vector3(Room.WallOffset + 0.1f, FenceMode ? 1.01f : 2.01f, Room.WallOffset + 0.1f + vector6.magnitude - 0.01f);
			}
			BuildingHUD.Instance.Enable(true, true, false);
			BuildingHUD.Instance.SetDimension(new Vector3(RectPoints[0].x, GameSettings.Instance.ActiveFloor * 2, RectPoints[0].y), new Vector3(RectPoints[1].x, GameSettings.Instance.ActiveFloor * 2, RectPoints[1].y), false);
			BuildingHUD.Instance.SetDimension(new Vector3(RectPoints[0].x, GameSettings.Instance.ActiveFloor * 2, RectPoints[0].y), new Vector3(RectPoints[3].x, GameSettings.Instance.ActiveFloor * 2, RectPoints[3].y));
			if (Input.GetMouseButtonUp(0))
			{
				if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - cost))
				{
					FinalizeRect(RectPoints.ToArray(), ref cost, true, FenceMode, IsPillar(), null);
					return;
				}
				HUD.FlashMoney();
				UISoundFX.PlaySFX("BuildError");
			}
		}
		else
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
			if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
			{
				ClearBuild();
				return;
			}
			for (int j = 0; j < TempWallList.Count; j++)
			{
				GameObject obj = TempWallList[j];
				obj.transform.position = new Vector3(p.x, (float)(GameSettings.Instance.ActiveFloor * 2) + (FenceMode ? 0.5f : 1f), p.y);
				obj.transform.localScale = new Vector3(Room.WallOffset + 0.01f, FenceMode ? 1.01f : 2.01f, Room.WallOffset + 0.01f);
			}
			for (int k = 0; k < RectPoints.Length; k++)
			{
				RectPoints[k] = p;
			}
			if (Input.GetMouseButtonDown(0))
			{
				RectDragging = true;
			}
		}
	}

	private List<WallEdge> GetSplitSegments(out Room splitRoom, int floor)
	{
		List<WallEdge> list = new List<WallEdge>();
		bool flag = true;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		splitRoom = null;
		bool flag3 = false;
		for (int i = 0; i < CurrentSegments.Count; i++)
		{
			int num3 = i;
			WallEdge wallEdge = CurrentSegments[num3];
			WallEdge wallEdge2 = CurrentSegments[(num3 + 1) % CurrentSegments.Count];
			if (wallEdge.UpAgainst(wallEdge2) || wallEdge2.UpAgainst(wallEdge))
			{
				if (!flag2 && !flag)
				{
					num++;
				}
				flag2 = true;
				flag3 = true;
			}
			else
			{
				if (flag2)
				{
					num++;
					num2 = list.Count;
				}
				else if (!flag && wallEdge.Links.Count > 0)
				{
					return null;
				}
				list.Add(wallEdge);
				list.Add(wallEdge2);
				flag2 = false;
			}
			if (num > 2)
			{
				return null;
			}
			flag = false;
		}
		if (!flag3)
		{
			return null;
		}
		if (list.Count > 0)
		{
			if (num2 > 0)
			{
				int num4 = list.Count - num2;
				for (int j = 0; j < num4; j++)
				{
					WallEdge item = list.Last();
					list.Insert(0, item);
					list.RemoveAt(list.Count - 1);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				WallEdge wallEdge3 = list[k];
				WallEdge wallEdge4 = list[(k + 1) % list.Count];
				if (wallEdge3 == wallEdge4)
				{
					list.RemoveAt(k);
					k--;
				}
			}
			HashSet<Room> hashSet = new HashSet<Room>();
			for (int l = 0; l < list.Count; l++)
			{
				WallEdge wallEdge5 = list[l];
				if (!wallEdge5.GetRelevantRooms(hashSet))
				{
					return null;
				}
				int num5 = l + 1;
				if (num5 < list.Count)
				{
					WallEdge wallEdge6 = list[num5];
					Vector2 point = (wallEdge5.Pos + wallEdge6.Pos) * 0.5f;
					Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(floor, point);
					if (roomFromPoint == null || roomFromPoint.Outside || !hashSet.Contains(roomFromPoint))
					{
						return null;
					}
					hashSet.Clear();
					hashSet.Add(roomFromPoint);
				}
			}
			if (hashSet.Count == 1)
			{
				splitRoom = hashSet.First();
				for (int m = 1; m < list.Count - 1; m++)
				{
					if (list[m].Links.ContainsKey(splitRoom) || list[m].IsSplitting(splitRoom))
					{
						return null;
					}
				}
			}
			else
			{
				splitRoom = null;
			}
			return list;
		}
		return null;
	}

	public List<WallEdge> CheckSplit(List<WallEdge> edges, int floor, out Room r)
	{
		r = null;
		CurrentSegments = edges.ToList();
		if (!ProjectToWalls(floor, true))
		{
			CurrentSegments = null;
			return null;
		}
		Room split = CurrentSegments[0].GetSplitRooms[0];
		if (split != null && CurrentSegments.All((WallEdge x) => x.IsSplitter && x.GetSplitRooms[0] == split))
		{
			CurrentSegments = null;
			return null;
		}
		for (int num = CurrentSegments.Count - 1; num >= 0; num--)
		{
			Vector2 pos = CurrentSegments[num].Pos;
			Vector2 pos2 = CurrentSegments[(num + 1) % CurrentSegments.Count].Pos;
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(floor))
			{
				foreach (KeyValuePair<IRoom, WallEdge> link in item.Links)
				{
					if (Utilities.LinesIntersect(pos, pos2, item.Pos, link.Value.Pos, true, false))
					{
						CurrentSegments = null;
						return null;
					}
				}
			}
		}
		if (IsInRoof())
		{
			CurrentSegments = null;
			return null;
		}
		List<WallEdge> splitSegments = GetSplitSegments(out r, floor);
		CurrentSegments = null;
		return splitSegments;
	}

	public Room PostCut(Room cutRoom, Room newRoom, Vector2 center, float cost, List<UndoObject.UndoAction> undos, List<UndoObject.UndoAction> snaps)
	{
		GameSettings.Instance.sRoomManager.AddRoom(newRoom);
		bool flag = newRoom.IsInside(center);
		Room result = (flag ? newRoom : cutRoom);
		if (undos != null)
		{
			undos.Add(new UndoObject.UndoAction(cutRoom, newRoom, cost, !flag));
		}
		foreach (Furniture item in from x in cutRoom.GetFurnitures().ToList()
			orderby x.GetSnappingDepth()
			select x)
		{
			if (item.IsAliveNotNull() && !item.UpdateParent(true, false) && undos != null)
			{
				item.UndoDestroyWithChildren(undos);
			}
		}
		if (undos != null)
		{
			undos.AddRange(snaps);
		}
		newRoom.RecalculateTableGroupsNow();
		cutRoom.RecalculateTableGroupsNow();
		return result;
	}

	public Room MakeSplit(List<WallEdge> splitEdges, Room spR, Vector2 center, List<UndoObject.UndoAction> undos, float cost, bool withErrors, Room ignore = null, bool ignoreSupport = false, bool checkDistance = true, bool preciseEdgeOptimization = false)
	{
		CurrentSegments = new List<WallEdge>();
		CurrentSegments.AddRange(splitEdges);
		if (IsValidSplit())
		{
			isCutting = spR;
			if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - cost) && ValidSplit(withErrors, ignore) && isCutting != null && (!checkDistance || !CurrentSegments.Any((WallEdge x) => !x.IsSplitter && x.Links.Count == 0 && TooClose(x.Pos, x))))
			{
				string debug = string.Join("\n", CurrentSegments.Select((WallEdge x) => x.Pos.x + ";" + x.Pos.y).ToArray()) + "\n\n" + string.Join("\n", isCutting.Edges.Select((WallEdge x) => x.Pos.x + ";" + x.Pos.y).ToArray());
				List<UndoObject.UndoAction> list = ((undos != null) ? new List<UndoObject.UndoAction>() : null);
				FinalizeCuts(true, isCutting.Floor, list, preciseEdgeOptimization);
				Dictionary<WallSnap, UndoObject.UndoAction> snaps = isCutting.PrepareSplit(true);
				GameSettings.Instance.sRoomManager.AllSegments.AddRange(CurrentSegments);
				Room room = isCutting.Split(CurrentSegments, list, snaps, debug, true, null, false, true, ignoreSupport);
				if (room != null)
				{
					Room result = PostCut(isCutting, room, center, cost, undos, list);
					isCutting = null;
					CurrentSegments = null;
					return result;
				}
				isCutting.OptimizeSegments();
				foreach (WallEdge currentSegment in CurrentSegments)
				{
					if (!isCutting.Edges.Contains(currentSegment))
					{
						GameSettings.Instance.sRoomManager.AllSegments.Remove(currentSegment);
					}
				}
				isCutting = null;
				CurrentSegments = null;
				return null;
			}
		}
		CurrentSegments = null;
		return null;
	}

	public Room FinalizeRect(Vector2[] rectPoints, ref float cost, bool clearOnDone, bool fenceMode, bool isPillar, List<UndoObject.UndoAction> undos, bool ignoreSelf = false, bool ignoreSupport = false, Room ignore = null, int floor = int.MinValue)
	{
		if (rectPoints[0] == rectPoints[1] || rectPoints[1] == rectPoints[2])
		{
			return null;
		}
		if (floor == int.MinValue)
		{
			floor = GameSettings.Instance.ActiveFloor;
		}
		Room room = null;
		CurrentSegments = new List<WallEdge>();
		if (Utilities.Clockwise(rectPoints))
		{
			rectPoints.ReverseArray();
		}
		List<WallEdge> list = GameSettings.Instance.sRoomManager.GetEdgesOnFloor(floor).ToList();
		for (int num = 3; num >= 0; num--)
		{
			Vector2 ps = rectPoints[num];
			WallEdge wallEdge = list.FirstOrDefault((WallEdge x) => (x.Pos - ps).magnitude < _instanceSnap);
			if (wallEdge == null)
			{
				wallEdge = new WallEdge(ps, floor);
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					WallEdge wallEdge2 = list[num2];
					foreach (KeyValuePair<IRoom, WallEdge> link in wallEdge2.Links)
					{
						Vector2 res;
						if (Utilities.ProjectToLine(ps, wallEdge2.Pos, link.Value.Pos, out res) && (ps - res).magnitude < _instanceSnap)
						{
							wallEdge.Pos = res;
							wallEdge.SetSplit(wallEdge2, (Room)link.Key);
							break;
						}
					}
					if (wallEdge.IsSplitter)
					{
						break;
					}
				}
			}
			CurrentSegments.Add(wallEdge);
		}
		if (CurrentSegments.All((WallEdge x) => x.Links.Count > 0))
		{
			Room[] array = (from x in GameSettings.Instance.sRoomManager.GetRooms()
				where x.Floor == floor && Utilities.IsInside(x.Center, rectPoints)
				select x).ToArray();
			if (array.Length > 1)
			{
				HashSet<Room> chosenRooms = new HashSet<Room>(array);
				Room r;
				int idx;
				List<WallEdge> outline;
				HashSet<Room> edgeRooms;
				if (RoofEditWindow.FindFirstPoint(array, chosenRooms, out r, out idx) && RoofEditWindow.FindPerimeterEdge(r, idx, out outline, chosenRooms, out edgeRooms))
				{
					HashSet<WallEdge> hashSet = array.SelectMany((Room x) => x.Edges).ToHashSet();
					bool flag = true;
					for (int num3 = 0; num3 < outline.Count; num3++)
					{
						Vector2 p = outline[num3].Pos;
						hashSet.Remove(outline[num3]);
						if (!rectPoints.None((Vector2 x) => x == p))
						{
							continue;
						}
						bool flag2 = false;
						for (int num4 = 0; num4 < rectPoints.Length; num4++)
						{
							Vector2 a = rectPoints[num4];
							Vector2 b = rectPoints[(num4 + 1) % rectPoints.Length];
							if ((Utilities.ProjectToLineEndless(p, a, b) - p).sqrMagnitude < 0.1f)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							flag = false;
							break;
						}
					}
					if (flag && hashSet.All((WallEdge x) => x.Links.All((KeyValuePair<IRoom, WallEdge> y) => y.Value.Links.ContainsValue(x))))
					{
						bool flag3 = false;
						if (undos == null)
						{
							undos = new List<UndoObject.UndoAction>();
							flag3 = true;
						}
						List<Room> list2 = array.ToList();
						while (list2.Count > 1)
						{
							bool flag4 = false;
							for (int num5 = 1; num5 < list2.Count; num5++)
							{
								if (list2[0].CanMerge(list2[num5]))
								{
									List<Vector2> split = list2[0].MergeWith(list2[num5], list2[1].PrepareSplit(true, list2[0].PrepareSplit(true)), undos);
									undos.Add(new UndoObject.UndoAction(list2[0], list2[num5], split));
									list2.RemoveAt(num5);
									num5--;
									flag4 = true;
								}
							}
							if (!flag4)
							{
								break;
							}
						}
						undos.Reverse();
						if (flag3)
						{
							GameSettings.Instance.AddUndo(undos.ToArray());
						}
						cost = 0f;
						if (clearOnDone)
						{
							if (PlaceMulti())
							{
								BeginRectBuilding(FenceMode);
							}
							else
							{
								ClearBuild();
							}
						}
						return list2[0];
					}
				}
			}
		}
		bool flag5 = ProjectToWalls(floor, true);
		Room split2 = CurrentSegments[0].GetSplitRooms[0];
		if (split2 != null && CurrentSegments.All((WallEdge x) => x.IsSplitter && x.GetSplitRooms[0] == split2))
		{
			ErrorOverlay.Instance.ShowError("RoomInRoomError", false, true, 4f);
			flag5 = false;
		}
		if (flag5)
		{
			for (int num6 = CurrentSegments.Count - 1; num6 >= 0; num6--)
			{
				Vector2 pos = CurrentSegments[num6].Pos;
				Vector2 pos2 = CurrentSegments[(num6 + 1) % CurrentSegments.Count].Pos;
				for (int num7 = 0; num7 < list.Count; num7++)
				{
					WallEdge wallEdge3 = list[num7];
					foreach (KeyValuePair<IRoom, WallEdge> link2 in wallEdge3.Links)
					{
						if (Utilities.LinesIntersect(pos, pos2, wallEdge3.Pos, link2.Value.Pos, true, false))
						{
							ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
							flag5 = false;
							break;
						}
					}
					if (!flag5)
					{
						break;
					}
				}
				if (!flag5)
				{
					break;
				}
			}
		}
		if (flag5 && IsInRoof(floor))
		{
			flag5 = false;
		}
		if (flag5)
		{
			Room splitRoom;
			List<WallEdge> splitSegments = GetSplitSegments(out splitRoom, floor);
			if (splitSegments != null && splitRoom != null)
			{
				float roomCost = GetRoomCost(GetActualSplitEdgesForCost(splitSegments, splitRoom, null, null, Vector2.zero, false), splitRoom.Outdoors || splitRoom.IsUpperAtrium, false, splitRoom.Floor, !splitRoom.IsUpperAtriumNotBalcony, false, false);
				bool flag6 = false;
				if (undos == null)
				{
					undos = new List<UndoObject.UndoAction>();
					flag6 = true;
				}
				room = MakeSplit(splitSegments, splitRoom, new Vector2(rectPoints.AverageOrDefault((Vector2 x) => x.x), rectPoints.AverageOrDefault((Vector2 x) => x.y)), undos, roomCost, true, ignore, ignoreSupport);
				if (room != null)
				{
					CostDisplay.Instance.FloatAway(roomCost);
					cost = roomCost;
					GameSettings.Instance.MyCompany.MakeTransaction(0f - roomCost, Company.TransactionCategory.Construction, true, "Room");
					UISoundFX.PlaySFX("PlaceRoom", true);
					UISoundFX.PlaySFX("Kaching");
					ErrorOverlay.Instance.Clear();
					if (flag6)
					{
						GameSettings.Instance.AddUndo(undos.ToArray());
					}
					if (clearOnDone)
					{
						if (PlaceMulti())
						{
							BeginRectBuilding(FenceMode);
						}
						else
						{
							ClearBuild();
						}
					}
					return room;
				}
				UISoundFX.PlaySFX("BuildError");
				CurrentSegments = null;
			}
			else
			{
				List<Room> rs = (from x in GameSettings.Instance.sRoomManager.GetRooms()
					where x.Floor == floor
					select x).ToList();
				if (flag5 && CurrentSegments.Where((WallEdge x) => x.Links.Count == 0 && !x.IsSplitter).Any((WallEdge x) => rs.Any((Room z) => z.IsInside(x.Pos))))
				{
					ErrorOverlay.Instance.ShowError("RoomInRoomError", false, true, 4f);
					flag5 = false;
				}
				if (flag5 && !ignoreSupport && !GameSettings.Instance.sRoomManager.IsSupported(CurrentSegments.Select((WallEdge x) => x.Pos), floor, null))
				{
					ErrorOverlay.Instance.ShowError("UnsupportedStructure", false, true, 4f);
					flag5 = false;
				}
				if (flag5 && (IsOnRoad(rectPoints[0], rectPoints[1], floor) || IsOnRoad(rectPoints[1], rectPoints[2], floor) || IsOnRoad(rectPoints[2], rectPoints[3], floor) || IsOnRoad(rectPoints[3], rectPoints[0], floor)))
				{
					ErrorOverlay.Instance.ShowError("RoomOnRoad2", false, true, 4f);
					flag5 = false;
				}
				if (flag5 && (IsOnPath(rectPoints[0], rectPoints[1], floor) || IsOnPath(rectPoints[1], rectPoints[2], floor) || IsOnPath(rectPoints[2], rectPoints[3], floor) || IsOnPath(rectPoints[3], rectPoints[0], floor) || ContainsPath(rectPoints, floor)))
				{
					ErrorOverlay.Instance.ShowError("RoomOnPath", false, true, 4f);
					flag5 = false;
				}
				if (flag5 && !GameSettings.Instance.PlayerOwnedArea(rectPoints, true))
				{
					ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
					flag5 = false;
				}
				if (flag5 && CurrentSegments.ToHashSet().Count == 1)
				{
					ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
					flag5 = false;
				}
				if (!CheckAgainstPrefab())
				{
					flag5 = false;
				}
				if (flag5 && !ContainsPoints(true, floor) && !ClampingRoom(true) && !HalfPointCheck(true, floor) && (ignoreSelf || !CurrentSegments.Any((WallEdge x) => TooClose(x.Pos, x))))
				{
					CostDisplay.Instance.FloatAway(cost);
					GameSettings.Instance.MyCompany.MakeTransaction(0f - cost, Company.TransactionCategory.Construction, true, "Room");
					UISoundFX.PlaySFX("PlaceRoom", true);
					UISoundFX.PlaySFX("Kaching");
					ErrorOverlay.Instance.Clear();
					bool flag7 = false;
					if (undos == null)
					{
						undos = new List<UndoObject.UndoAction>();
						flag7 = true;
					}
					FinalizeCuts(false, floor, undos);
					GameSettings.Instance.sRoomManager.AllSegments.AddRange(CurrentSegments);
					Room room2 = MakeRoom(CurrentSegments, fenceMode, isPillar, undos, true, true, floor);
					undos.Insert(0, new UndoObject.UndoAction(room2, true, cost));
					if (flag7)
					{
						GameSettings.Instance.AddUndo(undos.ToArray());
					}
					GameSettings.Instance.sRoomManager.AddRoom(room2);
					room = room2;
					if (clearOnDone)
					{
						if (PlaceMulti())
						{
							BeginRectBuilding(FenceMode);
						}
						else
						{
							ClearBuild();
						}
					}
				}
				else
				{
					UISoundFX.PlaySFX("BuildError");
					CurrentSegments = null;
				}
			}
		}
		else
		{
			UISoundFX.PlaySFX("BuildError");
			CurrentSegments = null;
		}
		return room;
	}

	public bool IsValidSplit()
	{
		if (CurrentSegments.Count < 2)
		{
			return false;
		}
		WallEdge wallEdge = CurrentSegments[0];
		WallEdge wallEdge2 = CurrentSegments[CurrentSegments.Count - 1];
		if (wallEdge.IsSplitter || wallEdge.Links.Count > 0)
		{
			if (!wallEdge2.IsSplitter)
			{
				return wallEdge2.Links.Count > 0;
			}
			return true;
		}
		return false;
	}

	public bool IsActive()
	{
		if (!alignNow && RectPoints == null && CurrentSegments == null && !(CurrentTempSegment != null) && !(CurrentFurnitureBuilder != null) && !(CurrentTempWall != null) && !RoadBuildCube.Instance.gameObject.activeSelf && !RoomCloneTool.Instance.gameObject.activeSelf && !WallRemovalTool.Instance.gameObject.activeSelf && !EnvironmentEditor.Instance.gameObject.activeSelf && !HUD.Instance.roofEditWindow.Window.Shown && !PathBuilder.Instance.enabled && !CurveBuilder.Instance.gameObject.activeSelf && !PillarToggler.Instance.gameObject.activeSelf && !WallDragTool.Instance.gameObject.activeSelf)
		{
			return AtriumTool.Instance.gameObject.activeSelf;
		}
		return true;
	}

	private bool AnyIntersections(WallEdge edge1, Vector2 b, WallEdge extraCheck = null)
	{
		Vector2 pos = edge1.Pos;
		for (int i = 0; i < CurrentSegments.Count - 1; i++)
		{
			Vector2 pos2 = CurrentSegments[i].Pos;
			Vector2 pos3 = CurrentSegments[i + 1].Pos;
			if (Utilities.LinesIntersect(pos, b, pos2, pos3, false, i < CurrentSegments.Count - 2))
			{
				ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
				return true;
			}
		}
		foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor))
		{
			Vector2 pos4 = item.Pos;
			foreach (WallEdge value in item.Links.Values)
			{
				if (!edge1.CanIntersect(item, value) && (extraCheck == null || !extraCheck.CanIntersect(item, value)))
				{
					Vector2 pos5 = value.Pos;
					if (Utilities.LinesIntersect(pos, b, pos4, pos5, true, false, false))
					{
						ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool AngleTooSteep(WallEdge e, bool last = false, bool withError = true)
	{
		if (last)
		{
			Vector2 pos = CurrentSegments[CurrentSegments.Count - 1].Pos;
			Vector2 pos2 = CurrentSegments[0].Pos;
			Vector2 pos3 = CurrentSegments[1].Pos;
			if (pos2.AngleBetween(pos, pos3) < MinAngle)
			{
				if (withError)
				{
					ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
				}
				return true;
			}
		}
		else
		{
			if (CurrentSegments.Count == 0 || (!CurrentSegments.Last().UpAgainst(e) && !e.UpAgainst(CurrentSegments.Last())))
			{
				if (e.Links.Count > 0 && CurrentSegments.Count > 0 && (isCutting != null || (CurrentSegments.Count == 1 && e.Links.Values.Any((WallEdge x) => CurrentSegments[0].Links.ContainsValue(x)))))
				{
					Vector2 pos4 = CurrentSegments.Last().Pos;
					foreach (WallEdge value in e.Links.Values)
					{
						if (e.Pos.AngleBetween(pos4, value.Pos) < MinAngle)
						{
							if (withError)
							{
								ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
							}
							return true;
						}
					}
				}
				if (CurrentSegments.Count > 0 && CurrentSegments.Last().Links.Count > 0 && (isCutting != null || (CurrentSegments.Count == 1 && e.Links.Values.Any((WallEdge x) => CurrentSegments[0].Links.ContainsValue(x)))))
				{
					Vector2 pos5 = CurrentSegments.Last().Pos;
					foreach (WallEdge value2 in CurrentSegments.Last().Links.Values)
					{
						if (pos5.AngleBetween(e.Pos, value2.Pos) < MinAngle)
						{
							if (withError)
							{
								ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
							}
							return true;
						}
					}
					foreach (WallEdge item in CurrentSegments.Last().FindAllConnectionIn())
					{
						if (pos5.AngleBetween(e.Pos, item.Pos) < MinAngle)
						{
							if (withError)
							{
								ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
							}
							return true;
						}
					}
				}
				if (CurrentSegments.Count > 0 && e.IsSplitter)
				{
					WallEdge[] getSplitEdges = e.GetSplitEdges;
					Vector2 pos6 = CurrentSegments.Last().Pos;
					for (int num = 0; num < getSplitEdges.Length; num++)
					{
						float num2 = e.Pos.AngleBetween(pos6, getSplitEdges[num].Pos);
						if (num2 > 0f && num2 < MinAngle)
						{
							if (withError)
							{
								ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
							}
							return true;
						}
					}
				}
				if (CurrentSegments.Count > 0 && CurrentSegments.Last().IsSplitter)
				{
					WallEdge[] getSplitEdges2 = CurrentSegments.Last().GetSplitEdges;
					Vector2 pos7 = CurrentSegments.Last().Pos;
					for (int num3 = 0; num3 < getSplitEdges2.Length; num3++)
					{
						float num4 = pos7.AngleBetween(e.Pos, getSplitEdges2[num3].Pos);
						if (num4 > 0f && num4 < MinAngle)
						{
							if (withError)
							{
								ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
							}
							return true;
						}
					}
				}
				if (CurrentSegments.Count > 0 && e.Links.Count > 0 && isCutting != null)
				{
					WallEdge wallEdge = e.Links[isCutting];
					Vector2 pos8 = CurrentSegments.Last().Pos;
					if (e.Pos.AngleBetween(pos8, wallEdge.Pos) < MinAngle)
					{
						if (withError)
						{
							ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
						}
						return true;
					}
					wallEdge = e.FindConnectionIn(isCutting);
					if (wallEdge != null && e.Pos.AngleBetween(pos8, wallEdge.Pos) < MinAngle)
					{
						if (withError)
						{
							ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
						}
						return true;
					}
				}
			}
			if (CurrentSegments.Count > 1)
			{
				Vector2 pos9 = CurrentSegments[CurrentSegments.Count - 2].Pos;
				if (CurrentSegments[CurrentSegments.Count - 1].Pos.AngleBetween(pos9, e.Pos) < MinAngle)
				{
					if (withError)
					{
						ErrorOverlay.Instance.ShowError("RoomAngleError2".Loc(MinAngle), false, true, 4f, false);
					}
					return true;
				}
			}
		}
		return false;
	}

	private static float FloorFact(int floor)
	{
		return Mathf.Pow(1.1f, Mathf.Max(0, floor));
	}

	public static float GetRoomCost(float wallLength, float area, bool outdoor, bool pillar, int floor, bool justSplit, bool rent, bool atrium)
	{
		if (rent)
		{
			if (pillar || area <= 0f)
			{
				return 0f;
			}
			float num = ((!GameSettings.Instance.IsReferenceNull()) ? GameSettings.Instance.Difficulty.RentCostFactor : ((ActorCustomization.Instance != null) ? ActorCustomization.Instance.GetDifficulty().RentCostFactor : 1f));
			return FloorFact(floor) * area * (outdoor ? OutdoorRentPrice : RoomRentPrice) * num;
		}
		float num2 = ((justSplit || atrium) ? 0f : (FloorFact(floor) * area * (outdoor ? OutdoorPrice : (pillar ? PillarPrice : RoomPrice))));
		float num3 = wallLength * (outdoor ? FencePrice : WallPrice);
		if (atrium)
		{
			num3 *= FloorFact(floor);
		}
		return num2 + num3;
	}

	public static float GetRoomCost(IList<Vector2> wallEdges, float area, bool outdoor, bool pillar, int floor, bool justSplit, bool rent, bool atrium)
	{
		float num = 0f;
		if (!rent)
		{
			for (int i = 0; i < wallEdges.Count - 1; i++)
			{
				num += (wallEdges[i] - wallEdges[i + 1]).magnitude;
			}
			if (!justSplit && wallEdges.Count > 1)
			{
				num += (wallEdges[0] - wallEdges[wallEdges.Count - 1]).magnitude;
			}
		}
		return GetRoomCost(num, area, outdoor, pillar, floor, justSplit, rent, atrium);
	}

	public static float GetRoomCost(Room r, bool justSplit, bool rent)
	{
		float num = 0f;
		if (!rent)
		{
			for (int i = 0; i < r.Edges.Count - 1; i++)
			{
				num += (r.Edges[i].Pos - r.Edges[i + 1].Pos).magnitude;
			}
			if (!justSplit && r.Edges.Count > 1)
			{
				num += (r.Edges[0].Pos - r.Edges[r.Edges.Count - 1].Pos).magnitude;
			}
		}
		return GetRoomCost(num, r.Area, r.Outdoors || r.IsBalcony, r.Pillar, r.Floor, justSplit, rent, r.IsUpperAtriumNotBalcony);
	}

	public static float GetRoomCost(IList<WallEdge> wallEdges, float area, bool outdoor, bool pillar, int floor, bool justSplit, bool rent, bool atrium)
	{
		float num = 0f;
		if (!rent)
		{
			for (int i = 0; i < wallEdges.Count - 1; i++)
			{
				num += (wallEdges[i].Pos - wallEdges[i + 1].Pos).magnitude;
			}
			if (!justSplit && wallEdges.Count > 1)
			{
				num += (wallEdges[0].Pos - wallEdges[wallEdges.Count - 1].Pos).magnitude;
			}
		}
		return GetRoomCost(num, area, outdoor, pillar, floor, justSplit, rent, atrium);
	}

	public static float GetRoomCost(IList<Vector2> wallEdges, bool outdoor, bool pillar, int floor, bool justSplit, bool rent, bool atrium)
	{
		return GetRoomCost(wallEdges, (!rent && justSplit) ? 0f : Utilities.PolygonArea(wallEdges), outdoor, pillar, floor, justSplit, rent, atrium);
	}

	public static float GetRoomCost(IList<WallEdge> wallEdges, bool outdoor, bool pillar, int floor, bool justSplit, bool rent, bool atrium)
	{
		return GetRoomCost(wallEdges, (!rent && justSplit) ? 0f : Utilities.PolygonArea(wallEdges), outdoor, pillar, floor, justSplit, rent, atrium);
	}

	public static bool IsOnRoad(Vector2 p1, Vector2 p2, int floor)
	{
		Vector2 vector = p2 - p1;
		float magnitude = vector.magnitude;
		float num = 0f;
		vector = vector.normalized;
		Vector2 vector2 = p1;
		int num2 = 1;
		while (true)
		{
			if (IsPointOnRoad(vector2, floor))
			{
				return true;
			}
			if (vector2 == p2)
			{
				break;
			}
			num += (float)num2;
			if (num > magnitude)
			{
				vector2 = p2;
			}
			else
			{
				vector2 += vector * num2;
			}
		}
		return false;
	}

	public static bool IsOnRoad(Vector2 p1, Vector2 p2)
	{
		return IsOnRoad(p1, p2, GameSettings.Instance.ActiveFloor);
	}

	public static bool IsOnPath(Vector2 p1, Vector2 p2)
	{
		return IsOnPath(p1, p2, GameSettings.Instance.ActiveFloor);
	}

	public static bool IsOnPath(Vector2 p1, Vector2 p2, int floor)
	{
		if (floor != 0)
		{
			return false;
		}
		PathController pathController = GameSettings.Instance.sRoomManager.PathController;
		for (int i = 0; i < pathController.AllPoints.Count; i++)
		{
			PathController.PathPoint pathPoint = pathController.AllPoints[i];
			Vector2 point = pathPoint.Point;
			for (int j = 0; j < pathPoint.Connections.Count; j++)
			{
				PathController.PathPoint key = pathPoint.Connections[j].Key;
				if (pathPoint.ID > key.ID)
				{
					Vector2 point2 = key.Point;
					if (point != point2 && Utilities.LinesIntersect(point, point2, p1, p2, false, false, true))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public static bool ContainsPath(IList<Vector2> area)
	{
		return ContainsPath(area, GameSettings.Instance.ActiveFloor);
	}

	public static bool ContainsPath(IList<Vector2> area, int floor)
	{
		if (floor != 0)
		{
			return false;
		}
		_pathCheckCache.Clear();
		bool num = Utilities.Clockwise(area);
		Vector2 vector = (num ? area[1] : area[area.Count - 1]);
		if (num)
		{
			for (int num2 = area.Count - 1; num2 >= 0; num2--)
			{
				Vector2 vector2 = area[num2];
				_pathCheckCache.Add(Utilities.GetOffset((num2 == 0) ? area[area.Count - 1] : area[num2 - 1], vector2, vector, 0f - Room.WallOffset, true));
				vector = vector2;
			}
		}
		else
		{
			for (int i = 0; i < area.Count; i++)
			{
				Vector2 vector3 = area[i];
				_pathCheckCache.Add(Utilities.GetOffset(vector, vector3, area[(i + 1) % area.Count], Room.WallOffset, true));
				vector = vector3;
			}
		}
		PathController pathController = GameSettings.Instance.sRoomManager.PathController;
		for (int j = 0; j < pathController.AllPoints.Count; j++)
		{
			if (Utilities.IsInside(pathController.AllPoints[j].Point, _pathCheckCache))
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsPointOnRoad(Vector2 p, int floor)
	{
		float num = p.x / RoadManager.Instance.RoadSize;
		float num2 = p.y / RoadManager.Instance.RoadSize;
		if (num < 0.9999f || num2 < 0.9999f || num > (float)RoadManager.Instance.GridSize - 0.9999f || num2 > (float)RoadManager.Instance.GridSize - 0.9999f)
		{
			return true;
		}
		if (floor < 0 || floor >= RoadManager.Floors * 2 + 2)
		{
			return false;
		}
		int num3 = Mathf.FloorToInt(num);
		int num4 = Mathf.FloorToInt(num2);
		bool roadClearance = RoadManager.Instance.GetRoadClearance(num3, num4, floor, true);
		bool flag = Mathf.Approximately(p.x % RoadManager.Instance.RoadSize, 0f);
		bool flag2 = Mathf.Approximately(p.y % RoadManager.Instance.RoadSize, 0f);
		if (flag && flag2)
		{
			if (!roadClearance && !RoadManager.Instance.GetRoadClearance(num3 - 1, num4, floor, true) && !RoadManager.Instance.GetRoadClearance(num3, num4 - 1, floor, true) && !RoadManager.Instance.GetRoadClearance(num3 - 1, num4 - 1, floor, true))
			{
				return true;
			}
			return false;
		}
		if (flag)
		{
			if (!roadClearance && !RoadManager.Instance.GetRoadClearance(num3 - 1, num4, floor, true))
			{
				return true;
			}
			return false;
		}
		if (flag2)
		{
			if (!roadClearance && !RoadManager.Instance.GetRoadClearance(num3, num4 - 1, floor, true))
			{
				return true;
			}
			return false;
		}
		if (!roadClearance)
		{
			return true;
		}
		return false;
	}

	public bool ClampingRoom(bool withError)
	{
		if (CurrentSegments.Any((WallEdge x) => x.Links.Count == 0 && !x.IsSplitter))
		{
			return false;
		}
		List<IRoom> list = CurrentSegments.SelectMany((WallEdge x) => x.Links.Keys).ToList();
		list.AddRange(CurrentSegments.Where((WallEdge x) => x.IsSplitter).SelectMany((WallEdge x) => x.GetSplitRooms));
		list = list.Where((IRoom x) => x != null).Distinct().ToList();
		if (list.Count == 0)
		{
			return false;
		}
		List<WallEdge> list2 = CurrentSegments.ToList();
		if (Utilities.Clockwise(list2.Select((WallEdge x) => x.Pos).ToList()))
		{
			list2.Reverse();
		}
		foreach (IRoom item in list)
		{
			for (int num = 0; num < list2.Count; num++)
			{
				int index = (num + 1) % list2.Count;
				WallEdge e1 = list2[num];
				WallEdge e2 = list2[index];
				if (e1.Links.Count > 0)
				{
					if (e2.Links.Count > 0)
					{
						if (e1.Links.ContainsKey(item) && e1.Links[item] == e2)
						{
							if (withError)
							{
								ErrorOverlay.Instance.ShowError("RoomInsideError", false, true, 4f);
							}
							return true;
						}
						continue;
					}
					WallEdge[] getSplitEdges = e2.GetSplitEdges;
					if (!getSplitEdges.Contains(e1))
					{
						continue;
					}
					WallEdge wallEdge = getSplitEdges.First((WallEdge x) => x != e1);
					if (e1.Links.ContainsKey(item) && wallEdge.Links.ContainsKey(item) && wallEdge.Links[item] != e1)
					{
						if (withError)
						{
							ErrorOverlay.Instance.ShowError("RoomInsideError", false, true, 4f);
						}
						return true;
					}
					continue;
				}
				if (e2.Links.Count > 0)
				{
					WallEdge wallEdge2 = e1.GetSplitEdges.First((WallEdge x) => x != e2);
					if (wallEdge2.Links.ContainsKey(item) && wallEdge2.Links[item] == e2)
					{
						if (withError)
						{
							ErrorOverlay.Instance.ShowError("RoomInsideError", false, true, 4f);
						}
						return true;
					}
					continue;
				}
				WallEdge[] getSplitEdges2 = e1.GetSplitEdges;
				WallEdge[] getSplitEdges3 = e2.GetSplitEdges;
				WallEdge wallEdge3 = getSplitEdges2[0];
				WallEdge wallEdge4 = getSplitEdges2[1];
				if (!getSplitEdges2.Contains(getSplitEdges3[0]) || !getSplitEdges2.Contains(getSplitEdges3[1]))
				{
					continue;
				}
				if (!wallEdge3.Links.ContainsKey(item) || wallEdge3.Links[item] != wallEdge4)
				{
					WallEdge wallEdge5 = wallEdge3;
					wallEdge3 = wallEdge4;
					wallEdge4 = wallEdge5;
				}
				if (!wallEdge3.Links.ContainsKey(item) || wallEdge3.Links[item] != wallEdge4)
				{
					continue;
				}
				float sqrMagnitude = (wallEdge3.Pos - e1.Pos).sqrMagnitude;
				float sqrMagnitude2 = (wallEdge3.Pos - e2.Pos).sqrMagnitude;
				if (sqrMagnitude < sqrMagnitude2)
				{
					if (withError)
					{
						ErrorOverlay.Instance.ShowError("RoomInsideError", false, true, 4f);
					}
					return true;
				}
			}
		}
		return false;
	}

	public Vector2 SnapToWall(Vector2 p, out WallEdge a, out WallEdge b)
	{
		a = null;
		b = null;
		Vector2 result;
		foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor))
		{
			result = p - item.Pos;
			if (!(result.magnitude < _instanceSnap))
			{
				continue;
			}
			a = item;
			result = item.Pos;
			goto IL_0120;
		}
		using (IEnumerator<WallEdge> enumerator = GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor).GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					WallEdge current2 = enumerator.Current;
					foreach (WallEdge value in current2.Links.Values)
					{
						Vector2 res;
						if (Utilities.ProjectToLine(p, current2.Pos, value.Pos, out res) && (p - res).magnitude < _instanceSnap)
						{
							a = current2;
							b = value;
							result = res;
							goto end_IL_0107;
						}
					}
					continue;
				}
				return p;
				continue;
				end_IL_0107:
				break;
			}
		}
		goto IL_0120;
		IL_0120:
		return result;
	}

	public bool CanChangeFloor()
	{
		if ((CurrentSegments == null || CurrentSegments.Count == 0) && (CurrentTempSegment == null || DynSegmentE1 == null) && !RectDragging && !EnvironmentEditor.Instance.gameObject.activeSelf && !HUD.Instance.roofEditWindow.Window.Shown && !PathBuilder.Instance.enabled && CurveBuilder.CanChangeFloor())
		{
			return WallDragTool.CanChangeFloor();
		}
		return false;
	}

	private bool IsInRoof()
	{
		return IsInRoof(GameSettings.Instance.ActiveFloor);
	}

	private bool IsInRoof(int floor)
	{
		List<Vector2> list = CurrentSegments.Select((WallEdge x) => x.Pos).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			Vector2 p = list[num];
			Vector2 p2 = list[(num + 1) % CurrentSegments.Count];
			for (int num2 = 0; num2 < GameSettings.Instance.sRoomManager.Roofs.Count; num2++)
			{
				Roof roof = GameSettings.Instance.sRoomManager.Roofs[num2];
				if (roof.Floor != floor)
				{
					continue;
				}
				if (Utilities.IsInside(p, roof.Area, Roof.SideBuildDistance))
				{
					ErrorOverlay.Instance.ShowError("RoofIntersectError", false, true, 4f);
					return true;
				}
				for (int num3 = 0; num3 < roof.Area.Count; num3++)
				{
					Vector2 vector = roof.Area[num3];
					Vector2 q = roof.Area[(num3 + 1) % roof.Area.Count];
					if (Utilities.IsInside(vector, list))
					{
						ErrorOverlay.Instance.ShowError("RoofIntersectError", false, true, 4f);
						return true;
					}
					if (Utilities.LinesIntersect(p, p2, vector, q, true, false))
					{
						ErrorOverlay.Instance.ShowError("RoofIntersectError", false, true, 4f);
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool IsPillar()
	{
		if (!FenceMode)
		{
			if (!Input.GetKey(KeyCode.LeftControl))
			{
				return Input.GetKey(KeyCode.RightControl);
			}
			return true;
		}
		return false;
	}

	private bool CheckAgainstPrefab()
	{
		if (ActivePrefab != null)
		{
			if (ActivePrefab.CheckRoom(CurrentSegments.SelectInPlace((WallEdge x) => x.Pos), GameSettings.Instance.ActiveFloor, FenceMode, IsPillar()))
			{
				return true;
			}
			ErrorOverlay.Instance.ShowError("ForcedPrefabError", false, true, 4f);
			return false;
		}
		return true;
	}

	private bool BuildRoomNow()
	{
		float roomCost = GetRoomCost(CurrentSegments.Select((WallEdge x) => x.Pos).ToList(), FenceMode, IsPillar(), GameSettings.Instance.ActiveFloor, false, false, false);
		if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - roomCost) && CheckAgainstPrefab())
		{
			CostDisplay.Instance.FloatAway(roomCost);
			GameSettings.Instance.MyCompany.MakeTransaction(0f - roomCost, Company.TransactionCategory.Construction, true, "Room");
			UISoundFX.PlaySFX("PlaceRoom", true);
			UISoundFX.PlaySFX("Kaching");
			ErrorOverlay.Instance.Clear();
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			FinalizeCuts(false, GameSettings.Instance.ActiveFloor, list);
			GameSettings.Instance.sRoomManager.AllSegments.AddRange(CurrentSegments);
			Room room = MakeRoom(CurrentSegments, FenceMode, IsPillar(), list);
			list.Insert(0, new UndoObject.UndoAction(room, true, roomCost));
			GameSettings.Instance.AddUndo(list.ToArray());
			room.Outdoors = FenceMode;
			GameSettings.Instance.sRoomManager.AddRoom(room);
			if (PlaceMulti())
			{
				ActivateBuildMode(FenceMode);
			}
			else
			{
				ClearBuild();
			}
			return true;
		}
		HUD.FlashMoney();
		UISoundFX.PlaySFX("BuildError");
		return false;
	}

	private bool SanityCheck()
	{
		for (int i = 0; i < CurrentSegments.Count; i++)
		{
			Vector2 pos = CurrentSegments[i].Pos;
			Vector2 pos2 = CurrentSegments[(i + 1) % CurrentSegments.Count].Pos;
			Vector2 mid = (pos + pos2) * 0.5f;
			if (GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && x.IsInside(mid, 0.02f)) != null)
			{
				ErrorOverlay.Instance.ShowError("RoomInRoomError", false, true, 4f);
				return false;
			}
		}
		return true;
	}

	private List<WallEdge> GetActualSplitEdgesForCost(List<WallEdge> input, Room isSplitting, WallEdge snapA, WallEdge snapB, Vector2 p, bool reverse)
	{
		if (isSplitting.IsUpperAtriumNotBalcony && (snapA == null || isSplitting.Edges.Contains(snapA)))
		{
			List<WallEdge> list = input.ToList();
			if (snapA != null)
			{
				WallEdge wallEdge = snapA;
				if (snapB != null)
				{
					wallEdge = new WallEdge(p, GameSettings.Instance.ActiveFloor);
					wallEdge.SetSplit(snapA, isSplitting);
				}
				list.Add(wallEdge);
			}
			if (!reverse)
			{
				list.Reverse();
			}
			WallEdge value = list.Last();
			WallEdge wallEdge2 = value;
			WallEdge wallEdge3 = list[0];
			int i = 1;
			if (wallEdge3.IsSplitter)
			{
				i = 0;
				wallEdge3 = wallEdge3.GetSplitEdges[0];
			}
			List<WallEdge> list2 = new List<WallEdge>();
			while (value != wallEdge3)
			{
				list2.Add(value);
				if (value.IsSplitter)
				{
					value = value.GetSplitEdges[1];
				}
				else if (!value.Links.TryGetValue(isSplitting, out value))
				{
					return input;
				}
				if (value == wallEdge2)
				{
					break;
				}
			}
			list2.Add(wallEdge3);
			for (; i < list.Count - 1; i++)
			{
				list2.Add(list[i]);
			}
			return list2;
		}
		return input;
	}

	private void RoomBuildingCode(Vector2 p, WallEdge snapA, WallEdge snapB)
	{
		float num = 0f;
		if (CurrentSegments != null)
		{
			if (LastPos != p && !NoGrid())
			{
				if (CurrentSegments.Count > 0)
				{
					float pitch = 1f + Mathf.Clamp(((CurrentSegments[CurrentSegments.Count - 1].Pos - p).magnitude - 4f) / 12f, 0f, 2f);
					UISoundFX.PlaySFX("Tick", pitch, 0f, true);
				}
				else
				{
					UISoundFX.PlaySFX("Tick", true);
				}
			}
			LastPos = p;
			if (CurrentSegments.Count > 0)
			{
				BuildingHUD.Instance.Enable(true, false, CurrentSegments.Count > 0);
				Vector2 pos = CurrentSegments.Last().Pos;
				int num2 = GameSettings.Instance.ActiveFloor * 2;
				BuildingHUD.Instance.SetDimension(new Vector3(pos.x, num2, pos.y), new Vector3(p.x, num2, p.y));
				if (_ang1 != null)
				{
					Vector2 pos2 = _ang1.Pos;
					BuildingHUD.Instance.SetRot(new Vector3(pos2.x, num2, pos2.y), new Vector3(pos.x, num2, pos.y), new Vector3(p.x, num2, p.y));
				}
				else if (CurrentSegments.Count > 1)
				{
					Vector2 pos3 = CurrentSegments[CurrentSegments.Count - 2].Pos;
					BuildingHUD.Instance.SetRot(new Vector3(pos3.x, num2, pos3.y), new Vector3(pos.x, num2, pos.y), new Vector3(p.x, num2, p.y));
				}
				else if (CurrentSegments.Count > 0)
				{
					Vector3 vector = Quaternion.Euler(0f, GetGridRotation(), 0f) * Vector3.left;
					Vector2 vector2 = pos + new Vector2(vector.x, vector.z);
					BuildingHUD.Instance.SetRot(new Vector3(vector2.x, num2, vector2.y), new Vector3(pos.x, num2, pos.y), new Vector3(p.x, num2, p.y));
				}
			}
			else
			{
				BuildingHUD.Instance.Enable(false, false, false);
			}
			Room room = isCutting;
			Room room2 = isCutting;
			if (room2 == null && CurrentSegments.Count > 0)
			{
				Vector2 pos4 = CurrentSegments.Last().Pos;
				room2 = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, (p + pos4) * 0.5f, true, false);
				if (room2 != null && room2.Outside)
				{
					room2 = null;
				}
			}
			if (isCutting != null)
			{
				num = ((snapA == null) ? GetRoomCost(CurrentSegments.Select((WallEdge wallEdge6) => wallEdge6.Pos).Concate(p).ToList(), isCutting.Outdoors || isCutting.IsUpperAtrium, IsPillar(), GameSettings.Instance.ActiveFloor, true, false, false) : GetRoomCost(GetActualSplitEdgesForCost(CurrentSegments, isCutting, snapA, snapB, p, Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)), isCutting.Outdoors || isCutting.IsUpperAtrium, IsPillar(), GameSettings.Instance.ActiveFloor, !isCutting.IsUpperAtriumNotBalcony, false, false));
			}
			else if (room2 != null && CurrentSegments.Count == 1 && (CurrentSegments[0].IsSplitter || CurrentSegments[0].Links.Count > 0))
			{
				room = room2;
				num = ((snapA == null) ? GetRoomCost(new List<Vector2>
				{
					CurrentSegments[0].Pos,
					p
				}, FenceMode || room.IsUpperAtrium, IsPillar(), GameSettings.Instance.ActiveFloor, true, false, false) : GetRoomCost(GetActualSplitEdgesForCost(CurrentSegments, room, snapA, snapB, p, Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)), FenceMode || room.IsUpperAtrium, IsPillar(), GameSettings.Instance.ActiveFloor, !room.IsUpperAtriumNotBalcony, false, false));
			}
			else if (CurrentSegments.Count > 2)
			{
				num = GetRoomCost(CurrentSegments.Select((WallEdge wallEdge6) => wallEdge6.Pos).ToList(), FenceMode, IsPillar(), GameSettings.Instance.ActiveFloor, false, false, false);
			}
			if (room != null && room.IsUpperAtriumNotBalcony)
			{
				Vector2 pos5 = CurrentSegments.Last().Pos;
				if (pos5 != p)
				{
					Arrow.SetActive(true);
					Arrow.transform.position = ((p + pos5) * 0.5f).ToVector3((float)(GameSettings.Instance.ActiveFloor * 2) + 2.5f);
					Vector3 vector3 = (p - pos5).ToVector3(0f);
					if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
					{
						vector3 = -vector3;
					}
					Arrow.transform.rotation = Quaternion.LookRotation(vector3);
					ErrorOverlay.Instance.ShowError("InvertBalcony", false, false, 0f, true, true);
				}
				else
				{
					Arrow.SetActive(false);
				}
			}
			else
			{
				Arrow.SetActive(false);
			}
		}
		bool flag = true;
		if (CurrentSegments != null)
		{
			for (int num3 = 0; num3 < GameSettings.Instance.sRoomManager.Roofs.Count; num3++)
			{
				Roof roof = GameSettings.Instance.sRoomManager.Roofs[num3];
				if (roof.Floor != GameSettings.Instance.ActiveFloor)
				{
					continue;
				}
				if (Utilities.IsInside(p, roof.Area, Roof.SideBuildDistance))
				{
					ErrorOverlay.Instance.ShowError("RoofIntersectError");
					flag = false;
					break;
				}
				if (CurrentSegments.Count > 0)
				{
					for (int num4 = 0; num4 < roof.Area.Count; num4++)
					{
						Vector2 q = roof.Area[num4];
						Vector2 q2 = roof.Area[(num4 + 1) % roof.Area.Count];
						if (Utilities.LinesIntersect(CurrentSegments[CurrentSegments.Count - 1].Pos, p, q, q2, true, false))
						{
							ErrorOverlay.Instance.ShowError("RoofIntersectError");
							flag = false;
							break;
						}
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}
		if (flag && CurrentSegments != null)
		{
			if (!GameSettings.Instance.PlayerOwnedPoint(p, true))
			{
				ErrorOverlay.Instance.ShowError("RoomOutOfPlot");
				flag = false;
			}
			else if (CurrentSegments.Count > 0 && !GameSettings.Instance.PlayerOwnedLine(CurrentSegments[CurrentSegments.Count - 1].Pos, p, true))
			{
				ErrorOverlay.Instance.ShowError("RoomOutOfPlot");
				flag = false;
			}
			else if (IsOnRoad(p, (CurrentSegments.Count > 0) ? CurrentSegments.Last().Pos : p))
			{
				ErrorOverlay.Instance.ShowError("RoomOnRoad2");
				flag = false;
			}
			else if (CurrentSegments.Count > 0 && IsOnPath(p, CurrentSegments.Last().Pos))
			{
				ErrorOverlay.Instance.ShowError("RoomOnPath");
				flag = false;
			}
			else if (!GameSettings.Instance.sRoomManager.IsSupported(p, GameSettings.Instance.ActiveFloor, null))
			{
				ErrorOverlay.Instance.ShowError("UnsupportedStructure");
				flag = false;
			}
		}
		if (!flag && CurrentSegments != null && Input.GetMouseButtonUp(0))
		{
			UISoundFX.PlaySFX("BuildError");
		}
		bool flag2;
		int count;
		bool flag3;
		Room room3;
		WallEdge wallEdge;
		int num5;
		if (flag && CurrentSegments != null && Input.GetMouseButtonUp(0))
		{
			flag2 = false;
			ResetAutoComplete();
			count = CurrentSegments.Count;
			if (CurrentSegments.Count > 2 && p.Dist(CurrentSegments[0].Pos) < _instanceSnap)
			{
				if (!IsInRoof() && !ContainsPoints(true) && !AngleTooSteep(CurrentSegments.First()) && !AngleTooSteep(null, true) && isCutting == null && !ClampingRoom(true))
				{
					List<Vector2> list = CurrentSegments.Select((WallEdge wallEdge6) => wallEdge6.Pos).ToList();
					if (GameSettings.Instance.PlayerOwnedArea(list, true))
					{
						if (GameSettings.Instance.sRoomManager.IsSupported(list, GameSettings.Instance.ActiveFloor, null))
						{
							if (!ContainsPath(list))
							{
								if (SanityCheck())
								{
									BuildRoomNow();
									flag2 = true;
								}
							}
							else
							{
								ErrorOverlay.Instance.ShowError("RoomOnPath", false, true, 4f);
								UISoundFX.PlaySFX("BuildError");
							}
						}
						else
						{
							ErrorOverlay.Instance.ShowError("UnsupportedStructure", false, true, 4f);
							UISoundFX.PlaySFX("BuildError");
						}
					}
					else
					{
						ErrorOverlay.Instance.ShowError("RoomOutOfPlot", false, true, 4f);
						UISoundFX.PlaySFX("BuildError");
					}
				}
			}
			else if (!TooClose(p))
			{
				flag3 = true;
				room3 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room room8) => room8.Floor == GameSettings.Instance.ActiveFloor && room8.IsInside(p, true));
				wallEdge = GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor).FirstOrDefault((WallEdge wallEdge6) => wallEdge6.Pos.Dist(p) < _instanceSnap);
				if (wallEdge != null && !CurrentSegments.Contains(wallEdge))
				{
					if (!(isCutting == null))
					{
						num5 = (wallEdge.Links.ContainsKey(isCutting) ? 1 : 0);
						if (num5 == 0)
						{
							goto IL_0c93;
						}
					}
					else
					{
						num5 = 1;
					}
					flag3 = CurrentSegments.Count == 0 || !AnyIntersections(CurrentSegments.Last(), p);
				}
				else
				{
					num5 = 0;
				}
				goto IL_0c93;
			}
			goto IL_1b3f;
		}
		goto IL_1c9b;
		IL_1c9b:
		if (CurrentSegments != null && num > 0f)
		{
			Vector2 v = (((CurrentSegments.Count <= 0 || !CurrentSegments[0].IsSplitter) && !(isCutting != null)) ? Utilities.GetPolygonCentroid(CurrentSegments) : ((CurrentSegments[CurrentSegments.Count - 1].Pos + p) * 0.5f));
			CostDisplay.Instance.Show(num, v.ToVector3(GameSettings.Instance.ActiveFloor * 2 + 2), GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num) ? Color.white : Color.red);
		}
		else
		{
			CostDisplay.Instance.Hide();
		}
		return;
		IL_0c93:
		if (((uint)num5 & (flag3 ? 1u : 0u)) != 0)
		{
			if (!AngleTooSteep(wallEdge))
			{
				bool flag4 = true;
				if (CurrentSegments.Count > 0)
				{
					WallEdge wallEdge2 = CurrentSegments.Last();
					float x = (wallEdge2.Pos.x + wallEdge.Pos.x) / 2f;
					float y = (wallEdge2.Pos.y + wallEdge.Pos.y) / 2f;
					Vector2 ppp = new Vector2(x, y);
					Room room4 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room room8) => room8.Floor == GameSettings.Instance.ActiveFloor && room8.IsInside(ppp));
					if (room4 != null && wallEdge2.CouldSplit(room4) && wallEdge.CouldSplit(room4) && !wallEdge2.UpAgainst(wallEdge) && !wallEdge.UpAgainst(wallEdge2))
					{
						if (CurrentSegments.Count == 1)
						{
							isCutting = room4;
							if (AngleTooSteep(wallEdge))
							{
								isCutting = null;
								flag4 = false;
							}
						}
						else
						{
							flag4 = false;
						}
					}
				}
				if (flag4)
				{
					CurrentSegments.Add(wallEdge);
					if (isCutting != null && CurrentSegments.Count > 1)
					{
						float roomCost = GetRoomCost(GetActualSplitEdgesForCost(CurrentSegments, isCutting, null, null, p, Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)), isCutting.Outdoors || isCutting.IsUpperAtrium, false, GameSettings.Instance.ActiveFloor, !isCutting.IsUpperAtriumNotBalcony, false, false);
						if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - roomCost))
						{
							bool flag5 = false;
							if (isCutting.IsUpperAtriumNotBalcony && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
							{
								CurrentSegments.Reverse();
								flag5 = true;
							}
							if (ValidSplit())
							{
								string debug = string.Join("\n", CurrentSegments.Select((WallEdge wallEdge6) => wallEdge6.Pos.x + ";" + wallEdge6.Pos.y).ToArray()) + "\n\n" + string.Join("\n", isCutting.Edges.Select((WallEdge wallEdge6) => wallEdge6.Pos.x + ";" + wallEdge6.Pos.y).ToArray());
								List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
								FinalizeCuts(true, GameSettings.Instance.ActiveFloor, list2);
								Dictionary<WallSnap, UndoObject.UndoAction> snaps = isCutting.PrepareSplit(true);
								GameSettings.Instance.sRoomManager.AllSegments.AddRange(CurrentSegments);
								Room room5 = isCutting.Split(CurrentSegments, list2, snaps, debug);
								if (room5 != null)
								{
									flag2 = true;
									CostDisplay.Instance.FloatAway(roomCost);
									GameSettings.Instance.MyCompany.MakeTransaction(0f - roomCost, Company.TransactionCategory.Construction, true, "Room");
									UISoundFX.PlaySFX("PlaceRoom", true);
									UISoundFX.PlaySFX("Kaching");
									ErrorOverlay.Instance.Clear();
									GameSettings.Instance.sRoomManager.AddRoom(room5);
									List<UndoObject.UndoAction> list3 = new List<UndoObject.UndoAction>
									{
										new UndoObject.UndoAction(isCutting, room5, roomCost)
									};
									foreach (Furniture item in from furniture in isCutting.GetFurnitures().ToList()
										orderby furniture.GetSnappingDepth()
										select furniture)
									{
										if (item.IsAliveNotNull() && !item.UpdateParent(true, false))
										{
											item.UndoDestroyWithChildren(list3);
										}
									}
									list3.AddRange(list2);
									GameSettings.Instance.AddUndo(list3.ToArray());
									room5.RecalculateTableGroupsNow();
									isCutting.RecalculateTableGroupsNow();
									isCutting = null;
									if (PlaceMulti())
									{
										ActivateBuildMode(FenceMode);
									}
									else
									{
										ClearBuild();
									}
								}
								else
								{
									isCutting.OptimizeSegments();
									foreach (WallEdge currentSegment in CurrentSegments)
									{
										if (!isCutting.Edges.Contains(currentSegment))
										{
											GameSettings.Instance.sRoomManager.AllSegments.Remove(currentSegment);
										}
									}
									isCutting = null;
									if (PlaceMulti())
									{
										ActivateBuildMode(FenceMode);
									}
									else
									{
										ClearBuild();
									}
								}
							}
							else
							{
								if (flag5)
								{
									CurrentSegments.Reverse();
								}
								CurrentSegments.Remove(wallEdge);
								UISoundFX.PlaySFX("BuildError");
							}
						}
						else
						{
							HUD.FlashMoney();
							CurrentSegments.Remove(wallEdge);
							UISoundFX.PlaySFX("BuildError");
						}
					}
					else
					{
						CurrentSegments.Remove(wallEdge);
						if (flag3)
						{
							AddSegment(wallEdge);
							if (ValidForAutoComplete())
							{
								CheckForAutoComplete();
							}
						}
					}
				}
			}
		}
		else
		{
			WallEdge split = null;
			foreach (WallEdge item2 in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor))
			{
				foreach (KeyValuePair<IRoom, WallEdge> link in item2.Links)
				{
					Vector2 res;
					if (Utilities.ProjectToLine(p, item2.Pos, link.Value.Pos, out res) && res.Dist(p) < _instanceSnap)
					{
						split = new WallEdge(res, GameSettings.Instance.ActiveFloor);
						split.SetSplit(item2, (Room)link.Key);
						break;
					}
				}
				if (split != null)
				{
					break;
				}
			}
			int num6;
			if (split != null)
			{
				num6 = ((!TooClose(split.Pos)) ? 1 : 0);
				if (num6 != 0)
				{
					flag3 = CurrentSegments.Count == 0 || !AnyIntersections(CurrentSegments.Last(), p, split);
				}
			}
			else
			{
				num6 = 0;
			}
			if (((uint)num6 & (flag3 ? 1u : 0u)) != 0)
			{
				if (!AngleTooSteep(split))
				{
					bool flag6 = true;
					if (CurrentSegments.Count > 0)
					{
						WallEdge wallEdge3 = CurrentSegments.Last();
						float x2 = (wallEdge3.Pos.x + split.Pos.x) / 2f;
						float y2 = (wallEdge3.Pos.y + split.Pos.y) / 2f;
						Vector2 ppp2 = new Vector2(x2, y2);
						Room room6 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room room8) => room8.Floor == GameSettings.Instance.ActiveFloor && room8.IsInside(ppp2));
						if (room6 != null && wallEdge3.CouldSplit(room6) && split.CouldSplit(room6) && !wallEdge3.UpAgainst(split) && !split.UpAgainst(wallEdge3))
						{
							isCutting = room6;
							if (CurrentSegments.Count > 1 || TooClose(split.Pos) || AngleTooSteep(split))
							{
								isCutting = null;
								flag6 = false;
							}
						}
					}
					else if (split.GetSplitEdges.Any((WallEdge wallEdge6) => wallEdge6.Pos.Dist(split.Pos).VeryStrictlyBelow(MinWallDistance)))
					{
						ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
						flag6 = false;
					}
					if (flag6)
					{
						CurrentSegments.Add(split);
						if (isCutting != null && CurrentSegments.Count > 1)
						{
							float roomCost2 = GetRoomCost(GetActualSplitEdgesForCost(CurrentSegments, isCutting, null, null, p, Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)), isCutting.Outdoors || isCutting.IsUpperAtrium, false, GameSettings.Instance.ActiveFloor, !isCutting.IsUpperAtriumNotBalcony, false, false);
							if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - roomCost2))
							{
								bool flag7 = false;
								if (isCutting.IsUpperAtriumNotBalcony && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
								{
									CurrentSegments.Reverse();
									flag7 = true;
								}
								if (ValidSplit())
								{
									string debug2 = string.Join("\n", CurrentSegments.Select((WallEdge wallEdge6) => wallEdge6.Pos.x + ";" + wallEdge6.Pos.y).ToArray()) + "\n\n" + string.Join("\n", isCutting.Edges.Select((WallEdge wallEdge6) => wallEdge6.Pos.x + ";" + wallEdge6.Pos.y).ToArray());
									List<UndoObject.UndoAction> list4 = new List<UndoObject.UndoAction>();
									FinalizeCuts(true, GameSettings.Instance.ActiveFloor, list4);
									Dictionary<WallSnap, UndoObject.UndoAction> snaps2 = isCutting.PrepareSplit(true);
									GameSettings.Instance.sRoomManager.AllSegments.AddRange(CurrentSegments);
									Room room7 = isCutting.Split(CurrentSegments, list4, snaps2, debug2);
									if (room7 != null)
									{
										flag2 = true;
										CostDisplay.Instance.FloatAway(roomCost2);
										GameSettings.Instance.MyCompany.MakeTransaction(0f - roomCost2, Company.TransactionCategory.Construction, true, "Room");
										UISoundFX.PlaySFX("PlaceRoom", true);
										UISoundFX.PlaySFX("Kaching");
										ErrorOverlay.Instance.Clear();
										GameSettings.Instance.sRoomManager.AddRoom(room7);
										List<UndoObject.UndoAction> list5 = new List<UndoObject.UndoAction>
										{
											new UndoObject.UndoAction(isCutting, room7, roomCost2)
										};
										foreach (Furniture item3 in from furniture in isCutting.GetFurnitures().ToList()
											orderby furniture.GetSnappingDepth()
											select furniture)
										{
											if (item3.IsAliveNotNull() && !item3.UpdateParent(true, false))
											{
												item3.UndoDestroyWithChildren(list5);
											}
										}
										list5.AddRange(list4);
										GameSettings.Instance.AddUndo(list5.ToArray());
										room7.RecalculateTableGroupsNow();
										isCutting.RecalculateTableGroupsNow();
										isCutting = null;
										if (PlaceMulti())
										{
											ActivateBuildMode(FenceMode);
										}
										else
										{
											ClearBuild();
										}
									}
									else
									{
										isCutting.OptimizeSegments();
										foreach (WallEdge currentSegment2 in CurrentSegments)
										{
											if (!isCutting.Edges.Contains(currentSegment2))
											{
												GameSettings.Instance.sRoomManager.AllSegments.Remove(currentSegment2);
											}
										}
										isCutting = null;
										if (PlaceMulti())
										{
											ActivateBuildMode(FenceMode);
										}
										else
										{
											ClearBuild();
										}
									}
								}
								else
								{
									if (flag7)
									{
										CurrentSegments.Reverse();
									}
									CurrentSegments.Remove(split);
									UISoundFX.PlaySFX("BuildError");
								}
							}
							else
							{
								HUD.FlashMoney();
								CurrentSegments.Remove(split);
								UISoundFX.PlaySFX("BuildError");
							}
						}
						else
						{
							CurrentSegments.Remove(split);
							if (CurrentSegments.Count == 0 || !AnyIntersections(CurrentSegments.Last(), p, split))
							{
								AddSegment(split);
								if (ValidForAutoComplete())
								{
									CheckForAutoComplete();
								}
							}
						}
					}
				}
			}
			else if (isCutting == room3)
			{
				if (CurrentSegments.Count == 0 || !AnyIntersections(CurrentSegments.Last(), p))
				{
					WallEdge wallEdge4 = new WallEdge(p, GameSettings.Instance.ActiveFloor);
					if (!AngleTooSteep(wallEdge4))
					{
						AddSegment(wallEdge4);
					}
				}
			}
			else if (CurrentSegments.Count == 1 && CurrentSegments[0].CouldSplit(room3) && !AnyIntersections(CurrentSegments.Last(), p))
			{
				isCutting = room3;
				if (!TooClose(p))
				{
					WallEdge wallEdge5 = new WallEdge(p, GameSettings.Instance.ActiveFloor);
					if (!AngleTooSteep(wallEdge5))
					{
						AddSegment(wallEdge5);
					}
				}
			}
			else if (room3 != null)
			{
				ErrorOverlay.Instance.ShowError("RoomInRoomError", false, true, 4f);
			}
		}
		goto IL_1b3f;
		IL_1b3f:
		if (CurrentSegments != null && CurrentSegments.Count > count)
		{
			UISoundFX.PlaySFX("PlaceWall", true);
		}
		else if (!flag2 && CurrentSegments != null)
		{
			UISoundFX.PlaySFX("BuildError");
		}
		if (flag2)
		{
			ErrorOverlay.Instance.Clear();
		}
		if (CurrentSegments != null && CurrentSegments.Count == 1)
		{
			_ang1 = null;
			foreach (WallEdge allSegment in GameSettings.Instance.sRoomManager.AllSegments)
			{
				if (allSegment.Floor != GameSettings.Instance.ActiveFloor)
				{
					continue;
				}
				foreach (KeyValuePair<IRoom, WallEdge> link2 in allSegment.Links)
				{
					Vector2 res2;
					if (Utilities.ProjectToLine(CurrentSegments[0].Pos, allSegment.Pos, link2.Value.Pos, out res2) && res2.Dist(CurrentSegments[0].Pos) < _instanceSnap)
					{
						_ang1 = allSegment;
						break;
					}
				}
			}
		}
		else
		{
			_ang1 = null;
		}
		goto IL_1c9b;
	}

	private bool ValidForAutoComplete()
	{
		if (CurrentSegments.Count < 2 || (!CurrentSegments[0].IsSplitter && CurrentSegments[0].Links.Count == 0))
		{
			return false;
		}
		WallEdge wallEdge = CurrentSegments[0];
		WallEdge wallEdge2 = CurrentSegments[CurrentSegments.Count - 1];
		if (CurrentSegments.Count <= 2)
		{
			if (!wallEdge.UpAgainst(wallEdge2))
			{
				return !wallEdge2.UpAgainst(wallEdge);
			}
			return false;
		}
		return true;
	}

	private void ResetAutoComplete()
	{
		AutoCompletePrompt.SetActive(false);
		_autoCompletion = null;
	}

	private void CheckForAutoComplete()
	{
		List<WallEdge>[] array = ConnectEdges();
		if (array == null)
		{
			return;
		}
		List<WallEdge> list = null;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				CleanAutoList(array[i]);
				if (i == 0)
				{
					array[i].Reverse();
				}
				if (CheckAutoSolution(array[i]))
				{
					list = ((list != null) ? null : array[i]);
				}
			}
		}
		if (list == null)
		{
			return;
		}
		List<Vector2> list2 = (from x in CurrentSegments.Concat(list)
			select x.Pos).ToList();
		if (GameSettings.Instance.sRoomManager.IsSupported(list2, GameSettings.Instance.ActiveFloor, null) && !ContainsPath(list2))
		{
			AutoCompletePrompt.SetActive(true);
			AutoCompleteLabel.text = "AutoCompleteRoomPrompt".Loc(GetRoomCost((from x in CurrentSegments.Concat(list)
				select x.Pos).ToArray(), FenceMode, IsPillar(), GameSettings.Instance.ActiveFloor, false, false, false).Currency());
			_autoCompletion = list;
		}
	}

	private void CleanAutoList(List<WallEdge> edges)
	{
		if (edges[0] == CurrentSegments[0] || edges[0] == CurrentSegments[CurrentSegments.Count - 1])
		{
			edges.RemoveAt(0);
		}
		if (edges.Count > 0 && (edges[edges.Count - 1] == CurrentSegments[0] || edges[edges.Count - 1] == CurrentSegments[CurrentSegments.Count - 1]))
		{
			edges.RemoveAt(edges.Count - 1);
		}
	}

	private bool CheckAutoSolution(List<WallEdge> addition)
	{
		int count = CurrentSegments.Count;
		CurrentSegments.AddRange(addition);
		bool flag = !ContainsPoints(false) && !ClampingRoom(false) && !AngleTooSteep(null, true, false) && GameSettings.Instance.PlayerOwnedArea(CurrentSegments.SelectInPlace((WallEdge x) => x.Pos), true);
		if (flag)
		{
			for (int num = 0; num < CurrentSegments.Count; num++)
			{
				Vector2 pos = CurrentSegments[num].Pos;
				Vector2 pos2 = CurrentSegments[(num + 1) % CurrentSegments.Count].Pos;
				Vector2 pos3 = CurrentSegments[(num + 2) % CurrentSegments.Count].Pos;
				if (pos2.AngleBetween(pos, pos3) < MinAngle)
				{
					flag = false;
					break;
				}
			}
		}
		count = CurrentSegments.Count - count;
		for (int num2 = 0; num2 < count; num2++)
		{
			CurrentSegments.RemoveAt(CurrentSegments.Count - 1);
		}
		return flag;
	}

	private List<WallEdge>[] ConnectEdges()
	{
		WallEdge wallEdge = FirstNodeFromStart(CurrentSegments[0]);
		WallEdge wallEdge2 = FirstNodeFromStart(CurrentSegments[CurrentSegments.Count - 1]);
		HashSet<WallEdge> hashSet = new HashSet<WallEdge>();
		for (int i = 1; i < CurrentSegments.Count - 1; i++)
		{
			WallEdge wallEdge3 = CurrentSegments[i];
			hashSet.Add(wallEdge3);
			if (wallEdge3.IsSplitter)
			{
				hashSet.AddRange(wallEdge3.GetSplitEdges);
			}
		}
		if (wallEdge != null && wallEdge2 != null)
		{
			List<WallEdge> list = new List<WallEdge>();
			List<WallEdge>[] array = new List<WallEdge>[2];
			int num = 0;
			WallEdge wallEdge4 = wallEdge;
			HashSet<WallEdge> hashSet2 = new HashSet<WallEdge>();
			bool flag = true;
			while (!hashSet2.Contains(wallEdge4))
			{
				hashSet2.Add(wallEdge4);
				if (hashSet.Contains(wallEdge4))
				{
					if (num == 1)
					{
						break;
					}
					flag = false;
				}
				list.Add(wallEdge4);
				WallEdge wallEdge5 = wallEdge4;
				foreach (KeyValuePair<IRoom, WallEdge> link in wallEdge4.Links)
				{
					if (!link.Value.Links.ContainsValue(wallEdge4))
					{
						wallEdge4 = link.Value;
						break;
					}
				}
				if (wallEdge5 == wallEdge4)
				{
					break;
				}
				if (wallEdge4 == wallEdge)
				{
					if (num == 1)
					{
						array[num] = list;
					}
					break;
				}
				if (wallEdge4 == wallEdge2)
				{
					if (flag)
					{
						array[num] = list;
					}
					flag = true;
					list = new List<WallEdge>();
					num++;
					if (num > 1)
					{
						break;
					}
				}
			}
			return array;
		}
		return null;
	}

	private WallEdge FirstNodeFromStart(WallEdge start)
	{
		if (start.IsSplitter)
		{
			WallEdge[] getSplitEdges = start.GetSplitEdges;
			if (getSplitEdges[0].Links.ContainsValue(getSplitEdges[1]))
			{
				return getSplitEdges[1];
			}
			return getSplitEdges[0];
		}
		return start.Links.Values.FirstOrDefault((WallEdge x) => !x.Links.ContainsValue(start));
	}

	public bool ContainsPoints(bool withError)
	{
		return ContainsPoints(withError, GameSettings.Instance.ActiveFloor);
	}

	public bool ContainsPoints(bool withError, int floor)
	{
		Vector2[] array = CurrentSegments.Select((WallEdge x) => x.Pos).ToArray();
		Rect bounds = ((IList<Vector2>)array).GetBounds();
		for (int num = 0; num < GameSettings.Instance.sRoomManager.Rooms.Count; num++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[num];
			if (!room.RoomBounds.Overlaps(bounds) || room.Floor != floor)
			{
				continue;
			}
			int[] array2 = new Triangulator(room.Edges.Select((WallEdge x) => x.Pos)).Triangulate();
			for (int num2 = 0; num2 < array2.Length; num2 += 3)
			{
				if (Utilities.IsInside(Utilities.GetTriangleCentroid(room.Edges[array2[num2]].Pos, room.Edges[array2[num2 + 1]].Pos, room.Edges[array2[num2 + 2]].Pos), array, -0.001f))
				{
					if (withError)
					{
						ErrorOverlay.Instance.ShowError("RoomInsideError", false, true, 4f);
					}
					return true;
				}
			}
		}
		return false;
	}

	public bool HalfPointCheck(bool withError, int floor)
	{
		Rect bounds = ((IList<Vector2>)CurrentSegments.Select((WallEdge x) => x.Pos).ToArray()).GetBounds();
		for (int num = 0; num < GameSettings.Instance.sRoomManager.Rooms.Count; num++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[num];
			if (!room.RoomBounds.Overlaps(bounds) || room.Floor != floor)
			{
				continue;
			}
			for (int num2 = 0; num2 < CurrentSegments.Count; num2++)
			{
				WallEdge wallEdge = CurrentSegments[num2];
				WallEdge wallEdge2 = CurrentSegments[(num2 + 1) % CurrentSegments.Count];
				Vector2 p = (wallEdge.Pos + wallEdge2.Pos) / 2f;
				if (room.IsInside(p, 0.001f))
				{
					if (withError)
					{
						ErrorOverlay.Instance.ShowError("RoomInsideError", false, true, 4f);
					}
					return true;
				}
			}
		}
		return false;
	}

	public void BeginBuildFurniture(GameObject furnPrefab)
	{
		ClearBuild();
		CurrentFurnitureBuilder = UnityEngine.Object.Instantiate(FurnitureBuilderPrefab).GetComponent<FurnitureBuilder>();
		CurrentFurnitureBuilder.FurnPrefab = furnPrefab;
	}

	private void AlignCode(Vector2 p)
	{
		if (!alignNow)
		{
			return;
		}
		float num = 1f / GetGridSize();
		bool flag = false;
		foreach (RaycastHit item in from x in Physics.RaycastAll(CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition))
			orderby x.distance
			select x)
		{
			Furniture component = item.collider.GetComponent<Furniture>();
			if (component != null && component.Parent.Floor == GameSettings.Instance.ActiveFloor)
			{
				Vector3 vector = component.transform.rotation * (Vector3.one * 0.5f);
				Vector3 vector2 = new Vector3(component.OriginalPosition.x + (component.OnXEdge ? 0f : vector.x), 0f, component.OriginalPosition.z + (component.OnYEdge ? 0f : vector.z));
				GridMatrix = Matrix4x4.TRS(vector2, component.transform.rotation, Vector3.one * num).inverse;
				Graphics.DrawMesh(AlignMesh, Matrix4x4.TRS(vector2 + Vector3.up * ((float)(component.Parent.Floor * 2) + 1.5f), Quaternion.identity, new Vector3(0.2f, 3f, 0.2f)), AlignMaterial, 0);
				UpdateGridVisual();
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			bool flag2 = false;
			int num2 = 0;
			WallEdge wallEdge = null;
			WallEdge wallEdge2 = null;
			foreach (Room item2 in GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && x.IsInsideBounds(p, _instanceSnap)))
			{
				foreach (WallEdge edge in item2.Edges)
				{
					WallEdge wallEdge3 = edge.Links[item2];
					Vector2 res;
					if (Utilities.ProjectToLine(p, edge.Pos, wallEdge3.Pos, out res) && res.Dist(p) < _instanceSnap)
					{
						wallEdge = edge;
						wallEdge2 = wallEdge3;
						float num3 = wallEdge.Pos.Dist(p) / wallEdge2.Pos.Dist(wallEdge.Pos);
						flag2 = false;
						num2 = 0;
						if (num3 > 0.7f)
						{
							wallEdge2 = edge;
							wallEdge = wallEdge3;
						}
						else if (num3 > 0.6f)
						{
							flag2 = true;
							num2 = 1;
						}
						else if (num3 > 0.4f)
						{
							flag2 = true;
						}
						else if (num3 > 0.3f)
						{
							num2 = -1;
							flag2 = true;
						}
						break;
					}
				}
				if (wallEdge != null)
				{
					break;
				}
			}
			if (wallEdge != null)
			{
				Vector3 vector3 = new Vector3(wallEdge.Pos.x, 0f, wallEdge.Pos.y);
				Vector3 vector4 = new Vector3(wallEdge2.Pos.x, 0f, wallEdge2.Pos.y);
				if (flag2)
				{
					vector3 = (vector3 + vector4) * 0.5f + num2 * (vector4 - vector3).normalized * 0.5f;
				}
				GridMatrix = Matrix4x4.TRS(new Vector3(vector3.x, 0f, vector3.z), Quaternion.LookRotation(vector3 - vector4), Vector3.one * num).inverse;
				if (flag2)
				{
					Graphics.DrawMesh(AlignMesh, Matrix4x4.TRS(new Vector3(vector3.x, GameSettings.Instance.ActiveFloor * 2 + 2, vector3.z), Quaternion.identity, new Vector3(0.2f, 4f, 0.2f)), AlignMaterial, 0);
					Graphics.DrawMesh(AlignMesh, Matrix4x4.TRS(new Vector3(wallEdge.Pos.x, (float)(GameSettings.Instance.ActiveFloor * 2) + 1.5f, wallEdge.Pos.y), Quaternion.identity, new Vector3(0.2f, 3f, 0.2f)), AlignMaterial, 0);
				}
				else
				{
					Graphics.DrawMesh(AlignMesh, Matrix4x4.TRS(new Vector3(wallEdge.Pos.x, GameSettings.Instance.ActiveFloor * 2 + 2, wallEdge.Pos.y), Quaternion.identity, new Vector3(0.2f, 4f, 0.2f)), AlignMaterial, 0);
				}
				Graphics.DrawMesh(AlignMesh, Matrix4x4.TRS(new Vector3(wallEdge2.Pos.x, (float)(GameSettings.Instance.ActiveFloor * 2) + 1.5f, wallEdge2.Pos.y), Quaternion.identity, new Vector3(0.2f, 3f, 0.2f)), AlignMaterial, 0);
				UpdateGridVisual();
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			OldMatrix = GridMatrix;
			ClearBuild();
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			ClearBuild();
		}
	}

	public void ClearBuild(bool clone = false, bool road = false, bool plot = false, bool environment = false, bool path = false, bool curveTool = false, bool pillar = false, bool dragTool = false, bool atriumTool = false)
	{
		ErrorOverlay.Instance.Clear();
		HUD.Instance.ShortcutPanel.Hide();
		WindowManager.SetCursorOverride(null);
		CostDisplay.Instance.Hide();
		TempWallList.ForEach(delegate(GameObject x)
		{
			UnityEngine.Object.Destroy(x);
		});
		TempWallList.Clear();
		RectDragging = false;
		RectPoints = null;
		CurrentTempWall = null;
		CurrentSegments = null;
		isCutting = null;
		UnityEngine.Object.Destroy(CurrentTempSegment);
		CurrentTempSegment = null;
		DynSegmentE1 = null;
		DynSegmentE2 = null;
		mergeNow = false;
		alignNow = false;
		_shiftGrid = false;
		_ang1 = null;
		Arrow.SetActive(false);
		ResetAutoComplete();
		if (CurrentFurnitureBuilder != null)
		{
			UnityEngine.Object.Destroy(CurrentFurnitureBuilder.gameObject);
		}
		GridMatrix = OldMatrix;
		UpdateGridVisual();
		BuildingHUD.Instance.Enable(false, false, false);
		if (HUD.Instance.roofEditWindow.Window.HasBeenShown)
		{
			HUD.Instance.roofEditWindow.Window.Close();
		}
		if (!clone)
		{
			RoomCloneTool.Instance.gameObject.SetActive(false);
		}
		if (!road)
		{
			RoadBuildCube.Instance.gameObject.SetActive(false);
		}
		if (!plot && PlotController.Instance != null)
		{
			PlotController.Instance.gameObject.SetActive(false);
		}
		if (!environment && EnvironmentEditor.Instance != null)
		{
			EnvironmentEditor.Instance.gameObject.SetActive(false);
		}
		if (PathBuilder.Instance != null && !path)
		{
			PathBuilder.Instance.enabled = false;
		}
		if (WallRemovalTool.Instance != null)
		{
			WallRemovalTool.Instance.gameObject.SetActive(false);
		}
		if (CurveBuilder.Instance != null && !curveTool)
		{
			CurveBuilder.Instance.gameObject.SetActive(false);
		}
		if (PillarToggler.Instance != null && !pillar)
		{
			PillarToggler.Instance.gameObject.SetActive(false);
		}
		if (WallDragTool.Instance != null && !dragTool)
		{
			WallDragTool.Instance.gameObject.SetActive(false);
		}
		if (AtriumTool.Instance != null && !atriumTool)
		{
			AtriumTool.Instance.gameObject.SetActive(false);
		}
		HUD.Instance.UpdateBorderOverlay();
	}

	public void BeginSegmentBuild(GameObject segmentPrefab)
	{
		WallSegmentPrefab = segmentPrefab;
		RoomSegment component = WallSegmentPrefab.GetComponent<RoomSegment>();
		ClearBuild();
		CurrentTempSegment = UnityEngine.Object.Instantiate(TempWallSegmentPrefab);
		CurrentTempSegment.transform.localScale = new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth);
		MaterialPreviewer.Instance.RefreshState();
		if (Options.ShiftToPlace)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceMultiple".Loc(), KeyCode.LeftShift, true);
		}
		else
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceSingle".Loc(), KeyCode.LeftShift, true);
			HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
		}
		if (component.DynamicWidth && component.MaxDynamicWidth <= 0f)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("Stretch".Loc(), KeyCode.Mouse0, true);
			HUD.Instance.ShortcutPanel.AddShortcut("AutoScale".Loc(), KeyCode.LeftControl, true);
		}
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.DisableGrid);
		HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.ShiftGrid);
	}

	private void CheckLastTick()
	{
		Vector2 vector = CurrentTempSegment.transform.position.FlattenVector3();
		if (LastPos != vector && !NoGrid())
		{
			UISoundFX.PlaySFX("Tick", true);
		}
		LastPos = vector;
	}

	public static bool NoGrid()
	{
		return InputController.GetKey(InputController.Keys.DisableGrid);
	}

	private void SegmentBuildCode()
	{
		if (!(CurrentTempSegment != null))
		{
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			ClearBuild();
			return;
		}
		RoomSegment component = WallSegmentPrefab.GetComponent<RoomSegment>();
		Arrow.SetActive(component.Directional);
		CostDisplay.Instance.Show(component.Cost, CurrentTempSegment.transform.position, GameSettings.Instance.MyCompany.CanMakeTransaction(0f - component.Cost) ? Color.white : Color.red);
		Vector2 pos = GetMousePos(new Plane(Vector3.up, Vector3.up * ((float)(GameSettings.Instance.ActiveFloor * 2) + component.YOffset)));
		IEnumerable<Room> enumerable = ((component.DynamicWidth && DynSegmentE1 != null) ? null : GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && x.IsInsideBounds(pos, _instanceSnap)));
		float num = 1f;
		if ((!component.DynamicWidth || DynSegmentE1 == null) && !enumerable.Any())
		{
			Arrow.SetActive(false);
			SetSegmentPos(new Vector3(pos.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
			return;
		}
		if (component.DynamicWidth && DynSegmentE1 != null)
		{
			float pos2 = DynSegmentPos;
			float num2 = component.WallWidth;
			Vector2 p = Utilities.ProjectToLineEndless(NoGrid() ? pos : CorrectMousePos(pos, _shiftGrid), DynSegmentE1.Pos, DynSegmentE2.Pos);
			float num3 = DynSegmentE1.Pos.Dist(DynSegmentE2.Pos);
			float num4 = DynSegmentE1.Pos.Dist(p);
			float num5 = DynSegmentE2.Pos.Dist(p);
			float num8;
			if (num4 / num3 > DynSegmentPos && (num5 < num3 || num4 > num5))
			{
				float num6 = DynSegmentPos * num3 - component.WallWidth / 2f;
				num4 = Mathf.Clamp(num4, num6 + component.WallWidth, num3);
				if (component.MaxDynamicWidth > 0f)
				{
					if (num4 - num6 > component.MaxDynamicWidth)
					{
						num4 = num6 + component.MaxDynamicWidth;
					}
				}
				else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
				{
					float? num7 = DynSegmentE1.FirstValidFrom(num6, DynSegmentE2);
					num4 = ((!num7.HasValue) ? num3 : num7.Value);
					num7 = DynSegmentE2.FirstValidFrom(num3 - num6, DynSegmentE1);
					num6 = ((!num7.HasValue) ? 0f : (num3 - num7.Value));
				}
				Vector2 vector = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num6;
				Vector2 vector2 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num4;
				Vector2 pos3 = (vector + vector2) * 0.5f;
				float magnitude = (vector - vector2).magnitude;
				Vector2 vector3 = pos3;
				float height = 0f;
				if (DynSegmentE1.ValidSegment(ref pos3, ref height, magnitude, DynSegmentE2, false, component.IsConnecter, false, false, !component.InsideSegment, component.Height1, component.Height2, true) && pos3 == vector3)
				{
					num8 = Mathf.Abs(num6 - num4) / component.WallWidth;
					SetSegmentPos(new Vector3(pos3.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos3.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, magnitude));
					CheckLastTick();
					pos2 = (num6 + num4) / 2f;
					pos2 /= num3;
					num2 = magnitude;
				}
				else
				{
					float? num9 = DynSegmentE1.FirstValidFrom(num6, DynSegmentE2);
					if (num9.HasValue)
					{
						num4 = num9.Value;
						Vector2 vector4 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num6;
						vector2 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num4;
						pos3 = (vector4 + vector2) * 0.5f;
						magnitude = (vector4 - vector2).magnitude;
						num8 = Mathf.Abs(num6 - num4) / component.WallWidth;
						SetSegmentPos(new Vector3(pos3.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos3.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, magnitude));
						CheckLastTick();
						pos2 = (num6 + num4) / 2f;
						pos2 /= num3;
						num2 = magnitude;
					}
					else
					{
						num8 = 1f;
						SetSegmentPos(new Vector3(DynSegmentVec.x, GameSettings.Instance.ActiveFloor * 2 + 1, DynSegmentVec.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
						CheckLastTick();
					}
				}
			}
			else
			{
				if (num5 > num3)
				{
					num4 = 0f;
				}
				float num10 = DynSegmentPos * num3 + component.WallWidth / 2f;
				num4 = Mathf.Clamp(num4, 0f, num10 - component.WallWidth);
				if (component.MaxDynamicWidth > 0f)
				{
					if (num10 - num4 > component.MaxDynamicWidth)
					{
						num4 = num10 - component.MaxDynamicWidth;
					}
				}
				else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
				{
					float? num11 = DynSegmentE1.FirstValidFrom(num10, DynSegmentE2);
					num4 = ((!num11.HasValue) ? num3 : num11.Value);
					num11 = DynSegmentE2.FirstValidFrom(num3 - num10, DynSegmentE1);
					num10 = ((!num11.HasValue) ? 0f : (num3 - num11.Value));
				}
				Vector2 vector5 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num10;
				Vector2 vector6 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num4;
				Vector2 pos4 = (vector5 + vector6) * 0.5f;
				float magnitude2 = (vector5 - vector6).magnitude;
				Vector2 vector7 = pos4;
				float height2 = 0f;
				if (DynSegmentE1.ValidSegment(ref pos4, ref height2, magnitude2, DynSegmentE2, false, component.IsConnecter, false, false, !component.InsideSegment, component.Height1, component.Height2, true) && pos4 == vector7)
				{
					num8 = Mathf.Abs(num10 - num4) / component.WallWidth;
					SetSegmentPos(new Vector3(pos4.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos4.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, magnitude2));
					CheckLastTick();
					pos2 = (num10 + num4) / 2f;
					pos2 /= num3;
					num2 = magnitude2;
				}
				else
				{
					float? num12 = DynSegmentE2.FirstValidFrom(num3 - num10, DynSegmentE1);
					if (num12.HasValue)
					{
						num4 = num3 - num12.Value;
						Vector2 vector8 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num10;
						vector6 = DynSegmentE1.Pos + (DynSegmentE2.Pos - DynSegmentE1.Pos).normalized * num4;
						pos4 = (vector8 + vector6) * 0.5f;
						magnitude2 = (vector8 - vector6).magnitude;
						num8 = Mathf.Abs(num10 - num4) / component.WallWidth;
						SetSegmentPos(new Vector3(pos4.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos4.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, magnitude2));
						CheckLastTick();
						pos2 = (num10 + num4) / 2f;
						pos2 /= num3;
						num2 = magnitude2;
					}
					else
					{
						num8 = 1f;
						SetSegmentPos(new Vector3(DynSegmentVec.x, GameSettings.Instance.ActiveFloor * 2 + 1, DynSegmentVec.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
						CheckLastTick();
					}
				}
			}
			CostDisplay.Instance.Show(component.Cost * num8, CurrentTempSegment.transform.position, GameSettings.Instance.MyCompany.CanMakeTransaction((0f - component.Cost) * num8) ? Color.white : Color.red);
			if (!Input.GetMouseButtonUp(0))
			{
				return;
			}
			if (!GameSettings.Instance.MyCompany.CanMakeTransaction((0f - component.Cost) * num8))
			{
				UISoundFX.PlaySFX("BuildError");
				HUD.FlashMoney();
			}
			else if (CheckForcedSegment(DynSegmentE1.Pos, DynSegmentE2.Pos, pos2, num2))
			{
				CostDisplay.Instance.FloatAway();
				UISoundFX.PlaySFX("PlaceFurniture", true);
				UISoundFX.PlaySFX("Kaching");
				ErrorOverlay.Instance.Clear();
				GameSettings.Instance.MyCompany.MakeTransaction((0f - component.Cost) * num8, Company.TransactionCategory.Construction, true, "Segment");
				GameObject gameObject = UnityEngine.Object.Instantiate(WallSegmentPrefab);
				RoomSegment component2 = gameObject.GetComponent<RoomSegment>();
				component2.FixDynamicWidth(num2);
				component2.Floor = GameSettings.Instance.ActiveFloor;
				component2.transform.position = new Vector3(0f, GameSettings.Instance.ActiveFloor * 2, 0f);
				component2.Init(DynSegmentE1, DynSegmentE2, pos2);
				DynSegmentE1 = null;
				DynSegmentE2 = null;
				SetSegmentScale(new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
				component2.name = component2.name.Replace("(Clone)", "").Trim();
				GameSettings.Instance.AddUndo(new UndoObject.UndoAction(component2, true));
				gameObject.SetActive(true);
				if (!PlaceMulti())
				{
					ClearBuild();
				}
			}
			else
			{
				DynSegmentE1 = null;
				DynSegmentE2 = null;
				SetSegmentScale(new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
			}
			return;
		}
		Vector2 p2 = (NoGrid() ? pos : CorrectMousePos(pos, _shiftGrid ^ (Mathf.RoundToInt(component.WallWidth) % 2 == 1)));
		float num13 = component.WallWidth / 2f;
		WallEdge wallEdge = null;
		WallEdge wallEdge2 = null;
		foreach (Room item in enumerable)
		{
			foreach (WallEdge edge in item.Edges)
			{
				WallEdge current2;
				WallEdge wallEdge3 = (current2 = edge).Links[item];
				Vector2 res;
				if (current2.Pos.Dist(wallEdge3.Pos) < num13 * 2f || (component.OnlyInterior && (item.Outdoors || !wallEdge3.Links.ContainsValue(current2) || wallEdge3.GetRoom(current2).Outdoors)) || !Utilities.ProjectToLine(pos, current2.Pos, wallEdge3.Pos, out res, 0.001f))
				{
					continue;
				}
				float num14 = res.Dist(pos);
				if (!(num14 < num))
				{
					continue;
				}
				Vector2 res2;
				if (!Utilities.ProjectToLine(p2, current2.Pos, wallEdge3.Pos, out res2, 0.001f))
				{
					res2 = res;
				}
				if (res2.Dist(current2.Pos) < num13)
				{
					res2 = current2.Pos + (wallEdge3.Pos - current2.Pos).normalized * num13;
				}
				if (res2.Dist(wallEdge3.Pos) < num13)
				{
					res2 = wallEdge3.Pos + (current2.Pos - wallEdge3.Pos).normalized * num13;
				}
				Vector2 pos5 = res2;
				float height3 = 0f;
				if (!current2.ValidSegment(ref pos5, ref height3, component.WallWidth, wallEdge3, false, component.IsConnecter, false, false, !component.InsideSegment, component.Height1, component.Height2, true, res.x - pos5.x, res.y - pos5.y))
				{
					continue;
				}
				num = num14;
				if (component.DynamicWidth && component.MaxDynamicWidth <= 0f && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
				{
					float num15 = current2.Pos.Dist(wallEdge3.Pos);
					float num16 = current2.Pos.Dist(pos5);
					float num17 = num15;
					float? num18 = current2.FirstValidFrom(num16, wallEdge3);
					if (num18.HasValue)
					{
						num17 = num18.Value;
					}
					num18 = wallEdge3.FirstValidFrom(num15 - num16, current2);
					num16 = ((!num18.HasValue) ? 0f : (num15 - num18.Value));
					float num19 = Mathf.Abs(num17 - num16);
					float num20 = component.Cost * (num19 / component.WallWidth);
					CostDisplay.Instance.Show(num20, CurrentTempSegment.transform.position, GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num20) ? Color.white : Color.red);
					pos5 = current2.Pos + (wallEdge3.Pos - current2.Pos) * ((num17 + num16) * 0.5f / num15);
					SetSegmentScale(new Vector3(Room.WallOffset + 0.1f, 2.1f, num19));
				}
				else
				{
					SetSegmentScale(new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
				}
				SetSegmentPos(new Vector3(pos5.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos5.y));
				if (component.Directional && Utilities.IsLeft(current2.Pos, wallEdge3.Pos, pos) > 0)
				{
					wallEdge = wallEdge3;
					wallEdge2 = current2;
				}
				else
				{
					wallEdge = current2;
					wallEdge2 = wallEdge3;
				}
				Vector2 vector9 = wallEdge.Pos - wallEdge2.Pos;
				SetSegmentRotation(Quaternion.LookRotation(new Vector3(vector9.x, 0f, vector9.y)));
			}
		}
		if (wallEdge != null)
		{
			CheckLastTick();
		}
		if (wallEdge == null)
		{
			Arrow.SetActive(false);
			SetSegmentPos(new Vector3(pos.x, GameSettings.Instance.ActiveFloor * 2 + 1, pos.y), new Vector3(Room.WallOffset + 0.1f, 2.1f, component.WallWidth));
		}
		else
		{
			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			if (component.DynamicWidth)
			{
				if (DynSegmentE1 == null)
				{
					Vector3 position = CurrentTempSegment.transform.position;
					DynSegmentVec = new Vector2(position.x, position.z);
					DynSegmentE1 = wallEdge;
					DynSegmentE2 = wallEdge2;
					DynSegmentPos = DynSegmentE1.Pos.Dist(DynSegmentVec) / DynSegmentE1.Pos.Dist(DynSegmentE2.Pos);
				}
				return;
			}
			if (!GameSettings.Instance.MyCompany.CanMakeTransaction(0f - component.Cost))
			{
				HUD.FlashMoney();
				UISoundFX.PlaySFX("BuildError");
				return;
			}
			Vector3 position2 = CurrentTempSegment.transform.position;
			Vector2 p3 = new Vector2(position2.x, position2.z);
			WallEdge wallEdge4 = wallEdge;
			WallEdge wallEdge5 = wallEdge2;
			float pos6 = wallEdge4.Pos.Dist(p3) / wallEdge4.Pos.Dist(wallEdge5.Pos);
			if (CheckForcedSegment(wallEdge4.Pos, wallEdge5.Pos, pos6, component.WallWidth))
			{
				CostDisplay.Instance.FloatAway();
				UISoundFX.PlaySFX("PlaceFurniture", true);
				UISoundFX.PlaySFX("Kaching");
				ErrorOverlay.Instance.Clear();
				GameSettings.Instance.MyCompany.MakeTransaction(0f - component.Cost, Company.TransactionCategory.Construction, true, "Segment");
				GameObject obj = UnityEngine.Object.Instantiate(WallSegmentPrefab);
				RoomSegment component3 = obj.GetComponent<RoomSegment>();
				component3.Floor = GameSettings.Instance.ActiveFloor;
				component3.transform.position = new Vector3(0f, GameSettings.Instance.ActiveFloor * 2, 0f);
				component3.Init(wallEdge4, wallEdge5, pos6);
				component3.name = component3.name.Replace("(Clone)", "").Trim();
				obj.SetActive(true);
				GameSettings.Instance.AddUndo(new UndoObject.UndoAction(component3, true));
				if (!PlaceMulti())
				{
					ClearBuild();
				}
			}
		}
	}

	private bool CheckForcedSegment(Vector2 a, Vector2 b, float pos, float width)
	{
		if (ActivePrefab != null)
		{
			Vector2 position = a + (b - a) * pos;
			float y = Quaternion.LookRotation((b - a).ToVector3(0f)).eulerAngles.y;
			if (ActivePrefab.CheckSegment(WallSegmentPrefab.name, GameSettings.Instance.ActiveFloor, position, width, y))
			{
				return true;
			}
			ErrorOverlay.Instance.ShowError("ForcedPrefabError", false, true, 4f);
			UISoundFX.PlaySFX("BuildError");
			return false;
		}
		return true;
	}

	private void SetSegmentScale(Vector3 scale)
	{
		SetSegmentPos(CurrentTempSegment.transform.position, scale);
	}

	private void SetSegmentPos(Vector3 pos)
	{
		SetSegmentPos(pos, CurrentTempSegment.transform.localScale);
	}

	private void SetSegmentPos(Vector3 pos, Vector3 scale)
	{
		CurrentTempSegment.transform.localScale = scale;
		CurrentTempSegment.transform.position = pos;
		Arrow.transform.position = pos + Vector3.up * 2f;
	}

	private void SetSegmentRotation(Quaternion rotation)
	{
		CurrentTempSegment.transform.rotation = rotation;
		Arrow.transform.rotation = Quaternion.Euler(0f, 90f, 0f) * rotation;
	}

	public bool ProjectToWalls(int floor, bool withErrors)
	{
		_projectCache.Clear();
		_projectCache.AddRange(CurrentSegments);
		for (int i = 0; i < CurrentSegments.Count; i++)
		{
			WallEdge wallEdge = CurrentSegments[i];
			WallEdge wallEdge2 = CurrentSegments[(i + 1) % CurrentSegments.Count];
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(floor))
			{
				Vector2 res;
				if (!_projectCache.Contains(item) && Utilities.ProjectToLine(item.Pos, wallEdge.Pos, wallEdge2.Pos, out res) && item.Pos.Dist(res) < _instanceSnap)
				{
					if (item.Pos.Dist(wallEdge.Pos) < _instanceSnap || item.Pos.Dist(wallEdge.Pos) < _instanceSnap)
					{
						if (withErrors)
						{
							ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
						}
						_projectCache.Clear();
						return false;
					}
					CurrentSegments.Insert(i + 1, item);
					_projectCache.Add(item);
					i--;
					break;
				}
			}
		}
		_projectCache.Clear();
		return true;
	}

	public bool ValidSplit(bool withErrors = true, Room ignore = null)
	{
		if (isCutting == null || isCutting.Burn > 0f || CurrentSegments.Count < 2 || (!CurrentSegments[0].Links.ContainsKey(isCutting) && !CurrentSegments[0].GetSplitRooms.Contains(isCutting)))
		{
			if (withErrors && isCutting != null && isCutting.Burn > 0f)
			{
				ErrorOverlay.Instance.ShowError("BurntRoomError", false, true, 4f);
			}
			return false;
		}
		foreach (WallEdge edge in isCutting.Edges)
		{
			for (int i = 0; i < CurrentSegments.Count - 1; i++)
			{
				WallEdge wallEdge = CurrentSegments[i];
				WallEdge wallEdge2 = CurrentSegments[i + 1];
				if (wallEdge.UpAgainst(wallEdge2) || wallEdge2.UpAgainst(wallEdge))
				{
					return false;
				}
				Vector2 res;
				if (edge != wallEdge && edge != wallEdge2 && Utilities.ProjectToLine(edge.Pos, wallEdge.Pos, wallEdge2.Pos, out res) && edge.Pos.Dist(res).VeryStrictlyBelow(MinWallDistance))
				{
					if (withErrors)
					{
						ErrorOverlay.Instance.ShowError("RoomNarrowError", false, true, 4f);
					}
					return false;
				}
			}
		}
		if (isCutting.AtriumParent == isCutting)
		{
			for (int j = 0; j < isCutting.AtriumChildren.Count; j++)
			{
				Room room = isCutting.AtriumChildren[j];
				for (int k = 0; k < room.AtriumChildren.Count; k++)
				{
					Room room2 = room.AtriumChildren[k];
					for (int l = 0; l < CurrentSegments.Count; l++)
					{
						if (room2.IsInside(CurrentSegments[l].Pos))
						{
							if (withErrors)
							{
								ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
							}
							return false;
						}
					}
					for (int m = 0; m < room2.Edges.Count; m++)
					{
						WallEdge wallEdge3 = room2.Edges[m];
						WallEdge wallEdge4 = room2.Edges[(m + 1) % room2.Edges.Count];
						WallEdge wallEdge5 = CurrentSegments[0];
						Vector2 res2;
						if (Utilities.ProjectToLine(wallEdge5.Pos, wallEdge3.Pos, wallEdge4.Pos, out res2) && (res2 - wallEdge5.Pos).sqrMagnitude < 0.0001f)
						{
							if (withErrors)
							{
								ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
							}
							return false;
						}
						wallEdge5 = CurrentSegments.Last();
						if (Utilities.ProjectToLine(wallEdge5.Pos, wallEdge3.Pos, wallEdge4.Pos, out res2) && (res2 - wallEdge5.Pos).sqrMagnitude < 0.0001f)
						{
							if (withErrors)
							{
								ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
							}
							return false;
						}
						for (int n = 0; n < CurrentSegments.Count - 1; n++)
						{
							WallEdge wallEdge6 = CurrentSegments[n];
							WallEdge wallEdge7 = CurrentSegments[n + 1];
							if (Utilities.LinesIntersect(wallEdge3.Pos, wallEdge4.Pos, wallEdge6.Pos, wallEdge7.Pos, false, true))
							{
								if (withErrors)
								{
									ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
								}
								return false;
							}
						}
					}
				}
			}
		}
		if (!CurrentSegments[0].CuttingSameWall(CurrentSegments.Last()))
		{
			if (isCutting != ignore && isCutting.IsBalcony && !SplitBalcQuickCheck(CurrentSegments[0]) && !SplitBalcQuickCheck(CurrentSegments.Last()))
			{
				WallEdge wallEdge8 = (CurrentSegments[0].IsSplitter ? CurrentSegments[0].GetSplitEdges[0] : CurrentSegments[0]);
				WallEdge wallEdge9 = CurrentSegments.Last();
				WallEdge wallEdge10 = (wallEdge9.IsSplitter ? wallEdge9.GetSplitEdges[0] : wallEdge9);
				if (!IsTouching(wallEdge8, wallEdge10, isCutting, isCutting.AtriumParent, ignore) || !IsTouching(wallEdge10, wallEdge8, isCutting, isCutting.AtriumParent, ignore))
				{
					if (withErrors)
					{
						ErrorOverlay.Instance.ShowError("EncloseBalconyError", false, true, 4f);
					}
					return false;
				}
			}
			if (isCutting.IsUpperAtriumNotBalcony)
			{
				HashSet<Room> hashSet = new HashSet<Room>();
				if (CurrentSegments[0].IsSplitter)
				{
					Room oppositeSplitRoom = CurrentSegments[0].GetOppositeSplitRoom(isCutting);
					if (oppositeSplitRoom != null)
					{
						hashSet.Add(oppositeSplitRoom);
					}
				}
				WallEdge wallEdge11 = (CurrentSegments[0].IsSplitter ? CurrentSegments[0].GetOppositeSplitEdge(isCutting) : CurrentSegments[0]);
				WallEdge wallEdge12 = CurrentSegments.Last();
				if (wallEdge12.IsSplitter)
				{
					Room oppositeSplitRoom2 = wallEdge12.GetOppositeSplitRoom(isCutting);
					if (oppositeSplitRoom2 != null)
					{
						hashSet.Add(oppositeSplitRoom2);
					}
				}
				WallEdge wallEdge13 = (wallEdge12.IsSplitter ? wallEdge12.GetSplitEdgeFor(isCutting) : wallEdge12);
				int num = isCutting.Edges.Count * 2;
				int num2 = 0;
				AddBalcValid(wallEdge13, wallEdge11, hashSet);
				while (wallEdge11 != wallEdge13 && num2 < num)
				{
					WallEdge wallEdge14 = wallEdge11.Links[isCutting];
					Room room3 = wallEdge14.GetRoom(wallEdge11);
					if (room3 != null && room3 != ignore && room3.AtriumParent == isCutting && !hashSet.Contains(room3))
					{
						if (withErrors)
						{
							ErrorOverlay.Instance.ShowError("EncloseBalconyError", false, true, 4f);
						}
						return false;
					}
					wallEdge11 = wallEdge14;
					num2++;
				}
			}
		}
		return true;
	}

	private void AddBalcValid(WallEdge start, WallEdge end, HashSet<Room> valids)
	{
		int num = isCutting.Edges.Count * 2;
		int num2 = 0;
		while (start != end && num2 < num)
		{
			WallEdge wallEdge = start.Links[isCutting];
			Room room = wallEdge.GetRoom(start);
			if (room != null && room.AtriumParent == isCutting)
			{
				valids.Add(room);
			}
			start = wallEdge;
			num2++;
		}
	}

	private bool SplitBalcQuickCheck(WallEdge a)
	{
		if (a.IsSplitter)
		{
			if (!(a.GetSplitRooms[0] == isCutting.AtriumParent))
			{
				return a.GetSplitRooms[1] == isCutting.AtriumParent;
			}
			return true;
		}
		return false;
	}

	public bool IsTouching(WallEdge a, WallEdge stop, Room from, Room touch, Room ignore)
	{
		if (from == null || a == null || from == touch)
		{
			return true;
		}
		int num = from.Edges.Count * 2;
		int num2 = 0;
		bool flag = ignore != null;
		while (a != stop && num2 < num)
		{
			WallEdge wallEdge = a.Links[from];
			Room room = wallEdge.GetRoom(a);
			if (room == touch || (flag && room == ignore))
			{
				return true;
			}
			a = wallEdge;
			num2++;
		}
		return false;
	}

	public void FinalizeCuts(bool splitting, int floor, List<UndoObject.UndoAction> undos, bool preciseEdgeOptimization = false)
	{
		HashSet<WallEdge> hashSet = CurrentSegments.ToHashSet();
		for (int i = 0; i < CurrentSegments.Count && (!splitting || i != CurrentSegments.Count - 1); i++)
		{
			WallEdge wallEdge = CurrentSegments[i];
			WallEdge wallEdge2 = CurrentSegments[(i + 1) % CurrentSegments.Count];
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(floor))
			{
				Vector2 res;
				if (item != wallEdge && item != wallEdge2 && !hashSet.Contains(item) && Utilities.ProjectToLine(item.Pos, wallEdge.Pos, wallEdge2.Pos, out res) && item.Pos.Dist(res) < GetSnapDistance(preciseEdgeOptimization))
				{
					CurrentSegments.Insert(i + 1, item);
					hashSet.Add(item);
					i--;
					break;
				}
			}
		}
		foreach (WallEdge currentSegment in CurrentSegments)
		{
			if (!currentSegment.IsSplitter)
			{
				continue;
			}
			float num = float.MaxValue;
			WallEdge wallEdge3 = null;
			Room room = currentSegment.GetSplitRooms[0];
			foreach (WallEdge edge in room.Edges)
			{
				WallEdge wallEdge4 = edge.Links[room];
				Vector2 res2;
				if (Utilities.ProjectToLine(currentSegment.Pos, edge.Pos, wallEdge4.Pos, out res2))
				{
					float num2 = res2.Dist(currentSegment.Pos);
					if (num2 < _instanceSnap && num2 < num)
					{
						num = num2;
						wallEdge3 = edge;
					}
				}
			}
			if (wallEdge3 != null)
			{
				currentSegment.SetSplit(wallEdge3, room);
				currentSegment.SplitSegment(undos);
				GameSettings.Instance.sRoomManager.AllSegments.Add(currentSegment);
			}
			else
			{
				currentSegment.ResetSplit();
			}
		}
	}

	public void RoomFromClipboard()
	{
	}

	public void MakeRoomFromString(string text)
	{
		string[] array = text.SplitByNewLines();
		string[] array2 = array[0].Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		List<WallEdge> list = new List<WallEdge>();
		for (int i = 0; i < array2.Length; i += 2)
		{
			float x = (float)Convert.ToDouble(array2[i]);
			float y = (float)Convert.ToDouble(array2[i + 1]);
			list.Add(new WallEdge(new Vector2(x, y), GameSettings.Instance.ActiveFloor));
		}
		Room room = MakeRoom(list, GameSettings.Instance.ActiveFloor, null, true, false, false);
		GameSettings.Instance.sRoomManager.AllSegments.AddRange(room.Edges);
		List<Furniture> list2 = new List<Furniture>();
		for (int j = 1; j < array.Length; j++)
		{
			string[] array3 = array[j].Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			GameObject furniture = ObjectDatabase.Instance.GetFurniture(array3[0]);
			if (furniture != null)
			{
				Vector3 pos = new Vector3((float)Convert.ToDouble(array3[1]), 0f, (float)Convert.ToDouble(array3[2]));
				Quaternion rot = Quaternion.Euler(0f, (float)Convert.ToDouble(array3[3]), 0f);
				WallEdge wallEdge = null;
				WallEdge wallEdge2 = null;
				float wallPos = 0f;
				SnapPoint snapPoint = null;
				bool flag = true;
				if (furniture.GetComponent<Furniture>().WallFurn)
				{
					wallEdge = list[Convert.ToInt32(array3[4])];
					wallEdge2 = list[Convert.ToInt32(array3[5])];
					wallPos = (float)Convert.ToDouble(array3[6]) / (wallEdge.Pos - wallEdge2.Pos).magnitude;
				}
				if (furniture.GetComponent<Furniture>().IsSnapping)
				{
					Furniture furniture2 = list2[Convert.ToInt32(array3[7])];
					if (furniture2 == null)
					{
						flag = false;
					}
					else
					{
						snapPoint = furniture2.SnapPoints[Convert.ToInt32(array3[8])];
						pos = snapPoint.transform.position;
					}
				}
				if (flag)
				{
					bool inventory;
					Furniture item = FurnitureBuilder.MakeFurn(pos, rot, room, wallEdge, wallEdge2, wallPos, false, snapPoint, furniture, 0f, false, out inventory, true);
					list2.Add(item);
				}
				else
				{
					list2.Add(null);
				}
			}
			else
			{
				Debug.Log("Missing furniture: " + array3[0]);
				list2.Add(null);
			}
		}
	}
}
