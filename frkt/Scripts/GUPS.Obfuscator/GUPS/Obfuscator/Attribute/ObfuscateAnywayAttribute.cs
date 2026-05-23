using System;

namespace GUPS.Obfuscator.Attribute
{
	[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event)]
	public class ObfuscateAnywayAttribute : System.Attribute
	{
		private string obfuscateTo;

		public ObfuscateAnywayAttribute(string _ObfuscateTo)
		{
		}
	}
}
