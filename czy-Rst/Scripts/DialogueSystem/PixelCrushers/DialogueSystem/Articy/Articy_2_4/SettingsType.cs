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
