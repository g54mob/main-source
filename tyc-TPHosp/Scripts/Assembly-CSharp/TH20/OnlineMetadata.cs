using System;
using System.Collections.Generic;
using FullSerializerSave;
using UnityEngine;

namespace TH20
{
	public class OnlineMetadata : OnlineManager.IOnlineSerializable
	{
		public class ChallengeScore
		{
			public int Score;

			public uint TimeStamp;

			public List<OnlinePlayerID> Rivals;
		}

		public enum ChallengeStatus
		{
			ChallengedYou = 0,
			StartedChallenge = 1,
			ChallengedAndBeat = 2,
			ChallengedAndDidntBeat = 3,
			DrewWithYourScore = 4,
			FinishedTheChallenge = 5
		}

		[fsProperty("st")]
		[SerializeField]
		private readonly Dictionary<LevelConfig, MetagameHospitalRecord.StarIndex> _stars = new Dictionary<LevelConfig, MetagameHospitalRecord.StarIndex>();

		[fsProperty("rb")]
		[SerializeField]
		private readonly Dictionary<LevelConfig, bool> _remixBadges = new Dictionary<LevelConfig, bool>();

		[fsProperty("ch")]
		[SerializeField]
		private readonly Dictionary<string, ChallengeScore> _challengeScores = new Dictionary<string, ChallengeScore>();

		[fsProperty("stat ")]
		[SerializeField]
		private readonly Dictionary<int, int> _statCollection = new Dictionary<int, int>();

		[fsProperty("lp")]
		[SerializeField]
		private readonly List<LevelConfig> _levelsPlayed = new List<LevelConfig>();

		[fsProperty("lpl")]
		[SerializeField]
		private LevelConfig _lastPlayedLevel;

		[fsProperty("lu")]
		[SerializeField]
		private uint _lastUpdateTime;

		[fsProperty("vis")]
		[SerializeField]
		private bool _onlineVisibility = true;

		[NonSerialized]
		private BaseOnlineDataFile _uploadFile;

		[NonSerialized]
		private float _uploadTimer;

		[NonSerialized]
		private bool _shouldUpload;

		[NonSerialized]
		private float _uploadInterval = 10f;

		public Dictionary<string, ChallengeScore> ChallengeScores => _challengeScores;

		public uint LastUpdateTime => _lastUpdateTime;

		public LevelConfig LastPlayedLevel => _lastPlayedLevel;

		public static ChallengeStatus GetFriendOnlineChallengeStatus(OnlinePlayerID friendSteamId, bool isChallengeFinished, float playerScore, float rivalScore, bool challengedMe)
		{
			if (!isChallengeFinished)
			{
				if (challengedMe)
				{
					return ChallengeStatus.ChallengedYou;
				}
				return ChallengeStatus.StartedChallenge;
			}
			if (playerScore > 0f)
			{
				if (rivalScore > playerScore)
				{
					return ChallengeStatus.ChallengedAndBeat;
				}
				if (rivalScore < playerScore)
				{
					return ChallengeStatus.ChallengedAndDidntBeat;
				}
				return ChallengeStatus.DrewWithYourScore;
			}
			return ChallengeStatus.FinishedTheChallenge;
		}

		public void LinkUploadFile(BaseOnlineDataFile uploadFile)
		{
			_uploadFile = uploadFile;
		}

		public void LogStarProgress(LevelConfig levelConfig, MetagameHospitalRecord.StarIndex numStars)
		{
			_stars.TryGetValue(levelConfig, out var value);
			if (value < numStars)
			{
				_stars[levelConfig] = numStars;
				Upload();
			}
		}

		public void LogRemixBadgeAwarded(LevelConfig levelConfig)
		{
			_remixBadges.TryGetValue(levelConfig, out var value);
			if (!value)
			{
				_remixBadges[levelConfig] = true;
				Upload();
			}
		}

		public void LogOnlineChallengeScore(string challengeID, int score, List<OnlinePlayerID> rivals)
		{
			if (!_challengeScores.TryGetValue(challengeID, out var value) || value.Score < score)
			{
				_challengeScores[challengeID] = new ChallengeScore
				{
					Score = score,
					TimeStamp = OnlineManager.GetServerTime(),
					Rivals = rivals
				};
				Upload();
			}
		}

		public void LogLastPlayedLevel(LevelConfig levelConfig)
		{
			_lastPlayedLevel = levelConfig;
			_levelsPlayed.AddUnique(levelConfig);
			Upload();
		}

		public bool GetStarProgress(LevelConfig levelConfig, out MetagameHospitalRecord.StarIndex starScore)
		{
			return _stars.TryGetValue(levelConfig, out starScore);
		}

		public bool GetChallengeScore(string challengeID, out ChallengeScore score)
		{
			if (challengeID == null)
			{
				score = new ChallengeScore();
				return false;
			}
			return _challengeScores.TryGetValue(challengeID, out score);
		}

		public bool HasPlayedLevel(LevelConfig levelConfig)
		{
			return _levelsPlayed.Contains(levelConfig);
		}

		public void SetStat(string name, int value)
		{
			_statCollection[name.GetHashCode()] = value;
		}

		public bool GetStat(string name, out int value)
		{
			return _statCollection.TryGetValue(name.GetHashCode(), out value);
		}

		public void SetIsVisible(bool value)
		{
			if (value != _onlineVisibility)
			{
				_onlineVisibility = value;
				if (_uploadFile != null)
				{
					_uploadFile.Serialize(this);
					_uploadFile.ForceUpload();
				}
			}
		}

		public bool IsVisible()
		{
			return _onlineVisibility;
		}

		public void Upload(bool immediately = false)
		{
			if (_onlineVisibility && _uploadFile != null)
			{
				_uploadFile.Serialize(this);
				if (immediately)
				{
					_uploadFile.ForceUpload();
				}
			}
		}

		public void Update()
		{
		}

		public void PrepareForUpload()
		{
			_lastUpdateTime = OnlineManager.GetServerTime();
		}

		public void RestoreAfterDownload()
		{
		}
	}
}
