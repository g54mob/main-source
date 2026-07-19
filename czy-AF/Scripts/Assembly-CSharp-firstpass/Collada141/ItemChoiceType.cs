using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema", IncludeInSchema = false)]
	public enum ItemChoiceType
	{
		@float = 0,
		float2 = 1,
		float3 = 2,
		float4 = 3,
		sampler2D = 4,
		surface = 5
	}
}
