using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : UIPanelBase
{
	public List<InteractionMessage> interactionsOverlayCanvas = new List<InteractionMessage>();

	public List<InteractionMessage> interactionsOverlayCanvasNoKey = new List<InteractionMessage>();

	public List<InteractionMessage> interactionsBottomInfoOverlay = new List<InteractionMessage>();

	[Header("Overlay Interactions")]
	public Transform overlayInteractionsParent;

	public Transform bottomInfoInteractionsParent;

	private bool isShowing;

	public CanvasGroup mainCanvasCG;

	public CanvasGroup worldCanvasCG;

	public CanvasGroup overlayCanvasCG;

	public CanvasGroup bottomInfoInteractionsOverlay;

	private Transform worldCanvasTransform;

	private RectTransform overlayInteractionsRect;

	private Canvas overlayCanvas;

	private Camera cachedCamera;

	[Header("Overlay Positioning")]
	[Range(0f, 0.2f)]
	public float overlayOffsetPercent = 0.05f;

	private Transform currentOverlayTarget;

	private bool isOverlayActive;

	private bool isOverlayAtHitPointActive;

	private Vector3 currentHitPoint;

	private bool isBottomInfoLocked;

	public HorizontalLayoutGroup overlayInteractionsLayoutGroup;

	public float oneAndTwoInteractionSpacing = 30f;

	public float threeInteractionSpacing = 20f;

	[Header("Center Progress")]
	public CanvasGroup centerProgressCanvasGroup;

	public Image centerProgressFillImage;

	[Header("Message Colors")]
	public Color positiveColor = Color.white;

	public Color negativeColor = Color.red;

	public Sprite mouseLeftClickIcon;

	public Sprite mouseRightClickIcon;

	public Sprite mouseMiddleClickIcon;

	public static InteractionPanel Instance { get; private set; }

	public bool IsBottomInfoLocked => isBottomInfoLocked;

	public bool IsBottomInfoShowing
	{
		get
		{
			if (bottomInfoInteractionsOverlay != null)
			{
				return bottomInfoInteractionsOverlay.alpha > 0f;
			}
			return false;
		}
	}

	public bool IsAnyHoldActive
	{
		get
		{
			foreach (InteractionMessage interactionsOverlayCanva in interactionsOverlayCanvas)
			{
				if (interactionsOverlayCanva.gameObject.activeInHierarchy && interactionsOverlayCanva.isHolding)
				{
					return true;
				}
			}
			foreach (InteractionMessage item in interactionsBottomInfoOverlay)
			{
				if (item.gameObject.activeInHierarchy && item.isHolding)
				{
					return true;
				}
			}
			return false;
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		cachedCamera = Camera.main;
		worldCanvasTransform = worldCanvasCG.transform;
		overlayInteractionsRect = overlayInteractionsParent.GetComponent<RectTransform>();
		overlayCanvas = overlayCanvasCG.GetComponentInParent<Canvas>();
		HideAllInteractions();
		HidePanels();
	}

	public void SetCamera(Camera cam)
	{
		if (cam != null)
		{
			cachedCamera = cam;
		}
	}

	private Camera GetCamera()
	{
		if (cachedCamera == null)
		{
			cachedCamera = Camera.main;
		}
		return cachedCamera;
	}

	private void Update()
	{
		if (isOverlayActive && currentOverlayTarget != null)
		{
			UpdateOverlayPosition(currentOverlayTarget);
		}
		else if (isOverlayAtHitPointActive)
		{
			UpdateOverlayPositionAtHitPoint(currentHitPoint);
		}
	}

	public void HidePanels()
	{
		worldCanvasCG.alpha = 0f;
		overlayCanvasCG.alpha = 0f;
		if (!isBottomInfoLocked)
		{
			bottomInfoInteractionsOverlay.alpha = 0f;
		}
		isOverlayActive = false;
		currentOverlayTarget = null;
		isOverlayAtHitPointActive = false;
	}

	public void HidePanel(CanvasType type)
	{
		if (type != CanvasType.Overlay)
		{
			return;
		}
		foreach (InteractionMessage interactionsOverlayCanva in interactionsOverlayCanvas)
		{
			interactionsOverlayCanva.ResetLoading();
			interactionsOverlayCanva.gameObject.SetActive(value: false);
		}
		foreach (InteractionMessage item in interactionsOverlayCanvasNoKey)
		{
			item.ResetLoading();
			item.gameObject.SetActive(value: false);
		}
		overlayCanvasCG.alpha = 0f;
		isOverlayActive = false;
		currentOverlayTarget = null;
		isOverlayAtHitPointActive = false;
	}

	public new void HidePanel()
	{
		HidePanels();
	}

	public void ShowPanel(CanvasType type)
	{
		switch (type)
		{
		case CanvasType.World:
			worldCanvasCG.alpha = 1f;
			overlayCanvasCG.alpha = 0f;
			break;
		case CanvasType.Overlay:
			worldCanvasCG.alpha = 0f;
			overlayCanvasCG.alpha = 1f;
			break;
		}
	}

	public void ShowInteractionOverlay(Transform objectTransform, Transform player, KeyCode keyCode, string message, bool hasHoldAction = false, float holdDuration = 1f, Action onHoldComplete = null, Color? messageColor = null)
	{
		List<InteractionData> interactionDataList = new List<InteractionData>
		{
			new InteractionData(keyCode, message, hasHoldAction, holdDuration, onHoldComplete, null, null, messageColor)
		};
		ShowMultipleInteractionOnOverlay(objectTransform, player, interactionDataList);
	}

	public void ShowMultipleInteractionOnOverlay(Transform objectTransform, Transform player, List<InteractionData> interactionDataList)
	{
		foreach (InteractionMessage interactionsOverlayCanva in interactionsOverlayCanvas)
		{
			interactionsOverlayCanva.gameObject.SetActive(value: false);
		}
		foreach (InteractionMessage item in interactionsOverlayCanvasNoKey)
		{
			item.gameObject.SetActive(value: false);
		}
		if (interactionDataList == null || interactionDataList.Count == 0)
		{
			HidePanels();
			return;
		}
		ShowPanel(CanvasType.Overlay);
		isShowing = true;
		currentOverlayTarget = objectTransform;
		isOverlayActive = true;
		UpdateOverlayPosition(objectTransform);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < interactionDataList.Count; i++)
		{
			if (interactionDataList[i].keyCode == KeyCode.None)
			{
				if (num2 < interactionsOverlayCanvasNoKey.Count)
				{
					interactionsOverlayCanvasNoKey[num2].gameObject.SetActive(value: true);
					interactionsOverlayCanvasNoKey[num2].ShowMessage(interactionDataList[i]);
					num2++;
				}
			}
			else if (num < interactionsOverlayCanvas.Count)
			{
				interactionsOverlayCanvas[num].gameObject.SetActive(value: true);
				interactionsOverlayCanvas[num].ShowMessage(interactionDataList[i]);
				num++;
			}
		}
		UpdateOverlaySpacing(num + num2);
		EqualizeMessageWidths(interactionsOverlayCanvas);
		EqualizeMessageWidths(interactionsOverlayCanvasNoKey);
	}

	public void ShowInteractionOverlayAtHitPoint(Vector3 worldHitPoint, Transform player, KeyCode keyCode, string message, bool hasHoldAction = false, float holdDuration = 1f, Action onHoldComplete = null)
	{
		List<InteractionData> interactionDataList = new List<InteractionData>
		{
			new InteractionData(keyCode, message, hasHoldAction, holdDuration, onHoldComplete)
		};
		ShowMultipleInteractionOnOverlayAtHitPoint(worldHitPoint, player, interactionDataList);
	}

	public void ShowMultipleInteractionOnOverlayAtHitPoint(Vector3 worldHitPoint, Transform player, List<InteractionData> interactionDataList)
	{
		if (isOverlayAtHitPointActive && overlayCanvasCG.alpha > 0f)
		{
			currentHitPoint = worldHitPoint;
			return;
		}
		HideAllInteractions();
		if (interactionDataList == null || interactionDataList.Count == 0)
		{
			HidePanels();
			return;
		}
		ShowPanel(CanvasType.Overlay);
		isShowing = true;
		currentOverlayTarget = null;
		isOverlayActive = false;
		isOverlayAtHitPointActive = true;
		currentHitPoint = worldHitPoint;
		UpdateOverlayPositionAtHitPoint(worldHitPoint);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < interactionDataList.Count; i++)
		{
			if (interactionDataList[i].keyCode == KeyCode.None)
			{
				if (num2 < interactionsOverlayCanvasNoKey.Count)
				{
					interactionsOverlayCanvasNoKey[num2].gameObject.SetActive(value: true);
					interactionsOverlayCanvasNoKey[num2].ShowMessage(interactionDataList[i]);
					num2++;
				}
			}
			else if (num < interactionsOverlayCanvas.Count)
			{
				interactionsOverlayCanvas[num].gameObject.SetActive(value: true);
				interactionsOverlayCanvas[num].ShowMessage(interactionDataList[i]);
				num++;
			}
		}
		UpdateOverlaySpacing(num + num2);
		EqualizeMessageWidths(interactionsOverlayCanvas);
		EqualizeMessageWidths(interactionsOverlayCanvasNoKey);
	}

	private void UpdateOverlayPosition(Transform objectTransform)
	{
		if (objectTransform == null || overlayInteractionsRect == null)
		{
			return;
		}
		Camera camera = GetCamera();
		if (!(camera == null))
		{
			Vector3 position = objectTransform.position;
			Collider component = objectTransform.GetComponent<Collider>();
			if (component != null)
			{
				position = component.bounds.center;
			}
			Vector3 vector = camera.WorldToScreenPoint(position);
			float num = (float)Screen.width * overlayOffsetPercent;
			float num2 = (float)Screen.height * overlayOffsetPercent;
			vector.x += num;
			vector.y += num2;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(overlayInteractionsRect.parent as RectTransform, vector, (overlayCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : camera, out var localPoint);
			overlayInteractionsRect.anchoredPosition = localPoint;
		}
	}

	private void UpdateOverlayPositionAtHitPoint(Vector3 worldHitPoint)
	{
		if (!(overlayInteractionsRect == null))
		{
			Camera camera = GetCamera();
			if (!(camera == null))
			{
				Vector3 vector = camera.WorldToScreenPoint(worldHitPoint);
				float num = (float)Screen.width * overlayOffsetPercent;
				float num2 = (float)Screen.height * overlayOffsetPercent;
				vector.x += num;
				vector.y += num2;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(overlayInteractionsRect.parent as RectTransform, vector, (overlayCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : camera, out var localPoint);
				overlayInteractionsRect.anchoredPosition = localPoint;
			}
		}
	}

	public void HideAllInteractions()
	{
		foreach (InteractionMessage interactionsOverlayCanva in interactionsOverlayCanvas)
		{
			interactionsOverlayCanva.gameObject.SetActive(value: false);
		}
		foreach (InteractionMessage item in interactionsOverlayCanvasNoKey)
		{
			item.gameObject.SetActive(value: false);
		}
		if (isBottomInfoLocked)
		{
			return;
		}
		foreach (InteractionMessage item2 in interactionsBottomInfoOverlay)
		{
			item2.gameObject.SetActive(value: false);
		}
	}

	public void HideInteraction()
	{
		HideAllInteractions();
		HidePanel();
		isShowing = false;
		isOverlayActive = false;
		currentOverlayTarget = null;
		isOverlayAtHitPointActive = false;
	}

	private void EqualizeMessageWidths(List<InteractionMessage> messages)
	{
		float num = 0f;
		for (int i = 0; i < messages.Count; i++)
		{
			if (messages[i].gameObject.activeInHierarchy)
			{
				float x = ((RectTransform)messages[i].transform).sizeDelta.x;
				if (x > num)
				{
					num = x;
				}
			}
		}
		for (int j = 0; j < messages.Count; j++)
		{
			if (messages[j].gameObject.activeInHierarchy)
			{
				RectTransform rectTransform = (RectTransform)messages[j].transform;
				rectTransform.sizeDelta = new Vector2(num, rectTransform.sizeDelta.y);
			}
		}
	}

	private void UpdateOverlaySpacing(int activeCount)
	{
		if (!(overlayInteractionsLayoutGroup == null))
		{
			if (activeCount <= 2)
			{
				overlayInteractionsLayoutGroup.spacing = oneAndTwoInteractionSpacing;
			}
			else
			{
				overlayInteractionsLayoutGroup.spacing = threeInteractionSpacing;
			}
		}
	}

	public bool ShowBottomInfoInteractionsOverlay(List<InteractionData> interactionDataList)
	{
		if (isBottomInfoLocked)
		{
			return false;
		}
		ShowBottomInfoInternal(interactionDataList);
		return true;
	}

	public void ShowBottomInfoLocked(List<InteractionData> interactionDataList)
	{
		isBottomInfoLocked = true;
		ShowBottomInfoInternal(interactionDataList);
	}

	public void UnlockAndHideBottomInfo()
	{
		isBottomInfoLocked = false;
		bottomInfoInteractionsOverlay.alpha = 0f;
		foreach (InteractionMessage item in interactionsBottomInfoOverlay)
		{
			item.gameObject.SetActive(value: false);
		}
	}

	public void ShowCenterProgress(float progress)
	{
		if (!(centerProgressCanvasGroup == null) && !(centerProgressFillImage == null))
		{
			centerProgressCanvasGroup.alpha = 1f;
			centerProgressFillImage.fillAmount = progress;
		}
	}

	public void HideCenterProgress()
	{
		if (!(centerProgressCanvasGroup == null) && !(centerProgressFillImage == null))
		{
			centerProgressCanvasGroup.alpha = 0f;
			centerProgressFillImage.fillAmount = 0f;
		}
	}

	private void ShowBottomInfoInternal(List<InteractionData> interactionDataList)
	{
		for (int i = 0; i < interactionsBottomInfoOverlay.Count; i++)
		{
			if (interactionsBottomInfoOverlay[i] != null)
			{
				interactionsBottomInfoOverlay[i].gameObject.SetActive(value: false);
			}
		}
		if (interactionDataList == null || interactionDataList.Count == 0)
		{
			Debug.LogWarning("InteractionPanel: interactionDataList is null or empty!");
			bottomInfoInteractionsOverlay.alpha = 0f;
			return;
		}
		if (interactionsBottomInfoOverlay == null || interactionsBottomInfoOverlay.Count == 0)
		{
			Debug.LogError("InteractionPanel: interactionsBottomInfoOverlay list is empty! Please assign InteractionMessage objects in Inspector.");
			return;
		}
		worldCanvasCG.alpha = 0f;
		bottomInfoInteractionsOverlay.alpha = 1f;
		isShowing = true;
		int num = Mathf.Min(interactionDataList.Count, interactionsBottomInfoOverlay.Count);
		for (int j = 0; j < num; j++)
		{
			interactionsBottomInfoOverlay[j].gameObject.SetActive(value: true);
			interactionsBottomInfoOverlay[j].ShowMessage(interactionDataList[j]);
		}
		EqualizeMessageWidths(interactionsBottomInfoOverlay);
	}
}
