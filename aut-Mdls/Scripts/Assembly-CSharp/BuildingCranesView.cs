using System.Collections.Generic;
using System.Linq;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Events.FactoryFloor;
using Logic.FactoryTools;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.ParticleSystemPool;
using Presentation.Locators;
using SaveData.FactoryFloor;
using UnityEngine;
using Utils;

public class BuildingCranesView : FactoryBehaviorView<BuildingCranesBehaviour>
{
	[SerializeField]
	private BuildingCraneView _cranePrefab;

	[SerializeField]
	private GameObject _craneEntrancePreview;

	[SerializeField]
	private GameObject _cranePreview;

	[SerializeField]
	private GameObject _craneRailPreview;

	[SerializeField]
	private HologramVFXController _cranePreviewVFXController;

	[SerializeField]
	private GameObject _possibleCranePositionVisual;

	[SerializeField]
	private ParticleSystemPoolLocator _particleSystemPoolLocator;

	[SerializeField]
	private GridLocator _gridLocator;

	[SerializeField]
	private ToolSystemLocator _toolSystemLocator;

	[SerializeField]
	private PlaceCraneFromBuildingTool _placeCraneFromBuildingTool;

	private bool _initialized;

	private bool _previewIsValid = true;

	private BuildingBehaviour _buildingBehaviour;

	private Vector3Int _craneEntrancePos;

	private Vector3Int _craneEntranceDir;

	private readonly Dictionary<BuildingCranesBehaviour.Crane, BuildingCraneView> _craneViews = new Dictionary<BuildingCranesBehaviour.Crane, BuildingCraneView>();

	private readonly List<GameObject> _possibleCranePosVisuals = new List<GameObject>();

	private readonly List<BuildingCraneView> _previewCranes = new List<BuildingCraneView>();

	protected override void Init()
	{
		base.Init();
		_buildingBehaviour = _behaviour.FactoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
	}

	protected override void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
	{
		base.PreviewInit(objectId, blueprintViewEventDto, element);
		foreach (BehaviourConfigurationDto configuration in element.Configurations)
		{
			if (configuration is BuildingCranesBehaviourConfigurationDto buildingCranesBehaviourConfigurationDto)
			{
				SpawnPreviewCranes(blueprintViewEventDto, element, buildingCranesBehaviourConfigurationDto.CraneDatas);
			}
		}
		_objectView.ValidPositionChanged += UpdatePreviewCranesValid;
		_previewIsValid = true;
	}

