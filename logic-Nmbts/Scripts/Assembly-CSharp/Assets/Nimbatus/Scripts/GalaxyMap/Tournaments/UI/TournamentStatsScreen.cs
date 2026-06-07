using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TournamentStatsScreen : TournamentScreen
	{
		public UILabel WinsLabel;

		public UILabel DurationLabel;

		public UILabel PartAmountLabel;

		public UILabel DiameterLabel;

		public UILabel DroneNameLabel;

		public UITexture DroneImage;

		public UILabel VelocityLabel;

		public UILabel AngularVelocityLabel;

		public UITexture DestroyedPartProgress;

		public UILabel DestroyedPartsCounter;

		public UITexture LostPartProgress;

		public UILabel LostPartsCounter;

		public override void Init()
		{
		}

		public override void Show()
		{
			TournamentStatistics lastTournamentStatistics = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.LastTournamentStatistics;
			DroneImage.mainTexture = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentDrone().Image;
			DroneNameLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/DroneName") + " " + LabelHelper.Orange + lastTournamentStatistics.DroneName;
			WinsLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/NumberOfWins") + " " + LabelHelper.Orange + lastTournamentStatistics.Wins;
			DiameterLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/DroneDiameter") + " " + LabelHelper.Orange + lastTournamentStatistics.Diameter.ToString("F2") + LabelHelper.LightGrey + " m";
			PartAmountLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/DroneSize") + " " + LabelHelper.Orange + lastTournamentStatistics.PartAmount + LabelHelper.LightGrey + " " + LocalizationManager.GetTermTranslation("Units/Parts");
			DurationLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/MatchDuration") + " " + LabelHelper.Orange + (lastTournamentStatistics.TotalMatchDuration / (float)((lastTournamentStatistics.NumberOfMatches <= 0) ? 1 : lastTournamentStatistics.NumberOfMatches)).ToString("F2") + LabelHelper.LightGrey + " " + LocalizationManager.GetTermTranslation("Units/Seconds");
			VelocityLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/MaxVelocity") + " " + LabelHelper.Orange + lastTournamentStatistics.MaxVelocity.ToString("F2") + LabelHelper.LightGrey + " " + LocalizationManager.GetTermTranslation("Units/MeterPerSecond");
			AngularVelocityLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("Tournaments/MaxAngularVelocity") + " " + LabelHelper.Orange + lastTournamentStatistics.MaxAngularVelocity.ToString("F2") + LabelHelper.LightGrey + " " + LocalizationManager.GetTermTranslation("Units/DegreePerSecond");
			if (lastTournamentStatistics.NumberOfMatches > 0)
			{
				int num = lastTournamentStatistics.PartAmount - lastTournamentStatistics.TotalLostParts / lastTournamentStatistics.NumberOfMatches;
				int num2 = (lastTournamentStatistics.TotalEnemyParts - lastTournamentStatistics.TotalDestroyedParts) / lastTournamentStatistics.NumberOfMatches;
				DestroyedPartProgress.fillAmount = 1f / (float)lastTournamentStatistics.TotalEnemyParts * (float)num2;
				DestroyedPartsCounter.text = LabelHelper.Orange + (DestroyedPartProgress.fillAmount * 100f).ToString("F0") + LocalizationManager.GetTermTranslation("Units/Percent");
				LostPartProgress.fillAmount = 1f / (float)lastTournamentStatistics.PartAmount * (float)num;
				LostPartsCounter.text = LabelHelper.Orange + (LostPartProgress.fillAmount * 100f).ToString("F0") + LocalizationManager.GetTermTranslation("Units/Percent");
			}
			else
			{
				DestroyedPartProgress.fillAmount = 1f;
				DestroyedPartsCounter.text = LabelHelper.Orange + 100 + LocalizationManager.GetTermTranslation("Units/Percent");
				LostPartProgress.fillAmount = 1f;
				LostPartsCounter.text = LabelHelper.Orange + 100 + LocalizationManager.GetTermTranslation("Units/Percent");
			}
		}

		public override void Hide()
		{
		}
	}
}
