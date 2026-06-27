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
	public class VariableType
	{
		private string technicalNameField;

		private LocalizableTextType descriptionField;

		private VariableDataTypeType dataTypeField;

		private string defaultValueField;

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

		public LocalizableTextType Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		public VariableDataTypeType DataType
		{
			get
			{
				return dataTypeField;
			}
			set
			{
				dataTypeField = value;
			}
		}

		public string DefaultValue
		{
			get
			{
				return defaultValueField;
			}
			set
			{
				defaultValueField = value;
			}
		}
	}
}
