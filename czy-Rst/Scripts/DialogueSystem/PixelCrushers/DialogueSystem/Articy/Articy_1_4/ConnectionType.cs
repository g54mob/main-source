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
	public class ConnectionType
	{
		private string colorField;

		private string technicalNameField;

		private LocalizableTextType labelField;

		private ConnectionRefType sourceField;

		private ConnectionRefType targetField;

		private string guidField;

		public string Color
		{
			get
			{
				return colorField;
			}
			set
			{
				colorField = value;
			}
		}

		[XmlElement(DataType = "token")]
		public string TechnicalName
		{
			get
			{
				return technicalNameField;
			}
			set
			{
				technicalNameField = value;
			}
		}

		public LocalizableTextType Label
		{
			get
			{
				return labelField;
			}
			set
			{
				labelField = value;
			}
		}

		public ConnectionRefType Source
		{
			get
			{
				return sourceField;
			}
			set
			{
				sourceField = value;
			}
		}

		public ConnectionRefType Target
		{
			get
			{
				return targetField;
			}
			set
			{
				targetField = value;
			}
		}

		[XmlAttribute]
		public string Guid
		{
			get
			{
				return guidField;
			}
			set
			{
				guidField = value;
			}
		}
	}
}
