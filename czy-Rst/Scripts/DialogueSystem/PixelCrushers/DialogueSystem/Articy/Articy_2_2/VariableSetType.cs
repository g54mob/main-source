using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	public class VariableSetType
	{
		private string technicalNameField;

		private LocalizableTextType descriptionField;

		private VariablesType variablesField;

		private string idField;

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

		public VariablesType Variables
		{
			get
			{
				return variablesField;
			}
			set
			{
				variablesField = value;
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
