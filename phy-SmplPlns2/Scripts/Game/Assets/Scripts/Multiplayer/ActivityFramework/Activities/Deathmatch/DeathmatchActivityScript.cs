using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Levels;
using Assets.Scripts.UI.Activity;
using FishNet.Connection;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.Deathmatch
{
	public class DeathmatchActivityScript : NetworkedActivityScript
	{
		private const string DeathScoreId = "Deaths";

		private const string KillScoreId = "Score";

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EDeathmatch_002EDeathmatchActivityScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EDeathmatch_002EDeathmatchActivityScriptGame_002Edll_Excuted;

		public bool IsTeamBasedDeathmatch { get; private set; }

		public override NetworkedActivityTeamIds JoinableTeams
		{
			get
			{
				if (!IsTeamBasedDeathmatch)
				{
					return NetworkedActivityTeamIds.Team1;
				}
				return NetworkedActivityTeamIds.Team1 | NetworkedActivityTeamIds.Team2;
			}
		}

		public override string GetPlayerScoreString(NetworkedActivityPlayer player)
		{
			int valueInt = player.GetScore("Score").ValueInt;
			int valueInt2 = player.GetScore("Deaths").ValueInt;
			return $"{valueInt}k-{valueInt2}d";
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			IsTeamBasedDeathmatch = base.Data.XmlData.GetBoolAttribute("teamDeathmatch");
		}

		public override void UpdateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			scoreSummary.SetText("left", LevelBase.FormatTime(((float?)base.TimerValue) ?? 0f));
			int valueInt = base.LocalPlayer.GetScore().ValueInt;
			scoreSummary.SetText("right", $"{valueInt}");
		}

		protected override int CompareScores(NetworkedActivityPlayer x, NetworkedActivityPlayer y)
		{
			int valueInt = x.GetScore("Score").ValueInt;
			int valueInt2 = y.GetScore("Score").ValueInt;
			int valueInt3 = x.GetScore("Deaths").ValueInt;
			int valueInt4 = y.GetScore("Deaths").ValueInt;
			if (valueInt > valueInt2)
			{
				return 1;
			}
			if (valueInt2 > valueInt)
			{
				return -1;
			}
			if (valueInt3 < valueInt4)
			{
				return 1;
			}
			if (valueInt3 > valueInt4)
			{
				return -1;
			}
			return 0;
		}

		protected override IEnumerable<NetworkedActivityScore> CreateScoresForPlayer(NetworkedActivityPlayer player)
		{
			yield return new NetworkedActivityScore("Score", "Score", NetworkedActivityScore.ScoreValueType.Int);
			yield return new NetworkedActivityScore("Deaths", "Deaths", NetworkedActivityScore.ScoreValueType.Int);
		}

		protected override NetworkedActivityTeamType GetTeamType(NetworkedActivityTeamIds teamId)
		{
			if (!IsTeamBasedDeathmatch)
			{
				return NetworkedActivityTeamType.TeamPerPlayerHostile;
			}
			return NetworkedActivityTeamType.Default;
		}

		protected override void OnActivityEndedServer()
		{
			base.OnActivityEndedServer();
		}

		protected override void OnActivityStartedClient()
		{
			base.OnActivityStartedClient();
			if (base.IsActivityHost)
			{
				StartTimer(base.Data.XmlData.GetIntAttribute("timer"));
			}
		}

		protected override void OnLocalPlayerEnded(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerEnded(player);
			player.Player.AircraftKilled -= OnLocalPlayerKilled;
		}

		protected override void OnLocalPlayerStarted(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerStarted(player);
			player.Player.AircraftKilled += OnLocalPlayerKilled;
		}

		protected override void OnTimerChangedClient(int timerValue)
		{
			base.OnTimerChangedClient(timerValue);
			if (timerValue <= 0 && base.IsActivityHost)
			{
				StopTimer();
				EndActivity();
			}
		}

		private void OnLocalPlayerKilled(object sender, AircraftKilledEventArgs e)
		{
			if (e.KillerId.HasValue)
			{
				NetworkedActivityPlayer player = GetPlayer(e.KillerId.Value);
				UpdatePlayerScore(player.PlayerId, "Score", 1);
			}
			int? num = e.Aircraft?.NetworkAircraft?.PlayerId;
			if (num.HasValue)
			{
				UpdatePlayerScore(num.Value, "Deaths", 1);
			}
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EDeathmatch_002EDeathmatchActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EDeathmatch_002EDeathmatchActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EDeathmatch_002EDeathmatchActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EDeathmatch_002EDeathmatchActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		public override void Awake()
		{
			NetworkInitialize___Early();
			base.Awake();
			NetworkInitialize___Late();
		}
	}
}
