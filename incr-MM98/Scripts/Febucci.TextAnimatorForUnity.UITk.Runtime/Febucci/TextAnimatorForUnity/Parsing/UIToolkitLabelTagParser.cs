using System.Globalization;
using System.Text;
using Febucci.Parsing.Core;
using UnityEngine.UIElements;

namespace Febucci.TextAnimatorForUnity.Parsing
{
	internal class UIToolkitLabelTagParser : TagParserBase
	{
		private readonly TextElement attachedTextElement;

		private static readonly UITkTagInfo[] lookups = new UITkTagInfo[74]
		{
			new UITkTagInfo("<a"),
			new UITkTagInfo("</a>"),
			new UITkTagInfo("<align="),
			new UITkTagInfo("</align>"),
			new UITkTagInfo("<allcaps>"),
			new UITkTagInfo("</allcaps>"),
			new UITkTagInfo("<alpha="),
			new UITkTagInfo("</alpha>"),
			new UITkTagInfo("<b>"),
			new UITkTagInfo("</b>"),
			new UITkTagInfo("<color="),
			new UITkTagInfo("</color>"),
			new UITkTagInfo("</color="),
			new UITkTagInfo("<cspace="),
			new UITkTagInfo("</cspace>"),
			new UITkTagInfo("<font="),
			new UITkTagInfo("</font>"),
			new UITkTagInfo("<font-weight="),
			new UITkTagInfo("</font-weight>"),
			new UITkTagInfo("<gradient="),
			new UITkTagInfo("</gradient>"),
			new UITkTagInfo("<i>"),
			new UITkTagInfo("</i>"),
			new UITkTagInfo("<indent="),
			new UITkTagInfo("</indent>"),
			new UITkTagInfo("<line-height="),
			new UITkTagInfo("</line-height>"),
			new UITkTagInfo("<line-indent="),
			new UITkTagInfo("</line-indent>"),
			new UITkTagInfo("<link="),
			new UITkTagInfo("</link>"),
			new UITkTagInfo("<link>"),
			new UITkTagInfo("</link>"),
			new UITkTagInfo("<lowercase>"),
			new UITkTagInfo("</lowercase>"),
			new UITkTagInfo("<margin="),
			new UITkTagInfo("</margin>"),
			new UITkTagInfo("<margin-left="),
			new UITkTagInfo("<margin-right="),
			new UITkTagInfo("<mark="),
			new UITkTagInfo("</mark>"),
			new UITkTagInfo("<mspace="),
			new UITkTagInfo("</mspace>"),
			new UITkTagInfo("<nobr>"),
			new UITkTagInfo("</nobr>"),
			new UITkTagInfo("<noparse>"),
			new UITkTagInfo("</noparse>"),
			new UITkTagInfo("<pos="),
			new UITkTagInfo("<rotate="),
			new UITkTagInfo("</rotate>"),
			new UITkTagInfo("<s>"),
			new UITkTagInfo("</s>"),
			new UITkTagInfo("<size="),
			new UITkTagInfo("</size>"),
			new UITkTagInfo("<smallcaps>"),
			new UITkTagInfo("</smallcaps>"),
			new UITkTagInfo("<space=", increasesTextLength: true),
			new UITkTagInfo("<sprite", increasesTextLength: true),
			new UITkTagInfo("<sprite ", increasesTextLength: true),
			new UITkTagInfo("<style="),
			new UITkTagInfo("</style>"),
			new UITkTagInfo("<sub>"),
			new UITkTagInfo("</sub>"),
			new UITkTagInfo("<sup>"),
			new UITkTagInfo("</sup>"),
			new UITkTagInfo("<u>"),
			new UITkTagInfo("</u>"),
			new UITkTagInfo("<uppercase>"),
			new UITkTagInfo("</uppercase>"),
			new UITkTagInfo("<voffset="),
			new UITkTagInfo("</voffset>"),
			new UITkTagInfo("<width="),
			new UITkTagInfo("</width>"),
			new UITkTagInfo("<br>", increasesTextLength: true)
		};

		public UIToolkitLabelTagParser(TextElement attachedTextElement, char openingBracket, char closingTagSymbol, char closingBracket)
			: base(openingBracket, closingTagSymbol, closingBracket)
		{
			this.attachedTextElement = attachedTextElement;
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (attachedTextElement == null)
			{
				return false;
			}
			if (!attachedTextElement.enableRichText)
			{
				return false;
			}
			string text = OpeningBracket + textInsideBrackets + ClosingBracket;
			UITkTagInfo[] array = lookups;
			for (int i = 0; i < array.Length; i++)
			{
				UITkTagInfo uITkTagInfo = array[i];
				if (text.StartsWith(uITkTagInfo.tagOpening, ignoreCase: true, CultureInfo.InvariantCulture))
				{
					finalTextBuilder.Append(text);
					if (uITkTagInfo.increasesTextLength)
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
