using System;

namespace TH20
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class DontVisitInternalsForAssetReferenceAttribute : Attribute
	{
	}
}
