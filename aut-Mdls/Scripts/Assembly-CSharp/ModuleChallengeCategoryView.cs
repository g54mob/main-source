using System.Collections.Generic;
using Presentation.UI.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModuleChallengeCategoryView : MonoBehaviour
{
	[SerializeField]
	private Image _moduleButtonImage;

	[SerializeField]
	private Image _moduleButtonBackground;

	[SerializeField]
	private Image _moduleButtonBorder;

	[SerializeField]
	private GameObject _background;

	[SerializeField]
	private ModuleButtonInObjectives _moduleButton;

	[SerializeField]
	private GameObject _info;

	[SerializeField]
	private TextMeshProUGUI _modNameText;

	[SerializeField]
	private GameObject _modNameCheckmark;

	[SerializeField]
	private TextMeshProUGUI _currentAmountText;

	[SerializeField]
	private TextMeshProUGUI _totalAmountText;

	[SerializeField]
	private ButtonEnabler _moduleButtonEnabler;

	[SerializeField]
	private List<ChallengeItemView> _itemViews;

	[SerializeField]
	private CanvasGroup _rewardsCanvasGroup;

	[SerializeField]
	private Color _moduleButtonBackgroundColorNormal;

	[SerializeField]
	private Color _moduleButtonBackgroundColorCompleted;

	[SerializeField]
	private Color _moduleButtonBackgroundColorDisabled;

	[SerializeField]
	private Color _moduleButtonBorderColorNormal;

	[SerializeField]
	private Color _moduleButtonBorderColorCompleted;

	[SerializeField]
	private Color _moduleButtonBorderColorDisabled;

	[SerializeField]
	private Color _modNameTextColorNormal;

	[SerializeField]
	private Color _modNameTextColorCompleted;

	[SerializeField]
	private float _rewardsAlphaNormal = 1f;

	[SerializeField]
	private float _rewardsAlphaDisabled = 0.2f;

	[SerializeField]
	private GameObject _inactiveBlocker;

	private ObjectiveTargetCategorySO _category;

	public List<ChallengeItemView> ItemViews => _itemViews;

	public void Build(ObjectiveTargetCategorySO category, int index)
	{
		_category = category;
		_moduleButtonImage.sprite = category.Resource.Icon;
		_modNameText.SetText(LocalizationUtility.GetLocalizedText(category.ModuleNameLocaKey));
		_moduleButton.IndexInSet = index;
		UpdateActive();
	}

	private void UpdateActive()
	{
		bool flag = true;
		foreach (ObjectiveTargetItem item in _category.Items)
		{
			if (!item.Active)
			{
				flag = false;
				break;
			}
		}
		_inactiveBlocker.SetActive(!flag);
	}

	public void UpdateView(bool isCategoryValid)
	{
		_moduleButtonEnabler.Interactable = isCategoryValid;
		_moduleButton.enabled = isCategoryValid;
		_info.SetActive(isCategoryValid);
		_moduleButtonBackground.color = ((!isCategoryValid) ? _moduleButtonBackgroundColorDisabled : (_category.AllTiersClaimed ? _moduleButtonBackgroundColorCompleted : _moduleButtonBackgroundColorNormal));
		_moduleButtonBorder.color = ((!isCategoryValid) ? _moduleButtonBorderColorDisabled : (_category.AllTiersClaimed ? _moduleButtonBorderColorCompleted : _moduleButtonBorderColorNormal));
		_modNameText.color = (_category.AllTiersClaimed ? _modNameTextColorCompleted : _modNameTextColorNormal);
		_modNameCheckmark.SetActive(_category.AllTiersClaimed);
		_rewardsCanvasGroup.alpha = (isCategoryValid ? _rewardsAlphaNormal : _rewardsAlphaDisabled);
		UpdateActive();
	}

	public void UpdateValues()
	{
		_currentAmountText.SetText(_category.DisplayDeliveredInTier.ToString());
		_totalAmountText.SetText($"/ {_category.DisplayRequiredInTier}");
	}

	public void ActivateBackground(bool value)
	{
		_background.SetActive(value);
	}
}
