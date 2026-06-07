using System.Diagnostics;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal static class Extentions
	{
		[Conditional("UNITY_EDITOR")]
		public static void Manage(this Component owner, GameObject @object)
		{
			@object.AddComponent<ManagedGameObject>().Owner = owner;
		}
	}
}
