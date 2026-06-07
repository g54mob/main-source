namespace UI.Xml.Tags
{
	public class TooltipUseTextMeshProAttribute : CustomXmlAttribute
	{
		public override eAttributeGroup AttributeGroup => eAttributeGroup.Tooltip;

		public override string ValueDataType => "xs:boolean";

		public override bool UsesApplyMethod => false;
	}
}
