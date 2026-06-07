using System;

namespace UltimateReplay
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ReplayComponentPreparerAttribute : Attribute
	{
		public Type componentType;

		public ReplayComponentPreparerAttribute(Type componentType)
		{
			this.componentType = componentType;
		}
	}
}
