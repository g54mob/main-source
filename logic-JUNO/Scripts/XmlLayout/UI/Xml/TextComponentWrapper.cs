using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	[Serializable]
	public class TextComponentWrapper
	{
		[SerializeField]
		private Text textComponent;

		[SerializeField]
		private TextMeshProUGUI textMeshProComponent;

		public XmlElement xmlElement;

		public string text
		{
			get
			{
				if (textMeshProComponent != null)
				{
					return textMeshProComponent.text;
				}
				if (textComponent != null)
				{
					return textComponent.text;
				}
				return null;
			}
			set
			{
				if (textMeshProComponent != null)
				{
					textMeshProComponent.text = value;
				}
				if (textComponent != null)
				{
					textComponent.text = value;
				}
			}
		}

		public float width
		{
			get
			{
				if (textMeshProComponent != null)
				{
					return textMeshProComponent.GetPreferredValues().x;
				}
				return 0f;
			}
		}

		public Color color
		{
			get
			{
				if (textMeshProComponent != null)
				{
					return textMeshProComponent.color;
				}
				if (textComponent != null)
				{
					return textComponent.color;
				}
				return default(Color);
			}
			set
			{
				if (textMeshProComponent != null)
				{
					textMeshProComponent.color = value;
				}
				if (textComponent != null)
				{
					textComponent.color = value;
				}
			}
		}

		public TextComponentWrapper(Text textComponent)
		{
			this.textComponent = textComponent;
			xmlElement = textComponent.GetComponent<XmlElement>();
		}

		public TextComponentWrapper(TextMeshProUGUI textMeshProComponent)
		{
			this.textMeshProComponent = textMeshProComponent;
			xmlElement = textMeshProComponent.GetComponent<XmlElement>();
		}
	}
}
