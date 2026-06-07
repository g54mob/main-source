using System;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class NavigationAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "None,Horizontal,Vertical,Automatic,Explicit";

		public override string DefaultValue => "Automatic";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
			Selectable component = xmlElement.GetComponent<Selectable>();
			if (component != null)
			{
				Navigation navigation = component.navigation;
				navigation.mode = (Navigation.Mode)Enum.Parse(typeof(Navigation.Mode), value);
				component.navigation = navigation;
			}
		}
	}
}
