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
	public class PathType
	{
		private LocalizableTextType displayNameField;

		private LocalizableTextType textField;

		private string colorField;

		private string technicalNameField;

		private string externalIdField;

		private string shortIdField;

		private FeaturesType featuresField;

		private VisibilityType visibilityField;

		private SelectabilityType selectabilityField;

		private PreviewImageType previewImageField;

		private VerticesType verticesField;

		private string idField;

		private string objectTemplateReferenceField;

		private string objectTemplateReferenceNameField;

		private float xField;

		private float yField;

		private float zIndexField;

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

		public VisibilityType Visibility
		{
			get
			{
				return visibilityField;
			}
			set
			{
				visibilityField = value;
			}
		}

		public SelectabilityType Selectability
		{
			get
			{
				return selectabilityField;
			}
			set
			{
				selectabilityField = value;
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

		[XmlAttribute]
		public float ZIndex
		{
			get
			{
				return zIndexField;
			}
			set
			{
				zIndexField = value;
			}
		}
	}
}
