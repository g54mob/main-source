using System;
using System.Collections.Generic;
using System.IO;
using MiniJSON;
using UnityEngine;

namespace PajamaLlama.JSON
{
	public static class JSONExtensions
	{
		public static bool TryReadJSON(string filePath, out Dictionary<string, object> output)
		{
			try
			{
				if (File.Exists(filePath))
				{
					output = Json.Deserialize(File.ReadAllText(filePath)) as Dictionary<string, object>;
					return output != null;
				}
				Debug.LogError("No file with path " + filePath);
			}
			catch (UnauthorizedAccessException message)
			{
				Debug.LogWarning(message);
			}
			output = null;
			return false;
		}

		public static bool TryReadJSON<T>(string filePath, out T output)
		{
			try
			{
				if (File.Exists(filePath))
				{
					output = JsonUtility.FromJson<T>(File.ReadAllText(filePath));
					return true;
				}
				Debug.LogError("No file with path " + filePath);
				output = default(T);
				return false;
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
				output = default(T);
				return false;
			}
		}

		public static bool TryReturnParameter<T>(Dictionary<string, object> parameters, string name, out T parameter)
		{
			if (parameters.TryGetValue(name, out var value) && value is T)
			{
				parameter = (T)value;
				return true;
			}
			parameter = default(T);
			return false;
		}
	}
}
