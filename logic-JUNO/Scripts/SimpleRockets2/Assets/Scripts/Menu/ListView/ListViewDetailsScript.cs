using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewDetailsScript : MonoBehaviour
	{
		public ListViewScript ListView { get; private set; }

		public virtual bool Visible
		{
			get
			{
				return base.transform.parent.gameObject.activeSelf;
			}
			set
			{
				base.transform.parent.gameObject.SetActive(value);
			}
		}

		public DetailsWidgetGroup Widgets { get; private set; }

		public XmlElement XmlElement { get; private set; }

		public void Initialize(XmlElement detailsElement, ListViewScript listView)
		{
			XmlElement = detailsElement;
			ListView = listView;
			Widgets = new DetailsWidgetGroup(this);
		}
	}
}
