using System;
using System.Threading;
using UnityEngine;

namespace NSEipix.Base
{
	public abstract class MonoSingletonMainThread<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static readonly object Padlock = new object();

		private static T instance;

		private static bool applicationIsQuitting = false;

		private static Thread mainThread = null;

		public static T Instance
		{
			get
			{
				lock (Padlock)
				{
					if ((object)instance == null)
					{
						instance = UnityEngine.Object.FindObjectOfType<T>();
						if ((object)instance != null)
						{
							if (UnityEngine.Object.FindObjectsOfType<T>().Length > 1)
							{
								Debug.LogErrorFormat("Multiple instances of {0}", instance.GetType().FullName);
							}
							return instance;
						}
						if (applicationIsQuitting)
						{
							return null;
						}
						GameObject obj = new GameObject();
						instance = obj.AddComponent<T>();
						obj.name = $"(singleton) {typeof(T).ToString()}";
						Debug.LogWarning(obj.name + ", was created at: \n" + Environment.StackTrace);
					}
					if (Thread.CurrentThread != mainThread)
					{
						Debug.LogError("Accessing '" + instance.name + "' from non-main thread!");
					}
					return instance;
				}
			}
		}

		private void OnApplicationQuit()
		{
			applicationIsQuitting = true;
		}

		private void Start()
		{
			if (mainThread == null)
			{
				mainThread = Thread.CurrentThread;
			}
		}
	}
}
