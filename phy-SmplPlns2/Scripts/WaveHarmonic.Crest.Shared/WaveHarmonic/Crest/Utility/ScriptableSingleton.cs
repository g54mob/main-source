using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Utility
{
	internal abstract class ScriptableSingleton<T> : CustomScriptableObject where T : ScriptableObject
	{
		public static T Instance { get; private set; }

		public ScriptableSingleton()
		{
			Instance = this as T;
		}
	}
}
