using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[XmlInclude(typeof(ReferenceStripPropertyType))]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public class ReferencesType
	{
		private ReferenceType[] referenceField;

		private int countField;

		[XmlElement("Reference")]
		public ReferenceType[] Reference
		{
			get
			{
				return referenceField;
			}
			set
			{
				referenceField = value;
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
	}
}
