using System;
using System.ComponentModel;
using DV.Interaction.Inputs;
using DV.RemoteControls;
using DV.Simulation.Cars;
using DV.UI;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;

namespace DV.HUD
{
	public class HUDLocoMenuProvider : AHUDLocoMenuProvider
	{
		private const bool RIGHT = true;

		private const bool LEFT = false;

		private const float PERCENTAGE_OF_SCREEN_FILLED_BY_HUD = 0.2f;

		public AnimationCurve popupAnimation;

		public float popupLength;

		public float popupHeightMult;

		public Material validMaterial;

		public GameObject highlighter;

		public HUDLocoMenu menu;

		private TrainCar currentCar;

		private BaseControlsOverrider currentBCO;

		private LocoZoneBlocker locoBlocker;

		private HUDTrainPlateInfo plateInfo;

		private CarDestinationHighlighter carDestinationHighlighter;

		private float angle;

		private UICouplingHelper couplingHelper;

		private float timeSinceCarChanged;

		[NonSerialized]
		public SimpleHoverable simpleHoverable;

		[NonSerialized]
		public bool contextMenuFitsOnScreen;

		private GameParams gameParams;

		private void Awake()
		{
			couplingHelper = new UICouplingHelper();
			couplingHelper.shouldAutoHandbrake = () => !InputManager.NewPlayer.GetButton(InputManager.Actions.Run) && gameParams.AutoHandbrakeViaUICouplingAllowed;
			simpleHoverable = menu.GetComponent<SimpleHoverable>();
			plateInfo = menu.GetComponentInChildren<HUDTrainPlateInfo>(includeInactive: true);
			menu.SetProvider(this);
			carDestinationHighlighter = new CarDestinationHighlighter(highlighter, null);
			gameParams = Globals.G.GameParams;
			SetupListeners(on: true);
			RefreshAllowedButtons();
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				gameParams.PropertyChanged += GameParamsPropertyChanged;
				RemoteControllerModule.PairingChangedAny += OnPairedAnyChanged;
			}
			else
			{
				gameParams.PropertyChanged -= GameParamsPropertyChanged;
				RemoteControllerModule.PairingChangedAny -= OnPairedAnyChanged;
			}
		}

