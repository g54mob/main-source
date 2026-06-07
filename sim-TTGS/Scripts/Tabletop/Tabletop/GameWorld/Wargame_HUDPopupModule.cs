using System;
using System.Collections.Generic;
using DG.Tweening;
using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class Wargame_HUDPopupModule : TabletopHUDPopupModule
	{
		[Header("Always Present")]
		[SerializeField]
		private TextMeshProUGUI m_roundText;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_playerLifeText;

		[SerializeField]
		private TextMeshProUGUI m_playerBetText;

		[SerializeField]
		private Button m_playerUnbetButton;

		[SerializeField]
		private Image m_playerPriorityImage;

		[SerializeField]
		private LocaVariable[] m_playerDiceEffectsLocaVars;

		[SerializeField]
		private SimulatorText[] m_playerDiceEffectsTexts;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_opponentLifeText;

		[SerializeField]
		private TextMeshProUGUI m_opponentBetText;

		[SerializeField]
		private Image m_opponentPriorityImage;

		[SerializeField]
		private LocaVariable[] m_opponentDiceEffectsLocaVars;

		[SerializeField]
		private SimulatorText[] m_opponentDiceEffectsTexts;

		[Header("Game Phase")]
		[SerializeField]
		private GameObject m_gamePhaseContainer;

		[SerializeField]
		private GameObject m_tokensContainer;

		[SerializeField]
		private SimulatorText m_instructionsText;

		[Space(10f)]
		[SerializeField]
		private Button m_startGameButton;

		[SerializeField]
		private Button m_throwDiceButton;

		[SerializeField]
		private Button m_rethrowDiceButton;

		[SerializeField]
		private NavButton m_validateButton;

		[SerializeField]
		private Button m_nextRoundButton;

		[Space(10f)]
		[SerializeField]
		private Image m_playerActivationImage;

		[SerializeField]
		private Button m_playerBetButton;

		[SerializeField]
		private Image[] m_playerTokens;

		[SerializeField]
		private Image m_playerAssaultBackground;

		[SerializeField]
		private TextMeshProUGUI m_playerAssaultText;

		[SerializeField]
		private TextMeshProUGUI m_playerDamageText;

		[SerializeField]
		private GameObject m_playerMiniaturesActivationContainer;

		[SerializeField]
		private TextMeshProUGUI[] m_playerMiniaturesActivationTexts;

		[SerializeField]
		private UI_WargameMiniatureTooltip[] m_playerMiniaturesTooltips;

		[SerializeField]
		private BounceData m_bounce;

		[Space(10f)]
		[SerializeField]
		private Image m_opponentActivationImage;

		[SerializeField]
		private Image m_opponentAssaultBackground;

		[SerializeField]
		private TextMeshProUGUI m_opponentAssaultText;

		[SerializeField]
		private TextMeshProUGUI m_opponentDamageText;

		[SerializeField]
		private Image[] m_opponentTokens;

		[SerializeField]
		private GameObject m_opponentTokensContainer;

		[SerializeField]
		private GameObject m_opponentMiniaturesActivationContainer;

		[SerializeField]
		private TextMeshProUGUI[] m_opponentMiniaturesActivationTexts;

		[SerializeField]
		private UI_WargameMiniatureTooltip[] m_opponentMiniaturesTooltips;

		[Header("Banner")]
		[SerializeField]
		private CanvasGroup m_bannerGroup;

		[SerializeField]
		private Image m_bannerImage;

		[SerializeField]
		private UI_WargameBannerRoundText m_bannerRoundText;

		[SerializeField]
		private TextMeshProUGUI m_bannerVictoryText;

		[SerializeField]
		private TextMeshProUGUI m_bannerDefeatText;

		[SerializeField]
		private TextMeshProUGUI m_bannerDrawText;

		[Header("Game Over")]
		[SerializeField]
		private GameObject m_gameOverPopup;

		[SerializeField]
		private Button m_playAgainButton;

		[SerializeField]
		private Button m_backToDeckButton;

		[SerializeField]
		private Button m_quitTableButton;

		[SerializeField]
		private UI_MiniaturePieceRewardPopup m_rewardPopup;

		[Header("Quit")]
		[SerializeField]
		private Button m_quitButton;

		[SerializeField]
		private GameObject m_quitPopup;

		[SerializeField]
		private Button m_quitOkButton;

		[SerializeField]
		private Button m_quitCancelButton;

		private WargameMiniature[] m_playerMiniatures;

		private WargameMiniature[] m_opponentMiniatures;

		private WargameDiceAnchor[] m_playerCombinationDiceAnchors;

		private WargameDiceAnchor[] m_opponentCombinationDiceAnchors;

		private List<WargameDice> m_playerDices = new List<WargameDice>();

		private List<WargameDice> m_opponentDices = new List<WargameDice>();

		private int m_rethrowCount;

		private Sequence m_assaultGaugeSequence;

		private Tween m_rewardTween;

		public override ETabletopHUDPopupModuleType ActualType => ETabletopHUDPopupModuleType.WARGAME;

		public override bool HideHUD => true;

		public event Action StartedGame;

		public event Action<List<int>> PlayerRethrewDices;

		public event Action<int, int> PlayerPlacedDice;

		public event Action<bool> PlayerBetToken;

		public event Action PlayerConfirmedDices;

		public event Action CompletedRound;

		protected override void OnEnable()
		{
			base.OnEnable();
			RegisterToUICallbacks(register: true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			RegisterToUICallbacks(register: false);
			m_rewardTween.Kill();
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			InputManager.DeviceChanged += OnDeviceChanged;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			InputManager.DeviceChanged -= OnDeviceChanged;
			TransientManager<InputManager>.Instance.SetVirtualMouseActive(active: false);
		}

		public void InitWargame(WargameSquad squadA, WargameSquad squadB)
		{
			WargameWorkshop currentlyUsed = WargameWorkshop.CurrentlyUsed;
			m_playerMiniatures = new WargameMiniature[squadA.Count];
			for (int i = 0; i < squadA.Count; i++)
			{
				if (squadA.Get(i).Wargame != null)
				{
					m_playerMiniatures[i] = UnityEngine.Object.Instantiate(squadA.Get(i).Wargame, currentlyUsed.GetPlayerMiniatureAnchor(i)).GetComponent<WargameMiniature>();
					m_playerMiniatures[i].Init(belongToPlayer: true, i);
					m_playerMiniaturesTooltips[i].SetContent(squadA.Get(i).Skill, showLifePoints: false);
				}
			}
			m_playerCombinationDiceAnchors = currentlyUsed.GetPlayerDiceAnchors();
			m_opponentMiniatures = new WargameMiniature[squadB.Count];
			for (int j = 0; j < squadB.Count; j++)
			{
				if (squadB.Get(j).Wargame != null)
				{
					m_opponentMiniatures[j] = UnityEngine.Object.Instantiate(squadB.Get(j).Wargame, currentlyUsed.GetOpponentMiniatureAnchor(squadB.Count - j - 1)).GetComponent<WargameMiniature>();
					m_opponentMiniatures[j].Init(belongToPlayer: false, j);
					m_opponentMiniatures[j].Hovered += OnOpponentMiniatureHovered;
					m_opponentMiniaturesTooltips[j].SetContent(squadB.Get(j).Skill, showLifePoints: false);
					m_opponentMiniaturesTooltips[j].SetActive(active: false);
				}
			}
			m_opponentCombinationDiceAnchors = currentlyUsed.GetOpponentDiceAnchors();
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[0], WargameSettings.GetDiceEffect(1).operand);
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[1], WargameSettings.GetDiceEffect(2).operand);
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[2], WargameSettings.GetDiceEffect(3).operand);
			SimulatorText[] playerDiceEffectsTexts = m_playerDiceEffectsTexts;
			for (int k = 0; k < playerDiceEffectsTexts.Length; k++)
			{
				playerDiceEffectsTexts[k].RefreshTerm();
			}
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[0], WargameSettings.GetDiceEffect(1).operand);
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[1], WargameSettings.GetDiceEffect(2).operand);
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[2], WargameSettings.GetDiceEffect(3).operand);
			playerDiceEffectsTexts = m_opponentDiceEffectsTexts;
			for (int k = 0; k < playerDiceEffectsTexts.Length; k++)
			{
				playerDiceEffectsTexts[k].RefreshTerm();
			}
			m_startGameButton.transform.parent.gameObject.SetActive(value: true);
			m_gamePhaseContainer.SetActive(value: false);
			m_bannerGroup.alpha = 0f;
			m_bannerGroup.blocksRaycasts = false;
			m_tokensContainer.SetActive(WargameSettings.UseTokens);
			m_quitPopup.SetActive(value: false);
			m_quitButton.transform.parent.gameObject.SetActive(value: true);
			m_nextRoundButton.transform.parent.gameObject.SetActive(value: false);
			m_gameOverPopup.SetActive(value: false);
			m_playerActivationImage.enabled = false;
			m_playerActivationImage.color = WargameSettings.PlayerActivationColor;
			m_opponentActivationImage.enabled = false;
			m_opponentActivationImage.color = WargameSettings.OpponentActivationColor;
			m_rewardPopup.SetActive(active: false);
		}

		public void UpdateState(WargameState state, EWargamePhase phase)
		{
			if (phase == EWargamePhase.COMBAT)
			{
				m_playerActivationImage.enabled = state.playerAPlaying;
				m_opponentActivationImage.enabled = !state.playerAPlaying;
			}
			else
			{
				m_playerActivationImage.enabled = false;
				m_opponentActivationImage.enabled = false;
			}
			m_playerAssaultText.color = Color.white;
			SetAndAnimateText(state.playerAAssault.ToString(), m_playerAssaultText);
			m_playerDamageText.color = Color.white;
			SetAndAnimateText(state.playerADamage.ToString(), m_playerDamageText, m_playerDamageText.transform.parent);
			m_playerLifeText.color = Color.white;
			SetAndAnimateText(state.playerALife.ToString(), m_playerLifeText);
			for (int i = 0; i < m_playerMiniatures.Length; i++)
			{
				m_playerMiniatures[i].SetState(state.squadAAlive[i] ? (state.playerAActivatedMiniatures[i] ? EWargameMiniatureState.ACTIVE : EWargameMiniatureState.IDLE) : EWargameMiniatureState.DEAD);
			}
			SetAndAnimateText(state.playerABet.ToString(), m_playerBetText);
			m_playerBetButton.interactable = phase == EWargamePhase.DICE && state.playerATokens > 0;
			m_playerUnbetButton.interactable = phase == EWargamePhase.DICE && state.playerABet > 0;
			for (int j = 0; j < m_playerTokens.Length; j++)
			{
				m_playerTokens[j].enabled = j < state.playerATokens;
			}
			m_opponentAssaultText.color = Color.white;
			SetAndAnimateText(state.playerBAssault.ToString(), m_opponentAssaultText);
			m_opponentDamageText.color = Color.white;
			SetAndAnimateText(state.playerBDamage.ToString(), m_opponentDamageText, m_opponentDamageText.transform.parent);
			m_opponentLifeText.color = Color.white;
			SetAndAnimateText(state.playerBLife.ToString(), m_opponentLifeText);
			for (int k = 0; k < m_opponentMiniatures.Length; k++)
			{
				m_opponentMiniatures[k].SetState(state.squadBAlive[k] ? (state.playerBActivatedMiniatures[k] ? EWargameMiniatureState.ACTIVE : EWargameMiniatureState.IDLE) : EWargameMiniatureState.DEAD);
			}
			m_opponentBetText.text = ((phase == EWargamePhase.DICE) ? "?" : state.playerBBet.ToString());
			for (int l = 0; l < m_opponentTokens.Length; l++)
			{
				m_opponentTokens[l].enabled = l < state.playerBTokens;
			}
			UpdateAssaultGauge(state.playerAAssault, state.playerBAssault);
			for (int m = 0; m < m_playerCombinationDiceAnchors.Length; m++)
			{
				if (m_playerCombinationDiceAnchors[m].HasDice)
				{
					m_playerCombinationDiceAnchors[m].Dice.Highlight(phase == EWargamePhase.COMBAT && state.playerAPlaying && state.usedDices.Contains(m));
				}
			}
			for (int n = 0; n < m_opponentCombinationDiceAnchors.Length; n++)
			{
				if (m_opponentCombinationDiceAnchors[n].HasDice)
				{
					m_opponentCombinationDiceAnchors[n].Dice.Highlight(phase == EWargamePhase.COMBAT && !state.playerAPlaying && state.usedDices.Contains(n));
				}
			}
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[0], state.playerADice1Value);
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[1], state.playerADice2Value);
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[2], state.playerADice3Value);
			SimulatorText[] playerDiceEffectsTexts = m_playerDiceEffectsTexts;
			for (int num = 0; num < playerDiceEffectsTexts.Length; num++)
			{
				playerDiceEffectsTexts[num].RefreshTerm();
			}
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[0], state.playerBDice1Value);
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[1], state.playerBDice2Value);
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[2], state.playerBDice3Value);
			playerDiceEffectsTexts = m_opponentDiceEffectsTexts;
			for (int num = 0; num < playerDiceEffectsTexts.Length; num++)
			{
				playerDiceEffectsTexts[num].RefreshTerm();
			}
		}

		private void SetAndAnimateText(string text, TextMeshProUGUI textAsset, Transform tr = null)
		{
			if (!(textAsset.text == text))
			{
				textAsset.text = text;
				m_bounce.PlayBounceCall((tr != null) ? tr : textAsset.transform);
			}
		}

		private void UpdateAssaultGauge(int playerAssault, int opponentAssault)
		{
			if (m_assaultGaugeSequence.IsActive())
			{
				m_assaultGaugeSequence.Kill();
			}
			m_assaultGaugeSequence = DOTween.Sequence();
			m_assaultGaugeSequence.SetUpdate(isIndependentUpdate: true);
			float num = Mathf.Abs(playerAssault) + Mathf.Abs(opponentAssault);
			float endValue;
			float endValue2;
			if (num == 0f || playerAssault == opponentAssault)
			{
				endValue = 190f;
				endValue2 = 190f;
			}
			else if (playerAssault > opponentAssault)
			{
				float num2 = playerAssault - opponentAssault;
				if (num2 < num / 2f)
				{
					num2 += num / 2f;
				}
				float num3 = Mathf.Clamp01(Mathf.Max(playerAssault, num2) / num);
				endValue = Mathf.Lerp(100f, 280f, num3);
				endValue2 = Mathf.Lerp(100f, 280f, 1f - num3);
			}
			else
			{
				float num4 = opponentAssault - playerAssault;
				if (num4 < num / 2f)
				{
					num4 += num / 2f;
				}
				float num5 = Mathf.Clamp01(Mathf.Max(opponentAssault, num4) / num);
				endValue = Mathf.Lerp(100f, 280f, 1f - num5);
				endValue2 = Mathf.Lerp(100f, 280f, num5);
			}
			m_assaultGaugeSequence.Join(DOTween.To(() => m_playerAssaultBackground.rectTransform.sizeDelta.y, delegate(float y)
			{
				m_playerAssaultBackground.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
			}, endValue, 0.5f).SetEase(Ease.OutCirc));
			m_assaultGaugeSequence.Join(DOTween.To(() => m_opponentAssaultBackground.rectTransform.sizeDelta.y, delegate(float y)
			{
				m_opponentAssaultBackground.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
			}, endValue2, 0.5f).SetEase(Ease.OutCirc));
			m_assaultGaugeSequence.Play();
		}

		public void UpdatePreview(WargamePreviewState state)
		{
			m_playerAssaultText.color = (state.playerAAssaultModified ? WargameSettings.PreviewTextColor : Color.white);
			SetAndAnimateText(state.playerAAssault.ToString(), m_playerAssaultText);
			m_playerDamageText.color = (state.playerADamageModified ? WargameSettings.PreviewTextColor : Color.white);
			SetAndAnimateText(state.playerADamage.ToString(), m_playerDamageText);
			m_playerLifeText.color = (state.playerALifeModified ? WargameSettings.PreviewTextColor : Color.white);
			SetAndAnimateText(state.playerALife.ToString(), m_playerLifeText);
			for (int i = 0; i < m_playerMiniatures.Length; i++)
			{
				m_playerMiniatures[i].SetState((!state.squadAAlive[i]) ? EWargameMiniatureState.DEAD : EWargameMiniatureState.IDLE, state.playerAActivatedMiniatures[i]);
			}
			m_playerBetText.text = state.playerABet.ToString();
			for (int j = 0; j < m_playerTokens.Length; j++)
			{
				m_playerTokens[j].enabled = j < state.playerATokens;
			}
			m_opponentAssaultText.color = (state.playerBAssaultModified ? WargameSettings.PreviewTextColor : Color.white);
			SetAndAnimateText(state.playerBAssault.ToString(), m_opponentAssaultText);
			m_opponentDamageText.color = (state.playerBDamageModified ? WargameSettings.PreviewTextColor : Color.white);
			SetAndAnimateText(state.playerBDamage.ToString(), m_opponentDamageText);
			m_opponentLifeText.color = (state.playerBLifeModified ? WargameSettings.PreviewTextColor : Color.white);
			SetAndAnimateText(state.playerBLife.ToString(), m_opponentLifeText);
			for (int k = 0; k < m_opponentMiniatures.Length; k++)
			{
				m_opponentMiniatures[k].SetState((!state.squadBAlive[k]) ? EWargameMiniatureState.DEAD : EWargameMiniatureState.IDLE, state.knowOpponentDices ? state.playerBActivatedMiniatures[k] : 0);
			}
			m_opponentBetText.text = "?";
			for (int l = 0; l < m_opponentTokens.Length; l++)
			{
				m_opponentTokens[l].enabled = l < state.playerBTokens;
			}
			UpdateAssaultGauge(state.playerAAssault, state.playerBAssault);
			for (int m = 0; m < state.playerAActivatedMiniatures.Length; m++)
			{
				m_playerMiniaturesActivationTexts[m].color = WargameSettings.PreviewTextColor;
				SetAndAnimateText(state.playerAActivatedMiniatures[m].ToString(), m_playerMiniaturesActivationTexts[m], m_playerMiniaturesActivationTexts[m].transform.parent);
			}
			for (int n = 0; n < state.playerBActivatedMiniatures.Length; n++)
			{
				if (state.knowOpponentDices)
				{
					m_opponentMiniaturesActivationTexts[n].color = WargameSettings.PreviewTextColor;
					SetAndAnimateText(state.playerBActivatedMiniatures[n].ToString(), m_opponentMiniaturesActivationTexts[n], m_opponentMiniaturesActivationTexts[n].transform.parent);
					m_opponentMiniaturesActivationTexts[n].enabled = true;
				}
				else
				{
					m_opponentMiniaturesActivationTexts[n].enabled = false;
				}
			}
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[0], state.playerADice1Value);
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[1], state.playerADice2Value);
			LocaVariableDatabase.SetVariableValue(m_playerDiceEffectsLocaVars[2], state.playerADice3Value);
			SimulatorText[] playerDiceEffectsTexts = m_playerDiceEffectsTexts;
			for (int num = 0; num < playerDiceEffectsTexts.Length; num++)
			{
				playerDiceEffectsTexts[num].RefreshTerm();
			}
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[0], state.playerBDice1Value);
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[1], state.playerBDice2Value);
			LocaVariableDatabase.SetVariableValue(m_opponentDiceEffectsLocaVars[2], state.playerBDice3Value);
			playerDiceEffectsTexts = m_opponentDiceEffectsTexts;
			for (int num = 0; num < playerDiceEffectsTexts.Length; num++)
			{
				playerDiceEffectsTexts[num].RefreshTerm();
			}
		}

		public void InitDicePhase()
		{
			foreach (WargameDice playerDix in m_playerDices)
			{
				UnityEngine.Object.Destroy(playerDix.gameObject);
			}
			m_playerDices.Clear();
			foreach (WargameDice opponentDix in m_opponentDices)
			{
				UnityEngine.Object.Destroy(opponentDix.gameObject);
			}
			m_opponentDices.Clear();
			for (int i = 0; i < m_playerCombinationDiceAnchors.Length; i++)
			{
				m_playerCombinationDiceAnchors[i].Clear();
				m_playerCombinationDiceAnchors[i].DicePlaced += OnDicePlaced;
			}
			for (int j = 0; j < m_opponentCombinationDiceAnchors.Length; j++)
			{
				m_opponentCombinationDiceAnchors[j].Clear();
			}
			m_gamePhaseContainer.SetActive(value: true);
			m_playerBetText.text = "0";
			m_opponentBetText.text = "?";
			m_opponentTokensContainer.SetActive(value: false);
			m_playerMiniaturesActivationContainer.SetActive(value: false);
			TextMeshProUGUI[] playerMiniaturesActivationTexts = m_playerMiniaturesActivationTexts;
			for (int k = 0; k < playerMiniaturesActivationTexts.Length; k++)
			{
				playerMiniaturesActivationTexts[k].text = "0";
			}
			m_opponentMiniaturesActivationContainer.SetActive(value: false);
			playerMiniaturesActivationTexts = m_opponentMiniaturesActivationTexts;
			for (int k = 0; k < playerMiniaturesActivationTexts.Length; k++)
			{
				playerMiniaturesActivationTexts[k].enabled = false;
			}
			m_throwDiceButton.transform.parent.gameObject.SetActive(value: true);
			m_rethrowDiceButton.transform.parent.gameObject.SetActive(value: false);
			m_validateButton.SetInteractable(value: false);
			m_rethrowCount = 0;
			m_instructionsText.Text.enabled = true;
			m_instructionsText.SetTerm(WargameSettings.GetInstructionTerm(EWargameInstruction.THROW_DICES));
			m_playerActivationImage.enabled = false;
			m_opponentActivationImage.enabled = false;
		}

		public void InitCombinations(int playerCombinationSize, int opponentCombinationSize)
		{
			for (int i = 0; i < m_playerCombinationDiceAnchors.Length; i++)
			{
				m_playerCombinationDiceAnchors[i].gameObject.SetActive(i < playerCombinationSize);
			}
			for (int j = 0; j < m_opponentCombinationDiceAnchors.Length; j++)
			{
				m_opponentCombinationDiceAnchors[j].gameObject.SetActive(j < opponentCombinationSize);
			}
		}

		public void DisplayAvailableDices(int diceIndex, int diceValue)
		{
			WargameDice component = UnityEngine.Object.Instantiate(WargameSettings.DicePrefab, WargameWorkshop.CurrentlyUsed.GetThrowOrigin()).GetComponent<WargameDice>();
			m_playerDices.Add(component);
			component.Init(diceValue, showRenderer: false);
		}

		public void AIPlaceDice(int combinationIndex, int diceValue, bool show)
		{
			WargameDice component = UnityEngine.Object.Instantiate(WargameSettings.OpponentDicePrefab, m_opponentCombinationDiceAnchors[combinationIndex].transform).GetComponent<WargameDice>();
			m_opponentDices.Add(component);
			component.Init(diceValue, show);
			m_opponentCombinationDiceAnchors[combinationIndex].Init(component);
		}

		public void RethrowDice(int diceIndex, int diceValue)
		{
			m_playerDices[diceIndex].Rethrow(WargameWorkshop.CurrentlyUsed.GetThrowOrigin().position, diceValue);
		}

		public void BetToken(bool player, int bet, int left)
		{
			if (player)
			{
				m_playerBetText.text = bet.ToString();
				m_playerBetButton.interactable = left > 0;
				m_playerUnbetButton.interactable = bet > 0;
				for (int i = 0; i < m_playerTokens.Length; i++)
				{
					m_playerTokens[i].enabled = i < left;
				}
			}
			else
			{
				m_opponentBetText.text = "?";
				for (int j = 0; j < m_opponentTokens.Length; j++)
				{
					m_opponentTokens[j].enabled = j < left;
				}
			}
		}

		private void ShowOpponentDices(bool show)
		{
			foreach (WargameDice opponentDix in m_opponentDices)
			{
				opponentDix.Show(show);
			}
		}

		public void InitCombatPhase()
		{
			m_playerBetButton.interactable = false;
			m_playerUnbetButton.interactable = false;
			m_validateButton.SetInteractable(value: false);
			m_instructionsText.Text.enabled = false;
			m_opponentTokensContainer.SetActive(value: true);
			m_rethrowDiceButton.transform.parent.gameObject.SetActive(value: false);
			foreach (WargameDice playerDix in m_playerDices)
			{
				playerDix.EnableDragging(enable: false);
			}
			foreach (WargameDice opponentDix in m_opponentDices)
			{
				opponentDix.EnableDragging(enable: false);
			}
			ShowOpponentDices(show: true);
			ParentPlayerDicesToAnchor();
		}

		public void OnCompleteCombatPhase()
		{
			m_playerMiniaturesActivationContainer.SetActive(value: false);
			m_opponentMiniaturesActivationContainer.SetActive(value: false);
		}

		public void EnableNextRound()
		{
			m_nextRoundButton.transform.parent.gameObject.SetActive(value: true);
		}

		public void DisplayRoundAndPriority(int round, bool playerHasPriority)
		{
			m_roundText.text = round + "/" + WargameSettings.RoundCount;
			m_bannerImage.sprite = WargameSettings.GetBannerSpriteForResult(EWargameResult.DRAW);
			m_bannerRoundText.SetRoundValue(round);
			m_bannerVictoryText.gameObject.SetActive(value: false);
			m_bannerDefeatText.enabled = false;
			m_bannerDrawText.enabled = false;
			m_playerPriorityImage.enabled = playerHasPriority;
			m_opponentPriorityImage.enabled = !playerHasPriority;
			m_bannerGroup.blocksRaycasts = true;
			Sequence sequence = DOTween.Sequence();
			sequence.Append(m_bannerGroup.DOFade(1f, 0.2f));
			sequence.AppendInterval(1f);
			sequence.Append(m_bannerGroup.DOFade(0f, 0.1f));
			sequence.AppendCallback(delegate
			{
				m_bannerGroup.blocksRaycasts = false;
			});
			sequence.SetUpdate(isIndependentUpdate: true);
			sequence.Play();
		}

		public void DisplayRoundResult(EWargameResult result)
		{
			m_bannerGroup.blocksRaycasts = true;
			m_bannerImage.sprite = WargameSettings.GetBannerSpriteForResult(EWargameResult.DRAW);
			m_bannerVictoryText.gameObject.SetActive(value: false);
			m_bannerDefeatText.enabled = false;
			m_bannerDrawText.enabled = false;
			m_bannerRoundText.SetRoundResult(result);
			Sequence sequence = DOTween.Sequence();
			sequence.Append(m_bannerGroup.DOFade(1f, WargameSettings.DelayBetweenRounds * 0.1f));
			sequence.AppendInterval(WargameSettings.DelayBetweenRounds * 0.8f);
			sequence.Append(m_bannerGroup.DOFade(0f, WargameSettings.DelayBetweenRounds * 0.1f));
			sequence.AppendCallback(delegate
			{
				m_bannerGroup.blocksRaycasts = false;
			});
			sequence.SetUpdate(isIndependentUpdate: true);
			sequence.Play();
			WargameMiniature[] playerMiniatures = m_playerMiniatures;
			for (int num = 0; num < playerMiniatures.Length; num++)
			{
				playerMiniatures[num].ForceResetAura();
			}
			playerMiniatures = m_opponentMiniatures;
			for (int num = 0; num < playerMiniatures.Length; num++)
			{
				playerMiniatures[num].ForceResetAura();
			}
		}

		public void DisplayGameOver(EWargameResult result)
		{
			m_quitButton.transform.parent.gameObject.SetActive(value: false);
			m_gamePhaseContainer.SetActive(value: false);
			m_bannerGroup.alpha = 1f;
			m_bannerGroup.blocksRaycasts = true;
			SetBannerContent(result);
			if (result == EWargameResult.PLAYER_B)
			{
				m_gameOverPopup.SetActive(value: true);
			}
		}

		private void SetBannerContent(EWargameResult result)
		{
			m_bannerImage.sprite = WargameSettings.GetBannerSpriteForResult(result);
			m_bannerRoundText.SetEnabled(value: false);
			switch (result)
			{
			case EWargameResult.PLAYER_A:
				m_bannerVictoryText.gameObject.SetActive(value: true);
				m_bannerDefeatText.enabled = false;
				m_bannerDrawText.enabled = false;
				break;
			case EWargameResult.PLAYER_B:
				m_bannerVictoryText.gameObject.SetActive(value: false);
				m_bannerDefeatText.enabled = true;
				m_bannerDrawText.enabled = false;
				break;
			case EWargameResult.DRAW:
				m_bannerVictoryText.gameObject.SetActive(value: false);
				m_bannerDefeatText.enabled = false;
				m_bannerDrawText.enabled = true;
				break;
			}
		}

		public void ShowReward(MiniaturePieceData pieceData)
		{
			m_rewardPopup.SetContent(pieceData);
			m_rewardTween = DOVirtual.DelayedCall(2f, ShowReward).Play();
		}

		private void ShowReward()
		{
			m_rewardPopup.SetActive(active: true);
			m_gameOverPopup.SetActive(value: true);
		}

		private void RegisterToUICallbacks(bool register)
		{
			if (register)
			{
				m_startGameButton.onClick.AddListener(OnStartGame);
				m_throwDiceButton.onClick.AddListener(OnThrowDices);
				m_rethrowDiceButton.onClick.AddListener(OnReThrowDices);
				m_playerBetButton.onClick.AddListener(OnTryBetToken);
				m_playerUnbetButton.onClick.AddListener(OnTryUnbetToken);
				m_validateButton.Button.onClick.AddListener(OnButtonValidate);
				m_nextRoundButton.onClick.AddListener(OnButtonNextRound);
				m_playAgainButton.onClick.AddListener(OnButtonPlayAgain);
				m_backToDeckButton.onClick.AddListener(OnButtonBackToDeck);
				m_quitTableButton.onClick.AddListener(base.Validate);
				m_quitButton.onClick.AddListener(OnTryQuit);
				m_quitOkButton.onClick.AddListener(base.Validate);
				m_quitCancelButton.onClick.AddListener(OnCancelQuit);
			}
			else
			{
				m_startGameButton.onClick.RemoveListener(OnStartGame);
				m_throwDiceButton.onClick.RemoveListener(OnThrowDices);
				m_rethrowDiceButton.onClick.RemoveListener(OnReThrowDices);
				m_playerBetButton.onClick.RemoveListener(OnTryBetToken);
				m_playerUnbetButton.onClick.RemoveListener(OnTryUnbetToken);
				m_validateButton.Button.onClick.RemoveListener(OnButtonValidate);
				m_nextRoundButton.onClick.RemoveListener(OnButtonNextRound);
				m_playAgainButton.onClick.RemoveListener(OnButtonPlayAgain);
				m_backToDeckButton.onClick.RemoveListener(OnButtonBackToDeck);
				m_quitTableButton.onClick.RemoveListener(base.Validate);
				m_quitButton.onClick.RemoveListener(OnTryQuit);
				m_quitOkButton.onClick.RemoveListener(base.Validate);
				m_quitCancelButton.onClick.RemoveListener(OnCancelQuit);
			}
		}

		private void OnStartGame()
		{
			m_startGameButton.transform.parent.gameObject.SetActive(value: false);
			WargameWorkshop.CurrentlyUsed.ShowDiceAnchors();
			this.StartedGame?.Invoke();
		}

		private void OnThrowDices()
		{
			m_throwDiceButton.transform.parent.gameObject.SetActive(value: false);
			for (int i = 0; i < m_playerDices.Count; i++)
			{
				m_playerDices[i].Throw(WargameWorkshop.CurrentlyUsed.GetPlayerFreeDiceAnchor(i).position);
			}
			if (WargameSettings.Rethrow > 0)
			{
				m_rethrowDiceButton.transform.parent.gameObject.SetActive(value: true);
			}
			m_validateButton.SetInteractable(WargameSettings.AllowIncompleteValidation);
			m_playerMiniaturesActivationContainer.SetActive(value: true);
			m_opponentMiniaturesActivationContainer.SetActive(value: true);
			m_instructionsText.SetTerm(WargameSettings.GetInstructionTerm(EWargameInstruction.SELECT_DICES));
		}

		private void OnReThrowDices()
		{
			m_rethrowCount++;
			if (m_rethrowCount >= WargameSettings.Rethrow)
			{
				m_rethrowDiceButton.transform.parent.gameObject.SetActive(value: false);
			}
			List<int> list = new List<int>();
			for (int i = 0; i < m_playerDices.Count; i++)
			{
				if (!m_playerDices[i].Anchored)
				{
					list.Add(i);
				}
			}
			this.PlayerRethrewDices?.Invoke(list);
		}

		private void OnDicePlaced(int combinationIndex, int diceValue)
		{
			this.PlayerPlacedDice?.Invoke(combinationIndex, diceValue);
			if (!WargameSettings.AllowIncompleteValidation)
			{
				for (int i = 0; i < m_playerCombinationDiceAnchors.Length; i++)
				{
					if (!m_playerCombinationDiceAnchors[i].HasDice)
					{
						m_validateButton.SetInteractable(value: false);
						m_instructionsText.SetTerm(WargameSettings.GetInstructionTerm(EWargameInstruction.SELECT_DICES));
						return;
					}
				}
			}
			m_validateButton.SetInteractable(value: true);
			m_instructionsText.SetTerm(WargameSettings.GetInstructionTerm(EWargameInstruction.VALIDATE_DICES));
		}

		private void OnTryBetToken()
		{
			this.PlayerBetToken?.Invoke(obj: true);
		}

		private void OnTryUnbetToken()
		{
			this.PlayerBetToken?.Invoke(obj: false);
		}

		private void OnButtonValidate()
		{
			this.PlayerConfirmedDices?.Invoke();
		}

		private void OnButtonNextRound()
		{
			m_nextRoundButton.transform.parent.gameObject.SetActive(value: false);
			this.CompletedRound?.Invoke();
		}

		private void OnButtonPlayAgain()
		{
			TabletopWorld.WargameManager.RestartWargame();
		}

		private void OnButtonBackToDeck()
		{
			TabletopWorld.WargameManager.CompleteWargame(backToDeck: true);
		}

		private void OnTryQuit()
		{
			m_quitPopup.SetActive(value: true);
		}

		private void OnCancelQuit()
		{
			m_quitPopup.SetActive(value: false);
		}

		private void OnOpponentMiniatureHovered(WargameMiniature miniature)
		{
			m_opponentMiniaturesTooltips[miniature.Index].SetActive(miniature.IsHovered);
		}

		protected override void OnValidated()
		{
			base.OnValidated();
			TabletopWorld.WargameManager.CompleteWargame(backToDeck: false);
		}

		public override bool OverrideCancel()
		{
			if (m_gameOverPopup.activeSelf)
			{
				return false;
			}
			if (m_quitPopup.activeSelf)
			{
				OnCancelQuit();
			}
			else
			{
				OnTryQuit();
			}
			return true;
		}

		public void PrepareDestruction()
		{
			foreach (WargameDice playerDix in m_playerDices)
			{
				UnityEngine.Object.Destroy(playerDix.gameObject);
			}
			m_playerDices.Clear();
			WargameMiniature[] playerMiniatures = m_playerMiniatures;
			for (int i = 0; i < playerMiniatures.Length; i++)
			{
				UnityEngine.Object.Destroy(playerMiniatures[i].gameObject);
			}
			playerMiniatures = m_opponentMiniatures;
			foreach (WargameMiniature obj in playerMiniatures)
			{
				obj.Hovered -= OnOpponentMiniatureHovered;
				UnityEngine.Object.Destroy(obj.gameObject);
			}
			for (int j = 0; j < m_playerCombinationDiceAnchors.Length; j++)
			{
				m_playerCombinationDiceAnchors[j].DicePlaced -= OnDicePlaced;
			}
		}

		private void ParentPlayerDicesToAnchor()
		{
			for (int i = 0; i < m_playerCombinationDiceAnchors.Length; i++)
			{
				m_playerCombinationDiceAnchors[i].ParentDice();
			}
		}

		private void OnDeviceChanged(EInputDeviceType device)
		{
			TransientManager<InputManager>.Instance.SetVirtualMouseActive(device == EInputDeviceType.GAMEPAD);
		}
	}
}
