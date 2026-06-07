using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	public class XmlLayoutDropdownComponent : Dropdown
	{
		private XmlElement m_xmlElement;

		private XmlElement xmlElement
		{
			get
			{
				if (m_xmlElement == null)
				{
					m_xmlElement = GetComponent<XmlElement>();
				}
				return m_xmlElement;
			}
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			base.DoStateTransition(state, instant);
			if (xmlElement != null)
			{
				xmlElement.NotifySelectionStateChanged((XmlElement.SelectionState)state);
			}
		}

		protected override DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			DropdownItem dropdownItem = base.CreateItem(itemTemplate);
			RectTransform component = dropdownItem.GetComponent<RectTransform>();
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.zero;
			return dropdownItem;
		}
	}
}
