#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Utils
{
	public static class DebugUtils
	{
		private static readonly Color _threadingColour = new Color(1f, 1f, 1f, 0.4f);

		private static readonly Dictionary<int, StringBuilder> _stringBuilders = new Dictionary<int, StringBuilder>();

		private static string _objectName;

		private static string _typeName;

		private static StringBuilder GetOrCreateStringBuilder()
		{
			if (!_stringBuilders.TryGetValue(Thread.CurrentThread.ManagedThreadId, out var value))
			{
				value = new StringBuilder();
				lock (_stringBuilders)
				{
					_stringBuilders.Add(Thread.CurrentThread.ManagedThreadId, value);
				}
			}
			return value;
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void DevException<T>(this UnityEngine.Object pContext, T pException, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1) where T : Exception
		{
			pContext.LogAssertion(pException.Message, pMethodName, pLineNumber);
			UnityEngine.Debug.LogError(pException);
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void DevException<T>(this object pContext, T pException, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1) where T : Exception
		{
			pContext.LogAssertion(pException.Message, pMethodName, pLineNumber);
			UnityEngine.Debug.LogError(pException);
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void DevException<T>(this Type pContext, T pException, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1) where T : Exception
		{
			pContext.LogError(pException.Message, pMethodName, pLineNumber);
			UnityEngine.Debug.LogError(pException);
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void DevException(this UnityEngine.Object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogError(new InvalidOperationException(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext)), pContext);
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void DevException(this object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogError(new InvalidOperationException(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext.GetType())));
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void DevException(this Type pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogError(new InvalidOperationException(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext)));
		}

		[Conditional("ENABLE_DEBUG_LOGS")]
		[HideInCallstack]
		public static void LogBasic(string pMessage)
		{
			UnityEngine.Debug.Log(pMessage);
		}

		[Conditional("ENABLE_DEBUG_LOGS")]
		[HideInCallstack]
		public static void Log(this UnityEngine.Object pContext, string pMessage = "", [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.Log(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext), pContext);
		}

		[Conditional("ENABLE_DEBUG_LOGS")]
		[HideInCallstack]
		public static void Log(this object pContext, string pMessage = "", [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.Log(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext.GetType()));
		}

		[Conditional("ENABLE_DEBUG_LOGS")]
		[HideInCallstack]
		public static void Log(this Type pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.Log(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext));
		}

		[Conditional("ENABLE_DEBUG_WARNINGS")]
		[HideInCallstack]
		public static void LogWarning(this UnityEngine.Object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogWarning(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext), pContext);
		}

		[Conditional("ENABLE_DEBUG_WARNINGS")]
		[HideInCallstack]
		public static void LogWarning(this object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogWarning(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext.GetType()));
		}

		[Conditional("ENABLE_DEBUG_WARNINGS")]
		[HideInCallstack]
		public static void LogWarning(this Type pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogWarning(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext));
		}

		[Conditional("ENABLE_DEBUG_ERRORS")]
		[HideInCallstack]
		public static void LogError(this UnityEngine.Object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogError(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext), pContext);
		}

		[Conditional("ENABLE_DEBUG_ERRORS")]
		[HideInCallstack]
		public static void LogError(this object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogError(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext.GetType()));
		}

		[Conditional("ENABLE_DEBUG_ERRORS")]
		[HideInCallstack]
		public static void LogError(this Type pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
			UnityEngine.Debug.LogError(CreateLogMessage(pMessage, pMethodName, pLineNumber, pContext));
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void LogAssertion(this UnityEngine.Object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void LogAssertion(this object pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
		}

		[Conditional("ENABLE_DEBUG_EXCEPTIONS")]
		[HideInCallstack]
		public static void LogAssertion(this Type pContext, string pMessage, [CallerMemberName] string pMethodName = "", [CallerLineNumber] int pLineNumber = -1)
		{
		}

		public static string ToLogString<TValue>(this IEnumerable<TValue> pValues, string pMessage)
		{
			StringBuilder orCreateStringBuilder = GetOrCreateStringBuilder();
			orCreateStringBuilder.Clear();
			orCreateStringBuilder.Append(pMessage);
			orCreateStringBuilder.Append(" [");
			foreach (TValue pValue in pValues)
			{
				orCreateStringBuilder.Append(pValue);
				orCreateStringBuilder.Append(", ");
			}
			orCreateStringBuilder.Remove(orCreateStringBuilder.Length - 2, 2);
			orCreateStringBuilder.Append(']');
			return orCreateStringBuilder.ToString();
		}

		public static string ToLogString<TKey, TValue>(this Dictionary<TKey, TValue> pDictionary, string pMessage)
		{
			StringBuilder orCreateStringBuilder = GetOrCreateStringBuilder();
			orCreateStringBuilder.Clear();
			orCreateStringBuilder.Append(pMessage);
			orCreateStringBuilder.Append(" [");
			foreach (KeyValuePair<TKey, TValue> item in pDictionary)
			{
				orCreateStringBuilder.Append(item.Key);
				orCreateStringBuilder.Append(": ");
				orCreateStringBuilder.Append(item.Value);
				orCreateStringBuilder.Append(", ");
			}
			orCreateStringBuilder.Remove(orCreateStringBuilder.Length - 2, 2);
			orCreateStringBuilder.Append(']');
			return orCreateStringBuilder.ToString();
		}

		public static string ToLogString<TValue>(this TValue[,] pValues, string pMessage)
		{
			StringBuilder orCreateStringBuilder = GetOrCreateStringBuilder();
			orCreateStringBuilder.Clear();
			orCreateStringBuilder.Append(pMessage);
			orCreateStringBuilder.Append(" { ");
			int length = pValues.GetLength(0);
			int length2 = pValues.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				orCreateStringBuilder.Append("{ ");
				for (int j = 0; j < length2; j++)
				{
					if (j == length2 - 1)
					{
						orCreateStringBuilder.Append($"{pValues[i, j]}" + "}");
					}
					else
					{
						orCreateStringBuilder.Append($"{pValues[i, j]}, ");
					}
				}
				if (i < length - 1)
				{
					orCreateStringBuilder.Append(", ");
				}
			}
			orCreateStringBuilder.Append(" }");
			return orCreateStringBuilder.ToString();
		}

		public static string GetPath(Transform transform)
		{
			if (transform.parent == null)
			{
				return transform.name;
			}
			return transform.name + "/" + GetPath(transform.parent);
		}

		private static string CreateLogMessage(string pMessage, string pMethodName, int pLineNumber, UnityEngine.Object pContext)
		{
			StringBuilder orCreateStringBuilder = GetOrCreateStringBuilder();
			if (pContext == null)
			{
				orCreateStringBuilder.Clear();
				orCreateStringBuilder.Append("_::");
				orCreateStringBuilder.Append(pMethodName);
				orCreateStringBuilder.Append(':');
				orCreateStringBuilder.Append(pLineNumber);
				orCreateStringBuilder.Append(' ');
				orCreateStringBuilder.Append(pMessage);
				return orCreateStringBuilder.ToString();
			}
			_typeName = pContext.GetType().Name;
			orCreateStringBuilder.Clear();
			orCreateStringBuilder.Append(_typeName);
			orCreateStringBuilder.Append("::");
			orCreateStringBuilder.Append(pMethodName);
			orCreateStringBuilder.Append(':');
			orCreateStringBuilder.Append(pLineNumber);
			orCreateStringBuilder.Append(' ');
			orCreateStringBuilder.Append(pMessage);
			return orCreateStringBuilder.ToString();
		}

		private static string CreateLogMessage(string pMessage, string pMethodName, int pLineNumber, Type pContext)
		{
			_typeName = pContext.Name;
			_objectName = null;
			StringBuilder orCreateStringBuilder = GetOrCreateStringBuilder();
			if (!ApplicationUtils.IsMainThread())
			{
				orCreateStringBuilder.Clear();
				orCreateStringBuilder.Append('[');
				orCreateStringBuilder.Append(Thread.CurrentThread.ManagedThreadId);
				orCreateStringBuilder.Append("] ");
				_objectName = ColourString(orCreateStringBuilder, _threadingColour);
			}
			orCreateStringBuilder.Clear();
			orCreateStringBuilder.Append(_objectName);
			orCreateStringBuilder.Append(_typeName);
			orCreateStringBuilder.Append("::");
			orCreateStringBuilder.Append(pMethodName);
			orCreateStringBuilder.Append(':');
			orCreateStringBuilder.Append(pLineNumber);
			orCreateStringBuilder.Append(' ');
			orCreateStringBuilder.Append(pMessage);
			return orCreateStringBuilder.ToString();
		}

		public static Color GetAutoColour(string pString)
		{
			return default(Color);
		}

		public static string AutoColourString(string pString)
		{
			return pString;
		}

		public static string ColourString(string pString, Color pColour)
		{
			return pString;
		}

		public static string ColourString(StringBuilder pStringBuilder, Color pColour)
		{
			return pStringBuilder.ToString();
		}
	}
}
