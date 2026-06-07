using System;
using System.Collections;
using CTS.BBT;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class SlotableItem : MonoBehaviour, IDragHandler, IEventSystemHandler, IDropHandler, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private float _timeByDistanceFactor = 0.0002f;

		[SerializeField]
		private LayerMask _uimask;

		private Transform _originParent;

		private Vector3 _originToParentPosition;

		private bool _onDrag;

		private Canvas _canvas;

		private Vector3 _toTargetParentPosition = Vector3.zero;

		private Coroutine snapCoroutine;

		private Coroutine _resizeCoroutine;

		private float _currentScale = 1f;

		private bool locked;

		private static AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public StockItemSO Item { get; private set; }

		public RectTransform _dragRectTransform { get; private set; }

		public event Action<bool> OnSlotted;

		public event Action OnUnslottedItem;

		public static event Action<bool> OnItemDragged;

		private void Awake()
		{
			_dragRectTransform = GetComponent<RectTransform>();
			_canvas = GetComponentInParent<Canvas>();
			_originToParentPosition = base.transform.localPosition;
			_originParent = base.transform.parent;
		}

		public void SetData(StockItemSO p_item)
		{
			Item = p_item;
			_image.sprite = Item.Icon;
		}

		public void SetLocked(bool p_locked)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!_onDrag && !locked)
			{
				if (_resizeCoroutine != null)
				{
					StopCoroutine(_resizeCoroutine);
				}
				_resizeCoroutine = StartCoroutine(ResizeIconScale(1.25f));
				SlotableItem.OnItemDragged?.Invoke(obj: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!locked && !_onDrag)
			{
				if (_resizeCoroutine != null)
				{
					StopCoroutine(_resizeCoroutine);
				}
				_resizeCoroutine = StartCoroutine(ResizeIconScale(1f));
				SlotableItem.OnItemDragged?.Invoke(obj: false);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!locked)
			{
				_dragRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (!locked)
			{
				DropSlotable();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_onDrag = true;
			if (snapCoroutine != null)
			{
				StopCoroutine(snapCoroutine);
			}
			if (_resizeCoroutine != null)
			{
				StopCoroutine(_resizeCoroutine);
			}
			_resizeCoroutine = StartCoroutine(ResizeIconScale(1.5f));
			_image.raycastTarget = false;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_onDrag = false;
			DropSlotable();
			_image.raycastTarget = true;
		}

		public void DropSlotable()
		{
			if (snapCoroutine != null)
			{
				StopCoroutine(snapCoroutine);
			}
			if (IngredientSlot.currentHoveredSlot != null && IngredientSlot.currentHoveredSlot.IsAuthorised(Item.Name))
			{
				snapCoroutine = StartCoroutine(SnapToPosition(IngredientSlot.currentHoveredSlot.transform, _toTargetParentPosition));
				this.OnSlotted?.Invoke(obj: true);
				IngredientSlot.currentHoveredSlot.AddItemToSlot(this);
			}
			else
			{
				snapCoroutine = StartCoroutine(SnapToPosition(_originParent, _originToParentPosition));
				this.OnSlotted?.Invoke(obj: false);
				this.OnUnslottedItem?.Invoke();
			}
			if (_resizeCoroutine != null)
			{
				StopCoroutine(_resizeCoroutine);
			}
			_resizeCoroutine = StartCoroutine(ResizeIconScale(1f));
			SlotableItem.OnItemDragged?.Invoke(obj: false);
		}

		private IEnumerator SnapToPosition(Transform p_parent, Vector3 p_DestinationLocalPosition)
		{
			base.transform.SetParent(p_parent);
			Vector3 dropPosition = base.transform.localPosition;
			float timeByDistance = Vector3.Distance(dropPosition, p_DestinationLocalPosition) * _timeByDistanceFactor;
			float currentTimer = 0f;
			do
			{
				currentTimer += Time.unscaledDeltaTime;
				base.transform.localPosition = Vector3.Lerp(dropPosition, p_DestinationLocalPosition, curve.Evaluate(Mathf.InverseLerp(0f, timeByDistance, currentTimer)));
				yield return null;
			}
			while (currentTimer < timeByDistance);
			base.transform.localPosition = p_DestinationLocalPosition;
			snapCoroutine = null;
		}

		private IEnumerator ResizeIconScale(float p_newScale)
		{
			float scaleTransitionValue = 0f;
			float startValue = _currentScale;
			while (scaleTransitionValue < 1f)
			{
				yield return null;
				scaleTransitionValue += Time.unscaledDeltaTime * 20f;
				_currentScale = Mathf.Lerp(startValue, p_newScale, scaleTransitionValue);
				base.transform.localScale = Vector3.one * _currentScale;
			}
			_currentScale = p_newScale;
			base.transform.localScale = Vector3.one * _currentScale;
			_resizeCoroutine = null;
		}
	}
}
