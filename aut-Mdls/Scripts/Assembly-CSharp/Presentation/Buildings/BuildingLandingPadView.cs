using System;
using DG.Tweening;
using Data.Buildings;
using Data.FactoryFloor.Buildings;
using Data.Variables;
using Presentation.FactoryFloor;
using UnityEngine;

namespace Presentation.Buildings
{
	public class BuildingLandingPadView : FactoryResourceHolderView<BuildingBehaviour>
	{
		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private GameObject _landingPadPrefab;

		[SerializeField]
		private float _droneLandingPlatformOffset;

		[SerializeField]
		private BoolVariableSO _isLoadingSave;

		[SerializeField]
		private FactoryObjectViewCullingController _factoryObjectViewCullingController;

		private bool _initialized;

		private BuildingCranesBehaviour _buildingCranesBehaviour;

		private BuildingLandingPad _buildingLandingPad;

		private bool _hasLandingPadView;

		private GameObject _landingPadView;

		private Vector3Int _landingPadPos;

		private BuildingLandingPadModelSwitcher _landingPadModelSwitcher;

		private BuildingLandingPadCulling _landingPadCulling;

		private Vector3 _topDroneLandingPlatformPosition;

		private Vector3 _bottomDroneLandingPlatformPosition;

		private Transform _droneLandingPlatform;

		private HologramVFXController _landingPadPreview;

		private bool _isShowingPreview;

		public BuildingLandingPad BuildingLandingPad => _buildingLandingPad;

		public Vector3 LandingPadForward => _landingPadView.transform.forward;

		public Vector3 TopDroneLandingPlatformPosition => _topDroneLandingPlatformPosition;

		public Vector3 BottomDroneLandingPlatformPosition => _bottomDroneLandingPlatformPosition;

		public event Action<bool> OnProductionReadyStateChanged = delegate
		{
		};

		protected override void Init()
		{
			base.Init();
			_buildingLandingPad = _behaviour.BuildingLandingPad;
			_buildingCranesBehaviour = _behaviour.FactoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>();
			_buildingLandingPad.OnLandingPadGenerated += GenerateLandingPadView;
			_buildingLandingPad.OnLandingPadDestroyed.RegisterMainThread(DestroyLandingPadView);
			_buildingLandingPad.OnShowLandingPadPreview.RegisterMainThread(ShowLandingPadPreview);
			_buildingLandingPad.OnHideLandingPadPreview.RegisterMainThread(DestroyLandingPadPreview);
			_buildingCranesBehaviour.OnCraneAddedEvent += AddedCrane;
			_buildingCranesBehaviour.OnCraneRemovedEvent += RemovedCrane;
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			HandleCullState(_factoryObjectViewCullingController.CurrentState);
			if (_behaviour.BuildingLandingPad.Exists)
			{
				GenerateLandingPadView(_behaviour.BuildingLandingPad.Position);
			}
			_initialized = true;
		}

		protected override void ResetFactoryObject()
		{
			base.ResetFactoryObject();
			DestroyLandingPadPreview();
			DestroyLandingPadView();
			if (_initialized)
			{
				_buildingLandingPad.OnLandingPadGenerated -= GenerateLandingPadView;
				_buildingLandingPad.OnLandingPadDestroyed.UnRegisterMainThread(DestroyLandingPadView);
				_buildingLandingPad.OnShowLandingPadPreview.UnRegisterMainThread(ShowLandingPadPreview);
				_buildingLandingPad.OnHideLandingPadPreview.UnRegisterMainThread(DestroyLandingPadPreview);
				_buildingCranesBehaviour.OnCraneAddedEvent -= AddedCrane;
				_buildingCranesBehaviour.OnCraneRemovedEvent -= RemovedCrane;
				FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
				factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			}
		}

		private void RemovedCrane(BuildingCranesBehaviour.Crane crane)
		{
			if (_hasLandingPadView)
			{
				UpdateModelBasedOnCranes(_landingPadModelSwitcher, _landingPadPos);
			}
		}

		private void AddedCrane(BuildingCranesBehaviour.Crane crane)
		{
			if (_hasLandingPadView)
			{
				UpdateModelBasedOnCranes(_landingPadModelSwitcher, _landingPadPos);
			}
		}

		public void ShowWithCraneModel()
		{
			if (_hasLandingPadView)
			{
				_landingPadModelSwitcher.SwitchToWithCrane();
			}
		}

