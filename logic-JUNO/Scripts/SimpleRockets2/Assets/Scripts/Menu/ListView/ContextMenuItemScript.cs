using System;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class ContextMenuItemScript : MonoBehaviour
	{
		private TextMeshProUGUI _text;

		public Action<ContextMenuItemScript> ClickHandler { get; set; }

		public bool CloseContextMenuWhenClicked { get; set; } = true;

		public bool Selected
		{
			get
			{
				return XmlElement.HasClass("selected");
			}
			set
			{
				if (value)
				{
					if (!Selected)
					{
						XmlElement.AddClass("selected");
						XmlElement.ApplyAttributesRecursive();
					}
				}
				else if (Selected)
				{
					XmlElement.RemoveClass("selected");
					XmlElement.ApplyAttributesRecursive();
				}
			}
		}

		public string Text
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public string Tooltip
		{
			get
			{
				return XmlElement.Tooltip;
			}
			set
			{
				XmlElement.Tooltip = value;
			}
		}

		public bool Visible
		{
			get
			{
				return XmlElement.Visible;
			}
			set
			{
				XmlElement.SetActive(value);
			}
		}

		public XmlElement XmlElement { get; private set; }

		public void Initialize(XmlElement element)
		{
			XmlElement = element;
			_text = XmlElement.GetElementByInternalId<TextMeshProUGUI>("text");
		}
	}
}
