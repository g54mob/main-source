using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Sectors
{
	[Serializable]
	public class UniqueLocationSector : GalaxyMapSector
	{
		public LocationData Location;

		private System.Random _randomGenerator;

		public void SetLocation(LocationData location, int radius)
		{
			Location = location;
			Location.Position = new Vector2(0f, 0f);
			base.Radius = (float)radius * location.CustomScale;
		}

		protected override void Init(System.Random randomGenerator)
		{
			_randomGenerator = randomGenerator;
		}

		public override LocationData GetLocationById(string dataCurrentLocationId)
		{
			if (Location.UniqueId == dataCurrentLocationId)
			{
				return Location;
			}
			return null;
		}

		public override void PostLoad(Galaxy galaxy)
		{
			base.PostLoad(galaxy);
			Location.PostLoad(this);
		}
	}
}
