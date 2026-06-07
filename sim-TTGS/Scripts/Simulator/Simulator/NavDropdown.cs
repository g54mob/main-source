using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class NavDropdown : InteractableNavElement
	{
		[Header("Button")]
		[SerializeField]
		private TabletopDropdown m_dropdown;

		public override bool NeedToBeSelectedFirst => m_dropdown.IsExpanded;

		protected override IEnumerable<Selectable> GetChildSelectables()
		{
			yield return GetPrimarySelectable();
			foreach (Selectable childSelectable in base.GetChildSelectables())
			{
				yield return childSelectable;
			}
		}

		public override void Select()
		{
			GetPrimarySelectable().Select();
		}

		private Selectable GetPrimarySelectable()
		{
			if (m_dropdown.IsExpanded)
			{
				return m_dropdown.DropdownToggles.First((TabletopToggle x) => x.isOn);
			}
			return m_dropdown;
		}
	}
}
