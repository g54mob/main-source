using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
	public enum fx_surface_format_hint_channels_enum
	{
		RGB = 0,
		RGBA = 1,
		L = 2,
		LA = 3,
		D = 4,
		XYZ = 5,
		XYZW = 6
	}
}
