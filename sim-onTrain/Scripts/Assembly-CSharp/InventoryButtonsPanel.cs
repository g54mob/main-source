using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonsPanel : Singleton<InventoryButtonsPanel>
{
	[Header("Buttons")]
	[SerializeField]
	private Button storyBoardPanelButton;

	[SerializeField]
	private Button craftPanelButton;

	[Header("Colors")]
	[SerializeField]
	private Color normalColor = Color.white;

	[SerializeField]
	private Color selectedColor = Color.yellow;

	[Header("Panel References")]
	[SerializeField]
	private StoryBoardPanel storyBoardPanel;

	[SerializeField]
	private CraftPanelUIManager craftPanel;

	[Header("Compass")]
	[SerializeField]
	private CanvasGroup compassCanvasGroup;

	[SerializeField]
	private float compassFadeDuration = 0.3f;

	private CanvasGroup canvasGroup;

	private UIPanelBase currentActivePanel;

	private bool zoomHidden;

	private void Start()
	{
		Canvas rootCanvas = GetComponentInParent<Canvas>().rootCanvas;
		base.transform.SetParent(rootCanvas.transform, worldPositionStays: true);
		base.transform.SetAsLastSibling();
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
		HideSelf();
		storyBoardPanelButton.onClick.AddListener(OnStoryBoardButtonClicked);
		craftPanelButton.onClick.AddListener(OnCraftButtonClicked);
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.AddListener(OnPanelOpened);
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.AddListener(OnPanelClosed);
	}

	private void OnDestroy()
	{
		if (Singleton<MainUIManager>.Instance != null)
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.RemoveListener(OnPanelOpened);
			Singleton<MainUIManager>.Instance.OnInGamePanelClosed.RemoveListener(OnPanelClosed);
		}
	}

	private void OnPanelOpened(UIPanelBase panel)
	{
		if (panel == storyBoardPanel || panel == craftPanel)
		{
			currentActivePanel = panel;
			zoomHidden = false;
			ShowSelf();
			UpdateButtonColors(panel);
			HideCompass();
		}
		else
		{
			HideSelf();
		}
	}

	private void OnPanelClosed(UIPanelBase panel)
	{
		currentActivePanel = null;
		zoomHidden = false;
		HideSelf();
		ShowCompass();
	}

	public void SetZoomHidden(bool hidden)
	{
		zoomHidden = hidden;
		if (hidden)
		{
			HideSelf();
		}
		else if (currentActivePanel != null)
		{
			ShowSelf();
		}
	}

	private void OnStoryBoardButtonClicked()
	{
		if (!(currentActivePanel == storyBoardPanel))
		{
			SwitchToPanel(storyBoardPanel);
		}
	}

	private void OnCraftButtonClicked()
	{
		if (currentActivePanel == craftPanel)
		{
			return;
		}
		if (currentActivePanel != null)
		{
			currentActivePanel.HidePanel();
			foreach (UIPanelBase connectedPanel in currentActivePanel.connectedPanels)
			{
				connectedPanel.HidePanel();
			}
		}
		currentActivePanel = craftPanel;
		craftPanel.ChangePanelActive(CraftMode.SimpleCraft);
	}

	private void SwitchToPanel(UIPanelBase newPanel)
	{
		if (currentActivePanel != null)
		{
			currentActivePanel.HidePanel();
			foreach (UIPanelBase connectedPanel in currentActivePanel.connectedPanels)
			{
				connectedPanel.HidePanel();
			}
		}
		currentActivePanel = newPanel;
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(newPanel);
		newPanel.ShowPanel();
	}

	private void UpdateButtonColors(UIPanelBase activePanel)
	{
		storyBoardPanelButton.image.color = normalColor;
		craftPanelButton.image.color = normalColor;
		if (activePanel == storyBoardPanel)
		{
			storyBoardPanelButton.image.color = selectedColor;
		}
		else if (activePanel == craftPanel)
		{
			craftPanelButton.image.color = selectedColor;
		}
	}

	private void ShowSelf()
	{
		if (!zoomHidden)
		{
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
	}

	private void HideSelf()
	{
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	private void HideCompass()
	{
		if (!(compassCanvasGroup == null))
		{
			compassCanvasGroup.DOKill();
			compassCanvasGroup.alpha = 0f;
		}
	}

	private void ShowCompass()
	{
		if (!(compassCanvasGroup == null))
		{
			compassCanvasGroup.DOKill();
			compassCanvasGroup.DOFade(1f, compassFadeDuration);
		}
	}
}
