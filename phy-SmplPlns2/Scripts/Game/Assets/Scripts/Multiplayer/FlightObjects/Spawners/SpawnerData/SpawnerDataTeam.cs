using System.Collections.Generic;
using Assets.Scripts.Flight.Combat.Teams;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners.SpawnerData
{
	public class SpawnerDataTeam : MonoBehaviour, ISpawnerData
	{
		public const string Key = "TeamId";

		[SerializeField]
		private TeamId _team;

		public void GetSpawnerData(IDictionary<string, string> data)
		{
			if (_team != TeamId.Unknown)
			{
				ushort team = (ushort)_team;
				data.Add("TeamId", team.ToString());
			}
		}
	}
}
