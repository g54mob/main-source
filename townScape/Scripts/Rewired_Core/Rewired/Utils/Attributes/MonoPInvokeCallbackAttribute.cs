using System;

namespace Rewired.Utils.Attributes
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class MonoPInvokeCallbackAttribute : Attribute
	{
		private Type type;

		public MonoPInvokeCallbackAttribute(Type t)
		{
		}
	}
}
