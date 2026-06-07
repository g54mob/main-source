using System;
using System.Collections.Generic;
using Factory;
using Motorways;
using Motorways.Leaderboards;
using UnityEngine;

public class MotorwaysTimedChallengeScore
{
	private const int NoScoreRecorded = -1;

	private const int InvalidExpiry = 0;

	[Dependency]
	private ChallengeSystem _challengeSystem;

	private int _expiry;

	private bool _isScoreLocked;

	private DateTime _scoreLockedDateTime;

	private MapChallenge.ChallengeType _challengeType;

	public int Score { get; private set; } = -1;

	public int Expiry => _expiry;

	public bool HasScoreExpired => _expiry < _challengeSystem.CurrentTimestamp;

	public LeaderboardScoreState ScoreState
	{
		get
		{
			if (Score == -1 || HasScoreExpired)
			{
				return LeaderboardScoreState.NotSubmitted;
			}
			if (!_isScoreLocked)
			{
				return LeaderboardScoreState.Editable;
			}
			return LeaderboardScoreState.Locked;
		}
	}

	public event Action<MotorwaysTimedChallengeScore> DataChanged;

	public void LockScore()
	{
		if (_challengeType != MapChallenge.ChallengeType.Daily)
		{
			Diagnostics.FailAssert("Tried locking score with type {0}. Only daily challenge score should be locked.", _challengeType);
		}
		else
		{
			_isScoreLocked = true;
			_scoreLockedDateTime = GameDateTime.UtcNow;
			this.DataChanged?.Invoke(this);
		}
	}

	public void Init(MapChallenge.ChallengeType challengeType, int expiry)
	{
		_challengeType = challengeType;
		_expiry = expiry;
		Score = -1;
		_isScoreLocked = false;
		_scoreLockedDateTime = DateTime.MinValue;
		this.DataChanged?.Invoke(this);
	}

	public void InitFromJson(JSON.Dictionary jsonDictionary, MapChallenge.ChallengeType challengeType)
	{
		if (jsonDictionary != null)
		{
			_challengeType = challengeType;
			_expiry = jsonDictionary.GetInt("_expiry");
			Score = jsonDictionary.GetInt("Score", -1);
			_isScoreLocked = jsonDictionary.GetBool("_isScoreLocked");
			_scoreLockedDateTime = jsonDictionary.GetDateTime("_scoreLockedDateTime");
		}
	}

	public object ToJson()
	{
		return new Dictionary<string, object>
		{
			["_expiry"] = _expiry,
			["Score"] = Score,
			["_isScoreLocked"] = _isScoreLocked,
			["_scoreLockedDateTime"] = _scoreLockedDateTime
		};
	}

	public void UpdateGameScore(int newScore, GameEndReason? gameEndReason)
	{
		if (HasScoreExpired)
		{
			Diagnostics.FailAssert("UpdateGameScore should never be called on expired score.");
			return;
		}
		int score = Score;
		if (MotorwaysScoreValidation.ShouldRecordScore(_isScoreLocked, score, newScore))
		{
			bool flag = gameEndReason.HasValue && MotorwaysScoreValidation.ShouldLockScoreWhenGameEnds(_challengeType, gameEndReason.Value);
			Score = newScore;
			if (!_isScoreLocked && flag)
			{
				_isScoreLocked = true;
				_scoreLockedDateTime = GameDateTime.UtcNow;
			}
			this.DataChanged?.Invoke(this);
		}
	}

	public void Merge(MotorwaysTimedChallengeScore otherScore)
	{
		if (_expiry == 0 && otherScore._expiry == 0)
		{
			return;
		}
		if (_expiry < otherScore._expiry)
		{
			_expiry = otherScore._expiry;
			_isScoreLocked = otherScore._isScoreLocked;
			_scoreLockedDateTime = otherScore._scoreLockedDateTime;
			Score = otherScore.Score;
		}
		else
		{
			if (_expiry != otherScore._expiry)
			{
				return;
			}
			if (_challengeType == MapChallenge.ChallengeType.Weekly)
			{
				Score = Mathf.Max(Score, otherScore.Score);
			}
			else if (_challengeType != MapChallenge.ChallengeType.Daily)
			{
				Diagnostics.FailAssert("Unknown challenge type while merging MotorwaysTimedChallengeScore");
			}
			else if (!_isScoreLocked && !otherScore._isScoreLocked)
			{
				if (Score == -1 && otherScore.Score != -1)
				{
					Score = otherScore.Score;
				}
			}
			else if (!_isScoreLocked && otherScore._isScoreLocked)
			{
				Score = otherScore.Score;
				_isScoreLocked = true;
				_scoreLockedDateTime = otherScore._scoreLockedDateTime;
			}
			else if (_isScoreLocked && otherScore._isScoreLocked && otherScore._scoreLockedDateTime < _scoreLockedDateTime)
			{
				Score = otherScore.Score;
				_scoreLockedDateTime = otherScore._scoreLockedDateTime;
			}
		}
	}
}
