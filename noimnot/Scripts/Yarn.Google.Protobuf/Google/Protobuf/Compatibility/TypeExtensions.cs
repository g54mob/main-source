using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Google.Protobuf.Compatibility
{
	internal static class TypeExtensions
	{
		internal static bool IsAssignableFrom(this Type target, Type c)
		{
			return false;
		}

		[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "The BaseType of the target will have all properties because of the annotation.")]
		internal static PropertyInfo GetProperty([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] this Type target, string name)
		{
			return null;
		}

		[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "The BaseType of the target will have all properties because of the annotation.")]
		internal static MethodInfo GetMethod([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] this Type target, string name)
		{
			return null;
		}
	}
}
