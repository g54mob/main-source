using System;
using System.Diagnostics;

namespace Animancer
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class EventNamesAttribute : Attribute
	{
		public EventNamesAttribute(params string[] names)
		{
		}

		public EventNamesAttribute(Type type)
		{
		}

		public EventNamesAttribute(Type type, string name)
		{
		}
	}
}
