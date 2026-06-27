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
	public class ProjectType
	{
		private string displayNameField;

		private string urlField;

		private string idField;

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
