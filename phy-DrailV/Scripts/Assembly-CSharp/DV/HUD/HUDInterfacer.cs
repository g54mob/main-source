using System;
using System.Collections.Generic;
using System.ComponentModel;
using DV.Common;
using DV.Interaction.Inputs;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.UI;
using DV.UI.LocoHUD;
using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace DV.HUD
{
	public class HUDInterfacer : SingletonBehaviour<HUDInterfacer>
	{
		public struct HUDChangeEvent
		{
			public BaseControlsOverrider oldBase;

			public BaseControlsOverrider newBase;

			public InteriorControlsManager oldManager;

			public InteriorControlsManager newManager;

			public HUDLocoControls newControls;

			public HUDLocoControls oldControls;
		}

		private const float HUD_ON_VALUE = 1f;

		private const float HUD_OFF_VALUE = 0f;

		private const int HUD_OVERRIDE_PRIORITY = 1;

		[NonSerialized]
		public TrainCar currentCar;

		[NonSerialized]
		public BaseControlsOverrider baseControls;

		[NonSerialized]
		public InteriorControlsManager controlsManager;

		[NonSerialized]
		public HUDLocoControls currentHud;

		public Canvas canvas;

		public Button vrHUDButton;

		private Dictionary<TrainCarType_v2, GameObject> hudPool = new Dictionary<TrainCarType_v2, GameObject>();

		private GameParams gameParams;

		private bool shouldCloseMouseMode;

		public event Action<HUDChangeEvent> HUDChanged;

		public event Action HUDRefreshCallback;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private void Start()
		{
			gameParams = Globals.G.GameParams;
			foreach (TrainCarType_v2 carType in Globals.G.Types.carTypes)
			{
				GameObject hudPrefab = carType.hudPrefab;
				if ((bool)hudPrefab && !hudPool.ContainsKey(carType))
				{
					hudPool[carType] = UnityEngine.Object.Instantiate(hudPrefab);
					HUDLocoControls component = hudPool[carType].GetComponent<HUDLocoControls>();
					UIOptimizedEnableDisable uIOptimizedEnableDisable = component.gameObject.AddComponent<UIOptimizedEnableDisable>();
					uIOptimizedEnableDisable.activeParent = canvas.transform;
					uIOptimizedEnableDisable.disabledParent = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.disabledOptimizedParent;
					uIOptimizedEnableDisable.Disable();
					SingletonBehaviour<HUDManager>.Instance.SetCurrentHUD(component);
				}
			}
			SingletonBehaviour<HUDManager>.Instance.SetCurrentHUD(null);
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.ToggleHUD, delegate
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryToggleState(CanvasController.ElementType.HUD);
			});
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ToggleHUD, () => (bool)currentHud && gameParams.LocoHUDAllowed);
			SingletonBehaviour<HUDManager>.Instance.SetIsVR(VRManager.IsVREnabled());
			SingletonBehaviour<HUDManager>.Instance.controlsPanelAllowedGetter = () => GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.MouseMode);
			if (VRManager.IsVREnabled())
			{
				vrHUDButton.onClick.AddListener(delegate
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryToggleState(CanvasController.ElementType.HUD);
				});
				vrHUDButton.gameObject.SetActive(value: false);
			}
			else
			{
				vrHUDButton.gameObject.SetActive(value: false);
			}
			SetupListeners(on: true);
			if ((bool)PlayerManager.Car)
			{
				OnCarChanged(PlayerManager.Car);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += CanvasElementToggled;
				SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += UpdateOnScreenspaceValue;
				PlayerManager.CarChanged += OnCarChanged;
				gameParams.PropertyChanged += OnGameParamsChanged;
				return;
			}
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= CanvasElementToggled;
				SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= UpdateOnScreenspaceValue;
				gameParams.PropertyChanged -= OnGameParamsChanged;
			}
			PlayerManager.CarChanged -= OnCarChanged;
		}

		private void CanvasElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
		{
			switch (element.Type)
			{
			case CanvasController.ElementType.HUD:
				FireHUDChangedEvent(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(element));
				break;
			case CanvasController.ElementType.MouseMode:
				shouldCloseMouseMode = false;
				break;
			}
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "LocoHUDAllowed" && !gameParams.LocoHUDAllowed && SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.HUD))
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.HUD, on: false);
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ToggleHUD);
			}
		}

		private void OnCarChanged(TrainCar car)
		{
			if ((bool)currentCar)
			{
				currentCar.InteriorLoaded -= CurrentCarOnInteriorLoaded;
				currentCar.InteriorAboutToBeUnloaded -= CurrentCarOnInteriorAboutToBeUnloaded;
			}
			if ((bool)car)
			{
				car.InteriorLoaded += CurrentCarOnInteriorLoaded;
				car.InteriorAboutToBeUnloaded += CurrentCarOnInteriorAboutToBeUnloaded;
			}
			RefreshHUD(car);
		}

		private void RefreshHUD(TrainCar car)
		{
			HUDLocoControls hUDLocoControls = currentHud;
			if ((bool)hUDLocoControls)
			{
				hUDLocoControls.closeHUDButton.Clicked -= CloseHUD;
				FireHUDChangedEvent(on: false);
			}
			currentHud = null;
			currentCar = car;
			if ((bool)currentCar)
			{
				baseControls = currentCar.SimController?.controlsOverrider;
				if (hudPool.TryGetValue(currentCar.carLivery.parentType, out var value))
				{
					if ((bool)currentCar.loadedInterior)
					{
						controlsManager = currentCar.loadedInterior.GetComponent<InteriorControlsManager>();
					}
					currentHud = value.GetComponent<HUDLocoControls>();
					if ((bool)currentHud)
					{
						currentHud.closeHUDButton.Clicked += CloseHUD;
					}
				}
			}
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.HUD))
			{
				FireHUDChangedEvent(on: true);
			}
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ToggleHUD);
			this.HUDRefreshCallback?.Invoke();
		}

		private void CurrentCarOnInteriorAboutToBeUnloaded(GameObject interior)
		{
			RefreshHUD(null);
		}

		private void CurrentCarOnInteriorLoaded(GameObject interior)
		{
			if ((bool)interior)
			{
				RefreshHUD(TrainCar.Resolve(interior));
			}
		}

		private void CloseHUD(IClickable clickable)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.HUD, on: false);
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.MouseMode) && shouldCloseMouseMode)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.MouseMode, on: false);
			}
		}

		public void FireHUDChangedEvent(bool on)
		{
			if ((bool)currentHud && !UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<HUDManager>.Instance.locoHUDVisible = on;
				SingletonBehaviour<HUDManager>.Instance.SetCurrentHUD(on ? currentHud : null);
				if (VRManager.IsVREnabled())
				{
					SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, on, onlyWhenHit: true);
				}
				if (on)
				{
					this.HUDChanged?.Invoke(new HUDChangeEvent
					{
						newBase = baseControls,
						newManager = controlsManager,
						newControls = currentHud
					});
				}
				else
				{
					this.HUDChanged?.Invoke(new HUDChangeEvent
					{
						oldBase = baseControls,
						oldManager = controlsManager,
						oldControls = currentHud
					});
				}
			}
		}

		private void Update()
		{
			if ((bool)currentHud && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.HUD) && gameParams.LocoHUDAllowed)
			{
				bool num = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.HUD);
				bool flag = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.MouseMode);
				bool flag2 = num && flag;
				if (!num && !flag)
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.MouseMode, on: true);
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.HUD, on: true);
					shouldCloseMouseMode = true;
				}
				else if (flag2 && shouldCloseMouseMode)
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.HUD, on: false);
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.MouseMode, on: false);
				}
				else
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.HUD, !flag2);
				}
			}
		}

		private void UpdateOnScreenspaceValue(bool visible)
		{
			SingletonBehaviour<HUDManager>.Instance.SetCursorButtonsVisible(visible);
		}
	}
}