		private void GenerateLandingPadView(Vector3Int position)
		{
			if (_hasLandingPadView)
			{
				DestroyLandingPadView();
			}
			_landingPadView = UnityEngine.Object.Instantiate(_landingPadPrefab, base.transform);
			_landingPadView.transform.position = position + new Vector3(0.5f, 0f, 0.5f);
			Vector3 offset = GetOffset(position);
			_landingPadView.transform.forward = offset.normalized;
			_landingPadView.TryGetComponent<BuildingLandingPadModelSwitcher>(out _landingPadModelSwitcher);
			_landingPadView.TryGetComponent<BuildingLandingPadCulling>(out _landingPadCulling);
			_landingPadPos = position;
			UpdateModelBasedOnCranes(_landingPadModelSwitcher, position);
			HologramVFXController component = _landingPadView.GetComponent<HologramVFXController>();
			if (_isLoadingSave.Value)
			{
				component.ShowNormalVersion();
			}
			else
			{
				component.AnimateToNormalVersion();
			}
			_droneLandingPlatform = _landingPadView.transform.GetChild(0).GetChild(1);
			_topDroneLandingPlatformPosition = _droneLandingPlatform.transform.position;
			_bottomDroneLandingPlatformPosition = _topDroneLandingPlatformPosition + Vector3.up * _droneLandingPlatformOffset;
			_droneLandingPlatform.transform.position = _bottomDroneLandingPlatformPosition;
			_hasLandingPadView = true;
		}

		private Vector3 GetOffset(Vector3Int position)
		{
			Vector3 result = position - _behaviour.Position;
			if (Mathf.Abs(result.x + 0.5f) > Mathf.Abs(result.z + 0.5f))
			{
				result.z = 0f;
			}
			else
			{
				result.x = 0f;
			}
			return result;
		}

		private void DestroyLandingPadView()
		{
			if (_hasLandingPadView)
			{
				UnityEngine.Object.Destroy(_landingPadView);
				_hasLandingPadView = false;
			}
		}

		public void LiftPlatform(float seconds, Ease ease)
		{
			if (_hasLandingPadView)
			{
				_droneLandingPlatform.transform.position = _bottomDroneLandingPlatformPosition;
				if (_globalUpdateMultiplier.Value > 0)
				{
					_droneLandingPlatform.transform.DOMove(_topDroneLandingPlatformPosition, seconds).SetEase(ease).OnComplete(RetractPlatform);
					this.OnProductionReadyStateChanged(obj: true);
				}
			}
		}

		private void RetractPlatform()
		{
			if (_globalUpdateMultiplier.Value > 0)
			{
				_droneLandingPlatform.transform.DOMove(_bottomDroneLandingPlatformPosition, 0.5f / (float)_globalUpdateMultiplier.Value).SetDelay(0.5f).SetEase(Ease.InOutCubic);
				this.OnProductionReadyStateChanged(obj: false);
			}
		}

		private void ShowLandingPadPreview(Vector3Int position)
		{
			if (_isShowingPreview)
			{
				DestroyLandingPadView();
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(_landingPadPrefab, base.transform);
			_landingPadPreview = gameObject.GetComponent<HologramVFXController>();
			_landingPadPreview.transform.position = position + new Vector3(0.5f, 0f, 0.5f);
			Vector3 offset = GetOffset(position);
			_landingPadPreview.transform.forward = offset.normalized;
			_landingPadPreview.ShowHologramVersion();
			BuildingLandingPadModelSwitcher component = gameObject.GetComponent<BuildingLandingPadModelSwitcher>();
			UpdateModelBasedOnCranes(component, position);
			_isShowingPreview = true;
		}

		private void UpdateModelBasedOnCranes(BuildingLandingPadModelSwitcher modelSwitcher, Vector3Int position)
		{
			bool flag = false;
			foreach (BuildingCranesBehaviour.Crane crane in _buildingCranesBehaviour.Cranes)
			{
				if (crane.Position == position)
				{
					modelSwitcher.SwitchToWithCrane();
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				modelSwitcher.SwitchToNoCrane();
			}
		}

		private void UpdateModelBasedOnCranes()
		{
			if (!_hasLandingPadView)
			{
				return;
			}
			bool flag = false;
			foreach (BuildingCranesBehaviour.Crane crane in _buildingCranesBehaviour.Cranes)
			{
				if (crane.Position == _landingPadPos)
				{
					_landingPadModelSwitcher.SwitchToWithCrane();
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				_landingPadModelSwitcher.SwitchToNoCrane();
			}
		}

		private void DestroyLandingPadPreview()
		{
			if (_isShowingPreview)
			{
				UnityEngine.Object.Destroy(_landingPadPreview.gameObject);
				_isShowingPreview = false;
			}
		}

		private void HandleCullState(CullableObjectState nextCullState, CullableObjectState prevCullState = CullableObjectState.Normal)
		{
			switch (nextCullState)
			{
			case CullableObjectState.Normal:
			case CullableObjectState.LOD:
				ForceCullableRenderers(value: false);
				break;
			case CullableObjectState.ShadowsOnly:
			case CullableObjectState.Culled:
				ForceCullableRenderers(value: true);
				break;
			}
		}

		private void ForceCullableRenderers(bool value)
		{
			if (_landingPadCulling != null)
			{
				_landingPadCulling.ForceCullableRenderers(value);
			}
		}

		public override void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
		}
	}
}
