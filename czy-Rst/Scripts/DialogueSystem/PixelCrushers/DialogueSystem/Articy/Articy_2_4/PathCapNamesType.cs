using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public enum PathCapNamesType
	{
		ColoredDot = 0,
		None = 1,
		LineArrowHead = 2,
		FilledArrowHead = 3,
		Diamond = 4,
		Square = 5,
		Disc = 6
	}
}
