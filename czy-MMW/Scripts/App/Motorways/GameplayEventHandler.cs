using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Views;
using NotificationService.Events;
using Server;

namespace Motorways
{
	public class GameplayEventHandler : IReusable, DestinationModel.IObserver
	{
		[Dependency]
		private INotificationEventSystem _notificationEventSystem;

		[Dependency]
		private HapticFeedbackGenerator _feedbackGenerator;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private ScreenStack _screenStack;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private City _city;

		[Dependency]
		private GameUIScreen _gameUIScreen;

		public void Reset()
		{
		}

		public void Tick(MotorwaysGame motorwaysGame)
		{
			if (_city.Rules.ShowsUI())
			{
				UpgradeDatabaseModel model = _simulation.GetModel<UpgradeDatabaseModel>();
				bool flag = !motorwaysGame.HasGameEnded && model != null && model.pendingUpgradeChoices.Count > model.numChoicesMade && _screenStack.IsInGame() && !_screenStack.HasPendingScreen() && !_screenStack.AreAnyScreensTransitioning && _gameUIScreen != null && _gameUIScreen.UpgradeBar != null && _gameUIScreen.UpgradeBar.IsVisible && (_city.Rules.ScoringMode != ScoringMode.EfficiencyMilestones || _gameUIScreen.IsElectiveUpgradeRequested) && _city.Rules.ScoringMode != ScoringMode.None;
				if (motorwaysGame.PlayingBackSimJournal)
				{
					flag = false;
				}
				if (flag)
				{
					motorwaysGame.TrySave(GameJournalMotive.Autosave);
					ShowUpgradeScreen();
				}
			}
		}

		private void EndGame(DestinationView failedOnDestination)
		{
			ScreenStack screenStack = _scope.Get<ScreenStack>();
			if (!screenStack.IsScreenActive(ScreenStack.MotorwaysScreen.GameOver))
			{
				_feedbackGenerator.GenerateFeedback(HapticFeedbackType.HeavyImpact);
				_notificationEventSystem.RecordEvent(new GameOvered
				{
					Map = _scope.Get<MotorwaysGame>().MapDefinition.CityNameEnum
				});
				screenStack.PushScreen(ScreenStack.MotorwaysScreen.GameOver, delegate(GameOverScreen gameOverScreen)
				{
					gameOverScreen.focusPoint = failedOnDestination.transform.position;
				}, additive: true, _scope);
			}
		}

		private void ShowUpgradeScreen()
		{
			UpgradeDatabaseModel upgrades = _simulation.GetModel<UpgradeDatabaseModel>();
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.Upgrade, delegate(GameUpgradeScreen screen)
			{
				screen.SetNextButtonOptions(upgrades.pendingUpgradeChoices[0], 0f);
			}, additive: true, _simulation.Scope).ApplyTheme(_theme.TargetTheme);
		}

		public void OnDestinationOvercrowded(DestinationModel destination)
		{
			if (_city.Rules.CanDestinationsOvercrowd)
			{
				DestinationView destinationView = _viewIndex.GetDestinationView(destination);
				EndGame(destinationView);
			}
		}

		public void OnDestinationReceivedVehicle(DestinationModel destination, VehicleModel vehicle)
		{
		}

		public void OnDestinationChangedGroup(DestinationModel destination, int oldGroupIndex, int newGroupIndex)
		{
		}

		public void OnDestinationRemoved(DestinationModel destination)
		{
		}
	}
}
