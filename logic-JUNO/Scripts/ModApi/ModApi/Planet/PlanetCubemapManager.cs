using System;
using System.Collections.Generic;
using ModApi.Settings;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetCubemapManager : MonoBehaviour
	{
		[SerializeField]
		private List<PlanetCubemapSet> _cubemapSets;

		[SerializeField]
		private List<PlanetCubemap> _cubemapsToUnload;

		public static bool EnableLogging { get; set; }

		public int CubemapMaxSize { get; private set; }

		public int CubemapMinSize { get; private set; }

		public IReadOnlyList<PlanetCubemapSet> CubemapSets => _cubemapSets;

		public void LoadPlanet(IPlanetData planet)
		{
			_cubemapSets.Add(new PlanetCubemapSet(this, _cubemapsToUnload, planet, CubemapMinSize, CubemapMaxSize));
		}

		public void LoadPlanet(IPlanetData planet, int minSize, int maxSize)
		{
			_cubemapSets.Add(new PlanetCubemapSet(this, _cubemapsToUnload, planet, minSize, maxSize));
		}

		public void LoadSystem(ISolarSystemData system)
		{
			UnloadAndDestroyEverything();
			if (system == null)
			{
				return;
			}
			foreach (IPlanetData planet in system.Planets)
			{
				LoadPlanet(planet, CubemapMinSize, CubemapMaxSize);
			}
		}

		public void ProcessRequests()
		{
			foreach (PlanetCubemapSet cubemapSet in _cubemapSets)
			{
				cubemapSet.ProcessRequests();
			}
		}

		public PlanetCubemapsRequest RequestCubemaps(string requestName, IPlanetData planet, int size, Action<PlanetCubemapsRequest> onCubemapsUpdated)
		{
			return GetCubemapSet(planet)?.RequestCubemaps(requestName, size, onCubemapsUpdated) ?? new PlanetCubemapsRequest(requestName, null, size, onCubemapsUpdated);
		}

		public void UnloadPlanet(IPlanetData planet)
		{
			PlanetCubemapSet set = GetCubemapSet(planet);
			if (set != null)
			{
				_cubemapsToUnload.RemoveAll((PlanetCubemap x) => x.PlanetData == set.PlanetData);
				set.OnDestroy();
				_cubemapSets.Remove(set);
			}
		}

		protected virtual void Awake()
		{
			_cubemapsToUnload = new List<PlanetCubemap>();
			_cubemapSets = new List<PlanetCubemapSet>();
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = Game.Instance.QualitySettings.Terrain.CubemapSettings;
			CubemapMinSize = cubemapSettings.MinSize;
			CubemapMaxSize = cubemapSettings.MaxSize;
			if (Device.IsUnityEditor)
			{
				EnableLogging = false;
			}
		}

		protected virtual void LateUpdate()
		{
			ProcessRequests();
			int num = _cubemapsToUnload.Count - 1;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					_cubemapsToUnload[i].UnloadCubemaps();
				}
				_cubemapsToUnload.RemoveRange(0, num);
			}
		}

		protected virtual void OnDestroy()
		{
			UnloadAndDestroyEverything();
		}

		private PlanetCubemapSet GetCubemapSet(IPlanetData planet)
		{
			foreach (PlanetCubemapSet cubemapSet in _cubemapSets)
			{
				if (cubemapSet.PlanetData == planet)
				{
					return cubemapSet;
				}
			}
			Debug.LogError("The cubemap set for celestial body '" + planet.Name + "' could not be found.");
			return null;
		}

		private void UnloadAndDestroyEverything()
		{
			_cubemapsToUnload?.Clear();
			if (_cubemapSets == null)
			{
				return;
			}
			foreach (PlanetCubemapSet cubemapSet in _cubemapSets)
			{
				cubemapSet.OnDestroy();
			}
			_cubemapSets.Clear();
		}
	}
}
