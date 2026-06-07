using System;
using System.Collections.Generic;
using System.Linq;
using DV.HUD.Signs;
using DV.Interaction.Inputs;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDManager : SingletonBehaviour<HUDManager>
	{
		[Serializable]
		public class HUDPanelRuntimeHelper
		{
			public HUDPanel panel;

			public HUDPanelType type;

			[NonSerialized]
			public bool on;

			[NonSerialized]
			public bool openable;
		}

		public enum HUDPanelType
		{
			Coupling = 0,
			Passengers = 1,
			DamageInfo = 2
		}

		public delegate void ButtonClicked();

		public delegate bool ButtonConditions();

		[Serializable]
		public class HUDButtonReference
		{
			public HUDAdvancedButton button;

			public HUDButtonType type;
		}

		public class HUDButtonRuntimeValues
		{
			public RectTransform buttonRect;

			public LocoHUDControlBase buttonBase;

			public ButtonConditions buttonConditions;

			public bool on;

			public event ButtonClicked buttonClicked;

			public void CallEvent()
			{
				this.buttonClicked?.Invoke();
			}

			public bool GetConditions()
			{
				return buttonConditions?.Invoke() ?? true;
			}
		}

		public enum HUDButtonType
		{
			ToggleHUD = 0,
			TogglePhotoMode = 1,
			EnterPlayerCam = 2,
			ToggleCameraLock = 3,
			ToggleTrainControlsScreen = 4,
			ToggleCameraControlsScreen = 5,
			ToggleWeatherControlsScreen = 6,
			ToggleTimePaused = 7,
			ToggleContextUI = 8,
			InventoryOpen = 9,
			EnterFreeCam = 10,
			EnterOrbitCam = 11,
			SaveCabPosition = 12,
			SaveExtCamPose = 13,
			ResetExtCamPose = 14,
			ResetCabPosition = 15
		}

		private const float MOUSE_NOTCH_STEP_SIZE = 1.5f;

		private const float LERP_SPEED = 30f;

		private const float CURSOR_TOP_SCREEN_RATIO = 0.9f;

		private const float CURSOR_BUTTON_EXPANDED_SIZE = 40f;

		private const float CURSOR_BUTTON_CLOSED_SIZE = -5f;

		private const float SAFE_DISTANCE_UNDER_SCREEN = -100f;

		private const float CONTROLS_PANELS_TIME = 1.5f;

		public float margin = 5f;

		public RectTransform topOfLocoHUDGroup;

		public Canvas cursorButtonsCanvas;

		public UIOptimizedEnableDisable controlsPanelsEnableDisable;

		public UIOptimizedEnableDisable topOfLocoGroupEnableDisable;

		public HUDPanelRuntimeHelper[] hudPanels;

		public HUDPanel controlsOpenerPanel;

		public HUDPanel weatherEditorPanel;

		public HUDLocoControls currentHUD;

		public AudioClip scrollSound;

		public List<HUDButtonReference> buttons;

		public bool locoHUDVisible;

		public bool cursorButtonsVisible;

		public Func<bool> controlsPanelAllowedGetter;

		private float cursorButtonsHeight;

		private float lastInteraction;

		private HUDPanel[] controlsPanels;

		private HUDControlModule lastScrolled;

		private HUDControlModule dragging;

		private float dragDelta;

		private bool isVR;

		private bool playedScrollSoundThisFrame;

		private Dictionary<HUDButtonType, HUDButtonRuntimeValues> HUDRuntimeValuesMap = new Dictionary<HUDButtonType, HUDButtonRuntimeValues>();

		private Dictionary<HUDPanelType, HUDPanelRuntimeHelper> HUDPanelRuntimeHelpers = new Dictionary<HUDPanelType, HUDPanelRuntimeHelper>();

		private List<HUDLocoControls> turnOffLocoHUDList = new List<HUDLocoControls>();

		private Vector3[] corners = new Vector3[4];

		private DateTime oldTime;

		public CouplerMenu CouplerMenu { get; private set; }

		public DamageMenu DamageMenu { get; private set; }

		public SignDisplay SignDisplay { get; private set; }

		public List<HUDPanelRuntimeHelper> GadgetPanels { get; } = new List<HUDPanelRuntimeHelper>();

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			for (int i = 0; i < buttons.Count; i++)
			{
				CreateButton(buttons[i]);
			}
			HUDPanelRuntimeHelper[] array = hudPanels;
			foreach (HUDPanelRuntimeHelper panel in array)
			{
				panel.panel.openCloseButton.Clicked += delegate
				{
					panel.on = !panel.on;
					UpdateHUDPanels();
				};
				HUDPanelRuntimeHelpers.Add(panel.type, panel);
				panel.openable = true;
				switch (panel.type)
				{
				case HUDPanelType.Coupling:
					CouplerMenu = panel.panel.GetComponent<CouplerMenu>();
					break;
				case HUDPanelType.DamageInfo:
					DamageMenu = panel.panel.GetComponent<DamageMenu>();
					break;
				}
			}
			controlsOpenerPanel.openCloseButton.onClick.AddListener(delegate
			{
				if (controlsPanels != null)
				{
					HUDPanel[] array2 = controlsPanels;
					for (int k = 0; k < array2.Length; k++)
					{
						array2[k].SetOpen(open: true);
					}
				}
			});
			SignDisplay = GetComponentInChildren<SignDisplay>(includeInactive: true);
			UpdateHUDPanels();
			foreach (Transform item in base.transform)
			{
				item.gameObject.SetActive(value: true);
			}
		}

		public void SetIsVR(bool vr)
		{
			isVR = vr;
			GetComponentInChildren<Canvas>().enabled = !vr;
		}

		public void SetGadgets(IEnumerable<HUDPanel> panels)
		{
			GadgetPanels.Clear();
			GadgetPanels.AddRange(panels.Select(delegate(HUDPanel panel)
			{
				HUDPanelRuntimeHelper helper = new HUDPanelRuntimeHelper();
				helper.panel = panel;
				helper.openable = true;
				panel.openCloseButton.Clicked += delegate
				{
					helper.on = !helper.on;
					UpdateHUDPanels();
				};
				return helper;
			}));
		}

		private void Update()
		{
			cursorButtonsHeight = ((cursorButtonsHeight > margin) ? margin : Mathf.Lerp(cursorButtonsHeight, cursorButtonsVisible ? margin : (-100f), Time.unscaledDeltaTime * 30f));
			DoCurrentHUD();
			DoTurnOffHUDList();
			cursorButtonsCanvas.enabled = !isVR && Mathf.Abs(topOfLocoHUDGroup.anchoredPosition.y - -100f) > 0.001f;
			if (cursorButtonsCanvas.enabled != topOfLocoGroupEnableDisable.IsActivated)
			{
				if (cursorButtonsCanvas.enabled)
				{
					topOfLocoGroupEnableDisable.Enable(0);
				}
				else
				{
					topOfLocoGroupEnableDisable.Disable();
				}
			}
			SetAnchoredPosition(topOfLocoHUDGroup, null, cursorButtonsHeight);
			DoButtons();
			DoPanels();
			DoMouseInteraction();
		}

		private void DoMouseInteraction()
		{
			playedScrollSoundThisFrame = false;
			if (Input.GetMouseButtonDown(0))
			{
				dragging = HUDControlModule.Hovered;
				dragDelta = 0f;
				if ((bool)dragging && !dragging.isDraggable)
				{
					dragging = null;
				}
			}
			if ((bool)dragging)
			{
				dragDelta += InputManager.GetMouseAxisInput().y;
				if (Mathf.Abs(dragDelta) > 0.3f)
				{
					SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: false, 1);
				}
				while (dragDelta > 1.5f)
				{
					dragDelta -= 3f;
					PlayScrollSound(1, dragging);
					dragging.ScrollValue(1);
					dragging.ScrollValue(0);
				}
				while (dragDelta < -1.5f)
				{
					dragDelta += 3f;
					PlayScrollSound(-1, dragging);
					dragging.ScrollValue(-1);
					dragging.ScrollValue(0);
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
				if ((bool)dragging)
				{
					dragging.ScrollValue(0);
				}
				dragging = null;
			}
			if (Input.mouseScrollDelta.y != 0f)
			{
				if ((bool)HUDControlModule.Hovered)
				{
					lastScrolled = HUDControlModule.Hovered;
					if (!lastScrolled.isDraggable)
					{
						lastScrolled = null;
						return;
					}
					int notches = (int)Input.mouseScrollDelta.y;
					PlayScrollSound(notches, lastScrolled);
					lastScrolled.ScrollValue(notches);
				}
			}
			else if ((bool)lastScrolled)
			{
				lastScrolled.ScrollValue(0);
				lastScrolled = null;
			}
		}

		private void PlayScrollSound(int notches, HUDControlModule module)
		{
			if (!playedScrollSoundThisFrame)
			{
				HUDVisualLevelModule component = module.GetComponent<HUDVisualLevelModule>();
				if ((bool)component && component.ShouldScrollCallback(notches))
				{
					scrollSound.Play2D();
					playedScrollSoundThisFrame = true;
				}
			}
		}

		private void DoCurrentHUD()
		{
			if ((bool)currentHUD)
			{
				currentHUD.hudRect.GetLocalCorners(corners);
				float y = currentHUD.hudRect.anchoredPosition.y;
				float y2 = corners[1].y;
				float b = ((locoHUDVisible && (cursorButtonsVisible || isVR)) ? margin : (-100f - y2));
				y = Mathf.Lerp(y, b, Time.unscaledDeltaTime * 30f * 0.5f);
				cursorButtonsHeight = Mathf.Max(cursorButtonsHeight, y2 + y + margin);
				SetAnchoredPosition(currentHUD.hudRect, null, y);
			}
		}

		private void DoTurnOffHUDList()
		{
			for (int num = turnOffLocoHUDList.Count - 1; num >= 0; num--)
			{
				HUDLocoControls hUDLocoControls = turnOffLocoHUDList[num];
				if (hUDLocoControls.Equals(currentHUD))
				{
					turnOffLocoHUDList.RemoveAt(num);
				}
				else
				{
					hUDLocoControls.hudRect.GetLocalCorners(corners);
					float y = hUDLocoControls.hudRect.anchoredPosition.y;
					float y2 = corners[1].y;
					y = Mathf.Lerp(y, -100f - y2, Time.unscaledDeltaTime * 30f * 0.5f);
					cursorButtonsHeight = Mathf.Max(cursorButtonsHeight, y2 + y + margin);
					SetAnchoredPosition(hUDLocoControls.hudRect, null, y);
					if (y + y2 < 0f)
					{
						turnOffLocoHUDList.RemoveAt(num);
						hUDLocoControls.GetComponent<UIOptimizedEnableDisable>().Disable();
					}
				}
			}
		}

		private void DoButtons()
		{
			for (int i = 0; i < buttons.Count; i++)
			{
				HUDButtonReference hUDButtonReference = buttons[i];
				RectTransform buttonRect = HUDRuntimeValuesMap[hUDButtonReference.type].buttonRect;
				buttonRect.sizeDelta = new Vector2(Mathf.Lerp(buttonRect.sizeDelta.x, HUDRuntimeValuesMap[hUDButtonReference.type].on ? 40f : (-5f), Time.unscaledDeltaTime * 30f), buttonRect.sizeDelta.y);
			}
		}

		private void DoPanels()
		{
			if (controlsPanels == null || isVR)
			{
				return;
			}
			if (Input.mousePosition.y / (float)Screen.height > 0.9f)
			{
				lastInteraction = Time.unscaledTime;
			}
			bool flag = Time.unscaledTime - lastInteraction < 1.5f;
			bool flag2 = false;
			bool flag3 = false;
			HUDPanel[] array = controlsPanels;
			foreach (HUDPanel hUDPanel in array)
			{
				hUDPanel.SetVisible(flag && !weatherEditorPanel.open);
				if (weatherEditorPanel.open && hUDPanel.open)
				{
					hUDPanel.SetOpen(open: false);
				}
				if (!hUDPanel.open)
				{
					flag2 = true;
				}
				if (hUDPanel.open || hUDPanel.visible)
				{
					flag3 = true;
				}
			}
			if (weatherEditorPanel.open || weatherEditorPanel.visible)
			{
				flag3 = true;
			}
			if (flag3 != controlsPanelsEnableDisable.IsActivated)
			{
				if (flag3)
				{
					controlsPanelsEnableDisable.Enable(0);
				}
				else
				{
					controlsPanelsEnableDisable.Disable();
				}
			}
			controlsOpenerPanel.SetVisible(flag && !weatherEditorPanel.open && flag2 && !isVR && controlsPanelAllowedGetter != null && controlsPanelAllowedGetter());
		}

		public void SetControlsPanels(HUDPanel[] panels)
		{
			controlsPanels = panels;
			HUDPanel[] array = controlsPanels;
			foreach (HUDPanel panel in array)
			{
				panel.openCloseButton.Clicked += delegate
				{
					panel.ToggleState();
				};
			}
		}

		public void RegisterCallback(HUDButtonType type, ButtonClicked buttonClicked)
		{
			HUDRuntimeValuesMap[type].buttonClicked += buttonClicked;
		}

		public void UnregisterCallback(HUDButtonType type, ButtonClicked buttonClicked)
		{
			HUDRuntimeValuesMap[type].buttonClicked -= buttonClicked;
		}

		public void SetButtonShown(HUDButtonType type, bool on)
		{
			HUDRuntimeValuesMap[type].on = on;
		}

		public void SetVisualState(HUDButtonType type, bool on)
		{
			HUDRuntimeValuesMap[type].buttonBase.SetVisualLevel(on ? 1f : 0f);
		}

		public void SetButtonConditions(HUDButtonType type, ButtonConditions conditions)
		{
			HUDRuntimeValuesMap[type].buttonConditions = conditions;
			RefreshButtonConditions(type);
		}

		public void RefreshButtonConditions(HUDButtonType type)
		{
			if (HUDRuntimeValuesMap.TryGetValue(type, out var value))
			{
				value.on = value.GetConditions();
			}
		}

		public void SetCurrentHUD(HUDLocoControls hud)
		{
			if ((bool)currentHUD)
			{
				turnOffLocoHUDList.Add(currentHUD);
				currentHUD.openPassengersButton.Clicked -= OpenPassengersButtonClicked;
				currentHUD.openCouplingButton.Clicked -= OpenCouplingButtonClicked;
				currentHUD.openDamageButton.Clicked -= OpenDamageButtonClicked;
				currentHUD.openGadgetsButton.Clicked -= OpenGadgetsButtonClicked;
			}
			currentHUD = hud;
			UpdateHUDPanels();
			if ((bool)currentHUD)
			{
				currentHUD.GetComponent<UIOptimizedEnableDisable>().Enable();
				currentHUD.openPassengersButton.Clicked += OpenPassengersButtonClicked;
				currentHUD.openCouplingButton.Clicked += OpenCouplingButtonClicked;
				currentHUD.openDamageButton.Clicked += OpenDamageButtonClicked;
				currentHUD.openGadgetsButton.Clicked += OpenGadgetsButtonClicked;
			}
		}

		private void OpenDamageButtonClicked(IClickable clickable)
		{
			ToggleHUDPanel(HUDPanelType.DamageInfo);
		}

		private void OpenGadgetsButtonClicked(IClickable clickable)
		{
			bool flag = false;
			foreach (HUDPanelRuntimeHelper gadgetPanel in GadgetPanels)
			{
				if (gadgetPanel.on)
				{
					flag = true;
					break;
				}
			}
			foreach (HUDPanelRuntimeHelper gadgetPanel2 in GadgetPanels)
			{
				gadgetPanel2.on = !flag;
				UpdateHUDPanels();
			}
		}

		private void OpenCouplingButtonClicked(IClickable clickable)
		{
			ToggleHUDPanel(HUDPanelType.Coupling);
		}

		private void OpenPassengersButtonClicked(IClickable clickable)
		{
			ToggleHUDPanel(HUDPanelType.Passengers);
		}

		public void ToggleHUDPanel(HUDPanelType type)
		{
			if (HUDPanelRuntimeHelpers.TryGetValue(type, out var value))
			{
				value.on = !value.on;
				UpdateHUDPanels();
			}
		}

		public void SetHUDPanelOn(HUDPanelType type, bool on)
		{
			if (HUDPanelRuntimeHelpers.TryGetValue(type, out var value))
			{
				value.on = on;
				UpdateHUDPanels();
			}
		}

		public void SetHUDOpenable(HUDPanelType type, bool openable)
		{
			if (HUDPanelRuntimeHelpers.TryGetValue(type, out var value))
			{
				value.openable = openable;
				UpdateHUDPanels();
			}
		}

		private void SetHUDPanelButtonInteractible(HUDPanelType type, ButtonDV button)
		{
			if (HUDPanelRuntimeHelpers.TryGetValue(type, out var value))
			{
				button.ToggleInteractable(value.openable);
			}
		}

		private void UpdateHUDPanels()
		{
			HUDPanelRuntimeHelper[] array = hudPanels;
			foreach (HUDPanelRuntimeHelper panel in array)
			{
				DoPanel(panel);
			}
			foreach (HUDPanelRuntimeHelper gadgetPanel in GadgetPanels)
			{
				DoPanel(gadgetPanel);
			}
			UpdateHUDPanelButtons();
		}

		private void DoPanel(HUDPanelRuntimeHelper panel)
		{
			bool open = cursorButtonsVisible && locoHUDVisible && panel.on && panel.openable;
			panel.panel.SetOpen(open);
		}

		private void UpdateHUDPanelButtons()
		{
			if ((bool)currentHUD)
			{
				SetHUDPanelButtonInteractible(HUDPanelType.Coupling, currentHUD.openCouplingButton);
				SetHUDPanelButtonInteractible(HUDPanelType.Passengers, currentHUD.openPassengersButton);
				SetHUDPanelButtonInteractible(HUDPanelType.DamageInfo, currentHUD.openDamageButton);
			}
		}

		public void SetCursorButtonsVisible(bool visible)
		{
			cursorButtonsVisible = visible;
			lastInteraction = (visible ? Time.unscaledTime : float.MinValue);
			UpdateHUDPanels();
		}

		public void SetTime(DateTime time, bool force = false)
		{
			if (time != oldTime || force)
			{
				oldTime = time;
				int hour = time.Hour;
				string textValue = $"{hour}:{time.Minute.ToString().PadLeft(2, '0')}";
				if ((bool)currentHUD && (bool)currentHUD.cab.time)
				{
					currentHUD.cab.time.SetTextValue(textValue);
				}
			}
		}

		public void SetClockShown(bool on)
		{
			if ((bool)currentHUD && (bool)currentHUD.cab.time)
			{
				currentHUD.cab.time.gameObject.SetActive(on);
			}
		}

		private void SetAnchoredPosition(RectTransform rect, float? x = null, float? y = null, float? dx = null, float? dy = null)
		{
			Vector2 anchoredPosition = rect.anchoredPosition;
			if (x.HasValue)
			{
				anchoredPosition.x = x.Value;
			}
			if (y.HasValue)
			{
				anchoredPosition.y = y.Value;
			}
			if (dx.HasValue)
			{
				anchoredPosition.x += dx.Value;
			}
			if (dy.HasValue)
			{
				anchoredPosition.y += dy.Value;
			}
			rect.anchoredPosition = anchoredPosition;
		}

		private void CreateButton(HUDButtonReference reference)
		{
			HUDButtonType type = reference.type;
			RectTransform component = reference.button.gameObject.GetComponent<RectTransform>();
			component.localScale = Vector3.one;
			LocoHUDControlBase controlBase = reference.button.controlBase;
			HUDRuntimeValuesMap[type] = new HUDButtonRuntimeValues
			{
				on = false,
				buttonRect = component,
				buttonBase = controlBase
			};
			controlBase.controlModule.ValueChanged += delegate(float value)
			{
				if (value > 0.5f)
				{
					HUDRuntimeValuesMap[type].CallEvent();
				}
			};
			controlBase.SetVisualLevel(0f);
		}
	}
}
