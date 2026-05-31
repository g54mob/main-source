using System;
using System.Collections;
using CTS.Core;
using UnityEngine;

public class BuildingFloor : AbsBuildingElement
{
	private MeshRenderer _assignationRenderer;

	public event Action<RoomBuilding, RoomBuilding> LinkedRoomChanged;

	public MeshRenderer GetAssignationRenderer()
	{
		if (!_assignationRenderer)
		{
			_assignationRenderer = base.transform.GetChild(0).GetComponent<MeshRenderer>();
		}
		return _assignationRenderer;
	}

	protected override void SetLinkedRoom(RoomBuilding room)
	{
		RoomBuilding linkedRoom = base.LinkedRoom;
		if ((bool)linkedRoom)
		{
			linkedRoom.RemoveFloorTile(this);
		}
		base.SetLinkedRoom(room);
		if ((bool)room)
		{
			base.transform.SetParent(room.FloorContainer);
			room.AddFloorTile(this);
		}
		else
		{
			GetAssignationRenderer().enabled = false;
		}
		this.LinkedRoomChanged?.Invoke(linkedRoom, room);
	}

	private void Start()
	{
		SetMaterial(null);
		affectedMaterial = null;
	}

	public override void AppliqMaterial()
	{
		affectedMaterial = MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex;
		SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.FloorMaterialsSOs[affectedMaterial.Value].MaterialData);
		if (base.LinkedCell.CellMaterials.SetFloor(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.SelectedMaterialdataIndex))
		{
			MonoSingleton<SurfaceObjectPaintingSystem>.Instance.AddRepaintToList(base.LinkedCell);
		}
		MonoSingleton<SurfaceObjectPaintingSystem>.Instance.UpdatePaintingCost();
	}

	public void UpdatePaint()
	{
		affectedMaterial = base.LinkedCell.CellMaterials.GetFloorIndex();
		SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.FloorMaterialsSOs[affectedMaterial.Value].MaterialData);
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
				SetMaterial(null);
			}
			else
			{
				SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetFloorMaterialFromIndex(base.LinkedCell.CellMaterials.GetFloorIndex()));
				affectedMaterial = base.LinkedCell.CellMaterials.GetFloorIndex();
			}
		}
		else if (base.LinkedCell.CurrentSectorID == 0 && MonoSingleton<ConstructionSystem>.Instance.CurrentGrid != null && MonoSingleton<ConstructionSystem>.Instance.CurrentGrid.IsGroundFloor)
		{
			SetMaterial(null);
			affectedMaterial = null;
		}
		else
		{
			SetMaterial(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.FloorMaterialsSOs[affectedMaterial.Value].MaterialData);
		}
		if (base.LinkedRoom == null || base.LinkedRoom.RoomIndex != base.LinkedCell.CurrentSectorID)
		{
			RoomBuilding roomByIndex = MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.GetRoomByIndex(base.LinkedCell.CurrentSectorID);
			if (roomByIndex != null)
			{
				base.LinkedRoom = roomByIndex;
			}
		}
	}

	protected override IEnumerator Spawn()
	{
		float timer = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 one = Vector3.one;
		while (timer < 1f)
		{
			timer += Time.unscaledDeltaTime * 4f;
			base.transform.localScale = Vector3.LerpUnclamped(zero, one, timer);
			yield return null;
		}
		base.transform.localScale = one;
	}
}
