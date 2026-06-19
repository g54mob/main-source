using System;

namespace TMPEffects.AutoParameters.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class AutoParameterBundleAttribute : AutoParameterAttribute
	{
		public AutoParameterBundleAttribute(string prefix)
			: base((string)null, (string[])null)
		{
		}
	}
}
