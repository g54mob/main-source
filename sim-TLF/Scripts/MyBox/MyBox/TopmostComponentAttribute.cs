using System;
using JetBrains.Annotations;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Class)]
	[PublicAPI]
	public class TopmostComponentAttribute : Attribute
	{
	}
}
