using System;
using UnityEngine;

public class VideoFailManager
{
	private IHasVideoThatCanFail _videoFailObject;

	private float _timeTilFailMinInitial;

	private float _timeTilFailMaxInitial;

	private float _timeTilFailMinRepeat;

	private float _timeTilFailMaxRepeat;

	private float _failDurationMinInitial;

	private float _failDurationMaxInitial;

	private float _timeTilFailWarningMin;

	private float _timeTilFailWarningMax;

	protected static System.Random _random = new System.Random();

	private VideoFailManager()
	{
	}

	public VideoFailManager(IHasVideoThatCanFail videoFailObject, float timeTilFailMinInitial, float timeTilFailMaxInitial, float timeTilFailMinRepeat, float timeTilFailMaxRepeat, float failDurationMinInitial, float failDurationMaxInitial, float timeTilFailWarningMin, float timeTilFailWarningMax)
		: this(videoFailObject)
	{
		_timeTilFailMinInitial = timeTilFailMinInitial;
		_timeTilFailMaxInitial = timeTilFailMaxInitial;
		_timeTilFailMinRepeat = timeTilFailMinRepeat;
		_timeTilFailMaxRepeat = timeTilFailMaxRepeat;
		_failDurationMinInitial = failDurationMinInitial;
		_failDurationMaxInitial = failDurationMaxInitial;
		_timeTilFailWarningMin = timeTilFailWarningMin;
		_timeTilFailWarningMax = timeTilFailWarningMax;
		CalcInitialVideoSignalLossInfo();
	}

	public VideoFailManager(IHasVideoThatCanFail videoFailObject)
	{
		_videoFailObject = videoFailObject;
	}

	public void CalcInitialVideoSignalLossInfo()
	{
		if (_timeTilFailMinRepeat == 0f && _timeTilFailMaxRepeat == 0f)
		{
			Debug.LogError("CalcInitialVideoSignalLossInfo() called most likely after the wrong constructor was used...");
		}
		_videoFailObject.VideoSignalLost = false;
		_videoFailObject.TimeOfNextVideoLoss = _videoFailObject.TimePassed + _random.NextFloat(_timeTilFailMinInitial, _timeTilFailMaxInitial);
		_videoFailObject.TimeOfNextWarningVideoLoss = _videoFailObject.TimeOfNextVideoLoss - _random.NextFloat(_timeTilFailWarningMin, _timeTilFailWarningMax);
		_videoFailObject.VideoLossDuration = _random.NextFloat(_failDurationMinInitial, _failDurationMaxInitial);
		_videoFailObject.TimeTilNextFailMin = _timeTilFailMinRepeat;
		_videoFailObject.TimeTilNextFailMax = _timeTilFailMaxRepeat;
		_videoFailObject.TimeOfNextVideoRestore = _videoFailObject.TimeOfNextVideoLoss + _videoFailObject.VideoLossDuration;
	}

	private void CalcTimeToNextVideoSignalLost()
	{
		_videoFailObject.VideoSignalLost = false;
		_videoFailObject.TimeOfNextVideoLoss = _videoFailObject.TimePassed + _random.NextFloat(_videoFailObject.TimeTilNextFailMin, _videoFailObject.TimeTilNextFailMax);
		_videoFailObject.TimeOfNextWarningVideoLoss = _videoFailObject.TimeOfNextVideoLoss - _random.NextFloat(_timeTilFailWarningMin, _timeTilFailWarningMax);
		if (_videoFailObject.VideoLossDuration > 0f)
		{
			_videoFailObject.VideoLossDuration += 15f;
		}
		_videoFailObject.TimeOfNextVideoRestore = _videoFailObject.TimeOfNextVideoLoss + _videoFailObject.VideoLossDuration;
		_videoFailObject.TimeTilNextFailMin -= 60f;
		_videoFailObject.TimeTilNextFailMax -= 60f;
		_videoFailObject.TimeTilNextFailMin = Mathf.Max(_videoFailObject.TimeTilNextFailMin, 60f);
		_videoFailObject.TimeTilNextFailMax = Mathf.Max(_videoFailObject.TimeTilNextFailMax, 60f);
	}

	public void Update()
	{
		if (!_videoFailObject.VideoSignalLost && _videoFailObject.TimeOfNextVideoLoss == 0f)
		{
			CalcTimeToNextVideoSignalLost();
		}
		if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
		{
			_videoFailObject.TimeOfNextVideoLoss += Time.deltaTime;
			_videoFailObject.TimeOfNextWarningVideoLoss = _videoFailObject.TimeOfNextVideoLoss - _random.NextFloat(_timeTilFailWarningMin, _timeTilFailWarningMax);
			_videoFailObject.TimeOfNextVideoRestore += Time.deltaTime;
		}
		else if (_videoFailObject.VideoSignalLost)
		{
			if (_videoFailObject is DungeonInfo && ((DungeonInfo)_videoFailObject).VideoSignalLostWarning)
			{
				((DungeonInfo)_videoFailObject).TimerVideoSignalLostWarning -= Time.deltaTime;
				if (((DungeonInfo)_videoFailObject).TimerVideoSignalLostWarning <= 0f)
				{
					_videoFailObject.VideoSignalLost = false;
					((DungeonInfo)_videoFailObject).VideoSignalLostWarningTemp = false;
					((DungeonInfo)_videoFailObject).VideoSignalLostWarning = false;
				}
			}
			if (_videoFailObject.TimePassed >= _videoFailObject.TimeOfNextVideoRestore)
			{
				_videoFailObject.VideoSignalLost = false;
				CalcTimeToNextVideoSignalLost();
			}
		}
		else if (_videoFailObject.TimePassed >= _videoFailObject.TimeOfNextVideoLoss)
		{
			_videoFailObject.VideoSignalLost = true;
			if (_videoFailObject is IDrone)
			{
				IDrone drone = (IDrone)_videoFailObject;
				UniverseSaveFile.Save(string.Format("DRONE_{0}", drone.InternalID), "HASFAILED", true);
			}
			else if (_videoFailObject is DungeonInfo)
			{
				((DungeonInfo)_videoFailObject).VideoSignalLostWarningShown = false;
			}
		}
		else if (_videoFailObject is DungeonInfo && !((DungeonInfo)_videoFailObject).VideoSignalLostWarningShown && _videoFailObject.TimePassed >= _videoFailObject.TimeOfNextWarningVideoLoss)
		{
			((DungeonInfo)_videoFailObject).VideoSignalLostWarning = true;
			((DungeonInfo)_videoFailObject).VideoSignalLostWarningShown = true;
			((DungeonInfo)_videoFailObject).VideoSignalLostWarningTemp = true;
			((DungeonInfo)_videoFailObject).TimerVideoSignalLostWarning = 1f;
			_videoFailObject.VideoSignalLost = true;
		}
	}
}
