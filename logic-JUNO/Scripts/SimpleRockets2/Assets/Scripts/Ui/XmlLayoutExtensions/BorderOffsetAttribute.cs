using UI.Xml;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class BorderOffsetAttribute : CustomXmlAttribute
	{
		public override string DefaultValue => string.Empty;

		public override bool KeepOriginalTag => true;

		public override string ValueDataType => "xmlLayout:floatList";
	}
}
