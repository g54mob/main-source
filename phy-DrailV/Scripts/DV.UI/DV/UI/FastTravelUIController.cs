using System;
using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class FastTravelUIController : NullCheckingMonoBehaviour
	{
		private FastTravelData ftd;

		private const string TOOLTIP_NOT_ENOUGH_MONEY = "fasttravel/not_enough_money";

		private const string TOOLTIP_DESTINATION_LOCO_REQUIRES_LICENSE = "fasttravel/dest_loco_req_license";

		private const string TOOLTIP_NOT_IN_A_LOCOMOTIVE = "fasttravel/not_in_loco";

		private const string TOOLTIP_LOCO_REQUIRES_LICENSE = "fasttravel/loco_req_license";

		private const string TOOLTIP_LOCOMOTIVE_DERAILED = "fasttravel/loco_derailed";

		private const string TOOLTIP_LOCOMOTIVE_FAST_TRAVEL_PREVENTED = "fasttravel/loco_prevented";

		private const string TOOLTIP_COST = "fasttravel/cost";

		private const string CONFIRMATION_DIALOG_TITLE = "fasttravel/pay";

		private const string TOOLTIP_TUTORIAL_IN_PROGRESS = "fasttravel/disabled_in_tutorial";

		private const string TOOLTIP_ARRIVAL_TIME = "fasttravel/arrival_time";

		[Header("Buttons")]
		[NullCheck]
		public ButtonDV fastTravelButton;

		[NullCheck]
		public ButtonDV fastTravelWithLocoButton;

		[NullCheck]
		public ButtonDV confirmPaymentButton;

		[NullCheck]
		public ButtonDV cancelPaymentButton;

		[NullCheck]
		public ButtonDV jumpButton;

		[NullCheck]
		public ButtonDV initialScreenCloseButton;

		[NullCheck]
		public ButtonDV confirmDialogCloseButton;

		[NullCheck]
		public ButtonDV jumpMenuCloseButton;

		[Header("Other")]
		[NullCheck]
		public UIMenuController menuController;

		[NullCheck]
		public TextMeshProUGUI initialScreenTitleTMPro;

		[NullCheck]
		public TextMeshProUGUI confirmationDialogTitleTMPro;

		[NullCheck]
		public TextMeshProUGUI jumpDialogTitleTMPro;

		[NullCheck]
		public TooltipHandler tooltipHandler;

		private UIElementTooltipNonLocalizedText fastTravelButtonTooltip;

		private UIElementTooltipNonLocalizedText fastTravelWithLocoButtonTooltip;

		private bool? withLocoButtonClicked;

		public bool DestroyOnClose => true;

		public event FastTravelRequest FastTravelRequested;

		public event Action JumpRequested;

		public event Action TeleportDenied;

		public event Action CloseRequested;

		public void Show(FastTravelData ftd)
		{
			this.ftd = ftd;
			RefreshInterface();
		}

		public void Hide()
		{
			menuController.CloseAllMenus();
		}

		protected override void Awake()
		{
			base.Awake();
			fastTravelButtonTooltip = fastTravelButton.GetComponent<UIElementTooltipNonLocalizedText>();
			fastTravelWithLocoButtonTooltip = fastTravelWithLocoButton.GetComponent<UIElementTooltipNonLocalizedText>();
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				fastTravelButton.Clicked += OnFastTravelClicked;
				fastTravelWithLocoButton.Clicked += OnFastTravelWithLocoClicked;
				confirmPaymentButton.Clicked += OnConfirmPaymentClicked;
				cancelPaymentButton.Clicked += OnCloseClicked;
				jumpButton.Clicked += OnJumpClicked;
				initialScreenCloseButton.Clicked += OnCloseClicked;
				confirmDialogCloseButton.Clicked += OnCloseClicked;
				jumpMenuCloseButton.Clicked += OnCloseClicked;
			}
			else
			{
				fastTravelButton.Clicked -= OnFastTravelClicked;
				fastTravelWithLocoButton.Clicked -= OnFastTravelWithLocoClicked;
				confirmPaymentButton.Clicked -= OnConfirmPaymentClicked;
				cancelPaymentButton.Clicked -= OnCloseClicked;
				jumpButton.Clicked -= OnJumpClicked;
				initialScreenCloseButton.Clicked -= OnCloseClicked;
				confirmDialogCloseButton.Clicked -= OnCloseClicked;
				jumpMenuCloseButton.Clicked -= OnCloseClicked;
			}
		}

		private void RefreshInterface()
		{
			withLocoButtonClicked = null;
			if (ftd.isDestinationWithinSameTrainset)
			{
				menuController.SwitchMenu(2);
				jumpDialogTitleTMPro.text = ftd.destinationName;
			}
			else
			{
				menuController.SwitchMenu(0);
				if (ftd.isTutorialInProgress)
				{
					fastTravelButtonTooltip.text = LocalizationAPI.L("fasttravel/disabled_in_tutorial");
					fastTravelButton.ToggleInteractable(newInteractable: false);
				}
				else if (ftd.CanTravelWithoutLoco)
				{
					fastTravelButtonTooltip.text = FormatTooltipText(withLoco: false);
					fastTravelButton.ToggleInteractable(newInteractable: true);
				}
				else if (!ftd.hasMoneyForFastTravel)
				{
					fastTravelButtonTooltip.text = LocalizationAPI.L("fasttravel/not_enough_money");
					fastTravelButton.ToggleInteractable(newInteractable: false);
				}
				else if (ftd.isDestinationLoco && !ftd.hasLicenseForDestinationLoco)
				{
					fastTravelButtonTooltip.text = LocalizationAPI.L("fasttravel/dest_loco_req_license");
					fastTravelButton.ToggleInteractable(newInteractable: false);
				}
				else
				{
					Debug.LogError("Unexpected state when setting up \"Fast Travel\" button", this);
				}
				if (ftd.isTutorialInProgress)
				{
					fastTravelWithLocoButtonTooltip.text = LocalizationAPI.L("fasttravel/disabled_in_tutorial");
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: false);
				}
				else if (ftd.CanTravelWithLoco)
				{
					fastTravelWithLocoButtonTooltip.text = FormatTooltipText(withLoco: true);
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: true);
				}
				else if (ftd.isLocoFastTravelPrevented)
				{
					fastTravelWithLocoButtonTooltip.text = LocalizationAPI.L("fasttravel/loco_prevented");
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: false);
				}
				else if (!ftd.isInLocomotive)
				{
					fastTravelWithLocoButtonTooltip.text = LocalizationAPI.L("fasttravel/not_in_loco");
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: false);
				}
				else if (!ftd.hasLocoLicense)
				{
					fastTravelWithLocoButtonTooltip.text = LocalizationAPI.L("fasttravel/loco_req_license");
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: false);
				}
				else if (!ftd.isLocoOnTracks)
				{
					fastTravelWithLocoButtonTooltip.text = LocalizationAPI.L("fasttravel/loco_derailed");
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: false);
				}
				else if (!ftd.hasMoneyForFastTravelWithLoco)
				{
					fastTravelWithLocoButtonTooltip.text = LocalizationAPI.L("fasttravel/not_enough_money");
					fastTravelWithLocoButton.ToggleInteractable(newInteractable: false);
				}
				else
				{
					Debug.LogError("Unexpected state when setting up \"Fast Travel With Loco\" button", this);
				}
			}
			tooltipHandler.UpdateTooltipText();
		}

		private string FormatTooltipText(bool withLoco)
		{
			int num = (withLoco ? ftd.fastTravelWithLocoPrice : ftd.fastTravelPrice);
			string text = "<align=left><margin-right=30%>" + ftd.destinationName + "</margin></align><line-height=0>";
			string text2 = "\n<align=right><margin-left=70%>" + LocalizationAPI.L("fasttravel/arrival_time") + "</margin></align></line-height>";
			string text3 = "\n<align=left><margin-right=50%>" + LocalizationAPI.L("fasttravel/cost", num.ToString()) + "</margin></align><line-height=0>\n";
			string text4 = $"</line-height><align=right><margin-left=50%>{ftd.arrivalTime:MM/dd HH:mm}</margin></align>";
			return text + text2 + text3 + text4;
		}

		private void OnCloseClicked(IClickable clickable)
		{
			this.CloseRequested?.Invoke();
		}

		private void OnFastTravelClicked(IClickable clickable)
		{
			withLocoButtonClicked = false;
			confirmationDialogTitleTMPro.text = LocalizationAPI.L("fasttravel/pay", ftd.fastTravelPrice.ToString());
			menuController.SwitchMenu(1);
		}

		private void OnFastTravelWithLocoClicked(IClickable clickable)
		{
			withLocoButtonClicked = true;
			confirmationDialogTitleTMPro.text = LocalizationAPI.L("fasttravel/pay", ftd.fastTravelWithLocoPrice.ToString());
			menuController.SwitchMenu(1);
		}

		private void OnConfirmPaymentClicked(IClickable clickable)
		{
			this.FastTravelRequested?.Invoke(withLocoButtonClicked.Value);
			this.CloseRequested?.Invoke();
		}

		private void OnJumpClicked(IClickable clickable)
		{
			this.JumpRequested?.Invoke();
			this.CloseRequested?.Invoke();
		}
	}
}
