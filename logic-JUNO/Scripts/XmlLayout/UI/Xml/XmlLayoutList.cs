using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml
{
	public class XmlLayoutList : MonoBehaviour
	{
		public XmlElement itemTemplate;

		public string DataSource;

		private XmlElement _listElement;

		private RectTransform _rectTransform;

		public List<XmlLayoutListItem> listItems = new List<XmlLayoutListItem>();

		public ShowAnimation itemShowAnimation;

		public HideAnimation itemHideAnimation;

		public float itemAnimationDuration = 0.25f;

		public XmlElement listElement
		{
			get
			{
				if (_listElement == null)
				{
					_listElement = GetComponent<XmlElement>();
				}
				return _listElement;
			}
		}

		public RectTransform rectTransform
		{
			get
			{
				if (_rectTransform == null)
				{
					_rectTransform = base.transform as RectTransform;
				}
				return _rectTransform;
			}
		}

		public int baseSiblingIndex { get; set; }

		public IObservableList list { get; set; }

		public bool isCalculatedList { get; set; }
	}
}
