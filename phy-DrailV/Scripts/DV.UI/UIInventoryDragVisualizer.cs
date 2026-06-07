using DV.Common;
using DV.UI;
using DV.UI.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryDragVisualizer : MonoBehaviour
{
	private const float FORWARD_OFFSET = 1f;

	private RectTransform dragTransform;

	private InventoryGridElement gridElement;

	[SerializeField]
	private Image visualizerImage;

	private Sprite fallbackSprite;

	private UIDragParent dragParent;

	private Transform originalParent;

	private UIDragElement dragElement;

	private bool deinitVisualizerOnEnable;

	private void Awake()
	{
		dragElement = GetComponentInParent<UIDragElement>();
		if (dragElement == null)
		{
			Debug.LogError("Missing UIDragElement on " + base.name);
			Object.Destroy(this);
		}
		else
		{
			gridElement = GetComponentInParent<InventoryGridElement>();
			fallbackSprite = visualizerImage.sprite;
			SetupListeners(on: true);
		}
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void OnEnable()
	{
		if (deinitVisualizerOnEnable)
		{
			DeinitVisualizer();
			deinitVisualizerOnEnable = false;
		}
	}

	private void Start()
	{
		originalParent = base.transform.parent;
		dragParent = GetComponentInParent<UIDragParent>();
	}

	private void SetupListeners(bool on)
	{
		if (!(dragElement == null))
		{
			dragElement.DragStarted -= OnDragStarted;
			dragElement.DragOngoing -= OnDragOngoing;
			dragElement.DragEnded -= OnDragEnded;
			if (on)
			{
				dragElement.DragStarted += OnDragStarted;
				dragElement.DragOngoing += OnDragOngoing;
				dragElement.DragEnded += OnDragEnded;
			}
		}
	}

	private void OnDragEnded(PointerEventData _, bool forced)
	{
		deinitVisualizerOnEnable = forced;
		if (!deinitVisualizerOnEnable)
		{
			DeinitVisualizer();
		}
	}

	private void OnDragOngoing(PointerEventData eventData)
	{
		UpdateVisualizer(eventData);
	}

	private void OnDragStarted(PointerEventData eventData)
	{
		IInventoryItemSpec spec = gridElement.Data.Spec;
		if (spec != null)
		{
			Sprite itemIconSprite = spec.ItemIconSprite;
			InitVisualizer(itemIconSprite, eventData);
		}
	}

	private void InitVisualizer(Sprite sprite, PointerEventData eventData)
	{
		DeinitVisualizer();
		if (sprite != null)
		{
			visualizerImage.sprite = sprite;
		}
		visualizerImage.gameObject.SetActive(value: true);
		Transform parent = ((dragParent != null) ? dragParent.DragParent : originalParent);
		base.transform.SetParent(parent, worldPositionStays: true);
		UpdateVisualizer(eventData);
	}

	private void UpdateVisualizer(PointerEventData eventData)
	{
		if (eventData.pointerEnter != null && eventData.pointerEnter.transform is RectTransform rectTransform)
		{
			dragTransform = rectTransform;
		}
		if (!(dragTransform == null) && RectTransformUtility.ScreenPointToWorldPointInRectangle(dragTransform, eventData.position, eventData.pressEventCamera, out var worldPoint))
		{
			base.transform.position = worldPoint - base.transform.forward * 1f;
			base.transform.rotation = dragTransform.rotation;
		}
	}

	private void DeinitVisualizer()
	{
		base.transform.SetParent(originalParent, worldPositionStays: true);
		visualizerImage.sprite = fallbackSprite;
		visualizerImage.gameObject.SetActive(value: false);
	}
}
