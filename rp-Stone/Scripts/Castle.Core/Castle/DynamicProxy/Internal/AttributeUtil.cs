using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Internal
{
	public static class AttributeUtil
	{
		public static CustomAttributeInfo CreateInfo(CustomAttributeData attribute)
		{
			GetArguments(attribute.ConstructorArguments, out var constructorArgTypes, out var constructorArgs);
			ConstructorInfo constructor = attribute.AttributeType.GetConstructor(constructorArgTypes);
			GetSettersAndFields(attribute.AttributeType, attribute.NamedArguments, out var properties, out var propertyValues, out var fields, out var fieldValues);
			return new CustomAttributeInfo(constructor, constructorArgs, properties, propertyValues, fields, fieldValues);
		}

		private static void GetArguments(IList<CustomAttributeTypedArgument> constructorArguments, out Type[] constructorArgTypes, out object[] constructorArgs)
		{
			constructorArgTypes = new Type[constructorArguments.Count];
			constructorArgs = new object[constructorArguments.Count];
			for (int i = 0; i < constructorArguments.Count; i++)
			{
				constructorArgTypes[i] = constructorArguments[i].ArgumentType;
				constructorArgs[i] = ReadAttributeValue(constructorArguments[i]);
			}
		}

		private static object[] GetArguments(IList<CustomAttributeTypedArgument> constructorArguments)
		{
			object[] array = new object[constructorArguments.Count];
			for (int i = 0; i < constructorArguments.Count; i++)
			{
				array[i] = ReadAttributeValue(constructorArguments[i]);
			}
			return array;
		}

		private static object ReadAttributeValue(CustomAttributeTypedArgument argument)
		{
			object value = argument.Value;
			if (!argument.ArgumentType.GetTypeInfo().IsArray)
			{
				return value;
			}
			object[] arguments = GetArguments((IList<CustomAttributeTypedArgument>)value);
			object[] array = new object[arguments.Length];
			arguments.CopyTo(array, 0);
			return array;
		}

		private static void GetSettersAndFields(Type attributeType, IEnumerable<CustomAttributeNamedArgument> namedArguments, out PropertyInfo[] properties, out object[] propertyValues, out FieldInfo[] fields, out object[] fieldValues)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			List<object> list2 = new List<object>();
			List<FieldInfo> list3 = new List<FieldInfo>();
			List<object> list4 = new List<object>();
			foreach (CustomAttributeNamedArgument namedArgument in namedArguments)
			{
				if (namedArgument.IsField)
				{
					list3.Add(attributeType.GetField(namedArgument.MemberName));
					list4.Add(ReadAttributeValue(namedArgument.TypedValue));
				}
				else
				{
					list.Add(attributeType.GetProperty(namedArgument.MemberName));
					list2.Add(ReadAttributeValue(namedArgument.TypedValue));
				}
			}
			properties = list.ToArray();
			propertyValues = list2.ToArray();
			fields = list3.ToArray();
			fieldValues = list4.ToArray();
		}

		public static IEnumerable<CustomAttributeInfo> GetNonInheritableAttributes(this MemberInfo member)
		{
			IEnumerable<CustomAttributeData> customAttributes = member.CustomAttributes;
			foreach (CustomAttributeData item in customAttributes)
			{
				Type attributeType = item.AttributeType;
				if (!ShouldSkipAttributeReplication(attributeType, ignoreInheritance: false))
				{
					CustomAttributeInfo customAttributeInfo;
					try
					{
						customAttributeInfo = CreateInfo(item);
					}
					catch (ArgumentException innerException)
					{
						throw new ProxyGenerationException(string.Format("Due to limitations in CLR, DynamicProxy was unable to successfully replicate non-inheritable attribute {0} on {1}{2}. To avoid this error you can chose not to replicate this attribute type by calling '{3}.Add(typeof({0}))'.", attributeType.FullName, member.DeclaringType.FullName, (member is TypeInfo) ? "" : ("." + member.Name), typeof(AttributesToAvoidReplicating).FullName), innerException);
					}
					if (customAttributeInfo != null)
					{
						yield return customAttributeInfo;
					}
				}
			}
		}

		public static IEnumerable<CustomAttributeInfo> GetNonInheritableAttributes(this ParameterInfo parameter)
		{
			IEnumerable<CustomAttributeData> customAttributes = parameter.CustomAttributes;
			bool ignoreInheritance = parameter.Member is ConstructorInfo;
			foreach (CustomAttributeData item in customAttributes)
			{
				if (!ShouldSkipAttributeReplication(item.AttributeType, ignoreInheritance))
				{
					CustomAttributeInfo customAttributeInfo = CreateInfo(item);
					if (customAttributeInfo != null)
					{
						yield return customAttributeInfo;
					}
				}
			}
		}

		private static bool ShouldSkipAttributeReplication(Type attribute, bool ignoreInheritance)
		{
			if (!attribute.GetTypeInfo().IsPublic)
			{
				return true;
			}
			if (AttributesToAvoidReplicating.ShouldAvoid(attribute))
			{
				return true;
			}
			if (attribute == typeof(ParamArrayAttribute))
			{
				return false;
			}
			if (!ignoreInheritance)
			{
				AttributeUsageAttribute[] array = attribute.GetTypeInfo().GetCustomAttributes<AttributeUsageAttribute>(inherit: true).ToArray();
				if (array.Length != 0)
				{
					return array[0].Inherited;
				}
				return true;
			}
			return false;
		}

		public static CustomAttributeInfo CreateInfo<TAttribute>() where TAttribute : Attribute, new()
		{
			return new CustomAttributeInfo(typeof(TAttribute).GetConstructor(Type.EmptyTypes), new object[0]);
		}

		public static CustomAttributeInfo CreateInfo(Type attribute, object[] constructorArguments)
		{
			return new CustomAttributeInfo(attribute.GetConstructor(GetTypes(constructorArguments)), constructorArguments);
		}

		private static Type[] GetTypes(object[] objects)
		{
			Type[] array = new Type[objects.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = objects[i].GetType();
			}
			return array;
		}
	}
}
