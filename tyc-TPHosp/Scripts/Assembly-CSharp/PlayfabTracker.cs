using TH20;
using TMPro;
using UnityEngine;

public class PlayfabTracker : MonoBehaviour
{
	[SerializeField]
	private GameObject _root;

	[SerializeField]
	private TextMeshProUGUI _timeSpentLabel;

	[SerializeField]
	private TextMeshProUGUI _setDataCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _setDataSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _setDataAverageSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getDataCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _getDataSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getDataAverageSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _setStatsCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _setStatsSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _setStatsAverageSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getStatsCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _getStatsSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getStatsAverageSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getLeaderboardCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _getLeaderboardSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getLeaderboardAverageSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getPlayFabIDsFromGenericIDsCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _getPlayFabIDsFromGenericIDsSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _getPlayFabIDsFromGenericIDsAverageSizeLabel;

	[SerializeField]
	private TextMeshProUGUI _totalsCallsLabel;

	[SerializeField]
	private TextMeshProUGUI _totalsSizeLabel;

	private bool _visible;

	private bool _loggedIn;

	private float _loggedInTimeTotalSeconds;

	private int _numSetDataCallsMade;

	private int _numGetDataCallsMade;

	private int _numSetPlayerStatsCallsMade;

	private int _numGetPlayerStatsCallsMade;

	private int _numGetLeaderboardCallsMade;

	private int _numGetPlayFabIDsFromGenericIDsCallsMade;

	private int _sizeOfSetData;

	private int _sizeOfGotData;

	private int _sizeOfSetPlayerStats;

	private int _sizeOfGotPlayerStats;

	private int _sizeOfGotLeaderboards;

	private int _sizeOfGotPlayFabIDsFromGenericIDs;

	private readonly string[] _byteSuffixes = new string[4] { "B", "KB", "MB", "GB" };

	private const int bytesPerMb = 1024;

	private App _app;

	public static PlayfabTracker Instance { get; private set; }
}
