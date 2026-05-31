using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Pooling;
using NaughtyAttributes;
using UnityEngine;

public class ConstructionCell : MonoBehaviour
{
	public enum ECellState
	{
		Default = 0,
		ToBuild = 1,
		ToDestroy = 2,
		Invalide = 3
	}

	public enum EInteriorState
	{
		None = 0,
		MarkAsInterior = 1,
		IsInterior = 2
	}

	[SerializeField]
	[ColorUsage(true)]
	private Color _defaultColor;

	[SerializeField]
	[ColorUsage(true)]
	private Color _selectedColor;

	[SerializeField]
	[ColorUsage(true)]
	private Color _invalidColor;

	[SerializeField]
	[ColorUsage(true)]
	private Color _destructedColor = new Color(1f, 1f, 0f, 1f);

	[SerializeField]
	private AnimationCurve _spawnScaleAnimationCurve;

	[HideInInspector]
	public CellMaterials CellMaterials;

	public ERotationAngle BuildableRotation;

	private Material _currentMat;

	private Coroutine _showCellCoroutine;

	private static readonly Color _transColor = new Color(1f, 1f, 1f, 0f);

	private static readonly Color _opaqueColor = Color.white;

	private Renderer _additiveRenderer;

	private Material _material;

	private int _private_sectorID;

	private int? _private_tempSectorID;

	private ECellState _private_currentState;

	private bool _nordBuyed;

	private bool _eastBuyed;

	private bool _southBuyed;

	private bool _westBuyed;

	private bool _isEnd;

	private static readonly int SHColor = Shader.PropertyToID("_Color");

	private RoomBuilding _linkedRoom;

	public EInteriorState InteriorState;

	public bool setCellUnoveriadable;

	private bool _overridableCell = true;

	public bool NeedToHaveSameID;

	public int HasGroupCell = -1;

	public BuildableElement BuildableElement { get; set; }

	[field: SerializeField]
	public Vector2Int Coordinate { get; set; }

	public BuyingData CellBuildCost
	{
		get
		{
			BuyingData result = new BuyingData
			{
				FloorsToBuild = (((CurrentState == ECellState.ToBuild || CurrentState == ECellState.Invalide) && BuildedSectorID != TempSectorID) ? 1 : 0),
				FloorsToDestroy = 0,
				WallsToBuild = 0,
				WallsToDestroy = 0
			};
			result.WallsToBuild += ((NordWall != null && !_nordBuyed) ? 1 : 0);
			result.WallsToBuild += ((EastWall != null && !_eastBuyed) ? 1 : 0);
			result.WallsToBuild += ((SouthWall != null && !_southBuyed) ? 1 : 0);
			result.WallsToBuild += ((WestWall != null && !_westBuyed) ? 1 : 0);
			return result;
		}
	}

	public BuyingData CellDestroyCost
	{
		get
		{
			BuyingData result = new BuyingData
			{
				FloorsToBuild = 0,
				FloorsToDestroy = (((CurrentState == ECellState.ToDestroy || CurrentState == ECellState.Invalide) && BuildedSectorID != TempSectorID) ? 1 : 0),
				WallsToBuild = 0,
				WallsToDestroy = 0
			};
			result.WallsToDestroy += (_nordBuyed ? 1 : 0);
			result.WallsToBuild += ((NordWall != null && !_nordBuyed) ? 1 : 0);
			result.WallsToDestroy += (_eastBuyed ? 1 : 0);
			result.WallsToBuild += ((EastWall != null && !_eastBuyed) ? 1 : 0);
			result.WallsToDestroy += (_southBuyed ? 1 : 0);
			result.WallsToBuild += ((SouthWall != null && !_southBuyed) ? 1 : 0);
			result.WallsToDestroy += (_westBuyed ? 1 : 0);
			result.WallsToBuild += ((WestWall != null && !_westBuyed) ? 1 : 0);
			return result;
		}
	}

	public BuildingWall NordWall { get; private set; }

	public BuildingWall EastWall { get; private set; }

	public BuildingWall SouthWall { get; private set; }

	public BuildingWall WestWall { get; private set; }

	public BuildingFloor Floor { get; private set; }

	public ConstructionGrid LinkedGrid { get; private set; }

