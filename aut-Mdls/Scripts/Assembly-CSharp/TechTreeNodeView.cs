#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Logic.Threading.Events;
using Presentation.UI;
using Presentation.UI.ButtonHelpers;
using Presentation.UI.HUD;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

public class TechTreeNodeView : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public struct TierProps
	{
		public Vector2 NodeSize;

		public bool ShowTitle;

		public bool ShowRankIcon;

		public bool ShowRankTitle;

		public bool ShowCost;

		public bool ShowUnlockingTexts;

		public float TitleSize;

		public float NameSize;

		public float RankSize;

		public float RankTitleSize;

		public float TextWidthMultiplier;
	}

	[Header("Layout")]
	[SerializeField]
	private RectTransform _rectTransform;

	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private Image _background;

	[SerializeField]
	private Image _border;

	[SerializeField]
	private Image _thumbnail;

	[SerializeField]
	private GameObject _filtered;

	[SerializeField]
	private GameObject _rankLabel;

	[SerializeField]
	private GameObject _rankIcon;

	[SerializeField]
	private TextMeshProUGUI _rankTitle;

	[SerializeField]
	private TextMeshProUGUI _rankText;

	[SerializeField]
	private GameObject _costIcons;

	[SerializeField]
	private SerializedDictionary<ResourceDataSO, DataShardCostUI> _costUIs;

	[SerializeField]
	private TechTreeInfoPanelContent _infoPanel;

	[SerializeField]
	private TextInfoPanelContent _demoInfoPanel;

	[SerializeField]
	private DelayedClickButton _delayedClickButton;

	[Header("CanvasGroups")]
	[SerializeField]
	private CanvasGroup _titleCG;

	[SerializeField]
	private CanvasGroup _costCG;

	[SerializeField]
	private GameObject _unlockCG;

	[SerializeField]
	private GameObject _unlockingCG;

	[SerializeField]
	private GameObject _lockedInDemo;

	[Header("Currency")]
	[SerializeField]
	private CurrencyPersistentSO _currentCurrency;

	[SerializeField]
	private OnUpdatedRankEvent _onUpdatedRankEvent;

	[SerializeField]
	private MainThreadEventSO _currencyUpdatedEvent;

	[Header("Style")]
	[SerializeField]
	private Color _affordableColor;

	[SerializeField]
	private Color _notAffordableColor;

	[SerializeField]
	private Color _lockedColor;

	[SerializeField]
	private Color _unlockedBgColor;

	[SerializeField]
	private Color _unlockableBgColor;

	[SerializeField]
	private Color _unlockedThumbnailColor;

	[SerializeField]
	private Color _unlockableThumbnailColor;

	[SerializeField]
	private Color _unconnectedThumbnailColor;

	private TechTreeNodeSO _techTreeNodeSO;

	public Action<TechTreeNodeSO> OnClickNode;

	private bool _hasEnoughDataShards = true;

	private bool _hasEnoughRank = true;

	private bool _hasAllIncomingNodesUnlocked = true;

	private string _requiredRank;

	private int _zoomTier;

	private bool _hasSetContent;

	private Vector2 _delayedBarOffset = new Vector2(16f, 16f);

	private bool _isHovering;

	private bool _queueUpdateInfo;

	private LanguageCode _currentLanguage;

	[SerializeField]
	private SerializedDictionary<int, TierProps> _zoomTierProperties = new SerializedDictionary<int, TierProps>();

	private bool _isFilteredOut;

	public TechTreeNodeSO TechTreeNodeSo => _techTreeNodeSO;

	public RectTransform RectTransform => _rectTransform;

	public bool IsFilteredOut
	{
		set
		{
			_isFilteredOut = value;
			_filtered.SetActive(value);
			_titleCG.alpha = GetFilterAlphaValue(_zoomTierProperties[_zoomTier].ShowTitle);
			_costCG.alpha = GetFilterAlphaValue(_zoomTierProperties[_zoomTier].ShowCost);
		}
	}

	private float GetFilterAlphaValue(bool show)
	{
		if (show)
		{
			if (!_isFilteredOut)
			{
				return 1f;
			}
			return 0.1f;
		}
		return 0f;
	}

	private void Awake()
	{
		_currentLanguage = LocalizationUtility.CurrentLanguage;
		_currencyUpdatedEvent.RegisterMainThread(UpdateCurrency);
		_onUpdatedRankEvent.Register(UpdateRank);
		DelayedClickButton delayedClickButton = _delayedClickButton;
		delayedClickButton.Callback = (Action)Delegate.Combine(delayedClickButton.Callback, new Action(OnNodeUnlock));
		_infoPanel.OnShow += UpdateInfoPanel;
	}

	private void UpdateInfoPanel()
	{
		_hasEnoughDataShards = _techTreeNodeSO.IsUnlocked || _techTreeNodeSO.HasEnoughDataShards;
		_hasEnoughRank = _techTreeNodeSO.IsUnlocked || _techTreeNodeSO.HasEnoughRank;
		_hasAllIncomingNodesUnlocked = _techTreeNodeSO.IsUnlocked || _techTreeNodeSO.HasAllIncomingNodesUnlocked;
		if (_infoPanel.IsOpen)
		{
			_infoPanel.UpdateWarnings(_hasEnoughDataShards, _hasEnoughRank, _hasAllIncomingNodesUnlocked);
		}
	}

	public void Show(TechTreeNodeSO techTreeNodeSO)
	{
		if (techTreeNodeSO == null)
		{
			this.LogError("TechTreeNodeSO is null", "Show", 145);
			return;
		}
		_techTreeNodeSO = techTreeNodeSO;
		if (_currentLanguage != LocalizationUtility.CurrentLanguage)
		{
			_currentLanguage = LocalizationUtility.CurrentLanguage;
			_hasSetContent = false;
			SetContent();
		}
		else if (techTreeNodeSO.IsDirty)
		{
			_requiredRank = _techTreeNodeSO.RequiredRank.ToString();
			_hasEnoughDataShards = _techTreeNodeSO.HasEnoughDataShards;
			_hasEnoughRank = _techTreeNodeSO.HasEnoughRank;
			UpdateButton();
			SetContent();
			SetStyle();
			SetCost();
			SetRequiredRank();
			UpdateInfoPanel();
			SetLockedInDemo();
			techTreeNodeSO.IsDirty = false;
		}
	}

	private void SetLockedInDemo()
	{
		_lockedInDemo.SetActive(_techTreeNodeSO.HasBlockedInDemoValidator);
		_demoInfoPanel.enabled = _techTreeNodeSO.HasBlockedInDemoValidator;
		_infoPanel.enabled = !_techTreeNodeSO.HasBlockedInDemoValidator;
	}

	public void SetZoomSize(int tier)
	{
		_zoomTier = tier;
		_rectTransform.sizeDelta = _zoomTierProperties[tier].NodeSize;
		_delayedClickButton.UpdateSize(_zoomTierProperties[tier].NodeSize - _delayedBarOffset);
		_rankTitle.gameObject.SetActive(_zoomTierProperties[tier].ShowRankTitle);
		_rankIcon.SetActive(_zoomTierProperties[tier].ShowRankIcon);
		_unlockCG.SetActive(_zoomTierProperties[tier].ShowUnlockingTexts);
		_unlockingCG.SetActive(_zoomTierProperties[tier].ShowUnlockingTexts);
		_titleText.fontSize = _zoomTierProperties[tier].TitleSize;
		_nameText.fontSize = _zoomTierProperties[tier].NameSize;
		_rankTitle.fontSize = _zoomTierProperties[tier].RankTitleSize;
		_rankText.fontSize = _zoomTierProperties[tier].RankSize;
		_titleText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _zoomTierProperties[tier].NodeSize.x * _zoomTierProperties[tier].TextWidthMultiplier);
		_nameText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _zoomTierProperties[tier].NodeSize.x * _zoomTierProperties[tier].TextWidthMultiplier);
		if (_infoPanel.IsOpen)
		{
			_infoPanel.UpdateDoShowTitle(!_zoomTierProperties[tier].ShowTitle, _techTreeNodeSO.IsUnlocked || _hasEnoughDataShards, _techTreeNodeSO.IsUnlocked || _hasEnoughRank);
		}
		if (!_techTreeNodeSO.RevealingRunTimeValue)
		{
			_titleCG.alpha = GetFilterAlphaValue(_zoomTierProperties[tier].ShowTitle);
			_costCG.alpha = GetFilterAlphaValue(_zoomTierProperties[tier].ShowCost);
		}
	}

	private void UpdateCurrency()
	{
		_queueUpdateInfo = true;
	}

	private void Update()
	{
		if (_queueUpdateInfo)
		{
			_queueUpdateInfo = false;
			UpdateCurrencyDelayed();
		}
	}

	private void UpdateCurrencyDelayed()
	{
		if (!(_techTreeNodeSO == null))
		{
			UpdateInfoPanel();
			_hasEnoughDataShards = _techTreeNodeSO.HasEnoughDataShards;
			_hasEnoughRank = _techTreeNodeSO.HasEnoughRank;
			SetStyle();
			SetCost();
			SetInfoPanelWarnings();
			UpdateButton();
		}
	}

	private void UpdateButton()
	{
		bool flag = false;
		flag = _techTreeNodeSO.HasBlockedInDemoValidator;
		_delayedClickButton.enabled = !flag && _techTreeNodeSO.IsUnlockable && !_techTreeNodeSO.IsUnlocked && _hasEnoughDataShards && _hasEnoughRank;
	}

	private void UpdateRank(int rank)
	{
		if (!(_techTreeNodeSO == null))
		{
			UpdateInfoPanel();
			_rankLabel.SetActive(!_hasEnoughRank);
			SetInfoPanelWarnings();
		}
	}

	private void SetContent()
	{
		if (!_hasSetContent)
		{
			_hasSetContent = true;
			string localizedText = LocalizationUtility.GetLocalizedText("TechTree." + _techTreeNodeSO.LocaKey + "-Name");
			string foundString;
			bool active = LocalizationUtility.TryGetLocalizedText("TechTree." + _techTreeNodeSO.LocaKey + "-Title", out foundString);
			_titleText.gameObject.SetActive(active);
			_titleText.SetText(foundString);
			_nameText.SetText(localizedText);
			_infoPanel.UpdateContent(localizedText, LocalizationUtility.GetLocalizedText("TechTree." + _techTreeNodeSO.LocaKey + "-Description"), _techTreeNodeSO.Behaviors);
			_thumbnail.sprite = _techTreeNodeSO.Thumbnail;
		}
	}

	private void SetCost()
	{
		_costIcons.SetActive(!_techTreeNodeSO.IsUnlocked);
		if (_techTreeNodeSO.IsUnlocked)
		{
			return;
		}
		foreach (KeyValuePair<ResourceDataSO, int> allCost in _techTreeNodeSO.Cost.GetAllCosts())
		{
			if (allCost.Value > 0)
			{
				_costUIs[allCost.Key].SetAmount(allCost.Value);
				_costUIs[allCost.Key].gameObject.SetActive(value: true);
				if (_currentCurrency.GetResourceCount(allCost.Key) >= allCost.Value)
				{
					_costUIs[allCost.Key].ResetColor();
				}
				else
				{
					_costUIs[allCost.Key].SetColor(_notAffordableColor);
				}
			}
			else
			{
				_costUIs[allCost.Key].gameObject.SetActive(value: false);
			}
		}
	}

	private void SetInfoPanelWarnings()
	{
		if (_infoPanel.IsOpen)
		{
			_infoPanel.UpdateWarnings(_techTreeNodeSO.IsUnlocked || _hasEnoughDataShards, _techTreeNodeSO.IsUnlocked || _hasEnoughRank, _techTreeNodeSO.IsUnlocked || _hasAllIncomingNodesUnlocked);
		}
	}

	private void SetStyle()
	{
		SetThumbnailStyle();
		if (_techTreeNodeSO.HasBlockedInDemoValidator)
		{
			_border.gameObject.SetActive(value: true);
			_background.color = _unlockableBgColor;
			_border.color = _lockedColor;
			return;
		}
		if (_techTreeNodeSO.IsUnlocked)
		{
			_border.gameObject.SetActive(value: false);
			_background.color = _unlockedBgColor;
			return;
		}
		_border.gameObject.SetActive(value: true);
		_background.color = _unlockableBgColor;
		if (!_techTreeNodeSO.IsUnlockable)
		{
			_border.color = _lockedColor;
		}
		else if (_hasEnoughDataShards && _hasEnoughRank)
		{
			_border.color = _affordableColor;
		}
		else
		{
			_border.color = _notAffordableColor;
		}
	}

	private void SetThumbnailStyle()
	{
		_thumbnail.DOKill();
		if (!_isHovering)
		{
			if (_techTreeNodeSO.HasBlockedInDemoValidator)
			{
				_thumbnail.color = _unconnectedThumbnailColor;
			}
			else if (_techTreeNodeSO.IsUnlocked)
			{
				_thumbnail.color = _unlockedThumbnailColor;
			}
			else
			{
				_thumbnail.color = (_techTreeNodeSO.IsUnlockable ? _unlockableThumbnailColor : _unconnectedThumbnailColor);
			}
		}
	}

	private void SetRequiredRank()
	{
		_rankLabel.SetActive(!_hasEnoughRank);
		if (!_hasEnoughRank)
		{
			_rankText.SetText(_requiredRank);
		}
	}

	private void OnDestroy()
	{
		_currencyUpdatedEvent.UnRegisterMainThread(UpdateCurrency);
		_onUpdatedRankEvent.UnRegister(UpdateRank);
		DelayedClickButton delayedClickButton = _delayedClickButton;
		delayedClickButton.Callback = (Action)Delegate.Remove(delayedClickButton.Callback, new Action(OnNodeUnlock));
		_infoPanel.OnShow -= UpdateInfoPanel;
		if (OnClickNode != null)
		{
			Delegate[] invocationList = OnClickNode.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				OnClickNode = (Action<TechTreeNodeSO>)Delegate.Remove(OnClickNode, (Action<TechTreeNodeSO>)obj);
			}
		}
	}

	private void OnNodeUnlock()
	{
		OnClickNode(_techTreeNodeSO);
		Show(_techTreeNodeSO);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!_techTreeNodeSO.HasBlockedInDemoValidator)
		{
			_isHovering = true;
			_thumbnail.DOKill();
			_thumbnail.DOColor(Color.white, 0.2f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!_techTreeNodeSO.HasBlockedInDemoValidator)
		{
			_isHovering = false;
			SetThumbnailStyle();
		}
	}
}
