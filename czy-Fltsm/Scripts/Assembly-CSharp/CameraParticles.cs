using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

public class CameraParticles : SceneBehaviour
{
	[Serializable]
	private class PollutionParticleSystem
	{
		public PollutionLevels PollutionLevel;

		public ParticleSystem ParticleSystem;

		public void PopulateParticleSystem(IWorldRegion worldRegion, List<ParticleSystem> particleSystems)
		{
			if (PollutionLevel == worldRegion.PollutionLevel)
			{
				particleSystems.Add(ParticleSystem);
			}
		}
	}

	[Serializable]
	private class RegionParticleSystem
	{
		public WorldRegionType Region;

		public ParticleSystem ParticleSystem;

		public PollutionParticleSystem[] PollutionParticleSystems;

		public void PopulateParticleSystem(IWorldRegion region, List<ParticleSystem> particleSystems)
		{
			if (region == null || Region != region.Type)
			{
				return;
			}
			particleSystems.Add(ParticleSystem);
			PollutionParticleSystem[] pollutionParticleSystems = PollutionParticleSystems;
			foreach (PollutionParticleSystem pollutionParticleSystem in pollutionParticleSystems)
			{
				if (pollutionParticleSystem.PollutionLevel == region.PollutionLevel)
				{
					particleSystems.Add(pollutionParticleSystem.ParticleSystem);
				}
			}
		}
	}

	[SerializeField]
	private RegionParticleSystem[] _regionParticleSystems;

	[SerializeField]
	private RegionParticleSystem _fallbackParticleSystem;

	private RegionParticleSystem _activeRegionParticleSystem;

	private List<ParticleSystem> _playingParticleSystems = new List<ParticleSystem>();

	private void OnEnable()
	{
		OnTownheartMoved();
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	private void OnTownheartMoved(GameEvent gameEvent = null)
	{
		IWorldRegion worldRegion = ((GameManager.WorldManager != null) ? GameManager.WorldManager.CurrentRegion : null);
		RegionParticleSystem regionParticleSystem = GetRegionParticleSystem(worldRegion);
		if (regionParticleSystem == _activeRegionParticleSystem)
		{
			return;
		}
		using ListPool<ParticleSystem>.List list = ListPool<ParticleSystem>.Get();
		_activeRegionParticleSystem = regionParticleSystem;
		_activeRegionParticleSystem.PopulateParticleSystem(worldRegion, list);
		foreach (ParticleSystem item in list)
		{
			if (!_playingParticleSystems.Remove(item))
			{
				item.Play();
			}
		}
		foreach (ParticleSystem playingParticleSystem in _playingParticleSystems)
		{
			playingParticleSystem.Stop();
		}
		_playingParticleSystems.Clear();
		_playingParticleSystems.AddRange(list);
	}

	private RegionParticleSystem GetRegionParticleSystem(IWorldRegion worldRegion)
	{
		if (worldRegion == null)
		{
			return _fallbackParticleSystem;
		}
		RegionParticleSystem[] regionParticleSystems = _regionParticleSystems;
		foreach (RegionParticleSystem regionParticleSystem in regionParticleSystems)
		{
			if (regionParticleSystem.Region == worldRegion.Type)
			{
				return regionParticleSystem;
			}
		}
		Debug.LogWarning($"No particle system set for region '{worldRegion.Type}', using fallback.");
		return _fallbackParticleSystem;
	}
}