		private void GameParamsPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "HandbrakeControlViaUIAllowed":
			case "CouplingViaHUDAllowed":
			case "FreeCamDashAllowed":
				RefreshAllowedButtons();
				break;
			}
		}

		private void RefreshAllowedButtons()
		{
			bool flag = false;
			if ((bool)currentCar)
			{
				foreach (TrainCar car in currentCar.trainset.cars)
				{
					RemoteControllerModule component;
					if (!car)
					{
						Debug.LogError("train should not be null!");
					}
					else if (car.TryGetComponent<RemoteControllerModule>(out component) && component.IsPaired)
					{
						flag = true;
						break;
					}
				}
			}
			menu.SetButtonsAllowed(new HUDLocoMenu.AllowedButtons
			{
				handbrakeAllowed = gameParams.HandbrakeControlViaUIAllowed,
				couplingAllowed = (gameParams.CouplingViaHUDAllowed || (gameParams.CouplingViaRemoteControllerAllowed && flag)),
				manningAllowed = (gameParams.FreeCamDashAllowed && (!currentCar || !locoBlocker))
			});
		}

		public void CarChanged(TrainCar car)
		{
			if ((bool)currentCar)
			{
				plateInfo.UnsubscribeCar(currentCar);
				menu.Turn(on: false);
				carDestinationHighlighter.TurnOff();
				locoBlocker = null;
			}
			currentCar = car;
			currentBCO = car?.SimController?.controlsOverrider;
			couplingHelper.trainCar = car;
			if ((bool)currentCar)
			{
				timeSinceCarChanged = 0f;
				menu.Turn(on: true);
				menu.UpdatePosition();
				plateInfo.SubscribeCar(currentCar);
				locoBlocker = currentCar.interior.GetComponentInChildren<LocoZoneBlocker>();
			}
			RefreshAllowedButtons();
		}

		private void OnPairedAnyChanged(bool paired, LocomotiveRemoteController controller)
		{
			RefreshAllowedButtons();
		}

		public override void HandleButtonPress(HUDLocoMenu.ButtonType type)
		{
			switch (type)
			{
			case HUDLocoMenu.ButtonType.AdvancedCouplingLeft:
				couplingHelper.HandleCoupling(couplingHelper.GetCoupler(GetCouplerViewDir(right: false).isFrontCoupler), advanced: true);
				break;
			case HUDLocoMenu.ButtonType.AdvancedCouplingRight:
				couplingHelper.HandleCoupling(couplingHelper.GetCoupler(GetCouplerViewDir(right: true).isFrontCoupler), advanced: true);
				break;
			case HUDLocoMenu.ButtonType.CouplingLeft:
				couplingHelper.HandleCoupling(couplingHelper.GetCoupler(GetCouplerViewDir(right: false).isFrontCoupler), advanced: false);
				break;
			case HUDLocoMenu.ButtonType.CouplingRight:
				couplingHelper.HandleCoupling(couplingHelper.GetCoupler(GetCouplerViewDir(right: true).isFrontCoupler), advanced: false);
				break;
			case HUDLocoMenu.ButtonType.FollowVehicle:
			{
				ExternalCamera externalCamera = SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera;
				if (externalCamera.CurrentCar == currentCar)
				{
					externalCamera.SwitchOrbitalToFly();
				}
				else
				{
					externalCamera.SwitchFlyToOrbital(currentCar);
				}
				break;
			}
			case HUDLocoMenu.ButtonType.ManVehicle:
				if (!TrainCar.IsInsideZoneBlocker(currentCar))
				{
					PlayerManager.TeleportPlayerToCar(currentCar);
				}
				break;
			case HUDLocoMenu.ButtonType.MUCableLeft:
				couplingHelper.DoMU(GetCouplerViewDir(right: false));
				break;
			case HUDLocoMenu.ButtonType.MUCableRight:
				couplingHelper.DoMU(GetCouplerViewDir(right: true));
				break;
			case HUDLocoMenu.ButtonType.BrakeLineLeft:
				couplingHelper.HandleBrakeHose(GetCouplerViewDir(right: false).isFrontCoupler);
				break;
			case HUDLocoMenu.ButtonType.BrakeLineRight:
				couplingHelper.HandleBrakeHose(GetCouplerViewDir(right: true).isFrontCoupler);
				break;
			case HUDLocoMenu.ButtonType.Handbrake:
				if ((bool)currentBCO)
				{
					currentBCO?.Handbrake?.Set((currentBCO.Handbrake.Value > 0.01f) ? 0f : 1f);
				}
				else
				{
					currentCar.brakeSystem.SetHandbrakePosition((currentCar.brakeSystem.handbrakePosition > 0.01f) ? 0f : 1f);
				}
				break;
			case HUDLocoMenu.ButtonType.Info:
				break;
			}
		}

		public override bool GetButtonState(HUDLocoMenu.ButtonType type)
		{
			switch (type)
			{
			case HUDLocoMenu.ButtonType.Handbrake:
				if ((bool)currentBCO)
				{
					return (currentBCO?.Handbrake?.Value ?? 0f) > 0.01f;
				}
				return currentCar.brakeSystem.handbrakePosition > 0.01f;
			case HUDLocoMenu.ButtonType.ManVehicle:
				return PlayerManager.Car == currentCar;
			case HUDLocoMenu.ButtonType.BrakeLineLeft:
				return couplingHelper.IsAirConnected(GetCouplerViewDir(right: false).isFrontCoupler);
			case HUDLocoMenu.ButtonType.BrakeLineRight:
				return couplingHelper.IsAirConnected(GetCouplerViewDir(right: true).isFrontCoupler);
			case HUDLocoMenu.ButtonType.MUCableLeft:
				return couplingHelper.IsMUConnected(GetCouplerViewDir(right: false).isFrontCoupler);
			case HUDLocoMenu.ButtonType.MUCableRight:
				return couplingHelper.IsMUConnected(GetCouplerViewDir(right: true).isFrontCoupler);
			case HUDLocoMenu.ButtonType.FollowVehicle:
				return SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.CurrentCar == currentCar;
			case HUDLocoMenu.ButtonType.CouplingLeft:
				return GetCouplerViewDir(right: false).IsCoupled();
			case HUDLocoMenu.ButtonType.CouplingRight:
				return GetCouplerViewDir(right: true).IsCoupled();
			case HUDLocoMenu.ButtonType.AdvancedCouplingLeft:
				return GetCouplerViewDir(right: false).IsCoupled();
			case HUDLocoMenu.ButtonType.AdvancedCouplingRight:
				return GetCouplerViewDir(right: true).IsCoupled();
			default:
				return false;
			}
		}

		public override bool IsButtonInteractable(HUDLocoMenu.ButtonType type)
		{
			switch (type)
			{
			case HUDLocoMenu.ButtonType.MUCableLeft:
				if (GetCouplerViewDir(right: false).IsCoupled() && currentCar.IsMultipleUnit)
				{
					return GetCouplerViewDir(right: false).coupledTo.train.IsMultipleUnit;
				}
				return false;
			case HUDLocoMenu.ButtonType.MUCableRight:
				if (GetCouplerViewDir(right: true).IsCoupled() && currentCar.IsMultipleUnit)
				{
					return GetCouplerViewDir(right: true).coupledTo.train.IsMultipleUnit;
				}
				return false;
			case HUDLocoMenu.ButtonType.ManVehicle:
				return PlayerManager.Car != currentCar;
			case HUDLocoMenu.ButtonType.CouplingLeft:
			case HUDLocoMenu.ButtonType.AdvancedCouplingLeft:
				if (!couplingHelper.IsInRange(GetCouplerViewDir(right: false).isFrontCoupler))
				{
					return GetCouplerViewDir(right: false).IsCoupled();
				}
				return true;
			case HUDLocoMenu.ButtonType.CouplingRight:
			case HUDLocoMenu.ButtonType.AdvancedCouplingRight:
				if (!couplingHelper.IsInRange(GetCouplerViewDir(right: true).isFrontCoupler))
				{
					return GetCouplerViewDir(right: true).IsCoupled();
				}
				return true;
			default:
				return true;
			}
		}

		public override bool IsHoseCockOpen(bool right)
		{
			return GetCouplerViewDir(right).IsCockOpen;
		}

		public override bool IsFullyCoupled(bool right)
		{
			return couplingHelper.IsFullyCoupled(GetCouplerViewDir(right).isFrontCoupler);
		}

		public override void CacheValues()
		{
			timeSinceCarChanged += Time.unscaledDeltaTime;
			angle = GetAngleBetweenCamAndTrain();
			couplingHelper.SetCoupler(currentCar.frontCoupler, front: true);
			couplingHelper.SetCoupler(currentCar.rearCoupler, front: false);
			couplingHelper.CacheValues();
		}

		public override HUDLocoMenu.CouplingState GetCouplerState(bool right)
		{
			Coupler couplerViewDir = GetCouplerViewDir(right);
			if (couplerViewDir.IsCoupled())
			{
				return HUDLocoMenu.CouplingState.Coupled;
			}
			if (couplingHelper.IsInRange(couplerViewDir.isFrontCoupler))
			{
				return HUDLocoMenu.CouplingState.CouplerInRange;
			}
			return HUDLocoMenu.CouplingState.NoCouplerInRange;
		}

		private Coupler GetCouplerViewDir(bool right)
		{
			if (!currentCar)
			{
				return null;
			}
			if (!((float)(right ? 1 : (-1)) * Mathf.Sign(angle) < 0f))
			{
				return currentCar.rearCoupler;
			}
			return currentCar.frontCoupler;
		}

		public override float GetAngle()
		{
			return Mathf.Repeat(GetAngleBetweenCamAndTrain(), 180f);
		}

		public override Vector2 GetScreenCoords()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera || !currentCar)
			{
				return Vector2.zero;
			}
			float time = Mathf.Clamp01(timeSinceCarChanged / popupLength);
			Vector3 vector = currentCar.transform.TransformPoint(Vector3.Scale(currentCar.Bounds.center, new Vector3(1f, 0f, 1f)));
			Vector3 position = vector + Vector3.up * (1f + popupAnimation.Evaluate(time) * popupHeightMult);
			Vector3 vector2 = activeCamera.WorldToViewportPoint(position);
			float num = Mathf.Min(vector2.x, vector2.y, 1f - vector2.x, 1f - vector2.y);
			if (SingletonBehaviour<HUDManager>.Instance.locoHUDVisible)
			{
				num = Mathf.Min(num, vector2.y - 0.2f);
			}
			contextMenuFitsOnScreen = num > 0.05f;
			if (contextMenuFitsOnScreen)
			{
				carDestinationHighlighter.Highlight(vector, currentCar.transform.forward, currentCar.Bounds, validMaterial);
			}
			else
			{
				carDestinationHighlighter.TurnOff();
			}
			if (!contextMenuFitsOnScreen)
			{
				return Vector2.right * 100f;
			}
			return vector2;
		}

		private float GetAngleBetweenCamAndTrain()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera || !currentCar)
			{
				return 0f;
			}
			Vector3 forward = activeCamera.transform.forward;
			forward.y = 0f;
			Vector3 forward2 = currentCar.transform.forward;
			forward2.y = 0f;
			return 0f - Vector3.SignedAngle(forward.normalized, forward2.normalized, Vector3.up);
		}
	}
}
