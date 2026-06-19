using System;

namespace BehaviorDesigner
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class SerializeStateAttribute : Attribute
	{
	}
}
