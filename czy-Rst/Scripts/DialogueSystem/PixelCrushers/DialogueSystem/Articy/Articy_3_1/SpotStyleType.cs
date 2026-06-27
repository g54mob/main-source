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
	public class SpotStyleType
	{
		private SpotStyleKindType kindField;

		private SizeNamesType sizeField;

		[XmlAttribute]
		public SpotStyleKindType Kind
		{
			get
			{
				return kindField;
			}
			set
			{
				kindField = value;
			}
		}

		[XmlAttribute]
		public SizeNamesType Size
		{
			get
			{
				return sizeField;
			}
			set
			{
				sizeField = value;
			}
		}
	}
}
