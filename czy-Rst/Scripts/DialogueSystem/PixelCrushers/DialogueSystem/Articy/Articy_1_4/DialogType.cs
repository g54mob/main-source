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
	public class DialogType
	{
		private LocalizableTextType displayNameField;

		private LocalizableTextType textField;

		private string colorField;

		private string technicalNameField;

		private string externalIdField;

		private string shortIdField;

		private FeaturesType featuresField;

		private ReferencesType referencesField;

		private PreviewImageType previewImageField;

		private PinsType pinsField;

		private string guidField;

		private string objectTemplateReferenceField;

		private string objectTemplateReferenceNameField;

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

		public FeaturesType Features
		{
			get
			{
				return featuresField;
			}
			set
			{
				featuresField = value;
			}
		}

		public ReferencesType References
		{
			get
			{
				return referencesField;
			}
			set
			{
				referencesField = value;
			}
		}

		public PreviewImageType PreviewImage
		{
			get
			{
				return previewImageField;
			}
			set
			{
				previewImageField = value;
			}
		}

		public PinsType Pins
		{
			get
			{
				return pinsField;
			}
			set
			{
				pinsField = value;
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
		public string ObjectTemplateReference
		{
			get
			{
				return objectTemplateReferenceField;
			}
			set
			{
				objectTemplateReferenceField = value;
			}
		}

		[XmlAttribute]
		public string ObjectTemplateReferenceName
		{
			get
			{
				return objectTemplateReferenceNameField;
			}
			set
			{
				objectTemplateReferenceNameField = value;
			}
		}
	}
}
