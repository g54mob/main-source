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
	public class LinkType
	{
		private string displayNameField;

		private LocalizableTextType textField;

		private string colorField;

		private string technicalNameField;

		private string externalIdField;

		private string shortIdField;

		private FeaturesType featuresField;

		private VisibilityType visibilityField;

		private SelectabilityType selectabilityField;

		private ReferenceType targetField;

		private string idField;

		private string objectTemplateReferenceField;

		private string objectTemplateReferenceNameField;

		private float xField;

		private bool xFieldSpecified;

		private float yField;

		private bool yFieldSpecified;

		private float zIndexField;

		private bool zIndexFieldSpecified;

		public string DisplayName
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

		public ReferenceType Target
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

		[XmlIgnore]
		public bool XSpecified
		{
			get
			{
				return xFieldSpecified;
			}
			set
			{
				xFieldSpecified = value;
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

		[XmlIgnore]
		public bool YSpecified
		{
			get
			{
				return yFieldSpecified;
			}
			set
			{
				yFieldSpecified = value;
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

		[XmlIgnore]
		public bool ZIndexSpecified
		{
			get
			{
				return zIndexFieldSpecified;
			}
			set
			{
				zIndexFieldSpecified = value;
			}
		}
	}
}
