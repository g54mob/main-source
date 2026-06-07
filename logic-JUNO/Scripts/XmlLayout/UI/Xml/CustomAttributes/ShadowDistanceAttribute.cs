namespace UI.Xml.CustomAttributes
{
	public class ShadowDistanceAttribute : ShadowAttribute
	{
		public override string ValueDataType => "xs:float";

		public override string DefaultValue => "1";
	}
}
