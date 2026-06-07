using System;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	public class ChartText
	{
		private Text m_Text;

		private TextAnchor m_TextAlignment;

		public Text text
		{
			get
			{
				return m_Text;
			}
			set
			{
				m_Text = value;
			}
		}

		public GameObject gameObject
		{
			get
			{
				if (m_Text != null)
				{
					return m_Text.gameObject;
				}
				return null;
			}
		}

		public TextAnchor alignment
		{
			get
			{
				return m_TextAlignment;
			}
			set
			{
				SetAlignment(alignment);
			}
		}

		public ChartText()
		{
		}

		public ChartText(GameObject textParent)
		{
			m_Text = textParent.GetComponentInChildren<Text>();
			if (m_Text == null)
			{
				Debug.LogError("can't find Text component:" + textParent);
			}
		}

		public void SetFontSize(float fontSize)
		{
			if (m_Text != null)
			{
				m_Text.fontSize = (int)fontSize;
			}
		}

		public void SetText(string text)
		{
			text = ((text != null) ? text.Replace("\\n", "\n") : string.Empty);
			if (m_Text != null)
			{
				m_Text.text = text;
			}
		}

		public string GetText()
		{
			if (m_Text != null)
			{
				return m_Text.text;
			}
			return string.Empty;
		}

		public void SetColor(Color color)
		{
			if (m_Text != null)
			{
				m_Text.color = color;
			}
		}

		public void SetLineSpacing(float lineSpacing)
		{
			if (m_Text != null)
			{
				m_Text.lineSpacing = lineSpacing;
			}
		}

		public void SetActive(bool flag)
		{
			if (m_Text != null)
			{
				ChartHelper.SetActive(m_Text.gameObject, flag);
			}
		}

		public void SetLocalPosition(Vector3 position)
		{
			if (m_Text != null)
			{
				m_Text.transform.localPosition = position;
			}
		}

		public void SetRectPosition(Vector3 position)
		{
			if (m_Text != null)
			{
				m_Text.GetComponent<RectTransform>().anchoredPosition3D = position;
			}
		}

		public void SetSizeDelta(Vector2 sizeDelta)
		{
			if (m_Text != null)
			{
				m_Text.GetComponent<RectTransform>().sizeDelta = sizeDelta;
			}
		}

		public void SetLocalEulerAngles(Vector3 position)
		{
			if (m_Text != null)
			{
				m_Text.transform.localEulerAngles = position;
			}
		}

		public void SetAlignment(TextAnchor alignment)
		{
			m_TextAlignment = alignment;
			if (m_Text != null)
			{
				m_Text.alignment = alignment;
			}
		}

		public void SetFont(Font font)
		{
			if ((bool)m_Text)
			{
				m_Text.font = font;
			}
		}

		public void SetFontStyle(FontStyle fontStyle)
		{
			if (m_Text != null)
			{
				m_Text.fontStyle = fontStyle;
			}
		}

		public void SetFontAndSizeAndStyle(TextStyle textStyle, ComponentTheme theme)
		{
			if (m_Text != null)
			{
				m_Text.font = ((textStyle.font == null) ? theme.font : textStyle.font);
				m_Text.fontSize = ((textStyle.fontSize == 0) ? theme.fontSize : textStyle.fontSize);
				m_Text.fontStyle = textStyle.fontStyle;
			}
		}

		public float GetPreferredWidth(string content)
		{
			if (m_Text != null)
			{
				TextGenerator cachedTextGeneratorForLayout = m_Text.cachedTextGeneratorForLayout;
				TextGenerationSettings generationSettings = m_Text.GetGenerationSettings(Vector2.zero);
				return cachedTextGeneratorForLayout.GetPreferredWidth(content, generationSettings) / m_Text.pixelsPerUnit;
			}
			return 0f;
		}

		public float GetPreferredWidth()
		{
			if (m_Text != null)
			{
				return m_Text.preferredWidth;
			}
			return 0f;
		}

		public float GetPreferredHeight()
		{
			if (m_Text != null)
			{
				return m_Text.preferredHeight;
			}
			return 0f;
		}

		public string GetPreferredText(string content, string suffix, float maxWidth)
		{
			if (m_Text != null)
			{
				if (GetPreferredWidth(content) < maxWidth)
				{
					return content;
				}
				float preferredWidth = GetPreferredWidth(suffix);
				float num = maxWidth - 1.3f * preferredWidth;
				for (int num2 = content.Length; num2 > 0; num2--)
				{
					string text = content.Substring(0, num2);
					if (GetPreferredWidth(text) < num)
					{
						return text + suffix;
					}
				}
			}
			return string.Empty;
		}
	}
}
