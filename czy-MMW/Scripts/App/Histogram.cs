using System.Collections.Generic;
using Easing;
using Factory;
using JetBrains.Annotations;
using Motorways;
using Motorways.Leaderboards;
using Motorways.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Histogram : MonoBehaviour
{
	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("HistogramPanel");

	[SerializeField]
	private RectTransform _columnParent;

	[SerializeField]
	private List<HistogramColumn> _columns = new List<HistogramColumn>();

	[SerializeField]
	private RectTransform _indicatorNotchRect;

	[SerializeField]
	private HorizontalLayoutGroup _indicatorNotchLayoutGroup;

	[SerializeField]
	private LocalizedTextUI _cityText;

	[SerializeField]
	private LocalizedTextUI _highScoreText;

	[SerializeField]
	private LocalizedTextUI _youText;

	[SerializeField]
	private RectTransform _youBar;

	[SerializeField]
	private List<RectTransform> _indicatorNotches = new List<RectTransform>();

	[SerializeField]
	private List<TextMeshProUGUI> _indicatorNotchTexts = new List<TextMeshProUGUI>();

	[SerializeField]
	[Tooltip("How large a bucket at the end of the histogram has to be to avoid being pruned, relative to the histogram's biggest bucket.")]
	private float _minBucketSizeRelativeToMax = 0.008f;

	[Tooltip("How long a column takes to tween in if it has a value of 0.")]
	[SerializeField]
	private float _minColumnTweenDuration = 0.1f;

	[SerializeField]
	[Tooltip("How long a column takes to tween in if it has the highest value across the graph.")]
	private float _maxColumnTweenDuration = 0.9f;

	[SerializeField]
	[Tooltip("How long to wait between start each column's animation.")]
	private float _columnTweenDelay = 0.02f;

	[SerializeField]
	private Easings.Functions _columnTweenEasingType;

	private IScope _scope;

	private MapSelectScreen _mapSelectScreen;

	private LeaderboardService _leaderboardService;

	private MotorwaysThemeDatabase _themeDatabase;

	private AsyncRequestHandle _requestHandle;

	private readonly List<int> _buckets = new List<int>();

	private int _bucketRange;

	[SerializeField]
	private LeaderboardPanel _leaderboardPanel;

	[Dependency]
	private ActivePlayer _player;

	private MapDatabase _mapDatabase;

	private static readonly int[] MaxNotchMultiples = new int[4] { 500, 250, 150, 50 };

	public void Initialize(IScope scope)
	{
		_scope = scope;
		_player = _scope.Get<ActivePlayer>();
		_themeDatabase = scope.Get<MotorwaysThemeDatabase>();
		_leaderboardService = scope.Get<LeaderboardService>();
		_mapSelectScreen = scope.Get<MapSelectScreen>();
		_mapDatabase = scope.Get<MapDatabase>();
		Clear();
	}

	private void Clear()
	{
		for (int i = 0; i < _indicatorNotches.Count; i++)
		{
			_indicatorNotches[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < _columns.Count; j++)
		{
			_columns[j].RectTransform.sizeDelta = new Vector2(0f, 0f);
			_columns[j].SubRectTransform.sizeDelta = new Vector2(0f, 0f);
		}
		_youText.gameObject.SetActive(value: false);
		Vector3 vector = _youBar.anchoredPosition;
		vector.x = 0f;
		_youBar.anchoredPosition = vector;
		_youBar.gameObject.SetActive(value: false);
	}

	public void ShowHistogram(LeaderboardId leaderboardId)
	{
		Clear();
		BuildAHistogram(leaderboardId);
	}

	private void BuildAHistogram(LeaderboardId leaderboardId)
	{
		_requestHandle?.Cancel();
		_leaderboardPanel.ErrorText.gameObject.SetActive(value: false);
		_leaderboardPanel.SetLoadingSpinnerEnabled(isLoading: true);
		if (leaderboardId is CityLeaderboardId cityLeaderboardId)
		{
			MapDefinition mapByName = _mapDatabase.MapLibrary.GetMapByName(cityLeaderboardId.City.ToString());
			if (Diagnostics.Verify(mapByName != null))
			{
				_cityText.SetStringId(_scope, mapByName.mapName);
			}
		}
		else if (leaderboardId is DailyLeaderboardId)
		{
			_cityText.SetStringId(_scope, StringId.DailyChallenge);
		}
		else if (leaderboardId is WeeklyLeaderboardId)
		{
			_cityText.SetStringId(_scope, StringId.WeeklyChallenge);
		}
		_highScoreText.LocString = null;
		_requestHandle = _leaderboardService.RequestHistogram(leaderboardId, delegate(List<int> buckets, int size, LeaderboardError error)
		{
			if (error == null && buckets != null && buckets.Count > 0 && size > 0)
			{
				_bucketRange = size;
				GenerateBuckets(buckets);
				OnHistogramRetrieved(leaderboardId);
			}
			else
			{
				Log.Warn("Failed to get histogram data.\n{0}", error);
				_leaderboardPanel.OnHistogramFailed(error);
			}
		});
	}

	private void LocalEntryRequestCompleted(LeaderboardEntry localEntry, long totalLeaderboardEntryCount, LeaderboardError error)
	{
		if (error != null || localEntry == null)
		{
			OnEntryRequestComplete(null, totalLeaderboardEntryCount);
		}
		else
		{
			OnEntryRequestComplete(localEntry, totalLeaderboardEntryCount);
		}
		_mapSelectScreen.RegisterThemeComponents(_themeDatabase.GetTheme());
		_mapSelectScreen.ApplyTheme(_themeDatabase.GetTheme());
	}

	private void OnEntryRequestComplete(LeaderboardEntry localEntry, long totalLeaderboardEntryCount)
	{
		if (localEntry == null || localEntry.Rank <= 0 || localEntry.Score < 0)
		{
			_youText.gameObject.SetActive(value: false);
			_youBar.gameObject.SetActive(value: false);
			_highScoreText.LocString = StandaloneLocString.CreateNonLocalizedString(_scope, "-");
		}
		else
		{
			_youText.LocString = localEntry.FormatLocalUserString(_scope, totalLeaderboardEntryCount, LeaderboardEntryFormatOptions.BoldYou | LeaderboardEntryFormatOptions.MultiLine | LeaderboardEntryFormatOptions.IncludePercentileInTopTen);
			int score = localEntry.Score;
			_highScoreText.LocString = StandaloneLocString.CreateLocalizedNumberString(_scope, score);
			float t = 1f;
			float endRange = _columns[_columns.Count - 1].EndRange;
			if ((float)score < endRange)
			{
				t = (float)score / endRange;
			}
			float num = _youBar.rect.width * 0.5f;
			float num2 = Mathf.Lerp(num, _columnParent.rect.width - num, t);
			ConstrainCenteredText(_youText.TextField, num2, _columnParent.rect.width);
			Vector3 vector = _youBar.anchoredPosition;
			vector.x = num2;
			_youBar.anchoredPosition = vector;
			_youText.gameObject.SetActive(value: true);
			_youBar.gameObject.SetActive(value: true);
		}
		_leaderboardPanel.OnHistogramSucceeded();
	}

	private void GenerateBuckets([NotNull] List<int> rawBuckets)
	{
		_buckets.Clear();
		_buckets.Capacity = rawBuckets.Count;
		int num = 0;
		int count = rawBuckets.Count;
		for (int i = 0; i < count; i++)
		{
			int num2 = rawBuckets[i];
			_buckets.Add(num2);
			num = Mathf.Max(num, num2);
		}
		int num3 = Mathf.CeilToInt((float)num * _minBucketSizeRelativeToMax);
		int j;
		for (j = 0; j < _buckets.Count && _buckets[_buckets.Count - 1 - j] < num3; j++)
		{
		}
		if (j > 0)
		{
			_buckets.RemoveRange(_buckets.Count - 1 - j, j);
		}
	}

	private void OnHistogramRetrieved(LeaderboardId leaderboardId)
	{
		if (_buckets.Count < _columns.Count)
		{
			_leaderboardPanel.OnHistogramFailed(null);
			return;
		}
		float height = _columnParent.rect.height;
		int count = _buckets.Count;
		float num = _bucketRange;
		float num2 = num * (float)count;
		int count2 = _columns.Count;
		float num3 = num2 / (float)count2;
		float num4 = 0f;
		for (int i = 0; i < _columns.Count; i++)
		{
			float num5 = (float)i * num3;
			float num6 = (float)(i + 1) * num3;
			int num7 = Mathf.FloorToInt(num5 / num);
			float num8 = num5 / num - (float)num7;
			int num9 = Mathf.FloorToInt(num6 / num);
			float num10 = num6 / num - (float)num9;
			if (num9 >= count)
			{
				num9 = count - 1;
				num10 = 1f;
			}
			float num11 = (float)_buckets[num7] * (1f - num8);
			for (int j = num7 + 1; j <= num9; j++)
			{
				num11 += (float)_buckets[j];
			}
			num11 -= (float)_buckets[num9] * (1f - num10);
			_columns[i].Initialise(num5, num6, num11, i % 2 == 1);
			_columns[i].RectTransform.sizeDelta = new Vector2(0f, height);
			num4 = Mathf.Max(num11, num4);
		}
		for (int k = 0; k < _columns.Count; k++)
		{
			HistogramColumn histogramColumn = _columns[k];
			float num12 = histogramColumn.NumberOfEntries / num4;
			histogramColumn.SetHeight(num12 * height, Mathf.Lerp(_minColumnTweenDuration, _maxColumnTweenDuration, num12), _columnTweenDelay * (float)k, _columnTweenEasingType);
		}
		_columnParent.GetComponent<HorizontalLayoutGroup>().enabled = false;
		_columnParent.GetComponent<HorizontalLayoutGroup>().enabled = true;
		int num13 = CalculateNotchIncrement(num2);
		for (int l = 0; l < _indicatorNotchTexts.Count; l++)
		{
			_indicatorNotchTexts[l].text = $"{l * num13}";
		}
		float num14 = (float)(num13 * (_indicatorNotches.Count - 1)) / num2;
		float width = _indicatorNotches[0].rect.width;
		float num15 = _indicatorNotchRect.rect.width * num14;
		float num16 = num15 - width * (float)_indicatorNotches.Count;
		_indicatorNotchLayoutGroup.spacing = num16 / (float)(_indicatorNotches.Count - 1);
		foreach (RectTransform indicatorNotch in _indicatorNotches)
		{
			indicatorNotch.gameObject.SetActive(value: true);
		}
		float num17 = _indicatorNotchTexts[0].GetPreferredValues().x * 0.5f;
		float center = num15 - width * 0.5f;
		ConstrainCenteredText(_indicatorNotchTexts[_indicatorNotchTexts.Count - 1], center, _columnParent.rect.width + num17 - width * 0.5f);
		_requestHandle = _leaderboardService.RequestLocalEntry(leaderboardId, LocalEntryRequestCompleted);
	}

	private int CalculateNotchIncrement(float maxScore)
	{
		int num = 0;
		int[] maxNotchMultiples = MaxNotchMultiples;
		foreach (int num2 in maxNotchMultiples)
		{
			int num3 = Mathf.FloorToInt(maxScore / (float)num2) * num2;
			num = num3 / (_indicatorNotches.Count - 1);
			if ((float)num > maxScore - (float)num3)
			{
				break;
			}
		}
		return num;
	}

	private static void ConstrainCenteredText(TMP_Text text, float center, float maxHorizontalConstraint)
	{
		float x = 0f;
		float num = text.GetPreferredValues().x * 0.5f;
		if (num > center)
		{
			x = num - center;
		}
		else if (num > maxHorizontalConstraint - center)
		{
			x = maxHorizontalConstraint - center - num;
		}
		RectTransform component = text.gameObject.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(x, component.anchoredPosition.y);
	}

	private void OnDisable()
	{
		_requestHandle?.Cancel();
	}
}
