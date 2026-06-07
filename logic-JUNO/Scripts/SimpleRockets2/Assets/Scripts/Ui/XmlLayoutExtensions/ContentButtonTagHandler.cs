using System.Collections.Generic;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class ContentButtonTagHandler : ElementTagHandler
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged" };

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "color", "xmlLayout:color" },
			{ "buttonColors", "xmlLayout:colorblock" },
			{ "onValueChanged", "xmlLayout:function" },
			{ "targetImage", "xs:string" }
		};

		public override bool isCustomElement => true;

		public override string prefabPath => "Ui/Prefabs/XmlLayout/ContentButton";

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<Button>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			Button button = primaryComponent as Button;
			if (attributesToApply.ContainsKey("targetImage"))
			{
				string internalId = attributesToApply["targetImage"];
				Image elementByInternalId = base.currentXmlElement.GetElementByInternalId<Image>(internalId);
				button.targetGraphic = elementByInternalId;
			}
			if (attributesToApply.ContainsKey("buttonColors"))
			{
				button.colors = attributesToApply["buttonColors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
		}
	}
}
