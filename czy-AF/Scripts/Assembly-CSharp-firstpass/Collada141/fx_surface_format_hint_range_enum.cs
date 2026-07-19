using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
	public enum fx_surface_format_hint_range_enum
	{
		SNORM = 0,
		UNORM = 1,
		SINT = 2,
		UINT = 3,
		FLOAT = 4
	}
}
