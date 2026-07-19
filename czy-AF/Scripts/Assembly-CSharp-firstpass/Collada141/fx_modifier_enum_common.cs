using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
	public enum fx_modifier_enum_common
	{
		CONST = 0,
		UNIFORM = 1,
		VARYING = 2,
		STATIC = 3,
		VOLATILE = 4,
		EXTERN = 5,
		SHARED = 6
	}
}
