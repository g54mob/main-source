using System;
using Assets.Source.Item;
using Steamworks;

namespace Assets.Source.Player
{
	public class SteamStat
	{
		public const float UpdateInterval = 1f;

		protected int _savedAmount;

		protected int _addedAmount;

		protected int _setAmount;

		private float _updateTimer = 1f;

		public SteamStatType Stat { get; private set; }

		public string StatName { get; private set; }

		public int[] Tiers { get; private set; }

		public ItemType Item { get; private set; }

		public SteamStat(SteamStatType type, int[] tiers, ItemType item = null)
		{
			Stat = type;
			StatName = Enum.GetName(typeof(SteamStatType), type);
			Tiers = tiers;
			Item = item;
		}

		public void Add(int count)
		{
			_addedAmount += count;
		}

		public void Set(int count)
		{
			if (_savedAmount != count)
			{
				_setAmount = count;
			}
		}

		public void Update(float delta)
		{
			_updateTimer -= delta;
			if (_updateTimer > 0f)
			{
				return;
			}
			_updateTimer = 1f;
			if ((_addedAmount == 0 && _setAmount == 0) || (_savedAmount == 0 && !SteamUserStats.GetStat(StatName, out _savedAmount)) || GamePlayer.Current == null || !GamePlayer.Current.Integrity)
			{
				return;
			}
			int num = ((_setAmount != 0) ? _setAmount : (_savedAmount + _addedAmount));
			SteamUserStats.SetStat(StatName, num);
			bool flag = false;
			for (int i = 0; i < Tiers.Length; i++)
			{
				if (_savedAmount < Tiers[i] && num >= Tiers[i])
				{
					flag = true;
					break;
				}
			}
			_savedAmount = num;
			_addedAmount = 0;
			_setAmount = 0;
			if (flag)
			{
				SteamUserStats.StoreStats();
			}
		}
	}
}
