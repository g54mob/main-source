using System;
using System.Collections.Generic;
using Easing;
using Factory;
using Helpers.GameCenter;
using Popups;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class LoadingScreen : BaseScalingScreen, IInitialGameScreen, IScreen
	{
		private enum LoadingStage
		{
			WaitingInvisibly = 0,
			FadingIn = 1,
			WaitingVisibly = 2,
			FadingOut = 3,
			Transitioned = 4
		}

		private abstract class LoadInterruptItem
		{
			public enum InterruptionState
			{
				WaitingForCheck = 0,
				WaitingForInterruptToEnd = 1,
				Done = 2
			}

			public InterruptionState interruptionState;

			public abstract bool ShouldInterrupt();

			public void PresentInterruption()
			{
				interruptionState = InterruptionState.WaitingForInterruptToEnd;
				PresentInterruptionImpl();
			}

			protected abstract void PresentInterruptionImpl();
		}

		private class CloudSaveWarning : LoadInterruptItem
		{
			private IPersistentStorageService _storage;

			private PopupStack _popupStack;

			public CloudSaveWarning(IPersistentStorageService storage, PopupStack popupStack)
			{
				_storage = storage;
				_popupStack = popupStack;
			}

			public override bool ShouldInterrupt()
			{
				return false;
			}

			protected override void PresentInterruptionImpl()
			{
				_popupStack.PushPopup<LoadScreenInterruptionPopup>().Initialise(StringId.Options_iCloud, StringId.Options_iCloud_CacheIssue_NotSignedIn, delegate
				{
					interruptionState = InterruptionState.Done;
				});
			}
		}

		private class GameCenterWarning : LoadInterruptItem
		{
			private IGameCenterAuthentication _gameCenterAuthentication;

			private PopupStack _popupStack;

			public GameCenterWarning(IGameCenterAuthentication gameCenterAuthentication, PopupStack popupStack)
			{
				_gameCenterAuthentication = gameCenterAuthentication;
				_popupStack = popupStack;
			}

			public override bool ShouldInterrupt()
			{
				return _gameCenterAuthentication.RequiresRetry;
			}

			protected override void PresentInterruptionImpl()
			{
				_popupStack.PushPopup<LoadScreenInterruptionPopup>().Initialise(StringId.GameCenterLoginRetryRequiredTitle, StringId.GameCenterLoginRetryRequiredDescription, delegate
				{
					interruptionState = InterruptionState.Done;
				});
			}
		}

		private readonly Queue<LoadInterruptItem> _loadInterruptItems = new Queue<LoadInterruptItem>();

		private bool _hasPlayerDataLoaded;

		private bool _hasActivatedPlayer;

		[SerializeField]
		private Image _loadingSpinner;

		private LoadingStage _stage;

		private float _timeVisible;

		private float _spinnerTweenTimer;

		[SerializeField]
		private float _maxTimeVisibleWithoutSpinner = 1.5f;

		[SerializeField]
		private float _spinnerTweenDuration = 0.4f;

		[SerializeField]
		private Easings.Functions _spinnerTweenEasing = Easings.Functions.SineEaseInOut;

		[SerializeField]
		[Tooltip("Force the loading screen to be visible for at least this many seconds. This is useful for testing the screen.")]
		private float _minTimeVisible;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[Dependency]
		private IPersistentStorageService _storage;

		[Dependency]
		private PlayerDatabase _playerDatabase;

		[Dependency]
		private IActivePlayer _activePlayer;

		[Dependency]
		private VisualConstantsData _visualConstants;

		[Dependency]
		private IGameCenterAuthentication _gameCenterAuthentication;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LoadingScreen");

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
			_loadInterruptItems.Enqueue(new CloudSaveWarning(_storage, popupStack));
			_loadInterruptItems.Enqueue(new GameCenterWarning(_gameCenterAuthentication, popupStack));
		}

		public override void Reset()
		{
			base.Reset();
			_hasPlayerDataLoaded = false;
			_hasActivatedPlayer = false;
			_stage = LoadingStage.WaitingInvisibly;
			_timeVisible = 0f;
			_spinnerTweenTimer = 0f;
			_loadInterruptItems.Clear();
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (_hasPlayerDataLoaded && _timeVisible > _minTimeVisible && !_hasActivatedPlayer)
			{
				List<Player> list = null;
				if (_loadInterruptItems.Count > 0)
				{
					LoadInterruptItem loadInterruptItem = _loadInterruptItems.Peek();
					if (loadInterruptItem.interruptionState == LoadInterruptItem.InterruptionState.WaitingForCheck)
					{
						if (loadInterruptItem.ShouldInterrupt())
						{
							loadInterruptItem.PresentInterruption();
						}
						else
						{
							loadInterruptItem.interruptionState = LoadInterruptItem.InterruptionState.Done;
						}
					}
					if (loadInterruptItem.interruptionState == LoadInterruptItem.InterruptionState.Done)
					{
						_loadInterruptItems.Dequeue();
					}
				}
				if (_loadInterruptItems.Count > 0)
				{
					return;
				}
				foreach (Player player2 in _playerDatabase.Players)
				{
					if (player2.HasAvatar)
					{
						continue;
					}
					bool flag = false;
					if (player2.LastPlayedUtcTimeOnLocalDevice == DateTime.MinValue)
					{
						Log.Info("Deleting empty player {0} because they don't have a valid last played time.");
						flag = true;
					}
					if (player2.UserProfile is LegacyMotorwaysUserProfile { TotalPlayTime: 0 })
					{
						Log.Info("Deleting empty player {0} because they don't have any play time.");
						flag = true;
					}
					if (flag)
					{
						if (list == null)
						{
							list = new List<Player>();
						}
						list.Add(player2);
					}
					else
					{
						DateTime utcTimestamp = player2.ExtendedUserProfile.UtcTimestamp;
						int profileIconCount = _visualConstants.ProfileIconCount;
						int iconCount = 6;
						player2.ChooseAvatar(profileIconCount, iconCount);
						player2.ExtendedUserProfile.UtcTimestamp = utcTimestamp;
					}
				}
				if (list != null)
				{
					foreach (Player item in list)
					{
						_playerDatabase.DeletePlayer(item);
					}
				}
				_hasActivatedPlayer = true;
				Player player = _playerDatabase.MostRecentPlayer;
				if (player == null)
				{
					player = _playerDatabase.CreatePlayer();
					player.LocaleId = _softwareCapabilities.PreferredLocaleId;
					int profileIconCount2 = _visualConstants.ProfileIconCount;
					int iconCount2 = 6;
					player.ChooseAvatar(profileIconCount2, iconCount2);
				}
				_activePlayer.ActivatePlayer(player);
				if (_stage == LoadingStage.WaitingInvisibly)
				{
					_screenStack.PushScreen(ScreenStack.MotorwaysScreen.Startup);
					_stage = LoadingStage.Transitioned;
				}
			}
			_timeVisible += deltaTime;
			float value = 0f;
			switch (_stage)
			{
			case LoadingStage.WaitingInvisibly:
				if (_timeVisible > _maxTimeVisibleWithoutSpinner)
				{
					_stage = LoadingStage.FadingIn;
					_spinnerTweenTimer = 0f;
				}
				break;
			case LoadingStage.FadingIn:
				_spinnerTweenTimer += deltaTime;
				value = _spinnerTweenTimer / _spinnerTweenDuration;
				if (_spinnerTweenTimer >= _spinnerTweenDuration)
				{
					_stage = LoadingStage.WaitingVisibly;
				}
				break;
			case LoadingStage.WaitingVisibly:
				value = 1f;
				if (_hasActivatedPlayer)
				{
					_spinnerTweenTimer = 0f;
					_stage = LoadingStage.FadingOut;
				}
				break;
			case LoadingStage.FadingOut:
				_spinnerTweenTimer += deltaTime;
				value = 1f - _spinnerTweenTimer / _spinnerTweenDuration;
				if (_spinnerTweenTimer >= _spinnerTweenDuration)
				{
					_screenStack.PushScreen(ScreenStack.MotorwaysScreen.Startup);
					_stage = LoadingStage.Transitioned;
				}
				break;
			}
			Color color = _loadingSpinner.color;
			color.a = Easings.Interpolate(Mathf.Clamp01(value), _spinnerTweenEasing);
			_loadingSpinner.color = color;
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			_storage.LoadAll(OnPlayerDataLoaded);
		}

		private void OnPlayerDataLoaded()
		{
			_hasPlayerDataLoaded = true;
		}
	}
}
