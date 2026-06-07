using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public struct PresetItem
	{
		public ScriptableCoroutine Preset;

		public Transform Target;
	}
}
