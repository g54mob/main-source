using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	public class FeatureType
	{
		private PropertiesType[] propertiesField;

		private string nameField;

		private string guidRefField;

		[XmlElement("Properties")]
		public PropertiesType[] Properties
		{
			get
			{
				return propertiesField;
			}
			set
			{
				propertiesField = value;
			}
		}

		[XmlAttribute]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		[XmlAttribute]
		public string GuidRef
		{
			get
			{
				return guidRefField;
			}
			set
			{
				guidRefField = value;
			}
		}
	}
}
