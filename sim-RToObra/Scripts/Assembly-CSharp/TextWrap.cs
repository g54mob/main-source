using System.Collections.Generic;
using System.Text;

public class TextWrap
{
	public interface IWidthProvider
	{
		float GetWidth(string text);
	}

	private static List<char> kCantStart = new List<char>("ﾞﾟ‐–〜゠・･,，、､;；:：!！‼⁉?？⁈⁇.．。｡’\"”〟»)）]］}｝｠〉》」｣』】〕〗〙\\%％‰′″\u309b\u309c°℃々〻ゝゞーヽヾ¢￠ぁァぃィぅゥぇェぉォゕヵㇰゖヶㇱㇲっッㇳㇴㇵㇶㇷㇸㇹㇺゃャゅュょョㇻㇼㇽㇾㇿゎヮ".ToCharArray());

	private static List<char> kCantTrail = new List<char>("‘\"“〝«(（[［{｛｟〈《「｢『【〔〖〘\\$＄£￡¥￥0123456789".ToCharArray());

	public static string Wrap(string text, float maxWidth, IWidthProvider widthProvider, bool rtl)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = text.Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			string paragraph = ((!rtl) ? array[i] : RtlHelper.Reverse(array[i]));
			if (paragraph.Length > 0)
			{
				int num = 0;
				while (paragraph.Length > 0 && num < 10000)
				{
					string text2 = PopLine(ref paragraph, maxWidth, widthProvider, rtl);
					if (text2.HasValue())
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.AppendLine(string.Empty);
						}
						stringBuilder.Append(text2);
					}
					num++;
				}
			}
			else
			{
				stringBuilder.AppendLine(string.Empty);
			}
		}
		return stringBuilder.ToString();
	}

	private static string PopLine(ref string paragraph, float maxWidth, IWidthProvider widthProvider, bool rtl)
	{
		if (widthProvider.GetWidth(paragraph) < maxWidth)
		{
			string text = paragraph;
			paragraph = string.Empty;
			return text.TrimEnd();
		}
		if (rtl)
		{
			string text2 = string.Empty;
			string text3 = paragraph.Substring(paragraph.Length - 1);
			for (int i = 2; i < paragraph.Length; i++)
			{
				string text4 = paragraph.Substring(paragraph.Length - i);
				if (widthProvider.GetWidth(text4) > maxWidth)
				{
					break;
				}
				text3 = text4;
				if (CanBreakAfter(paragraph, paragraph.Length - i))
				{
					text2 = text3;
				}
			}
			string text5 = ((!text2.HasValue()) ? text3 : text2);
			paragraph = paragraph.Substring(0, paragraph.Length - text5.Length);
			return text5.TrimEnd();
		}
		string text6 = string.Empty;
		string text7 = paragraph.Substring(0, 1);
		for (int j = 2; j < paragraph.Length; j++)
		{
			string text8 = paragraph.Substring(0, j);
			if (widthProvider.GetWidth(text8) > maxWidth)
			{
				break;
			}
			text7 = text8;
			if (CanBreakAfter(paragraph, j))
			{
				text6 = text7;
			}
		}
		string text9 = ((!text6.HasValue()) ? text7 : text6);
		paragraph = paragraph.Substring(text9.Length);
		return text9.TrimEnd();
	}

	private static bool CanBreakAfter(string text, int afterIndex)
	{
		char c = text[afterIndex];
		if (c == ' ')
		{
			return true;
		}
		if (!Lang.loadedLanguage.isAsian)
		{
			return false;
		}
		if (kCantStart.Contains(c))
		{
			return false;
		}
		if (afterIndex > 0 && kCantTrail.Contains(text[afterIndex - 1]))
		{
			return false;
		}
		return true;
	}
}
