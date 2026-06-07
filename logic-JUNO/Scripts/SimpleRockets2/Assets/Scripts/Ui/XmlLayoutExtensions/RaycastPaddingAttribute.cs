using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class RaycastPaddingAttribute : CustomXmlAttribute
	{
		public override string DefaultValue => "0";

		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xmlLayout:vector4";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Vector4? vector = value?.ToVector4();
			Image component = xmlElement.GetComponent<Image>();
			if (vector.HasValue && component != null)
			{
				component.raycastPadding = new Vector4(vector.Value.x, vector.Value.w, vector.Value.y, vector.Value.z);
			}
		}
	}
}
