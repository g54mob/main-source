using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class TextLimit : ChildComponent
	{
		[SerializeField]
		private bool m_Enable;

		[SerializeField]
		private float m_MaxWidth;

		[SerializeField]
		private float m_Gap = 1f;

		[SerializeField]
		private string m_Suffix = "...";

		private ChartText m_RelatedText;

		private float m_RelatedTextWidth;

		public bool enable
		{
			get
			{
				return m_Enable;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Enable, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float maxWidth
		{
			get
			{
				return m_MaxWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxWidth, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float gap
		{
			get
			{
				return m_Gap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Gap, value))
				{
					SetComponentDirty();
				}
			}
		}

		public string suffix
		{
			get
			{
				return m_Suffix;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Suffix, value))
				{
					SetComponentDirty();
				}
			}
		}

		public TextLimit Clone()
		{
			return new TextLimit
			{
				enable = enable,
				maxWidth = maxWidth,
				gap = gap,
				suffix = suffix
			};
		}

		public void Copy(TextLimit textLimit)
		{
			enable = textLimit.enable;
			maxWidth = textLimit.maxWidth;
			gap = textLimit.gap;
			suffix = textLimit.suffix;
		}

		public void SetRelatedText(ChartText txt, float labelWidth)
		{
			m_RelatedText = txt;
			m_RelatedTextWidth = labelWidth;
		}

		public string GetLimitContent(string content)
		{
			float num = ((m_MaxWidth > 0f) ? m_MaxWidth : m_RelatedTextWidth);
			if (m_RelatedText == null || num <= 0f)
			{
				return content;
			}
			if (m_Enable)
			{
				float preferredWidth = m_RelatedText.GetPreferredWidth(content);
				float preferredWidth2 = m_RelatedText.GetPreferredWidth(suffix);
				if (preferredWidth >= num - m_Gap * 2f)
				{
					return content.Substring(0, GetAdaptLength(content, preferredWidth2)) + suffix;
				}
				return content;
			}
			return content;
		}

		private int GetAdaptLength(string content, float suffixLen)
		{
			int num = 0;
			int num2 = content.Length / 2;
			int num3 = content.Length;
			float num4 = ((m_MaxWidth > 0f) ? m_MaxWidth : m_RelatedTextWidth) - m_Gap * 2f - suffixLen;
			if (num4 < 0f)
			{
				return 0;
			}
			float num5 = 0f;
			while (num5 != num4 && num2 != num)
			{
				num5 = m_RelatedText.GetPreferredWidth(content.Substring(0, num2));
				if (num5 < num4)
				{
					num = num2;
				}
				else
				{
					if (!(num5 > num4))
					{
						break;
					}
					num3 = num2;
				}
				num2 = (num + num3) / 2;
			}
			return num2;
		}
	}
}
