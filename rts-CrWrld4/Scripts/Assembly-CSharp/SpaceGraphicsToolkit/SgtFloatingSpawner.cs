using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtFloatingSpawner : MonoBehaviour
	{
		public string Category;

		public List<SgtFloatingSpawnable> Prefabs;

		private static List<SgtFloatingSpawnable> prefabs;

		[SerializeField]
		private List<SgtFloatingSpawnable> instances;

		[NonSerialized]
		private SgtFloatingSpawnable cachedSpawnable;

		[NonSerialized]
		private bool cachedSpawnableSet;

		public SgtFloatingSpawnable CachedSpawnable => null;

		protected virtual void OnDisable()
		{
		}

		protected bool BuildSpawnList()
		{
			return false;
		}

		protected SgtFloatingSpawnable SpawnAt(SgtPosition position)
		{
			return null;
		}

		private static void BuildSpawnList(List<SgtFloatingSpawnable> floatingObjects)
		{
		}
	}
}
