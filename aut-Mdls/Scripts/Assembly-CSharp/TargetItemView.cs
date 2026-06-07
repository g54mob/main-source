using DG.Tweening;
using Presentation.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetItemView : MonoBehaviour
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
	private TextMeshProUGUI _rewardText;

	[SerializeField]
	private CanvasGroup _viewCanvasGroup;

	[SerializeField]
	private Image _background;

	[SerializeField]
	private GameObject _backgroundTop;

	[SerializeField]
	private AdvancedTextInfoPanelContent _infoPanel;

	[SerializeField]
	private TextInfoPanelContent _demoInfoPanel;

	[SerializeField]
	private Image _glow;

	[SerializeField]
	private Color _glowColorActive;

	[SerializeField]
	private Color _glowColorGold;

	[SerializeField]
	private Image _inactiveImage;

	private bool _isPlayingClaimAnimation;

	private Tween _pulseTween;

	private ObjectiveTargetItem _itemSO;

	private int _tier;

	private string _categoryNameLocaKey;

	private float _hiddenAlpha = 0.3f;

	private EGlowState _glowState;

	private ObjectiveTargetCategorySO _categorySO;

	private string _categoryName;

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
				if (_tier == 9)
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

	private void Update()
	{
		UpdateText();
	}

	private void UpdateText()
	{
		string arg = ((_categorySO.CurrentTier == _tier) ? $"{_categorySO.DisplayDeliveredInTier}/{_categorySO.DisplayRequiredInTier}" : $"{_itemSO.Amount}");
		_infoPanel.UpdateContent(string.Format(LocalizationUtility.GetLocalizedText("DeliverTargets.LevelTitle"), _categoryName, (_tier + 1).ToString()), string.Format(LocalizationUtility.GetLocalizedText("DeliverTargets.LevelDescription"), arg, _categoryName));
		if (_categorySO.CurrentTier == _tier)
		{
			_infoPanel.ForceUpdate();
		}
	}

	private void UpdateTexts()
	{
		_rewardText.SetText(string.Format(LocalizationUtility.GetLocalizedText("Objectives.xpLabel"), _itemSO.XpReward));
		_categoryName = LocalizationUtility.GetLocalizedText(_categoryNameLocaKey);
		UpdateText();
	}

	public void Build(ObjectiveTargetItem item, int tier, ObjectiveTargetCategorySO category, Color color, string categoryNameLocaKey)
	{
		_categorySO = category;
		_itemSO = item;
		_tier = tier;
		_categoryNameLocaKey = categoryNameLocaKey;
		_hiddenAlpha = (item.Active ? 0.3f : 0.1f);
		_inactiveImage.gameObject.SetActive(!item.Active);
		_infoPanel.enabled = item.Active;
		_demoInfoPanel.enabled = !item.Active;
		UpdateTexts();
		_tierText.SetText((tier + 1).ToString());
		_tierIcon.SetActive(tier == 9);
		_tierText.gameObject.SetActive(tier < 9);
		_background.color = color;
		_infoPanel.UpdateColors(Color.white, color);
		SetHidden(isHidden: true);
		_infoPanel.enabled = false;
	}

	public void SetViewDefault()
	{
		GlowState = EGlowState.Disabled;
		_rewardText.gameObject.SetActive(value: true);
		_infoPanel.enabled = true;
		_background.fillAmount = 0f;
		SetHidden(isHidden: true);
	}

	public void SetViewCurrent(ObjectiveTargetItem item, uint deliveredAmount)
	{
		GlowState = EGlowState.Active;
		_rewardText.gameObject.SetActive(value: true);
		SetHidden(isHidden: false);
		_background.fillAmount = (float)deliveredAmount / (float)item.Amount;
		_infoPanel.enabled = true;
	}

	public void SetViewClaimed()
	{
		GlowState = EGlowState.Completed;
		_rewardText.gameObject.SetActive(value: false);
		SetHidden(isHidden: false);
		_background.fillAmount = 1f;
		_infoPanel.enabled = true;
	}

	public void SetHidden(bool isHidden)
	{
		_viewCanvasGroup.alpha = (isHidden ? _hiddenAlpha : 1f);
		_backgroundTop.gameObject.SetActive(!isHidden);
		_background.enabled = !isHidden;
	}
}
