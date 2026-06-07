using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class RawImageTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<RawImage>();
			}
		}

		public override bool isCustomElement => true;

		public override string prefabPath => null;

		public override string extension => "blank";

		public override List<string> attributeGroups => new List<string> { "rectTransform", "rectPosition", "layoutElement", "tooltip", "animation" };

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "texture", "xs:string" },
			{ "color", "xmlLayout:color" },
			{ "material", "xs:string" },
			{ "raycastTarget", "xs:boolean" },
			{ "uvRect", "xmlLayout:rect" }
		};

		public override void Open(AttributeDictionary elementAttributes)
		{
			base.currentInstanceTransform.gameObject.AddComponent<RawImage>();
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			MatchParentDimensions();
			base.ApplyAttributes(attributesToApply);
		}
	}
}
