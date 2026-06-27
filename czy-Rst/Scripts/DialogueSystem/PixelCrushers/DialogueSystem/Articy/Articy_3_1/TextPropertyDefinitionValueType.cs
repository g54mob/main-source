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
	public class TextPropertyDefinitionValueType
	{
		private LocalizedStringType[] localizedStringField;

		private string[] textField;

		private int countField;

		private bool countFieldSpecified;

		[XmlElement("LocalizedString")]
		public LocalizedStringType[] LocalizedString
		{
			get
			{
				return localizedStringField;
			}
			set
			{
				localizedStringField = value;
			}
		}

		[XmlText]
		public string[] Text
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

		[XmlAttribute]
		public int Count
		{
			get
			{
				return countField;
			}
			set
			{
				countField = value;
			}
		}

		[XmlIgnore]
		public bool CountSpecified
		{
			get
			{
				return countFieldSpecified;
			}
			set
			{
				countFieldSpecified = value;
			}
		}
	}
}
