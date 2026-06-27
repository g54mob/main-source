using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	[Serializable]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	public enum BackgroundImagePositioningModeType
	{
		Fitting = 0,
		Filling = 1,
		Stretched = 2,
		Repeating = 3,
		Centered = 4
	}
}
