using System.Reflection;

namespace FluentAssertions.Common
{
	internal static class PropertyInfoExtensions
	{
		internal static bool IsVirtual(this PropertyInfo property)
		{
			return !(property.GetGetMethod(nonPublic: true) ?? property.GetSetMethod(nonPublic: true)).IsNonVirtual();
		}

		internal static bool IsStatic(this PropertyInfo property)
		{
			return (property.GetGetMethod(nonPublic: true) ?? property.GetSetMethod(nonPublic: true)).IsStatic;
		}

		internal static bool IsAbstract(this PropertyInfo property)
		{
			return (property.GetGetMethod(nonPublic: true) ?? property.GetSetMethod(nonPublic: true)).IsAbstract;
		}
	}
}
