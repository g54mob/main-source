using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

namespace PugMod
{
	public static class JobsPatch
	{
		private static readonly string ProducerAttributeName = typeof(JobProducerTypeAttribute).FullName;

		private static readonly string RegisterGenericJobTypeAttributeName = typeof(RegisterGenericJobTypeAttribute).FullName;

		public static bool Patch(Assembly assembly)
		{
			List<Type> list = new List<Type>();
			foreach (CustomAttributeData customAttribute in assembly.CustomAttributes)
			{
				if (string.Equals(customAttribute.AttributeType.FullName, RegisterGenericJobTypeAttributeName))
				{
					Type type = (Type)customAttribute.ConstructorArguments[0].Value;
					if (type.IsGenericType && type.IsValueType)
					{
						list.Add(type);
					}
				}
			}
			HashSet<Type> visited = new HashSet<Type>();
			CollectGenericTypeInstances(assembly, list, visited);
			bool flag = false;
			Type[] types = assembly.GetTypes();
			foreach (Type t in types)
			{
				flag |= VisitJobStructs(t);
			}
			foreach (Type item in list)
			{
				flag |= VisitJobStructs(item);
			}
			return true;
		}

		private static bool VisitJobStructs(Type t)
		{
			if (t.ContainsGenericParameters)
			{
				return false;
			}
			return VisitJobStructInterfaces(t, t);
		}

		private static bool VisitJobStructInterfaces(Type jobType, Type currentType)
		{
			bool flag = false;
			Type[] interfaces;
			if (jobType.IsValueType)
			{
				interfaces = currentType.GetInterfaces();
				foreach (Type type in interfaces)
				{
					foreach (CustomAttributeData customAttribute in type.CustomAttributes)
					{
						if (customAttribute.AttributeType.FullName == ProducerAttributeName)
						{
							Type producerType = (Type)customAttribute.ConstructorArguments[0].Value;
							flag |= FindInitMethod(producerType, jobType);
						}
						if (currentType.IsInterface && !type.ContainsGenericParameters)
						{
							flag |= VisitJobStructInterfaces(jobType, type);
						}
					}
				}
			}
			interfaces = currentType.GetNestedTypes();
			foreach (Type t in interfaces)
			{
				flag |= VisitJobStructs(t);
			}
			return flag;
		}

		private static bool FindInitMethod(Type producerType, Type jobType)
		{
			while (producerType != null)
			{
				MethodInfo methodInfo = producerType.GetMethods().FirstOrDefault((MethodInfo x) => x.Name == "EarlyJobInit" && x.GetParameters().Length == 0 && x.IsStatic && x.IsPublic);
				if (methodInfo != null)
				{
					MethodInfo methodInfo2 = methodInfo.MakeGenericMethod(jobType);
					Type[] genericArguments = methodInfo2.GetGenericArguments();
					if (genericArguments.Length != 0)
					{
						Debug.Log($"Invoke {producerType.Name}.{methodInfo2.Name}<{genericArguments[0]}...>()");
					}
					methodInfo2.Invoke(null, Array.Empty<object>());
					return false;
				}
				producerType = producerType.DeclaringType;
			}
			return false;
		}

		private static void CollectGenericTypeInstances(Assembly assembly, List<Type> types, HashSet<Type> visited)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			foreach (Module module in assembly.Modules)
			{
				for (int i = 1; i < 16777216; i++)
				{
					try
					{
						Type type = module.ResolveType(0x1B000000 | i);
						if (type.IsConstructedGenericType && !type.ContainsGenericParameters)
						{
							CollectGenericTypeInstances(type, types, visited);
						}
					}
					catch (ArgumentOutOfRangeException)
					{
						break;
					}
					catch (ArgumentException)
					{
					}
				}
				for (int j = 1; j < 16777216; j++)
				{
					try
					{
						Type[] genericArguments = module.ResolveMethod(0x2B000000 | j).GetGenericArguments();
						foreach (Type type2 in genericArguments)
						{
							if (type2.IsConstructedGenericType && !type2.ContainsGenericParameters)
							{
								CollectGenericTypeInstances(type2, types, visited);
							}
						}
					}
					catch (ArgumentOutOfRangeException)
					{
						break;
					}
					catch (ArgumentException)
					{
					}
				}
				for (int l = 1; l < 16777216; l++)
				{
					try
					{
						CollectGenericTypeInstances(module.ResolveField(0x4000000 | l).FieldType, types, visited);
					}
					catch (ArgumentOutOfRangeException)
					{
						break;
					}
					catch (ArgumentException)
					{
					}
				}
			}
		}

		private static void CollectGenericTypeInstances(Type type, List<Type> types, HashSet<Type> visited)
		{
			if (type.IsPrimitive || !visited.Add(type))
			{
				return;
			}
			if (type.IsConstructedGenericType && !type.ContainsGenericParameters)
			{
				types.Add(type);
			}
			Type[] genericTypeArguments = type.GenericTypeArguments;
			foreach (Type type2 in genericTypeArguments)
			{
				if (!type2.IsPrimitive)
				{
					CollectGenericTypeInstances(type2, types, visited);
				}
			}
		}
	}
}
