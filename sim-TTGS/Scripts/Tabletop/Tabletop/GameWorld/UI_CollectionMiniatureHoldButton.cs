using System;
using Simulator;
using UnityEngine.EventSystems;

namespace Tabletop.GameWorld
{
	public class UI_CollectionMiniatureHoldButton : TabletopButton
	{
		public Action SubmitEvent;

		public Action SubmitHoldCompleteEvent;

		private bool m_available;

		private bool m_holdComplete;

		public void SetAvailable(bool available)
		{
			m_available = available;
			SetCanHold(available);
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
			if (!m_available)
			{
				SubmitEvent?.Invoke();
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			SetCanHold(canHold: false);
			base.OnPointerDown(eventData);
			SubmitEvent?.Invoke();
		}

		protected override void OnSubmitHold(BaseEventData eventData)
		{
			SubmitHoldCompleteEvent?.Invoke();
			m_holdComplete = true;
		}

		protected override void OnKillDelayedCall()
		{
			if (m_holdComplete)
			{
				m_holdComplete = false;
				return;
			}
			base.OnKillDelayedCall();
			SubmitEvent?.Invoke();
		}
	}
}
