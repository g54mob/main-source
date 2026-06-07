using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.XR.UI
{
	public class RadialDragArea : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
	{
		[SerializeField]
		private float _maxAngle = 360f;

		[SerializeField]
		private float _minAngle;

		[SerializeField]
		private Transform _pointerTransform;

		[SerializeField]
		private RectTransform _referenceTransform;

		[SerializeField]
		private float _value;

		public bool IsDragging { get; private set; }

		public float MaxAngle
		{
			get
			{
				return _maxAngle;
			}
			set
			{
				_maxAngle = value;
			}
		}

		public float MinAngle
		{
			get
			{
				return _minAngle;
			}
			set
			{
				_minAngle = value;
			}
		}

		public float Value
		{
			get
			{
				return _value;
			}
			set
			{
				SetValueQuietly(value);
				this.OnValueChange?.Invoke(_value);
			}
		}

		public event Action<float> OnValueChange;

		public void OnBeginDrag(PointerEventData eventData)
		{
			IsDragging = true;
		}

		public void OnDrag(PointerEventData eventData)
		{
			PointerEvent(eventData);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			IsDragging = false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			PointerEvent(eventData);
		}

		public void SetValueQuietly(float value)
		{
			value = Mathf.Clamp01(value);
			_value = value;
			SetIndicator(Mathf.Lerp(_minAngle, _maxAngle, value));
		}

		private void PointerEvent(PointerEventData eventData)
		{
			if (base.isActiveAndEnabled && RectTransformUtility.ScreenPointToLocalPointInRectangle(_referenceTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				float num;
				for (num = Vector2.SignedAngle(Vector2.up, localPoint); num + 360f < _maxAngle; num += 360f)
				{
				}
				Value = Mathf.Clamp01(Mathf.InverseLerp(_minAngle, _maxAngle, num));
			}
		}

		private void SetIndicator(float angle)
		{
			_pointerTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
