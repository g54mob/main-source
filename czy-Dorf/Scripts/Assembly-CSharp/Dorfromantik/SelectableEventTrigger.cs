using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class SelectableEventTrigger : Selectable, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private UnityEvent onSelect;

		[SerializeField]
		private UnityEvent onDeselect;

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			onSelect.Invoke();
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			onDeselect.Invoke();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			throw new NotImplementedException();
		}
	}
}
