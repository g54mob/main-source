using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public enum TypeOfJourneyPointType
	{
		FlowFragment = 0,
		Dialogue = 1,
		DialogueFragment = 2,
		Connection = 3,
		Pin = 4,
		Hub = 5,
		Jump = 6,
		FlowConnectionSelection = 7,
		DialogueConnectionSelection = 8,
		InputPinSelection = 9,
		OutputPinSelection = 10
	}
}
