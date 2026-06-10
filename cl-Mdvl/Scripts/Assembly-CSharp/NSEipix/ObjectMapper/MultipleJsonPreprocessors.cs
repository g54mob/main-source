using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NSEipix.ObjectMapper
{
	public static class MultipleJsonPreprocessors
	{
		private const string RepositoryFieldName = "repository";

		private const string ArrayAppendSuffix = "#APPEND";

		private const string ArrayRemoveSuffix = "#REMOVE";

		public static string GetMultipleJsonsMerged(List<string> filePaths)
		{
			if (filePaths == null || filePaths.Count <= 0)
			{
				Log.Error("Something went wrong. File paths list is null or empty", "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				return string.Empty;
			}
			JObject jObject = new JObject();
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(11, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Processing ");
				messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(string.Join(',', filePaths)));
			}
			Log.Debug(messageBuilder);
			for (int i = 0; i < filePaths.Count; i++)
			{
				string text = FileReaders.Get.ReadFile(filePaths[i]);
				if (string.IsNullOrEmpty(text))
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("File ");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePaths[i]));
						messageBuilder2.AppendLiteral(" could not be found");
					}
					Log.Error(messageBuilder2);
				}
				else if (i == 0)
				{
					jObject = JObject.Parse(text);
				}
				else
				{
					ProcessObject(JObject.Parse(text), jObject);
				}
			}
			messageBuilder = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Finished processing ");
				messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(string.Join(',', filePaths)));
			}
			Log.Debug(messageBuilder);
			return jObject.ToString(Formatting.None);
		}

		private static void ProcessObject(JObject jObject, JObject targetObject)
		{
			foreach (JProperty item in jObject.Properties())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(23, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("jProperty: ");
					messageBuilder.AppendFormatted(item.Name);
					messageBuilder.AppendLiteral(" jProperty: ");
					messageBuilder.AppendFormatted(item.Value);
				}
				Log.Trace(messageBuilder);
				if (item.Value is JArray jArray)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(item.Name);
						messageBuilder.AppendLiteral(" Array found: ");
						messageBuilder.AppendFormatted(jArray.Count);
						messageBuilder.AppendLiteral(" items");
					}
					Log.Trace(messageBuilder);
					ProcessArray(item, jArray, targetObject);
				}
				else if (item.Value is JObject jObject2)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Object ");
						messageBuilder.AppendFormatted(item.Name);
						messageBuilder.AppendLiteral(" found: ");
						messageBuilder.AppendFormatted(Enumerable.Count(jObject2.Properties()));
						messageBuilder.AppendLiteral(" properties");
					}
					Log.Trace(messageBuilder);
					JObject jObject3 = GetObject(item.Name, targetObject);
					if (jObject3 == null)
					{
						FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Object ");
							messageBuilder2.AppendFormatted(item.Name);
							messageBuilder2.AppendLiteral(" could not be found in ");
							messageBuilder2.AppendFormatted(targetObject);
						}
						Log.Warning(messageBuilder2);
					}
					else
					{
						ProcessObject(jObject2, jObject3);
					}
				}
				else
				{
					UpdatePropertyValue(item, targetObject);
				}
			}
		}

		private static void UpdatePropertyValue(JProperty property, JObject targetObject)
		{
			JProperty property2 = GetProperty(property.Name, targetObject);
			if (property2 == null)
			{
				targetObject.Add(property);
				return;
			}
			property2.Value = property.Value;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(4, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("[");
				messageBuilder.AppendFormatted(property.Type);
				messageBuilder.AppendLiteral("]");
				messageBuilder.AppendFormatted(property.Name);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(property.Value);
			}
			Log.Trace(messageBuilder);
		}

		private static void ProcessArray(JProperty jProperty, JArray jArray, JObject targetParentObject)
		{
			if (TryAppendRemove(jProperty, targetParentObject))
			{
				return;
			}
			if (jArray.First is JValue)
			{
				UpdatePropertyValue(jProperty, targetParentObject);
				return;
			}
			string name = jProperty.Name;
			JArray jArray2 = (JArray)targetParentObject.GetValue(name);
			if (jArray2 == null)
			{
				targetParentObject.Add(name, jArray);
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't find matching array with id:");
					messageBuilder.AppendFormatted(name);
					messageBuilder.AppendLiteral(", creating new");
				}
				Log.Trace(messageBuilder);
				return;
			}
			foreach (JToken item in jArray)
			{
				string newElementId = GetId(item);
				JToken jToken = jArray2.Children().FirstOrDefault((JToken jt) => GetId(jt).Equals(newElementId));
				if (jToken == null)
				{
					jArray2.Add(item);
				}
				else if (item is JObject jObject && jToken is JObject targetObject)
				{
					ProcessObject(jObject, targetObject);
				}
			}
		}

		private static bool TryAppendRemove(JProperty property, JObject targetModel)
		{
			if (property.Name.Contains("#APPEND"))
			{
				return HandleArrayAppend(property, targetModel);
			}
			if (property.Name.Contains("#REMOVE"))
			{
				return HandleArrayRemove(property, targetModel);
			}
			return false;
		}

		private static bool HandleArrayAppend(JProperty property, JObject targetObject)
		{
			string text = property.Name.Replace("#APPEND", string.Empty);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("APPEND [");
				messageBuilder.AppendFormatted(property.Type);
				messageBuilder.AppendLiteral("]");
				messageBuilder.AppendFormatted(text);
			}
			Log.Trace(messageBuilder);
			if (!(property.Value is JArray jArray))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(property.Name);
					messageBuilder2.AppendLiteral(" in sourceModel is not an array. This is not allowed!");
				}
				Log.Error(messageBuilder2);
				return false;
			}
			if (!TryGetArrayFromObject(text, targetObject, out var outArray))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(text);
					messageBuilder2.AppendLiteral(" in targetModel is not an array. This is not allowed!");
				}
				Log.Error(messageBuilder2);
				return false;
			}
			foreach (JToken token in jArray)
			{
				if (!outArray.Any((JToken tkn) => TokenEquals(tkn, token)))
				{
					outArray.Add(token);
				}
			}
			return true;
		}

		private static bool HandleArrayRemove(JProperty property, JObject targetModel)
		{
			string text = property.Name.Replace("#REMOVE", string.Empty);
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Remove from [");
				messageBuilder.AppendFormatted(property.Type);
				messageBuilder.AppendLiteral("]");
				messageBuilder.AppendFormatted(text);
			}
			Log.Trace(messageBuilder);
			if (!(property.Value is JArray jArray))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(property.Name);
					messageBuilder2.AppendLiteral(" in sourceModel is not an array. This is not allowed!");
				}
				Log.Error(messageBuilder2);
				return false;
			}
			if (!TryGetArrayFromObject(text, targetModel, out var outArray))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(text);
					messageBuilder2.AppendLiteral(" in targetModel is not an array. This is not allowed!");
				}
				Log.Error(messageBuilder2);
				return false;
			}
			List<JToken> list = new List<JToken>();
			foreach (JToken item in jArray)
			{
				foreach (JToken item2 in outArray)
				{
					if (TokenEquals(item2, item))
					{
						list.Add(item2);
					}
				}
			}
			foreach (JToken item3 in list)
			{
				outArray.Remove(item3);
				messageBuilder = new FVLogTraceInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral(" Removed [");
					messageBuilder.AppendFormatted(item3);
					messageBuilder.AppendLiteral("] from target array [");
					messageBuilder.AppendFormatted(outArray.Count);
					messageBuilder.AppendLiteral("] items left");
				}
				Log.Trace(messageBuilder);
			}
			return true;
		}

		private static bool TokenEquals(JToken tokenA, JToken tokenB)
		{
			if (tokenA is JValue jValue && tokenB is JValue other)
			{
				return jValue.Equals(other);
			}
			if (!(tokenA is JObject jObject))
			{
				return false;
			}
			if (!(tokenB is JObject jObject2))
			{
				return false;
			}
			JProperty[] array = jObject.Properties().ToArray();
			JProperty[] array2 = jObject2.Properties().ToArray();
			if (Enumerable.Count(array) != Enumerable.Count(array2))
			{
				return false;
			}
			for (int i = 0; i < Enumerable.Count(array); i++)
			{
				if (array[i].Value is JArray jArray)
				{
					JToken value = array2[i].Value;
					JArray jArrayB = value as JArray;
					if (jArrayB != null)
					{
						if (jArray.Count != jArrayB.Count)
						{
							return false;
						}
						return !jArray.Where((JToken t, int a) => !TokenEquals(t, jArrayB[a])).Any();
					}
				}
				if (!array[i].Name.Equals(array2[i].Name))
				{
					return false;
				}
				if (!array[i].Type.Equals(array2[i].Type))
				{
					return false;
				}
				if (!array[i].Value.Equals(array2[i].Value))
				{
					return false;
				}
			}
			return true;
		}

		private static JObject GetObject(string propertyId, JObject parentObject)
		{
			foreach (JProperty item in parentObject.Properties())
			{
				if (item.Name.Equals(propertyId))
				{
					if (item.Value is JObject result)
					{
						return result;
					}
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Property ");
						messageBuilder.AppendFormatted(item.Name);
						messageBuilder.AppendLiteral(" exists but it's not a JObject");
					}
					Log.Warning(messageBuilder);
				}
			}
			return null;
		}

		private static JProperty GetProperty(string propertyId, JObject modelObject)
		{
			foreach (JProperty item in modelObject.Properties())
			{
				if (item.Name.Equals(propertyId))
				{
					return item;
				}
			}
			return null;
		}

		private static bool TryGetArrayFromObject(string arrayId, JObject jsonObject, out JArray outArray)
		{
			outArray = null;
			if (!(jsonObject.GetValue(arrayId) is JArray jArray))
			{
				return false;
			}
			outArray = jArray;
			return true;
		}

		private static string GetId(JToken jToken)
		{
			bool isEnabled;
			if (!(jToken is JObject jObject))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("JToken ");
					messageBuilder.AppendFormatted(jToken.Type);
					messageBuilder.AppendLiteral(" is not JObject");
				}
				Log.Error(messageBuilder);
				return string.Empty;
			}
			JProperty jProperty = jObject.Property("id");
			if (jProperty != null)
			{
				return jProperty.Value.ToString();
			}
			if (!(jToken.First is JProperty jProperty2))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\MultipleJsonPreprocessors.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("JToken ");
					messageBuilder.AppendFormatted(jToken.First.Type);
					messageBuilder.AppendLiteral(" is not JProperty");
				}
				Log.Error(messageBuilder);
				return string.Empty;
			}
			return jProperty2.Value.ToString();
		}
	}
}
