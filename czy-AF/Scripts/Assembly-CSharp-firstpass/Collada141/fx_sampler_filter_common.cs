using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
	public enum fx_sampler_filter_common
	{
		NONE = 0,
		NEAREST = 1,
		LINEAR = 2,
		NEAREST_MIPMAP_NEAREST = 3,
		LINEAR_MIPMAP_NEAREST = 4,
		NEAREST_MIPMAP_LINEAR = 5,
		LINEAR_MIPMAP_LINEAR = 6
	}
}
