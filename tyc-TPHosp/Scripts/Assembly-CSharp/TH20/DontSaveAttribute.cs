using System;

namespace TH20
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field)]
	public class DontSaveAttribute : Attribute
	{
	}
}
