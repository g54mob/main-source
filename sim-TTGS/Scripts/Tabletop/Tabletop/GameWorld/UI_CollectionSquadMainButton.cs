using Simulator;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadMainButton : NavButton
	{
		private bool m_selected;

		public void SetSelected(bool selected)
		{
			if (selected)
			{
				OverrideTransition(Transitioner.ESelectionState.Normal, instant: true);
			}
			m_selected = selected;
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			if (!m_selected || state == SelectionState.Normal)
			{
				base.DoStateTransition(state, instant);
			}
		}
	}
}
