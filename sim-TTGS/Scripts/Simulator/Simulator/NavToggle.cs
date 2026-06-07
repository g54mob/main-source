using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class NavToggle : InteractableNavElement
	{
		[Header("Toggle")]
		[SerializeField]
		private Toggle m_toggle;

		public Toggle Toggle => m_toggle;

		protected override void OnEnable()
		{
			base.OnEnable();
			Toggle.onValueChanged.AddListener(OnToggleValueChanged);
			OnToggleValueChanged(m_toggle.isOn);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}

		private void OnToggleValueChanged(bool value)
		{
			if (m_toggle.graphic == null)
			{
				OverrideTransition(value ? Transitioner.ESelectionState.Pressed : Transitioner.ESelectionState.Normal, instant: false);
			}
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			if (!m_toggle.isOn)
			{
				base.DoStateTransition(state, instant);
			}
		}

		protected override IEnumerable<Selectable> GetChildSelectables()
		{
			if (m_toggle != null)
			{
				yield return m_toggle;
			}
			foreach (Selectable childSelectable in base.GetChildSelectables())
			{
				yield return childSelectable;
			}
		}
	}
}
