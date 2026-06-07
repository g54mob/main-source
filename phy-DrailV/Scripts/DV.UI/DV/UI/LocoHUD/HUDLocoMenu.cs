using System.Collections.Generic;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.LocoHUD
{
	public class HUDLocoMenu : MonoBehaviour
	{
		public enum ButtonType
		{
			CouplingLeft = 0,
			BrakeLineLeft = 1,
			MUCableLeft = 2,
			CouplingRight = 3,
			BrakeLineRight = 4,
			MUCableRight = 5,
			FollowVehicle = 6,
			ManVehicle = 7,
			Handbrake = 8,
			Info = 9,
			AdvancedCouplingLeft = 10,
			AdvancedCouplingRight = 11,
			CouplingExpandLeft = 12,
			CouplingExpandRight = 13
		}

		public enum CouplingState
		{
			Coupled = 0,
			CouplerInRange = 1,
			NoCouplerInRange = 2
		}

		public struct AllowedButtons
		{
			public bool manningAllowed;

			public bool couplingAllowed;

			public bool handbrakeAllowed;
		}

		public class RuntimeHelper
		{
			public HUDPanel panel;

			public ButtonDV button;

			public LocoHUDControlBase controlBase;
		}

		[Header("Buttons")]
		public HUDPanel couplingLeftButton;

		public HUDPanel brakeLineLeftButton;

		public HUDPanel muCableLeftButton;

		public HUDPanel couplingRightButton;

		public HUDPanel brakeLineRightButton;

		public HUDPanel muCableRightButton;

		public HUDPanel followVehicleButton;

		public HUDPanel manVehicleButton;

		public HUDPanel handbrakeButton;

		public HUDPanel infoButton;

		public HUDPanel advancedCouplingButtonLeft;

		public HUDPanel advancedCouplingButtonRight;

		public HUDPanel couplingExpandButtonLeft;

		public HUDPanel couplingExpandButtonRight;

		[Header("Other")]
		public HUDPanel infoPanel;

		public RectTransform directionMaskLeft;

		public RectTransform directionMaskRight;

		private Image directionIndicatorLeft;

		private Image directionIndicatorRight;

		private Image[] leftHoseImages;

		private Image[] rightHoseImages;

		private Image leftAdvancedCouplingImage;

		private Image rightAdvancedCouplingImage;

		private AHUDLocoMenuProvider provider;

		private RectTransform rectTransform;

		private bool couplingExpanded;

		private float expandTimerLeft;

		private float expandTimerRight;

		private AllowedButtons allowedButtons;

		private Dictionary<ButtonType, RuntimeHelper> panelDict = new Dictionary<ButtonType, RuntimeHelper>();

		private Dictionary<CouplingState, Color> couplingStateColors = new Dictionary<CouplingState, Color>
		{
			{
				CouplingState.NoCouplerInRange,
				UIColors.CLEAR
			},
			{
				CouplingState.CouplerInRange,
				UIColors.GREEN
			},
			{
				CouplingState.Coupled,
				UIColors.RED
			}
		};

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			directionIndicatorLeft = directionMaskLeft.GetChild(0).GetComponent<Image>();
			directionIndicatorRight = directionMaskRight.GetChild(0).GetComponent<Image>();
			InitializeButton(couplingLeftButton, ButtonType.CouplingLeft);
			InitializeButton(brakeLineLeftButton, ButtonType.BrakeLineLeft);
			InitializeButton(muCableLeftButton, ButtonType.MUCableLeft);
			InitializeButton(couplingRightButton, ButtonType.CouplingRight);
			InitializeButton(brakeLineRightButton, ButtonType.BrakeLineRight);
			InitializeButton(muCableRightButton, ButtonType.MUCableRight);
			InitializeButton(followVehicleButton, ButtonType.FollowVehicle);
			InitializeButton(manVehicleButton, ButtonType.ManVehicle);
			InitializeButton(handbrakeButton, ButtonType.Handbrake);
			InitializeButton(infoButton, ButtonType.Info);
			InitializeButton(advancedCouplingButtonLeft, ButtonType.AdvancedCouplingLeft);
			InitializeButton(advancedCouplingButtonRight, ButtonType.AdvancedCouplingRight);
			InitializeButton(couplingExpandButtonLeft, ButtonType.CouplingExpandLeft);
			InitializeButton(couplingExpandButtonRight, ButtonType.CouplingExpandRight);
			HUDButtonVisualLevelModule componentInChildren = brakeLineLeftButton.GetComponentInChildren<HUDButtonVisualLevelModule>();
			HUDButtonVisualLevelModule componentInChildren2 = brakeLineRightButton.GetComponentInChildren<HUDButtonVisualLevelModule>();
			leftHoseImages = new Image[2]
			{
				componentInChildren.onImages[0],
				componentInChildren.offImages[0]
			};
			rightHoseImages = new Image[2]
			{
				componentInChildren2.onImages[0],
				componentInChildren2.offImages[0]
			};
			leftAdvancedCouplingImage = advancedCouplingButtonLeft.GetComponentInChildren<HUDButtonVisualLevelModule>().onImages[0];
			rightAdvancedCouplingImage = advancedCouplingButtonRight.GetComponentInChildren<HUDButtonVisualLevelModule>().onImages[0];
			RefreshCouplingExpanded();
			void InitializeButton(HUDPanel panel, ButtonType type)
			{
				panelDict.Add(type, new RuntimeHelper
				{
					panel = panel,
					button = panel.GetComponentInChildren<ButtonDV>(),
					controlBase = panel.GetComponentInChildren<LocoHUDControlBase>()
				});
				ButtonDV componentInChildren3 = panel.GetComponentInChildren<ButtonDV>();
				switch (type)
				{
				case ButtonType.AdvancedCouplingLeft:
				case ButtonType.CouplingExpandLeft:
					componentInChildren3.MouseOverChanged += delegate(IHoverable h)
					{
						expandTimerLeft = (h.IsHovered ? (-1) : 0);
					};
					break;
				case ButtonType.AdvancedCouplingRight:
				case ButtonType.CouplingExpandRight:
					componentInChildren3.MouseOverChanged += delegate(IHoverable h)
					{
						expandTimerRight = (h.IsHovered ? (-1) : 0);
					};
					break;
				}
				componentInChildren3.Clicked += delegate
				{
					switch (type)
					{
					case ButtonType.CouplingExpandLeft:
					case ButtonType.CouplingExpandRight:
						couplingExpanded = !couplingExpanded;
						RefreshCouplingExpanded();
						break;
					case ButtonType.Info:
					{
						bool flag = infoPanel.open && infoPanel.visible;
						infoPanel.SetOpen(!flag);
						infoPanel.SetVisible(!flag);
						break;
					}
					default:
						if ((bool)provider)
						{
							provider.HandleButtonPress(type);
						}
						break;
					}
					RefreshButtonState();
					RefreshButtonInteractable();
				};
				panel.SetOpen(open: true);
			}
		}

		public void LateUpdate()
		{
			provider.CacheValues();
			RefreshCouplingIndicators();
			RefreshButtonInteractable();
			RefreshButtonState();
			RefreshButtonExpandVisible();
			RefreshHoseImageColor();
			RefreshAdvancedCouplingImageColor();
			RefreshCouplingExpanderPositions();
			UpdatePosition();
		}

		private void RefreshCouplingExpanderPositions()
		{
			float x = ((RectTransform)advancedCouplingButtonLeft.mask.parent).sizeDelta.x;
			Vector2 anchoredPosition = couplingExpandButtonLeft.mask.anchoredPosition;
			anchoredPosition.x = advancedCouplingButtonLeft.mask.anchoredPosition.x - x * 0.5f;
			couplingExpandButtonLeft.mask.anchoredPosition = anchoredPosition;
			anchoredPosition = couplingExpandButtonRight.mask.anchoredPosition;
			anchoredPosition.x = advancedCouplingButtonRight.mask.anchoredPosition.x - x * 0.5f;
			couplingExpandButtonRight.mask.anchoredPosition = anchoredPosition;
		}

		private void RefreshCouplingIndicators()
		{
			CouplingState couplerState = provider.GetCouplerState(right: true);
			CouplingState couplerState2 = provider.GetCouplerState(right: false);
			float angle = provider.GetAngle();
			directionIndicatorLeft.color = couplingStateColors[couplerState2];
			directionIndicatorRight.color = couplingStateColors[couplerState];
			directionIndicatorLeft.rectTransform.localEulerAngles = Vector3.forward * angle;
			directionIndicatorRight.rectTransform.localEulerAngles = Vector3.forward * (angle + 180f);
		}

		public void SetButtonsAllowed(AllowedButtons allowedButtons)
		{
			this.allowedButtons = allowedButtons;
			RefreshCouplingExpanded();
			SetButtonShown(ButtonType.Handbrake, allowedButtons.handbrakeAllowed);
			SetButtonShown(ButtonType.ManVehicle, allowedButtons.manningAllowed);
			SetButtonShown(ButtonType.AdvancedCouplingLeft, allowedButtons.couplingAllowed);
			SetButtonShown(ButtonType.AdvancedCouplingRight, allowedButtons.couplingAllowed);
		}

		private void RefreshCouplingExpanded()
		{
			SetButtonShown(ButtonType.CouplingLeft, couplingExpanded && allowedButtons.couplingAllowed);
			SetButtonShown(ButtonType.CouplingRight, couplingExpanded && allowedButtons.couplingAllowed);
			SetButtonShown(ButtonType.BrakeLineLeft, couplingExpanded && allowedButtons.couplingAllowed);
			SetButtonShown(ButtonType.BrakeLineRight, couplingExpanded && allowedButtons.couplingAllowed);
			SetButtonShown(ButtonType.MUCableLeft, couplingExpanded && allowedButtons.couplingAllowed);
			SetButtonShown(ButtonType.MUCableRight, couplingExpanded && allowedButtons.couplingAllowed);
			directionMaskLeft.SetParent(couplingExpanded ? couplingLeftButton.transform : advancedCouplingButtonLeft.transform, worldPositionStays: false);
			directionMaskRight.SetParent(couplingExpanded ? couplingRightButton.transform : advancedCouplingButtonRight.transform, worldPositionStays: false);
		}

		public void RefreshButtonState()
		{
			foreach (KeyValuePair<ButtonType, RuntimeHelper> item in panelDict)
			{
				switch (item.Key)
				{
				case ButtonType.CouplingExpandLeft:
				case ButtonType.CouplingExpandRight:
					item.Value.controlBase.SetVisualLevel(couplingExpanded ? 1 : 0);
					break;
				case ButtonType.Info:
					item.Value.controlBase.SetVisualLevel(infoPanel.open ? 1 : 0);
					break;
				default:
					item.Value.controlBase.SetVisualLevel(provider.GetButtonState(item.Key) ? 1 : 0);
					break;
				}
			}
		}

		public void RefreshButtonInteractable()
		{
			foreach (KeyValuePair<ButtonType, RuntimeHelper> item in panelDict)
			{
				item.Value.button.ToggleInteractable(provider.IsButtonInteractable(item.Key));
			}
		}

		private void RefreshButtonExpandVisible()
		{
			if (expandTimerLeft >= 0f)
			{
				expandTimerLeft += Time.unscaledDeltaTime;
			}
			SetButtonShown(ButtonType.CouplingExpandLeft, expandTimerLeft < 1f || couplingExpanded);
			if (expandTimerRight >= 0f)
			{
				expandTimerRight += Time.unscaledDeltaTime;
			}
			SetButtonShown(ButtonType.CouplingExpandRight, expandTimerRight < 1f || couplingExpanded);
		}

		private void RefreshHoseImageColor()
		{
			Color color = ((provider.IsHoseCockOpen(right: false) != provider.GetButtonState(ButtonType.BrakeLineLeft)) ? UIColors.RED : UIColors.WHITE);
			Color color2 = ((provider.IsHoseCockOpen(right: true) != provider.GetButtonState(ButtonType.BrakeLineRight)) ? UIColors.RED : UIColors.WHITE);
			Image[] array = leftHoseImages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = color;
			}
			array = rightHoseImages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = color2;
			}
		}

		private void RefreshAdvancedCouplingImageColor()
		{
			leftAdvancedCouplingImage.color = ((!provider.IsFullyCoupled(right: false)) ? UIColors.RED : (provider.GetButtonState(ButtonType.MUCableLeft) ? UIColors.BLUE : UIColors.WHITE));
			rightAdvancedCouplingImage.color = ((!provider.IsFullyCoupled(right: true)) ? UIColors.RED : (provider.GetButtonState(ButtonType.MUCableRight) ? UIColors.BLUE : UIColors.WHITE));
		}

		public void SetButtonShown(ButtonType type, bool shown)
		{
			if (panelDict.TryGetValue(type, out var value))
			{
				value.panel.SetOpen(shown);
				value.panel.SetVisible(shown);
			}
		}

		public void SetProvider(AHUDLocoMenuProvider provider)
		{
			this.provider = provider;
		}

		public void Turn(bool on)
		{
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.LocoContextMenu, on) && on)
			{
				provider.CacheValues();
				RefreshButtonInteractable();
				RefreshButtonState();
			}
		}

		public void UpdatePosition()
		{
			Vector2 screenCoords = provider.GetScreenCoords();
			Vector2 size = ((RectTransform)rectTransform.parent).rect.size;
			rectTransform.anchoredPosition = new Vector2(Mathf.LerpUnclamped(0f, size.x, screenCoords.x) - size.x * 0.5f, Mathf.LerpUnclamped(0f, size.y, screenCoords.y));
		}
	}
}
