using System.Diagnostics;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class Misc
	{
		public static void Destroy(Object obj)
		{
		}

		public static void DestroyImmediate(Object obj)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void SetDirty(Object obj)
		{
		}
	}
}
