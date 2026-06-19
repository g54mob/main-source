using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	internal sealed class CompilerFeatureRequiredAttribute : Attribute
	{
		public const string RefStructs = "RefStructs";

		public const string RequiredMembers = "RequiredMembers";

		public string FeatureName { get; }

		public bool IsOptional { get; init; }

		public CompilerFeatureRequiredAttribute(string featureName)
		{
			FeatureName = featureName;
		}
	}
}
