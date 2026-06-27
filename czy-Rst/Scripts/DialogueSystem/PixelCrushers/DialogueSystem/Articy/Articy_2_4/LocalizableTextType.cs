using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public class LocalizableTextType
	{
		private LocalizedStringType[] localizedStringField;

		private int countField;

		private bool hasMarkupField;

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

		[XmlAttribute]
		[DefaultValue(false)]
		public bool HasMarkup
		{
			get
			{
				return hasMarkupField;
			}
			set
			{
				hasMarkupField = value;
			}
		}

		public LocalizableTextType()
		{
			hasMarkupField = false;
		}
	}
}
