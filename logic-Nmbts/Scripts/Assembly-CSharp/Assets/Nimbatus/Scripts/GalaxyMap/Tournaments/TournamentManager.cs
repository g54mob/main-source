using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments
{
	public class TournamentManager : GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>
	{
		[NonSerialized]
		[HideInInspector]
		public List<Tournament> Tournaments;

		[HideInInspector]
		public string CurrentGameVersion = "1.0.0";

		[HideInInspector]
		public string LoadedVersion;

		internal override string Filename
		{
			get
			{
				return "Tournaments.xml";
			}
		}

		[HideInInspector]
		public Tournament ActiveTournament { get; private set; }

		public bool IsInTraining { get; set; }

		public void SetActiveTournament(ETournamentType tournament)
		{
			ActiveTournament = GetTournament(tournament);
		}

		public Tournament GetTournament(ETournamentType tournamentType)
		{
			return Tournaments.FirstOrDefault((Tournament t) => t.Settings.TournamentType == tournamentType);
		}

		public void StoreMatchStatistics(bool playerWon, NimbatusDrone leftDrone, NimbatusDrone rightDrone, float matchTime)
		{
			if (ActiveTournament.IsTournamentRunning() && !IsInTraining)
			{
				DronePart[] source = UnityEngine.Object.FindObjectsOfType<DronePart>();
				int numberOfPart = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0).NumberOfParts;
				int currentParts = source.Count((DronePart dp) => !dp.IsBroken && dp.gameObject.layer == leftDrone.RootDronePart.gameObject.layer);
				int numberOfParts = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(1).NumberOfParts;
				int currentEnemyParts = source.Count((DronePart dp) => !dp.IsBroken && dp.gameObject.layer == rightDrone.RootDronePart.gameObject.layer);
				if (playerWon)
				{
					ActiveTournament.IncreaseScore();
					ActiveTournament.LastTournamentStatistics.AddMatch(true, SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0), currentParts, numberOfParts, currentEnemyParts, matchTime);
				}
				else
				{
					ActiveTournament.IncreaseLoss();
					ActiveTournament.LastTournamentStatistics.AddMatch(false, SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0), currentParts, numberOfParts, currentEnemyParts, matchTime);
				}
			}
		}

		protected override void PreLoad()
		{
			base.PreLoad();
			Tournaments = new List<Tournament>();
			LoadedVersion = CurrentGameVersion;
			foreach (TournamentSettingObject item in Resources.LoadAll<TournamentSettingObject>("CompetitiveMode").ToList())
			{
				Tournament tournament = new Tournament();
				tournament.Init(item);
				Tournaments.Add(tournament);
			}
		}

		protected override void LoadFromFile(TournamentManagerSaveData data)
		{
			LoadedVersion = data.Version;
			if (string.IsNullOrEmpty(LoadedVersion))
			{
				LoadedVersion = "0.0.0";
			}
			for (int i = 0; i < Tournaments.Count; i++)
			{
				Tournament tournament = Tournaments[i];
				foreach (Tournament tournament2 in data.Tournaments)
				{
					if (tournament.Settings.TournamentType == tournament2.Settings.TournamentType)
					{
						Tournaments[i].LoadFrom(tournament2);
					}
				}
			}
		}

		protected override void PostLoad()
		{
			base.PostLoad();
			foreach (Tournament tournament in Tournaments)
			{
				tournament.PostLoad();
			}
		}

		protected override TournamentManagerSaveData SaveToFile()
		{
			return new TournamentManagerSaveData
			{
				Tournaments = Tournaments,
				Version = CurrentGameVersion
			};
		}
	}
}
