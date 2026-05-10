using System;
using System.Diagnostics;
using UnityEngine;

namespace ParadoxNotion.Design
{
	public static class UndoUtility
	{
		public static string lastOperationName { get; private set; }

		[Conditional("UNITY_EDITOR")]
		public static void RecordObject(UnityEngine.Object target, string name)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void RecordObjectComplete(UnityEngine.Object target, string name)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void SetDirty(UnityEngine.Object target)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void RecordObject(UnityEngine.Object target, string name, Action operation)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void RecordObjectComplete(UnityEngine.Object target, string name, Action operation)
		{
		}

		public static string GetLastOperationNameOr(string operation)
		{
			return null;
		}

		public static void CheckUndo(UnityEngine.Object target, string name)
		{
		}

		public static void CheckDirty(UnityEngine.Object target)
		{
		}
	}
}
