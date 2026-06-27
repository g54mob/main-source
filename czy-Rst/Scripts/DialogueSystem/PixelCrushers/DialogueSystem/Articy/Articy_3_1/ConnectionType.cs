using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	[Serializable]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	public class ConnectionType
	{
		private string colorField;

		private string technicalNameField;

		private string urlField;

		private LocalizableTextType labelField;

		private ConnectionRefType sourceField;

		private ConnectionRefType targetField;

		private bool showLabelField;

		private string idField;

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

		public string Url
		{
			get
			{
				return urlField;
			}
			set
			{
				urlField = value;
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

		public bool ShowLabel
		{
			get
			{
				return showLabelField;
			}
			set
			{
				showLabelField = value;
			}
		}

		[XmlAttribute]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}
	}
}
