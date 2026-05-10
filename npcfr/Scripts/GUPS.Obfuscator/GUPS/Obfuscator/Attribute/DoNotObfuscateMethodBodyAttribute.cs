using System;

namespace GUPS.Obfuscator.Attribute
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class DoNotObfuscateMethodBodyAttribute : System.Attribute
	{
	}
}
