using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
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
