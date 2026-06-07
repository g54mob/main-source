using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Behaviour.Util
{
	public class AchievementManager : MonoBehaviour
	{
		private List<AchievementChecker> _checkers = new List<AchievementChecker>();

		private float _updateTimer = 1f;

		private int _clickCount;

		private float _clickTimer;

		private float _inactivityTimer = 28800f;

		public static AchievementManager Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		private void Update()
		{
			if (PlayerControls.HasInput)
			{
				_inactivityTimer = 28800f;
			}
			else
			{
				_inactivityTimer -= Time.deltaTime;
				if (_inactivityTimer < 0f)
				{
					SteamAchievement.Trigger("NoClick");
				}
			}
			_updateTimer -= Time.deltaTime;
			if (_updateTimer < 0f)
			{
				_updateAchievements();
				_updateTimer = 1f;
			}
			for (int i = 0; i < _checkers.Count; i++)
			{
				if (_checkers[i].Update(Time.deltaTime))
				{
					_checkers.RemoveAt(i);
					i--;
				}
			}
			_clickTimer -= Time.deltaTime;
			if (_clickTimer < 0f)
			{
				_clickTimer = 0.125f;
				if (_clickCount > 0)
				{
					_clickCount--;
				}
			}
		}

		public void AddAchievementClick()
		{
			_clickCount++;
			if (_clickCount > 20)
			{
				SteamAchievement.Trigger("FastClick");
			}
		}

		private void _updateAchievements()
		{
			SteamStatsManager.Set(SteamStatType.PowerPerSecond, (int)GamePlayer.Current.GetProductionStats(ItemType.Power));
		}

		public static void CheckAchievement(AchievementChecker ct)
		{
			if ((bool)Instance)
			{
				Instance._checkAchievement(ct);
			}
		}

		private void _checkAchievement(AchievementChecker ct)
		{
			for (int i = 0; i < _checkers.Count; i++)
			{
				if (_checkers[i].AchievementName == ct.AchievementName)
				{
					_checkers[i] = ct;
					return;
				}
			}
			_checkers.Add(ct);
		}
	}
}
