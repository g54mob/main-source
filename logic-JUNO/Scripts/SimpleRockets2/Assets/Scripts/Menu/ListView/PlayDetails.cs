using System;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft;
using ModApi.Levels;
using ModApi.Levels.Scores;

namespace Assets.Scripts.Menu.ListView
{
	public class PlayDetails
	{
		private DetailsTextScript _description;

		private DetailsInputScript _launchName;

		private DetailsTextScript _noScoresText;

		private DetailsPropertyScript[] _scoreProperties;

		private DetailsHeaderScript _scoresHeader;

		public string FlightName
		{
			get
			{
				return _launchName.Text;
			}
			set
			{
				_launchName.Text = value;
			}
		}

		public DetailsWidgetGroup LaunchWidgets { get; private set; }

		public PlayDetails(ListViewDetailsScript listViewDetails, ICraftScript craftScript)
		{
			_description = listViewDetails.Widgets.AddText("Description");
			listViewDetails.Widgets.AddSpacer();
			LaunchWidgets = listViewDetails.Widgets.AddGroup();
			LaunchWidgets.AddHeader("Flight Name");
			_launchName = LaunchWidgets.AddInput();
			_launchName.PlaceholderText = "Flight Name...";
			LaunchWidgets.AddSpacer();
			_scoresHeader = listViewDetails.Widgets.AddHeader("SCORES");
			_noScoresText = listViewDetails.Widgets.AddText("No scores yet");
			_scoreProperties = new DetailsPropertyScript[10];
			for (int i = 0; i < 10; i++)
			{
				_scoreProperties[i] = listViewDetails.Widgets.AddProperty(string.Empty);
			}
			HideScores();
		}

		public void UpdateDetails(PlayViewModel.PlayItemViewModel item)
		{
			_description.Text = UiUtilities.ProcessStringWithInputs(item.Description);
			LaunchWidgets.Visible = item.LaunchCraft;
			ILevelData level = item.Level;
			if (level != null && level.ScoreData.ShowTopScores)
			{
				ShowScores(item.Level);
			}
			else
			{
				HideScores();
			}
		}

		private void HideScores()
		{
			_scoresHeader.Visible = false;
			_noScoresText.Visible = false;
			DetailsPropertyScript[] scoreProperties = _scoreProperties;
			for (int i = 0; i < scoreProperties.Length; i++)
			{
				scoreProperties[i].Visible = false;
			}
		}

		private void ShowScores(ILevelData level)
		{
			_scoresHeader.Visible = true;
			_noScoresText.Visible = level.ScoreData.Scores.Count == 0;
			for (int i = 0; i < _scoreProperties.Length; i++)
			{
				if (i < level.ScoreData.Scores.Count)
				{
					LevelScore levelScore = level.ScoreData.Scores[i];
					_scoreProperties[i].LabelText = Utilities.RelativeDate(DateTime.UtcNow, levelScore.DateTime);
					_scoreProperties[i].ValueText = level.ScoreData.Formatter.FormatScore(levelScore);
					_scoreProperties[i].Visible = true;
				}
				else
				{
					_scoreProperties[i].Visible = false;
				}
			}
		}
	}
}
