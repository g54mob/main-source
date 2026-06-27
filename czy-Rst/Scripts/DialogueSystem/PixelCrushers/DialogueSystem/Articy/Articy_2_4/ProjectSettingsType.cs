using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public class ProjectSettingsType
	{
		private FlowSettingsType flowSettingsField;

		private JourneySettingsType journeySettingsField;

		private LocationSettingsType locationSettingsField;

		private ExternalApplicationsType externalApplicationsField;

		private string idField;

		public FlowSettingsType FlowSettings
		{
			get
			{
				return flowSettingsField;
			}
			set
			{
				flowSettingsField = value;
			}
		}

		public JourneySettingsType JourneySettings
		{
			get
			{
				return journeySettingsField;
			}
			set
			{
				journeySettingsField = value;
			}
		}

		public LocationSettingsType LocationSettings
		{
			get
			{
				return locationSettingsField;
			}
			set
			{
				locationSettingsField = value;
			}
		}

		public ExternalApplicationsType ExternalApplications
		{
			get
			{
				return externalApplicationsField;
			}
			set
			{
				externalApplicationsField = value;
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
