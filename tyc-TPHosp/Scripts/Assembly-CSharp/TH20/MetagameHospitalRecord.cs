using System.Linq;
using JetBrains.Annotations;

namespace TH20
{
	public class MetagameHospitalRecord
	{
		public class RecordData
		{
			public int HospitalValue { get; set; }

			public int Balance { get; set; }

			public float Reputation { get; set; }

			public int PrestigeLevel { get; set; }

			public int HospitalDateDay { get; set; }

			public int HospitalDateMonth { get; set; }

			public int HospitalDateYear { get; set; }
		}

		public enum StarIndex
		{
			[UsedImplicitly]
			Star1 = 0,
			[UsedImplicitly]
			Star2 = 1,
			[UsedImplicitly]
			Star3 = 2
		}

		private bool _visible;

		private bool _unlocked;

		private bool _playable;

		private bool _hasPlayed;

		private bool _replaying;

		private int _sharesUsed;

		private int _playthroughID;

		private readonly bool[] _stars = new bool[3];

		private readonly bool[] _starsReplay = new bool[3];

		private readonly bool[] _starAwardSeen = new bool[3];

		private bool _remixBadgeAwarded;

		private bool _remixBadgeReplay;

		private bool _remixBadgeAwardSeen;

		private RecordData _data;

		public MetagameHospitalRecord()
		{
			_playthroughID = RandomUtils.GlobalRandomInstance.Next();
		}

		public bool IsVisible()
		{
			return _visible;
		}

		public void SetVisible()
		{
			_visible = true;
		}

		public bool IsUnlocked()
		{
			return _unlocked;
		}

		public void SetUnlocked()
		{
			_unlocked = true;
		}

		public bool IsPlayable()
		{
			return _playable;
		}

		public void SetPlayable()
		{
			_playable = true;
		}

		public bool HasPlayed()
		{
			return _hasPlayed;
		}

		public void SetHasPlayed()
		{
			_hasPlayed = true;
		}

		public RecordData GetRecordData()
		{
			return _data;
		}

		public void SetHospitalValue(int value)
		{
			if (_data == null)
			{
				_data = new RecordData();
			}
			_data.HospitalValue = value;
		}

		public int GetHospitalValue()
		{
			if (_data == null)
			{
				return 0;
			}
			return _data.HospitalValue;
		}

		public void SetHospitalDate(int day, int month, int year)
		{
			if (_data == null)
			{
				_data = new RecordData();
			}
			_data.HospitalDateDay = day;
			_data.HospitalDateMonth = month;
			_data.HospitalDateYear = year;
		}

		public int GetHospitalDateDay()
		{
			if (_data == null)
			{
				return 0;
			}
			return _data.HospitalDateDay;
		}

		public int GetHospitalDateMonth()
		{
			if (_data == null)
			{
				return 0;
			}
			return _data.HospitalDateMonth;
		}

		public int GetHospitalDateYear()
		{
			if (_data == null)
			{
				return 0;
			}
			return _data.HospitalDateYear;
		}

		public void SetBalance(int value)
		{
			if (_data == null)
			{
				_data = new RecordData();
			}
			_data.Balance = value;
		}

		public int GetBalance()
		{
			if (_data == null)
			{
				return 0;
			}
			return _data.Balance;
		}

		public void SetReputation(float value)
		{
			if (_data == null)
			{
				_data = new RecordData();
			}
			_data.Reputation = value;
		}

		public float GetReputation()
		{
			if (_data == null)
			{
				return 0f;
			}
			return _data.Reputation;
		}

		public void SetPrestigeLevel(int value)
		{
			if (_data == null)
			{
				_data = new RecordData();
			}
			_data.PrestigeLevel = value;
		}

		public int GetPrestigeLevel()
		{
			if (_data == null)
			{
				return 0;
			}
			return _data.PrestigeLevel;
		}

		public void SetSharesUsed(int sharesUsed)
		{
			_sharesUsed = sharesUsed;
		}

		public int GetSharesUsed()
		{
			return _sharesUsed;
		}

		public void AwardStar(StarIndex index)
		{
			_stars[(int)index] = true;
			_starsReplay[(int)index] = true;
		}

		public bool HasStarBeenAwarded(int index)
		{
			if (!_replaying)
			{
				return _stars[index];
			}
			return _starsReplay[index];
		}

		public bool HasStarPreviouslyBeenAwarded(int index)
		{
			return _stars[index];
		}

		public void SeenStarAward(int index)
		{
			_starAwardSeen[index] = true;
		}

		public bool HasStarAwardBeenSeen(int index)
		{
			return _starAwardSeen[index];
		}

		public bool IsPendingStarAward(int index)
		{
			if (HasStarAwardBeenSeen(index))
			{
				return !HasStarAwardBeenSeen(index);
			}
			return false;
		}

		public int TotalStars()
		{
			return _stars.Count((bool star) => star);
		}

		public int TotalLevelStars()
		{
			return _starsReplay.Count((bool star) => star);
		}

		public void AwardRemixBadge()
		{
			_remixBadgeAwarded = true;
			_remixBadgeReplay = true;
		}

		public bool HasRemixBadgeBeenAwarded()
		{
			if (!_replaying)
			{
				return _remixBadgeAwarded;
			}
			return _remixBadgeReplay;
		}

		public bool HasRemixBadgePreviouslyBeenAwarded()
		{
			return _remixBadgeAwarded;
		}

		public bool HasSeenRemixBadgeAward()
		{
			return _remixBadgeAwardSeen;
		}

		public void SeenRemixBadgeAward()
		{
			_remixBadgeAwardSeen = true;
		}

		public void Reset()
		{
			_visible = false;
			_playable = false;
			_playthroughID = RandomUtils.GlobalRandomInstance.Next();
			for (int i = 0; i <= 2; i++)
			{
				_stars[i] = false;
				_starsReplay[i] = false;
			}
		}

		public void Replay()
		{
			_replaying = true;
			_playthroughID = RandomUtils.GlobalRandomInstance.Next();
			for (int i = 0; i <= 2; i++)
			{
				_starsReplay[i] = false;
			}
			SetHospitalDate(0, 0, 0);
		}

		public bool IsReplaying()
		{
			return _playable;
		}

		public int LevelPlaythroughID()
		{
			return _playthroughID;
		}
	}
}
