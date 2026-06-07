using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

public class BuildingWall : AbsBuildingElement, IPoolable, IPoolCallbackReceiver
{
	private MeshFilter _meshFilter;

	private ERotationAngle __rotationAngle;

	private EWallType __wallType;

	PoolGuid IPoolable.PoolGuid { get; set; }

	public ERotationAngle RotationAngle
	{
		get
		{
			return __rotationAngle;
		}
		set
		{
			__rotationAngle = value;
			Vector3 vector = new Vector3(MonoSingleton<ConstructionParams>.Instance.CellSize / 2f, 0f, MonoSingleton<ConstructionParams>.Instance.CellSize / 2f);
			switch (__rotationAngle)
			{
			case ERotationAngle.Nord:
				vector = new Vector3(0f, 0f, 0.5f);
				break;
			case ERotationAngle.East:
				vector = new Vector3(0.5f, 0f, 0f);
				break;
			case ERotationAngle.South:
				vector = new Vector3(0f, 0f, -0.5f);
				break;
			case ERotationAngle.West:
				vector = new Vector3(-0.5f, 0f, 0f);
				break;
			}
			if (base.LinkedCell != null)
			{
				base.transform.position = base.LinkedCell.transform.position + vector;
			}
			base.transform.rotation = ConstructionParams.GetRotationFromRotationAngle(value);
		}
	}

	public bool IsInterior
	{
		get
		{
			if ((object)base.LinkedRoom == null || base.LinkedRoom.RoomIndex == 0)
			{
				return false;
			}
			ConstructionCell neighborCell = GetNeighborCell();
			if ((object)neighborCell?.LinkedRoom != null)
			{
				return neighborCell.LinkedRoom.RoomIndex != 0;
			}
			return false;
		}
	}

	public EWallType WallType
	{
		get
		{
			return __wallType;
		}
		set
		{
			SetMesh(MonoSingleton<ConstructionParams>.Instance.GetMeshFromWallType(value, base.LinkedCell.CurrentSectorID == 0));
			__wallType = value;
		}
	}

	public bool IsExteriorLimitWall
	{
		get
		{
			if (base.LinkedCell.CurrentSectorID != 0 && !(GetNeighborWall() == null))
			{
				return GetNeighborWall().LinkedCell.CurrentSectorID == 0;
			}
			return true;
		}
	}

	public event Action Removing;

