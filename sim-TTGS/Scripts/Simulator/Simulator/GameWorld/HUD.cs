using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class HUD : ControllerComponent
	{
		[Header("HUD")]
		[SerializeField]
		private Canvas m_canvas;

		[Header("Main Components")]
		[SerializeField]
		private Image m_crosshair;

		[SerializeField]
		private TextMeshProUGUI m_moneyText;

		[SerializeField]
		private TextMeshProUGUI m_timeText;

		[SerializeField]
		private Image m_timeIconImage;

		[SerializeField]
		private Sprite m_daySprite;

		[SerializeField]
		private Sprite m_nightSprite;

		[SerializeField]
		private TextMeshProUGUI m_shopLevelText;

		[SerializeField]
		private Image m_xpImage;

		[SerializeField]
		private Image m_hold;

		[SerializeField]
		private HUDTooltip m_tooltip;

		[SerializeField]
		private HUDProductTooltip m_productTooltip;

		[Header("Inputs")]
		[SerializeField]
		private GameObject m_inputsContainer;

		[SerializeField]
		private UI_InputHintCompanion m_inputHintCompanionPrefab;

		[SerializeField]
		private InputHint m_nightTextInputHint;

		private readonly UI_InputHintCompanion[] m_inputHints = new UI_InputHintCompanion[4];

		private Sequence m_holdFillAmountSequence;

		private Tween m_tween;

		private void Start()
		{
			SetHoldFillAmount(0f);
			InitializeInputs();
			HideTooltip();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			RegisterInfosCallbacks(register: true);
			EventManager.OnGameEvent += OnGameEvent;
			EventManager.OnWorldEvent += OnWorldEvent;
			InputManager.MapChanged += OnInputMapChanged;
			GraphicsApplicationOptions.Crosshair.OnValueChanged += OnCrosshairValueChanged_UpdateCrosshair;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			RegisterInfosCallbacks(register: false);
			EventManager.OnGameEvent -= OnGameEvent;
			EventManager.OnWorldEvent -= OnWorldEvent;
			InputManager.MapChanged -= OnInputMapChanged;
			GraphicsApplicationOptions.Crosshair.OnValueChanged -= OnCrosshairValueChanged_UpdateCrosshair;
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_canvas.enabled = true;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_canvas.enabled = false;
		}

		private void RegisterInfosCallbacks(bool register)
		{
			if (register)
			{
				GameState.MoneyAmountChanged += OnMoneyAmountChanged;
				GameState.XPChanged += OnXPChanged;
				GameState.ShopLevelChanged += OnShopLevelChanged;
				TimeController.TimeChanged += OnTimeChanged;
				Shop.GotEmpty += OnShopEmpty;
				GameplayApplicationOptions.Currency.OnValueChanged += OnCurrencyValueChanged;
			}
			else
			{
				GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
				GameState.XPChanged -= OnXPChanged;
				GameState.ShopLevelChanged -= OnShopLevelChanged;
				TimeController.TimeChanged -= OnTimeChanged;
				Shop.GotEmpty -= OnShopEmpty;
				GameplayApplicationOptions.Currency.OnValueChanged += OnCurrencyValueChanged;
			}
		}

		private void OnGameEvent(EGameEvent gameEvent)
		{
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				OnDayStart();
				break;
			case EGameEvent.DAY_END:
				HideInputs();
				break;
			case EGameEvent.NIGHT:
				OnNight();
				break;
			case EGameEvent.OPEN_SHOP:
			case EGameEvent.CLOSE_SHOP:
				TryShowNightInput();
				break;
			case EGameEvent.EVENING:
				break;
			}
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.INITIALISATION:
				World.PlayerCharacter.OnHoldInputProcess += PlayerCharacterOnHoldInputProcess;
				World.PlayerCharacter.OnHoldInputCancel += PlayerCharacterOnHoldInputCancel;
				break;
			case EWorldEvent.START:
				TryEnableCrosshair();
				TryShowNightInput();
				break;
			case EWorldEvent.PREPARE_QUIT:
				World.PlayerCharacter.OnHoldInputProcess -= PlayerCharacterOnHoldInputProcess;
				World.PlayerCharacter.OnHoldInputCancel -= PlayerCharacterOnHoldInputCancel;
				break;
			}
		}

		private void OnCrosshairValueChanged_UpdateCrosshair(bool value)
		{
			TryEnableCrosshair();
		}

		private bool CanEnableCrosshair()
		{
			if (!GraphicsApplicationOptions.Crosshair)
			{
				return false;
			}
			if (TransientManager<InputManager>.Instance.CurrentMap != InputManager.EMap.PLAYER)
			{
				return false;
			}
			return true;
		}

		private void TryEnableCrosshair()
		{
			m_crosshair.enabled = CanEnableCrosshair();
		}

		private void InitializeInputs()
		{
			for (int i = 0; i < m_inputHints.Length; i++)
			{
				if (m_inputHints[i] == null)
				{
					m_inputHints[i] = Object.Instantiate(m_inputHintCompanionPrefab, m_inputsContainer.transform);
				}
			}
			HideInputs();
		}

		public void ShowInputs(InputHint.DisplayData[] displayDatas)
		{
			for (int i = 0; i < displayDatas.Length; i++)
			{
				UI_InputHintCompanion uI_InputHintCompanion = m_inputHints[i];
				if (uI_InputHintCompanion != null)
				{
					uI_InputHintCompanion.gameObject.SetActive(value: true);
					uI_InputHintCompanion.Setup(displayDatas[i]);
				}
			}
		}

		public void HideInputs()
		{
			for (int i = 0; i < m_inputHints.Length; i++)
			{
				if (m_inputHints[i] != null)
				{
					m_inputHints[i].gameObject.SetActive(value: false);
				}
			}
		}

		private void StartHoldFillAmount(float duration)
		{
			DoSetHoldFillAmount(1f, duration);
		}

		private void StopHoldFillAmount(float duration)
		{
			DoSetHoldFillAmount(0f, duration);
		}

		private void DoSetHoldFillAmount(float endValue, float duration)
		{
			duration = Mathf.Abs(m_hold.fillAmount - endValue) * duration;
			m_holdFillAmountSequence?.Kill();
			m_holdFillAmountSequence = DOTween.Sequence();
			m_holdFillAmountSequence.Append(m_hold.DOFade(1f, HUDSettings.HoldInteractionFadeInDuration));
			m_holdFillAmountSequence.Insert(0f, m_hold.DOFillAmount(endValue, duration));
			m_holdFillAmountSequence.Append(m_hold.DOFade(0f, HUDSettings.HoldInteractionFadeOutDuration));
			m_holdFillAmountSequence.OnComplete(HoldFillAmountSequenceCleanup);
			m_holdFillAmountSequence.Play();
		}

		private void HoldFillAmountSequenceCleanup()
		{
			m_holdFillAmountSequence?.Kill();
			m_holdFillAmountSequence = null;
		}

		private void SetHoldFillAmount(float amount)
		{
			m_hold.fillAmount = amount;
		}

		private void PlayerCharacterOnHoldInputProcess(InputManager.ESide side)
		{
			m_tween?.Kill();
			m_tween = DOVirtual.DelayedCall(GetTapDuration(side), delegate
			{
				StartHoldFillAmount(GetHoldDuration(side) - GetTapDuration(side));
			});
			m_tween.Play();
		}

		private void PlayerCharacterOnHoldInputCancel(InputManager.ESide side)
		{
			m_tween?.Kill();
			PlayerCharacter playerCharacter = World.PlayerCharacter;
			if (playerCharacter.MainHoldInteractableStarted || playerCharacter.SecondHoldInteractableStarted)
			{
				SetHoldFillAmount(0f);
			}
			else
			{
				StopHoldFillAmount(GetHoldDuration(side));
			}
		}

		private float GetHoldDuration(InputManager.ESide side)
		{
			return side switch
			{
				InputManager.ESide.MAIN => TransientManager<InputManager>.Instance.MainHoldInteractionDuration, 
				InputManager.ESide.SECOND => TransientManager<InputManager>.Instance.ThirdInteractionDuration, 
				InputManager.ESide.JUMP => TransientManager<InputManager>.Instance.JumpHoldInteractionDuration, 
				_ => InputSystem.settings.defaultHoldTime, 
			};
		}

		private float GetTapDuration(InputManager.ESide side)
		{
			return side switch
			{
				InputManager.ESide.MAIN => TransientManager<InputManager>.Instance.MainTapInteractionDuration, 
				InputManager.ESide.SECOND => TransientManager<InputManager>.Instance.SecondTapInteractionDuration, 
				_ => InputSystem.settings.defaultTapTime, 
			};
		}

		protected virtual void OnMoneyAmountChanged(float _)
		{
			m_moneyText.text = GameState.MoneyAmount.ToStringMoneyFormat();
		}

		protected virtual void OnTimeChanged(DayTime time)
		{
			m_timeText.text = time.ToString();
		}

		protected virtual void OnDayStart()
		{
			m_timeIconImage.sprite = m_daySprite;
			m_nightTextInputHint.enabled = false;
		}

		protected virtual void OnNight()
		{
			m_timeIconImage.sprite = m_nightSprite;
			TryShowNightInput();
		}

		protected virtual void OnXPChanged(int type, float normalizedXP)
		{
			if (type == 0)
			{
				m_xpImage.fillAmount = Mathf.Clamp01(normalizedXP);
			}
		}

		protected virtual void OnShopLevelChanged(int shopLevel)
		{
			m_shopLevelText.text = shopLevel.ToString();
		}

		private void OnCurrencyValueChanged(GameplayApplicationOptions.ECurrency _)
		{
			OnMoneyAmountChanged(0f);
		}

		protected virtual void OnInputMapChanged(InputManager.EMap map)
		{
			TryEnableCrosshair();
		}

		protected virtual void OnShopEmpty()
		{
			TryShowNightInput();
		}

		private void ToggleTooltip(bool show, string key = null)
		{
			if (show)
			{
				m_tooltip.ShowTooltip(key);
			}
			else
			{
				m_tooltip.HideTooltip();
			}
		}

		public static void ShowTooltip(string key)
		{
			if (PlayerHUDIsValid() && !string.IsNullOrEmpty(key))
			{
				World.PlayerController.Hud.ToggleTooltip(show: true, key);
			}
		}

		public static void HideTooltip()
		{
			if (PlayerHUDIsValid())
			{
				World.PlayerController.Hud.ToggleTooltip(show: false);
			}
		}

		private void ToggleProductTooltip(bool show, ProductData data = null)
		{
			if (show)
			{
				m_productTooltip.ShowTooltip(data);
			}
			else
			{
				m_productTooltip.HideTooltip();
			}
		}

		public static void ShowProductTooltip(ProductData data)
		{
			if (PlayerHUDIsValid())
			{
				World.PlayerController.Hud.ToggleProductTooltip(show: true, data);
			}
		}

		public static void HideProductTooltip()
		{
			if (PlayerHUDIsValid())
			{
				World.PlayerController.Hud.ToggleProductTooltip(show: false);
			}
		}

		private static bool PlayerHUDIsValid()
		{
			if (World.PlayerController != null)
			{
				return World.PlayerController.Hud != null;
			}
			return false;
		}

		protected virtual void TryShowNightInput()
		{
			m_nightTextInputHint.enabled = World.CanEndDay();
		}
	}
}
