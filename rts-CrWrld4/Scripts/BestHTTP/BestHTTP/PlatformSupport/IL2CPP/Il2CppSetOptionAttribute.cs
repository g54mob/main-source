using System;

namespace BestHTTP.PlatformSupport.IL2CPP
{
	public class Il2CppSetOptionAttribute : Attribute
	{
		public Option Option { get; private set; }

		public object Value { get; private set; }

		public Il2CppSetOptionAttribute(Option option, object value)
		{
		}
	}
}
