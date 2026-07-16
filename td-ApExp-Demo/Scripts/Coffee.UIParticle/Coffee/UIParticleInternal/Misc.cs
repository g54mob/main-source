using System.Diagnostics;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class Misc
	{
		public static T[] FindObjectsOfType<T>() where T : Object
		{
			return Object.FindObjectsOfType<T>();
		}

		public static void Destroy(Object obj)
		{
			if ((bool)obj)
			{
				Object.Destroy(obj);
			}
		}

		public static void DestroyImmediate(Object obj)
		{
			if ((bool)obj)
			{
				Object.Destroy(obj);
			}
		}

		[Conditional("UNITY_EDITOR")]
		public static void SetDirty(Object obj)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void QueuePlayerLoopUpdate()
		{
		}
	}
}
