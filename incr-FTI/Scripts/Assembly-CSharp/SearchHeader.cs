using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SearchHeader : MonoBehaviour
{
	public TMP_InputField searchField;

	public MenuButton cancelSearchField;

	public LabelButton purchaseAllButton;

	public Image filterIconImage;

	public UnityAction searchChangeDelegate;

	public UnityAction searchClearDelegate;

	public void Initialize()
	{
		cancelSearchField.AddPointerClickTrigger(OnCancelSearchPressed);
		cancelSearchField.buttonState = CustomButtonState.Background;
	}

	public void OnSearchTextChanged()
	{
		cancelSearchField.buttonState = ((!string.IsNullOrEmpty(searchField.text)) ? CustomButtonState.Default : CustomButtonState.Background);
		searchChangeDelegate?.Invoke();
	}

	public void OnCancelSearchPressed()
	{
		cancelSearchField.buttonState = CustomButtonState.Background;
		searchField.text = string.Empty;
		if (searchClearDelegate == null)
		{
			searchChangeDelegate?.Invoke();
		}
		else
		{
			searchClearDelegate();
		}
	}

	public void SetPlaceholder(string s)
	{
		if (searchField.placeholder is TextMeshProUGUI textMeshProUGUI)
		{
			textMeshProUGUI.text = s;
		}
	}

	public void SetFilterDisplay(object itemFilter, EntityId entityFilter, bool isSearchApplied)
	{
		filterIconImage.enabled = false;
		SetPlaceholder(TextDisplay.Ellipsis);
		searchField.image.color = ((!string.IsNullOrEmpty(searchField.text)) ? ColorManager.blueFlash2 : Color.white);
	}
}
