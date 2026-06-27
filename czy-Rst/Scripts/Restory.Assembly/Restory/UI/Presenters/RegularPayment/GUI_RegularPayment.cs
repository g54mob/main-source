using System;
using DG.Tweening;
using Helpers.Extensions;
using Helpers.Ranges;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.Common;
using Restory.Gameplay.Effects;
using Restory.Gameplay.GameView;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Statistics;
using Restory.UI.Views.Tooltips;
using Restory.UserInterface;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.RegularPayment
{
	public sealed class GUI_RegularPayment : MonoBehaviour, IActiveStateSwitchRequester, IExitablePanel
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Button closeButton;

		[SerializeField]
		private GUI_LocalisedText nameOfBillText;

		[SerializeField]
		private TextMeshProUGUI amountText;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private RectTransform paymentTransform;

		[SerializeField]
		private RectTransform moneyIconTransform;

		[SerializeField]
		private RectTransform billTransform;

		[SerializeField]
		private RectTransform envelopeFrontTransform;

		[SerializeField]
		private GUI_TooltipIndicator tooltipIndicator;

		[SerializeField]
		[Min(0f)]
		private float showHideDuration = 0.25f;

		[SerializeField]
		[Min(0f)]
		private float moveMoneyDuration = 1f;

		[SerializeField]
		private FloatRange moneyPositionY = new FloatRange(404f, 602f);

		[SerializeField]
		[Min(0f)]
		private float delayCloseDuration = 1f;

		[SerializeField]
		[Min(0f)]
		private float moveBillDuration = 1f;

		[SerializeField]
		private FloatRange billPositionY = new FloatRange(404f, 602f);

		[SerializeField]
		[Min(0f)]
		private float paymentScale = 0.8f;

		[SerializeField]
		[Min(0f)]
		private float paymentScaleDuration = 0.5f;

		[SerializeField]
		private FloatRange paymentPositionX = new FloatRange(404f, 602f);

		[SerializeField]
		[Min(0f)]
		private float rotationPaymentDuration = 20f;

		[SerializeField]
		[Min(0f)]
		private float movePaymentDuration = 2f;

		[SerializeField]
		private string emptyPresetName = "Empty";

		[SerializeField]
		private string moneyPresetName = "With money";

		[SerializeField]
		private string closePresetName = "Closed";

		private RegularPaymentObject regularPaymentObject;

		private bool isVisible = true;

		private Sequence autoHideSequence;

		private Sequence showHideSequence;

		private Sequence moneySequence;

		private GameStatisticsService gameStatistics;

		private RegularPaymentObjectService regularPaymentObjectService;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		private TweenSequencesService tweenSequencesService;

		private VfxService vfxService;

		public bool IsVisible => isVisible;

		public RegularPaymentObject RegularPaymentObject => regularPaymentObject;

		public event Action OnIsVisibleChanged;

		[Inject]
		private void Construct(VfxService vfxService, RegularPaymentObjectService regularPaymentObjectService, CameraDirectionSwitcher cameraDirectionSwitcher, TweenSequencesService tweenSequencesService, GameStatisticsService gameStatistics)
		{
			this.vfxService = vfxService;
			this.regularPaymentObjectService = regularPaymentObjectService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.tweenSequencesService = tweenSequencesService;
			this.gameStatistics = gameStatistics;
		}

		private void OnEnable()
		{
			closeButton.onClick.AddListener(ResolveCloseButtonClicked);
		}

		private void OnDisable()
		{
			closeButton.onClick.RemoveListener(ResolveCloseButtonClicked);
			tweenSequencesService.Kill(autoHideSequence);
			tweenSequencesService.Kill(moneySequence);
			tweenSequencesService.Kill(showHideSequence);
			isVisible = false;
		}

		public void ToggleIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		public void Show(RegularPaymentObject regularPaymentObject)
		{
			tweenSequencesService.Kill(autoHideSequence);
			tweenSequencesService.Kill(moneySequence);
			tweenSequencesService.Kill(showHideSequence);
			isVisible = true;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
			this.regularPaymentObject = regularPaymentObject;
			nameOfBillText.LocalizationID = regularPaymentObject.RegularPaymentInfo.NameLocalizationKey;
			amountText.text = "¥" + regularPaymentObject.RegularPaymentInfo.Sum.ToReadableString();
			cameraDirectionSwitcher.AddBlocker(this);
			HideMoney();
			ResetBill();
			ResetPayment();
			showHideSequence = tweenSequencesService.Create();
			showHideSequence.Append(canvasGroup.DOFade(1f, showHideDuration));
			this.OnIsVisibleChanged?.Invoke();
		}

		public void Hide(bool instant = false)
		{
			if (isVisible)
			{
				isVisible = false;
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
				regularPaymentObject = null;
				cameraDirectionSwitcher.RemoveBlocker(this);
				if (instant)
				{
					canvasGroup.alpha = 0f;
					this.OnIsVisibleChanged?.Invoke();
					return;
				}
				tweenSequencesService.Kill(autoHideSequence);
				tweenSequencesService.Kill(moneySequence);
				tweenSequencesService.Kill(showHideSequence);
				showHideSequence = tweenSequencesService.Create();
				showHideSequence.Append(canvasGroup.DOFade(0f, showHideDuration));
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		public void OnExitEvent()
		{
			Hide();
		}

		private void ResolveCloseButtonClicked()
		{
			Hide();
		}

		public bool PayRegularPayment(CashMoneyObject cashMoneyObject)
		{
			if (regularPaymentObject == null)
			{
				return false;
			}
			if (cashMoneyObject.MoneyAmountHeld < regularPaymentObject.RegularPaymentInfo.Sum)
			{
				return false;
			}
			gameStatistics.ProcessRegularPaymentMade(regularPaymentObject.RegularPaymentInfo);
			vfxService.PlayDestroyEffect(regularPaymentObject.transform);
			regularPaymentObjectService.Destroy(regularPaymentObject);
			regularPaymentObject = null;
			tweenSequencesService.Kill(autoHideSequence);
			autoHideSequence = tweenSequencesService.Create();
			autoHideSequence.Append(billTransform.DOAnchorPosY(billPositionY.Max, moveBillDuration));
			autoHideSequence.AppendCallback(delegate
			{
				billTransform.SetSiblingIndex(envelopeFrontTransform.GetSiblingIndex());
			});
			autoHideSequence.Append(billTransform.DOAnchorPosY(billPositionY.Min, moveBillDuration));
			autoHideSequence.AppendCallback(delegate
			{
				presetSwitcher.ActivatePreset(closePresetName);
			});
			autoHideSequence.Append(paymentTransform.DOScale(Vector3.one * paymentScale, paymentScaleDuration).SetEase(Ease.InBack));
			autoHideSequence.Append(paymentTransform.DOAnchorPosX(paymentPositionX.Max, movePaymentDuration).SetEase(Ease.InBack));
			autoHideSequence.Join(paymentTransform.DOLocalRotate(new Vector3(0f, 0f, rotationPaymentDuration), movePaymentDuration).SetEase(Ease.InBack));
			autoHideSequence.AppendInterval(delayCloseDuration);
			autoHideSequence.AppendCallback(delegate
			{
				Hide();
			});
			return true;
		}

		public void ShowMoney()
		{
			if (isVisible)
			{
				moneyIconTransform.anchoredPosition = new Vector2(moneyIconTransform.anchoredPosition.x, moneyPositionY.Max);
				tweenSequencesService.Kill(moneySequence);
				moneySequence = tweenSequencesService.Create();
				moneySequence.AppendCallback(delegate
				{
					presetSwitcher.ActivatePreset(moneyPresetName);
				});
				moneySequence.Append(moneyIconTransform.DOAnchorPosY(moneyPositionY.Min, moveMoneyDuration));
			}
		}

		public void HideMoney()
		{
			if (isVisible)
			{
				presetSwitcher.ActivatePreset(emptyPresetName);
			}
		}

		private void ResetBill()
		{
			billTransform.anchoredPosition = new Vector2(billTransform.anchoredPosition.x, billPositionY.Min);
			billTransform.SetSiblingIndex(envelopeFrontTransform.GetSiblingIndex() + 1);
		}

		private void ResetPayment()
		{
			paymentTransform.anchoredPosition = new Vector2(paymentPositionX.Min, paymentTransform.anchoredPosition.y);
			paymentTransform.localRotation = Quaternion.identity;
			paymentTransform.localScale = Vector3.one;
		}
	}
}
