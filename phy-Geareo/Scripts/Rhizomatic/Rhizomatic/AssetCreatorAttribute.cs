using System;

namespace Rhizomatic
{
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
	public sealed class AssetCreatorAttribute : Attribute
	{
		public Type categoryType;

		public AssetCreatorAttribute(Type categoryType)
		{
		}
	}
}
