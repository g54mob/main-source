using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways;
using Motorways.Leaderboards;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : MonoBehaviour
{
	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LeaderboardPanel");

	private const int MaximumTopEntries = 10;

	private const int DisplayedRows = 11;

	private const float MinVisibleDurationBeforeErrorDisplay = 0.9f;

	[SerializeField]
	private Sprite _bottomEntrySprite;

	[SerializeField]
	private LocalizedTextUI _errorText;

	[SerializeField]
	private GameObject _loadingSpinner;

	[SerializeField]
	private GameObject _histogramParent;

	[SerializeField]
	private GameObject _leaderboardParent;

	[SerializeField]
	private TouchToggle _surroundingLeaderboardsButton;

	[SerializeField]
	private TouchToggle _friendsLeaderboardsButton;

	[SerializeField]
	private TouchToggle _globalLeaderboardsButton;

	[SerializeField]
	private TouchToggle _histogramLeaderboardsButton;

	[SerializeField]
	private LocalizedTextUI _filterDisplayText;

	[SerializeField]
	private TouchButton _leaderboardErrorButton;

	[SerializeField]
	private LocalizedTextUI _leaderboardErrorButtonText;

	[SerializeField]
	private Histogram _histogram;

	public GameObject leaderboardEntriesParent;

	private readonly List<LeaderboardPanelEntry> _displayedEntries = new List<LeaderboardPanelEntry>();

	public LeaderboardPanelEntry leaderboardEntryRowPrefab;

	private IScope _scope;

	private MapSelectScreen _mapSelectScreen;

	private LeaderboardService _leaderboardService;

	private IReachability _reachability;

	private MotorwaysThemeDatabase _themeDatabase;

	private LeaderboardId _lastRequestedLeaderboard;

	private LeaderboardType _lastRequestedLeaderboardType = LeaderboardType.Surrounding;

	private AsyncRequestHandle _requestHandle;

	private LeaderboardErrorCode _lastError;

	private TouchOptionButton _leaderboardSelector;

	private MapButton _mapButton;

	private MapDefinition _mapDefinition;

	private float _initializeTime;

	private LeaderboardError _requestError;

	public LocalizedTextUI ErrorText => _errorText;

	public TouchToggle SurroundingLeaderboardsButton => _surroundingLeaderboardsButton;

	public TouchToggle FriendsLeaderboardsButton => _friendsLeaderboardsButton;

	public TouchToggle GlobalLeaderboardsButton => _globalLeaderboardsButton;

	public TouchToggle HistogramLeaderboardsButton => _histogramLeaderboardsButton;

	public TouchButton LeaderboardErrorButton => _leaderboardErrorButton;

	protected void Awake()
	{
		_surroundingLeaderboardsButton.onValueChanged.AddListener(delegate
		{
			ChangeTypeForLastRequestedLeaderboard(LeaderboardType.Surrounding);
		});
		_friendsLeaderboardsButton.onValueChanged.AddListener(delegate
		{
			ChangeTypeForLastRequestedLeaderboard(LeaderboardType.Friends);
		});
		_globalLeaderboardsButton.onValueChanged.AddListener(delegate
		{
			ChangeTypeForLastRequestedLeaderboard(LeaderboardType.Global);
		});
		_histogramLeaderboardsButton.onValueChanged.AddListener(delegate
		{
			ChangeTypeForLastRequestedLeaderboard(LeaderboardType.Histogram);
		});
	}

	protected void Update()
	{
		if (_requestError != null && Time.realtimeSinceStartup - _initializeTime > 0.9f)
		{
			LeaderboardError requestError = _requestError;
			_requestError = null;
			DisplayError(requestError);
		}
	}

	public void Initialize(IScope scope, TouchOptionButton recurringLeaderboardSelector, MapButton mapButton)
	{
		_scope = scope;
		_leaderboardSelector = recurringLeaderboardSelector;
		_themeDatabase = scope.Get<MotorwaysThemeDatabase>();
		_leaderboardService = scope.Get<LeaderboardService>();
		_reachability = scope.Get<IReachability>();
		_mapSelectScreen = scope.Get<MapSelectScreen>();
		_lastRequestedLeaderboard = null;
		_mapButton = mapButton;
		_mapDefinition = mapButton.MapDefinition;
		_histogram.Initialize(scope);
		bool flag = _leaderboardService.IsLeaderboardTypeSupported(LeaderboardType.Global);
		bool flag2 = _leaderboardService.IsLeaderboardTypeSupported(LeaderboardType.Friends);
		bool flag3 = _leaderboardService.IsLeaderboardTypeSupported(LeaderboardType.Surrounding);
		bool flag4 = flag && !flag2 && !flag3;
		bool flag5 = mapButton.IsChallengeMapButton();
		_surroundingLeaderboardsButton.gameObject.SetActive(!flag4 && flag3);
		_friendsLeaderboardsButton.gameObject.SetActive(!flag4 && flag2);
		_globalLeaderboardsButton.gameObject.SetActive(flag5 && !flag4);
		_histogramLeaderboardsButton.gameObject.SetActive(flag && !flag4);
		if (!flag5)
		{
			_leaderboardSelector.leftButton.gameObject.SetActive(!mapButton.AreChallengesLocked || mapButton.MapDefinition.IsExpertModeUnlocked(_scope));
			_leaderboardSelector.rightButton.gameObject.SetActive(!mapButton.AreChallengesLocked || mapButton.MapDefinition.IsExpertModeUnlocked(_scope));
			if (!mapButton.MapDefinition.IsExpertModeUnlocked(_scope))
			{
				_leaderboardSelector.SkipOption(1);
			}
			for (int i = 0; i < _mapDefinition.cityChallenges.Length; i++)
			{
				CityChallengeData cityChallengeData = _mapDefinition.cityChallenges[i];
				_leaderboardSelector.options[2 + i].GetComponent<LocalizedTextUI>().SetStringId(scope, cityChallengeData.titleStringId);
			}
			for (int j = 2 + _mapDefinition.cityChallenges.Length; j < _leaderboardSelector.options.Length; j++)
			{
				_leaderboardSelector.SkipOption(j);
			}
		}
		_initializeTime = Time.realtimeSinceStartup;
	}

	[UsedImplicitly]
	public void ChangeTypeForLastRequestedLeaderboard(LeaderboardType type)
	{
		ShowLeaderboardFor(type, _lastRequestedLeaderboard);
		_mapSelectScreen.PlayerSelectedLeaderboardType = type;
	}

	public void ShowLeaderboardFor(LeaderboardType type, LeaderboardId leaderboardId)
	{
		switch (type)
		{
		case LeaderboardType.Surrounding:
			_histogramParent.SetActive(value: false);
			_leaderboardParent.SetActive(value: true);
			ShowSurroundingEntriesFor(leaderboardId);
			_surroundingLeaderboardsButton.Set(value: true, sendCallback: false);
			_friendsLeaderboardsButton.Set(value: false, sendCallback: false);
			_globalLeaderboardsButton.Set(value: false, sendCallback: false);
			_histogramLeaderboardsButton.Set(value: false, sendCallback: false);
			_filterDisplayText.SetStringId(_scope, StringId.LeaderboardFilter_Surrounding);
			break;
		case LeaderboardType.Friends:
			_histogramParent.SetActive(value: false);
			_leaderboardParent.SetActive(value: true);
			ShowTopFriendEntriesFor(leaderboardId);
			_friendsLeaderboardsButton.Set(value: true, sendCallback: false);
			_surroundingLeaderboardsButton.Set(value: false, sendCallback: false);
			_globalLeaderboardsButton.Set(value: false, sendCallback: false);
			_histogramLeaderboardsButton.Set(value: false, sendCallback: false);
			_filterDisplayText.SetStringId(_scope, StringId.LeaderboardFilter_Friends);
			break;
		case LeaderboardType.Global:
			_histogramParent.SetActive(value: false);
			_leaderboardParent.SetActive(value: true);
			ShowTopEntriesFor(leaderboardId);
			_globalLeaderboardsButton.Set(value: true, sendCallback: false);
			_histogramLeaderboardsButton.Set(value: false, sendCallback: false);
			_surroundingLeaderboardsButton.Set(value: false, sendCallback: false);
			_friendsLeaderboardsButton.Set(value: false, sendCallback: false);
			_filterDisplayText.SetStringId(_scope, StringId.LeaderboardFilter_Global);
			break;
		case LeaderboardType.Histogram:
			ShowHistogramFor(leaderboardId);
			_histogramLeaderboardsButton.Set(value: true, sendCallback: false);
			_globalLeaderboardsButton.Set(value: false, sendCallback: false);
			_surroundingLeaderboardsButton.Set(value: false, sendCallback: false);
			_friendsLeaderboardsButton.Set(value: false, sendCallback: false);
			_filterDisplayText.SetStringId(_scope, StringId.LeaderboardFilter_Histogram);
			break;
		}
		if (leaderboardId is CityLeaderboardId cityLeaderboardId)
		{
			if (cityLeaderboardId.CityChallengeIndex == -1)
			{
				int index = ((cityLeaderboardId.Mode == CityGameMode.Expert) ? 1 : 0);
				_leaderboardSelector.SetOption(index, invokeMethod: false);
			}
			else
			{
				_leaderboardSelector.SetOption(2 + cityLeaderboardId.CityChallengeIndex, invokeMethod: false);
			}
		}
	}

	private void ShowHistogramFor(LeaderboardId leaderboardId)
	{
		if (_lastRequestedLeaderboard == null || !_lastRequestedLeaderboard.Equals(leaderboardId) || _lastRequestedLeaderboardType != LeaderboardType.Histogram)
		{
			_requestHandle?.Cancel();
			ClearError();
			_histogramParent.SetActive(value: false);
			_leaderboardParent.SetActive(value: false);
			_lastRequestedLeaderboard = leaderboardId;
			_lastRequestedLeaderboardType = LeaderboardType.Histogram;
			_histogram.ShowHistogram(leaderboardId);
		}
	}

	public void OnHistogramSucceeded()
	{
		SetLoadingSpinnerEnabled(isLoading: false);
		_histogramParent.SetActive(value: true);
	}

	public void OnHistogramFailed([CanBeNull] LeaderboardError error)
	{
		if (error != null && error.Code != LeaderboardErrorCode.NoData)
		{
			Log.Info("Error while requesting leaderboard entries. {0}", error);
			_requestError = error;
		}
		else
		{
			_histogramParent.SetActive(value: false);
			_leaderboardParent.SetActive(value: true);
			ShowTopEntriesFor(_lastRequestedLeaderboard);
		}
	}

	private void ShowTopEntriesFor(LeaderboardId leaderboardId)
	{
		if (_lastRequestedLeaderboard == null || !_lastRequestedLeaderboard.Equals(leaderboardId) || _lastRequestedLeaderboardType != LeaderboardType.Global)
		{
			ClearError();
			SetEntriesEnabled(isEnabled: false);
			SetLoadingSpinnerEnabled(isLoading: true);
			_lastRequestedLeaderboard = leaderboardId;
			_lastRequestedLeaderboardType = LeaderboardType.Global;
			_requestHandle?.Cancel();
			_requestHandle = _leaderboardService.RequestTopEntries(leaderboardId, 10, OnEntryRequestCompleted);
		}
	}

	private void ShowTopFriendEntriesFor(LeaderboardId leaderboardId)
	{
		if (_lastRequestedLeaderboard == null || !_lastRequestedLeaderboard.Equals(leaderboardId) || _lastRequestedLeaderboardType != LeaderboardType.Friends)
		{
			ClearError();
			SetEntriesEnabled(isEnabled: false);
			SetLoadingSpinnerEnabled(isLoading: true);
			_lastRequestedLeaderboard = leaderboardId;
			_lastRequestedLeaderboardType = LeaderboardType.Friends;
			_requestHandle?.Cancel();
			_requestHandle = _leaderboardService.RequestTopFriendFilteredEntries(leaderboardId, 10, OnEntryRequestCompleted);
		}
	}

	private void ShowSurroundingEntriesFor(LeaderboardId leaderboardId)
	{
		if (_lastRequestedLeaderboard == null || !_lastRequestedLeaderboard.Equals(leaderboardId) || _lastRequestedLeaderboardType != LeaderboardType.Surrounding)
		{
			ClearError();
			SetEntriesEnabled(isEnabled: false);
			SetLoadingSpinnerEnabled(isLoading: true);
			_lastRequestedLeaderboard = leaderboardId;
			_lastRequestedLeaderboardType = LeaderboardType.Surrounding;
			_requestHandle?.Cancel();
			_requestHandle = _leaderboardService.RequestPlayerCenteredEntries(leaderboardId, 10, OnEntryRequestCompleted);
		}
	}

	private void OnEntryRequestCompleted(List<LeaderboardEntry> entries, long totalLeaderboardEntryCount, LeaderboardError error)
	{
		if (error != null)
		{
			Log.Info("Error while requesting leaderboard entries. {0}", error);
			_requestError = error;
			return;
		}
		ClearError();
		SetLoadingSpinnerEnabled(isLoading: false);
		SetEntriesEnabled(isEnabled: true);
		if (entries == null)
		{
			EnsureExactNumberOfDisplayedEntries(0);
		}
		else
		{
			EnsureExactNumberOfDisplayedEntries(11);
			for (int i = 0; i < entries.Count && i < _displayedEntries.Count; i++)
			{
				LeaderboardEntry fromEntry = entries[i];
				_displayedEntries[i].UpdateFromLeaderboardEntry(fromEntry, i % 2 == 1, totalLeaderboardEntryCount);
			}
			for (int j = entries.Count; j < _displayedEntries.Count; j++)
			{
				_displayedEntries[j].SetAsBlankEntry(j % 2 == 1);
			}
			_displayedEntries[_displayedEntries.Count - 1].GetComponent<Image>().sprite = _bottomEntrySprite;
		}
		_mapSelectScreen.RegisterThemeComponents(_themeDatabase.GetTheme());
		_mapSelectScreen.ApplyTheme(_themeDatabase.GetTheme());
	}

	private void DisplayError([NotNull] LeaderboardError error)
	{
		SetEntriesEnabled(isEnabled: false);
		SetLoadingSpinnerEnabled(isLoading: false);
		_lastError = LeaderboardErrorCode.None;
		if (!Diagnostics.Verify(error != null && error.Code != LeaderboardErrorCode.None))
		{
			return;
		}
		Log.Info("Leaderboard request resulted in error {0}.", error);
		if (error.Code == LeaderboardErrorCode.NotAuthenticated && _leaderboardService.CanAuthenticate)
		{
			if (!_leaderboardService.Authenticate(delegate(bool didAuthenticate)
			{
				if (didAuthenticate)
				{
					ReloadLeaderboard();
				}
				else
				{
					_mapButton.ShowCard(MapButton.Card.Main);
				}
			}))
			{
				_mapButton.ShowCard(MapButton.Card.Main);
			}
		}
		else
		{
			if (error.Description != StringId.None)
			{
				_errorText.gameObject.SetActive(value: true);
				_errorText.SetStringId(_scope, error.Description);
			}
			if (error.Code == LeaderboardErrorCode.NoConnection && _reachability.CanConnectManually)
			{
				_leaderboardErrorButtonText.LocString = StandaloneLocString.CreateString(_scope, StringId.Leaderboard_Connect);
				_leaderboardErrorButton.gameObject.SetActive(value: true);
				_lastError = LeaderboardErrorCode.NoConnection;
			}
		}
		_leaderboardService.PresentError(error);
	}

	private void ClearError()
	{
		_errorText.gameObject.SetActive(value: false);
		_leaderboardErrorButton.gameObject.SetActive(value: false);
		_lastError = LeaderboardErrorCode.None;
	}

	public void SetLoadingSpinnerEnabled(bool isLoading)
	{
		_loadingSpinner.SetActive(isLoading);
	}

	private void SetEntriesEnabled(bool isEnabled)
	{
		foreach (LeaderboardPanelEntry displayedEntry in _displayedEntries)
		{
			displayedEntry.gameObject.SetActive(isEnabled);
		}
	}

	private void EnsureExactNumberOfDisplayedEntries(int entryCount)
	{
		if (_displayedEntries.Count == entryCount || entryCount < 0)
		{
			return;
		}
		for (int num = _displayedEntries.Count - 1; num >= entryCount; num--)
		{
			_displayedEntries[num].gameObject.transform.SetParent(null, worldPositionStays: false);
			Object.Destroy(_displayedEntries[num].gameObject);
			_displayedEntries.RemoveAt(num);
		}
		for (int i = _displayedEntries.Count; i < entryCount; i++)
		{
			LeaderboardPanelEntry leaderboardPanelEntry = Object.Instantiate(leaderboardEntryRowPrefab, leaderboardEntriesParent.transform);
			if (Diagnostics.Verify(leaderboardPanelEntry != null))
			{
				leaderboardPanelEntry.InitializeWithScope(_scope);
				_displayedEntries.Add(leaderboardPanelEntry);
			}
		}
	}

	public void OnLeaderboardErrorButtonPressed()
	{
		if (_lastError == LeaderboardErrorCode.NoConnection)
		{
			ClearError();
			SetEntriesEnabled(isEnabled: false);
			SetLoadingSpinnerEnabled(isLoading: true);
			_reachability.OpenManualConnection(delegate(InternetConnectionHandle request)
			{
				ReloadLeaderboard();
				request.Close();
			});
		}
		else
		{
			if (_lastError != LeaderboardErrorCode.NotAuthenticated)
			{
				return;
			}
			_leaderboardService.Authenticate(delegate(bool didAuthenticate)
			{
				if (didAuthenticate)
				{
					ReloadLeaderboard();
				}
			});
		}
	}

	private void OnDisable()
	{
		_requestHandle?.Cancel();
	}

	private void ReloadLeaderboard()
	{
		LeaderboardId lastRequestedLeaderboard = _lastRequestedLeaderboard;
		_lastRequestedLeaderboard = null;
		if (lastRequestedLeaderboard != null)
		{
			Log.Info("Forcing a reload of the leaderboard panel for {0}.", lastRequestedLeaderboard);
			ShowLeaderboardFor(_lastRequestedLeaderboardType, lastRequestedLeaderboard);
		}
	}
}
