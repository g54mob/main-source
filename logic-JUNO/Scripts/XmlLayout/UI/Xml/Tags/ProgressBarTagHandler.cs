using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ProgressBarTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<XmlLayoutProgressBar>();
			}
		}

		public override bool isCustomElement => true;

		public override string elementChildType => "none";

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "percentage", "xs:float" },
			{ "showPercentageText", "xs:boolean" },
			{ "percentageTextFormat", "xs:string" },
			{ "textShadow", "xmlLayout:color" },
			{ "textOutline", "xmlLayout:color" },
			{ "textColor", "xmlLayout:color" },
			{
				"textAlignment",
				string.Join(",", Enum.GetNames(typeof(RectAlignment)))
			},
			{ "fillImage", "xs:string" },
			{ "fillImageColor", "xmlLayout:color" }
		};

		public override List<string> attributeGroups => new List<string> { "text", "image" };

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			XmlLayoutProgressBar obj = primaryComponent as XmlLayoutProgressBar;
			Text ref_text = obj.ref_text;
			ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Text");
			xmlTagHandler.SetInstance(ref_text.rectTransform, base.currentXmlLayoutInstance);
			AttributeDictionary attributeDictionary = new AttributeDictionary(attributesToApply.Where((KeyValuePair<string, string> a) => TextTagHandler.TextAttributes.Contains(a.Key, StringComparer.OrdinalIgnoreCase)).ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> b) => b.Value));
			if (attributesToApply.ContainsKey("textshadow"))
			{
				attributeDictionary.Add("shadow", attributesToApply["textshadow"]);
			}
			if (attributesToApply.ContainsKey("textoutline"))
			{
				attributeDictionary.Add("outline", attributesToApply["textoutline"]);
			}
			if (attributesToApply.ContainsKey("textcolor"))
			{
				attributeDictionary.Add("color", attributesToApply["textcolor"]);
			}
			if (attributesToApply.ContainsKey("textalignment"))
			{
				attributeDictionary.Add("alignment", attributesToApply["textalignment"]);
			}
			xmlTagHandler.ApplyAttributes(attributeDictionary);
			Image ref_fillImage = obj.ref_fillImage;
			if (attributesToApply.ContainsKey("fillImage"))
			{
				ref_fillImage.sprite = attributesToApply.GetValue<Sprite>("fillImage");
			}
			if (attributesToApply.ContainsKey("fillImageColor"))
			{
				ref_fillImage.color = attributesToApply.GetValue<Color>("fillImageColor");
			}
		}

		public override void SetValue(string newValue, bool fireEventHandlers = true)
		{
			float percentage = float.Parse(newValue);
			(primaryComponent as XmlLayoutProgressBar).percentage = percentage;
		}
	}
}
