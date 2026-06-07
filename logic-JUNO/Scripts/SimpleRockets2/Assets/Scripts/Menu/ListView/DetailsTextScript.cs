using System;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsTextScript : DetailsWidgetBaseScript
	{
		private TextMeshProUGUI _text;

		private Lazy<XmlElement> _xmlElement;

		public TextAlignmentOptions Alignment
		{
			get
			{
				return _text.alignment;
			}
			set
			{
				_text.alignment = value;
			}
		}

		public string Color
		{
			get
			{
				return _xmlElement.Value.GetAttribute("color");
			}
			set
			{
				_xmlElement.Value.SetAndApplyAttribute("color", value);
			}
		}

		public Vector4 Margin
		{
			get
			{
				return _text.margin;
			}
			set
			{
				_text.margin = value;
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

		public override void Initialize(ListViewDetailsScript details)
		{
			_text = GetComponent<TextMeshProUGUI>();
			_xmlElement = new Lazy<XmlElement>(() => GetComponent<XmlElement>(), isThreadSafe: false);
		}
	}
}
