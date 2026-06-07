using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class SelectedAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xs:boolean";

		public override string DefaultValue => "false";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			if (!value.ToBoolean())
			{
				return;
			}
			Selectable selectable = xmlElement.GetComponent<Selectable>();
			if (selectable != null)
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					selectable.Select();
				}, xmlElement);
			}
		}
	}
}
