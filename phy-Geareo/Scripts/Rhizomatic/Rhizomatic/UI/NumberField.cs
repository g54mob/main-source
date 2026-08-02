using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rhizomatic.UI
{
	public class NumberField : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public InputFieldAdapter inputField;

		public NumberFieldParser parser;

		public float _value;

		public float step;

		public float speed;

		public string format;

		public UnityEvent<float> onValueChanged;

		public UnityEvent onStartEdit;

		public UnityEvent onEndEdit;

		private Vector2 startPosition;

		private float startValue;

		private float preEditValue;

		private bool editing;

		private bool startedEditing;

		public float value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void SetValue(float value)
		{
		}

		public void SetValueWithoutNotify(float value)
		{
		}

		public string GetTextValue()
		{
			return null;
		}
	}
}
