using Client;
using Factory;
using Factory.Pools;
using Motorways.Leaderboards;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class ChallengeView : IView, IReusable
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private MotorwaysGame _motorwaysGame;

		[Dependency]
		private LeaderboardService _leaderboardService;

		private AnchoredMessageModel _messageModal;

		private bool _hasSeenMessage;

		private float _messageDisplayTimeRemaining;

		private bool _scoreSubmitted;

		private static readonly Vector2 MessageAnchorOffset = new Vector2(0f, 0.8f);

		public const int TimeRemainingBeforeNotificationInSeconds = 900;

		public const int SubmitScoreWhenSecondsRemaining = 15;

		private const float MessageDisplayDurationInSeconds = 5f;

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			TickChallengeTimeRemainingDisplay(timeInterval.Delta);
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
		}

		private void TickChallengeTimeRemainingDisplay(float deltaTime)
		{
			ActiveChallengesModel activeChallengesModel = _scope.Get<ActiveChallengesModel>();
			if (!activeChallengesModel.HasChallenges || !activeChallengesModel.HasEndTime)
			{
				return;
			}
			int secondsLeftWithGracePeriod = activeChallengesModel.SecondsLeftWithGracePeriod;
			if (secondsLeftWithGracePeriod <= 15)
			{
				if (!_scoreSubmitted)
				{
					LeaderboardId leaderboardIdForGame = _motorwaysGame.GetLeaderboardIdForGame();
					int score = _scope.Get<ScoreModel>().Score;
					_leaderboardService.SubmitScore(leaderboardIdForGame, score, LeaderboardScoreState.Locked);
					_scoreSubmitted = true;
				}
			}
			else
			{
				if (secondsLeftWithGracePeriod >= 900)
				{
					return;
				}
				ISimulation simulation = _scope.Get<ISimulation>();
				if (!_hasSeenMessage)
				{
					AnchoredMessageModel anchoredMessageModel = _scope.Get<AnchoredMessageModel>();
					anchoredMessageModel.InitializeWithScreenAnchor(StringId.Leaderboard_ChallengeTimeRunningOut, MessageAnchorOffset, CameraLayer.Overlay);
					simulation.AddModel(anchoredMessageModel);
					_messageModal = anchoredMessageModel;
					_messageDisplayTimeRemaining = 5f;
					_hasSeenMessage = true;
				}
				if (_messageDisplayTimeRemaining > 0f)
				{
					_messageDisplayTimeRemaining -= deltaTime;
					if (_messageDisplayTimeRemaining < 0f)
					{
						simulation.RemoveModel(_messageModal);
						_messageModal = null;
					}
				}
			}
		}

		public void Reset()
		{
			_hasSeenMessage = false;
			_messageModal = null;
			_messageDisplayTimeRemaining = 0f;
			_scoreSubmitted = false;
		}
	}
}
