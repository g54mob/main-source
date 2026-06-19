using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public class AssetsOnlyAttribute : Attribute
	{
	}
}
