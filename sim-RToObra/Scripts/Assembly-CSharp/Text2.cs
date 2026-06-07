using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text2 : Text
{
	public enum Fit
	{
		Default = 0,
		FitHorizontal = 1,
		FitVertical = 2
	}

	public enum RtlAlign
	{
		OverrideLeftMoveToRightExtentsBox = 0,
		OverrideLeftMoveToRightWidestLine = 1,
		OverrideRightMoveToLeft = 2,
		None = 3
	}

	public Fit fit;

	public bool justify;

	public RtlAlign rtlAlign;

	public int rtlAlignExtentsBoxPadRight;

	private TextWrapper textWrapper = new TextWrapper();

	private readonly UIVertex[] m_TempVerts = new UIVertex[4];

	private bool wantCustomWrap
	{
		get
		{
			return base.horizontalOverflow == HorizontalWrapMode.Wrap && (Lang.loadedLanguage.isAsian || Lang.loadedLanguage.isRTL);
		}
	}

	public override float preferredWidth
	{
		get
		{
			TextGenerationSettings generationSettings = GetGenerationSettings(Vector2.zero);
			return base.cachedTextGeneratorForLayout.GetPreferredWidth(m_Text, generationSettings) / base.pixelsPerUnit;
		}
	}

	public override float preferredHeight
	{
		get
		{
			Vector2 extents = new Vector2(GetPixelAdjustedRect().size.x, 0f);
			TextGenerationSettings generationSettings = GetGenerationSettings(extents);
			if (wantCustomWrap)
			{
				generationSettings.horizontalOverflow = HorizontalWrapMode.Overflow;
				string str = textWrapper.Wrap(text, base.cachedTextGeneratorForLayout, generationSettings, RtlHelper.HasRtl(text));
				return base.cachedTextGeneratorForLayout.GetPreferredHeight(str, generationSettings) / base.pixelsPerUnit;
			}
			return base.cachedTextGeneratorForLayout.GetPreferredHeight(m_Text, generationSettings) / base.pixelsPerUnit;
		}
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (base.font == null)
		{
			return;
		}
		m_DisableFontTextureRebuiltCallback = true;
		Vector2 size = base.rectTransform.rect.size;
		TextGenerationSettings settings = GetGenerationSettings(size);
		bool flag = RtlHelper.HasRtl(this.text);
		string text = CalcCustomWrap(ref settings, base.cachedTextGenerator, size, flag);
		if (flag)
		{
			string[] array = text.Split('\n');
			if ((settings.textAnchor == TextAnchor.LowerLeft || settings.textAnchor == TextAnchor.MiddleLeft || settings.textAnchor == TextAnchor.UpperLeft) && (rtlAlign == RtlAlign.OverrideLeftMoveToRightExtentsBox || rtlAlign == RtlAlign.OverrideLeftMoveToRightWidestLine))
			{
				if (settings.textAnchor == TextAnchor.LowerLeft)
				{
					settings.textAnchor = TextAnchor.LowerRight;
				}
				if (settings.textAnchor == TextAnchor.MiddleLeft)
				{
					settings.textAnchor = TextAnchor.MiddleRight;
				}
				if (settings.textAnchor == TextAnchor.UpperLeft)
				{
					settings.textAnchor = TextAnchor.UpperRight;
				}
				if (rtlAlign == RtlAlign.OverrideLeftMoveToRightWidestLine)
				{
					float num = 0f;
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						num = Mathf.Max(num, base.cachedTextGenerator.GetPreferredWidth(text2.Trim(), settings));
					}
					settings.generationExtents.x = num;
				}
				else
				{
					settings.generationExtents.x -= rtlAlignExtentsBoxPadRight;
				}
			}
			else if (rtlAlign == RtlAlign.OverrideRightMoveToLeft)
			{
				if (settings.textAnchor == TextAnchor.LowerRight)
				{
					settings.textAnchor = TextAnchor.LowerLeft;
				}
				if (settings.textAnchor == TextAnchor.MiddleRight)
				{
					settings.textAnchor = TextAnchor.MiddleLeft;
				}
				if (settings.textAnchor == TextAnchor.UpperRight)
				{
					settings.textAnchor = TextAnchor.UpperLeft;
				}
			}
			text = string.Join("\n", array);
		}
		base.cachedTextGenerator.PopulateWithErrors(text, settings, base.gameObject);
		IList<UIVertex> verts = base.cachedTextGenerator.verts;
		float num2 = 1f / base.pixelsPerUnit;
		int num3 = verts.Count - 4;
		Vector2 vector = new Vector2(verts[0].position.x, verts[0].position.y) * num2;
		vector = PixelAdjustPoint(vector) - vector;
		toFill.Clear();
		if (vector != Vector2.zero)
		{
			for (int j = 0; j < num3; j++)
			{
				int num4 = j & 3;
				m_TempVerts[num4] = verts[j];
				m_TempVerts[num4].position *= num2;
				m_TempVerts[num4].position.x += vector.x;
				m_TempVerts[num4].position.y += vector.y;
				if (num4 == 3)
				{
					toFill.AddUIVertexQuad(m_TempVerts);
				}
			}
		}
		else
		{
			for (int k = 0; k < num3; k++)
			{
				int num5 = k & 3;
				m_TempVerts[num5] = verts[k];
				m_TempVerts[num5].position *= num2;
				if (num5 == 3)
				{
					toFill.AddUIVertexQuad(m_TempVerts);
				}
			}
		}
		if (justify)
		{
			Justify(toFill, text);
		}
		m_DisableFontTextureRebuiltCallback = false;
	}

	private string CalcCustomWrap(ref TextGenerationSettings settings, TextGenerator generator, Vector2 extents, bool rtl)
	{
		if (fit == Fit.FitVertical)
		{
			string text = this.text;
			if (wantCustomWrap)
			{
				settings.horizontalOverflow = HorizontalWrapMode.Overflow;
			}
			int num = Mathf.Min(20, -(4 - base.fontSize));
			for (int i = 0; i < num; i++)
			{
				settings.fontSize = base.fontSize - i;
				if (wantCustomWrap)
				{
					text = textWrapper.Wrap(this.text, base.cachedTextGenerator, settings, rtl);
				}
				float num2 = generator.GetPreferredHeight(text, settings);
				if (num2 < extents.y)
				{
					break;
				}
			}
			return text;
		}
		if (fit == Fit.FitHorizontal)
		{
			int num3 = -(4 - base.fontSize);
			for (int j = 0; j < num3; j++)
			{
				settings.fontSize = base.fontSize - j;
				float num4 = generator.GetPreferredWidth(this.text, settings);
				if (num4 < extents.x)
				{
					break;
				}
			}
			if (wantCustomWrap)
			{
				return (!rtl) ? this.text : RtlHelper.Reverse(this.text);
			}
			return this.text;
		}
		if (wantCustomWrap)
		{
			settings.horizontalOverflow = HorizontalWrapMode.Overflow;
			return textWrapper.Wrap(this.text, base.cachedTextGenerator, settings, rtl);
		}
		if (rtl)
		{
			return RtlHelper.Reverse(this.text);
		}
		return this.text;
	}

	private void Justify(VertexHelper vh, string wrappedText)
	{
		float num = 0.75f;
		UIVertex vertex = default(UIVertex);
		TextGenerator textGenerator = base.cachedTextGenerator;
		for (int i = 0; i < textGenerator.lines.Count - 1; i++)
		{
			UILineInfo uILineInfo = textGenerator.lines[i];
			UILineInfo uILineInfo2 = textGenerator.lines[i + 1];
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			float num4 = 0f;
			float num5 = 0f;
			int num6 = 0;
			float charWidth;
			for (int j = uILineInfo.startCharIdx; j < uILineInfo2.startCharIdx; num4 += charWidth, j++)
			{
				char c = wrappedText[j];
				charWidth = textGenerator.characters[j].charWidth;
				switch (c)
				{
				case ' ':
					num2++;
					num6++;
					num5 += charWidth;
					continue;
				case '\n':
					break;
				default:
					num3++;
					num5 = 0f;
					num6 = 0;
					continue;
				}
				flag = true;
				break;
			}
			if (flag || num3 == 0)
			{
				continue;
			}
			num2 -= num6;
			float num7 = textGenerator.rectExtents.xMax - (num4 - num5);
			float num8 = num7 * ((num2 == 0) ? 0f : num);
			float num9 = num7 - num8;
			float num10 = num8 / (float)((num2 != 0) ? num2 : 0);
			float num11 = num9 / (float)num3;
			float num12 = 0f;
			for (int k = uILineInfo.startCharIdx; k < uILineInfo2.startCharIdx; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					int i2 = k * 4 + l;
					vh.PopulateUIVertex(ref vertex, i2);
					vertex.position.x += Mathf.FloorToInt(num12);
					vh.SetUIVertex(vertex, i2);
				}
				char c2 = wrappedText[k];
				num12 = ((c2 != ' ') ? (num12 + num11) : (num12 + num10));
			}
		}
	}
}
