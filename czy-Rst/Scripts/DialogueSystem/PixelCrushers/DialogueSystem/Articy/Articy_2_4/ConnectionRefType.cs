using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public class ConnectionRefType
	{
		private string idRefField;

		private string pinRefField;

		private string valueField;

		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return idRefField;
			}
			set
			{
				idRefField = value;
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
