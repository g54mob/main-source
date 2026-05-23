using System;

namespace GUPS.Obfuscator.Attribute
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	public class DoNotObfuscateClassAttribute : System.Attribute
	{
	}
}
