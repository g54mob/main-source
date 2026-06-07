using DG.Tweening;
using Presentation.UI;
using Presentation.UI.Objectives;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeItemView : MonoBehaviour
{
	private enum EGlowState
	{
		Disabled = 0,
		Active = 1,
		Completed = 2
	}

	[Header("UI References")]
	[SerializeField]
	private TextMeshProUGUI _tierText;

	[SerializeField]
	private GameObject _tierIcon;

	[SerializeField]
	private CanvasGroup _viewCanvasGroup;

	[SerializeField]
	private Image _background;

	[SerializeField]
	private Image _border;

	[SerializeField]
	private Image _glow;

	[SerializeField]
	private GameObject _backgroundTop;

	[SerializeField]
	private ChallengeRewardLabels _challengeRewardLabels;

	[SerializeField]
	private AdvancedTextInfoPanelContent _infoPanel;

	[SerializeField]
	private Color _borderColorNormal;

	[SerializeField]
	private Color _borderColorDisabled;

	[SerializeField]
	private Color _glowColorActive;

	[SerializeField]
	private Color _glowColorGold;

	private bool _isPlayingClaimAnimation;

	private string _categoryNameLocaKey;

	private int _tier;

	private EGlowState _glowState;

	private EGlowState GlowState
	{
		set
		{
			if (value == _glowState)
			{
				return;
			}
			_glow.DOKill();
			_glowState = value;
			switch (value)
			{
			case EGlowState.Disabled:
				_glow.gameObject.SetActive(value: false);
				break;
			case EGlowState.Active:
				_glow.color = _glowColorActive;
				_glow.gameObject.SetActive(value: true);
				_glow.DOFade(0.7f, 0.5f).From(0.2f).SetLoops(-1, LoopType.Yoyo);
				break;
			case EGlowState.Completed:
				if (_tier == 2)
				{
					_glow.color = _glowColorGold;
					_glow.gameObject.SetActive(value: true);
				}
				else
				{
					_glow.gameObject.SetActive(value: false);
				}
				break;
			}
		}
	}

	private void OnDestroy()
	{
		LocalizationUtility.OnLanguageUpdate -= UpdateTexts;
	}

	public void Build(ObjectiveTargetItem item, int tier)
	{
		LocalizationUtility.OnLanguageUpdate += UpdateTexts;
		_tier = tier;
		_challengeRewardLabels.Build(item, tier);
		_tierText.SetText((tier + 1).ToString());
		_tierIcon.SetActive(tier == 2);
		_tierText.gameObject.SetActive(tier < 2);
		SetHidden(isHidden: true);
		UpdateTexts();
	}

	private void UpdateTexts()
	{
		_infoPanel.UpdateText1(LocalizationUtility.GetLocalizedText("ModuleChallenges.Delivered"));
	}

	public void SetViewDefault()
	{
		GlowState = EGlowState.Disabled;
		_challengeRewardLabels.SetRewarded(value: false, _tier);
		SetHidden(isHidden: true);
	}

	public void SetViewCurrent(ObjectiveTargetItem item, uint deliveredAmount)
	{
		GlowState = EGlowState.Active;
		_challengeRewardLabels.SetRewarded(value: false, _tier);
		SetHidden(isHidden: false);
		_background.fillAmount = (float)deliveredAmount / (float)item.Amount;
		if (_infoPanel.enabled)
		{
			_infoPanel.UpdateText2(deliveredAmount + "/" + item.Amount);
			_infoPanel.ForceUpdate();
		}
	}

	public void SetViewClaimed(ObjectiveTargetItem item)
	{
		GlowState = EGlowState.Completed;
		_challengeRewardLabels.SetRewarded(value: true, _tier);
		SetHidden(isHidden: false);
		_background.fillAmount = 1f;
		if (_infoPanel.enabled)
		{
			_infoPanel.UpdateText2(item.Amount + "/" + item.Amount);
		}
	}

	public void SetHidden(bool isHidden)
	{
		_viewCanvasGroup.alpha = (isHidden ? 0.3f : 1f);
		_backgroundTop.gameObject.SetActive(!isHidden);
		_background.enabled = !isHidden;
		_border.color = (isHidden ? _borderColorDisabled : _borderColorNormal);
		_infoPanel.enabled = !isHidden;
	}
}
