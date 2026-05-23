using System;
using System.Collections.Generic;
using Commands;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Resources;
using Data.Variables;
using Events;
using Presentation.FactoryFloor;
using Presentation.Locators;
using SaveData.FactoryFloor;
using UnityEngine;

public class BuildingCraneView : MonoBehaviour, IDeleteToolBehaviour, IHeatmapView
{
	[SerializeField]
	private FactoryObjectView _factoryObjectView;

	[SerializeField]
	private HologramVFXController _hologramVFXController;

	[SerializeField]
	private BoxCollider _railsCollider;

	[SerializeField]
	private BoxCollider _entranceCollider;

	[SerializeField]
	private Transform _itemPickupTransform;

	[SerializeField]
	private FactoryObjectViewCullingController _cullingController;

	[SerializeField]
	private List<CallFakeAnimOnMaterial> _craneFakeAnims = new List<CallFakeAnimOnMaterial>();

	[SerializeField]
	private IntVariableSO _globalSpeedMultiplier;

	[SerializeField]
	private float _craneGoingDownTime = 0.2f;

	[SerializeField]
	private List<GameObject> _craneEntrance;

	[SerializeField]
	private List<GameObject> _crane;

	[SerializeField]
	private List<GameObject> _craneRail;

	[SerializeField]
	private AudioManagerLocator _audioManagerLocator;

	[SerializeField]
	private BaseEvent _onPlacedCrane;

	private bool _initialized;

	private BuildingCranesBehaviour.Crane _craneData;

	private BuildingCranesBehaviour _buildingCranesBehaviour;

	private ResourceJobContainer _resourceJobContainer;

	private ConveyorView _conveyorView;

	private Vector3 _itemPickupPosition;

	private bool _hasConveyorBehaviour;

	private static readonly int CraneDistance = Shader.PropertyToID("_craneDistance");

	private static readonly int DownAnimationTime = Shader.PropertyToID("_downAnimationTime");

	public FactoryObjectView FactoryObjectView => _factoryObjectView;

	public BuildingCranesBehaviourConfigurationDto.CraneData CraneData { get; private set; }

	public Vector3Int EntrancePos { get; set; }

	public Vector3Int PickupPos { get; set; }

	public event Action OnInit;

	public void SetCrane(BuildingCranesBehaviour.Crane crane, BuildingCranesBehaviour behaviour, bool isGameLoading)
	{
		_craneData = crane;
		_buildingCranesBehaviour = behaviour;
		_itemPickupPosition = _itemPickupTransform.position;
		SetCranePositions(crane.Position, crane.PickupPosition);
		if (isGameLoading)
		{
			_hologramVFXController.ShowNormalVersion();
		}
		else
		{
			_hologramVFXController.AnimateToNormalVersion();
		}
		_craneData.Behaviour.OnTakeResource.RegisterMainThread(HandleTakeResourceAnimation);
		_craneData.Behaviour.OnConveyorFound.RegisterMainThread(ConveyorFound);
		_craneData.Behaviour.OnConveyorRemoved.RegisterMainThread(ConveyorRemoved);
		_initialized = true;
		_cullingController.SetCullingFactoryObject(behaviour.FactoryObject);
		this.OnInit?.Invoke();
		_craneData.Behaviour.OnActivityStart.RegisterMainThread(OnActivityStart);
	}

	private void OnDestroy()
	{
		if (_initialized)
		{
			if (_craneData.Behaviour != null)
			{
				_craneData.Behaviour.OnActivityStart.UnRegisterMainThread(OnActivityStart);
			}
			_craneData.Behaviour.OnTakeResource.UnRegisterMainThread(HandleTakeResourceAnimation);
			_craneData.Behaviour.OnConveyorFound.UnRegisterMainThread(ConveyorFound);
			_craneData.Behaviour.OnConveyorRemoved.UnRegisterMainThread(ConveyorRemoved);
			_hasConveyorBehaviour = false;
			_resourceJobContainer?.Dispose();
		}
	}

