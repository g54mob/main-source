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
	public class JourneyRefType
	{
		private string guidRefField;

		private string pinRefField;

		private string valueField;

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

		[XmlAttribute]
		public string PinRef
		{
			get
			{
				return pinRefField;
			}
			set
			{
				pinRefField = value;
			}
		}

		[XmlText]
		public string Value
		{
			get
			{
				return valueField;
			}
			set
			{
				valueField = value;
			}
		}
	}
}
