using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils.Libraries.TinyJson
{
	public static class JsonParser
	{
		[CustomObfuscation(rename = false)]
		internal static Stack<List<string>> splitArrayPool = new Stack<List<string>>();

		private static StringBuilder drNTNhoRPgnQDjVmGDJEvgXvRSn = new StringBuilder();

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> aRhsUGFchKOGdQlvGBuxyIzMqJp = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> QcceECBWCowbJVMdAPhVIKTZCOuL = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		[CompilerGenerated]
		private static Func<FieldInfo, bool> lOQcCRGEDAZVfMHZnMEpswIpjBVD;

		[CompilerGenerated]
		private static Func<FieldInfo, string> LDLmDsvfHVpKxKAhJlObsDuRmDN;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> wNyWUmLMRqqfCWaWaDRQiHidubV;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> IofEnaXWxGryaGqpiazUeyamIko;

		public static bool TryFromJson<T>(string json, out T value)
		{
			return TryFromJson<T>(json, out value, null);
		}

		[CustomObfuscation(rename = false)]
		internal static bool TryFromJson<T>(string json, out T value, Type preferredAnonymousObjectType)
		{
			try
			{
				if (string.IsNullOrEmpty(json))
				{
					value = default(T);
					return false;
				}
				drNTNhoRPgnQDjVmGDJEvgXvRSn.Length = 0;
				for (int i = 0; i < json.Length; i++)
				{
					char c = json[i];
					if (c == '"')
					{
						i = QkSTJdCDQaoEpUScvvjJTddkYis(true, i, json);
					}
					else if (!char.IsWhiteSpace(c))
					{
						drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(c);
					}
				}
				value = (T)yuZblmXMGWarnAAHsTCdgXVkZeRV(typeof(T), drNTNhoRPgnQDjVmGDJEvgXvRSn.ToString(), preferredAnonymousObjectType, out var _);
				return true;
			}
			catch
			{
				value = default(T);
				return false;
			}
		}

		public static T FromJson<T>(string json)
		{
			return FromJson<T>(json, null);
		}

		[CustomObfuscation(rename = false)]
		internal static T FromJson<T>(string json, Type preferredAnonymousObjectType)
		{
			if (string.IsNullOrEmpty(json))
			{
				return default(T);
			}
			drNTNhoRPgnQDjVmGDJEvgXvRSn.Length = 0;
			for (int i = 0; i < json.Length; i++)
			{
				char c = json[i];
				if (c == '"')
				{
					i = QkSTJdCDQaoEpUScvvjJTddkYis(true, i, json);
				}
				else if (!char.IsWhiteSpace(c))
				{
					drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(c);
				}
			}
			bool flag;
			return (T)yuZblmXMGWarnAAHsTCdgXVkZeRV(typeof(T), drNTNhoRPgnQDjVmGDJEvgXvRSn.ToString(), preferredAnonymousObjectType, out flag);
		}

		public static object FromJson(Type type, string json)
		{
			return FromJson(type, json, null);
		}

		[CustomObfuscation(rename = false)]
		internal static object FromJson(Type type, string json, Type preferredAnonymousObjectType)
		{
			if (string.IsNullOrEmpty(json))
			{
				return null;
			}
			drNTNhoRPgnQDjVmGDJEvgXvRSn.Length = 0;
			for (int i = 0; i < json.Length; i++)
			{
				char c = json[i];
				if (c == '"')
				{
					i = QkSTJdCDQaoEpUScvvjJTddkYis(true, i, json);
				}
				else if (!char.IsWhiteSpace(c))
				{
					drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(c);
				}
			}
			bool flag;
			return yuZblmXMGWarnAAHsTCdgXVkZeRV(type, drNTNhoRPgnQDjVmGDJEvgXvRSn.ToString(), preferredAnonymousObjectType, out flag);
		}

		private static object yuZblmXMGWarnAAHsTCdgXVkZeRV(Type P_0, string P_1, Type P_2, out bool P_3)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_3 = false;
				return null;
			}
			if (object.ReferenceEquals(P_0, typeof(string)))
			{
				if (P_1.Length <= 2)
				{
					P_3 = false;
					return string.Empty;
				}
				string text = P_1.Substring(1, P_1.Length - 2);
				P_3 = true;
				return text.Replace("\\", string.Empty);
			}
			if (object.ReferenceEquals(P_0, typeof(int)))
			{
				P_3 = int.TryParse(P_1, out var result);
				return result;
			}
			if (object.ReferenceEquals(P_0, typeof(float)))
			{
				P_3 = float.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out var result2);
				return result2;
			}
			if (object.ReferenceEquals(P_0, typeof(double)))
			{
				P_3 = double.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out var result3);
				return result3;
			}
			if (object.ReferenceEquals(P_0, typeof(bool)))
			{
				if (string.Equals(P_1, "true", StringComparison.OrdinalIgnoreCase))
				{
					P_3 = true;
					return true;
				}
				if (string.Equals(P_1, "false", StringComparison.OrdinalIgnoreCase))
				{
					P_3 = true;
					return false;
				}
				P_3 = false;
				return false;
			}
			if (object.ReferenceEquals(P_0, typeof(Guid)))
			{
				try
				{
					bool flag;
					string g = (string)yuZblmXMGWarnAAHsTCdgXVkZeRV(typeof(string), P_1, P_2, out flag);
					if (!flag)
					{
						P_3 = false;
						return Guid.Empty;
					}
					P_3 = true;
					return new Guid(g);
				}
				catch
				{
					P_3 = false;
					return Guid.Empty;
				}
			}
			if (ReflectionTools.IsEnum(P_0))
			{
				Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(P_0);
				object obj2 = yuZblmXMGWarnAAHsTCdgXVkZeRV(underlyingEnumType, P_1, P_2, out var flag2);
				if (flag2 && obj2 != null && ReflectionTools.IsValueType(obj2.GetType()))
				{
					P_3 = true;
					return Enum.ToObject(P_0, obj2);
				}
				try
				{
					obj2 = yuZblmXMGWarnAAHsTCdgXVkZeRV(typeof(string), P_1, P_2, out flag2);
					if (flag2 && !string.IsNullOrEmpty((string)obj2))
					{
						obj2 = Enum.Parse(P_0, (string)obj2, ignoreCase: true);
						if (obj2 != null)
						{
							P_3 = true;
							return obj2;
						}
					}
				}
				catch
				{
				}
			}
			if (P_1 == "null")
			{
				P_3 = true;
				return null;
			}
			if ((object)P_2 != null && ReflectionTools.DoesTypeImplement(P_2, P_0))
			{
				return vmiEIklUlBNSMdnOFdzxZGSlFTK(P_1, P_2, out P_3);
			}
			if (ReflectionTools.IsArray(P_0))
			{
				Type elementType = P_0.GetElementType();
				if (P_1[0] != '[' || P_1[P_1.Length - 1] != ']')
				{
					P_3 = false;
					return null;
				}
				List<string> list = tbMXtPZGPnwZeQqIJZKGnAICGml(P_1);
				Array array = Array.CreateInstance(elementType, list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					array.SetValue(yuZblmXMGWarnAAHsTCdgXVkZeRV(elementType, list[i], P_2, out var _), i);
				}
				splitArrayPool.Push(list);
				P_3 = true;
				return array;
			}
			bool flag4 = ReflectionTools.IsGenericType(P_0);
			if (flag4 && (object)P_0.GetGenericTypeDefinition() == typeof(List<>))
			{
				Type type = ReflectionTools.GetGenericArguments(P_0)[0];
				if (P_1[0] != '[' || P_1[P_1.Length - 1] != ']')
				{
					P_3 = false;
					return null;
				}
				IList list2 = (IList)Factory.CreateInstance(typeof(List<>).MakeGenericType(type));
				List<string> list3 = tbMXtPZGPnwZeQqIJZKGnAICGml(P_1);
				for (int j = 0; j < list3.Count; j++)
				{
					list2.Add(yuZblmXMGWarnAAHsTCdgXVkZeRV(type, list3[j], P_2, out var _));
				}
				splitArrayPool.Push(list3);
				P_3 = true;
				return list2;
			}
			if (flag4 && (object)P_0.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				Type[] genericArguments = ReflectionTools.GetGenericArguments(P_0);
				Type type2 = genericArguments[0];
				Type type3 = genericArguments[1];
				if ((object)type2 != typeof(string))
				{
					P_3 = false;
					return null;
				}
				if (P_1[0] != '{' || P_1[P_1.Length - 1] != '}')
				{
					P_3 = false;
					return null;
				}
				List<string> list4 = tbMXtPZGPnwZeQqIJZKGnAICGml(P_1);
				try
				{
					if (list4.Count % 2 != 0)
					{
						P_3 = false;
						return null;
					}
					IDictionary dictionary = (IDictionary)Factory.CreateInstance(typeof(Dictionary<, >).MakeGenericType(type2, type3));
					for (int k = 0; k < list4.Count; k += 2)
					{
						if (list4[k].Length > 2)
						{
							string key = list4[k].Substring(1, list4[k].Length - 2);
							bool flag6;
							object value = yuZblmXMGWarnAAHsTCdgXVkZeRV(type3, list4[k + 1], P_2, out flag6);
							dictionary.Add(key, value);
						}
					}
					P_3 = true;
					return dictionary;
				}
				finally
				{
					if (list4 != null)
					{
						splitArrayPool.Push(list4);
					}
				}
			}
			if (object.ReferenceEquals(P_0, typeof(object)))
			{
				return vmiEIklUlBNSMdnOFdzxZGSlFTK(P_1, P_2, out P_3);
			}
			if (P_1[0] == '{' && P_1[P_1.Length - 1] == '}')
			{
				P_3 = true;
				return iuihhRNVQyFnTvUDheuNHbCFFKn(P_0, P_1, P_2);
			}
			P_3 = false;
			return null;
		}

		private static object vmiEIklUlBNSMdnOFdzxZGSlFTK(string P_0, Type P_1, out bool P_2)
		{
			if (P_0.Length == 0)
			{
				P_2 = false;
				return null;
			}
			if (P_0[0] == '{' && P_0[P_0.Length - 1] == '}')
			{
				List<string> list = tbMXtPZGPnwZeQqIJZKGnAICGml(P_0);
				try
				{
					if (list.Count % 2 != 0)
					{
						P_2 = false;
						return null;
					}
					if ((object)P_1 != null && ReflectionTools.DoesTypeImplement(P_1, typeof(IAddKeyValue<string, object>)))
					{
						IAddKeyValue<string, object> addKeyValue = (IAddKeyValue<string, object>)Factory.CreateInstance(P_1, new object[1] { list.Count / 2 });
						for (int i = 0; i < list.Count; i += 2)
						{
							addKeyValue.Add(list[i].Substring(1, list[i].Length - 2), vmiEIklUlBNSMdnOFdzxZGSlFTK(list[i + 1], P_1, out var _));
						}
						P_2 = true;
						return addKeyValue;
					}
					Dictionary<string, object> dictionary = new Dictionary<string, object>(list.Count / 2);
					for (int j = 0; j < list.Count; j += 2)
					{
						dictionary.Add(list[j].Substring(1, list[j].Length - 2), vmiEIklUlBNSMdnOFdzxZGSlFTK(list[j + 1], P_1, out var _));
					}
					P_2 = true;
					return dictionary;
				}
				finally
				{
					if (list != null)
					{
						splitArrayPool.Push(list);
					}
				}
			}
			if (P_0[0] == '[' && P_0[P_0.Length - 1] == ']')
			{
				List<string> list2 = tbMXtPZGPnwZeQqIJZKGnAICGml(P_0);
				try
				{
					if ((object)P_1 != null && ReflectionTools.DoesTypeImplement(P_1, typeof(IAddValue<object>)))
					{
						IAddValue<object> addValue = (IAddValue<object>)Factory.CreateInstance(P_1, new object[1] { list2.Count });
						for (int k = 0; k < list2.Count; k++)
						{
							addValue.Add(vmiEIklUlBNSMdnOFdzxZGSlFTK(list2[k], P_1, out var _));
						}
						P_2 = true;
						return addValue;
					}
					List<object> list3 = new List<object>(list2.Count);
					for (int l = 0; l < list2.Count; l++)
					{
						list3.Add(vmiEIklUlBNSMdnOFdzxZGSlFTK(list2[l], P_1, out var _));
					}
					P_2 = true;
					return list3;
				}
				finally
				{
					if (list2 != null)
					{
						splitArrayPool.Push(list2);
					}
				}
			}
			if (P_0[0] == '"' && P_0[P_0.Length - 1] == '"')
			{
				string text = P_0.Substring(1, P_0.Length - 2);
				P_2 = true;
				return text.Replace("\\", string.Empty);
			}
			if (char.IsDigit(P_0[0]) || P_0[0] == '-')
			{
				if (P_0.Contains("."))
				{
					P_2 = double.TryParse(P_0, NumberStyles.Any, CultureInfo.InvariantCulture, out var result);
					return result;
				}
				P_2 = int.TryParse(P_0, out var result2);
				return result2;
			}
			if (P_0 == "true")
			{
				P_2 = true;
				return true;
			}
			if (P_0 == "false")
			{
				P_2 = true;
				return false;
			}
			P_2 = true;
			return null;
		}

		private static object iuihhRNVQyFnTvUDheuNHbCFFKn(Type P_0, string P_1, Type P_2)
		{
			object obj = Factory.CreateInstance(P_0);
			List<string> list = tbMXtPZGPnwZeQqIJZKGnAICGml(P_1);
			try
			{
				if (list.Count % 2 != 0)
				{
					return obj;
				}
				if (!aRhsUGFchKOGdQlvGBuxyIzMqJp.TryGetValue(P_0, out var value))
				{
					value = (from fieldInfo in ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
						where (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) || fieldInfo.IsDefined(typeof(SerializeField), inherit: true)) && !fieldInfo.IsDefined(typeof(NonSerializedAttribute), inherit: true) && !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
						select fieldInfo).ToDictionary((FieldInfo fieldInfo) =>
					{
						string name;
						return (fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name : fieldInfo.Name;
					});
					aRhsUGFchKOGdQlvGBuxyIzMqJp.Add(P_0, value);
				}
				if (!QcceECBWCowbJVMdAPhVIKTZCOuL.TryGetValue(P_0, out var value2))
				{
					value2 = (from propertyInfo in ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
						where propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
						select propertyInfo).ToDictionary((PropertyInfo propertyInfo) =>
					{
						string name;
						return (propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name : propertyInfo.Name;
					});
					QcceECBWCowbJVMdAPhVIKTZCOuL.Add(P_0, value2);
				}
				for (int num = 0; num < list.Count; num += 2)
				{
					if (list[num].Length > 2)
					{
						string key = list[num].Substring(1, list[num].Length - 2);
						string text = list[num + 1];
						PropertyInfo value4;
						if (value.TryGetValue(key, out var value3))
						{
							value3.SetValue(obj, yuZblmXMGWarnAAHsTCdgXVkZeRV(value3.FieldType, text, P_2, out var _));
						}
						else if (value2.TryGetValue(key, out value4) && value4.CanWrite)
						{
							value4.SetValue(obj, yuZblmXMGWarnAAHsTCdgXVkZeRV(value4.PropertyType, text, P_2, out var _), null);
						}
					}
				}
				if (obj is ISerializationCallbackReceiver serializationCallbackReceiver)
				{
					try
					{
						serializationCallbackReceiver.OnAfterDeserialize();
					}
					catch (Exception ex)
					{
						Logger.LogError(ex.ToString(), requiredThreadSafety: true);
					}
				}
				return obj;
			}
			finally
			{
				if (list != null)
				{
					splitArrayPool.Push(list);
				}
			}
		}

		private static int QkSTJdCDQaoEpUScvvjJTddkYis(bool P_0, int P_1, string P_2)
		{
			drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(P_2[P_1]);
			for (int i = P_1 + 1; i < P_2.Length; i++)
			{
				if (P_2[i] == '\\')
				{
					if (P_0)
					{
						drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(P_2[i]);
					}
					drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(P_2[i + 1]);
					i++;
				}
				else
				{
					if (P_2[i] == '"')
					{
						drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(P_2[i]);
						return i;
					}
					drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(P_2[i]);
				}
			}
			return P_2.Length - 1;
		}

		private static List<string> tbMXtPZGPnwZeQqIJZKGnAICGml(string P_0)
		{
			List<string> list = ((splitArrayPool.Count > 0) ? splitArrayPool.Pop() : new List<string>());
			list.Clear();
			int num = 0;
			drNTNhoRPgnQDjVmGDJEvgXvRSn.Length = 0;
			for (int i = 1; i < P_0.Length - 1; i++)
			{
				switch (P_0[i])
				{
				case '[':
				case '{':
					num++;
					break;
				case ']':
				case '}':
					num--;
					break;
				case '"':
					i = QkSTJdCDQaoEpUScvvjJTddkYis(true, i, P_0);
					continue;
				case ',':
				case ':':
					if (num == 0)
					{
						list.Add(drNTNhoRPgnQDjVmGDJEvgXvRSn.ToString());
						drNTNhoRPgnQDjVmGDJEvgXvRSn.Length = 0;
						continue;
					}
					break;
				}
				drNTNhoRPgnQDjVmGDJEvgXvRSn.Append(P_0[i]);
			}
			if (drNTNhoRPgnQDjVmGDJEvgXvRSn.Length == 0)
			{
				return list;
			}
			list.Add(drNTNhoRPgnQDjVmGDJEvgXvRSn.ToString());
			return list;
		}

		[CompilerGenerated]
		private static bool HuuvDyEZDxTDcgAwebzNPiLQaDhD(FieldInfo P_0)
		{
			if ((P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), inherit: true) || P_0.IsDefined(typeof(SerializeField), inherit: true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string bCXwNohcFibsGYLESaPQBxsOIsOm(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool BxycMUCPnnLLZPgLPdVYXpgpLqLp(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string BvvlVuyYHBUaGuEXRUYQPXFhHib(PropertyInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}
	}
}
