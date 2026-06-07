using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Data.Variables;
using Events;
using Events.Generic;
using Events.UI.Overlays;
using FMOD.Studio;
using Presentation.Buildings;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Presentation.FactoryFloor.FactoryObjectViews.Buildings
{
	public class MonumentView : FactoryBehaviorView<MonumentBehaviour>
	{
		[SerializeField]
		private FadeToBlackEvent _fadeToBlackEvent;

		[SerializeField]
		private FadeFromBlackEvent _fadeFromBlackEvent;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private Animation _animation;

		[FormerlySerializedAs("_animationFinishedHandlerHandler")]
		[FormerlySerializedAs("_monumentAnimationHandler")]
		[SerializeField]
		private AnimationFinishedHandler _animationFinishedHandler;

		[SerializeField]
		private BuildingView _buildingView;

		[SerializeField]
		private MonumentFinishedActivationAnimEvent _monumentFinishedActivationAnimEventSO;

		[SerializeField]
		private MonumentBuiltEvent _monumentBuiltEvent;

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

		private MainThreadBoolVariableSO _chargeVariable;

		private EventInstance _sfxLoopReference;

		private bool _inputPreviousState;

		private bool _previousVisibilityActionRef;

		protected override void Init()
		{
			base.Init();
			MonumentBuildingBehaviour factoryObjectBehaviour = _objectView.FactoryObject.FactoryObjectData.GetFactoryObjectBehaviour<MonumentBuildingBehaviour>();
			HandleMonumentChargedValueChanged(factoryObjectBehaviour.IsCharged);
			_chargeVariable = factoryObjectBehaviour.ChargeVariable;
			_chargeVariable.ValueChanged.RegisterMainThread(HandleMonumentChargedValueChanged);
			if (_objectView.FactoryObject.FactoryObjectData is BuildingObjectData buildingObjectData)
			{
				_animation.clip = buildingObjectData.ActivationAnimationClip;
				_animation.AddClip(buildingObjectData.ActivationAnimationClip, buildingObjectData.ActivationAnimationClip.name);
			}
			_monumentBuiltEvent.Register(OnMonumentBuilt);
		}

		protected override void OnDestroy()
		{
			if (_chargeVariable != null)
			{
				_chargeVariable.ValueChanged.UnRegisterMainThread(HandleMonumentChargedValueChanged);
			}
			_monumentBuiltEvent.UnRegister(OnMonumentBuilt);
			base.OnDestroy();
		}

		private void HandleMonumentChargedValueChanged(bool isCharged)
		{
			_audioManagerLocator.AudioManager.PlayChargedMonument(base.transform.position, isCharged, ref _sfxLoopReference);
		}

		protected override void ResetFactoryObject()
		{
			if (_chargeVariable != null)
			{
				_chargeVariable.ValueChanged.UnRegisterMainThread(HandleMonumentChargedValueChanged);
			}
			_audioManagerLocator.AudioManager.PlayChargedMonument(base.transform.position, isCharged: false, ref _sfxLoopReference);
			base.ResetFactoryObject();
		}

		private void OnMonumentBuilt(FactoryObject factoryObject)
		{
			if (!(_behaviour == null) && factoryObject == _behaviour.FactoryObject)
			{
				_fadeToBlackEvent.Fire(StartMonumentAnimation);
			}
		}

		private void StartMonumentAnimation()
		{
			ToggleUIOff();
			_cameraViewLocator.CameraView.LerpToTargetPosition(base.transform.position, 1f, blockInput: true);
			_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: false);
			_audioManagerLocator.AudioManager.PlayMonumentCompleted(base.transform.position);
			_animationFinishedHandler.OnAnimationFinishedEvent += HandleAnimationFinished;
			_buildingView.TriggerBuildingCompletion(0);
			_animation.Play();
			_fadeFromBlackEvent.Fire((null, false));
		}

		private void HandleAnimationFinished()
		{
			_animationFinishedHandler.OnAnimationFinishedEvent -= HandleAnimationFinished;
			_monumentFinishedActivationAnimEventSO.Fire(_behaviour);
			_fadeToBlackEvent.Fire(delegate
			{
				_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: true);
				_fadeFromBlackEvent.Fire((null, true));
				ToggleUIOn();
			});
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
	}
}
