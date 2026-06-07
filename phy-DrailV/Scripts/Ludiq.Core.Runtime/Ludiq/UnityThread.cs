using System;
using System.Threading;
using UnityEngine;

namespace Ludiq
{
	public static class UnityThread
	{
		public static Thread thread = Thread.CurrentThread;

		public static Action<Action> editorAsync;

		public static bool allowsAPI
		{
			get
			{
				if (!Serialization.isUnitySerializing)
				{
					return Thread.CurrentThread == thread;
				}
				return false;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RuntimeInitialize()
		{
			thread = Thread.CurrentThread;
		}

		public static void EditorAsync(Action action)
		{
			editorAsync?.Invoke(action);
		}
	}
}
