using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryBoardPanel : UIPanelBase, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
{
	public List<StoryBoardSaveData> CollectedStories = new List<StoryBoardSaveData>();

	public CanvasGroup inGameCanvasGroup;

	[Header("Zoom/Pan Ayarları")]
	public RectTransform contentContainer;

	[SerializeField]
	private float zoomSpeed = 0.1f;

	[SerializeField]
	private float minZoom = 0.9f;

	[SerializeField]
	private float maxZoom = 3f;

	[SerializeField]
	private float topPadding = 50f;

	[SerializeField]
	[Range(0f, 1f)]
	private float hideButtonsPanelZoomPercent = 0.1f;

	[Header("Background Ayarları")]
	[SerializeField]
	private RectTransform backgroundImage;

	[SerializeField]
	private bool autoFitBackground = true;

	[Header("Sürükleme Sınırları")]
	[Tooltip("Sürükleme sınırlarını aktif eder")]
	[SerializeField]
	private bool useBounds = true;

	[Tooltip("Aktif olduğunda sınırlar zoom seviyesine göre otomatik ayarlanır")]
	[SerializeField]
	private bool dynamicBounds = true;

	[Tooltip("İçerik ekrandan ne kadar dışarı çıkabilir (piksel)")]
	[SerializeField]
	private float edgeMargin = 200f;

	[Tooltip("Dinamik sınırlar kapalıyken kullanılacak minimum sınırlar")]
	[SerializeField]
	private Vector2 minBounds = new Vector2(-1000f, -1000f);

	[Tooltip("Dinamik sınırlar kapalıyken kullanılacak maksimum sınırlar")]
	[SerializeField]
	private Vector2 maxBounds = new Vector2(1000f, 1000f);

	private TSPlayerController tsPlayer;

	private bool isDragging;

	private bool canDrag = true;

	private Vector2 lastPosition = Vector2.zero;

	private Vector3 lastScale = Vector3.one;

	private bool hasStoredValues;

	public List<StoryPaperUI> stories = new List<StoryPaperUI>();

	private Coroutine refreshCoroutine;

	private void Start()
	{
		StartCoroutine(FindPlayer());
		if (GetComponent<Image>() == null)
		{
			Image image = base.gameObject.AddComponent<Image>();
			image.color = new Color(0f, 0f, 0f, 0.01f);
			image.raycastTarget = true;
		}
		if (contentContainer == null)
		{
			Transform transform = base.transform.Find("Content");
			if (transform != null)
			{
				contentContainer = transform.GetComponent<RectTransform>();
				Debug.Log("Var olan Content bulundu");
			}
			else
			{
				GameObject gameObject = new GameObject("Content");
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				contentContainer = gameObject.AddComponent<RectTransform>();
				contentContainer.anchorMin = new Vector2(0.5f, 0.5f);
				contentContainer.anchorMax = new Vector2(0.5f, 0.5f);
				contentContainer.pivot = new Vector2(0.5f, 0.5f);
				contentContainer.sizeDelta = new Vector2(2000f, 2000f);
				contentContainer.anchoredPosition = Vector2.zero;
				Image image2 = gameObject.AddComponent<Image>();
				image2.color = new Color(0f, 0f, 0f, 0.01f);
				image2.raycastTarget = false;
				List<Transform> list = new List<Transform>();
				foreach (Transform item in base.transform)
				{
					if (item != contentContainer.transform)
					{
						list.Add(item);
					}
				}
				foreach (Transform item2 in list)
				{
					item2.SetParent(contentContainer, worldPositionStays: true);
				}
				Debug.Log($"Yeni Content oluşturuldu, {list.Count} çocuk obje taşındı");
			}
		}
		contentContainer.localScale = Vector3.one;
		SetupBackground();
		if (autoFitBackground)
		{
			CalculateMinZoomToFit();
		}
	}

	private void SetupBackground()
	{
		if (backgroundImage == null)
		{
			Transform transform = contentContainer.Find("Background");
			if (transform != null)
			{
				backgroundImage = transform.GetComponent<RectTransform>();
			}
			else
			{
				GameObject gameObject = new GameObject("Background");
				gameObject.transform.SetParent(contentContainer, worldPositionStays: false);
				backgroundImage = gameObject.AddComponent<RectTransform>();
				backgroundImage.anchorMin = Vector2.zero;
				backgroundImage.anchorMax = Vector2.one;
				backgroundImage.sizeDelta = Vector2.zero;
				backgroundImage.anchoredPosition = Vector2.zero;
				Image image = gameObject.AddComponent<Image>();
				image.color = new Color(0.2f, 0.2f, 0.2f, 1f);
				image.raycastTarget = false;
				gameObject.transform.SetAsFirstSibling();
			}
		}
		if (backgroundImage != null)
		{
			contentContainer.sizeDelta = backgroundImage.sizeDelta;
		}
	}

	private void CalculateMinZoomToFit()
	{
	}

	private IEnumerator FindPlayer()
	{
		TSPlayerController component;
		while (true)
		{
			if (TrainGameManager.instance != null && TrainGameManager.instance.mainPlayer != null)
			{
				component = TrainGameManager.instance.mainPlayer.GetComponent<TSPlayerController>();
				if (component != null)
				{
					break;
				}
				Debug.Log("TSPlayerController component bulunamadı");
			}
			yield return new WaitForSeconds(0.3f);
		}
		tsPlayer = component;
	}

	private void Update()
	{
		if (ChatPanelController.isInputFocused)
		{
			return;
		}
		if (isPanelOpen)
		{
			HandleZoom();
			if (Input.GetKeyDown(KeyCode.R))
			{
				ResetContentPosition();
			}
			if (Input.GetKeyDown(KeyCode.T))
			{
				TestMovement();
			}
		}
		if (isPanelOpen && Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.StoryPanelKey))
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
			HidePanel();
			return;
		}
		KeyData keyData = Singleton<UserPrefencesManager>.Instance.keyData;
		if (!isPanelOpen && Singleton<MainUIManager>.Instance.isInGamePanelOpened && Input.GetKeyUp(keyData.StoryPanelKey) && keyData.StoryPanelKey != keyData.InventoryKey)
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			ShowPanel();
		}
		else if (TrainGameManager.isInputActive && Input.GetKeyUp(keyData.StoryPanelKey) && keyData.StoryPanelKey != keyData.InventoryKey && !isPanelOpen)
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			ShowPanel();
		}
	}

	private void ResetContentPosition()
	{
		if (contentContainer != null)
		{
			contentContainer.anchoredPosition = new Vector2(0f, 0f - topPadding);
			if (autoFitBackground && backgroundImage != null)
			{
				CalculateMinZoomToFit();
				contentContainer.localScale = Vector3.one * minZoom;
			}
			else
			{
				contentContainer.localScale = Vector3.one;
			}
			lastPosition = new Vector2(0f, 0f - topPadding);
			lastScale = contentContainer.localScale;
			hasStoredValues = false;
			ApplyBounds();
		}
	}

	private void TestMovement()
	{
		if (contentContainer != null)
		{
			Vector2 anchoredPosition = contentContainer.anchoredPosition + new Vector2(100f, 100f);
			if (useBounds)
			{
				Vector2 currentBounds = GetCurrentBounds(isMin: true);
				Vector2 currentBounds2 = GetCurrentBounds(isMin: false);
				anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, currentBounds.x, currentBounds2.x);
				anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, currentBounds.y, currentBounds2.y);
			}
			contentContainer.anchoredPosition = anchoredPosition;
		}
	}

	private Vector2 GetCurrentBounds(bool isMin)
	{
		if (!useBounds)
		{
			if (!isMin)
			{
				return new Vector2(float.MaxValue, float.MaxValue);
			}
			return new Vector2(float.MinValue, float.MinValue);
		}
		RectTransform rectTransform = base.transform as RectTransform;
		if (rectTransform == null || contentContainer == null)
		{
			if (!isMin)
			{
				return Vector2.zero;
			}
			return Vector2.zero;
		}
		float x = contentContainer.localScale.x;
		float num;
		float num2;
		if (backgroundImage != null)
		{
			num = backgroundImage.rect.width * x;
			num2 = backgroundImage.rect.height * x;
		}
		else
		{
			num = contentContainer.sizeDelta.x * x;
			num2 = contentContainer.sizeDelta.y * x;
		}
		float width = rectTransform.rect.width;
		float height = rectTransform.rect.height;
		float num3 = Mathf.Max(0f, (num - width) / 2f);
		float num4 = Mathf.Max(0f, (num2 - height) / 2f);
		if (isMin)
		{
			return new Vector2(0f - num3, 0f - num4 - topPadding);
		}
		return new Vector2(num3, num4 - topPadding);
	}

	private void ApplyBounds()
	{
		if (contentContainer != null && useBounds)
		{
			Vector2 anchoredPosition = contentContainer.anchoredPosition;
			Vector2 currentBounds = GetCurrentBounds(isMin: true);
			Vector2 currentBounds2 = GetCurrentBounds(isMin: false);
			anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, currentBounds.x, currentBounds2.x);
			anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, currentBounds.y, currentBounds2.y);
			contentContainer.anchoredPosition = anchoredPosition;
		}
	}

	public override void ShowPanel()
	{
		tsPlayer.HidePlayerCanvas();
		base.ShowPanel();
		inGameCanvasGroup.alpha = 0f;
		inGameCanvasGroup.interactable = false;
		inGameCanvasGroup.blocksRaycasts = false;
		if (contentContainer == null)
		{
			Transform transform = base.transform.Find("Content");
			if (transform != null)
			{
				contentContainer = transform.GetComponent<RectTransform>();
			}
		}
		if (contentContainer != null)
		{
			if (autoFitBackground)
			{
				CalculateMinZoomToFit();
			}
			if (hasStoredValues)
			{
				contentContainer.anchoredPosition = lastPosition;
				contentContainer.localScale = lastScale;
				ApplyBounds();
			}
			else
			{
				ResetContentPosition();
			}
		}
		RefreshStoryPapers();
		if (refreshCoroutine != null)
		{
			StopCoroutine(refreshCoroutine);
		}
		refreshCoroutine = StartCoroutine(AutoRefreshStoryPapers());
	}

	public override void HidePanel()
	{
		if (isPanelOpen)
		{
			if (refreshCoroutine != null)
			{
				StopCoroutine(refreshCoroutine);
				refreshCoroutine = null;
			}
			if (contentContainer != null)
			{
				lastPosition = contentContainer.anchoredPosition;
				lastScale = contentContainer.localScale;
				hasStoredValues = true;
			}
			tsPlayer.ShowPlayerCanvas();
			base.HidePanel();
			inGameCanvasGroup.alpha = 1f;
			inGameCanvasGroup.interactable = true;
			inGameCanvasGroup.blocksRaycasts = true;
		}
	}

	private IEnumerator AutoRefreshStoryPapers()
	{
		while (isPanelOpen)
		{
			yield return new WaitForSeconds(0.5f);
			RefreshStoryPapers();
		}
	}

	public void RefreshStoryPapers()
	{
		if (contentContainer == null)
		{
			return;
		}
		StoryPaperUI[] componentsInChildren = contentContainer.GetComponentsInChildren<StoryPaperUI>();
		foreach (StoryPaperUI storyPaperUI in componentsInChildren)
		{
			if (storyPaperUI.storyData != null)
			{
				if (storyPaperUI.storyData.isLearned)
				{
					storyPaperUI.ShowPaper();
				}
				else
				{
					storyPaperUI.HidePaper();
				}
			}
		}
	}

	private void HandleZoom()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if ((eventData.button == PointerEventData.InputButton.Right || eventData.button == PointerEventData.InputButton.Middle) && canDrag)
		{
			isDragging = true;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right || eventData.button == PointerEventData.InputButton.Middle)
		{
			isDragging = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (contentContainer != null && isDragging && canDrag)
		{
			Vector2 anchoredPosition = contentContainer.anchoredPosition + eventData.delta;
			if (useBounds)
			{
				Vector2 currentBounds = GetCurrentBounds(isMin: true);
				Vector2 currentBounds2 = GetCurrentBounds(isMin: false);
				anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, currentBounds.x, currentBounds2.x);
				anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, currentBounds.y, currentBounds2.y);
			}
			contentContainer.anchoredPosition = anchoredPosition;
		}
	}

	public void SetDraggingEnabled(bool enabled)
	{
		canDrag = enabled;
		if (!enabled)
		{
			isDragging = false;
		}
	}
}
