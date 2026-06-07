using Simulator;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadSelectionPlayButton : NavButton
	{
		private bool m_isValid;

		public void SetValid(bool valid)
		{
			m_isValid = valid;
			OverrideTransition((!m_isValid) ? Transitioner.ESelectionState.Disabled : Transitioner.ESelectionState.Normal, instant: true);
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			if (m_isValid)
			{
				base.DoStateTransition(state, instant);
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (m_isValid)
			{
				base.OnPointerClick(eventData);
			}
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			if (m_isValid)
			{
				base.OnSubmit(eventData);
			}
		}
	}
}
