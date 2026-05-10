using System;
using CTS;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

public class RoomAssignationVisual : CTSBehaviour
{
	[SerializeField]
	[Inject(false)]
	private NavMeshRebuilder _navMeshRebuilder;

	[SerializeField]
	[Inject(false)]
	private RoomBuilding _room;

	protected override void OnEnabled()
	{
		base.OnEnabled();
		_navMeshRebuilder.AreaChanged += OnNavMeshAreaChanged;
		RoomAssignationVisualMode.ModeChanged += OnCurrentModeChanged;
		WorldSelector.RegisterToSelection<IRoomAssignable>(OnAssignableObjectSelected);
		WorldSelector.RegisterToSelection<Furniture>(OnFurnitureSelected);
		RoomAssignations.AssignedRoomsChanged += OnAssignedRoomsChanged;
		RefreshTiles();
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		_navMeshRebuilder.AreaChanged -= OnNavMeshAreaChanged;
		RoomAssignationVisualMode.ModeChanged -= OnCurrentModeChanged;
		WorldSelector.UnregisterToSelection<IRoomAssignable>(OnAssignableObjectSelected);
		WorldSelector.UnregisterToSelection<Furniture>(OnFurnitureSelected);
		RoomAssignations.AssignedRoomsChanged -= OnAssignedRoomsChanged;
	}

	public void RefreshTiles()
	{
		switch (RoomAssignationVisualMode.CurrentMode)
		{
		case RoomAssignationVisualMode.EMode.Navigation:
			RefreshTilesForNavigation();
			break;
		case RoomAssignationVisualMode.EMode.ObjectAssignation:
			RefreshTilesForSelectedAssignable();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void OnAssignedRoomsChanged(RoomAssignations assignations, RoomBuilding room)
	{
		if (RoomAssignationVisualMode.CurrentMode == RoomAssignationVisualMode.EMode.ObjectAssignation && (object)room == _room && WorldSelector.IsObjectSelected(assignations))
		{
			RefreshTilesForSelectedAssignable();
		}
	}

	private void OnCurrentModeChanged(RoomAssignationVisualMode.EMode mode)
	{
		RefreshTiles();
	}

	private void OnAssignableObjectSelected(IRoomAssignable worker, bool isSelected)
	{
		if (isSelected && RoomAssignationVisualMode.CurrentMode == RoomAssignationVisualMode.EMode.ObjectAssignation)
		{
			RefreshTilesForSelectedAssignable();
		}
	}

	private void OnFurnitureSelected(Furniture furniture, bool isSelected)
	{
		if (furniture.Interactor is IRoomAssignable worker)
		{
			OnAssignableObjectSelected(worker, isSelected);
		}
	}

	private void OnNavMeshAreaChanged()
	{
		if (RoomAssignationVisualMode.CurrentMode == RoomAssignationVisualMode.EMode.Navigation)
		{
			RefreshTilesForNavigation();
		}
	}

	private void RefreshTilesForSelectedAssignable()
	{
		IRoomAssignable roomAssignable = WorldSelector.GetLastSelected<IRoomAssignable>();
		if (roomAssignable == null)
		{
			foreach (SelectableObject currentSelected in CTSSingleton<WorldSelector>.Instance.CurrentSelectedList)
			{
				if (currentSelected.SelectionTarget is Furniture { Interactor: IRoomAssignable interactor })
				{
					roomAssignable = interactor;
				}
			}
		}
		if (roomAssignable == null || roomAssignable.RoomAssignations == null || !roomAssignable.RoomAssignations.HasRoom(_room))
		{
			DisableAll();
			return;
		}
		Material workerAssignationMaterial = MonoSingleton<ConstructionParams>.Instance.WorkerAssignationMaterial;
		foreach (BuildingFloor floorTile in _room.FloorTiles)
		{
			MeshRenderer assignationRenderer = floorTile.GetAssignationRenderer();
			assignationRenderer.enabled = true;
			assignationRenderer.sharedMaterial = workerAssignationMaterial;
		}
	}

	private void RefreshTilesForNavigation()
	{
		if (MonoSingleton<ConstructionParams>.Instance.RoomAssignationMaterials.TryGetValue(_room.NavArea, out var value))
		{
			foreach (BuildingFloor floorTile in _room.FloorTiles)
			{
				MeshRenderer assignationRenderer = floorTile.GetAssignationRenderer();
				assignationRenderer.enabled = true;
				assignationRenderer.sharedMaterial = value;
			}
			return;
		}
		DisableAll();
	}

	private void DisableAll()
	{
		foreach (BuildingFloor floorTile in _room.FloorTiles)
		{
			floorTile.GetAssignationRenderer().enabled = false;
		}
	}
}
