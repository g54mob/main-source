using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.CurveEditor
{
	public class HandleScript : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		public event Action<PointerEventData> OnDrag;

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			this.OnDrag?.Invoke(eventData);
		}
	}
}
