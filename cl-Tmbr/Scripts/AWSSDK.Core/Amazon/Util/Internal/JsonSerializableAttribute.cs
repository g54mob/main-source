using System;

namespace Amazon.Util.Internal
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class JsonSerializableAttribute : Attribute
	{
		public JsonSerializableAttribute(Type type)
		{
		}
	}
}
