using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jundroo.Common.Expressions
{
	public class TypeMetadata
	{
		public Dictionary<string, MethodInfo> Methods { get; } = new Dictionary<string, MethodInfo>();

		public MemberAccessPermissionFlags Permissions { get; }

		public Dictionary<string, MethodInfo> Properties { get; } = new Dictionary<string, MethodInfo>();

		public Type Type { get; }

		public TypeMetadata(Type type, MemberAccessPermissionFlags permissions)
		{
			Type = type;
			Permissions = permissions;
			if (!permissions.HasFlag(MemberAccessPermissionFlags.AllowAnnotated) && !permissions.HasFlag(MemberAccessPermissionFlags.AllowPublic))
			{
				return;
			}
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
			if (permissions.HasFlag(MemberAccessPermissionFlags.AllowBaseClass))
			{
				bindingFlags |= BindingFlags.FlattenHierarchy;
			}
			if (permissions.HasFlag(MemberAccessPermissionFlags.AllowMethods))
			{
				MethodInfo[] methods = type.GetMethods(bindingFlags);
				foreach (MethodInfo methodInfo in methods)
				{
					string text = methodInfo.Name;
					if (!permissions.HasFlag(MemberAccessPermissionFlags.AllowPublic))
					{
						ExposedAttribute customAttribute = methodInfo.GetCustomAttribute<ExposedAttribute>(inherit: true);
						if (customAttribute == null)
						{
							continue;
						}
						text = customAttribute.Name ?? text;
					}
					Methods.Add(text, methodInfo);
				}
			}
			if (!permissions.HasFlag(MemberAccessPermissionFlags.AllowProperties))
			{
				return;
			}
			PropertyInfo[] properties = type.GetProperties(bindingFlags);
			foreach (PropertyInfo propertyInfo in properties)
			{
				string text2 = propertyInfo.Name;
				if (!permissions.HasFlag(MemberAccessPermissionFlags.AllowPublic))
				{
					ExposedAttribute customAttribute2 = propertyInfo.GetCustomAttribute<ExposedAttribute>(inherit: true);
					if (customAttribute2 == null)
					{
						continue;
					}
					text2 = customAttribute2.Name ?? text2;
				}
				Properties.Add(text2, propertyInfo.GetGetMethod(nonPublic: false));
			}
		}
	}
}