	protected override void UpdatePreview(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
	{
		base.UpdatePreview(blueprintViewEventDto, element);
		Vector3 worldPosition = element.Position + blueprintViewEventDto.Blueprint.Position;
		Vector3Int cellPosition = _gridLocator.GetCellPosition(worldPosition);
		int degrees = element.Rotation + blueprintViewEventDto.Blueprint.Rotation;
		bool mirrored = element.Mirrored;
		foreach (BuildingCraneView previewCrane in _previewCranes)
		{
			Vector3Int relativeCraneEntrancePos = previewCrane.CraneData.RelativeCraneEntrancePos;
			Vector3Int relativeCranePos = previewCrane.CraneData.RelativeCranePos;
			if (mirrored)
			{
				relativeCraneEntrancePos.x = -relativeCraneEntrancePos.x;
				relativeCranePos.x = -relativeCranePos.x;
			}
			Vector3Int entrancePos = GridUtils.RotatePoint(relativeCraneEntrancePos, degrees);
			Vector3Int pickupPos = GridUtils.RotatePoint(relativeCranePos, degrees);
			entrancePos += cellPosition;
			pickupPos += cellPosition;
			previewCrane.EntrancePos = entrancePos;
			previewCrane.PickupPos = pickupPos;
			UpdatePreviewCranesValid(_previewIsValid);
		}
	}

	private void SpawnPreviewCranes(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element, List<BuildingCranesBehaviourConfigurationDto.CraneData> craneDatas)
	{
		Vector3 worldPosition = element.Position + blueprintViewEventDto.Blueprint.Position;
		Vector3Int cellPosition = _gridLocator.GetCellPosition(worldPosition);
		int degrees = element.Rotation + blueprintViewEventDto.Blueprint.Rotation;
		bool mirrored = element.Mirrored;
		foreach (BuildingCranesBehaviourConfigurationDto.CraneData craneData in craneDatas)
		{
			Vector3Int relativeCraneEntrancePos = craneData.RelativeCraneEntrancePos;
			Vector3Int relativeCranePos = craneData.RelativeCranePos;
			if (mirrored)
			{
				relativeCraneEntrancePos.x = -relativeCraneEntrancePos.x;
				relativeCranePos.x = -relativeCranePos.x;
			}
			Vector3Int entrancePos = GridUtils.RotatePoint(relativeCraneEntrancePos, degrees);
			Vector3Int pickupPos = GridUtils.RotatePoint(relativeCranePos, degrees);
			entrancePos += cellPosition;
			pickupPos += cellPosition;
			SpawnPreviewCraneView(entrancePos, pickupPos, craneData);
		}
	}

	private void SpawnPreviewCraneView(Vector3Int entrancePos, Vector3Int pickupPos, BuildingCranesBehaviourConfigurationDto.CraneData craneData)
	{
		Vector3 position = pickupPos + Vector3.one * 0.5f;
		BuildingCraneView buildingCraneView = Object.Instantiate(_cranePrefab, position, Quaternion.identity, base.transform);
		buildingCraneView.ShowPreview(entrancePos, pickupPos, craneData);
		buildingCraneView.EntrancePos = entrancePos;
		buildingCraneView.PickupPos = pickupPos;
		_previewCranes.Add(buildingCraneView);
	}

	private void UpdatePreviewCranesValid(bool isValid)
	{
		_previewIsValid = isValid;
		if (isValid)
		{
			foreach (BuildingCraneView previewCrane in _previewCranes)
			{
				bool valid = _placeCraneFromBuildingTool.IsCranePlacementValid(previewCrane.PickupPos, previewCrane.EntrancePos);
				previewCrane.SetValid(valid);
			}
			return;
		}
		foreach (BuildingCraneView previewCrane2 in _previewCranes)
		{
			previewCrane2.SetValid(isValid: false);
		}
	}

	public override void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading)
	{
		base.SetFactoryObject(factoryObject, isGameLoading);
		_initialized = true;
		foreach (BuildingCranesBehaviour.Crane crane in _behaviour.Cranes)
		{
			SpawnCraneView(crane, isGameLoading);
		}
		Subscribe();
	}

	private void Subscribe()
	{
		_behaviour.OnCraneAddedEvent += OnCraneAdded;
		_behaviour.OnCraneRemovedEvent += RemoveCraneView;
	}

	private void UnSubscribe()
	{
		if ((bool)_behaviour)
		{
			_behaviour.OnCraneAddedEvent -= OnCraneAdded;
			_behaviour.OnCraneRemovedEvent -= RemoveCraneView;
		}
		_objectView.ValidPositionChanged -= UpdatePreviewCranesValid;
	}

	protected override void OnDestroy()
	{
		UnSubscribe();
		base.OnDestroy();
	}

	protected override void ResetFactoryObject()
	{
		UnSubscribe();
		RemoveAllCranes();
		RemoveAllPreviewCranes();
		base.ResetFactoryObject();
	}

	private void SpawnCraneView(BuildingCranesBehaviour.Crane crane, bool isGameLoading)
	{
		Vector3 position = crane.PickupPosition + Vector3.one * 0.5f;
		BuildingCraneView buildingCraneView = Object.Instantiate(_cranePrefab, position, Quaternion.identity, base.transform);
		buildingCraneView.SetCrane(crane, _behaviour, isGameLoading);
		_craneViews.Add(crane, buildingCraneView);
	}

	private void OnCraneAdded(BuildingCranesBehaviour.Crane crane)
	{
		SpawnCraneView(crane, isGameLoading: false);
	}

