using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicSlotDragHandler : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	private Canvas canvas;

	[SerializeField]
	private GameObject placeholderElementPrefab;

	private GameObject placeholderElementObject;

	private GameObject draggedSlotObject;

	private GameObject dropZoneObject;

	private int oldElementIndex;

	private int newElementIndex;

	private Transform parentTransform;

	protected float draggedSlotHeight;

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	public event Action<int, int> OnLogicSlotPositionChangedEvent;

	public void OnBeginDrag(PointerEventData eventData)
	{
		this.OnBeginDragEvent?.Invoke();
		canvas = GUIManager.Instance.LogicEditorView.ParentCanvas;
		draggedSlotObject = base.gameObject;
		dropZoneObject = draggedSlotObject.transform.parent.gameObject;
		oldElementIndex = draggedSlotObject.transform.GetSiblingIndex();
		parentTransform = draggedSlotObject.transform.parent;
		draggedSlotObject.transform.SetParent(canvas.transform);
		draggedSlotObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		placeholderElementObject = UnityEngine.Object.Instantiate(placeholderElementPrefab);
		placeholderElementObject.transform.SetParent(dropZoneObject.transform);
		placeholderElementObject.transform.localScale = Vector3.one;
		placeholderElementObject.transform.SetLocalPositionZ(0f);
		placeholderElementObject.transform.SetSiblingIndex(oldElementIndex);
		draggedSlotHeight = draggedSlotObject.GetComponent<RectTransform>().rect.height;
	}

	public void OnDrag(PointerEventData eventData)
	{
		float y = Util.ConvertMousePositionToRectTransform(canvas).y;
		float num = (draggedSlotHeight / 2f - 16f) * canvas.transform.localScale.y;
		draggedSlotObject.transform.SetPositionY(y - num);
		draggedSlotObject.transform.SetLocalPositionZ(-300f);
		int siblingIndex = placeholderElementObject.transform.GetSiblingIndex();
		foreach (Transform item3 in dropZoneObject.transform)
		{
			(float beforePosition, float afterPosition) elementPositions = GetElementPositions(item3.gameObject);
			float item = elementPositions.beforePosition;
			float item2 = elementPositions.afterPosition;
			int siblingIndex2 = placeholderElementObject.transform.GetSiblingIndex();
			int siblingIndex3 = item3.GetSiblingIndex();
			if (siblingIndex3 < siblingIndex2 && y > item)
			{
				siblingIndex = siblingIndex3;
				break;
			}
			if (siblingIndex3 > siblingIndex2 && y < item2)
			{
				siblingIndex = siblingIndex3;
				break;
			}
		}
		placeholderElementObject.transform.SetSiblingIndex(siblingIndex);
		newElementIndex = siblingIndex;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.OnEndDragEvent?.Invoke();
		UnityEngine.Object.Destroy(placeholderElementObject);
		draggedSlotObject.transform.SetParent(parentTransform, worldPositionStays: false);
		draggedSlotObject.transform.SetLocalPositionZ(0f);
		draggedSlotObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		draggedSlotObject.transform.SetSiblingIndex(oldElementIndex);
		AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		this.OnLogicSlotPositionChangedEvent?.Invoke(oldElementIndex, newElementIndex);
	}

	private (float beforePosition, float afterPosition) GetElementPositions(GameObject elementObject)
	{
		Vector3[] array = new Vector3[4];
		(elementObject.transform as RectTransform).GetWorldCorners(array);
		float y = array[1].y;
		float y2 = array[0].y;
		return (beforePosition: y, afterPosition: y2);
	}
}
