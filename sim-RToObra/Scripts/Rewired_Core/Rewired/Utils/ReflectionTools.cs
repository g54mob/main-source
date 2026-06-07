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
			if (type == null)
			{
				return false;
			}
			return type.IsEnum;
		}

		public static Type GetUnderlyingEnumType(Type enumType)
		{
			if (enumType == null)
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
			if (type == null)
			{
				return false;
			}
			return type.IsGenericType;
		}

		public static Type[] GetGenericArguments(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetGenericArguments();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetFields();
		}

		public static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetFields((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetProperties();
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetProperties((System.Reflection.BindingFlags)bindingFlags);
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetMethods();
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindingFlags)
		{
			if (type == null)
			{
				return null;
			}
			return type.GetMethods((System.Reflection.BindingFlags)bindingFlags);
		}

		public static bool IsDefined(Type type, Type attributeType, bool inherit)
		{
			if (type == null || attributeType == null)
			{
				return false;
			}
			return type.IsDefined(attributeType, inherit);
		}

		public static T GetAttribute<T>(Type type, bool inherit) where T : Attribute
		{
			if (type == null)
			{
				return null;
			}
			T result = default(T);
			try
			{
				object[] customAttributes = type.GetCustomAttributes(typeof(T), inherit);
				if (customAttributes == null)
				{
					goto IL_0049;
				}
				if (customAttributes.Length == 0)
				{
					goto IL_0027;
				}
				goto IL_0063;
				IL_0063:
				result = customAttributes[0] as T;
				goto end_IL_000d;
				IL_0027:
				int num = 1465715618;
				goto IL_002c;
				IL_002c:
				switch (num ^ 0x575D0BA3)
				{
				case 0:
					break;
				case 1:
					goto IL_0049;
				case 2:
					goto end_IL_000d;
				default:
					goto IL_0063;
				}
				goto IL_0027;
				IL_0049:
				result = null;
				num = 1465715617;
				goto IL_002c;
				end_IL_000d:;
			}
			catch
			{
				T val = default(T);
				while (true)
				{
					IL_0074:
					int num2 = 1465715618;
					while (true)
					{
						switch (num2 ^ 0x575D0BA3)
						{
						case 2:
							break;
						case 1:
							goto IL_0092;
						default:
							result = val;
							goto end_IL_0079;
						}
						goto IL_0074;
						IL_0092:
						val = null;
						num2 = 1465715619;
						continue;
						end_IL_0079:
						break;
					}
					break;
				}
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
			int num2 = -512148827;
			goto IL_000d;
			IL_0008:
			num2 = -512148830;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -512148828)
				{
				case 0:
					break;
				case 6:
					return false;
				case 5:
					return true;
				case 4:
					return true;
				case 7:
					if (!ignoreCase)
					{
						if (useShortName)
						{
							if (assemblies[num].GetName().Name.Equals(assemblyName))
							{
								num2 = -512148820;
								continue;
							}
						}
						else if (assemblies[num].FullName.Equals(assemblyName))
						{
							num2 = -512148825;
							continue;
						}
						goto IL_00cc;
					}
					num2 = -512148826;
					continue;
				case 2:
					if (!useShortName)
					{
						if (assemblies[num].FullName.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
						{
							num2 = -512148831;
							continue;
						}
					}
					else if (assemblies[num].GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase))
					{
						num2 = -512148832;
						continue;
					}
					goto IL_00cc;
				case 3:
					return true;
				case 8:
					return true;
				default:
					{
						if (num >= assemblies.Length)
						{
							return false;
						}
						goto case 7;
					}
					IL_00cc:
					num++;
					num2 = -512148827;
					continue;
				}
				break;
			}
			goto IL_0008;
		}

		internal static Type GetTypeInUnityEditorAssembly(string classPath, bool ignoreCase = false)
		{
			return UzDcEHAnPuPHCBXYooCbdgSVsykk(classPath, true, ignoreCase);
		}

		internal static Type GetTypeInUnityBuildAssembly(string classPath, bool ignoreCase = false)
		{
			return UzDcEHAnPuPHCBXYooCbdgSVsykk(classPath, false, ignoreCase);
		}

		private static Type UzDcEHAnPuPHCBXYooCbdgSVsykk(string P_0, bool P_1, bool P_2 = false)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			int num = 0;
			while (num < assemblies.Length)
			{
				while (true)
				{
					Assembly assembly = assemblies[num];
					int num2 = 927063198;
					while (true)
					{
						switch (num2 ^ 0x3741DC9C)
						{
						case 3:
							num2 = 927063192;
							continue;
						case 4:
							break;
						case 2:
						{
							Type type = assembly.GetType(P_0, false, P_2);
							if (type != null)
							{
								return type;
							}
							goto case 0;
						}
						case 0:
							num++;
							num2 = 927063197;
							continue;
						default:
							goto end_IL_0036;
						}
						break;
					}
					continue;
					end_IL_0036:
					break;
				}
			}
			return null;
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
			while (true)
			{
				int num = 1865636970;
				while (true)
				{
					switch (num ^ 0x6F335C6B)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0035;
					case 2:
						return;
					}
					break;
					IL_0035:
					field.SetValue(obj, value);
					num = 1865636969;
				}
			}
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
			Type typeFromHandle = default(Type);
			while (true)
			{
				int num = -1192217606;
				while (true)
				{
					switch (num ^ -1192217605)
					{
					case 2:
						break;
					case 1:
						goto IL_0021;
					default:
					{
						MethodInfo method = typeFromHandle.GetMethod(name, (System.Reflection.BindingFlags)bindingAttr);
						return (TRet)method.Invoke(obj, param);
					}
					}
					break;
					IL_0021:
					typeFromHandle = typeof(T);
					num = -1192217605;
				}
			}
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
