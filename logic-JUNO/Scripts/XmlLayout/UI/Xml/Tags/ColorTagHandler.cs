using System.Collections.Generic;

namespace UI.Xml.Tags
{
	public class ColorTagHandler : ElementTagHandler
	{
		public override bool isCustomElement => true;

		public override string elementChildType => "none";

		public override string extension => "blank";

		public override List<string> attributeGroups => new List<string>();

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "name", "xs:string" },
			{ "color", "xmlLayout:color" }
		};

		public override bool renderElement => false;

		public override string elementGroup => "defaultsOnly";

		public override string prefabPath => null;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
		}
	}
}
