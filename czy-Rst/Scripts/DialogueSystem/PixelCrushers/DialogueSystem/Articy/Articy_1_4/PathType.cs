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
	public class PathType
	{
		private LocalizableTextType displayNameField;

		private LocalizableTextType textField;

		private string colorField;

		private string technicalNameField;

		private string externalIdField;

		private string shortIdField;

		private FeaturesType featuresField;

		private PreviewImageType previewImageField;

		private VerticesType verticesField;

		private string guidField;

		private string objectTemplateReferenceField;

		private string objectTemplateReferenceNameField;

		private float xField;

		private float yField;

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

		public VerticesType Vertices
		{
			get
			{
				return verticesField;
			}
			set
			{
				verticesField = value;
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

		[XmlAttribute]
		public float X
		{
			get
			{
				return xField;
			}
			set
			{
				xField = value;
			}
		}

		[XmlAttribute]
		public float Y
		{
			get
			{
				return yField;
			}
			set
			{
				yField = value;
			}
		}
	}
}
