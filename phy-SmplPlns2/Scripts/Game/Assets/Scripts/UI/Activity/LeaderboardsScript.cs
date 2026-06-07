using System.Collections;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Activity
{
	public class LeaderboardsScript : WidgetScript
	{
		private ActivityUIScript _activityUI;

		private bool _gameOver;

		private Widget _leaderboards;

		private ScoreSummaryScript _scoreSummary;

		private TextWidget _scoreTextLeft;

		private TextWidget _scoreTextRight;

		public NetworkedActivityScript Activity => _activityUI.Activity;

		public void Initialize(ActivityUIScript activityUI)
		{
			_activityUI = activityUI;
			Activity.StateChanged += OnActivityStateChanged;
			if (activityUI.Activity.IsActivityHost)
			{
				base.Widget.EnableClass("host", enabled: true);
			}
			base.Widget.FindWidget<TextWidget>("activity-name").Text = Activity.Data.DisplayName;
			base.Widget.FindWidgetComponent<TeamListPanelScript>("team-panels").Initialize(Activity);
		}

		public async void OnActivityStarted()
		{
			_scoreSummary = base.Widget.FindWidgetComponent<ScoreSummaryScript>("score-summary");
			_scoreSummary.Leaderboards = this;
			Activity.CreateScoreSummaryWidget(_scoreSummary);
			base.Widget.Visible = true;
			TextWidget startText = base.Widget.FindWidget<TextWidget>("start-text");
			startText.Text = null;
			await _activityUI.Activity.UpdateStartText(delegate(string s)
			{
				startText.Text = s;
			}, startText.Show, startText.Hide);
			startText.Hide();
		}

		public void OnExitActivityButtonClicked(Widget widget)
		{
			if (_gameOver)
			{
				LeaveActivity();
				return;
			}
			string messageText = ((Activity.IsActivityHost && Activity.Players.Count > 1) ? "You are the host. Leaving will end the activity for everyone. Do you want to continue?" : "Are you sure you want to leave this activity?");
			Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, messageText, "Exit Activity").OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				LeaveActivity();
			};
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_leaderboards = widget.FindWidget("leaderboards-panel");
			_scoreTextLeft = widget.FindWidget<TextWidget>("score-text-left");
			_scoreTextRight = widget.FindWidget<TextWidget>("score-text-right");
		}

		public void ToggleLeaderboards()
		{
			if (_leaderboards.Visible)
			{
				_leaderboards.Hide(null, force: true);
				_scoreSummary.Widget.EnableClass("expanded", enabled: false);
			}
			else
			{
				_leaderboards.Show(force: true);
				_scoreSummary.Widget.EnableClass("expanded", enabled: true);
			}
		}

		protected virtual void OnDestroy()
		{
			Activity.StateChanged -= OnActivityStateChanged;
		}

		protected virtual void Update()
		{
			if (!_gameOver && Activity != null && _scoreSummary.Widget.Visible && Activity.LocalPlayer != null)
			{
				Activity.UpdateScoreSummaryWidget(_scoreSummary);
			}
		}

		private void LeaveActivity()
		{
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			if (localPlayer.NetworkedActivity != null)
			{
				localPlayer.NetworkedActivity.LeaveActivity(localPlayer);
			}
			FlightSceneScript.Instance.FlightUI.ActivityManagerUI.CloseCurrentActivityUI();
		}

		private void OnActivityStateChanged(object sender, NetworkedActivityStateChangedEventArgs e)
		{
			if (base.isActiveAndEnabled && (int)e.State >= 5 && !_gameOver)
			{
				_gameOver = true;
				base.Widget.FindWidget("start-text-container").Visible = false;
				_leaderboards.Show(force: true);
				_scoreSummary.Widget.Visible = false;
				base.Widget.EnableClass("ended", enabled: true);
				StartCoroutine(ShowGameOverText());
				FlightSceneScript.Instance.FlightUI.ActivityManagerUI.OnCurrentActivityEnded();
			}
		}

		private void OnCloseLeaderboardsButtonClicked(Widget widget)
		{
			if (!_gameOver)
			{
				_leaderboards.Hide();
			}
			else
			{
				LeaveActivity();
			}
		}

		private void OnRestartActivityButtonClicked(Widget widget)
		{
			if (Activity.State != NetworkedActivityState.Ended)
			{
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "This activity is still in progress. Restarting will end it for all participants. Continue?", "Restart Activity", delegate(MessageDialogScript d)
				{
					d.Close();
					ExecuteRestart().Forget();
				}).UseDangerButtonStyle = true;
			}
			else
			{
				ExecuteRestart().Forget();
			}
			async UniTaskVoid ExecuteRestart()
			{
				NetworkedActivityData activity = Activity.Data;
				await Game.Instance.NetworkedActivityManager.LeaveActivity();
				await Game.Instance.NetworkedActivityManager.CreateActivity(activity);
			}
		}

		private IEnumerator ShowGameOverText()
		{
			NetworkedActivityScript.FinalScoreSummary finalScoreSummary = Activity.GenerateFinalScoreSummary();
			if (!string.IsNullOrEmpty(finalScoreSummary.Message))
			{
				TextWidget gameOverText = base.Widget.FindWidget<TextWidget>("game-over-text");
				string text = finalScoreSummary.Message;
				if (!string.IsNullOrEmpty(finalScoreSummary.SubMessage))
				{
					text = text + "\n<size=33%>" + finalScoreSummary.SubMessage;
				}
				gameOverText.Text = text;
				gameOverText.EnableClass("activity-player-won", finalScoreSummary.ShowCelebrationStyle);
				gameOverText.Show();
				yield return new WaitForSeconds(5f);
				gameOverText.Hide();
			}
		}
	}
}
