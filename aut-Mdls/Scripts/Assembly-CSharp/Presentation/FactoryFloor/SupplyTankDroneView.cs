using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.Resources;
using Data.Variables;
using FMOD.Studio;
using FMODUnity;
using Logic.Factory;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class SupplyTankDroneView : MonoBehaviour
	{
		[SerializeField]
		private IntVariableSO _factoryStepsPerSecond;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private Vector3 _droneOffset;

		[SerializeField]
		private SupplyTankCapsuleView _capsuleView;

		[SerializeField]
		private Transform _rotationPivot;

		[SerializeField]
		private float _tiltAmount = 15f;

		[SerializeField]
		private float _tiltSpeed = 3f;

		[SerializeField]
		private float _timeToRotatePerDegree = 0.0125f;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EventReference _dropResourceSFX;

		[SerializeField]
		private EventReference _loopSFX;

		private SupplyTankDroneBehaviour _droneBehaviour;

		private SupplyTankView _supplyTankView;

		private SupplyTankDroneBehaviour.SupplyTankDroneState _state;

		private Vector3 _startPos;

		private Vector3 _endPos;

		private Quaternion _recipientRotation = Quaternion.identity;

		private float _spawnTime;

		private float _timeToTransferItems;

		private Quaternion _moveToEndRot;

		private Quaternion _moveToStartRot;

		private Quaternion _supplyTankRotation;

		private Coroutine _rotationCoroutine;

		private bool _isRotating;

		private bool _startedRotatingToEndRot;

		private EventInstance _loopingSFXInstance;

		public event Action<ResourceDataSO, int> OnReceivedResources = delegate
		{
		};

		public event Action OnDeliveredResources = delegate
		{
		};

		public void Init(SupplyTankDroneBehaviour droneBehaviour, SupplyTankView supplyTankView, Vector3 startPos, Vector3 endPos)
		{
			_droneBehaviour = droneBehaviour;
			_supplyTankView = supplyTankView;
			_startPos = startPos;
			_endPos = endPos;
			_supplyTankRotation = _supplyTankView.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
			_recipientRotation = Quaternion.identity;
			_spawnTime = (float)_droneBehaviour.StepsToSpawn / (float)_factoryStepsPerSecond.Value;
			_timeToTransferItems = (float)_droneBehaviour.StepsToTransferItems / (float)_factoryStepsPerSecond.Value;
			Vector3 normalized = (_endPos - _startPos).normalized;
			normalized.y = 0f;
			_moveToEndRot = Quaternion.LookRotation(normalized, Vector3.up);
			_moveToStartRot = Quaternion.LookRotation(-normalized, Vector3.up);
			base.transform.position = _droneBehaviour.Position + _droneOffset;
			_droneBehaviour.OnDestroyDrone.RegisterMainThread(DestroyDroneView);
			_droneBehaviour.OnChangeState.RegisterMainThread(ChangeDroneViewState);
			_droneBehaviour.OnResourcesAdded.RegisterMainThread(ResourcesAdded);
			ChangeDroneViewState(_droneBehaviour.GetState(), instant: true);
		}

		private void DestroyDroneView()
		{
			_droneBehaviour.OnDestroyDrone.UnRegisterMainThread(DestroyDroneView);
			_droneBehaviour.OnChangeState.UnRegisterMainThread(ChangeDroneViewState);
			_droneBehaviour.OnResourcesAdded.UnRegisterMainThread(ResourcesAdded);
			_supplyTankView.DestroyDroneView(this, _droneBehaviour);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void OnDestroy()
		{
			StopLoopSFX();
		}

		private void ChangeDroneViewState(SupplyTankDroneBehaviour.SupplyTankDroneState state)
		{
			ChangeDroneViewState(state, instant: false);
		}

		private void ChangeDroneViewState(SupplyTankDroneBehaviour.SupplyTankDroneState state, bool instant)
		{
			_state = state;
			if (_globalUpdateMultiplier.Value <= 0 && !instant)
			{
				return;
			}
			_startedRotatingToEndRot = false;
			base.transform.DOKill();
			base.transform.localScale = Vector3.one;
			switch (_state)
			{
			case SupplyTankDroneBehaviour.SupplyTankDroneState.Spawning:
				base.transform.position = _droneBehaviour.Position + _droneOffset;
				base.transform.localScale = (instant ? Vector3.one : Vector3.zero);
				if (!instant)
				{
					base.transform.DOScale(Vector3.one, _spawnTime / (float)_globalUpdateMultiplier.Value).SetEase(Ease.OutQuad);
				}
				RotateDrone(_supplyTankRotation, _spawnTime / (float)_globalUpdateMultiplier.Value, instant);
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.MovingToRecipient:
				_capsuleView.gameObject.SetActive(value: true);
				UpdateDronePos();
				RotateDrone(_moveToStartRot, _timeToRotatePerDegree);
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.MovingToSupplyTank:
				_capsuleView.gameObject.SetActive(value: false);
				UpdateDronePos();
				RotateDrone(_moveToEndRot, _timeToRotatePerDegree);
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.WaitingForPickUpResources:
				UpdateDronePos();
				RotateDrone(_supplyTankRotation, _timeToTransferItems * 0.5f / (float)_globalUpdateMultiplier.Value, instant);
				UpdateLoopSFX(0f);
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.WaitingToDropResources:
				_capsuleView.gameObject.SetActive(value: true);
				UpdateDronePos();
				RotateDrone(_recipientRotation, _timeToTransferItems * 0.5f / (float)_globalUpdateMultiplier.Value, instant);
				UpdateLoopSFX(0f);
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.DroppingResources:
				DropResources();
				UpdateDronePos();
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.PickUpResources:
				break;
			}
		}

		private void RotateDrone(Quaternion targetRot, float duration, bool instantRotation)
		{
			if (instantRotation)
			{
				base.transform.rotation = targetRot;
				return;
			}
			if (_isRotating)
			{
				StopCoroutine(_rotationCoroutine);
			}
			_rotationCoroutine = StartCoroutine(IRotateDrone(targetRot, duration));
		}

		private void RotateDrone(Quaternion targetRot, float timePerRotationDegree)
		{
			float num = Quaternion.Angle(base.transform.rotation, targetRot);
			if (_isRotating)
			{
				StopCoroutine(_rotationCoroutine);
			}
			_rotationCoroutine = StartCoroutine(IRotateDrone(targetRot, num * timePerRotationDegree));
		}

		private IEnumerator IRotateDrone(Quaternion targetRot, float duration)
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
			switch (_state)
			{
			case SupplyTankDroneBehaviour.SupplyTankDroneState.MovingToRecipient:
				UpdateDronePos();
				UpdateLoopSFX(_droneBehaviour.CurrentSpeed01);
				StartRotatingToEndRotation(_recipientRotation);
				break;
			case SupplyTankDroneBehaviour.SupplyTankDroneState.MovingToSupplyTank:
				UpdateDronePos();
				UpdateLoopSFX(_droneBehaviour.CurrentSpeed01);
				StartRotatingToEndRotation(_supplyTankRotation);
				break;
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
				base.transform.position = Vector3.Lerp(position, nextProcessPosition, _droneBehaviour.IslandObject.GetDeltaTimePerc(Time.time)) + _droneOffset;
			}
		}

		private void UpdateDroneTilt()
		{
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

		private void ResourcesAdded(IReadOnlyDictionary<ResourceDataSO, int> resources)
		{
			foreach (KeyValuePair<ResourceDataSO, int> resource in resources)
			{
				_capsuleView.SetLiquidToResource(resource.Key);
				_capsuleView.SetLiquidFillPercentage(1f);
				this.OnReceivedResources(resource.Key, resource.Value);
			}
			_capsuleView.gameObject.SetActive(value: true);
		}

		private void DropResources()
		{
			this.OnDeliveredResources();
			_capsuleView.gameObject.SetActive(value: false);
			_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_dropResourceSFX, base.transform.position);
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
	}
}
