using System;
using UnityEngine;

namespace Jundroo.SocialPlatforms.Achievements
{
	[Serializable]
	public class AchievementInfo
	{
		[Serializable]
		public class SupportedPlatforms
		{
			[SerializeField]
			private bool _gameCenter;

			[SerializeField]
			private bool _gog;

			[SerializeField]
			private bool _googlePlay;

			[SerializeField]
			private bool _steam;

			public bool GameCenter
			{
				get
				{
					return _gameCenter;
				}
				set
				{
					_gameCenter = value;
				}
			}

			public bool Gog
			{
				get
				{
					return _gog;
				}
				set
				{
					_gog = value;
				}
			}

			public bool GooglePlay
			{
				get
				{
					return _googlePlay;
				}
				set
				{
					_googlePlay = value;
				}
			}

			public bool Steam
			{
				get
				{
					return _steam;
				}
				set
				{
					_steam = value;
				}
			}

			public SupportedPlatforms()
			{
				GameCenter = true;
				Gog = true;
				GooglePlay = true;
				Steam = true;
			}
		}

		[Header("Basic Info")]
		[SerializeField]
		private string _name;

		[SerializeField]
		private string _description;

		[SerializeField]
		private bool _hidden;

		[SerializeField]
		private double _minValue;

		[SerializeField]
		private double _maxValue;

		[SerializeField]
		private int _points;

		[Header("Identifiers")]
		[SerializeField]
		private AchievementKey _key;

		[SerializeField]
		private string _gameCenterId = string.Empty;

		[SerializeField]
		private string _googlePlayGamesId = string.Empty;

		[SerializeField]
		private string _steamId = string.Empty;

		[SerializeField]
		private string _steamStatId = string.Empty;

		[SerializeField]
		private SteamStatDataType _steamStatDataType;

		[Space]
		[SerializeField]
		private SupportedPlatforms _supportedPlatforms = new SupportedPlatforms();

		public string Description => _description;

		public string GameCenterId => _gameCenterId;

		public string GooglePlayGamesId => _googlePlayGamesId;

		public bool Hidden => _hidden;

		public string Id
		{
			get
			{
				string result = Name;
				if (SocialExt.IsSteam || SocialExt.IsGog)
				{
					result = SteamId;
				}
				else if (SocialExt.IsGameCenter)
				{
					result = GameCenterId;
				}
				else if (SocialExt.IsGooglePlayGames)
				{
					result = GooglePlayGamesId;
				}
				return result;
			}
		}

		public AchievementKey Key => _key;

		public double MaxValue => _maxValue;

		public double MinValue => _minValue;

		public string Name => _name;

		public SupportedPlatforms Platforms => _supportedPlatforms;

		public int Points => _points;

		public string StatId
		{
			get
			{
				string result = Key.ToString();
				if (SocialExt.IsSteam || SocialExt.IsGog)
				{
					result = SteamStatId;
				}
				return result;
			}
		}

		public string SteamId => _steamId;

		public SteamStatDataType SteamStatDataType => _steamStatDataType;

		public string SteamStatId => _steamStatId;

		public float GetFloatProgress(double percentageComplete)
		{
			return (float)GetDoubleProgress(percentageComplete);
		}

		public float GetFloatProgress(double percentageComplete, double incrementAmount)
		{
			return (float)GetDoubleProgress(percentageComplete) + (float)incrementAmount;
		}

		public int GetIntProgress(double percentageComplete)
		{
			return Mathf.RoundToInt((float)GetDoubleProgress(percentageComplete));
		}

		public int GetIntProgress(double percentageComplete, double incrementAmount)
		{
			return GetIntProgress(percentageComplete) + Mathf.RoundToInt((float)incrementAmount);
		}

		public double GetValueRange()
		{
			double num = Math.Abs(MaxValue - MinValue);
			if (num == 0.0)
			{
				num = 1.0;
			}
			return num;
		}

		private double GetDoubleProgress(double percentageComplete)
		{
			return percentageComplete / 100.0 * GetValueRange() + MinValue;
		}
	}
}
