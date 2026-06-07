using System;
using DG.Tweening;
using Simulator;
using Simulator.Preview3D;
using TMPro;
using Tabletop.Preview3D;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_MiniaturePaintingPopup : UI_CollectionPopup
	{
		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private GameObject m_container;

		[SerializeField]
		private GameObject m_blocker;

		[Header("Start")]
		[SerializeField]
		private Button m_startButton;

		[SerializeField]
		private TextMeshProUGUI m_startCountdownText;

		[Header("Content")]
		[SerializeField]
		private RawImage m_miniatureImage;

		[SerializeField]
		private TextMeshProUGUI m_scoreText;

		[SerializeField]
		private TextMeshProUGUI m_valueText;

		[SerializeField]
		private TextMeshProUGUI m_valueIncreaseText;

		[SerializeField]
		private NavButton m_backButton;

		[Header("Parameters")]
		[SerializeField]
		private CursorState m_cursor;

		[Header("Undercoat")]
		[Header("Color Mixing Game")]
		[Header("Painting Game")]
		[SerializeField]
		private UI_PaintingGame m_paintingGame;

		[Header("Finitions Game")]
		[Header("Score Screen")]
		[SerializeField]
		private UI_PaintResultScreen m_resultScreen;

		private bool m_focusedBeforeAssemble;

		private bool m_canBeClosed;

		private Sequence m_countdownSeq;

		private Tween m_paintTlTween;

		private Tween m_paintPpTween;

		public int MiniatureUID { get; private set; }

		public MiniatureData MiniatureData { get; private set; }

		public int TotalScore { get; private set; }

		public bool IsPainting { get; private set; }

		public float Progress { get; private set; }

		protected override void OnEnable()
		{
			base.OnEnable();
			Collection.WantsToPaintMiniature += OnStartPaintingMiniature;
			Collection_HUDPopupModule.Closed += OnCloseCollection;
			UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Combine(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnTry));
			UI_BasePaintMiniGame.Completed = (Action<int>)Delegate.Combine(UI_BasePaintMiniGame.Completed, new Action<int>(OnCompletePaintingGame));
			m_resultScreen.Activated += OnActivateResultScreen;
			m_startButton.onClick.AddListener(OnButton_Start);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Collection.WantsToPaintMiniature -= OnStartPaintingMiniature;
			Collection_HUDPopupModule.Closed -= OnCloseCollection;
			UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Remove(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnTry));
			UI_BasePaintMiniGame.Completed = (Action<int>)Delegate.Remove(UI_BasePaintMiniGame.Completed, new Action<int>(OnCompletePaintingGame));
			m_resultScreen.Activated -= OnActivateResultScreen;
			m_startButton.onClick.RemoveListener(OnButton_Start);
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_container.SetActive(value: true);
			m_blocker.SetActive(value: true);
			m_focusedBeforeAssemble = Preview3DManager.Instance.Focused;
			m_canBeClosed = true;
			LockInGame(isLocked: false);
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_countdownSeq.Kill();
			if (IsPainting)
			{
				CursorManager.PopCurrent();
				m_paintingGame.SetActive(active: false);
			}
			LockInGame(isLocked: false);
			m_container.SetActive(value: false);
			m_blocker.SetActive(value: false);
			if (!m_focusedBeforeAssemble)
			{
				Preview3DManager.Instance.Unfocus();
			}
		}

		public override bool CanBeClosed()
		{
			return m_canBeClosed;
		}

		private void SetupStart()
		{
			m_startButton.transform.parent.gameObject.SetActive(value: true);
			m_startCountdownText.enabled = false;
			Material cachedMaterial = PaintingSettings.GetCachedMaterial();
			cachedMaterial.SetFloat(PaintingSettings.TexLerpFactorShaderProperty, 0f);
			cachedMaterial.SetFloat(PaintingSettings.PaintProgressionShaderProperty, 0f);
			RefreshContent();
			m_navBox.SelectFirstChild();
		}

		private void LaunchCountdown()
		{
			m_canBeClosed = false;
			m_startButton.transform.parent.gameObject.SetActive(value: false);
			m_startCountdownText.enabled = true;
			m_startCountdownText.text = "3";
			m_countdownSeq = DOTween.Sequence();
			m_countdownSeq.AppendInterval(1f);
			m_countdownSeq.AppendCallback(delegate
			{
				m_startCountdownText.text = "2";
			});
			m_countdownSeq.AppendInterval(1f);
			m_countdownSeq.AppendCallback(delegate
			{
				m_startCountdownText.text = "1";
			});
			m_countdownSeq.AppendInterval(1f);
			m_countdownSeq.AppendCallback(StartPaintingGame);
			m_countdownSeq.Play();
		}

		private void StartPaintingGame()
		{
			m_startCountdownText.text = "";
			IsPainting = true;
			Progress = 0f;
			m_paintingGame.SetActive(active: true);
		}

		private void RefreshContent()
		{
			m_miniatureImage.uvRect = TabletopPreview3DManager.Instance.GetFocusedMiniatureRect();
			SetAndAnimateText(TotalScore.ToString(), m_scoreText);
			float miniaturePrice = PaintingSettings.GetMiniaturePrice(TotalScore, MiniatureData.MarketPrice);
			float amount = miniaturePrice - MiniatureData.MarketPrice;
			SetAndAnimateText(miniaturePrice.ToStringMoneyFormat(), m_valueText);
			m_valueIncreaseText.text = "+" + amount.ToStringMoneyFormat();
			SetAndAnimateText("+" + amount.ToStringMoneyFormat(), m_valueIncreaseText);
			static void SetAndAnimateText(string text, TextMeshProUGUI textAsset)
			{
				if (!(textAsset.text == text))
				{
					textAsset.text = text;
					JuiceManager.AddBounce(EBouncePresets.GENERIC_TEXT, textAsset.transform);
				}
			}
		}

		private void LockInGame(bool isLocked)
		{
			m_backButton.gameObject.SetActive(!isLocked);
		}

		private void OnButton_Start()
		{
			LockInGame(isLocked: true);
			CursorManager.StackState(m_cursor);
			LaunchCountdown();
		}

		private void OnStartPaintingMiniature(int uid)
		{
			MiniatureUID = uid;
			MiniatureData = MiniatureDatabase.Get(uid);
			TotalScore = 0;
			SetActive(active: true);
			TabletopPreview3DManager.Instance.FocusMiniature(uid, highlightMissingPieces: false);
			TabletopPreview3DManager.Instance.PaintFocusedMiniature(0, whilePainting: true);
			SetupStart();
		}

		private void OnActivateResultScreen(UI_CollectionPopup _, bool active)
		{
			if (!active)
			{
				SetActive(active: false);
			}
		}

		private void OnCloseCollection()
		{
			SetActive(active: false);
		}

		public override void OnCancel()
		{
			if (CanBeClosed())
			{
				base.OnCancel();
			}
		}

		private void OnTry(bool success, int score)
		{
			if (success)
			{
				TotalScore += score;
				Progress += 1f / (float)PaintingSettings.PaintingGameActionsCount;
				RefreshContent();
			}
			else
			{
				Progress += 1f / (float)PaintingSettings.PaintingGameActionsCount;
			}
			ShaderAnimation();
		}

		private void OnCompletePaintingGame(int score)
		{
			TotalScore = Collection.PaintMiniature(MiniatureUID, TotalScore);
			IsPainting = false;
			Progress = 1f;
			RefreshContent();
			CursorManager.PopCurrent();
			Material cachedMaterial = PaintingSettings.GetCachedMaterial();
			cachedMaterial.SetFloat(PaintingSettings.TexLerpFactorShaderProperty, 0f);
			cachedMaterial.SetFloat(PaintingSettings.PaintProgressionShaderProperty, -1f);
			TabletopPreview3DManager.Instance.PaintFocusedMiniature();
			TransientManager<InputManager>.Instance.UIInputModule.submit.action.Enable();
			LockInGame(isLocked: false);
			SelectCloseButton();
			m_canBeClosed = true;
		}

		private void ShaderAnimation()
		{
			m_paintTlTween.Kill();
			m_paintPpTween.Kill();
			Material mat = PaintingSettings.GetCachedMaterial();
			float startValueTl = mat.GetFloat(PaintingSettings.TexLerpFactorShaderProperty);
			float paintLerpFactorByScore = PaintingSettings.GetPaintLerpFactorByScore(TotalScore);
			float startValuePp = mat.GetFloat(PaintingSettings.PaintProgressionShaderProperty);
			float endValue = (IsPainting ? Progress : 1f);
			m_paintTlTween = DOTween.To(() => startValueTl, delegate(float x)
			{
				mat.SetFloat(PaintingSettings.TexLerpFactorShaderProperty, x);
			}, paintLerpFactorByScore, 0.5f).SetEase(Ease.OutQuad);
			m_paintPpTween = DOTween.To(() => startValuePp, delegate(float x)
			{
				mat.SetFloat(PaintingSettings.PaintProgressionShaderProperty, x);
			}, endValue, 0.5f).SetEase(Ease.OutQuad);
		}
	}
}
