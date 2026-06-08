using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoIncludeAttribute : Attribute
	{
		public int Tag { get; }

		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
		public string KnownTypeName { get; }

		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
		public Type KnownType => TypeModel.ResolveKnownType(KnownTypeName, null);

		[DefaultValue(DataFormat.Default)]
		public DataFormat DataFormat { get; set; }

		public ProtoIncludeAttribute(int tag, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type knownType)
			: this(tag, ((object)knownType == null) ? "" : knownType.AssemblyQualifiedName)
		{
		}

		public ProtoIncludeAttribute(int tag, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] string knownTypeName)
		{
			if (tag <= 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException("tag", "Tags must be positive integers");
			}
			if (string.IsNullOrEmpty(knownTypeName))
			{
				ThrowHelper.ThrowArgumentNullException("knownTypeName", "Known type cannot be blank");
			}
			Tag = tag;
			KnownTypeName = knownTypeName;
		}
	}
}
