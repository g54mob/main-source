using System;

namespace ZLinq
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	public class ZLinqDropInExternalExtensionAttribute : Attribute
	{
		public string GenerateNamespace { get; }

		public string SourceTypeFullyQualifiedMetadataName { get; }

		public string? EnumeratorTypeFullyQualifiedMetadataName { get; }

		public bool GenerateAsPublic { get; set; }

		public ZLinqDropInExternalExtensionAttribute(string generateNamespace, string sourceTypeFullyQualifiedMetadataName, string? enumeratorTypeFullyQualifiedMetadataName = null)
		{
			GenerateNamespace = generateNamespace;
			SourceTypeFullyQualifiedMetadataName = sourceTypeFullyQualifiedMetadataName;
			EnumeratorTypeFullyQualifiedMetadataName = enumeratorTypeFullyQualifiedMetadataName;
		}
	}
}