	public RoomBuilding LinkedRoom
	{
		get
		{
			if (_linkedRoom == null)
			{
				_linkedRoom = LinkedGrid.RoomManager.GetRoomByIndex(_private_sectorID);
			}
			return _linkedRoom;
		}
		set
		{
			if (!(_linkedRoom == value))
			{
				_linkedRoom = value;
			}
		}
	}

	public int BuildedSectorID
	{
		get
		{
			return _private_sectorID;
		}
		set
		{
			_private_tempSectorID = null;
			_private_sectorID = Mathf.Clamp(value, 0, 1000);
			if (_private_sectorID == 0)
			{
				CellMaterials.SetFloor(0);
				CellMaterials.SetNordWall(0);
				CellMaterials.SetEastWall(0);
				CellMaterials.SetSouthWall(0);
				CellMaterials.SetWestWall(0);
				CellMaterials.BuyPaint();
			}
			RefreshBuildable(canDestroy: true);
			LinkedRoom = LinkedGrid.RoomManager.GetRoomByIndex(_private_sectorID);
		}
	}

	public int? TempSectorID
	{
		get
		{
			return _private_tempSectorID;
		}
		set
		{
			if (value.HasValue)
			{
				_private_tempSectorID = Mathf.Clamp(value.Value, 0, 1000);
			}
			else
			{
				_private_tempSectorID = null;
			}
		}
	}

	public ECellState CurrentState
	{
		get
		{
			return _private_currentState;
		}
		set
		{
			if (_additiveRenderer == null)
			{
				_additiveRenderer = base.transform.GetChild(0).GetComponent<Renderer>();
				_material = _additiveRenderer.material;
			}
			if (!OverridableCell)
			{
				_additiveRenderer.enabled = false;
				return;
			}
			switch (value)
			{
			case ECellState.Default:
				_additiveRenderer.enabled = false;
				break;
			case ECellState.ToBuild:
				_additiveRenderer.enabled = true;
				_additiveRenderer.material = _material;
				_material.SetColor(SHColor, _selectedColor);
				break;
			case ECellState.ToDestroy:
				_additiveRenderer.enabled = true;
				_additiveRenderer.material = _material;
				_material.SetColor(SHColor, _destructedColor);
				break;
			case ECellState.Invalide:
				_additiveRenderer.enabled = true;
				_material.SetColor(SHColor, _invalidColor);
				break;
			}
			_private_currentState = value;
		}
	}

	public int CurrentSectorID
	{
		get
		{
			if (_private_tempSectorID.HasValue)
			{
				return _private_tempSectorID.Value;
			}
			return _private_sectorID;
		}
	}

	public bool HasTempSector => _private_tempSectorID.HasValue;

	public bool HasFloorTile { get; set; } = true;

	public bool OverridableCell
	{
		get
		{
			return _overridableCell;
		}
		set
		{
			_overridableCell = value;
			GetComponent<Renderer>().enabled = _overridableCell || _isEnd;
		}
	}

	public void SetMaterial(Material mat)
	{
		if (!(_currentMat == mat))
		{
			_currentMat = mat;
			GetComponent<MeshRenderer>().sharedMaterial = mat;
		}
	}

	public void SetEnds(bool xPlus, bool xMinus, bool zPlus, bool zMinus)
	{
		MeshFilter component = GetComponent<MeshFilter>();
		_isEnd = xPlus || xMinus || zPlus || zMinus;
		Color[] colors = new Color[4]
		{
			(zPlus || xPlus) ? _transColor : _opaqueColor,
			(zMinus || xPlus) ? _transColor : _opaqueColor,
			(zMinus || xMinus) ? _transColor : _opaqueColor,
			(zPlus || xMinus) ? _transColor : _opaqueColor
		};
		component.mesh.colors = colors;
	}

	private void Awake()
	{
		_additiveRenderer = base.transform.GetChild(0).GetComponent<Renderer>();
		_material = _additiveRenderer.material;
		CurrentState = ECellState.Default;
		LinkedGrid = GetComponentInParent<ConstructionGrid>(includeInactive: true);
		if ((bool)LinkedGrid)
		{
			LinkedGrid.RoomManager.ChangedVisibility += OnChangedVisibility;
		}
		CellMaterials.LinkedCell = this;
	}

	private void Start()
	{
		if (setCellUnoveriadable)
		{
			OverridableCell = false;
		}
	}

