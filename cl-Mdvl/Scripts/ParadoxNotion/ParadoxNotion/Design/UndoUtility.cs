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
			operation();
		}

		[Conditional("UNITY_EDITOR")]
		public static void RecordObjectComplete(UnityEngine.Object target, string name, Action operation)
		{
			operation();
		}

		public static string GetLastOperationNameOr(string operation)
		{
			if (!string.IsNullOrEmpty(lastOperationName))
			{
				return lastOperationName;
			}
			return operation;
		}

		public static void CheckUndo(UnityEngine.Object target, string name)
		{
			Event current = Event.current;
			if (current.type == EventType.MouseDown || current.type == EventType.KeyDown || current.type == EventType.DragPerform || current.type == EventType.ExecuteCommand)
			{
				lastOperationName = name;
			}
		}

		public static void CheckDirty(UnityEngine.Object target)
		{
			_ = GUI.changed;
		}
	}
}