	private void ConveyorFound(ConveyorBehaviour conveyorBehaviour)
	{
		if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(conveyorBehaviour.FactoryObject.CreatedId, out var view) && view.TryGetComponent<ConveyorView>(out var component))
		{
			_conveyorView = component;
			_hasConveyorBehaviour = true;
		}
	}

	private void ConveyorRemoved()
	{
		_conveyorView = null;
		_hasConveyorBehaviour = false;
	}

	private void OnActivityStart()
	{
		_audioManagerLocator.AudioManager.PlayCrane(base.transform.position);
	}

	private void AnimateResourceOut(ResourceView resourceView, Vector3 resourceStartPos, float speedMultiplier)
	{
		if (_resourceJobContainer == null)
		{
			_resourceJobContainer = new ResourceJobContainer(resourceStartPos, _itemPickupPosition, ResourceJobContainer.ScalingMode.NoScaling, returnResourceToPoolAfter: true, _cullingController);
		}
		_resourceJobContainer.SetSpeedMultiplier(speedMultiplier);
		_resourceJobContainer.SetStartPosition(resourceStartPos);
		_resourceJobContainer.PlayAnimation(resourceView);
	}

	private void SetCranePositions(Vector3Int entrancePos, Vector3Int pickupPos)
	{
		Vector3 forward = Vector3.Normalize(pickupPos - entrancePos);
		base.transform.forward = forward;
		foreach (GameObject item in _craneEntrance)
		{
			item.transform.position = entrancePos + Vector3.one * 0.5f;
		}
		_entranceCollider.center = _craneEntrance[0].transform.localPosition + new Vector3(0f, 1f, 0.1f);
		float num = Vector3.Distance(pickupPos, entrancePos);
		foreach (CallFakeAnimOnMaterial craneFakeAnim in _craneFakeAnims)
		{
			craneFakeAnim.SetCustomAttribute(num, CraneDistance);
			craneFakeAnim.SetCustomAttribute(_craneGoingDownTime, DownAnimationTime);
		}
		bool flag = num < 2f;
		Vector3 vector = (Vector3)(pickupPos - entrancePos) * 0.5f + entrancePos;
		foreach (GameObject item2 in _craneRail)
		{
			item2.SetActive(!flag);
			item2.transform.position = vector + Vector3.one * 0.5f;
			item2.transform.localScale = new Vector3(1f, 1f, num - 1f);
		}
		_railsCollider.center = _craneRail[0].transform.localPosition + new Vector3(0f, 1.275f, 0f);
		_railsCollider.size = new Vector3(_railsCollider.size.x, _railsCollider.size.y, num - 1f);
	}

	private void HandleTakeResourceAnimation(Resource resource, int stepsToComeBack)
	{
		if (!_hasConveyorBehaviour)
		{
			return;
		}
		Vector3 position = _conveyorView.ResourceView.transform.position;
		float timeLeftInAnimation = _conveyorView.TimeLeftInAnimation;
		float num = _craneGoingDownTime / (float)_globalSpeedMultiplier.Value;
		AnimateResourceOut(_conveyorView.ResourceView, position, 1f / Mathf.Max(timeLeftInAnimation, num));
		float delay = ((timeLeftInAnimation > num) ? (timeLeftInAnimation - num) : 0f);
		foreach (CallFakeAnimOnMaterial craneFakeAnim in _craneFakeAnims)
		{
			craneFakeAnim.PlayAnimation(delay);
		}
	}

	public void ShowPreview(Vector3Int entrancePos, Vector3Int pickupPos, BuildingCranesBehaviourConfigurationDto.CraneData craneData)
	{
		CraneData = craneData;
		SetCranePositions(entrancePos, pickupPos);
		_hologramVFXController.ShowHologramVersion();
	}

	public void SetValid(bool isValid)
	{
		if (isValid)
		{
			_hologramVFXController.SetValidColors();
		}
		else
		{
			_hologramVFXController.SetInvalidColors();
		}
	}

	public ICommandUndo GetCommand()
	{
		return new PlaceCraneFromBuildingCommand(delete: true, _onPlacedCrane, _buildingCranesBehaviour, _audioManagerLocator, _craneData.PickupPosition, _craneData.Position);
	}

	public ITrackActivity GetTrackActivity()
	{
		return _craneData.Behaviour;
	}
}
