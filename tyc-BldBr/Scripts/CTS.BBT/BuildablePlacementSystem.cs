using System;
using System.Collections.Generic;
using System.Linq;
using CTS;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildablePlacementSystem : MonoSingleton<BuildablePlacementSystem>
{
	[SerializeField]
	private BuildableCursor _buildableCursorPrefab;

	[SerializeField]
	private LayerMask _wallLayer;

	[SerializeField]
	private LayerMask _buildableLayer;

	[SerializeField]
	private InputActionReference _placementButton;

	private BuildableElementSO[] _buildableElementSOs;

	private bool _buildableCanBePlace;

	private BuildingWall _private_selectedWallForBuildableSpawn;

	private BuildableElementSO _currentSelectedBuildable;

	public BuildableCursor BuildableCursor { get; private set; }

	public Dictionary<BuildableElementSO.EBuildableType, List<BuildableElementSO>> Buildables { get; private set; } = new Dictionary<BuildableElementSO.EBuildableType, List<BuildableElementSO>>();

	public BuildableElementSO CurrentSelectedBuildable
	{
		get
		{
			return _currentSelectedBuildable;
		}
		set
		{
			_currentSelectedBuildable = value;
			BuildablePlacementSystem.OnSelectedValueChanged?.Invoke(_currentSelectedBuildable);
		}
	}

	private BuildingWall SelectedWallForBuildableSpawn
	{
		get
		{
			return _private_selectedWallForBuildableSpawn;
		}
		set
		{
			if (!(value == _private_selectedWallForBuildableSpawn))
			{
				ClearCutter();
				_private_selectedWallForBuildableSpawn?.LinkedCell.RefreshBuildable(canDestroy: true);
				_private_selectedWallForBuildableSpawn?.GetNeighborCell()?.RefreshBuildable(canDestroy: true);
				_private_selectedWallForBuildableSpawn = value;
				if (_private_selectedWallForBuildableSpawn == null)
				{
					BuildableCursor.transform.position = new Vector3(0f, -20f, 0f);
				}
				else if (!(CurrentSelectedBuildable == null) && CurrentSelectedBuildable.BuildableType != BuildableElementSO.EBuildableType.Room)
				{
					_private_selectedWallForBuildableSpawn.SurfaceObject.CutQuad(CurrentSelectedBuildable.Prefab.CurrentWallCutter);
					_private_selectedWallForBuildableSpawn.GetNeighborWall()?.SurfaceObject.CutQuad(CurrentSelectedBuildable.Prefab.CurrentWallCutter);
				}
			}
		}
	}

	public static event Action<BuildableElementSO> OnSelectedValueChanged;

	public static event Action<BuildableElement> OnBuildablePlaced;

	protected override void SingletonAwake()
	{
		BuildableCursor = UnityEngine.Object.Instantiate(_buildableCursorPrefab);
		_buildableElementSOs = Addressables.LoadAssetsAsync<BuildableElementSO>("Buildables").WaitForCompletion().ToArray();
		BuildableElementSO[] buildableElementSOs = _buildableElementSOs;
		foreach (BuildableElementSO buildableElementSO in buildableElementSOs)
		{
			Buildables.EnsureKeyExists(buildableElementSO.BuildableType).Add(buildableElementSO);
		}
		OnSelectedValueChanged += UI_BuildableSelectionPanel_OnSelectedValueChanged;
	}

	private void UI_BuildableSelectionPanel_OnSelectedValueChanged(BuildableElementSO obj)
	{
		BuildableCursor.SetApparenceFromSO(obj);
		BuildableCursor.SetActive(obj != null);
		if (obj == null)
		{
			SelectedWallForBuildableSpawn = null;
		}
	}

	protected override void OnSingletonDestroy()
	{
		OnSelectedValueChanged -= UI_BuildableSelectionPanel_OnSelectedValueChanged;
	}

	private void OnEnable()
	{
		BuildableCursor.SetApparenceFromSO(CurrentSelectedBuildable);
		BuildableCursor.SetActive(active: true);
	}

	private void OnDisable()
	{
		if ((bool)BuildableCursor)
		{
			BuildableCursor.SetActive(active: false);
		}
		ClearCutter();
		SelectedWallForBuildableSpawn = null;
	}

	private void ClearCutter()
	{
		if (SelectedWallForBuildableSpawn != null)
		{
			SelectedWallForBuildableSpawn.SurfaceObject.ResetCutter();
			SelectedWallForBuildableSpawn.GetNeighborWall()?.SurfaceObject.ResetCutter();
		}
	}

	public void UpdateBuildableConstruction()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100f, _wallLayer))
		{
			if (SetBuildableToCursorPosition(hitInfo.point, hitInfo.collider.GetComponent<BuildingWall>()) && _placementButton.action.IsPressed() && CurrentSelectedBuildable != null && CurrentSelectedBuildable.BuildableType != BuildableElementSO.EBuildableType.Room)
			{
				PlaceBuildable(MonoSingleton<ConstructionSystem>.Instance.GetParentWall, BuildableCursor.transform.position, BuildableCursor.transform.rotation);
			}
		}
		else
		{
			BuildableCursor.SetActive(active: false);
		}
	}

	private bool SetBuildableToCursorPosition(Vector3 point, BuildingWall wall)
	{
		if (CurrentSelectedBuildable == null || CurrentSelectedBuildable.BuildableType == BuildableElementSO.EBuildableType.Room)
		{
			BuildableCursor.SetActive(active: false);
			return false;
		}
		BuildableCursor.SetActive(active: true);
		if (wall == null || !wall.CanPlaceBuildableElement(CurrentSelectedBuildable, checkIfFree: true))
		{
			BuildableCursor.SetValidColor(validColor: false);
			BuildableCursor.transform.position = point;
			_buildableCanBePlace = false;
			SelectedWallForBuildableSpawn = null;
			return false;
		}
		SelectedWallForBuildableSpawn = wall;
		BuildableCursor.transform.position = wall.transform.position;
		BuildableCursor.transform.rotation = wall.transform.rotation;
		if (SelectedWallForBuildableSpawn.LinkedCell.BuildedSectorID <= SelectedWallForBuildableSpawn.GetNeighborWall().LinkedCell.BuildedSectorID)
		{
			BuildableCursor.transform.rotation = Quaternion.Euler(BuildableCursor.transform.rotation.eulerAngles + new Vector3(0f, 180f, 0f));
		}
		BuildableCursor.SetApparenceFromSO(CurrentSelectedBuildable, SelectedWallForBuildableSpawn.IsExteriorLimitWall);
		BuildableCursor.SetValidColor(validColor: true);
		_buildableCanBePlace = true;
		return true;
	}

	public void RecreateDoor(BuildingWall wall, BuildableElementSO so)
	{
		SelectedWallForBuildableSpawn = wall;
		CurrentSelectedBuildable = so;
		_buildableCanBePlace = true;
		Vector3 position = wall.transform.position;
		Quaternion poseRotation = wall.transform.rotation;
		if (SelectedWallForBuildableSpawn.LinkedCell.BuildedSectorID <= SelectedWallForBuildableSpawn.GetNeighborWall().LinkedCell.BuildedSectorID)
		{
			poseRotation = Quaternion.Euler(poseRotation.eulerAngles + new Vector3(0f, 180f, 0f));
		}
		PlaceBuildable(MonoSingleton<ConstructionSystem>.Instance.GetParentWall, position, poseRotation);
		_buildableCanBePlace = false;
	}

	private void PlaceBuildable(Transform wallParent, Vector3 posePosition, Quaternion poseRotation)
	{
		if (_buildableCanBePlace && !(SelectedWallForBuildableSpawn == null) && !(CurrentSelectedBuildable == null))
		{
			_ = CurrentSelectedBuildable.BuildableType;
			BuildableElement buildableElement = CTSFactory.Instantiate(CurrentSelectedBuildable.Prefab, posePosition, poseRotation, wallParent, false);
			buildableElement.BuildableElementSO = CurrentSelectedBuildable;
			if (SelectedWallForBuildableSpawn.GetNeighborWall() == null)
			{
				PlaceOnWall(buildableElement, SelectedWallForBuildableSpawn);
			}
			else if (SelectedWallForBuildableSpawn.LinkedCell.BuildedSectorID > SelectedWallForBuildableSpawn.GetNeighborWall().LinkedCell.BuildedSectorID)
			{
				PlaceOnWall(buildableElement, SelectedWallForBuildableSpawn);
				PlaceOnWall(buildableElement, SelectedWallForBuildableSpawn.GetNeighborWall());
			}
			else
			{
				PlaceOnWall(buildableElement, SelectedWallForBuildableSpawn.GetNeighborWall());
				PlaceOnWall(buildableElement, SelectedWallForBuildableSpawn);
			}
			buildableElement.OnPlaced(SelectedWallForBuildableSpawn);
			buildableElement.CheckIfFusionnable();
			buildableElement.gameObject.SetActive(value: true);
			BuildablePlacementSystem.OnBuildablePlaced?.Invoke(buildableElement);
			MonoSingleton<AbsMoneyHandlerBridge>.Instance.SpendMoney(CurrentSelectedBuildable.PurchasePrice);
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Expense, CurrentSelectedBuildable.PurchasePrice, TransactionTag.Renovation);
		}
	}

	public void PlaceFromEditor(string buildableName, BuildingWall wall)
	{
		BuildableElementSO byName = GetByName(buildableName);
		if ((object)byName == null)
		{
			throw new NullReferenceException("Couldn't find buildable " + buildableName);
		}
		BuildableElement buildableElement = CTSFactory.Instantiate(byName.Prefab, wall.transform.position, wall.transform.rotation, MonoSingleton<ConstructionSystem>.Instance.GetParentWall, false);
		buildableElement.BuildableElementSO = byName;
		if (wall.GetNeighborWall() == null)
		{
			PlaceOnWall(buildableElement, wall);
		}
		else if (wall.LinkedCell.BuildedSectorID > wall.GetNeighborWall().LinkedCell.BuildedSectorID)
		{
			PlaceOnWall(buildableElement, wall);
			PlaceOnWall(buildableElement, wall.GetNeighborWall());
		}
		else
		{
			buildableElement.transform.rotation = Quaternion.Euler(buildableElement.transform.rotation.eulerAngles + new Vector3(0f, 180f, 0f));
			PlaceOnWall(buildableElement, wall.GetNeighborWall());
			PlaceOnWall(buildableElement, wall);
		}
		buildableElement.OnPlaced(wall);
		buildableElement.CheckIfFusionnable();
		buildableElement.gameObject.SetActive(value: true);
		BuildablePlacementSystem.OnBuildablePlaced?.Invoke(buildableElement);
	}

	private BuildableElementSO GetByName(string buildableName)
	{
		foreach (BuildableElementSO.EBuildableType key in Buildables.Keys)
		{
			for (int i = 0; i < Buildables[key].Count; i++)
			{
				if (Buildables[key][i].name == buildableName)
				{
					return Buildables[key][i];
				}
			}
		}
		return null;
	}

	private void PlaceOnWall(BuildableElement buildable, BuildingWall wall)
	{
		if (buildable.BuildableType != BuildableElementSO.EBuildableType.Window)
		{
			if (wall.TryGetComponent<NavMeshObstacle>(out var component))
			{
				component.enabled = false;
			}
			if (wall.GetNeighborWall().TryGetComponent<NavMeshObstacle>(out var component2))
			{
				component2.enabled = false;
			}
		}
		wall.LinkedCell.SetBuildableElement(buildable, wall.RotationAngle);
	}

	public void RemoveBuildable(BuildableElement element)
	{
		element.RemoveBySelection();
	}

	public int GetBuildableCount(BuildableElementSO.EBuildableType type)
	{
		if (Buildables.ContainsKey(type))
		{
			return Buildables[type].Count;
		}
		return 0;
	}
}
