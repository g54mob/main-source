using TMPro;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class TextElementScript : BlockElementScript
	{
		private TextMeshProUGUI _tmp;

		private bool _trailingSpace;

		public bool RichText
		{
			get
			{
				return _tmp.richText;
			}
			set
			{
				_tmp.richText = value;
			}
		}

		public string Text
		{
			get
			{
				return _tmp.text;
			}
			set
			{
				_trailingSpace = value.EndsWith(" ");
				_tmp.text = value;
			}
		}

		public override Vector2 LayoutElement()
		{
			Vector2 vector = new Vector2(_tmp.preferredWidth + (float)base.Padding.left + (float)base.Padding.right, base.RectTransform.sizeDelta.y + (float)base.Padding.top + (float)base.Padding.bottom);
			if (_trailingSpace)
			{
				vector.x += 5.581395f;
			}
			GetComponent<RectTransform>().sizeDelta = vector;
			return vector;
		}

		public void SetTextColor(Color color)
		{
			_tmp.color = color;
		}

		protected override void Awake()
		{
			base.Awake();
			_tmp = GetComponent<TextMeshProUGUI>();
		}
	}
}
