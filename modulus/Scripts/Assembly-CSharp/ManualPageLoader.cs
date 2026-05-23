#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class ManualPageLoader : MonoBehaviour
{
	[SerializeField]
	private Transform _pageParent;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private List<ManualPageSO> _pages = new List<ManualPageSO>();

	[SerializeField]
	private SerializedDictionary<PageElementType, PageElement> _pageElements = new SerializedDictionary<PageElementType, PageElement>();

	private ManualPageSO _currentPage;

	public ManualPageSO CurrentPage => _currentPage;

	public void LoadPage(ManualPageSO page)
	{
		_currentPage = page;
		RemoveAllChildren(_pageParent);
		if (page.PageElements == null)
		{
			this.DevException("Page '" + page.PageNameLoca + "' has a null PageElements list. Skipping.", "LoadPage", 25);
			return;
		}
		foreach (PageElementSO pageElement in page.PageElements)
		{
			if (!_pageElements.TryGetValue(pageElement.ElementType, out var value))
			{
				this.DevException($"Page Element {pageElement} not found in page {page}", "LoadPage", 33);
			}
			else
			{
				Object.Instantiate(value, _pageParent).Setup(pageElement);
			}
		}
		_scrollRect.verticalNormalizedPosition = 1f;
	}

	private void RemoveAllChildren(Transform parent)
	{
		for (int num = parent.childCount - 1; num >= 0; num--)
		{
			Object.Destroy(parent.GetChild(num).gameObject);
		}
	}
}
