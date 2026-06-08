using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik.UI.Components
{
	public class UiButton : Button
	{
		[SerializeField]
		private UnityEvent onSelect;

		[SerializeField]
		private UnityEvent onDeselect;

		private RectTransform _003CRectTransform_003Ek__BackingField;

		public RectTransform RectTransform
		{
			get
			{
				return _003CRectTransform_003Ek__BackingField;
			}
			private set
			{
				_003CRectTransform_003Ek__BackingField = value;
			}
		}

		public event Action OnSelected;

		public event Action OnDeselected;

		protected override void Awake()
		{
			base.Awake();
			RectTransform = GetComponent<RectTransform>();
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			onSelect.Invoke();
			this.OnSelected?.Invoke();
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			onDeselect.Invoke();
			this.OnDeselected?.Invoke();
		}
	}
}
