using System;

namespace Kongregate
{
	public class MonoPInvokeCallbackAttribute : Attribute
	{
		public Type type;

		public MonoPInvokeCallbackAttribute(Type t)
		{
			type = t;
		}
	}
}
