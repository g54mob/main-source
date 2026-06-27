using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	[Serializable]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	public enum ReachedByType
	{
		Invalid = 0,
		JourneyStart = 1,
		Skip = 2,
		Next = 3,
		Submerge = 4,
		Emerge = 5,
		Branch = 6,
		EndPoint = 7
	}
}
