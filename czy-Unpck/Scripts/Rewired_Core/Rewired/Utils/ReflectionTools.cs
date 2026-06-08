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
			return type?.IsEnum ?? false;
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
			return type?.IsGenericType ?? false;
		}

		public static Type[] GetGenericArguments(Type type)
		{
			return type?.GetGenericArguments();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			return type?.GetFields();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags)
		{
			return type?.GetFields((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			return type?.GetProperties();
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags bindingFlags)
		{
			return type?.GetProperties((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type)
		{
			return type?.GetMethods();
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindingFlags)
		{
			return type?.GetMethods((System.Reflection.BindingFlags)bindingFlags);
		}

		public static bool IsDefined(Type type, Type attributeType, bool inherit)
		{
			if ((object)type != null)
			{
				while (true)
				{
					int num = -1873089099;
					while (true)
					{
						switch (num ^ -1873089100)
						{
						case 0:
							break;
						case 1:
							goto IL_0021;
						default:
							goto end_IL_0003;
						}
						break;
						IL_0021:
						if ((object)attributeType == null)
						{
							num = -1873089098;
							continue;
						}
						return type.IsDefined(attributeType, inherit);
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return false;
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
				if (customAttributes != null)
				{
					goto IL_0022;
				}
				goto IL_0051;
				IL_0022:
				int num = 281568396;
				goto IL_0027;
				IL_0027:
				while (true)
				{
					switch (num ^ 0x10C8648E)
					{
					case 0:
						break;
					case 3:
						goto end_IL_000d;
					case 1:
						goto IL_0051;
					case 2:
						goto IL_0062;
					default:
						result = customAttributes[0] as T;
						goto end_IL_000d;
					}
					break;
					IL_0062:
					int num2;
					if (customAttributes.Length == 0)
					{
						num = 281568399;
						num2 = num;
					}
					else
					{
						num = 281568394;
						num2 = num;
					}
				}
				goto IL_0022;
				IL_0051:
				result = null;
				num = 281568397;
				goto IL_0027;
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
				goto IL_0008;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (assemblies == null)
			{
				return false;
			}
			int num = 0;
			int num2 = 95931052;
			goto IL_000d;
			IL_0008:
			num2 = 95931055;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x5B7CAAC)
				{
				case 5:
					break;
				case 2:
					return true;
				case 4:
					if (assemblies[num].GetName().Name.Equals(assemblyName))
					{
						return true;
					}
					goto IL_006a;
				case 3:
					return false;
				case 1:
					if (!ignoreCase)
					{
						if (useShortName)
						{
							num2 = 95931048;
							continue;
						}
						if (assemblies[num].FullName.Equals(assemblyName))
						{
							return true;
						}
					}
					else if (useShortName)
					{
						if (assemblies[num].GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					else if (assemblies[num].FullName.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
					{
						num2 = 95931054;
						continue;
					}
					goto IL_006a;
				default:
					{
						if (num >= assemblies.Length)
						{
							return false;
						}
						goto case 1;
					}
					IL_006a:
					num++;
					num2 = 95931052;
					continue;
				}
				break;
			}
			goto IL_0008;
		}

		internal static Type GetTypeInUnityEditorAssembly(string classPath, bool ignoreCase = false)
		{
			return EXakJvTyqezeEFaXEtwBNkAeuG(classPath, true, ignoreCase);
		}

		internal static Type GetTypeInUnityBuildAssembly(string classPath, bool ignoreCase = false)
		{
			return EXakJvTyqezeEFaXEtwBNkAeuG(classPath, false, ignoreCase);
		}

		private static Type EXakJvTyqezeEFaXEtwBNkAeuG(string P_0, bool P_1, bool P_2 = false)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			int num = 0;
			Type type = default(Type);
			while (num < assemblies.Length)
			{
				while (true)
				{
					Assembly assembly = assemblies[num];
					int num2 = 524998778;
					while (true)
					{
						switch (num2 ^ 0x1F4AD87C)
						{
						case 0:
							num2 = 524998783;
							continue;
						case 5:
							num++;
							num2 = 524998776;
							continue;
						case 6:
							type = assembly.GetType(P_0, throwOnError: false, P_2);
							num2 = 524998781;
							continue;
						case 2:
							return type;
						case 3:
							break;
						case 1:
							goto IL_0073;
						default:
							goto end_IL_0067;
						}
						break;
						IL_0073:
						int num3;
						if ((object)type != null)
						{
							num2 = 524998782;
							num3 = num2;
						}
						else
						{
							num2 = 524998777;
							num3 = num2;
						}
					}
					continue;
					end_IL_0067:
					break;
				}
			}
			return null;
		}

		internal static Type GetTypeInAssembly(string classPath, string assemblyName, bool ignoreCase = false)
		{
			return Type.GetType(classPath + ", " + assemblyName + ", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", throwOnError: false, ignoreCase);
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
			return @delegate?.Method;
		}
	}
}
