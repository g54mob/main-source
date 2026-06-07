namespace UI.Xml.CustomAttributes
{
	public class OutlineSizeAttribute : OutlineAttribute
	{
		public override string ValueDataType => "xs:float";

		public override string DefaultValue => "1";
	}
}