	public override void AppliqMaterial()
	{
		affectedMaterial = MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex;
		SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[affectedMaterial.Value].MaterialData);
		switch (__rotationAngle)
		{
		case ERotationAngle.Nord:
			if (base.LinkedCell.CellMaterials.SetNordWall(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex))
			{
				MonoSingleton<SurfaceObjectPaintingSystem>.Instance.AddRepaintToList(base.LinkedCell);
			}
			break;
		case ERotationAngle.East:
			if (base.LinkedCell.CellMaterials.SetEastWall(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex))
			{
				MonoSingleton<SurfaceObjectPaintingSystem>.Instance.AddRepaintToList(base.LinkedCell);
			}
			break;
		case ERotationAngle.South:
			if (base.LinkedCell.CellMaterials.SetSouthWall(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex))
			{
				MonoSingleton<SurfaceObjectPaintingSystem>.Instance.AddRepaintToList(base.LinkedCell);
			}
			break;
		case ERotationAngle.West:
			if (base.LinkedCell.CellMaterials.SetWestWall(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex))
			{
				MonoSingleton<SurfaceObjectPaintingSystem>.Instance.AddRepaintToList(base.LinkedCell);
			}
			break;
		}
		MonoSingleton<SurfaceObjectPaintingSystem>.Instance.UpdatePaintingCost();
	}

	public void UpdatePaint()
	{
		switch (__rotationAngle)
		{
		case ERotationAngle.Nord:
			affectedMaterial = base.LinkedCell.CellMaterials.GetNordWallIndex();
			break;
		case ERotationAngle.East:
			affectedMaterial = base.LinkedCell.CellMaterials.GetEastWallIndex();
			break;
		case ERotationAngle.South:
			affectedMaterial = base.LinkedCell.CellMaterials.GetSouthWallIndex();
			break;
		case ERotationAngle.West:
			affectedMaterial = base.LinkedCell.CellMaterials.GetWestWallIndex();
			break;
		}
		SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[affectedMaterial.Value].MaterialData);
	}

	public override void UpdateVisual()
	{
		if (base.LinkedCell.CurrentState == ConstructionCell.ECellState.ToBuild || base.LinkedCell.HasTempSector)
		{
			SetMaterial(MonoSingleton<ConstructionParams>.Instance.PrevisualMaterial);
			return;
		}
		if (!affectedMaterial.HasValue)
		{
			if (base.LinkedCell.CurrentSectorID == 0)
			{
				SetMaterial(base.LinkedCell.LinkedGrid.ExteriorWallMaterial);
			}
			else
			{
				switch (__rotationAngle)
				{
				case ERotationAngle.Nord:
					SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallMaterialFromIndex(base.LinkedCell.CellMaterials.GetNordWallIndex()));
					affectedMaterial = base.LinkedCell.CellMaterials.GetNordWallIndex();
					break;
				case ERotationAngle.East:
					SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallMaterialFromIndex(base.LinkedCell.CellMaterials.GetEastWallIndex()));
					affectedMaterial = base.LinkedCell.CellMaterials.GetEastWallIndex();
					break;
				case ERotationAngle.South:
					SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallMaterialFromIndex(base.LinkedCell.CellMaterials.GetSouthWallIndex()));
					affectedMaterial = base.LinkedCell.CellMaterials.GetSouthWallIndex();
					break;
				case ERotationAngle.West:
					SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallMaterialFromIndex(base.LinkedCell.CellMaterials.GetWestWallIndex()));
					affectedMaterial = base.LinkedCell.CellMaterials.GetWestWallIndex();
					break;
				}
			}
		}
		else if (base.LinkedCell.CurrentSectorID == 0 && !base.LinkedCell.LinkedGrid.IsUnderGround)
		{
			SetMaterial(MonoSingleton<ConstructionSystem>.Instance.CurrentGrid.ExteriorWallMaterial);
			affectedMaterial = null;
		}
		else
		{
			SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[affectedMaterial.Value].MaterialData);
		}
		if (base.LinkedRoom == null || base.LinkedRoom.RoomIndex != base.LinkedCell.CurrentSectorID)
		{
			RoomBuilding roomByIndex = MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.GetRoomByIndex(base.LinkedCell.CurrentSectorID);
			if (roomByIndex != null)
			{
				base.LinkedRoom = roomByIndex;
				PlaySpawnEffect();
			}
		}
	}

	protected override void SetLinkedRoom(RoomBuilding room)
	{
		RoomBuilding linkedRoom = base.LinkedRoom;
		if ((bool)linkedRoom)
		{
			linkedRoom.RemoveWallTile(this);
		}
		base.SetLinkedRoom(room);
		if ((bool)room && linkedRoom != base.LinkedRoom)
		{
			room.AddWallTile(this);
			base.transform.SetParent(room.WallsContainer);
		}
	}

	public ConstructionCell GetNeighborCell()
	{
		return base.LinkedCell?.LinkedGrid.GetNeighborCell(base.LinkedCell.Coordinate, RotationAngle);
	}

	public BuildingWall GetNeighborWall()
	{
		ConstructionCell constructionCell = base.LinkedCell?.LinkedGrid.GetNeighborCell(base.LinkedCell.Coordinate, RotationAngle);
		if ((object)constructionCell == null)
		{
			return null;
		}
		return RotationAngle switch
		{
			ERotationAngle.Nord => constructionCell.SouthWall, 
			ERotationAngle.East => constructionCell.WestWall, 
			ERotationAngle.South => constructionCell.NordWall, 
			ERotationAngle.West => constructionCell.EastWall, 
			_ => null, 
		};
	}

	protected override IEnumerator Spawn()
	{
		float timer = 0f;
		Vector3 zero = Vector3.right;
		Vector3 one = Vector3.one;
		_ = Vector3.right;
		while (timer < 1f)
		{
			timer += Time.unscaledDeltaTime * 4f;
			base.transform.localScale = Vector3.LerpUnclamped(zero, one, MonoSingleton<ConstructionParams>.Instance.SpawnScaleCurveY.Evaluate(timer));
			yield return null;
		}
		base.transform.localScale = one;
	}

	private void SetMesh(Mesh mesh)
	{
		if (!(_meshFilter == null) || TryGetComponent<MeshFilter>(out _meshFilter))
		{
			_meshFilter.sharedMesh = mesh;
		}
	}

	public bool CanPlaceBuildableElement(BuildableElementSO buildableElementSO, bool checkIfFree)
	{
		if (MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney() < buildableElementSO.PurchasePrice)
		{
			return false;
		}
		if (!IsFreeBuildablePlace(buildableElementSO))
		{
			return false;
		}
		return CanPlaceBuildableType(buildableElementSO.BuildableType);
	}

	private bool IsFreeBuildablePlace(BuildableElementSO buildableElementSO)
	{
		if (!buildableElementSO.Prefab.CanBePlaced(this))
		{
			return false;
		}
		if (base.LinkedCell.BuildableElement != null || GetNeighborWall().LinkedCell.BuildableElement != null)
		{
			return false;
		}
		return true;
	}

	public bool CanPlaceBuildableType(BuildableElementSO.EBuildableType buildableType)
	{
		if (!MonoSingleton<ConstructionSystem>.InstanceExists() || !MonoSingleton<ConstructionSystem>.Instance.CurrentGrid)
		{
			return false;
		}
		switch (buildableType)
		{
		case BuildableElementSO.EBuildableType.Arch:
			if (WallType == EWallType.Simple && (GetNeighborWall() == null || GetNeighborWall().WallType == EWallType.Simple))
			{
				return !IsExteriorLimitWall;
			}
			return false;
		case BuildableElementSO.EBuildableType.Window:
			if (WallType == EWallType.Simple && (GetNeighborWall() == null || GetNeighborWall().WallType == EWallType.Simple) && IsExteriorLimitWall)
			{
				return !MonoSingleton<ConstructionSystem>.Instance.CurrentGrid.IsUnderGround;
			}
			return false;
		case BuildableElementSO.EBuildableType.Door:
			if (WallType == EWallType.Simple)
			{
				if (!(GetNeighborWall() == null))
				{
					return GetNeighborWall().WallType == EWallType.Simple;
				}
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	void IPoolCallbackReceiver.OnPulled()
	{
	}

	void IPoolCallbackReceiver.OnPushed()
	{
		base.transform.localScale = Vector3.one;
		affectedMaterial = null;
		base.SurfaceObject.ResetCutter();
	}

	public void Remove()
	{
		this.Removing?.Invoke();
	}
}
