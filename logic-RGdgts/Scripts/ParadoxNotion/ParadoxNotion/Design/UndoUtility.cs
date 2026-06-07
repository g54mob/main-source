using System;
using UnityEngine;

namespace ParadoxNotion.Design
{
	public static class UndoUtility
	{
		public static string lastOperationName { get; private set; }

		public static void RecordObject(UnityEngine.Object target, string name)
		{
		}

		public static void RecordObjectComplete(UnityEngine.Object target, string name)
		{
		}

		public static void SetDirty(UnityEngine.Object target)
		{
		}

		public static void RecordObject(UnityEngine.Object target, string name, Action operation)
		{
		}

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
