using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class HeaderScript : MonoBehaviour
	{
		public delegate void CollapseDelegate(HeaderScript headerScript);

		private XmlElement _element;

		public bool Collapsed { get; private set; }

		public bool StartCollapsed { get; set; }

		public event CollapseDelegate OnCollapsedChanged;

		public void Collapse(bool collapse)
		{
			Collapsed = collapse;
			if (collapse)
			{
				_element.AddClass("collapsed");
			}
			else
			{
				_element.RemoveClass("collapsed");
			}
			for (int i = _element.transform.GetSiblingIndex() + 1; i < _element.transform.parent.childCount; i++)
			{
				Transform child = _element.transform.parent.GetChild(i);
				if (child.GetComponent<HeaderScript>() != null)
				{
					break;
				}
				PropertyRowScript component = child.gameObject.GetComponent<PropertyRowScript>();
				if (component != null)
				{
					component.Collapsed = collapse;
				}
			}
			this.OnCollapsedChanged?.Invoke(this);
		}

		public void Initialize(XmlElement element)
		{
			_element = element;
			element.GetElementByInternalId("header-background").AddOnClickEvent(delegate
			{
				OnHeaderClicked();
			});
		}

		protected virtual void Start()
		{
			if (StartCollapsed)
			{
				Collapse(StartCollapsed);
			}
		}

		private void OnHeaderClicked()
		{
			bool collapse = !_element.HasClass("collapsed");
			Collapse(collapse);
		}
	}
}
