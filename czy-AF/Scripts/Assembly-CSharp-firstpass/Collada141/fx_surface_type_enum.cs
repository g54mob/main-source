using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
	public enum fx_surface_type_enum
	{
		UNTYPED = 0,
		[XmlEnum("1D")]
		Item1D = 1,
		[XmlEnum("2D")]
		Item2D = 2,
		[XmlEnum("3D")]
		Item3D = 3,
		RECT = 4,
		CUBE = 5,
		DEPTH = 6
	}
}
