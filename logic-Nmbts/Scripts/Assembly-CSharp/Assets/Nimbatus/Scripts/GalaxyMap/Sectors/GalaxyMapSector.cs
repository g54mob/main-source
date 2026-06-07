using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Sectors
{
	[Serializable]
	[XmlInclude(typeof(SolarSystem))]
	[XmlInclude(typeof(UniqueLocationSector))]
	public abstract class GalaxyMapSector
	{
		public List<string> NeighbourSectorIds = new List<string>();

		[NonSerialized]
		[XmlIgnore]
		private List<GalaxyMapSector> _neighbourSectors = new List<GalaxyMapSector>();

		public int RewardSeed;

		public string UniqueId { get; set; }

		public int Step { get; set; }

		public Vector2 Position { get; set; }

		public bool Revealed { get; set; }

		public bool Scanned { get; set; }

		public bool Explored { get; set; }

		public int InfluenceToUnlock { get; set; }

		public int Influence { get; set; }

		public float Radius { get; set; }

		public bool IsDeadEnd { get; set; }

		public void Init(System.Random randomGenerator, Vector2 position)
		{
			UniqueId = Guid.NewGuid().ToString();
			Position = position;
			Influence = 0;
			InfluenceToUnlock = 0;
			Radius = 0f;
			RewardSeed = randomGenerator.Next();
			Init(randomGenerator);
		}

		public void SetPosition(Vector2 position)
		{
			Position = position;
		}

		public void AddNeighbour(GalaxyMapSector sector)
		{
			if (!_neighbourSectors.Contains(sector))
			{
				_neighbourSectors.Add(sector);
				NeighbourSectorIds.Add(sector.UniqueId);
				sector.AddNeighbour(this);
			}
		}

		public List<GalaxyMapSector> GetNeighbours()
		{
			return _neighbourSectors.ToList();
		}

		public void ExploreAllNeighbours()
		{
			foreach (GalaxyMapSector neighbourSector in _neighbourSectors)
			{
				SolarSystem system;
				if ((system = neighbourSector as SolarSystem) != null)
				{
					CreateSectorRewards(system);
				}
				neighbourSector.ExploreAll();
			}
		}

		private void ExploreAll()
		{
			Explored = true;
			foreach (GalaxyMapSector neighbourSector in _neighbourSectors)
			{
				if (!neighbourSector.Explored)
				{
					SolarSystem system;
					if ((system = neighbourSector as SolarSystem) != null)
					{
						CreateSectorRewards(system);
					}
					neighbourSector.ExploreAll();
				}
			}
		}

		public void SetExplored(bool explored)
		{
			if (Explored == explored)
			{
				return;
			}
			Explored = explored;
			if (explored)
			{
				if (!Scanned)
				{
					SetScanned(true);
				}
				ExploreWhenEnoughInfluence();
			}
		}

		public void ExploreWhenEnoughInfluence()
		{
			if (this is SolarSystem && Influence >= InfluenceToUnlock)
			{
				ExploreNeighbours();
			}
		}

		public void ExploreNeighbours()
		{
			foreach (GalaxyMapSector neighbourSector in _neighbourSectors)
			{
				neighbourSector.SetExplored(true);
			}
		}

		private void CreateSectorRewards(SolarSystem system)
		{
			System.Random randomGenerator = new System.Random(system.RewardSeed);
			foreach (LocationData location in system.Locations)
			{
				location.CreateRewards(randomGenerator);
				location.CreatePenalties(randomGenerator);
			}
		}

		public void RevealNeighbours(bool reveal)
		{
			foreach (GalaxyMapSector neighbourSector in _neighbourSectors)
			{
				neighbourSector.Revealed = reveal;
			}
		}

		public List<GalaxyMapSector> ScanNeighbours(bool scan)
		{
			List<GalaxyMapSector> list = new List<GalaxyMapSector>();
			foreach (GalaxyMapSector neighbour in GetNeighbours())
			{
				if (!neighbour.Scanned)
				{
					list.Add(neighbour);
				}
				neighbour.SetScanned(scan);
			}
			return list;
		}

		public void SetScanned(bool scan)
		{
			Scanned = scan;
			SolarSystem system;
			if (Scanned && (system = this as SolarSystem) != null)
			{
				CreateSectorRewards(system);
			}
		}

		public void MissionCompleted(NimbatusMission mission)
		{
			IncreaseInfluence(GetInfluence(mission.Difficulty));
		}

		public void BossfightCompleted()
		{
			IncreaseInfluence(GetInfluence(EMissionDifficulty.Hard));
		}

		public void IncreaseInfluence(int inf)
		{
			Influence += inf;
			if (Influence >= InfluenceToUnlock)
			{
				ExploreNeighbours();
			}
		}

		private int GetInfluence(EMissionDifficulty difficulty)
		{
			return (int)difficulty;
		}

		protected abstract void Init(System.Random randomGenerator);

		public virtual void PostLoad(Galaxy galaxy)
		{
			_neighbourSectors = new List<GalaxyMapSector>();
			foreach (string neighbourSectorId in NeighbourSectorIds)
			{
				_neighbourSectors.Add(galaxy.GetSectorById(neighbourSectorId));
			}
		}

		public abstract LocationData GetLocationById(string dataCurrentLocationId);
	}
}
