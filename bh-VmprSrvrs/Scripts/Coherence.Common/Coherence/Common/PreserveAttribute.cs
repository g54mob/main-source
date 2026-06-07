using System;
using System.Diagnostics;

namespace Coherence.Common
{
	[Conditional("UNITY_5_3_OR_NEWER")]
	[Conditional("UNITY")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	internal sealed class PreserveAttribute : Attribute
	{
	}
}
