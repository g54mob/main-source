using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI.Score;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TournamentProgressScreen : TournamentScreen
	{
		public FindNextOpponentButton FindNextButton;

		public AbandonTournamentButton ResetButton;

		public ShowTournamentDrone DroneDisplay;

		public TournamentScoreDisplay ScoreDisplay;

		public override void Init()
		{
			DroneDisplay.Init(Manager);
			FindNextButton.Init(Manager);
			ResetButton.Init(Manager);
			ScoreDisplay.Init(Manager);
		}
	}
}
