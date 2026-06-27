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
	public class JourneyPointType
	{
		private JourneyRefType targetField;

		private LocalizableTextType textField;

		private string externalIdField;

		private string shortIdField;

		private JourneyPointSettingsType settingsField;

		private TypeOfJourneyPointType typeField;

		private ReachedByType reachedByField;

		public JourneyRefType Target
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

		public JourneyPointSettingsType Settings
		{
			get
			{
				return settingsField;
			}
			set
			{
				settingsField = value;
			}
		}

		[XmlAttribute]
		public TypeOfJourneyPointType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
			}
		}

		[XmlAttribute]
		public ReachedByType ReachedBy
		{
			get
			{
				return reachedByField;
			}
			set
			{
				reachedByField = value;
			}
		}
	}
}
