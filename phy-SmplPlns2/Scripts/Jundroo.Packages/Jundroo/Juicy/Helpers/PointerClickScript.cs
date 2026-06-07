using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jundroo.Juicy.Helpers
{
	public class PointerClickScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public event EventHandler<PointerEventData> PointerClick;

		public void OnPointerClick(PointerEventData eventData)
		{
			this.PointerClick?.Invoke(this, eventData);
		}
	}
}
