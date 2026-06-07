using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class SuppressInvalidAttributeErrorAttribute : Attribute
	{
	}
}
