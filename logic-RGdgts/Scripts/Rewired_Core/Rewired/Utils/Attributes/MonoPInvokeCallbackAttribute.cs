using System;

namespace Rewired.Utils.Attributes
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class MonoPInvokeCallbackAttribute : Attribute
	{
		private Type type;

		public MonoPInvokeCallbackAttribute(Type P_0)
		{
		}
	}
}
