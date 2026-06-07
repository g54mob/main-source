using System;
using System.Collections.Generic;
using Motorways;
using UnityEngine;

public class MotorwaysCityStatistics
{
	private int _maxTrips;

	private int _maxTripsDayCount;

	private int _maxAverageTrips;

	private int _totalTrips;

	private int _maxDuration;

	private int _totalDuration;

	private int _totalPlayTime;

	public string CityId { get; private set; }

	public GameMode Mode { get; private set; }

	public int MaxTrips
	{
		get
		{
			return _maxTrips;
		}
		set
		{
			_maxTrips = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public int MaxTripsDayCount
	{
		get
		{
			return _maxTripsDayCount;
		}
		set
		{
			_maxTripsDayCount = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public int MaxAverageTrips
	{
		get
		{
			return _maxAverageTrips;
		}
		set
		{
			_maxAverageTrips = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public int TotalTrips
	{
		get
		{
			return _totalTrips;
		}
		set
		{
			_totalTrips = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public int MaxDuration
	{
		get
		{
			return _maxDuration;
		}
		set
		{
			_maxDuration = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public int TotalDuration
	{
		get
		{
			return _totalDuration;
		}
		set
		{
			_totalDuration = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public int TotalPlayTime
	{
		get
		{
			return _totalPlayTime;
		}
		set
		{
			_totalPlayTime = value;
			this.DataChanged?.Invoke(this);
		}
	}

	public event Action<MotorwaysCityStatistics> DataChanged;

	public void InitWithCityIdAndMode(string cityId, GameMode mode)
	{
		CityId = cityId;
		Mode = mode;
	}

	public void InitFromJson(JSON.Dictionary jsonDictionary)
	{
		if (jsonDictionary == null)
		{
			return;
		}
		CityId = jsonDictionary.GetString("CityId") ?? "";
		string text = jsonDictionary.GetString("Mode");
		if (!string.IsNullOrEmpty(text))
		{
			if (Diagnostics.Verify(Enum.TryParse<GameMode>(text, out var result), "{0} is not a valid game mode! Setting to Normal.", text))
			{
				Mode = result;
			}
			else
			{
				Mode = GameMode.Normal;
			}
		}
		_maxTrips = jsonDictionary.GetInt("MaxTrips");
		_maxTripsDayCount = jsonDictionary.GetInt("MaxTripsDayCount");
		_maxAverageTrips = jsonDictionary.GetInt("MaxAverageTrips");
		_totalTrips = jsonDictionary.GetInt("TotalTrips");
		_maxDuration = jsonDictionary.GetInt("MaxDuration");
		_totalDuration = jsonDictionary.GetInt("TotalDuration");
		_totalPlayTime = jsonDictionary.GetInt("TotalPlayTime");
	}

	public void RecordGameStatistics(MotorwaysGameStatistics motorwaysGameStatistics)
	{
		RecordCumulativeGameStatistics(motorwaysGameStatistics);
		if (motorwaysGameStatistics.TotalTrips > MaxTrips)
		{
			MaxTrips = motorwaysGameStatistics.TotalTrips;
			MaxTripsDayCount = motorwaysGameStatistics.TotalDuration;
		}
		MaxAverageTrips = Mathf.Max(MaxAverageTrips, motorwaysGameStatistics.PeakAverageTrips);
		MaxDuration = Mathf.Max(MaxDuration, motorwaysGameStatistics.TotalDuration);
	}

	public void RecordCumulativeGameStatistics(MotorwaysGameStatistics motorwaysGameStatistics)
	{
		TotalTrips += motorwaysGameStatistics.NewTrips;
		TotalDuration += motorwaysGameStatistics.NewDuration;
		TotalPlayTime += motorwaysGameStatistics.NewPlayTime;
	}

	public void Merge(MotorwaysCityStatistics otherStatistics)
	{
		MaxTrips = Mathf.Max(MaxTrips, otherStatistics.MaxTrips);
		MaxTripsDayCount = Mathf.Max(MaxTripsDayCount, otherStatistics.MaxTripsDayCount);
		MaxAverageTrips = Mathf.Max(MaxAverageTrips, otherStatistics.MaxAverageTrips);
		TotalTrips = Mathf.Max(TotalTrips, otherStatistics.TotalTrips);
		MaxDuration = Mathf.Max(MaxDuration, otherStatistics.MaxDuration);
		TotalDuration = Mathf.Max(TotalDuration, otherStatistics.TotalDuration);
		TotalPlayTime = Mathf.Max(TotalPlayTime, otherStatistics.TotalPlayTime);
	}

	public object ToJson()
	{
		return new Dictionary<string, object>
		{
			["CityId"] = CityId,
			["Mode"] = Mode.ToString(),
			["MaxTrips"] = MaxTrips,
			["MaxTripsDayCount"] = MaxTripsDayCount,
			["MaxAverageTrips"] = MaxAverageTrips,
			["TotalTrips"] = TotalTrips,
			["MaxDuration"] = MaxDuration,
			["TotalDuration"] = TotalDuration,
			["TotalPlayTime"] = TotalPlayTime
		};
	}
}
