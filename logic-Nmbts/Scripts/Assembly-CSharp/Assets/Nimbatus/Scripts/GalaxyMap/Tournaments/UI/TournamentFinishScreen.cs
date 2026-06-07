using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TournamentFinishScreen : TournamentScreen
	{
		public UILabel ScoreLabel;

		public string WinSound;

		public string WinSoundLoop;

		public override void Init()
		{
			int currentScore = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentScore();
			if (currentScore == 10)
			{
				ScoreLabel.text = LocalizationManager.GetTermTranslation("Tournaments/10Wins");
			}
			else if (currentScore > 1)
			{
				string translation = LocalizationManager.GetTermTranslation("Tournaments/XWins");
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
				{
					"WinCount",
					currentScore.ToString()
				} });
				ScoreLabel.text = translation;
			}
			else if (currentScore == 1)
			{
				ScoreLabel.text = LocalizationManager.GetTermTranslation("Tournaments/1Win");
			}
			else if (currentScore <= 0)
			{
				ScoreLabel.text = LocalizationManager.GetTermTranslation("Tournaments/0Wins");
			}
		}

		public override void Show()
		{
			AudioController.Play(WinSound);
			AudioController.Play(WinSoundLoop);
		}

		public override void Hide()
		{
			AudioController.Stop(WinSound);
			AudioController.Stop(WinSoundLoop);
		}
	}
}
