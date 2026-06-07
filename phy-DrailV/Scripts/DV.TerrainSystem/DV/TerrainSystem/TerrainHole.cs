using System;
using DV.Utils;
using UnityEngine;

namespace DV.TerrainSystem
{
	public class TerrainHole : MonoBehaviour
	{
		public float radius = 4f;

		[NonSerialized]
		public int managerIndex = -1;

		private Terrain _terrain;

		private bool wasStarted;

		public Terrain Terrain
		{
			get
			{
				return _terrain;
			}
			set
			{
				if (value != _terrain)
				{
					this.TerrainAboutToBeChanged?.Invoke(value);
					_terrain = value;
				}
			}
		}

		public event Action<Terrain> TerrainAboutToBeChanged;

		private void Start()
		{
			wasStarted = true;
			OnEnable();
		}

		private void OnEnable()
		{
			if (wasStarted)
			{
				SingletonBehaviour<TerrainHoleManager>.Instance.RegisterHole(this);
			}
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading && wasStarted && (bool)SingletonBehaviour<TerrainHoleManager>.Instance)
			{
				SingletonBehaviour<TerrainHoleManager>.Instance.UnregisterHole(this);
			}
		}
	}
}
