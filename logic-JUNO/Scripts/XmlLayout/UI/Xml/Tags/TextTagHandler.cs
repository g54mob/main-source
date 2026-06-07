using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class TextTagHandler : ElementTagHandler
	{
		public static List<string> TextAttributes = new List<string> { "text", "fontstyle", "font", "fontsize", "horizontalOverflow", "verticalOverflow", "resizeTextForBestFit", "resizeTextMinSize", "resizeTextMaxSize", "alignByGeometry" };

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<Text>();
			}
		}

		public override bool UseParseChildElements => true;

		public override void ParseChildElements(XmlNode xmlNode)
		{
			string source = xmlNode.InnerXml.Replace(" xmlns=\"http://www.w3schools.com\"", string.Empty).Replace("<![CDATA[", string.Empty).Replace("]]>", string.Empty);
			source = ReplaceIgnoreCase(source, "<textcolor color=", "<color=");
			source = ReplaceIgnoreCase(source, "</textcolor", "</color");
			source = ReplaceIgnoreCase(source, "<textsize size=", "<size=");
			source = ReplaceIgnoreCase(source, "</textsize", "</size");
			source = source.Trim();
			source = source.Replace("<br/>", "\n").Replace("<br />", "\n");
			source = source.Replace("\\n", "\n");
			source = StringExtensions.DecodeEncodedNonAsciiCharacters(source);
			(primaryComponent as Text).text = source;
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			if (attributesToApply.ContainsKey("text"))
			{
				(primaryComponent as Text).text = StringExtensions.DecodeEncodedNonAsciiCharacters(attributesToApply["text"]);
			}
		}

		private string ReplaceIgnoreCase(string source, string match, string replace)
		{
			return new Regex(match, RegexOptions.IgnoreCase).Replace(source, replace);
		}
	}
}
