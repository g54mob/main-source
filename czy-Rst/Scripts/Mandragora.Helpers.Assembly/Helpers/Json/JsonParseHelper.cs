using System;
using System.Globalization;
using UnityEngine;

namespace Helpers.Json
{
	public static class JsonParseHelper
	{
		private const string errorMessage = "JsonToDateTime can't parse value";

		public static string DateTimeToJson(DateTime aDateTime)
		{
			return $"{aDateTime.Year:0000}-{aDateTime.Month:00}-{aDateTime.Day:00} {aDateTime.Hour:00}:{aDateTime.Minute:00}:{aDateTime.Second:00}";
		}

		public static DateTime JsonToDateTime(string aJson)
		{
			DateTime result = default(DateTime);
			if (string.IsNullOrEmpty(aJson) || aJson == "-1")
			{
				return result;
			}
			aJson = RemoveContainers(aJson);
			string[] array = aJson.Split(' ');
			if (array == null || array.Length < 2)
			{
				Debug.LogErrorFormat("Unity: {0}: {1}", "JsonToDateTime can't parse value", "Unknown DateTime format");
				return result;
			}
			string[] array2 = array[0].Split('-');
			if (array2 == null || array2.Length < 3)
			{
				Debug.LogErrorFormat("Unity: {0}: {1}", "JsonToDateTime can't parse value", "Unknown YY-MM-DD format");
				return result;
			}
			string[] array3 = array[1].Split(':');
			if (array3 == null || array3.Length < 3)
			{
				Debug.LogErrorFormat("Unity: {0}: {1}", "JsonToDateTime can't parse value", "Unknown HH:MM:SS format");
				return result;
			}
			int result2 = 0;
			if (int.TryParse(array2[0], out result2))
			{
				result = result.AddYears(result2 - 1);
			}
			if (int.TryParse(array2[1], out result2))
			{
				result = result.AddMonths(result2 - 1);
			}
			if (int.TryParse(array2[2], out result2))
			{
				result = result.AddDays(result2 - 1);
			}
			return result.AddHours(JsonToFloat(array3[0])).AddMinutes(JsonToFloat(array3[1])).AddSeconds(JsonToFloat(array3[2]));
		}

		public static string Vector3ToJson(Vector3 aVector3)
		{
			return $"{FloatToJson(aVector3.x)},{FloatToJson(aVector3.y)},{FloatToJson(aVector3.z)}";
		}

		public static Vector3 JsonToVector3(string aJson)
		{
			if (aJson == null)
			{
				throw new NullReferenceException("JsonToVector3 has null parameter");
			}
			aJson = RemoveContainers(aJson);
			string[] array = aJson.Split(',');
			if (array.Length < 3)
			{
				Debug.LogWarningFormat("Can't Parse string \"{0}\" to Vector3", aJson);
				return Vector3.zero;
			}
			return new Vector3(JsonToFloat(array[0]), JsonToFloat(array[1]), JsonToFloat(array[2]));
		}

		public static float JsonToFloat(string aJson)
		{
			if (aJson == null)
			{
				throw new NullReferenceException("JsonToFloat has null parameter");
			}
			float num = 0f;
			try
			{
				return float.Parse(aJson, CultureInfo.InvariantCulture);
			}
			catch (OverflowException)
			{
				return 0f;
			}
		}

		public static string FloatToJson(float aValue)
		{
			return aValue.ToString(CultureInfo.InvariantCulture);
		}

		public static string RemoveContainers(string aTarget)
		{
			if (aTarget.StartsWith("(") && aTarget.EndsWith(")"))
			{
				aTarget = aTarget.Substring(1, aTarget.Length - 2);
			}
			if (aTarget.StartsWith("[") && aTarget.EndsWith("]"))
			{
				aTarget = aTarget.Substring(1, aTarget.Length - 2);
			}
			if (aTarget.StartsWith("\\") && aTarget.EndsWith("\\"))
			{
				aTarget = aTarget.Substring(1, aTarget.Length - 2);
			}
			if (aTarget.StartsWith("/") && aTarget.EndsWith("/"))
			{
				aTarget = aTarget.Substring(1, aTarget.Length - 2);
			}
			if (aTarget.StartsWith("\"") && aTarget.EndsWith("\""))
			{
				aTarget = aTarget.Substring(1, aTarget.Length - 2);
			}
			return aTarget;
		}
	}
}
