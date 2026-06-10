using System;

namespace TwitchSDK.Interop
{
	[AttributeUsage(AttributeTargets.Method)]
	internal sealed class MonoPInvokeCallbackAttribute : Attribute
	{
		public Type Type { get; private set; }

		public MonoPInvokeCallbackAttribute(Type type)
		{
			Type = type;
		}
	}
}
