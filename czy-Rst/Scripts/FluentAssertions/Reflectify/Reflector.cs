using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflectify
{
	internal sealed class Reflector
	{
		private readonly List<FieldInfo> selectedFields = new List<FieldInfo>();

		private List<PropertyInfo> selectedProperties = new List<PropertyInfo>();

		public MemberInfo[] Members { get; }

		public PropertyInfo[] Properties => selectedProperties.ToArray();

		public FieldInfo[] Fields => selectedFields.ToArray();

		public Reflector(Type typeToReflect, MemberKind kind)
		{
			LoadProperties(typeToReflect, kind);
			LoadFields(typeToReflect, kind);
			List<PropertyInfo> list = selectedProperties;
			List<FieldInfo> list2 = selectedFields;
			int num = 0;
			MemberInfo[] array = new MemberInfo[list.Count + list2.Count];
			foreach (PropertyInfo item in list)
			{
				array[num] = item;
				num++;
			}
			foreach (FieldInfo item2 in list2)
			{
				array[num] = item2;
				num++;
			}
			Members = array;
		}

		private void LoadProperties(Type typeToReflect, MemberKind kind)
		{
			HashSet<string> collectedPropertyNames = new HashSet<string>();
			while (typeToReflect != null && typeToReflect != typeof(object))
			{
				BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
				bindingFlags = (BindingFlags)((int)bindingFlags | (kind.HasFlag(MemberKind.Static) ? 8 : 4));
				PropertyInfo[] properties = typeToReflect.GetProperties(bindingFlags);
				AddNormalProperties(kind, properties, collectedPropertyNames);
				AddExplicitlyImplementedProperties(kind, properties, collectedPropertyNames);
				AddInterfaceProperties(typeToReflect, kind, bindingFlags, collectedPropertyNames);
				typeToReflect = typeToReflect.BaseType;
			}
			selectedProperties = selectedProperties.Where((PropertyInfo x) => !x.IsIndexer()).ToList();
		}

		private void AddNormalProperties(MemberKind kind, PropertyInfo[] allProperties, HashSet<string> collectedPropertyNames)
		{
			if (!kind.HasFlag(MemberKind.Public) && !kind.HasFlag(MemberKind.Internal) && !kind.HasFlag(MemberKind.ExplicitlyImplemented))
			{
				return;
			}
			foreach (PropertyInfo propertyInfo in allProperties)
			{
				if (HasVisibility(kind, propertyInfo) && !propertyInfo.IsExplicitlyImplemented() && collectedPropertyNames.Add(propertyInfo.Name))
				{
					selectedProperties.Add(propertyInfo);
				}
			}
		}

		private static bool HasVisibility(MemberKind kind, PropertyInfo prop)
		{
			if (!kind.HasFlag(MemberKind.Public) || !prop.IsPublic())
			{
				if (kind.HasFlag(MemberKind.Internal))
				{
					return prop.IsInternal();
				}
				return false;
			}
			return true;
		}

		private void AddExplicitlyImplementedProperties(MemberKind kind, PropertyInfo[] allProperties, HashSet<string> collectedPropertyNames)
		{
			if (!kind.HasFlag(MemberKind.ExplicitlyImplemented))
			{
				return;
			}
			foreach (PropertyInfo propertyInfo in allProperties)
			{
				if (propertyInfo.IsExplicitlyImplemented())
				{
					string item = propertyInfo.Name.Split(new char[1] { '.' }).Last();
					if (collectedPropertyNames.Add(item))
					{
						selectedProperties.Add(propertyInfo);
					}
				}
			}
		}

		private void AddInterfaceProperties(Type typeToReflect, MemberKind kind, BindingFlags flags, HashSet<string> collectedPropertyNames)
		{
			if (!kind.HasFlag(MemberKind.DefaultInterfaceProperties) && !typeToReflect.IsInterface)
			{
				return;
			}
			Type[] interfaces = typeToReflect.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				PropertyInfo[] properties = interfaces[i].GetProperties(flags);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if ((!propertyInfo.IsAbstract() || typeToReflect.IsInterface) && collectedPropertyNames.Add(propertyInfo.Name))
					{
						selectedProperties.Add(propertyInfo);
					}
				}
			}
		}

		private void LoadFields(Type typeToReflect, MemberKind kind)
		{
			HashSet<string> hashSet = new HashSet<string>();
			while (typeToReflect != null && typeToReflect != typeof(object))
			{
				BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
				bindingFlags = (BindingFlags)((int)bindingFlags | (kind.HasFlag(MemberKind.Static) ? 8 : 4));
				FieldInfo[] fields = typeToReflect.GetFields(bindingFlags);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (HasVisibility(kind, fieldInfo) && hashSet.Add(fieldInfo.Name))
					{
						selectedFields.Add(fieldInfo);
					}
				}
				typeToReflect = typeToReflect.BaseType;
			}
		}

		private static bool HasVisibility(MemberKind kind, FieldInfo field)
		{
			if (!kind.HasFlag(MemberKind.Public) || !field.IsPublic)
			{
				if (kind.HasFlag(MemberKind.Internal))
				{
					if (!field.IsAssembly)
					{
						return field.IsFamilyOrAssembly;
					}
					return true;
				}
				return false;
			}
			return true;
		}
	}
}
