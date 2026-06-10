using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Tools;
using UnityEngine;

namespace NSEipix.ObjectMapper
{
	public class JsonSerializer<T> : ISerializer<T>
	{
		public class Builder
		{
			private string path;

			private List<string> paths;

			public Builder(string path)
			{
				this.path = path;
			}

			public Builder(List<string> paths)
			{
				this.paths = paths;
			}

			public JsonSerializer<T> Build()
			{
				return JsonSerializer<T>.Both(path);
			}

			public JsonSerializer<T> BuildMultiple()
			{
				return JsonSerializer<T>.Both(paths);
			}

			public JsonSerializer<T> BuildOverwrite(T objectToOverwrite)
			{
				return JsonSerializer<T>.BothOverwrite(path, objectToOverwrite);
			}

			public JsonSerializer<T> BuildWithoutSerializer()
			{
				return JsonSerializer<T>.OnlyDeserializator(path);
			}

			public JsonSerializer<T> BuildWithoutSerializerMultiple()
			{
				return JsonSerializer<T>.OnlyDeserializator(paths);
			}

			public JsonSerializer<T> BuildWithoutDeserializer()
			{
				return JsonSerializer<T>.OnlySerializator(path);
			}
		}

		private string path;

		private Action<T> serializerImpl;

		private Func<T> deserializerImpl;

		private readonly List<string> paths;

		private JsonSerializer(string path)
		{
			this.path = path;
			serializerImpl = SerializeImpl;
			deserializerImpl = DeserializeImpl;
		}

		private JsonSerializer(List<string> paths)
		{
			this.paths = paths;
			serializerImpl = SerializeImplMultiple;
			deserializerImpl = DeserializeImplMultiple;
		}

		private JsonSerializer(string path, T objectToOverwrite)
		{
			JsonSerializer<T> jsonSerializer = this;
			this.path = path;
			serializerImpl = SerializeImpl;
			deserializerImpl = () => jsonSerializer.DeserializeOverwrite(objectToOverwrite);
		}

		public void Serialize(T obj)
		{
			if (serializerImpl != null)
			{
				serializerImpl(obj);
			}
		}

		public T Deserialize()
		{
			if (deserializerImpl != null)
			{
				return deserializerImpl();
			}
			return default(T);
		}

		public T[] DeserializeDirectory(string path)
		{
			List<T> list = new List<T>();
			string[] files;
			bool isEnabled;
			try
			{
				files = Directory.GetFiles(path, "*.json");
			}
			catch (DirectoryNotFoundException)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonSerializer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Directory not found: ");
					messageBuilder.AppendFormatted(path);
				}
				Log.Warning(messageBuilder);
				return list.ToArray();
			}
			string[] array = files;
			foreach (string text in array)
			{
				string text2 = FileReaders.Get.ReadFile(text);
				try
				{
					if (!string.IsNullOrEmpty(text2))
					{
						text2 = JsonPreprocessors.StringAsEnum(text2, typeof(T));
						list.Add(JsonUtility.FromJson<T>(text2));
					}
				}
				catch (Exception ex2)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonSerializer.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Error \"");
						messageBuilder2.AppendFormatted(ex2.Message);
						messageBuilder2.AppendLiteral("\" in json: ");
						messageBuilder2.AppendFormatted(text);
					}
					Log.Error(messageBuilder2);
				}
			}
			return list.ToArray();
		}

		private static JsonSerializer<T> Both(string path)
		{
			return new JsonSerializer<T>(path);
		}

		private static JsonSerializer<T> Both(List<string> paths)
		{
			return new JsonSerializer<T>(paths);
		}

		private static JsonSerializer<T> BothOverwrite(string path, T objectToOverwrite)
		{
			return new JsonSerializer<T>(path, objectToOverwrite);
		}

		private static JsonSerializer<T> OnlySerializator(string path)
		{
			return new JsonSerializer<T>(path)
			{
				deserializerImpl = null
			};
		}

		private static JsonSerializer<T> OnlyDeserializator(string path)
		{
			return new JsonSerializer<T>(path)
			{
				serializerImpl = null
			};
		}

		private static JsonSerializer<T> OnlyDeserializator(List<string> paths)
		{
			return new JsonSerializer<T>(paths)
			{
				serializerImpl = null
			};
		}

		private void SerializeImpl(T obj)
		{
			string fullPathToCheck = Path.Combine(FileReaders.Get.GetPersistentDataPath(), path);
			FilePathUtils.CheckAndCreatePath(fullPathToCheck);
			string data = JsonUtility.ToJson(obj, Debug.isDebugBuild);
			FileUtils.SafeWriteAllText(fullPathToCheck, data);
		}

		private void SerializeImplMultiple(T obj)
		{
			string fullPathToCheck = Path.Combine(FileReaders.Get.GetStreamingAssetsPath(), paths.FirstOrDefault());
			FilePathUtils.CheckAndCreatePath(fullPathToCheck);
			string data = JsonUtility.ToJson(obj, Debug.isDebugBuild);
			FileUtils.SafeWriteAllText(fullPathToCheck, data);
		}

		private T DeserializeImpl()
		{
			string text = FileReaders.Get.ReadFile(path);
			if (string.IsNullOrEmpty(text))
			{
				throw new NullReferenceException("File not found: " + path);
			}
			return PreprocessJson(text);
		}

		private T DeserializeOverwrite(T objectToOverwrite)
		{
			string text = FileReaders.Get.ReadFile(path);
			if (string.IsNullOrEmpty(text))
			{
				throw new NullReferenceException("File not found: " + path);
			}
			return PreprocessJsonOverwrite(text, objectToOverwrite);
		}

		private T DeserializeImplMultiple()
		{
			if (paths.Count == 1)
			{
				string json = FileReaders.Get.ReadFile(paths.FirstOrDefault());
				return PreprocessJson(json);
			}
			return PreprocessMultipleJson(paths);
		}

		private T PreprocessMultipleJson(List<string> jsons)
		{
			try
			{
				string multipleJsonsMerged = MultipleJsonPreprocessors.GetMultipleJsonsMerged(jsons);
				return PreprocessJson(multipleJsonsMerged);
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(57, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonSerializer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error deserializing some of jsons of type \"");
					messageBuilder.AppendFormatted(Path.GetFileName(paths.FirstOrDefault()));
					messageBuilder.AppendLiteral("\"! Exception: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
				return default(T);
			}
		}

		private T PreprocessJson(string json)
		{
			try
			{
				json = JsonPreprocessors.StringAsEnum(json, typeof(T));
				return string.IsNullOrEmpty(json) ? default(T) : JsonUtility.FromJson<T>(json);
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(40, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonSerializer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error deserializing json \"");
					messageBuilder.AppendFormatted(Path.GetFileName(path));
					messageBuilder.AppendLiteral("\"! Exception: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
				return default(T);
			}
		}

		private T PreprocessJsonOverwrite(string json, T objectToOverwrite)
		{
			try
			{
				json = JsonPreprocessors.StringAsEnum(json, typeof(T));
				if (string.IsNullOrEmpty(json))
				{
					return default(T);
				}
				JsonUtility.FromJsonOverwrite(json, objectToOverwrite);
				return objectToOverwrite;
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\ObjectMapper\\JsonSerializer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error overwrite deserializing json \"");
					messageBuilder.AppendFormatted(Path.GetFileName(path));
					messageBuilder.AppendLiteral("\"! Exception: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
				return default(T);
			}
		}
	}
}