	private void RemoveCraneView(BuildingCranesBehaviour.Crane crane)
	{
		if (_craneViews.ContainsKey(crane))
		{
			_particleSystemPoolLocator.Pool.PlayDestroyBuildingVFX(crane.PickupPosition + Vector3.one * 0.5f, null);
			_craneViews[crane].FactoryObjectView.HoverStopped();
			Object.Destroy(_craneViews[crane].gameObject);
			_craneViews.Remove(crane);
		}
	}

	private void RemoveAllCranes()
	{
		for (int num = _craneViews.Count - 1; num >= 0; num--)
		{
			RemoveCraneView(_craneViews.ElementAt(num).Key);
		}
	}

	private void RemoveAllPreviewCranes()
	{
		for (int num = _previewCranes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(_previewCranes[num].gameObject);
			_previewCranes.RemoveAt(num);
		}
	}

	public void ShowCraneEntrancePreview(Vector3Int pos, Vector3Int dir)
	{
		_craneEntrancePreview.gameObject.SetActive(value: true);
		_craneEntrancePreview.transform.position = pos + Vector3.one * 0.5f;
		_craneEntrancePreview.transform.forward = dir;
		_craneEntrancePos = pos;
		_craneEntranceDir = dir;
	}

	public void ShowCranePreview(Vector3Int pos)
	{
		_cranePreview.gameObject.SetActive(value: true);
		_cranePreview.transform.position = pos + Vector3.one * 0.5f;
		_cranePreview.transform.forward = _craneEntranceDir;
		float num = Vector3.Distance(pos, _craneEntrancePos);
		bool flag = num < 2f;
		_craneRailPreview.gameObject.SetActive(!flag);
		_craneRailPreview.transform.position = (Vector3)(pos - _craneEntrancePos) * 0.5f + _craneEntrancePos + Vector3.one * 0.5f;
		_craneRailPreview.transform.forward = _craneEntranceDir;
		_craneRailPreview.transform.localScale = new Vector3(1f, 1f, num - 1f);
	}

	public void HideCraneEntrancePreview()
	{
		_craneEntrancePreview.SetActive(value: false);
		_cranePreview.SetActive(value: false);
		_craneRailPreview.SetActive(value: false);
	}

	public void SetCranePreviewValid(bool isValid)
	{
		if (isValid)
		{
			_cranePreviewVFXController.SetValidColors();
		}
		else
		{
			_cranePreviewVFXController.SetInvalidColors();
		}
	}

	public void ShowPossibleCraneEntrancePositions()
	{
		HidePossibleCraneEntrancePositions();
		foreach (KeyValuePair<Vector3Int, Vector3Int> possibleCranePosition in _behaviour.PossibleCranePositions)
		{
			GameObject gameObject = Object.Instantiate(_possibleCranePositionVisual, possibleCranePosition.Key + Vector3.one * 0.5f, Quaternion.identity, base.transform);
			_possibleCranePosVisuals.Add(gameObject);
			gameObject.transform.forward = possibleCranePosition.Value;
			if (_buildingBehaviour.BuildingLandingPad.Exists && possibleCranePosition.Key == _buildingBehaviour.BuildingLandingPad.Position)
			{
				gameObject.transform.position += (Vector3)possibleCranePosition.Value * 0.4f;
			}
		}
	}

	public void HidePossibleCraneEntrancePositions()
	{
		for (int num = _possibleCranePosVisuals.Count - 1; num >= 0; num--)
		{
			Object.Destroy(_possibleCranePosVisuals[num]);
		}
		_possibleCranePosVisuals.Clear();
	}

	private void OnDrawGizmos()
	{
		if (!_initialized)
		{
			return;
		}
		Gizmos.color = Color.blue;
		foreach (KeyValuePair<Vector3Int, Vector3Int> possibleCranePosition in _behaviour.PossibleCranePositions)
		{
			Vector3 vector = possibleCranePosition.Key + Vector3.one * 0.5f + Vector3.up;
			Gizmos.DrawSphere(vector, 0.25f);
			Gizmos.DrawLine(vector, vector + possibleCranePosition.Value);
		}
	}
}
