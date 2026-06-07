#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class ManualButtonLoader : MonoBehaviour
{
	[SerializeField]
	private Transform _buttonsParent;

	[SerializeField]
	private ManualButton _buttonPrefab;

	[SerializeField]
	private ToggleGroup _toggleGroup;

	[SerializeField]
	private CategorySeparator _categorySeparatorPrefab;

	[SerializeField]
	private List<ButtonCategory> _buttonCategories = new List<ButtonCategory>();

	[SerializeField]
	private ManualPageLoader _pageLoader;

	private void Start()
	{
		foreach (ButtonCategory buttonCategory in _buttonCategories)
		{
			CreateCategorySeparatorIfNeeded(buttonCategory);
			if (buttonCategory.ButtonPages == null)
			{
				this.LogWarning("ButtonPages list is null for category: " + (buttonCategory.CategoryNameLoca ?? "Unnamed Category"), "Start", 31);
				continue;
			}
			foreach (ManualPageSO buttonPage in buttonCategory.ButtonPages)
			{
				CreateButtonForPage(buttonCategory.CategoryNameLoca, buttonPage);
			}
		}
		_pageLoader.LoadPage(_buttonCategories[0].ButtonPages[0]);
	}

	private void CreateCategorySeparatorIfNeeded(ButtonCategory buttonCategory)
	{
		if (!string.IsNullOrEmpty(buttonCategory.CategoryNameLoca))
		{
			Object.Instantiate(_categorySeparatorPrefab, _buttonsParent).SetText(buttonCategory.CategoryNameLoca);
		}
	}

	private void CreateButtonForPage(string categoryName, ManualPageSO page)
	{
		if (page == null)
		{
			this.LogWarning("Null ManualPageSO found in category: " + (categoryName ?? "Unnamed Category"), "CreateButtonForPage", 58);
		}
		else
		{
			Object.Instantiate(_buttonPrefab, _buttonsParent).Setup(page, _toggleGroup, this, page.RequiredUnlockCondition);
		}
	}

	public void OnManualButtonClicked(Toggle toggle, bool newValue, ManualPageSO pageToLoad)
	{
		if (!newValue)
		{
			return;
		}
		if (_pageLoader != null)
		{
			if (_pageLoader.CurrentPage != pageToLoad)
			{
				_pageLoader.LoadPage(pageToLoad);
			}
			else
			{
				toggle.isOn = true;
			}
		}
		else
		{
			this.LogError("Page Loader is not assigned!", "OnManualButtonClicked", 83);
		}
	}
}
