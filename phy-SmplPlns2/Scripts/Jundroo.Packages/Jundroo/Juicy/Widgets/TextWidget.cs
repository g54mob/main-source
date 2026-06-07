using System.Xml.Linq;
using Jundroo.Common.Extensions;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using TMPro;
using UnityEngine;

namespace Jundroo.Juicy.Widgets
{
	public class TextWidget : Widget
	{
		private bool _allowLinks;

		private int _characterLimit = -1;

		private string _richText;

		private string _text;

		public bool AllowLinks
		{
			get
			{
				return _allowLinks;
			}
			set
			{
				_allowLinks = value;
				LinkTextScript component;
				if (_allowLinks)
				{
					base.gameObject.AddMissingComponent<LinkTextScript>();
				}
				else if (base.gameObject.TryGetComponent<LinkTextScript>(out component))
				{
					Object.Destroy(component);
				}
			}
		}

		public int CharacterLimit
		{
			get
			{
				return _characterLimit;
			}
			set
			{
				if (_characterLimit != value)
				{
					_characterLimit = value;
					SetText(_text, setStyle: false);
				}
			}
		}

		public ColorProperty Color { get; private set; }

		public string RichText
		{
			get
			{
				return _richText;
			}
			set
			{
				if (_richText != value)
				{
					_richText = value;
					value = value.Replace('[', '<');
					value = value.Replace(']', '>');
					Text = value;
				}
			}
		}

		public string Text
		{
			get
			{
				return TextMeshPro.text;
			}
			set
			{
				if (_text != value)
				{
					SetText(value, setStyle: true);
				}
			}
		}

		public TextMeshProUGUI TextMeshPro { get; private set; }

		protected override AttributeSet AttributeSet => TextAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
			Color = new ColorProperty(TextMeshPro.color.gamma, delegate(Color x)
			{
				TextMeshPro.color = x;
			});
		}

		public void SetText(string text, bool setStyle)
		{
			_text = text;
			TextMeshPro.text = _text;
			TextMeshPro.maxVisibleCharacters = ((_characterLimit < 0) ? int.MaxValue : _characterLimit);
			if (setStyle)
			{
				base.Style.Attributes["text"] = text;
			}
		}
	}
}
