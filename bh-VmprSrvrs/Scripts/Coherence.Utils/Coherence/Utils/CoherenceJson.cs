using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Coherence.Utils
{
	internal static class CoherenceJson
	{
		public static string SerializeObject(object? value)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string SerializeObject(object? value, Formatting formatting)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string SerializeObject(object? value, params JsonConverter[]? converters)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string SerializeObject(object? value, Formatting formatting, params JsonConverter[]? converters)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string? SerializeObject(object? value, JsonSerializerSettings? settings)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string? SerializeObject(object? value, Type? type, JsonSerializerSettings? settings)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string? SerializeObject(object? value, Formatting formatting, JsonSerializerSettings? settings)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static string? SerializeObject(object? value, Type? type, Formatting formatting, JsonSerializerSettings? settings)
		{
			return null;
		}

		private static string SerializeObjectInternal(object? value, Type? type, JsonSerializer jsonSerializer)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static object DeserializeObject(string value)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static object DeserializeObject(string value, JsonSerializerSettings settings)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type)
		{
			return null;
		}

		[DebuggerStepThrough]
		public static T? DeserializeObject<T>(string value)
		{
			return default(T);
		}

		[DebuggerStepThrough]
		public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject) where T : notnull
		{
			return default(T);
		}

		[DebuggerStepThrough]
		public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject, JsonSerializerSettings settings) where T : notnull
		{
			return default(T);
		}

		[DebuggerStepThrough]
		public static T DeserializeObject<T>(string value, params JsonConverter[] converters) where T : notnull
		{
			return default(T);
		}

		[DebuggerStepThrough]
		public static T? DeserializeObject<T>(string value, JsonSerializerSettings? settings)
		{
			return default(T);
		}

		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type, params JsonConverter[]? converters)
		{
			return null;
		}

		public static object? DeserializeObject(string value, Type? type, JsonSerializerSettings? settings)
		{
			return null;
		}
	}
}
