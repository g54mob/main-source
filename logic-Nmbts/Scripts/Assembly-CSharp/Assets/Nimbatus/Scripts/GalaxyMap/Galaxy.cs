using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap
{
	[Serializable]
	public class Galaxy
	{
		public int Level { get; set; }

		public int Seed { get; set; }

		public string StartLocationId { get; set; }

		public string EndLocationId { get; set; }

		public string CurrentLocationId { get; set; }

		public float CurrentThreatLevel { get; set; }

		public float BaseThreatIncrease { get; set; }

		public List<GalaxyMapSector> Sectors { get; set; }

		public void PostLoad()
		{
			foreach (GalaxyMapSector sector in Sectors)
			{
				sector.PostLoad(this);
			}
		}

		public GalaxyMapSector GetSectorById(string id)
		{
			foreach (GalaxyMapSector sector in Sectors)
			{
				if (id == sector.UniqueId)
				{
					return sector;
				}
			}
			return null;
		}

		public LocationData GetLocationById(string id)
		{
			foreach (GalaxyMapSector sector in Sectors)
			{
				LocationData locationById = sector.GetLocationById(id);
				if (locationById != null)
				{
					return locationById;
				}
			}
			return null;
		}

		public void IncreaseThreatByAmount(float amount)
		{
			CurrentThreatLevel += amount;
			CurrentThreatLevel = Mathf.Clamp(CurrentThreatLevel, 0f, 100f);
		}

		public void SetThreat(float value)
		{
			CurrentThreatLevel = Mathf.Min(value, 100f);
			CurrentThreatLevel = Mathf.Clamp(CurrentThreatLevel, 0f, 100f);
		}
	}
}
