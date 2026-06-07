using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class IngameData
{
	[Serializable]
	public class IngameRecord
	{
		public int TotalCollectedCoins;

		public int TotalSpentCoins;

		public int TotalDamageTaken;

		public int TotalDamageDealt;

		public int NormalDamage;

		public int FireDamage;

		public int FrostDamage;

		public int ElectricDamage;

		public int PoisonDamage;

		public int ArcaneDamage;
	}

	[Serializable]
	public class TowerSlotModifier
	{
		public int slotIndex;

		public bool isBanned;

		public int sourceID;

		public int duration;
	}

	[Serializable]
	public class MonsterDamageModifier
	{
		public float value;

		public eModifierType modifierType;

		public int sourceID;

		public int duration;
	}

	[CompilerGenerated]
	private sealed class _003CCR_Mulligan_003Ed__127 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IngameData _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_Mulligan_003Ed__127(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public int CoinGainedFromSellTowerInThisRound;

	public List<int> List_RoundScoreRecord;

	public List<CardData> list_DeckData;

	public List<CardData> list_DiscardData;

	public List<CardData> list_HandCardData;

	public IngameRecord record;

	public List<TowerSlotModifier> list_TowerSlotModifier;

	public List<MonsterDamageModifier> list_MonsterDamageModifier;

	private readonly int DRAW_CARD_COST_INITIAL;

	private readonly int DRAW_CARD_COST_INCREASE;

	private int drawCardCount;

	public int Coin { get; private set; }

	public int Energy { get; private set; }

	public int HP { get; private set; }

	public int Armor { get; private set; }

	public int Score { get; private set; }

	public int DrawCardCost { get; private set; }

	public int FreeDrawCardChance { get; private set; }

	public int DamageTaken { get; private set; }

	public int ExtraEmberStoneReward { get; private set; }

	public int ExtraHandCardLimit { get; private set; }

	public IngameData(int coin, int hp, int armor)
	{
	}

	public void Initialize(int coin, int hp, int armor)
	{
	}

	public void ClearEvents()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnRequestAddGemForVictoryReward(int delta)
	{
	}

	private void OnRequestRemoveDamageMultiplier(int sourceID)
	{
	}

	private void OnRequestChangeDamageMultiplier(float value, eModifierType modifierType, int duration, int sourceID)
	{
	}

	public int CalculateMonsterDamageAfterMultiplier(int originalDamage)
	{
		return 0;
	}

	~IngameData()
	{
	}

	public void UpdateRound()
	{
	}

	private void OnRequestAddCoin(int value)
	{
	}

	private void OnRequestSetCoin(int value)
	{
	}

	private void AddCoin(int value)
	{
	}

	private void SetCoin(int value)
	{
	}

	public bool IsCoinEnough(int value)
	{
		return false;
	}

	private void OnRequestAddHP(int value)
	{
	}

	private void OnRequestSetHP(int value)
	{
	}

	private void AddHP(int value)
	{
	}

	private void SetHP(int value)
	{
	}

	public bool IsPlayerAlive()
	{
		return false;
	}

	public bool IsPlayerHurt()
	{
		return false;
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	private void OnRequestAddArmor(int value)
	{
	}

	private void OnRequestSetArmor(int value)
	{
	}

	private void AddArmor(int value)
	{
	}

	private void SetArmor(int value)
	{
	}

	private void OnRequestAddScore(int value)
	{
	}

	private void OnRequestSetScore(int value)
	{
	}

	private void AddScore(int value)
	{
	}

	private void SetScore(int value)
	{
	}

	private void OnRequestAddRoundScoreRecord(int value)
	{
	}

	public int GetHandCardCount()
	{
		return 0;
	}

	public int GetDeckCardCount()
	{
		return 0;
	}

	public int GetDiscardCardCount()
	{
		return 0;
	}

	public int GetHandCardSpace()
	{
		return 0;
	}

	public int GetHandCardLimit()
	{
		return 0;
	}

	public bool IsHandCardFull()
	{
		return false;
	}

	public int GetCardIndexInHand(CardData cardData)
	{
		return 0;
	}

	private void OnRequestAddCardToDeck(eItemType towerType)
	{
	}

	private void OnRequestRemoveCardFromDeck(CardData data)
	{
	}

	private void OnRequestResetDeckFromStorage()
	{
	}

	private void OnRequestAddCardToHand(eItemType towerType, bool ignorHandLimit)
	{
	}

	private void RequestAddCardToHandByCardData(CardData cardData, bool ignorHandLimit)
	{
	}

	private void OnRequestAddCardToHandFromPosition(eItemType towerType, Vector3 position, bool ignorHandLimit)
	{
	}

	private void OnRequestRemoveCardFromHand(CardData data)
	{
	}

	private void OnRequestDiscardCardFromHand(CardData data)
	{
	}

	private void OnRequestRemoveExcessHandCard(int limit)
	{
	}

	private void OnRequestGrantFreeDrawCard(int count)
	{
	}

	private void OnRequestConsumeFreeDrawCard()
	{
	}

	private void OnRequestCorruptHandCard(CardData data)
	{
	}

	private void OnRequestUncorruptHandCard(CardData data)
	{
	}

	private void OnRequestBanHandCard(CardData data)
	{
	}

	private void OnRequestUnbanHandCard(CardData data)
	{
	}

	private void OnRequestReplaceHandCard(CardData oldData, CardData newData)
	{
	}

	private void OnRequestDiscardAllCardsFromHand()
	{
	}

	private void OnRequestRedrawCards()
	{
	}

	private void OnRequestResetDrawCardCost()
	{
	}

	private void OnRequestDrawCard(int count, bool doIncreaseDrawCost)
	{
	}

	private void OnRequestDrawSpecificCard(CardData data, bool doIncreaseDrawCost)
	{
	}

	private void IncreateDrawCost()
	{
	}

	private void OnRequestShuffleDeck()
	{
	}

	public CardData AddCardToDeck(eItemType itemType)
	{
		return null;
	}

	public void AddCardToPlayerHand(eItemType itemType)
	{
	}

	public void AddCardToPlayerHand(CardData cardData)
	{
	}

	public void AddCardToPlayerHandFromPosition(eItemType itemType, Vector3 position)
	{
	}

	public void ShuffleDeck()
	{
	}

	public void PutCardBackToDeck(int count)
	{
	}

	public void DrawCardFromDeck(int count)
	{
	}

	public void DrawSpecificCardFromDeck(CardData cardData)
	{
	}

	private void OnRequestRecallBlockCard(TetrisCardData data)
	{
	}

	private void OnRequestAddItemCardLimitInThisLevel(int value)
	{
	}

	private void OnRequestMulligan()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Mulligan_003Ed__127))]
	private IEnumerator CR_Mulligan()
	{
		return null;
	}

	private void OnRequestSellTower(ABaseTower tower)
	{
	}

	private void OnRequestBanTowerSlot(int index, int duration, int sourceID)
	{
	}

	private void BanTowerSlot(int index, int duration, int sourceID)
	{
	}

	private void RequestUnbanTowerSlot(int index, int sourceID)
	{
	}

	private void OnRequestBanTowerByType(eItemType type, int duration, int sourceID)
	{
	}

	private void OnRequestBanTowerByElement(eDamageType type, int duration, int sourceID)
	{
	}

	private void OnRequestBanTowerBySize(eTowerSizeType type, int duration, int sourceID)
	{
	}

	public bool IsTowerSlotBanned(int index)
	{
		return false;
	}
}
