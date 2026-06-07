using System.Globalization;
using System.Text;
using Febucci.Parsing.Core;

namespace Febucci.TextAnimatorForUnity.TextMeshPro
{
	internal class TMPTagParser : TagParserBase
	{
		private struct TMPTagInfo
		{
			public readonly string tagOpening;

			public readonly bool increasesTextLength;

			public TMPTagInfo(string tagOpening, bool increasesTextLength = false)
			{
				this.tagOpening = tagOpening;
				this.increasesTextLength = increasesTextLength;
			}
		}

		private readonly bool richTagsEnabled;

		private static readonly TMPTagInfo[] lookups = new TMPTagInfo[71]
		{
			new TMPTagInfo("<align="),
			new TMPTagInfo("</align>"),
			new TMPTagInfo("<allcaps>"),
			new TMPTagInfo("</allcaps>"),
			new TMPTagInfo("<alpha="),
			new TMPTagInfo("</alpha>"),
			new TMPTagInfo("<b>"),
			new TMPTagInfo("</b>"),
			new TMPTagInfo("<color="),
			new TMPTagInfo("</color>"),
			new TMPTagInfo("</color="),
			new TMPTagInfo("<cspace="),
			new TMPTagInfo("</cspace>"),
			new TMPTagInfo("<font="),
			new TMPTagInfo("</font>"),
			new TMPTagInfo("<font-weight="),
			new TMPTagInfo("</font-weight>"),
			new TMPTagInfo("<gradient="),
			new TMPTagInfo("</gradient>"),
			new TMPTagInfo("<i>"),
			new TMPTagInfo("</i>"),
			new TMPTagInfo("<indent="),
			new TMPTagInfo("</indent>"),
			new TMPTagInfo("<line-height="),
			new TMPTagInfo("</line-height>"),
			new TMPTagInfo("<line-indent="),
			new TMPTagInfo("</line-indent>"),
			new TMPTagInfo("<link="),
			new TMPTagInfo("</link>"),
			new TMPTagInfo("<link>"),
			new TMPTagInfo("</link>"),
			new TMPTagInfo("<lowercase>"),
			new TMPTagInfo("</lowercase>"),
			new TMPTagInfo("<margin="),
			new TMPTagInfo("</margin>"),
			new TMPTagInfo("<margin-left>"),
			new TMPTagInfo("<margin-right>"),
			new TMPTagInfo("<mark="),
			new TMPTagInfo("</mark>"),
			new TMPTagInfo("<mspace="),
			new TMPTagInfo("</mspace>"),
			new TMPTagInfo("<nobr>"),
			new TMPTagInfo("</nobr>"),
			new TMPTagInfo("<page>"),
			new TMPTagInfo("<pos="),
			new TMPTagInfo("<rotate="),
			new TMPTagInfo("</rotate>"),
			new TMPTagInfo("<s>"),
			new TMPTagInfo("</s>"),
			new TMPTagInfo("<size="),
			new TMPTagInfo("</size>"),
			new TMPTagInfo("<smallcaps>"),
			new TMPTagInfo("</smallcaps>"),
			new TMPTagInfo("<space="),
			new TMPTagInfo("<sprite", increasesTextLength: true),
			new TMPTagInfo("<sprite ", increasesTextLength: true),
			new TMPTagInfo("<style="),
			new TMPTagInfo("</style>"),
			new TMPTagInfo("<sub>"),
			new TMPTagInfo("</sub>"),
			new TMPTagInfo("<sup>"),
			new TMPTagInfo("</sup>"),
			new TMPTagInfo("<u>"),
			new TMPTagInfo("</u>"),
			new TMPTagInfo("<uppercase>"),
			new TMPTagInfo("</uppercase>"),
			new TMPTagInfo("<voffset="),
			new TMPTagInfo("</voffset>"),
			new TMPTagInfo("<width="),
			new TMPTagInfo("</width>"),
			new TMPTagInfo("<br>", increasesTextLength: true)
		};

		public TMPTagParser(bool richTagsEnabled, char openingBracket, char closingTagSymbol, char closingBracket)
			: base(openingBracket, closingTagSymbol, closingBracket)
		{
			this.richTagsEnabled = richTagsEnabled;
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (!richTagsEnabled)
			{
				return false;
			}
			string text = OpeningBracket + textInsideBrackets + ClosingBracket;
			TMPTagInfo[] array = lookups;
			for (int i = 0; i < array.Length; i++)
			{
				TMPTagInfo tMPTagInfo = array[i];
				if (text.StartsWith(tMPTagInfo.tagOpening, ignoreCase: true, CultureInfo.InvariantCulture))
				{
					finalTextBuilder.Append(text);
					if (tMPTagInfo.increasesTextLength)
					{
						realTextIndex++;
					}
					return true;
				}
			}
			return false;
		}
	}
}
