using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Draggable : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IScrollHandler, IPointerExitHandler, IPointerEnterHandler
{
	[Header("Selection Objects")]
	[Tooltip("The object that we turn on/off when we enter/leave this draggable.")]
	public GameObject HoverObject;

	[Header("Hovering")]
	[Tooltip("When this object is hovered do you want to see hover sprites.")]
	public bool UseHoverSprites;

	[Header("Child offsets")]
	[Tooltip("The distance that you want to offset this object when it is being dragged outside the scroll rect.")]
	[SerializeField]
	private float _bottomOffset = 35f;

	[HideInInspector]
	public bool CanExitHover = true;

	[HideInInspector]
	public DraggableScrollRect MainScroll;

	private List<RectTransform> _siblings = new List<RectTransform>();

	private bool _isDragging;

	private int _newIndex;

	private float _halfHeightElement;

	public UnityEvent BeginDrag;

	public void Start()
	{
		MainScroll = GetComponentInParent<DraggableScrollRect>();
		if (BeginDrag == null)
		{
			BeginDrag = new UnityEvent();
		}
		_halfHeightElement = GetComponent<RectTransform>().rect.height / 2f;
	}

	private void Update()
	{
		if (_isDragging)
		{
			if (_siblings.Count != base.transform.parent.childCount)
			{
				FindAllSiblings();
			}
			Transform transform = null;
			if (!MainScroll.OutsideBottomSide)
			{
				transform = ((!MainScroll.OutsideTopSide) ? GetClosestSibling() : GetClosestSibling(MainScroll.ViewPortRectTransform.position));
			}
			else
			{
				Vector3 position = MainScroll.ViewPortRectTransform.position;
				position.y -= MainScroll.ViewPortRectTransform.rect.height - _bottomOffset;
				transform = GetClosestSibling(position);
			}
			int siblingIndex = transform.GetSiblingIndex();
			base.transform.SetSiblingIndex(siblingIndex);
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		BeginDrag.Invoke();
		FindAllSiblings();
		MainScroll.OnBeginDrag(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		_isDragging = true;
		if (!MainScroll.OutsideBottomSide && !MainScroll.OutsideTopSide)
		{
			if (_siblings.Count != base.transform.parent.childCount)
			{
				FindAllSiblings();
			}
			int siblingIndex = GetClosestSibling().GetSiblingIndex();
			base.transform.SetSiblingIndex(siblingIndex);
			MainScroll.OnDrag(eventData);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		_isDragging = false;
		if (_siblings.Count != base.transform.parent.transform.childCount)
		{
			FindAllSiblings();
		}
		Transform closestSibling = GetClosestSibling();
		_newIndex = closestSibling.GetSiblingIndex();
		base.transform.parent.SetSiblingIndex(closestSibling.GetSiblingIndex());
		MainScroll.OnDraggableChangedPositionEvent.Invoke();
		MainScroll.OnEndDrag(eventData);
	}

	public void OnScroll(PointerEventData eventData)
	{
		MainScroll.OnScroll(eventData);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (UseHoverSprites)
		{
			HoverObject.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (UseHoverSprites && CanExitHover)
		{
			HoverObject.SetActive(value: false);
		}
	}

	private void FindAllSiblings()
	{
		_siblings.Clear();
		foreach (RectTransform item in base.transform.parent.transform)
		{
			_siblings.Add(item);
		}
	}

	private Transform GetClosestSibling()
	{
		Vector3 position = base.transform.position;
		position.y = FlotsamInputManager.MousePosition.y;
		return GetClosestSibling(position);
	}

	private Transform GetClosestSibling(Vector3 pos)
	{
		Transform transform = _siblings[0];
		Vector3 position = transform.position;
		position.y += _halfHeightElement;
		float num = (pos - position).magnitude;
		foreach (RectTransform sibling in _siblings)
		{
			position = sibling.position;
			position.y += 10f;
			float magnitude = (pos - position).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
				transform = sibling;
			}
		}
		return transform;
	}
}
