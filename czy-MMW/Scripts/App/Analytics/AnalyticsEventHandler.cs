using Factory;
using Motorways;
using Motorways.Views;
using Plugins.Analytics;
using com.dinopoloclub.analytics;

namespace Analytics
{
	public class AnalyticsEventHandler : ICreatedInScopeHandler, MotorwaysGame.IObserver, GameContainerScreen.IObserver
	{
		[Dependency]
		private MainMenuScreen _mainMenuScreen;

		[Dependency]
		private StartupScreen _startupScreen;

		[Dependency]
		private GameContainerScreen _gameContainerScreen;

		[Dependency]
		private ActivePlayer _activePlayer;

		private MotorwaysGameAnalytics _analyticsGameEvents;

		public void OnCreatedInScope(IScope scope)
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.Analytics))
			{
				_gameContainerScreen.Subscribe(this);
				_analyticsGameEvents = new MotorwaysGameAnalytics();
				_analyticsGameEvents.Initialise(_activePlayer.AnalyticsConsentState, new MotorwaysGameAnalyticsStorageProvider());
			}
		}

		public void SetAnalyticsConsentState(AnalyticsService.ConsentState consentState)
		{
			_analyticsGameEvents.SetUserAnalyticsConsent(consentState);
		}

		public void OnMainMenuTransitionedIn()
		{
			if (AnalyticsUtilities.IsUnderage())
			{
				_analyticsGameEvents.SetUserAnalyticsConsent(AnalyticsService.ConsentState.Declined);
				_activePlayer.AnalyticsConsentState = AnalyticsService.ConsentState.Declined;
			}
		}

		public void OnMotorwaysGameStarted(string cityName, GameMode gameMode)
		{
			_analyticsGameEvents.SendLevelStartEvent(cityName, gameMode.ToString());
		}

		public void OnMotorwaysGameEnded(string cityName, GameMode mode, GameEndReason gameEndReason, int score)
		{
			_analyticsGameEvents.SendLevelEndEvent(cityName, mode.ToString(), gameEndReason.ToString(), score);
		}

		public void OnMotorwaysGameCreated(MotorwaysGame motorwaysGame)
		{
			motorwaysGame.Subscribe(this);
		}
	}
}
