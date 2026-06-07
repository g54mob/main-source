using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem
{
	public class PlanetSpawnManager : SerializableMonobehaviour<PlanetSpawnManager, SpawnManagerData>
	{
		private Dictionary<ESpawnSectorType, SpawnSector> _spawnSectors;

		private System.Random _randomGenerator;

		private NimbatusPlanetTheme _activeTheme;

		public NimbatusPlanetEvent ActiveEvent;

		internal override string Filename
		{
			get
			{
				return "SpawnManager.xml";
			}
		}

		public IEnumerator StartSpawn(System.Random random)
		{
			_randomGenerator = random;
			InitSpawnSectors();
			if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null)
			{
				yield return StartCoroutine(DoSpawn(SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.SpawnSettings));
			}
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation is PlanetLocationData)
			{
				PlanetLocationData planetLocationData = (PlanetLocationData)SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation;
				_activeTheme = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetTheme(planetLocationData.ThemeType);
				NimbatusPlanetTheme activeDecoTheme = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetDecoTheme(planetLocationData.DecoThemeType);
				yield return StartCoroutine(DoSpawn(_activeTheme.SpawnSettings));
				NimbatusPlanetTheme nimbatusPlanetTheme = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.AlwaysActiveThemes.RandomItemSeed(random.Next(0, int.MaxValue));
				if (nimbatusPlanetTheme != null)
				{
					yield return StartCoroutine(DoSpawn(nimbatusPlanetTheme.SpawnSettings));
				}
				yield return StartCoroutine(DoSpawn(activeDecoTheme.SpawnSettings));
			}
		}

		public IEnumerator StartEvents(EPlanetEventType eventType, bool force = false)
		{
			if (!(ActiveEvent == null) || (!force && _randomGenerator.Next(0, 100) >= 10) || !(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation is PlanetLocationData))
			{
				yield break;
			}
			NimbatusPlanetEvent selectedEvent = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetEvent(eventType);
			if (!force)
			{
				yield return new WaitForSeconds(_randomGenerator.Next(selectedEvent.MinStartDelay, selectedEvent.MaxStartDelay));
			}
			float startTime = Time.time;
			ActiveEvent = selectedEvent;
			if (selectedEvent.SpawnSettings != null && selectedEvent.SpawnSettings.Count > 0)
			{
				foreach (PlanetSpawnSetting spawnSetting in selectedEvent.SpawnSettings)
				{
					spawnSetting.Init(_randomGenerator);
				}
				List<ESpawnSectorType> selectedSectors = new List<ESpawnSectorType>();
				foreach (PlanetSpawnSetting spawn in selectedEvent.SpawnSettings)
				{
					for (int i = 0; i < spawn.NumberOfSectors; i++)
					{
						ESpawnSectorType sector;
						if (CanSpawn(spawn, out sector))
						{
							selectedSectors.Add(sector);
						}
					}
					while (startTime + selectedEvent.Duration > Time.time)
					{
						foreach (ESpawnSectorType item in selectedSectors)
						{
							if (RuntimeGlobals.IsGameOver || RuntimeGlobals.IsGameLoading)
							{
								yield break;
							}
							spawn.TryToSpawn(item);
							yield return true;
						}
						yield return new WaitForSeconds(selectedEvent.SpawnInterval);
					}
				}
			}
			ActiveEvent = null;
		}

		public IEnumerator DoSpawn(List<PlanetSpawnSetting> spawnsettings)
		{
			if (spawnsettings != null && spawnsettings.Count > 0)
			{
				foreach (PlanetSpawnSetting spawnsetting in spawnsettings)
				{
					spawnsetting.Init(_randomGenerator);
				}
				foreach (PlanetSpawnSetting spawn in spawnsettings)
				{
					for (int i = 0; i < spawn.NumberOfSectors; i++)
					{
						ESpawnSectorType sector;
						if (CanSpawn(spawn, out sector) && spawn.TryToSpawn(sector) && !spawn.IgnoreBlockedSectors)
						{
							LockSpawnLocation(spawn, sector);
						}
						yield return true;
					}
				}
			}
			yield return true;
		}

		private void InitSpawnSectors()
		{
			_spawnSectors = new Dictionary<ESpawnSectorType, SpawnSector>();
			foreach (ESpawnSectorType item in from ESpawnSectorType c in Enum.GetValues(typeof(ESpawnSectorType))
				where c != ESpawnSectorType.All
				select c)
			{
				_spawnSectors.Add(item, new SpawnSector(item, SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.UnlockedSpawnRegions));
			}
		}

		private void LockSpawnLocation(PlanetSpawnSetting spawn, ESpawnSectorType sector)
		{
			if (sector != ESpawnSectorType.All)
			{
				_spawnSectors[sector].LockRegion(spawn.PossibleSpawnRegion);
			}
		}

		private bool CanSpawn(PlanetSpawnSetting spawn, out ESpawnSectorType sector)
		{
			sector = ESpawnSectorType.All;
			if (spawn.PossibleSpawnSectors.Contains(ESpawnSectorType.All))
			{
				List<SpawnSector> list = (from s in _spawnSectors
					where !spawn.UsedSpawnSectors.Contains(s.Key)
					select s.Value).ToList();
				list.Shuffle(_randomGenerator);
				foreach (SpawnSector item in list)
				{
					if (item.CanSpawn(spawn) || spawn.IgnoreBlockedSectors)
					{
						sector = item.SectorType;
						spawn.UsedSpawnSectors.Add(sector);
						return true;
					}
				}
			}
			else
			{
				List<ESpawnSectorType> list2 = spawn.PossibleSpawnSectors.Where((ESpawnSectorType s) => !spawn.UsedSpawnSectors.Contains(s)).ToList();
				list2.Shuffle(_randomGenerator);
				foreach (ESpawnSectorType item2 in list2)
				{
					SpawnSector spawnSector = _spawnSectors[item2];
					if (spawnSector.CanSpawn(spawn) || spawn.IgnoreBlockedSectors)
					{
						sector = spawnSector.SectorType;
						spawn.UsedSpawnSectors.Add(sector);
						return true;
					}
				}
			}
			sector = ESpawnSectorType.All;
			return false;
		}

		protected override void LoadFromFile(SpawnManagerData data)
		{
		}

		protected override SpawnManagerData SaveToFile()
		{
			return new SpawnManagerData();
		}
	}
}
