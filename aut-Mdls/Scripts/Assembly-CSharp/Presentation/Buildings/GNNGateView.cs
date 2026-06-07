using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Buildings;
using Data.Operator;
using Data.Shapes;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI.Overlays;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using Presentation.Locators;
using Presentation.UI.Credits;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.Buildings
{
	public class GNNGateView : FactoryResourceHolderView<GNNGateBehaviour>, BuildingViewEvents
	{
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private GNNGateVisuals _gnnGateVisuals;

		[SerializeField]
		private BoxCollider _collider;

		[SerializeField]
		private BoxCollider _platformCollider;

		[SerializeField]
		private FactoryObjectView _factoryObjectView;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[Header("Custom Culling")]
		[SerializeField]
		private FactoryObjectViewCullingController _factoryObjectViewCullingController;

		[SerializeField]
		private List<Renderer> _cullableRenderers = new List<Renderer>();

		[Header("Platform")]
		[SerializeField]
		private Transform _platformParent;

		[Header("Activation animation refs")]
		[SerializeField]
		private Animator _activateAnimator;

		[SerializeField]
		private AnimationFinishedHandler _animationFinishedHandler;

		[SerializeField]
		private FadeToBlackEvent _fadeToBlackEvent;

		[SerializeField]
		private FadeFromBlackEvent _fadeFromBlackEvent;

		[SerializeField]
		private FadeLetterBoxFromBlackEvent _fadeLetterboxFromBlackEvent;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _creditsUILocator;

		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		[LocaKey]
		private string _endOfCampaignModalLocaKey;

		[SerializeField]
		private Sprite _endOfCampaignModalSprite;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private BoolEvent _toggleCursorVisibleEvent;

		[SerializeField]
		private BoolVariableSO _uiVisibility;

		[SerializeField]
		private InputActionReference _uiVisibilityActionRef;

		[SerializeField]
		private UIMenuManagerLocator _menuManagerLocator;

		[SerializeField]
		private BoolVariableSO _HUDUIIsHidden;

		[SerializeField]
		private BaseEvent _hideTopHUDUIEvent;

		[SerializeField]
		private BaseEvent _showTopHUDUIEvent;

		[SerializeField]
		private BoolVariableSO _TopHUDUIIsHidden;

		[SerializeField]
		private BaseEvent _hideHUDUIEvent;

		[SerializeField]
		private BaseEvent _showHUDUIEvent;

		[SerializeField]
		private List<GoBackSourceSO> _creditsIgnoreGoBackSources = new List<GoBackSourceSO>();

		private bool _isInitialized;

		private GNNGatePlatformView _gnnGatePlatformView;

		private int _lastPhase;

		private GNNGateActivationBehaviour _gnnGateActivationBehaviour;

		private readonly List<Collider> _manualColliders = new List<Collider>();

		private readonly List<Collider> _currentColliders = new List<Collider>();

		private static readonly int Play = Animator.StringToHash("Play");

		private bool _previousVisibilityActionRef;

		public event Action OnBuildingInit;

		public event Action OnBuildingPreviewInit;

		protected override void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			BuildingObjectData data = _factoryObjectDatabase.GetObjectDataWithId(objectId) as BuildingObjectData;
			_gnnGateVisuals.gameObject.SetActive(value: true);
			_gnnGateVisuals.Init(data, _behaviour, isActivated: false);
			GeneratePlatform(data);
			_gnnGateVisuals.SpawnVisuals();
			_gnnGateVisuals.ShowHologramVisuals();
			_factoryObjectView.ValidPositionChanged += UpdateValidPosition;
			ToggleColliders(toggle: false);
			this.OnBuildingPreviewInit?.Invoke();
		}

		private void HandleCullState(CullableObjectState newCullState, CullableObjectState prevCullState = CullableObjectState.Normal)
		{
			switch (newCullState)
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
			for (int num = _cullableRenderers.Count - 1; num >= 0; num--)
			{
				Renderer renderer = _cullableRenderers[num];
				if (renderer == null)
				{
					_cullableRenderers.RemoveAt(num);
				}
				else
				{
					renderer.forceRenderingOff = value;
				}
			}
		}

		private void ToggleColliders(bool toggle)
		{
			foreach (Collider currentCollider in _currentColliders)
			{
				currentCollider.enabled = toggle;
			}
			_platformCollider.enabled = toggle;
		}

		private void UpdateValidPosition(bool isValid)
		{
			_gnnGateVisuals.SetValid(isValid);
		}

		protected override void Init()
		{
			base.Init();
			_gnnGateActivationBehaviour = _behaviour.FactoryObject.GetFactoryObjectBehaviour<GNNGateActivationBehaviour>();
			_gnnGateVisuals.Init(_behaviour.BuildingObjectData, _behaviour, _gnnGateActivationBehaviour.IsActivated);
			Subscribe();
			GeneratePlatform(_behaviour.BuildingObjectData);
			SetBuildingStage(_behaviour.CurrentBuildingStage, _behaviour.IsUpgrading);
			_gnnGatePlatformView = _platformParent.GetComponentInChildren<GNNGatePlatformView>();
			_gnnGatePlatformView.TriggerCounterAnimation(_behaviour.CurrentBuildingStage);
			AddCurrentShapes();
			_isInitialized = true;
			_platformParent.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
			ToggleColliders(toggle: true);
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			HandleCullState(_factoryObjectViewCullingController.CurrentState);
			_behaviour.GetCurrentPhaseAndFloor(out _lastPhase, out var _, out var _);
			this.OnBuildingInit?.Invoke();
		}

		private void Update()
		{
			if (!_isInitialized)
			{
				_platformParent.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
			}
		}

		private void Subscribe()
		{
			_behaviour.OnStageCompleted.RegisterMainThread(TriggerBuildingCompletion);
			_behaviour.OnShapeAdded.RegisterMainThread(ShapeAdded);
			_behaviour.OnUpgradeStateChanged.RegisterMainThread(OnUpgradeStateChanged);
			_behaviour.OnCreatedResources.RegisterMainThread(OnCreatedResources);
			_behaviour.OnStageCompleted.RegisterMainThread(OnStageCompleted);
			_behaviour.OnGNNGateCompleted.RegisterMainThread(AnimateFinishedStage);
			_gnnGateActivationBehaviour.OnActivateGNNGate.RegisterMainThread(ActivateGNNGateAnimation);
		}

		private void Unsubscribe()
		{
			_factoryObjectView.ValidPositionChanged += UpdateValidPosition;
			if ((bool)_behaviour)
			{
				if (_gnnGateVisuals.IsAnimating)
				{
					_gnnGateVisuals.OnTransitionEnd -= SetBuildingStageDelayed;
				}
				_behaviour.OnStageCompleted.UnRegisterMainThread(TriggerBuildingCompletion);
				_behaviour.OnShapeAdded.UnRegisterMainThread(ShapeAdded);
				_behaviour.OnUpgradeStateChanged.UnRegisterMainThread(OnUpgradeStateChanged);
				_behaviour.OnCreatedResources.UnRegisterMainThread(OnCreatedResources);
				_behaviour.OnStageCompleted.UnRegisterMainThread(OnStageCompleted);
				_behaviour.OnGNNGateCompleted.UnRegisterMainThread(AnimateFinishedStage);
			}
			if ((bool)_gnnGateActivationBehaviour)
			{
				_gnnGateActivationBehaviour.OnActivateGNNGate.UnRegisterMainThread(ActivateGNNGateAnimation);
			}
			_animationFinishedHandler.OnFadeCreditEvent -= HandleAnimationFadeCredit;
		}

		private void OnStageCompleted(int index)
		{
			_gnnGatePlatformView.TriggerCounterAnimation(index + 1);
		}

		protected override void OnDestroy()
		{
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			_cullableRenderers.Clear();
			Unsubscribe();
			base.OnDestroy();
		}

		private void GeneratePlatform(BuildingObjectData data)
		{
			UnityEngine.Object.Instantiate(data.PlatformPrefab, _platformParent);
			Renderer[] componentsInChildren = _platformParent.GetComponentsInChildren<Renderer>();
			_cullableRenderers.AddRange(componentsInChildren);
			HandleCullState(_factoryObjectViewCullingController.CurrentState);
			_platformParent.transform.localPosition = new Vector3(data.MeshOffset.x, -0.499f, data.MeshOffset.z);
		}

		private void AddCurrentShapes()
		{
			foreach (BuildingConstructionResource buildRequirement in _behaviour.BuildRequirements)
			{
				if (buildRequirement is ShapeConstructionResource shapeConstructionResource)
				{
					ShapeAddedNoAnim(shapeConstructionResource.ShapeData, shapeConstructionResource.Count);
				}
			}
		}

		private void SetBuildingStage(int stage, bool isUpgrading)
		{
			if (!_behaviour.BuildingCompleted)
			{
				GNNGateBehaviour.UpgradeOverwrite upgradeOverwrite;
				bool hasUpgradeOverwrite = _behaviour.TryGetCurrentUpgradeOverwrite(out upgradeOverwrite);
				_gnnGateVisuals.SetUpgradeOverwrite(hasUpgradeOverwrite, upgradeOverwrite);
				_gnnGateVisuals.SpawnVisuals();
				_gnnGateVisuals.gameObject.SetActive(value: true);
				_gnnGateVisuals.ShowHologramVisuals();
				_cullableRenderers.AddRange(_gnnGateVisuals.GetComponentsInChildren<Renderer>());
				HandleCullState(_factoryObjectViewCullingController.CurrentState);
				UpdateBuildingCollider();
			}
		}

		protected override void ResetFactoryObject()
		{
			Unsubscribe();
			for (int num = _platformParent.transform.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_platformParent.GetChild(num).gameObject);
			}
			DeleteManualColliders();
			_gnnGateVisuals.Reset();
			_currentColliders.Clear();
			base.ResetFactoryObject();
		}

		private void OnUpgradeStateChanged(bool upgrading)
		{
			SetBuildingStage(_behaviour.CurrentBuildingStage, upgrading);
		}

		private void ShapeAdded(ShapeData shapeData, int index)
		{
			if (!(shapeData == null) && _behaviour.IsUpgrading)
			{
				_gnnGateVisuals.AddShape(shapeData, index);
			}
		}

		private void ShapeAddedNoAnim(ShapeData shapeData, int index)
		{
			if (_behaviour.IsUpgrading)
			{
				_gnnGateVisuals.AddShape(shapeData, index, anim: false);
			}
		}

		public void TriggerBuildingCompletion(int stage)
		{
			_behaviour.GetCurrentPhaseAndFloor(out var phase, out var _, out var _);
			if (_lastPhase == phase)
			{
				_audioManagerLocator.AudioManager.PlayFloorCompleted(base.transform.position, _factoryObjectView.FactoryObject.FactoryObjectData.ObjectSize);
			}
			else
			{
				_lastPhase = phase;
				_audioManagerLocator.AudioManager.PlayGNNPhaseComplete(base.transform.position);
			}
			AnimateFinishedStage();
		}

		private void AnimateFinishedStage()
		{
			_gnnGatePlatformView.TriggerFakeLightsAnimation();
			_gnnGateVisuals.PlayBuildingVisualsFinishedAnimation();
			_gnnGateVisuals.OnTransitionEnd += SetBuildingStageDelayed;
		}

		private void SetBuildingStageDelayed()
		{
			_gnnGateVisuals.OnTransitionEnd -= SetBuildingStageDelayed;
			if (_behaviour.IsUpgrading)
			{
				SetBuildingStage(_behaviour.CurrentBuildingStage, _behaviour.IsUpgrading);
			}
		}

		private void UpdateBuildingCollider()
		{
			DeleteManualColliders();
			if (_gnnGateVisuals.BuildingCompletionEffect.OverrideColliders)
			{
				UpdateManualColliders();
			}
			else
			{
				UpdateAutoGeneratedCollider();
			}
			UpdatePlatformCollider();
		}

		private void UpdatePlatformCollider()
		{
			_platformCollider.size = new Vector3(_behaviour.BuildingObjectData.BuildingSize.x - 1, _platformCollider.size.y, _behaviour.BuildingObjectData.BuildingSize.y - 1);
			_platformCollider.center = new Vector3((_behaviour.BuildingObjectData.BuildingSize.x % 2 == 0) ? (-0.5f) : 0f, _platformCollider.center.y, (_behaviour.BuildingObjectData.BuildingSize.y % 2 == 0) ? (-0.5f) : 0f);
		}

		private void UpdateAutoGeneratedCollider()
		{
			_collider.enabled = true;
			int num = (_behaviour.IsUpgrading ? (_behaviour.CurrentBuildingStage + 1) : _behaviour.CurrentBuildingStage);
			Vector3 boundsSize = _gnnGateVisuals.BoundsSize;
			Vector3 vector = Quaternion.Euler(0f, _gnnGateVisuals.transform.rotation.eulerAngles.y, 0f) * boundsSize;
			_collider.size = new Vector3(vector.x, boundsSize.y * (float)num, vector.z);
			_collider.center = base.transform.InverseTransformPoint(_gnnGateVisuals.CenterPosition) + Vector3.up * (_collider.size.y * 0.5f);
			_currentColliders.Clear();
			_currentColliders.Add(_collider);
		}

		private void UpdateManualColliders()
		{
			_collider.enabled = false;
			_currentColliders.Clear();
			foreach (BoxCollider collider in _gnnGateVisuals.BuildingCompletionEffect.Colliders)
			{
				collider.enabled = false;
				BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
				Quaternion quaternion = Quaternion.Euler(0f, _gnnGateVisuals.BuildingCompletionEffect.transform.localRotation.eulerAngles.y, 0f);
				Vector3 localScale = _gnnGateVisuals.BuildingCompletionEffect.transform.localScale;
				Vector3 position = _gnnGateVisuals.BuildingCompletionEffect.transform.TransformPoint(collider.center);
				Vector3 size = Vector3.Scale(quaternion * collider.size, localScale);
				boxCollider.size = size;
				boxCollider.center = base.transform.InverseTransformPoint(position);
				_manualColliders.Add(boxCollider);
				_currentColliders.Add(boxCollider);
			}
		}

		private void DeleteManualColliders()
		{
			for (int num = _manualColliders.Count - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_manualColliders[num]);
			}
			_manualColliders.Clear();
		}

		public override void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
			ResourceViewManager.Instance.ReturnResourceToPool(resource);
		}

		private void OnCreatedResources(BuildingBehaviour behaviour)
		{
			if (!_behaviour.BuildingObjectData.ProducedSFX.IsNull)
			{
				_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_behaviour.BuildingObjectData.ProducedSFX, _objectView.transform.position, _behaviour.BuildingObjectData.ObjectSize);
			}
		}

		[Button("Find All MeshRenderers", EButtonEnableMode.Always)]
		private void EditorFindAllMeshRenderers()
		{
			GetComponentsInChildren(_cullableRenderers);
		}

		private void ActivateGNNGateAnimation()
		{
			_animationFinishedHandler.OnFadeCreditEvent += HandleAnimationFadeCredit;
			_cameraViewLocator.CameraView.LerpToTargetPosition(base.transform.position, 1f, blockInput: true);
			_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: false);
			_fadeToBlackEvent.Fire(delegate
			{
				_fadeFromBlackEvent.Fire((StartAnimation, false));
			});
		}

		private void StartAnimation()
		{
			ToggleUIOff();
			_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: false);
			_activateAnimator.gameObject.SetActive(value: true);
			_activateAnimator.SetTrigger(Play);
			_audioManagerLocator.AudioManager.PlayGNNGateCompleted(base.transform.position);
		}

		private void ToggleUIOff()
		{
			_toggleCursorVisibleEvent.Fire(data: false);
			_uiVisibility.SetValue(value: false);
			_previousVisibilityActionRef = _uiVisibilityActionRef.action.enabled;
			_uiVisibilityActionRef.action.Disable();
			_menuManagerLocator.UIMenuManager.CloseAllOpenMenus();
			_TopHUDUIIsHidden.SetValue(value: true);
			_hideTopHUDUIEvent.Fire();
			_HUDUIIsHidden.SetValue(value: true);
			_hideHUDUIEvent.Fire();
			_inputActionAsset.Disable();
		}

		private void ToggleUIOn()
		{
			_inputActionAsset.Enable();
			_toggleCursorVisibleEvent.Fire(data: true);
			_uiVisibility.SetValue(value: true);
			if (_previousVisibilityActionRef)
			{
				_uiVisibilityActionRef.action.Enable();
			}
			_HUDUIIsHidden.SetValue(value: false);
			_showHUDUIEvent.Fire();
			_TopHUDUIIsHidden.SetValue(value: false);
			_showTopHUDUIEvent.Fire();
		}

		private void HandleAnimationFadeCredit()
		{
			_inputActionAsset.Enable();
			_fadeLetterboxFromBlackEvent.Fire(null);
			_showUIMenuEvent.Fire(new UIMenuMenuData(_creditsUILocator.UIMenu, AbstractUIMenuData.ToggleTypes.HideHUD, _creditsIgnoreGoBackSources));
			(_creditsUILocator.UIMenu as CreditsUI).OnCloseCredits += OnCloseCredits;
		}

		private void OnCloseCredits(CreditsUI creditsUI)
		{
			creditsUI.OnCloseCredits -= OnCloseCredits;
			_fadeToBlackEvent.Fire(delegate
			{
				_gnnGateVisuals.SetGNNGateCompleteVisuals();
				_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: true);
				ToggleUIOn();
				_activateAnimator.gameObject.SetActive(value: false);
				_fadeFromBlackEvent.Fire((delegate
				{
					ModalDialogDto dto = new ModalDialogDto(new ModalDialogContent("", _endOfCampaignModalLocaKey, _endOfCampaignModalSprite));
					_showModalDialogEvent.Fire(new UIModaldialogData(dto));
				}, true));
			});
		}
	}
}
