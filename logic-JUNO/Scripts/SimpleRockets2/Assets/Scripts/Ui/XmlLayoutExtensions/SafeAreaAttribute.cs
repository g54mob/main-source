using ModApi;
using ModApi.Common.Extensions;
using UI.Xml;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class SafeAreaAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xs:boolean";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			if (Device.IsMobileBuild)
			{
				SafeAreaScript safeAreaScript = xmlElement.gameObject.AddMissingComponent<SafeAreaScript>();
				bool isEnabled = value.ToBoolean();
				safeAreaScript.IsEnabled = isEnabled;
			}
		}
	}
}
