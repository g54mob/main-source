using System.Reflection;

namespace Reflectify
{
	internal static class PropertyInfoExtensions
	{
		public static bool IsIndexer(this PropertyInfo member)
		{
			return member.GetIndexParameters().Length != 0;
		}

		public static bool IsExplicitlyImplemented(this PropertyInfo prop)
		{
			return prop.Name.IndexOf('.') != -1;
		}

		public static bool IsPublic(this PropertyInfo prop)
		{
			MethodInfo getMethod = prop.GetMethod;
			if ((object)getMethod == null || !getMethod.IsPublic)
			{
				return prop.SetMethod?.IsPublic ?? false;
			}
			return true;
		}

		public static bool IsInternal(this PropertyInfo prop)
		{
			MethodInfo getMethod = prop.GetMethod;
			bool flag = (((object)getMethod != null && (getMethod.IsAssembly || getMethod.IsFamilyOrAssembly)) ? true : false);
			bool flag2 = flag;
			if (!flag2)
			{
				MethodInfo setMethod = prop.SetMethod;
				bool flag3 = (((object)setMethod != null && (setMethod.IsAssembly || setMethod.IsFamilyOrAssembly)) ? true : false);
				flag2 = flag3;
			}
			return flag2;
		}

		public static bool IsAbstract(this PropertyInfo prop)
		{
			MethodInfo getMethod = prop.GetMethod;
			if ((object)getMethod == null || !getMethod.IsAbstract)
			{
				return prop.SetMethod?.IsAbstract ?? false;
			}
			return true;
		}
	}
}