	private void OnDestroy()
	{
		if ((bool)LinkedGrid)
		{
			LinkedGrid.RoomManager.ChangedVisibility -= OnChangedVisibility;
		}
	}

	public void ClearCell()
	{
		_private_sectorID = 0;
		_private_currentState = ECellState.Default;
		_private_tempSectorID = null;
		InteriorState = EInteriorState.None;
	}

	[Button(null, EButtonEnableMode.Always)]
	private void SetUnoverridable()
	{
		OverridableCell = false;
	}

	public void LoadCellFromEditor(CellSaveData data)
	{
		if (NordWall != null)
		{
			NordWall.Remove();
			Pooler.Push(NordWall);
			NordWall = null;
		}
		if (EastWall != null)
		{
			EastWall.Remove();
			Pooler.Push(EastWall);
			EastWall = null;
		}
		if (SouthWall != null)
		{
			SouthWall.Remove();
			Pooler.Push(SouthWall);
			SouthWall = null;
		}
		if (WestWall != null)
		{
			WestWall.Remove();
			Pooler.Push(WestWall);
			WestWall = null;
		}
		InteriorState = ((data.roomID != 0) ? EInteriorState.IsInterior : EInteriorState.None);
		_private_sectorID = data.roomID;
		CellMaterials.FromSaveArray(data.paint);
		base.gameObject.SetActive(value: true);
		UpdateVisuals();
	}

	public void LoadBuildables(CellSaveData data)
	{
		if (!string.IsNullOrEmpty(data.buildableName))
		{
			switch ((ERotationAngle)data.buildableRotation)
			{
			case ERotationAngle.Nord:
				MonoSingleton<BuildablePlacementSystem>.Instance.PlaceFromEditor(data.buildableName, NordWall);
				break;
			case ERotationAngle.East:
				MonoSingleton<BuildablePlacementSystem>.Instance.PlaceFromEditor(data.buildableName, EastWall);
				break;
			case ERotationAngle.South:
				MonoSingleton<BuildablePlacementSystem>.Instance.PlaceFromEditor(data.buildableName, SouthWall);
				break;
			case ERotationAngle.West:
				MonoSingleton<BuildablePlacementSystem>.Instance.PlaceFromEditor(data.buildableName, WestWall);
				break;
			}
		}
	}

	public CellSaveData SaveCellFromEditor()
	{
		return new CellSaveData
		{
			roomID = CurrentSectorID,
			position = Coordinate,
			paint = CellMaterials.ToSaveArray(),
			buildableName = ((!(BuildableElement != null)) ? "" : ((BuildableElement.MainCell.Coordinate == Coordinate) ? BuildableElement.BuildableElementSO.name : "")),
			buildableRotation = (int)BuildableRotation
		};
	}

	public ConstructionCell GetNeighborCellFromBuildable()
	{
		if (BuildableElement == null)
		{
			return null;
		}
		if (BuildableRotation == ERotationAngle.None)
		{
			return null;
		}
		return LinkedGrid.GetNeighborCell(Coordinate, BuildableRotation);
	}

