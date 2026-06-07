using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PagesSystemHandler
{
	private GameObject pagesContainerPanel;

	private int slotsPerPage;

	private Button previousPageButton;

	private Button nextPageButton;

	private TextMeshProUGUI numberOfPagesText;

	private int currentPageSelected;

	public PagesSystemHandler(GameObject pageElementsPanel, GameObject defaultPagesContainerPanel, int slotsPerPage)
	{
		previousPageButton = pageElementsPanel.transform.FindComponent<Button>("PreviousPageButton", isRecursively: true);
		nextPageButton = pageElementsPanel.transform.FindComponent<Button>("NextPageButton", isRecursively: true);
		numberOfPagesText = pageElementsPanel.transform.FindComponent<TextMeshProUGUI>("NumberOfPagesText", isRecursively: true);
		pagesContainerPanel = defaultPagesContainerPanel;
		this.slotsPerPage = slotsPerPage;
		currentPageSelected = 1;
		previousPageButton.onClick.AddListener(delegate
		{
			currentPageSelected--;
			UpdatePagesSystem();
		});
		nextPageButton.onClick.AddListener(delegate
		{
			currentPageSelected++;
			UpdatePagesSystem();
		});
	}

	public void AddFirstParentPagePanel(GameObject pagePrefab)
	{
		GetParentPagePanel(pagePrefab, 0);
	}

	public GameObject GetParentPagePanel(GameObject pagePrefab, int index)
	{
		return GetParentPagePanel(pagesContainerPanel, pagePrefab, index);
	}

	public GameObject GetParentPagePanel(GameObject pagesContainerPanel, GameObject pagePanelPrefab, int index)
	{
		this.pagesContainerPanel = pagesContainerPanel;
		GameObject result = null;
		int childCount = pagesContainerPanel.transform.childCount;
		int num = index / slotsPerPage + 1;
		if (childCount == 0 || num > childCount)
		{
			result = Util.InstantiateForGUI(pagePanelPrefab, pagesContainerPanel.transform, "Page_" + num);
			result.transform.RemoveAllChildren();
			result.SetActive(value: false);
			return result;
		}
		if (num <= childCount)
		{
			result = pagesContainerPanel.transform.GetChild(num - 1).gameObject;
		}
		return result;
	}

	public void ReorganizePages()
	{
		ReorganizePages(pagesContainerPanel);
	}

	public void ReorganizePages(GameObject pagesContainerPanel)
	{
		this.pagesContainerPanel = pagesContainerPanel;
		int childCount = pagesContainerPanel.transform.childCount;
		for (int i = 0; i < childCount - 1; i++)
		{
			Transform child = pagesContainerPanel.transform.GetChild(i);
			if (child.childCount < slotsPerPage)
			{
				Transform child2 = pagesContainerPanel.transform.GetChild(i + 1);
				if (child2.childCount <= 0)
				{
					break;
				}
				child2.GetChild(0).SetParent(child);
			}
		}
		UpdatePagesSystem();
	}

	public void SelectPage(int pageNumber)
	{
		currentPageSelected = pageNumber;
		UpdatePagesSystem();
	}

	public void UpdateToFirstPage(GameObject pagesContainerPanel)
	{
		currentPageSelected = 1;
		UpdatePagesSystem(pagesContainerPanel);
	}

	public void UpdatePagesSystem()
	{
		UpdatePagesSystem(pagesContainerPanel);
	}

	public void UpdatePagesSystem(GameObject pagesContainerPanel)
	{
		this.pagesContainerPanel = pagesContainerPanel;
		int num = 0;
		foreach (Transform item in pagesContainerPanel.transform)
		{
			if (item.childCount > 0)
			{
				num++;
			}
		}
		num = ((num == 0) ? 1 : num);
		currentPageSelected = Mathf.Clamp(currentPageSelected, 1, num);
		bool active = num > 1;
		previousPageButton.gameObject.SetActive(active);
		nextPageButton.gameObject.SetActive(active);
		numberOfPagesText.gameObject.SetActive(active);
		string text = LanguagesManager.Instance.GetText("page.separator.text", "/");
		numberOfPagesText.text = currentPageSelected + " " + text + " " + num;
		previousPageButton.interactable = currentPageSelected > 1;
		nextPageButton.interactable = currentPageSelected < num;
		foreach (Transform item2 in pagesContainerPanel.transform)
		{
			item2.gameObject.SetActive(value: false);
		}
		if (pagesContainerPanel.transform.childCount != 0)
		{
			pagesContainerPanel.transform.GetChild(currentPageSelected - 1).gameObject.SetActive(value: true);
		}
	}
}
