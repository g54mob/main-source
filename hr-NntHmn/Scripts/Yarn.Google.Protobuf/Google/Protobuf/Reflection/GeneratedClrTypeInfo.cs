using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("ClrType = {ClrType}")]
	public sealed class GeneratedClrTypeInfo
	{
		private static readonly string[] EmptyNames;

		private static readonly GeneratedClrTypeInfo[] EmptyCodeInfo;

		private static readonly Extension[] EmptyExtensions;

		internal const DynamicallyAccessedMemberTypes MessageAccessibility = DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties;

		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
		public Type ClrType { get; }

		public MessageParser Parser { get; }

		public string[] PropertyNames { get; }

		public Extension[] Extensions { get; }

		public string[] OneofNames { get; }

		public GeneratedClrTypeInfo[] NestedTypes { get; }

		public Type[] NestedEnums { get; }

		public GeneratedClrTypeInfo([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type clrType, MessageParser parser, string[] propertyNames, string[] oneofNames, Type[] nestedEnums, Extension[] extensions, GeneratedClrTypeInfo[] nestedTypes)
		{
		}

		public GeneratedClrTypeInfo([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type clrType, MessageParser parser, string[] propertyNames, string[] oneofNames, Type[] nestedEnums, GeneratedClrTypeInfo[] nestedTypes)
		{
		}

		public GeneratedClrTypeInfo(Type[] nestedEnums, Extension[] extensions, GeneratedClrTypeInfo[] nestedTypes)
		{
		}

		public GeneratedClrTypeInfo(Type[] nestedEnums, GeneratedClrTypeInfo[] nestedTypes)
		{
		}
	}
}
