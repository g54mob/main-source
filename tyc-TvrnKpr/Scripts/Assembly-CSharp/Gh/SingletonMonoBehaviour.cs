using System.Diagnostics;
using UnityEngine;

namespace Gh
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		protected static object _lock;

		public static bool DoesInstanceExist => false;

		public static T Instance
		{
			[DebuggerStepThrough]
			get
			{
				return null;
			}
			[DebuggerStepThrough]
			private set
			{
			}
		}

		protected static bool _applicationIsQuitting { get; private set; }

		public virtual void Awake()
		{
		}

		protected static void SetInstanceToNull()
		{
		}

		public virtual void OnApplicationQuit()
		{
		}
	}
}
