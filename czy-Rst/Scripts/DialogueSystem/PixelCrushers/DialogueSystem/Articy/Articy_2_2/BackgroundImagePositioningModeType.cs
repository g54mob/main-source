using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	public enum BackgroundImagePositioningModeType
	{
		Fitting = 0,
		Filling = 1,
		Stretched = 2,
		Repeating = 3,
		Centered = 4
	}
}
