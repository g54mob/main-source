using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace NSEipix.ObjectMapper
{
	public static class JsonPreprocessors
	{
		public static string StringAsEnum(string json, Type objType)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return json;
			}
			Dictionary<string, Type> dictionary = FindEnumFields(objType);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(55, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonPreprocessors.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Preprocessing json for type ");
				messageBuilder.AppendFormatted(objType.GenericTypeArguments?.FirstOrDefault()?.Name ?? objType.Name);
				messageBuilder.AppendLiteral(", field path to enum type: ");
				messageBuilder.AppendFormatted(dictionary.ToPrettyString());
			}
			Log.Trace(messageBuilder);
			if (dictionary.Count == 0)
			{
				Log.Trace("No enums in this type, nothing to do here", "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonPreprocessors.cs");
				return json;
			}
			return ConvertEnumStringsToInts(json, dictionary);
		}

		private static Dictionary<string, Type> FindEnumFields(Type objType)
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			Stack<(Type, string)> stack = new Stack<(Type, string)>();
			stack.Push((objType, ""));
			while (stack.Count > 0)
			{
				var (type, text) = stack.Pop();
				foreach (FieldInfo item in (IEnumerable<FieldInfo>)GetAllFieldsFlattenHierarchy(type))
				{
					string text2 = (string.IsNullOrEmpty(text) ? item.Name : (text + "/" + item.Name));
					if (item.FieldType.IsArray || (item.FieldType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(item.FieldType)))
					{
						Type type2 = ((!item.FieldType.IsArray) ? item.FieldType.GetGenericArguments()[0] : item.FieldType.GetElementType());
						if (type2.IsEnum)
						{
							dictionary[text2] = type2;
						}
						else if (type2.IsClass && type2 != typeof(string))
						{
							stack.Push((type2, text2));
						}
					}
					else if (item.FieldType.IsClass && item.FieldType != typeof(string))
					{
						stack.Push((item.FieldType, text2));
					}
					else if (item.FieldType.IsEnum)
					{
						dictionary[text2] = item.FieldType;
					}
				}
			}
			return dictionary;
		}

		private static List<FieldInfo> GetAllFieldsFlattenHierarchy(Type type)
		{
			List<FieldInfo> list = new List<FieldInfo>();
			Type type2 = type;
			int num = 0;
			while (type2 != null && type2 != typeof(object))
			{
				num++;
				if (num > 1000)
				{
					throw new Exception("Infinite loop happened during JSON preprocessing, something is very wrong here");
				}
				list.AddRange(from field in type2.GetRuntimeFields()
					where field.GetCustomAttribute<SerializeField>() != null || field.IsPublic
					select field);
				type2 = type2.BaseType;
			}
			return list;
		}

		private static string ConvertEnumStringsToInts(string json, Dictionary<string, Type> fieldPathToEnumType)
		{
			JObject jObject = JObject.Parse(json);
			Stack<(JToken, string)> stack = new Stack<(JToken, string)>();
			stack.Push((jObject, ""));
			List<(JToken, JToken)> list = new List<(JToken, JToken)>();
			while (stack.Count > 0)
			{
				var (jToken, text) = stack.Pop();
				if (!(jToken is JObject jObject2))
				{
					continue;
				}
				foreach (JProperty item5 in jObject2.Properties())
				{
					string text2 = (string.IsNullOrEmpty(text) ? item5.Name : (text + "/" + item5.Name));
					if (fieldPathToEnumType.TryGetValue(text2, out var value) && item5.Value.Type == JTokenType.String)
					{
						string text3 = item5.Value.ToString();
						if (int.TryParse(text3, out var result))
						{
							list.Add((item5, new JProperty(item5.Name, result)));
							continue;
						}
						Dictionary<string, int> enumInfo = GetEnumInfo(value);
						if (!enumInfo.TryGetValue(text3, out var value2))
						{
							throw new Exception("Incorrect enum value '" + text3 + "' for enum " + value.Name + ". Supported values are: " + enumInfo.Keys.ToList().ToPrettyString());
						}
						list.Add((item5, new JProperty(item5.Name, value2)));
					}
					else if (item5.Value is JObject item)
					{
						stack.Push((item, text2));
					}
					else
					{
						if (!(item5.Value is JArray jArray))
						{
							continue;
						}
						foreach (JToken item6 in jArray)
						{
							if (!(item6 is JObject item2))
							{
								if (!(item6 is JValue jValue) || !fieldPathToEnumType.TryGetValue(text2, out value) || jValue.Type != JTokenType.String)
								{
									continue;
								}
								string text4 = jValue.ToString(CultureInfo.InvariantCulture);
								if (int.TryParse(text4, out var result2))
								{
									list.Add((jValue, new JValue(result2)));
									continue;
								}
								Dictionary<string, int> enumInfo2 = GetEnumInfo(value);
								if (!enumInfo2.TryGetValue(text4, out var value3))
								{
									throw new Exception("Incorrect enum value '" + text4 + "' for enum " + value.Name + ". Supported values are: " + enumInfo2.Keys.ToList().ToPrettyString());
								}
								list.Add((jValue, new JValue(value3)));
							}
							else
							{
								stack.Push((item2, text2));
							}
						}
					}
				}
			}
			if (list.Count == 0)
			{
				Log.Trace("Found no properties to replace, returning original json", "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonPreprocessors.cs");
				return json;
			}
			foreach (var item7 in list)
			{
				JToken item3 = item7.Item1;
				JToken item4 = item7.Item2;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(4, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(item3);
					messageBuilder.AppendLiteral(" -> ");
					messageBuilder.AppendFormatted(item4);
				}
				Log.Trace(messageBuilder);
				item3.Replace(item4);
			}
			return jObject.ToString(Formatting.None);
		}

		private static Dictionary<string, int> GetEnumInfo(Type enumType)
		{
			if (!enumType.IsEnum)
			{
				return null;
			}
			string[] names = Enum.GetNames(enumType);
			int[] array = Enum.GetValues(enumType).Cast<int>().ToArray();
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			for (int i = 0; i < names.Length; i++)
			{
				dictionary[names[i]] = array[i];
			}
			return dictionary;
		}
	}
}
