using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InstructionDragHandlerBase : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	[SerializeField]
	protected GameObject placeholderElementPrefab;

	protected GameObject placeholderElementObject;

	protected GameObject draggedSlotObject;

	protected GameObject dropZoneObject;

	protected int oldElementIndex;

	protected int newElementIndex;

	protected Transform parentTransform;

	protected float draggedSlotHeight;

	protected InstructionDropZone selectedInstructionDropZone;

	private Canvas canvas;

	protected Canvas ParentCanvas
	{
		get
		{
			if (canvas == null)
			{
				canvas = GetComponentInParent<Canvas>();
			}
			return canvas;
		}
	}

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	protected virtual void Awake()
	{
	}

	public virtual void OnBeginDrag(PointerEventData eventData)
	{
		this.OnBeginDragEvent?.Invoke();
	}

	public virtual void OnDrag(PointerEventData eventData)
	{
	}

	public virtual void OnEndDrag(PointerEventData eventData)
	{
		this.OnEndDragEvent?.Invoke();
	}

	protected void DraggingZonesChecks()
	{
		float y = Util.ConvertMousePositionToRectTransform(ParentCanvas).y;
		float num = (draggedSlotHeight / 2f - 16f) * ParentCanvas.transform.localScale.y;
		draggedSlotObject.transform.SetPositionY(y - num);
		draggedSlotObject.transform.SetLocalPositionZ(-300f);
		(float beforePosition, float afterPosition) elementPositions = GetElementPositions(dropZoneObject);
		float item = elementPositions.beforePosition;
		float item2 = elementPositions.afterPosition;
		int siblingIndex = placeholderElementObject.transform.GetSiblingIndex();
		foreach (Transform item5 in dropZoneObject.transform)
		{
			(float beforePosition, float afterPosition) elementPositions2 = GetElementPositions(item5.gameObject);
			float item3 = elementPositions2.beforePosition;
			float item4 = elementPositions2.afterPosition;
			int siblingIndex2 = placeholderElementObject.transform.GetSiblingIndex();
			int siblingIndex3 = item5.GetSiblingIndex();
			if (y < item2 || y > item)
			{
				InstructionDropZone component = dropZoneObject.GetComponent<InstructionDropZone>();
				if (!component.IsRootLevel)
				{
					var (num2, num3) = GetElementPositions(component.ParentSlotObject);
					if (y < num3 || y > num2)
					{
						if (y < num3)
						{
							siblingIndex = component.ParentSlotObject.transform.GetSiblingIndex() + 1;
						}
						else if (y > num2)
						{
							siblingIndex = component.ParentSlotObject.transform.GetSiblingIndex();
						}
						dropZoneObject = component.ParentSlotObject.transform.parent.gameObject;
						placeholderElementObject.transform.SetParent(dropZoneObject.transform);
						selectedInstructionDropZone = dropZoneObject.GetComponent<InstructionDropZone>();
						break;
					}
					bool flag = false;
					InstructionDropZone[] componentsInChildren = component.ParentSlotObject.GetComponentsInChildren<InstructionDropZone>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						if (!(component == componentsInChildren[i]) && !componentsInChildren[i].IsZoneHidden)
						{
							var (num4, num5) = GetElementPositions(componentsInChildren[i].gameObject);
							if (y < num4 && y > num5)
							{
								float num6 = num5 - y;
								float num7 = y - num4;
								siblingIndex = ((num6 > num7) ? componentsInChildren[i].transform.childCount : 0);
								dropZoneObject = componentsInChildren[i].gameObject;
								placeholderElementObject.transform.SetParent(componentsInChildren[i].transform);
								selectedInstructionDropZone = componentsInChildren[i];
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (y < item3 && y > item4)
			{
				InstructionDropZone[] componentsInChildren2 = item5.GetComponentsInChildren<InstructionDropZone>(includeInactive: true);
				if (componentsInChildren2 != null && componentsInChildren2.Length >= 1)
				{
					bool flag2 = false;
					for (int j = 0; j < componentsInChildren2.Length; j++)
					{
						if (!componentsInChildren2[j].IsZoneHidden)
						{
							var (num8, num9) = GetElementPositions(componentsInChildren2[j].gameObject);
							if (y < num8 && y > num9)
							{
								float num10 = num9 - y;
								float num11 = y - num8;
								siblingIndex = ((num10 > num11) ? componentsInChildren2[j].transform.childCount : 0);
								dropZoneObject = componentsInChildren2[j].gameObject;
								placeholderElementObject.transform.SetParent(dropZoneObject.transform);
								selectedInstructionDropZone = componentsInChildren2[j];
								flag2 = true;
								break;
							}
						}
					}
					if (flag2)
					{
						break;
					}
				}
			}
			if (siblingIndex3 < siblingIndex2 && y > item3)
			{
				siblingIndex = siblingIndex3;
				break;
			}
			if (siblingIndex3 > siblingIndex2 && y < item4)
			{
				siblingIndex = siblingIndex3;
				break;
			}
		}
		placeholderElementObject.transform.SetSiblingIndex(siblingIndex);
		newElementIndex = siblingIndex;
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
