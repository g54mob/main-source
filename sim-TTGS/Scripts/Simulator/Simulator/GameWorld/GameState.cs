using System;
using System.Collections.Generic;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class GameState : WorldManager
	{
		private Dictionary<int, int> m_xpAmounts = new Dictionary<int, int>();

		private Dictionary<int, int> m_levels = new Dictionary<int, int>();

		public static float MoneyAmount { get; private set; }

		public static int ShopLevel { get; private set; }

		public static int AttractionScore { get; private set; }

		private static float PlayTime { get; set; }

		public static event Action<float> MoneyAmountChanged;

		public static event Action<int, float> XPChanged;

		public static event Action<int, int> XPGained;

		public static event Action<int> ShopLevelChanged;

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.LOADING_PHASE1:
				Load();
				break;
			case EWorldEvent.SAVE:
				Save();
				break;
			case EWorldEvent.START:
				StartComputePlayTime();
				break;
			case EWorldEvent.PREPARE_QUIT:
				StopComputePlayTime();
				break;
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.DAY_END:
				TriggerXPRewardEvent(ESimulatorXPRewardEvent.DAY_END);
				break;
			case EGameEvent.ANALYTICS:
				SendAnalytics();
				break;
			}
		}

		public bool ConsumeMoney(float amount)
		{
			if (MoneyAmount >= amount)
			{
				MoneyAmount -= amount;
				GameState.MoneyAmountChanged?.Invoke(0f - amount);
				return true;
			}
			return false;
		}

		public void GainMoney(float amount)
		{
			MoneyAmount += amount;
			GameState.MoneyAmountChanged?.Invoke(amount);
		}

		private void SetMoney(float amount)
		{
			MoneyAmount = amount;
			GameState.MoneyAmountChanged?.Invoke(0f);
		}

		public void Debug_SetShopLevel(int level)
		{
			m_levels[0] = level;
			UpdateShopLevel();
		}

		public void Debug_GainShopXP(int amount)
		{
			GainXP(0, amount);
		}

		protected int GetXPAmount(int type)
		{
			if (m_xpAmounts.ContainsKey(type))
			{
				return m_xpAmounts[type];
			}
			return 0;
		}

		public float GetNormalizedShopXP()
		{
			return GetNormalizedXP(0, GetXPAmount(0));
		}

		public virtual void TriggerXPRewardEvent(ESimulatorXPRewardEvent rewardEvent, int count = 1)
		{
			GainXP(0, count);
		}

		protected void GainXP(int type, int amount)
		{
			GameState.XPGained?.Invoke(type, amount);
			int value = 0;
			m_xpAmounts.TryGetValue(type, out value);
			value += amount;
			GameState.XPChanged?.Invoke(type, GetNormalizedXP(type, value));
			if (LevelUp(ref value, out var levelUp))
			{
				m_levels[type] += levelUp;
				if (type == 0)
				{
					UpdateShopLevel();
					World.HUDPopup.QueueLevelUp();
				}
				GameState.XPChanged?.Invoke(type, GetNormalizedXP(type, value));
			}
			SetXP(type, value, notify: false);
		}

		protected void SetXP(int type, int amount, bool notify)
		{
			m_xpAmounts[type] = amount;
			GameState.XPChanged?.Invoke(type, GetNormalizedXP(type, amount));
		}

		protected bool LevelUp(ref int xp, out int levelUp)
		{
			bool result = false;
			levelUp = 0;
			if (ShopLevel == GameStateSettings.ShopMaxLevel)
			{
				return false;
			}
			int xPTierForLevel = GetXPTierForLevel(ShopLevel);
			while (xp >= xPTierForLevel)
			{
				levelUp++;
				xp -= xPTierForLevel;
				result = true;
				xPTierForLevel = GetXPTierForLevel(ShopLevel + levelUp);
			}
			return result;
		}

		protected int GetXPTierForLevel(int level)
		{
			return GameStateSettings.GetXPTierForLevelToReach(level + 1);
		}

		protected float GetNormalizedXP(int type, int xpAmount)
		{
			int level = 1;
			if (m_levels.TryGetValue(type, out var value))
			{
				level = value;
			}
			return (float)xpAmount / (float)GetXPTierForLevel(level);
		}

		private void UpdateShopLevel()
		{
			if (ShopLevel != m_levels[0])
			{
				ShopLevel = m_levels[0];
				if (ShopLevel >= ShopExtensionSettings.ReserveExtensionInitialUnlockLevel && ShopExtensionSystem.ReserveExtensionLevel < 1)
				{
					ShopExtensionSystem.BuyNextReserveExtension();
					Tutorial.TryShow(TutorialSettings.Reserve);
				}
				GameState.ShopLevelChanged?.Invoke(ShopLevel);
				switch (ShopLevel)
				{
				case 3:
					ESteamAchievement.SHOP_LVL_3.Trigger();
					break;
				case 10:
					ESteamAchievement.SHOP_LVL_10.Trigger();
					break;
				case 25:
					ESteamAchievement.SHOP_LVL_25.Trigger();
					break;
				case 40:
					ESteamAchievement.SHOP_LVL_40.Trigger();
					break;
				case 50:
					ESteamAchievement.SHOP_LVL_50.Trigger();
					break;
				}
			}
		}

		public virtual void CheckoutProduct(Product product)
		{
			TriggerXPRewardEvent(ESimulatorXPRewardEvent.SELL_PRODUCT);
		}

		protected virtual void Load()
		{
			ShopLevel = 0;
			m_levels[0] = SaveManager.CurrentSave.globalState.shopLevel;
			if (GameStateSettings.Demo)
			{
				m_levels[0] = Mathf.Min(m_levels[0], GameStateSettings.DemoMaxLevel);
			}
			UpdateShopLevel();
			SetMoney(SaveManager.CurrentSave.globalState.moneyAmount);
			SetXP(0, SaveManager.CurrentSave.globalState.xp, notify: true);
			AttractionScore = GameStateSettings.DefaultAttractionScore;
			PlayTime = 0f;
		}

		protected virtual void Save()
		{
			SaveManager.CurrentSave.globalState.shopLevel = m_levels[0];
			SaveManager.CurrentSave.globalState.xp = GetXPAmount(0);
			SaveManager.CurrentSave.globalState.moneyAmount = MoneyAmount;
		}

		private void SendAnalytics()
		{
			GameAnalytics.NewDesignEvent("id_analytics_shop_level", ShopLevel);
			GameAnalytics.NewDesignEvent("id_analytics_money", MoneyAmount);
			GameAnalytics.NewDesignEvent("id_analytics_shop_score", AttractionScore);
			GameAnalytics.NewDesignEvent("id_analytics_sessionduration", (int)PlayTime);
		}

		private void StartComputePlayTime()
		{
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.GAME_PLAYING, ComputePlayTime);
		}

		private void StopComputePlayTime()
		{
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.GAME_PLAYING, ComputePlayTime);
		}

		private void ComputePlayTime(float deltaTime)
		{
			PlayTime += Time.unscaledDeltaTime;
		}
	}
}
