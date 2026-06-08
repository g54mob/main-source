using System;
using System.ComponentModel;

namespace ProtoBuf
{
	[ImmutableObject(true)]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public sealed class CompatibilityLevelAttribute : Attribute
	{
		public CompatibilityLevel Level { get; }

		public CompatibilityLevelAttribute(CompatibilityLevel level)
		{
			Level = level;
		}

		internal static void AssertValid(CompatibilityLevel compatibilityLevel)
		{
			switch (compatibilityLevel)
			{
			case CompatibilityLevel.NotSpecified:
			case CompatibilityLevel.Level200:
			case CompatibilityLevel.Level240:
			case CompatibilityLevel.Level300:
				return;
			}
			Throw(compatibilityLevel);
			static void Throw(CompatibilityLevel compatibilityLevel2)
			{
				throw new ArgumentOutOfRangeException("compatibilityLevel", $"Compatiblity level '{compatibilityLevel2}' is not recognized.");
			}
		}
	}
}
