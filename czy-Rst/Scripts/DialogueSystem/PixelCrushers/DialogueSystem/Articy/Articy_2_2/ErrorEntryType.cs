using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	public class ErrorEntryType
	{
		private ErrorSeverityType severityField;

		private string valueField;

		[XmlAttribute]
		[DefaultValue(ErrorSeverityType.Soft)]
		public ErrorSeverityType Severity
		{
			get
			{
				return severityField;
			}
			set
			{
				severityField = value;
			}
		}

		[XmlText]
		public string Value
		{
			get
			{
				return valueField;
			}
			set
			{
				valueField = value;
			}
		}

		public ErrorEntryType()
		{
			severityField = ErrorSeverityType.Soft;
		}
	}
}
