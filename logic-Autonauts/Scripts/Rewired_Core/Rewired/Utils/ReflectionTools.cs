using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public static class ReflectionTools
	{
		[Flags]
		public enum BindingFlags
		{
			IgnoreCase = 1,
			DeclaredOnly = 2,
			Instance = 4,
			Static = 8,
			Public = 0x10,
			NonPublic = 0x20,
			FlattenHierarchy = 0x40
		}

		public static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}

		public static bool IsEnum(Type type)
		{
			if ((object)type == null)
			{
				return false;
			}
			return type.IsEnum;
		}

		public static Type GetUnderlyingEnumType(Type enumType)
		{
			if ((object)enumType == null)
			{
				return null;
			}
			if (!IsEnum(enumType))
			{
				return null;
			}
			return Enum.GetUnderlyingType(enumType);
		}

		public static bool IsClass(Type type)
		{
			return type.IsClass;
		}

		public static bool IsPrimitive(Type type)
		{
			return type.IsPrimitive;
		}

		public static bool IsArray(Type type)
		{
			return type.IsArray;
		}

		public static bool DoesTypeImplement(Type type, Type baseOrInterfaceType)
		{
			return baseOrInterfaceType.IsAssignableFrom(type);
		}

		public static bool IsGenericType(Type type)
		{
			if ((object)type == null)
			{
				return false;
			}
			return type.IsGenericType;
		}

		public static Type[] GetGenericArguments(Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetGenericArguments();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetFields();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetFields((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetProperties();
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags bindingFlags)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetProperties((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetMethods();
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindingFlags)
		{
			if ((object)type == null)
			{
				return null;
			}
			return type.GetMethods((System.Reflection.BindingFlags)bindingFlags);
		}

		public static bool IsDefined(Type type, Type attributeType, bool inherit)
		{
			if ((object)type == null || (object)attributeType == null)
			{
				return false;
			}
			return type.IsDefined(attributeType, inherit);
		}

		public static T GetAttribute<T>(Type type, bool inherit) where T : Attribute
		{
			if ((object)type == null)
			{
				return null;
			}
			T result = default(T);
			try
			{
				object[] customAttributes = type.GetCustomAttributes(typeof(T), inherit);
				if (customAttributes == null)
				{
					goto IL_004d;
				}
				if (customAttributes.Length == 0)
				{
					goto IL_0027;
				}
				goto IL_0067;
				IL_004d:
				result = null;
				int num = 995076083;
				goto IL_002c;
				IL_0027:
				num = 995076084;
				goto IL_002c;
				IL_002c:
				switch (num ^ 0x3B4FA7F0)
				{
				case 0:
					break;
				default:
					goto end_IL_000d;
				case 4:
					goto IL_004d;
				case 3:
					goto end_IL_000d;
				case 2:
					goto IL_0067;
				case 1:
					goto end_IL_000d;
				}
				goto IL_0027;
				IL_0067:
				result = customAttributes[0] as T;
				num = 995076081;
				goto IL_002c;
				end_IL_000d:;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		internal static bool IsAssemblyLoaded(string assemblyName, bool useShortName, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(assemblyName))
			{
				return false;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (assemblies == null)
			{
				return false;
			}
			int num = 0;
			while (num < assemblies.Length)
			{
				while (true)
				{
					int num2;
					if (ignoreCase)
					{
						if (useShortName)
						{
							if (assemblies[num].GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
							{
								num2 = 514546166;
								goto IL_0026;
							}
						}
						else if (assemblies[num].FullName.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					else if (useShortName)
					{
						if (assemblies[num].GetName().Name.Equals(assemblyName))
						{
							return true;
						}
					}
					else if (assemblies[num].FullName.Equals(assemblyName))
					{
						return true;
					}
					num++;
					num2 = 514546164;
					goto IL_0026;
					IL_0026:
					while (true)
					{
						switch (num2 ^ 0x1EAB59F7)
						{
						case 0:
							num2 = 514546165;
							continue;
						case 2:
							break;
						case 1:
							return true;
						default:
							goto end_IL_0043;
						}
						break;
					}
					continue;
					end_IL_0043:
					break;
				}
			}
			return false;
		}

		internal static Type GetTypeInUnityEditorAssembly(string classPath, bool ignoreCase = false)
		{
			return hmDUNSPqHchcrjMRWLIrPuMDzvz(classPath, true, ignoreCase);
		}

		internal static Type GetTypeInUnityBuildAssembly(string classPath, bool ignoreCase = false)
		{
			return hmDUNSPqHchcrjMRWLIrPuMDzvz(classPath, false, ignoreCase);
		}

		private static Type hmDUNSPqHchcrjMRWLIrPuMDzvz(string P_0, bool P_1, bool P_2 = false)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			int num = 0;
			while (true)
			{
				int num2 = 1450992852;
				while (true)
				{
					switch (num2 ^ 0x567C64D6)
					{
					case 0:
						break;
					case 2:
						num2 = 1450992855;
						continue;
					case 3:
						num++;
						num2 = 1450992855;
						continue;
					case 4:
					{
						Assembly assembly = assemblies[num];
						Type type = assembly.GetType(P_0, false, P_2);
						if ((object)type != null)
						{
							return type;
						}
						goto case 3;
					}
					default:
						if (num >= assemblies.Length)
						{
							return null;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		internal static Type GetTypeInAssembly(string classPath, string assemblyName, bool ignoreCase = false)
		{
			return Type.GetType(classPath + ", " + assemblyName + ", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false, ignoreCase);
		}

		public static TRet GetPrivateField<T, TRet>(T obj, string name)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			Type typeFromHandle = typeof(T);
			FieldInfo field = typeFromHandle.GetField(name, (System.Reflection.BindingFlags)bindingAttr);
			return (TRet)field.GetValue(obj);
		}

		public static TRet GetPrivateProperty<T, TRet>(T obj, string name)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			Type typeFromHandle = typeof(T);
			PropertyInfo property = typeFromHandle.GetProperty(name, (System.Reflection.BindingFlags)bindingAttr);
			return (TRet)property.GetValue(obj, null);
		}

		public static void SetPrivateField<T>(T obj, string name, object value)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			Type typeFromHandle = typeof(T);
			FieldInfo field = typeFromHandle.GetField(name, (System.Reflection.BindingFlags)bindingAttr);
			field.SetValue(obj, value);
		}

		public static void SetPrivateProperty<T>(T obj, string name, object value)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			Type typeFromHandle = typeof(T);
			PropertyInfo property = typeFromHandle.GetProperty(name, (System.Reflection.BindingFlags)bindingAttr);
			property.SetValue(obj, value, null);
		}

		public static TRet CallPrivateMethod<T, TRet>(T obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			Type typeFromHandle = typeof(T);
			MethodInfo method = typeFromHandle.GetMethod(name, (System.Reflection.BindingFlags)bindingAttr);
			return (TRet)method.Invoke(obj, param);
		}

		public static MethodInfo GetMethodInfo(Delegate @delegate)
		{
			if ((object)@delegate == null)
			{
				return null;
			}
			return @delegate.Method;
		}
	}
}
