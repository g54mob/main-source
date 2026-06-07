using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeNodeUI : MonoBehaviour
{
	[Header("Visual Elements")]
	[SerializeField]
	private Image nodeBackground;

	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TextMeshProUGUI levelText;

	[SerializeField]
	private Image statusIcon;

	[SerializeField]
	private Sprite lockSprite;

	[SerializeField]
	private Sprite checkSprite;

	[SerializeField]
	private GameObject connectingBar;

	[SerializeField]
	private Image connectingBarImage;

	[SerializeField]
	private Button nodeButton;

	[SerializeField]
	private Image holdFillBar;

	[Header("Colors")]
	[SerializeField]
	private Color activeColor = new Color(1f, 0.8f, 0f, 1f);

	[SerializeField]
	private Color inactiveColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);

	private UpgradeType _upgradeType;

	private int _levelIndex;

	private string _levelPrefixKey = "Level";

	private Action<UpgradeType, int> _onClickCallback;

	public void Setup(UpgradeType upgradeType, int levelIndex, int currentUpgradeLevel, Sprite icon, string levelPrefix, bool isLastNode, UpgradeLevelData levelData, Action<UpgradeType, int> onClickCallback)
	{
		_upgradeType = upgradeType;
		_levelIndex = levelIndex;
		_levelPrefixKey = ((!string.IsNullOrEmpty(levelPrefix)) ? levelPrefix : "Level");
		_onClickCallback = onClickCallback;
		if (connectingBarImage == null && connectingBar != null)
		{
			connectingBarImage = connectingBar.GetComponent<Image>();
			if (connectingBarImage == null)
			{
				connectingBarImage = connectingBar.GetComponentInChildren<Image>();
			}
		}
		if (iconImage != null && icon != null)
		{
			iconImage.sprite = icon;
		}
		UpdateVisual(currentUpgradeLevel, isLastNode);
		if (nodeButton != null)
		{
			nodeButton.onClick.RemoveAllListeners();
			nodeButton.onClick.AddListener(OnNodeClicked);
		}
	}

	public void UpdateLevel(int newCurrentLevel, bool isLastNode)
	{
		UpdateVisual(newCurrentLevel, isLastNode);
	}

	private void UpdateVisual(int currentUpgradeLevel, bool isLastNode)
	{
		bool flag = currentUpgradeLevel >= _levelIndex;
		if (levelText != null)
		{
			string translation = LocalizationManager.GetTranslation(_levelPrefixKey);
			if (string.IsNullOrEmpty(translation))
			{
				translation = _levelPrefixKey;
			}
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				_levelIndex.ToString()
			} });
			levelText.text = translation;
		}
		if (statusIcon != null)
		{
			statusIcon.sprite = (flag ? checkSprite : lockSprite);
			statusIcon.color = (flag ? activeColor : inactiveColor);
		}
		if (iconImage != null)
		{
			iconImage.color = (flag ? activeColor : Color.white);
		}
		if (nodeBackground != null)
		{
			nodeBackground.color = (flag ? activeColor : inactiveColor);
		}
		if (connectingBar != null)
		{
			connectingBar.SetActive(!isLastNode);
		}
		if (connectingBarImage != null)
		{
			connectingBarImage.color = (flag ? activeColor : inactiveColor);
		}
	}

	private void OnNodeClicked()
	{
		_onClickCallback?.Invoke(_upgradeType, _levelIndex);
	}

	public void SetHoldProgress(float progress)
	{
		if (holdFillBar != null)
		{
			holdFillBar.fillAmount = Mathf.Clamp01(progress);
		}
	}
}
