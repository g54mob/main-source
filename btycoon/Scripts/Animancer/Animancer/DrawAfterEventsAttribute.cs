using System;
using System.Diagnostics;

namespace Animancer
{
	[AttributeUsage(AttributeTargets.Field)]
	[Conditional("UNITY_EDITOR")]
	public sealed class DrawAfterEventsAttribute : Attribute
	{
	}
}
