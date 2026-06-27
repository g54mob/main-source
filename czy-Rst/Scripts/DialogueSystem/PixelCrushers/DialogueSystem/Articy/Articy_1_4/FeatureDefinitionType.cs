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
	public class FeatureDefinitionType
	{
		private LocalizableTextType displayNameField;

		private LocalizableTextType textField;

		private string colorField;

		private string technicalNameField;

		private string externalIdField;

		private string shortIdField;

		private PropertyDefinitionsType propertyDefinitionsField;

		private string guidField;

		private string basedOnField;

		public LocalizableTextType DisplayName
		{
			get
			{
				return displayNameField;
			}
			set
			{
				displayNameField = value;
			}
		}

		public LocalizableTextType Text
		{
			get
			{
				return textField;
			}
			set
			{
				textField = value;
			}
		}

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

		public string ExternalId
		{
			get
			{
				return externalIdField;
			}
			set
			{
				externalIdField = value;
			}
		}

		public string ShortId
		{
			get
			{
				return shortIdField;
			}
			set
			{
				shortIdField = value;
			}
		}

		public PropertyDefinitionsType PropertyDefinitions
		{
			get
			{
				return propertyDefinitionsField;
			}
			set
			{
				propertyDefinitionsField = value;
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

		[XmlAttribute]
		public string BasedOn
		{
			get
			{
				return basedOnField;
			}
			set
			{
				basedOnField = value;
			}
		}
	}
}
