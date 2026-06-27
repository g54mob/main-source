using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	public enum TypeOfJourneyPointType
	{
		FlowFragment = 0,
		Dialog = 1,
		DialogFragment = 2,
		Connection = 3,
		Pin = 4,
		Hub = 5,
		Jump = 6,
		FlowConnectionSelection = 7,
		DialogConnectionSelection = 8,
		InputPinSelection = 9,
		OutputPinSelection = 10
	}
}
