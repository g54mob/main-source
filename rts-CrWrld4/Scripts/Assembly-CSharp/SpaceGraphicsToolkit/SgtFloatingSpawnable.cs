using System;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGraphicsToolkit
{
	[DisallowMultipleComponent]
	public class SgtFloatingSpawnable : MonoBehaviour
	{
		[Serializable]
		public class SpawnEvent : UnityEvent<int>
		{
		}

		[SgtSeed]
		public int Seed;

		public SpawnEvent OnSpawn;

		public Action<int> OnSpawnNative;

		[NonSerialized]
		private SgtFloatingObject cachedObject;

		[NonSerialized]
		private bool cachedObjectSet;

		public SgtFloatingObject CachedObject => null;

		public void InvokeOnSpawn()
		{
		}
	}
}
