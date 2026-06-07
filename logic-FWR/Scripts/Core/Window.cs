using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Window : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
	[SerializeField]
	private bool dockable;

	public RectTransform dockPosition;

	public Workspace workspace;

	public string windowName;

	public bool isMinimized;

	public Vector2 minimizedSize;

	public Vector2 playerSetSize;

	public Vector2 automaticSize;

	public Vector2 minSize;

	public float resizeMargin = 10f;

	public List<GameObject> disableOnMinimize;

	public UnityEvent<bool> OnMinimizeChanged;

	private bool horitontalResize;

	private bool verticalResize;

	private Vector2 pointerDownPosition;

	public Window dockedParent { get; private set; }

	public Window DockedChild
	{
		get
		{
			if (dockPosition == null || dockPosition.childCount == 0)
			{
				return null;
			}
			return dockPosition.GetChild(0)?.GetComponent<Window>();
		}
	}

	public Window LeastDockedChild
	{
		get
		{
			Window window = this;
			while (window.DockedChild != null)
			{
				window = window.DockedChild;
			}
			return window;
		}
	}

	public Window HighestDockedParent
	{
		get
		{
			Window window = this;
			while (window.dockedParent != null)
			{
				window = window.dockedParent;
			}
			return window;
		}
	}

	public float DockingOffset
	{
		get
		{
			Window window = HighestDockedParent;
			float num = 0f;
			while (window != this)
			{
				num += ((RectTransform)window.transform).rect.height;
				window = window.DockedChild;
			}
			return num;
		}
	}

	public void SetMinmized(bool minimized)
	{
		isMinimized = minimized;
		workspace.UpdateContainerSize();
		OnMinimizeChanged?.Invoke(minimized);
		foreach (GameObject item in disableOnMinimize)
		{
			item.SetActive(!minimized);
		}
		UpdateSize();
		MoveToFront();
	}

	public void Close()
	{
		if (DockedChild != null)
		{
			DockedChild.GetComponent<Window>().Undock();
		}
		workspace.openWindows.Remove(windowName);
		workspace.codeWindows.Remove(windowName, out var _);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void UpdateSize()
	{
		if (isMinimized)
		{
			((RectTransform)base.transform).sizeDelta = minimizedSize;
			return;
		}
		Vector2 sizeDelta = Vector2.Max(playerSetSize, minSize);
		if (playerSetSize.y < minSize.y)
		{
			sizeDelta.y = MathF.Max(automaticSize.y, minSize.y);
		}
		((RectTransform)base.transform).sizeDelta = sizeDelta;
		if (TryGetComponent<CodeWindow>(out var component))
		{
			component.UpdateCodeInputSize();
		}
	}

	public void ToggleMinimize()
	{
		SetMinmized(!isMinimized);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			RectTransform rectTransform = (RectTransform)base.transform;
			if (horitontalResize)
			{
				playerSetSize.x += eventData.delta.x / workspace.editorCanvas.scaleFactor / workspace.cameraController.zoom;
				playerSetSize.x = MathF.Max(playerSetSize.x, minSize.x);
				UpdateSize();
			}
			if (verticalResize)
			{
				playerSetSize.y -= eventData.delta.y / workspace.editorCanvas.scaleFactor / workspace.cameraController.zoom;
				playerSetSize.y = MathF.Max(playerSetSize.y, minSize.y);
				UpdateSize();
			}
			if (!horitontalResize && !verticalResize)
			{
				rectTransform.anchoredPosition += eventData.delta / workspace.editorCanvas.scaleFactor / workspace.cameraController.zoom;
			}
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			IsPointerOnResizeArea(pointerDownPosition, out horitontalResize, out verticalResize);
			if (horitontalResize || verticalResize)
			{
				playerSetSize = ((RectTransform)base.transform).sizeDelta;
			}
			if (dockable && !verticalResize && !horitontalResize)
			{
				Undock();
				GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		workspace.UpdateContainerSize();
		if (dockable && !verticalResize && !horitontalResize)
		{
			Window window = eventData.pointerCurrentRaycast.gameObject?.GetComponent<Window>();
			if (window == null)
			{
				window = eventData.pointerCurrentRaycast.gameObject?.GetComponentInParent<Window>();
			}
			DockOnto(window);
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		if (playerSetSize.x <= minSize.x)
		{
			playerSetSize.x = 0f;
		}
		if (playerSetSize.y <= minSize.y)
		{
			playerSetSize.y = 0f;
		}
		UpdateSize();
		horitontalResize = false;
		verticalResize = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			MoveToFront();
			pointerDownPosition = eventData.position;
		}
	}

	public void IsPointerOnResizeArea(Vector2 screenPoint, out bool horizontal, out bool vertical)
	{
		RectTransform rectTransform = (RectTransform)base.transform;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, workspace.uiCam, out var localPoint);
		localPoint.y = 0f - localPoint.y;
		horizontal = rectTransform.rect.width - localPoint.x < resizeMargin && !isMinimized;
		vertical = rectTransform.rect.height - localPoint.y < resizeMargin && !isMinimized;
	}

	public void MoveToFront()
	{
		HighestDockedParent.transform.SetAsLastSibling();
	}

	public void DockOnto(Window other)
	{
		if (!(other == null) && other.dockable && dockable)
		{
			other.DockedChild?.DockOnto(LeastDockedChild);
			base.transform.SetParent(other.dockPosition, worldPositionStays: false);
			((RectTransform)base.transform).anchoredPosition = Vector2.zero;
			dockedParent = other;
		}
	}

	public void Undock()
	{
		if (dockedParent != null)
		{
			base.transform.SetParent(workspace.container);
			dockedParent = null;
		}
	}

	public void Rename(string newName)
	{
		workspace.openWindows.Remove(windowName);
		workspace.openWindows[newName] = this;
		if (TryGetComponent<CodeWindow>(out var component))
		{
			workspace.codeWindows.Remove(windowName, out var _);
			workspace.codeWindows[newName] = component;
		}
		windowName = newName;
	}
}
