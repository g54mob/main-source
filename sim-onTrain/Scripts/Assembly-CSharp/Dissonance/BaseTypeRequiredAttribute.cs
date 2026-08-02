using System;

namespace Dissonance
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[Dissonance.BaseTypeRequired(typeof(Attribute))]
	internal sealed class BaseTypeRequiredAttribute : Attribute
	{
		[Dissonance.NotNull]
		public Type BaseType { get; private set; }

		public BaseTypeRequiredAttribute([Dissonance.NotNull] Type baseType)
		{
			BaseType = baseType;
		}
	}
}
