using UI.Xml;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class BorderSpriteAttribute : CustomXmlAttribute
	{
		public override string DefaultValue => "None";

		public override bool KeepOriginalTag => true;

		public override string ValueDataType => "xs:string";
	}
}
