using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingLod : MonoBehaviour
	{
		[Serializable]
		public class Level
		{
			public SgtLength DistanceMin;

			public SgtFloatingSpawnable Prefab;

			public SgtLength DistanceMax;

			public SgtFloatingSpawnable Clone;
		}

		public bool EnableInEditor;

		[SerializeField]
		private List<Level> levels;

		[NonSerialized]
		private SgtFloatingObject cachedObject;

		[NonSerialized]
		private SgtFloatingSpawnable cachedSpawnable;

		[NonSerialized]
		private bool cachedSpawnableSet;

		public SgtFloatingSpawnable CachedSpawnable => null;

		public Level AddLevel()
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void UpdateDistance(double distance)
		{
		}

		private void UpdateLevel(Level level, double distance)
		{
		}
	}
}
