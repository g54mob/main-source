using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners.SpawnerData
{
	public class SpawnerDataLocation : MonoBehaviour, ISpawnerData
	{
		public const string Key = "LocationId";

		[SerializeField]
		private string _locationId;

		public void GetSpawnerData(IDictionary<string, string> data)
		{
			if (!string.IsNullOrEmpty(_locationId))
			{
				data.Add("LocationId", _locationId);
			}
		}
	}
}
