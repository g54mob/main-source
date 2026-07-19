using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
	[Serializable]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
	public enum fx_sampler_wrap_common
	{
		NONE = 0,
		WRAP = 1,
		MIRROR = 2,
		CLAMP = 3,
		BORDER = 4
	}
}