	public ConstructionCell GetOppositeCellFromBuildable()
	{
		if (BuildableElement == null)
		{
			return null;
		}
		if (BuildableRotation == ERotationAngle.None)
		{
			return null;
		}
		ERotationAngle rotation = BuildableRotation switch
		{
			ERotationAngle.None => ERotationAngle.None, 
			ERotationAngle.Nord => ERotationAngle.South, 
			ERotationAngle.East => ERotationAngle.West, 
			ERotationAngle.South => ERotationAngle.Nord, 
			ERotationAngle.West => ERotationAngle.East, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		LinkedGrid.TryGetNeighborCell(Coordinate, rotation, out var outCell);
		return outCell;
	}

	public void SetBuildableElement(BuildableElement buildableElement, ERotationAngle rotationAngle)
	{
		buildableElement.MainCell = this;
		if (BuildableElement == null)
		{
			BuildableElement = buildableElement;
			BuildableRotation = rotationAngle;
		}
		if (BuildableElement != null && BuildableRotation == rotationAngle)
		{
			switch (BuildableRotation)
			{
			case ERotationAngle.Nord:
				NordWall.SurfaceObject?.CutQuad(buildableElement.CurrentWallCutter);
				break;
			case ERotationAngle.East:
				EastWall.SurfaceObject?.CutQuad(buildableElement.CurrentWallCutter);
				break;
			case ERotationAngle.South:
				SouthWall.SurfaceObject?.CutQuad(buildableElement.CurrentWallCutter);
				break;
			case ERotationAngle.West:
				WestWall.SurfaceObject?.CutQuad(buildableElement.CurrentWallCutter);
				break;
			}
		}
	}

	public void RemoveBuildableElement()
	{
		if (BuildableElement != null)
		{
			BuildableElement = null;
		}
		NordWall?.SurfaceObject?.ResetCutter();
		EastWall?.SurfaceObject?.ResetCutter();
		SouthWall?.SurfaceObject?.ResetCutter();
		WestWall?.SurfaceObject?.ResetCutter();
	}

	public BuildingWall GetWallFromBuildableRotation()
	{
		return BuildableRotation switch
		{
			ERotationAngle.Nord => NordWall, 
			ERotationAngle.East => EastWall, 
			ERotationAngle.South => SouthWall, 
			ERotationAngle.West => WestWall, 
			_ => null, 
		};
	}

	public void RefreshBuildable(BuildableElement element, bool canDestroy)
	{
		BuildingWall wallFromBuildableRotation = GetWallFromBuildableRotation();
		if (wallFromBuildableRotation == null)
		{
			return;
		}
		if (element != null)
		{
			if (wallFromBuildableRotation.CanPlaceBuildableType(element.BuildableType) && wallFromBuildableRotation.GetNeighborCell() != null && BuildedSectorID != wallFromBuildableRotation.GetNeighborCell().BuildedSectorID)
			{
				wallFromBuildableRotation.SurfaceObject?.CutQuad(element.CurrentWallCutter);
				if (wallFromBuildableRotation.GetNeighborWall() != null)
				{
					wallFromBuildableRotation.GetNeighborWall().SurfaceObject.CutQuad(element.CurrentWallCutter);
				}
				element.OnPlaced(wallFromBuildableRotation);
			}
			else if (canDestroy)
			{
				BuildableRotation = ERotationAngle.None;
				element.DestroyElement();
				RemoveBuildableElement();
				wallFromBuildableRotation.GetNeighborCell().RemoveBuildableElement();
			}
		}
		else
		{
			wallFromBuildableRotation.SurfaceObject.ResetCutter();
		}
	}

	public void RefreshBuildable(bool canDestroy)
	{
		if ((object)BuildableElement != null && OverridableCell)
		{
			RefreshBuildable(BuildableElement, canDestroy);
		}
	}

	public void UpdateVisuals()
	{
		if (NordWall != null)
		{
			NordWall.UpdateVisual();
		}
		if (EastWall != null)
		{
			EastWall.UpdateVisual();
		}
		if (SouthWall != null)
		{
			SouthWall.UpdateVisual();
		}
		if (WestWall != null)
		{
			WestWall.UpdateVisual();
		}
		bool flag = Floor != null;
		if (flag)
		{
			Floor.UpdateVisual();
		}
		if ((bool)LinkedGrid)
		{
			if (flag && Floor.PaintMaterial.HasValue)
			{
				SetMaterial(LinkedGrid.UsedGridMaterial);
			}
			else
			{
				SetMaterial(LinkedGrid.FreeGridMaterial);
			}
		}
	}

	public void BuildCell()
	{
		if (Floor == null)
		{
			CellMaterials.ClearFloor();
		}
		if (NordWall == null)
		{
			CellMaterials.ClearNord();
			if (BuildableElement != null && BuildableRotation == ERotationAngle.Nord)
			{
				BuildableRotation = ERotationAngle.None;
				BuildableElement?.DestroyElement();
				BuildableElement = null;
			}
		}
		else
		{
			RefreshBuildable(canDestroy: true);
		}
		_nordBuyed = NordWall != null;
		if (EastWall == null)
		{
			CellMaterials.ClearEast();
			if (BuildableElement != null && BuildableRotation == ERotationAngle.East)
			{
				BuildableRotation = ERotationAngle.None;
				BuildableElement?.DestroyElement();
				BuildableElement = null;
			}
		}
		else
		{
			RefreshBuildable(canDestroy: true);
		}
		_eastBuyed = EastWall != null;
		if (SouthWall == null)
		{
			CellMaterials.ClearSouth();
			if (BuildableElement != null && BuildableRotation == ERotationAngle.South)
			{
				BuildableRotation = ERotationAngle.None;
				BuildableElement?.DestroyElement();
				BuildableElement = null;
			}
		}
		else
		{
			RefreshBuildable(canDestroy: true);
		}
		_southBuyed = SouthWall != null;
		if (WestWall == null)
		{
			CellMaterials.ClearWest();
			if (BuildableElement != null && BuildableRotation == ERotationAngle.West)
			{
				BuildableRotation = ERotationAngle.None;
				BuildableElement?.DestroyElement();
				BuildableElement = null;
			}
		}
		else
		{
			RefreshBuildable(canDestroy: true);
		}
		_westBuyed = WestWall != null;
	}

	public void ConfirmBuyPaint()
	{
		CellMaterials.BuyPaint();
		if (NordWall != null)
		{
			NordWall.UpdatePaint();
		}
		if (EastWall != null)
		{
			EastWall.UpdatePaint();
		}
		if (SouthWall != null)
		{
			SouthWall.UpdatePaint();
		}
		if (WestWall != null)
		{
			WestWall.UpdatePaint();
		}
		if (Floor != null)
		{
			Floor.UpdatePaint();
		}
	}

	public void ClearBuyPaint()
	{
		CellMaterials.ClearBuyPaint();
		if (NordWall != null)
		{
			NordWall.UpdatePaint();
		}
		if (EastWall != null)
		{
			EastWall.UpdatePaint();
		}
		if (SouthWall != null)
		{
			SouthWall.UpdatePaint();
		}
		if (WestWall != null)
		{
			WestWall.UpdatePaint();
		}
		if (Floor != null)
		{
			Floor.UpdatePaint();
		}
	}

	public int GetPaintingCost()
	{
		return CellMaterials.GetPaintingCost();
	}

	public void UpdateWallsStruct(List<CellConstructionStruct> cellConstructionStructs, GameObject previsualContainer, RoomBuilding room)
	{
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		foreach (CellConstructionStruct cellConstructionStruct in cellConstructionStructs)
		{
			switch (cellConstructionStruct.RotationType)
			{
			case ERotationAngle.Nord:
				flag = false;
				if ((object)NordWall != null)
				{
					NordWall.WallType = cellConstructionStruct.WallType;
				}
				else
				{
					NordWall = SpawnWall(cellConstructionStruct, previsualContainer, room);
				}
				break;
			case ERotationAngle.East:
				flag2 = false;
				if (EastWall != null)
				{
					EastWall.WallType = cellConstructionStruct.WallType;
				}
				else
				{
					EastWall = SpawnWall(cellConstructionStruct, previsualContainer, room);
				}
				break;
			case ERotationAngle.South:
				flag3 = false;
				if (SouthWall != null)
				{
					SouthWall.WallType = cellConstructionStruct.WallType;
				}
				else
				{
					SouthWall = SpawnWall(cellConstructionStruct, previsualContainer, room);
				}
				break;
			case ERotationAngle.West:
				flag4 = false;
				if (WestWall != null)
				{
					WestWall.WallType = cellConstructionStruct.WallType;
				}
				else
				{
					WestWall = SpawnWall(cellConstructionStruct, previsualContainer, room);
				}
				break;
			}
		}
		if (flag && (object)NordWall != null)
		{
			NordWall.Remove();
			Pooler.Push(NordWall);
			NordWall = null;
		}
		if (flag2 && (object)EastWall != null)
		{
			EastWall.Remove();
			Pooler.Push(EastWall);
			EastWall = null;
		}
		if (flag3 && (object)SouthWall != null)
		{
			SouthWall.Remove();
			Pooler.Push(SouthWall);
			SouthWall = null;
		}
		if (flag4 && (object)WestWall != null)
		{
			WestWall.Remove();
			Pooler.Push(WestWall);
			WestWall = null;
		}
		RefreshBuildable(canDestroy: false);
		if ((object)room != null)
		{
			BuildCell();
		}
		UpdateVisuals();
	}

	private void OnChangedVisibility(bool visible)
	{
		if ((bool)BuildableElement)
		{
			BuildableElement.ChangeVisibility(visible);
		}
		if ((bool)NordWall)
		{
			NordWall.ChangeVisibility(visible);
		}
		if ((bool)EastWall)
		{
			EastWall.ChangeVisibility(visible);
		}
		if ((bool)SouthWall)
		{
			SouthWall.ChangeVisibility(visible);
		}
		if ((bool)WestWall)
		{
			WestWall.ChangeVisibility(visible);
		}
		if (CurrentState != ECellState.Default && (bool)Floor)
		{
			Floor.ChangeVisibility(visible);
		}
	}

	private IEnumerator ShowCell(bool show)
	{
		float timer = 0f;
		base.transform.localScale = (show ? Vector3.zero : Vector3.one);
		while (timer < 1f)
		{
			timer += Time.unscaledDeltaTime * 4f;
			base.transform.localScale = Vector3.one * _spawnScaleAnimationCurve.Evaluate(show ? timer : (1f - timer));
			yield return null;
		}
		if (show)
		{
			base.transform.localScale = Vector3.one;
		}
		else
		{
			base.transform.localScale = Vector3.zero;
			base.gameObject.SetActive(value: false);
		}
		_showCellCoroutine = null;
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		if (_showCellCoroutine != null)
		{
			StopCoroutine(_showCellCoroutine);
		}
		_showCellCoroutine = StartCoroutine(ShowCell(show: true));
	}

	public void Hide()
	{
		if (base.gameObject.activeSelf)
		{
			if (_showCellCoroutine != null)
			{
				StopCoroutine(_showCellCoroutine);
			}
			_showCellCoroutine = StartCoroutine(ShowCell(show: false));
		}
	}

	public BuildingWall GetOppositeWallFromWall(BuildingWall wall)
	{
		return wall.RotationAngle switch
		{
			ERotationAngle.Nord => SouthWall, 
			ERotationAngle.East => WestWall, 
			ERotationAngle.South => NordWall, 
			ERotationAngle.West => EastWall, 
			_ => null, 
		};
	}

	public BuildingWall GetOppositeWallFromRotation(ERotationAngle rotationAngle)
	{
		return rotationAngle switch
		{
			ERotationAngle.Nord => SouthWall, 
			ERotationAngle.East => WestWall, 
			ERotationAngle.South => NordWall, 
			ERotationAngle.West => EastWall, 
			_ => null, 
		};
	}

	public ConstructionCell GetNeighborCell(Vector2Int coordinate)
	{
		return LinkedGrid.GetNeighborCell(Coordinate, ERotationAngle.Nord);
	}

	public void SpawnFloor(RoomBuilding room)
	{
		Floor = UnityEngine.Object.Instantiate(MonoSingleton<ConstructionParams>.Instance.FloorPrefab, base.transform.position, base.transform.rotation, room.FloorContainer);
		Floor.LinkedCell = this;
		Floor.LinkedRoom = room;
	}

	private BuildingWall SpawnWall(CellConstructionStruct cellStruct, GameObject wallContainer, RoomBuilding room)
	{
		BuildingWall wallPrefab = MonoSingleton<ConstructionParams>.Instance.GetWallPrefab(largeWall: false);
		if (wallPrefab == null)
		{
			Debug.LogError("No Wall To Spawn Founded!");
			return null;
		}
		BuildingWall buildingWall = Pooler.Pull(wallPrefab, active: true);
		buildingWall.LinkedRoom = room;
		if (room == null)
		{
			buildingWall.transform.SetParent(wallContainer.transform);
		}
		buildingWall.LinkedCell = this;
		buildingWall.RotationAngle = cellStruct.RotationType;
		buildingWall.WallType = cellStruct.WallType;
		MonoSingleton<ConstructionSystem>.Instance.CurrentWallToCreateCount++;
		return buildingWall;
	}

	private void OnDrawGizmosSelected()
	{
		if (!OverridableCell)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(base.transform.position, Vector3.one);
			return;
		}
		Gizmos.DrawCube(base.transform.position, Vector3.one);
		switch (InteriorState)
		{
		case EInteriorState.MarkAsInterior:
			Gizmos.color = Color.red;
			Gizmos.DrawCube(base.transform.position, new Vector3(0.5f, CurrentSectorID * 2 + 1, 0.5f));
			break;
		case EInteriorState.None:
			Gizmos.color = Color.gray;
			Gizmos.DrawCube(base.transform.position, new Vector3(0.5f, CurrentSectorID * 2 + 1, 0.5f));
			break;
		case EInteriorState.IsInterior:
			break;
		}
	}
}
