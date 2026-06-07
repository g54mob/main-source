using System;
using JetBrains.Annotations;

namespace Sirenix.OdinInspector
{
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	public class ShowInInspectorAttribute : Attribute
	{
	}
}
