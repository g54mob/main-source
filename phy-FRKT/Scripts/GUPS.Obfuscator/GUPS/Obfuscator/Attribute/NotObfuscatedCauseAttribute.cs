using System;

namespace GUPS.Obfuscator.Attribute
{
	[AttributeUsage(AttributeTargets.All)]
	public class NotObfuscatedCauseAttribute : System.Attribute
	{
		public NotObfuscatedCauseAttribute(string _Cause)
		{
		}
	}
}
