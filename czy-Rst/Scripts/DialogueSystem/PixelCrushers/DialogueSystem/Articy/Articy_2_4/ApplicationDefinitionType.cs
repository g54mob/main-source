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
	public class ApplicationDefinitionType
	{
		private string nameField;

		private string commandField;

		private string workingDirectoryField;

		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		public string Command
		{
			get
			{
				return commandField;
			}
			set
			{
				commandField = value;
			}
		}

		public string WorkingDirectory
		{
			get
			{
				return workingDirectoryField;
			}
			set
			{
				workingDirectoryField = value;
			}
		}
	}
}
