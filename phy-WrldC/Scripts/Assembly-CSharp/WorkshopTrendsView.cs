using System.Collections;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopTrendsView : BaseGUIPanelView
{
	public const string PageChangeEvent = "WorkshopTrendsView.PreviousPageButtonEvent";

	public const string CloseEvent = "WorkshopTrendsView.CloseEvent";

	private Image itemImage;

	private TextMeshProUGUI itemNameText;

	private Button itemLinkButton;

	private TextMeshProUGUI pageCountText;

	private Button previousPageButton;

	private Button nextPageButton;

	private Button closeButton;

	private ulong itemId;

	private bool isAutoPageChangeActive;

	private Coroutine autoPageChangeCoroutine;

	private WaitForSeconds waitForNextPage;

	public MainMenuView MainMenuView { get; }

	public WorkshopTrendsView(MainMenuView mainMenuView)
	{
		MainMenuView = mainMenuView;
		base.MainPanel = mainMenuView.mainPanel.transform.FindChildRecursively("WorkshopTrendsWindow").gameObject;
		itemImage = base.MainPanel.transform.FindComponent<Image>("ItemImage", isRecursively: true);
		itemNameText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("ItemNameText", isRecursively: true);
		itemLinkButton = base.MainPanel.transform.FindComponent<Button>("ItemLinkButton", isRecursively: true);
		pageCountText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("PageCountText", isRecursively: true);
		previousPageButton = base.MainPanel.transform.FindComponent<Button>("PreviousPageButton", isRecursively: true);
		nextPageButton = base.MainPanel.transform.FindComponent<Button>("NextPageButton", isRecursively: true);
		closeButton = base.MainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		itemLinkButton.onClick.AddListener(delegate
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://steamcommunity.com/workshop/filedetails/?id=" + itemId);
		});
		previousPageButton.onClick.AddListener(delegate
		{
			NotifyChange("WorkshopTrendsView.PreviousPageButtonEvent", -1);
			isAutoPageChangeActive = false;
		});
		nextPageButton.onClick.AddListener(delegate
		{
			NotifyChange("WorkshopTrendsView.PreviousPageButtonEvent", 1);
			isAutoPageChangeActive = false;
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("WorkshopTrendsView.CloseEvent");
		});
		isAutoPageChangeActive = true;
		waitForNextPage = new WaitForSeconds(4f);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		if (isVisible)
		{
			if (autoPageChangeCoroutine != null)
			{
				GameManager.Instance.StopCoroutine(autoPageChangeCoroutine);
			}
			autoPageChangeCoroutine = GameManager.Instance.StartCoroutine(AutoPageChange());
			isAutoPageChangeActive = true;
		}
		else if (autoPageChangeCoroutine != null)
		{
			GameManager.Instance.StopCoroutine(autoPageChangeCoroutine);
		}
	}

	public void SetConfiguration(WorkshopTrendsModel.ItemData itemData)
	{
		itemId = itemData.itemId;
		itemNameText.SetText(itemData.itemName);
		if (itemData.itemTexture != null)
		{
			itemImage.sprite = Sprite.Create(itemData.itemTexture, new Rect(0f, 0f, itemData.itemTexture.width, itemData.itemTexture.height), new Vector2(0.5f, 0.5f));
			itemImage.preserveAspect = true;
		}
	}

	public void RefreshPages(int selectedPage, int pageCount)
	{
		previousPageButton.interactable = selectedPage != 1;
		nextPageButton.interactable = selectedPage < pageCount;
		pageCountText.SetText($"{selectedPage} / {pageCount}");
	}

	private IEnumerator AutoPageChange()
	{
		while (true)
		{
			yield return waitForNextPage;
			if (isAutoPageChangeActive)
			{
				NotifyChange("WorkshopTrendsView.PreviousPageButtonEvent", 1);
			}
		}
	}
}
