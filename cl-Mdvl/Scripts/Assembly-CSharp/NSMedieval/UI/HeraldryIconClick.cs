using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.UI
{
	public class HeraldryIconClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private HeraldryEditorView view;

		private Action<PointerEventData> action;

		public Action<PointerEventData> Action
		{
			set
			{
				action = value;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			action(eventData);
		}

		private void Start()
		{
			view = base.gameObject.GetComponentInParent<HeraldryEditorView>();
		}
	}
}
