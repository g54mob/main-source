using System;
using System.Collections;
using DG.Tweening;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Drones;
using Data.Variables;
using FMOD.Studio;
using FMODUnity;
using Logic.Factory;
using Presentation.Buildings;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class HarvesterPadDroneView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _fullDrone;

		[SerializeField]
		private GameObject _fullDroneSupportersEdition;

		[SerializeField]
		private CrateView _crateView;

		[SerializeField]
		private GameObject _normalParent;

		[SerializeField]
		private GameObject _deluxeEditionParent;

		[SerializeField]
		private TrailRenderer[] _trails;

		[Space]
		[SerializeField]
		private BoolVariableSO _hasDeluxeEditionSO;

		[SerializeField]
		private BoolVariableSO _showDeluxeEditionDronesSO;

		[SerializeField]
		private IntVariableSO _factoryStepsPerSecond;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private float _landingPadForwardOffset = -0.4f;

		[SerializeField]
		private Transform _rotationPivot;

		[SerializeField]
		private float _timeToRotatePerDegree = 0.0125f;

		[SerializeField]
		private HarvesterPadDroneViewPool _harvesterPadDroneViewPool;

		[Header("Ease")]
		[SerializeField]
		private Ease _spawnOutOfLandingPadEase = Ease.OutSine;

		[SerializeField]
		private Ease _dropToHarvestorPadEase = Ease.InQuad;

		[SerializeField]
		private Ease _enterHarvestorPadEase = Ease.InQuad;

		[Header("Tilt")]
		[SerializeField]
		private float _tiltAmount = 15f;

		[SerializeField]
		private float _tiltSpeed = 3f;

		[SerializeField]
		private float _tiltDisabledSpeed = 15f;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EventReference _loopSFX;

		private HarvestPadDroneBehaviour _droneBehaviour;

		private HarvesterPadView _harvesterPadView;

		private BuildingLandingPadView _landingPadView;

		private bool _hasLandingPadView;

		private HarvestPadDroneBehaviour.HarvestPadDroneState _state;

		private EventInstance _loopingSFXInstance;

		private Vector3 _dropOffPos;

		private Vector3 _pickUpPos;

		private float _secondsToSpawn;

		private float _secondsToEnterHarvestorPad;

		private float _secondsOnHarvestorPad;

		private float _secondsToDropToHarvestorPadPerHeight;

		private Quaternion _moveToHarvesterPadRot;

		private Coroutine _rotationCoroutine;

		private bool _isRotating;

		private bool _startedRotatingToEndRot;

		private int _buildingFamilyID;

		private BuildingCategoryType _buildingCategoryType;

		private Vector3 _dronePickupOffset;

		private bool _disableTilt;

		public HarvestPadDroneBehaviour DroneBehaviour => _droneBehaviour;

		public event Action<HarvesterPadDroneView, float, float, Ease> OnDeliveredResources = delegate
		{
		};

		public void Init(HarvestPadDroneBehaviour droneBehaviour, HarvesterPadView harvesterPadView, Vector3 droneDropOffPos, Vector3 dronePickUpOffset)
		{
			_state = HarvestPadDroneBehaviour.HarvestPadDroneState.Hidden;
			_droneBehaviour = droneBehaviour;
			_harvesterPadView = harvesterPadView;
			_dronePickupOffset = dronePickUpOffset;
			_dropOffPos = droneDropOffPos + new Vector3(-0.5f, 0f, 0.5f);
			_pickUpPos = droneBehaviour.BuildingBehaviour.BuildingLandingPad.Position + _dronePickupOffset;
			_secondsToSpawn = (float)_droneBehaviour.StepsToSpawn / (float)_factoryStepsPerSecond.Value;
			_secondsToEnterHarvestorPad = (float)_droneBehaviour.StepsToEnterHarvestorPad / (float)_factoryStepsPerSecond.Value;
			_secondsOnHarvestorPad = (float)_droneBehaviour.StepsOnHarvestorPad / (float)_factoryStepsPerSecond.Value;
			_secondsToDropToHarvestorPadPerHeight = (float)_droneBehaviour.StepsToDropToHarvestorPadPerHeight / (float)_factoryStepsPerSecond.Value;
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(droneBehaviour.BuildingBehaviour.FactoryObject.CreatedId, out var view))
			{
				TrySetLandingPad(view);
			}
			else
			{
				FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated += ViewCreated;
			}
			_buildingFamilyID = droneBehaviour.BuildingBehaviour.BuildingObjectData.FamilyID;
			_buildingCategoryType = droneBehaviour.BuildingBehaviour.BuildingObjectData.CategoryType;
			_crateView.SetBuilding(_buildingFamilyID, _buildingCategoryType);
			UpdateDroneTargetRotations(instant: true);
			_droneBehaviour.OnDestroyDrone.RegisterMainThread(ReturnToPool);
			_droneBehaviour.OnChangeState.RegisterMainThread(ChangeDroneViewState);
			_droneBehaviour.OnHeightIndexChanged.RegisterMainThread(OnHeightIndexChanged);
			ChangeDeluxeState(_showDeluxeEditionDronesSO.Value);
			_showDeluxeEditionDronesSO.ValueChanged += ChangeDeluxeState;
			base.transform.position = _droneBehaviour.Position;
			ChangeDroneViewState(_droneBehaviour.State, instant: true);
			TrailRenderer[] trails = _trails;
			for (int i = 0; i < trails.Length; i++)
			{
				trails[i].Clear();
			}
		}

		public void UnInit()
		{
			_droneBehaviour.OnDestroyDrone.UnRegisterMainThread(ReturnToPool);
			_droneBehaviour.OnChangeState.UnRegisterMainThread(ChangeDroneViewState);
			_droneBehaviour.OnHeightIndexChanged.UnRegisterMainThread(OnHeightIndexChanged);
			FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated -= ViewCreated;
			_showDeluxeEditionDronesSO.ValueChanged -= ChangeDeluxeState;
			_harvesterPadView.DestroyDroneView(this);
			_state = HarvestPadDroneBehaviour.HarvestPadDroneState.Hidden;
			StopLoopSFX();
		}

		private void ViewCreated(FactoryObjectView factoryObjectView, FactoryObject factoryObject)
		{
			if (factoryObject.CreatedId == _droneBehaviour.BuildingBehaviour.FactoryObject.CreatedId)
			{
				TrySetLandingPad(factoryObjectView);
				FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated -= ViewCreated;
			}
		}

		private void TrySetLandingPad(FactoryObjectView buildingView)
		{
			if (!buildingView.TryGetComponent<BuildingLandingPadView>(out _landingPadView))
			{
				_hasLandingPadView = false;
			}
			else if (!_landingPadView.BuildingLandingPad.Exists)
			{
				_hasLandingPadView = false;
				_landingPadView.BuildingLandingPad.OnLandingPadGenerated += SetLandingPad;
			}
			else
			{
				SetLandingPad(_landingPadView);
			}
		}

		private void SetLandingPad(Vector3Int landingPadPos)
		{
			SetLandingPad(_landingPadView);
			_landingPadView.BuildingLandingPad.OnLandingPadGenerated -= SetLandingPad;
		}

		private void SetLandingPad(BuildingLandingPadView landingPadView)
		{
			_landingPadView = landingPadView;
			_hasLandingPadView = true;
			_pickUpPos = _droneBehaviour.BuildingBehaviour.BuildingLandingPad.Position + _dronePickupOffset;
			_pickUpPos += landingPadView.LandingPadForward * _landingPadForwardOffset;
			UpdateDroneTargetRotations(instant: true);
		}

		private void UpdateDroneTargetRotations(bool instant)
		{
			Vector3 vector = _pickUpPos - _dropOffPos;
			vector.y = 0f;
			_moveToHarvesterPadRot = Quaternion.LookRotation(-vector, Vector3.up);
			ChangeDroneViewState(_droneBehaviour.State, instant);
		}

		public void ReturnToPool()
		{
			_harvesterPadDroneViewPool.ReturnToPool(this);
		}

		private void OnDestroy()
		{
			UnInit();
			_harvesterPadDroneViewPool.RemoveFromPool(this);
		}

		private void ChangeDroneViewState(HarvestPadDroneBehaviour.HarvestPadDroneState state)
		{
			ChangeDroneViewState(state, instant: false);
		}

		private void ChangeDroneViewState(HarvestPadDroneBehaviour.HarvestPadDroneState state, bool instant)
		{
			_state = state;
			if (_globalUpdateMultiplier.Value > 0 || instant)
			{
				_startedRotatingToEndRot = false;
				base.transform.DOKill();
				base.transform.localScale = Vector3.one;
				switch (_state)
				{
				case HarvestPadDroneBehaviour.HarvestPadDroneState.Spawning:
					_disableTilt = true;
					AnimateOutOfLandingPad();
					break;
				case HarvestPadDroneBehaviour.HarvestPadDroneState.MovingToHarvesterPad:
					_disableTilt = false;
					RotateDrone(_moveToHarvesterPadRot, _secondsToSpawn, instant);
					UpdateLoopSFX(1f);
					UpdateDronePos();
					break;
				case HarvestPadDroneBehaviour.HarvestPadDroneState.WaitingToDropResources:
				{
					_disableTilt = true;
					_audioManagerLocator.AudioManager.PlayDroneLand(base.transform.position);
					UpdateDronePos();
					float duration = _secondsToEnterHarvestorPad * _droneBehaviour.EnterHarvesterPadTimeScalar() * 0.5f / (float)_globalUpdateMultiplier.Value;
					RotateDrone(_harvesterPadView.transform.rotation, duration, instant);
					UpdateLoopSFX(0f);
					break;
				}
				case HarvestPadDroneBehaviour.HarvestPadDroneState.DroppingResources:
					_disableTilt = true;
					AnimateToDropResources();
					break;
				}
			}
		}

		private void OnHeightIndexChanged(int previousHeightIndex, int heightIndex)
		{
			if (_state == HarvestPadDroneBehaviour.HarvestPadDroneState.WaitingToDropResources)
			{
				float duration = _secondsToDropToHarvestorPadPerHeight * _droneBehaviour.EnterHarvesterPadTimeScalar() / (float)_globalUpdateMultiplier.Value;
				base.transform.DOKill();
				Vector3 endValue = _droneBehaviour.EndPos + _droneBehaviour.DroneHeights.HeightOffsetPerDrone * (float)Mathf.Max(0, heightIndex) * Vector3.up;
				base.transform.DOMove(endValue, duration).SetEase(_dropToHarvestorPadEase);
			}
		}

		private void RotateDrone(Quaternion targetRot, float duration, bool instantRotation)
		{
			if (_isRotating)
			{
				StopCoroutine(_rotationCoroutine);
				_isRotating = false;
			}
			if (instantRotation)
			{
				base.transform.rotation = targetRot;
			}
			else
			{
				_rotationCoroutine = StartCoroutine(RotateDroneRoutine(targetRot, duration));
			}
		}

		private void RotateDrone(Quaternion targetRot, float timePerRotationDegree)
		{
			float num = Quaternion.Angle(base.transform.rotation, targetRot);
			if (_isRotating)
			{
				StopCoroutine(_rotationCoroutine);
			}
			_rotationCoroutine = StartCoroutine(RotateDroneRoutine(targetRot, num * timePerRotationDegree));
		}

		private IEnumerator RotateDroneRoutine(Quaternion targetRot, float duration)
		{
			_isRotating = true;
			Quaternion startRot = base.transform.rotation;
			for (float i = 0f; i < duration; i += Time.deltaTime)
			{
				float time = i / duration;
				base.transform.rotation = Quaternion.Slerp(startRot, targetRot, MathUtils.EaseInOutCubic(time));
				yield return null;
			}
			base.transform.rotation = targetRot;
			_isRotating = false;
		}

		private void Update()
		{
			if (_state == HarvestPadDroneBehaviour.HarvestPadDroneState.MovingToHarvesterPad)
			{
				UpdateDronePos();
				UpdateLoopSFX(_droneBehaviour.CurrentSpeed01);
				StartRotatingToEndRotation(_harvesterPadView.transform.rotation);
			}
			UpdateDroneTilt();
		}

		private void StartRotatingToEndRotation(Quaternion endRot)
		{
			if (!_startedRotatingToEndRot)
			{
				float num = Quaternion.Angle(base.transform.rotation, endRot) * _timeToRotatePerDegree;
				if ((float)_droneBehaviour.StepsUntilEnd <= (float)FactoryUpdater.Instance.GetStepsPerSecond() * num)
				{
					_startedRotatingToEndRot = true;
					RotateDrone(endRot, _timeToRotatePerDegree);
				}
			}
		}

		private void UpdateDronePos()
		{
			if (FactoryUpdater.Instance.GetStepsPerSecond() > 0)
			{
				Vector3 position = _droneBehaviour.Position;
				Vector3 nextProcessPosition = _droneBehaviour.GetNextProcessPosition();
				base.transform.position = Vector3.Lerp(position, nextProcessPosition, _droneBehaviour.IslandObject.GetDeltaTimePerc(Time.time));
			}
		}

		private void UpdateDroneTilt()
		{
			if (_disableTilt)
			{
				_rotationPivot.localRotation = Quaternion.Slerp(_rotationPivot.localRotation, Quaternion.identity, Time.deltaTime * _tiltDisabledSpeed);
				return;
			}
			Quaternion rotation = _rotationPivot.rotation;
			Quaternion rotation2 = ((_droneBehaviour.CurrentVelocity != Vector3.zero) ? Quaternion.LookRotation(_droneBehaviour.CurrentVelocity) : _rotationPivot.rotation);
			_rotationPivot.rotation = rotation2;
			Vector3 right = _rotationPivot.right;
			_rotationPivot.localRotation = Quaternion.identity;
			float num = Mathf.Clamp01(_droneBehaviour.CurrentVelocity.magnitude / _droneBehaviour.DroneMaxVelocityData.DefaultValue);
			_rotationPivot.Rotate(right, (0f - _tiltAmount) * num, Space.World);
			Quaternion rotation3 = _rotationPivot.rotation;
			_rotationPivot.rotation = rotation;
			_rotationPivot.rotation = Quaternion.Slerp(_rotationPivot.rotation, rotation3, Time.deltaTime * _tiltSpeed);
		}

		private void AnimateOutOfLandingPad()
		{
			if (_hasLandingPadView)
			{
				_audioManagerLocator.AudioManager.PlayDronePickup(base.transform.position);
				base.transform.position = _droneBehaviour.Position + (_landingPadView.BottomDroneLandingPlatformPosition - _landingPadView.TopDroneLandingPlatformPosition);
				base.transform.localScale = Vector3.zero;
				Quaternion targetRot = Quaternion.Euler(0f, Mathf.Round(_moveToHarvesterPadRot.eulerAngles.y / 90f) * 90f, 0f);
				RotateDrone(targetRot, 0f, instantRotation: true);
				float num = _secondsToSpawn / (float)_globalUpdateMultiplier.Value;
				_landingPadView.LiftPlatform(num, _spawnOutOfLandingPadEase);
				base.transform.DOScale(Vector3.one, num).SetEase(_spawnOutOfLandingPadEase);
				base.transform.DOMove(_droneBehaviour.Position, num).SetEase(_spawnOutOfLandingPadEase);
			}
		}

		private void AnimateToDropResources()
		{
			_audioManagerLocator.AudioManager.PlayDroneDropOff(base.transform.position);
			if (_globalUpdateMultiplier.Value != 0)
			{
				Vector3 vector = base.transform.position - _harvesterPadView.TopDroneLandingPlatformPosition;
				float num = _droneBehaviour.EnterHarvesterPadTimeScalar();
				float num2 = _secondsToEnterHarvestorPad / (float)_globalUpdateMultiplier.Value * num;
				float num3 = _secondsOnHarvestorPad / (float)_globalUpdateMultiplier.Value * num;
				this.OnDeliveredResources(this, num2, num3, _enterHarvestorPadEase);
				base.transform.DOScale(Vector3.zero, num2).SetDelay(num3).SetEase(_enterHarvestorPadEase);
				base.transform.DOMove(_harvesterPadView.BottomDroneLandingPlatformPosition + vector, num2).SetDelay(num3).SetEase(_enterHarvestorPadEase)
					.OnComplete(delegate
					{
						base.gameObject.SetActive(value: false);
					});
			}
		}

		private void UpdateLoopSFX(float speed)
		{
			if (_loopingSFXInstance.isValid())
			{
				_audioManagerLocator.AudioManager.SetDroneFlyingSpeed(_loopingSFXInstance, speed);
			}
			else
			{
				_loopingSFXInstance = _audioManagerLocator.AudioManager.PlayDroneFlyingWithSpeed(_loopSFX, base.gameObject, speed);
			}
		}

		private void StopLoopSFX()
		{
			if (_loopingSFXInstance.isValid())
			{
				_audioManagerLocator.AudioManager.StopPlayDroneFly(ref _loopingSFXInstance);
			}
		}

		private void ChangeDeluxeState(bool showDeluxeEdition)
		{
			ShowDroneFullState();
		}

		private void ShowDroneFullState()
		{
			bool flag = _showDeluxeEditionDronesSO.Value && _hasDeluxeEditionSO.Value;
			_normalParent.SetActive(!flag);
			_deluxeEditionParent.SetActive(flag);
			_fullDrone.SetActive(!flag);
			_fullDroneSupportersEdition.SetActive(flag);
		}
	}
}
