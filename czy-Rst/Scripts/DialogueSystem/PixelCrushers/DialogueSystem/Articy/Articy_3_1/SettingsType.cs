using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	[Serializable]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	public class SettingsType
	{
		private bool exportMarkupField;

		private bool exportQueriesField;

		private bool writeNamespaceField;

		private bool writeAllVariablesField;

		public bool ExportMarkup
		{
			get
			{
				return exportMarkupField;
			}
			set
			{
				exportMarkupField = value;
			}
		}

		public bool ExportQueries
		{
			get
			{
				return exportQueriesField;
			}
			set
			{
				exportQueriesField = value;
			}
		}

		public bool WriteNamespace
		{
			get
			{
				return writeNamespaceField;
			}
			set
			{
				writeNamespaceField = value;
			}
		}

		public bool WriteAllVariables
		{
			get
			{
				return writeAllVariablesField;
			}
			set
			{
				writeAllVariablesField = value;
			}
		}
	}
}
