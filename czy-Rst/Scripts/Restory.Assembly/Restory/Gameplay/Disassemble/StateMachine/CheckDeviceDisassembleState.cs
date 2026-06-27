using System;
using DG.Tweening;
using Mandragora.PWS;
using Restory.Data.Devices.Quality;
using Restory.Data.Disassemble.StateMachine;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.CheckDevice;
using Restory.Utils;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class CheckDeviceDisassembleState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<CheckDeviceDisassembleState>
		{
		}

		private Sequence transitionSequence;

		private readonly DeviceService deviceService;

		private readonly IPlayerInput playerInput;

		private readonly DisassembleRotationController disassembleRotationController;

		private readonly DisassembleStateMachine stateMachine;

		private readonly TweenSequencesService tweenSequences;

		private readonly VfxService vfxService;

		private readonly GUI_CheckDevicePanel checkDevicePanel;

		private readonly ShineEffectApplierToMaterialInstances shineEffectApplier;

		private readonly CheckDeviceConfig config;

		private readonly WorkSurface workSurface;

		private readonly GameWarningService gameWarningService;

		private readonly GameWarningDatabase gameWarningDatabase;

		private bool shownPanel;

		[Inject]
		public CheckDeviceDisassembleState(DeviceService deviceService, IPlayerInput playerInput, DisassembleRotationController disassembleRotationController, DisassembleStateMachine stateMachine, TweenSequencesService tweenSequences, VfxService vfxService, GUI_CheckDevicePanel checkDevicePanel, ShineEffectApplierToMaterialInstances shineEffectApplier, CheckDeviceConfig config, WorkSurface workSurface, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase)
		{
			this.deviceService = deviceService;
			this.playerInput = playerInput;
			this.disassembleRotationController = disassembleRotationController;
			this.stateMachine = stateMachine;
			this.tweenSequences = tweenSequences;
			this.vfxService = vfxService;
			this.checkDevicePanel = checkDevicePanel;
			this.shineEffectApplier = shineEffectApplier;
			this.config = config;
			this.workSurface = workSurface;
			this.gameWarningService = gameWarningService;
			this.gameWarningDatabase = gameWarningDatabase;
		}

		public void Enter()
		{
			Debug.Log("Quality: " + deviceService.PlacedDeviceContainer.Quality.ID);
			if (!(deviceService.PlacedDeviceContainer.Quality is IdealDeviceQuality))
			{
				gameWarningService.ShowWarning(gameWarningDatabase.RecheckParts);
				stateMachine.Enter<DetectionDisassembleState>();
			}
			else
			{
				disassembleRotationController.Blocked = true;
				SubscribeInputEvents();
				TransferElementToCleaningPosition();
			}
		}

		public void Exit()
		{
			shownPanel = false;
			disassembleRotationController.Blocked = false;
			UnsubscribeInputEvents();
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
				HidePanel();
			}
		}

		public void Dispose()
		{
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
		}

		private void UnsubscribeInputEvents()
		{
			playerInput.RemoveInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			if (!shownPanel)
			{
				if (transitionSequence != null)
				{
					tweenSequences.Kill(transitionSequence);
				}
				transitionSequence = tweenSequences.Create();
				transitionSequence.AppendCallback(SetScaleAndRotation).AppendCallback(ShowPanelInstantly).AppendInterval(config.DelayUI)
					.AppendCallback(HidePanel)
					.OnComplete(OnTransferComplete);
			}
			else
			{
				if (transitionSequence != null)
				{
					tweenSequences.Kill(transitionSequence);
				}
				stateMachine.Enter<DetectionDisassembleState>();
			}
		}

		private void TransferElementToCleaningPosition()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(Rotate());
			DeviceQualityBase quality = deviceService.PlacedDeviceContainer.Quality;
			if (!(quality is IdealDeviceQuality))
			{
				if (!(quality is WorkingDeviceQuality))
				{
					if (quality is BrokenDeviceQuality)
					{
						transitionSequence.Append(Vibration()).AppendCallback(PlayVfx);
					}
				}
				else
				{
					transitionSequence.AppendCallback(PlayVfx).Append(Punch());
				}
			}
			else
			{
				transitionSequence.AppendCallback(PlayVfx).AppendCallback(PowerUpDevice).Append(Punch())
					.AppendCallback(PlayShineEffect);
			}
			transitionSequence.AppendCallback(ShowPanel).AppendInterval(config.DelayUI).AppendCallback(HidePanel)
				.OnComplete(OnTransferComplete);
		}

		private void SetScaleAndRotation()
		{
			deviceService.PlacedDeviceContainer.DisassemblePoint.localEulerAngles = deviceService.PlacedDeviceContainer.InitDisassemblePointRotation;
			deviceService.PlacedDeviceContainer.DisassemblePoint.localScale = Vector3.one;
		}

		private Tween Rotate()
		{
			return deviceService.PlacedDeviceContainer.DisassemblePoint.DOLocalRotate(deviceService.PlacedDeviceContainer.InitDisassemblePointRotation, config.RotationDuration).SetEase(Ease.InOutCubic);
		}

		private Tween Vibration()
		{
			return deviceService.PlacedDeviceContainer.DisassemblePoint.DOShakeRotation(config.ShakeDuration, config.ShakeStrength, config.ShakeVibrato, config.ShakeRandomness, config.ShakeFadeOut);
		}

		private Tween Punch()
		{
			return deviceService.PlacedDeviceContainer.DisassemblePoint.DOPunchScale(Vector3.one * config.PunchScale, config.PunchDuration, config.PunchVibrato, config.PunchElasticity);
		}

		private void PowerUpDevice()
		{
			deviceService.PlacedDeviceContainer.Device.PowerUp();
		}

		private void PlayShineEffect()
		{
			shineEffectApplier.Apply(deviceService.PlacedDeviceContainer.GetComponentsInChildren<MeshRendererMaterialsInstantiator>());
		}

		private void PlayVfx()
		{
			vfxService.PlayCheckDeviceEffect(deviceService.PlacedDeviceContainer.CheckVfxPoint, deviceService.PlacedDeviceContainer.Quality);
		}

		private void ShowPanelInstantly()
		{
			shownPanel = true;
			checkDevicePanel.Show(deviceService.PlacedDeviceContainer.Quality, instantly: true);
		}

		private void ShowPanel()
		{
			shownPanel = true;
			checkDevicePanel.Show(deviceService.PlacedDeviceContainer.Quality);
		}

		private void HidePanel()
		{
			checkDevicePanel.Hide();
		}

		private void OnTransferComplete()
		{
			if (workSurface.PlacedElements.Count > 0)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.RemoveExtraParts);
			}
			transitionSequence = null;
			stateMachine.Enter<DetectionDisassembleState>();
		}
	}
}
