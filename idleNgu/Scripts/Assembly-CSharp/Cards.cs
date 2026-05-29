using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cards
{
	public List<Card> cards;

	public List<Mana> manas;

	public bool cardsOn;

	public List<float> bonuses;

	public UnityEngine.Random.State cardState;

	public UnityEngine.Random.State chonkerState;

	public PlayerTime cardSpawnTimer;

	public PlayerTime chonkerSpawnTimer;

	public List<cardBonus> taggedBonuses;

	public int cardsGenerated;

	public int extraDeckSpace;

	public Cards()
	{
		cards = new List<Card>();
		manas = new List<Mana>();
		bonuses = new List<float>();
		cardSpawnTimer = new PlayerTime();
		chonkerSpawnTimer = new PlayerTime();
		taggedBonuses = new List<cardBonus>();
		while (manas.Count < manaSize())
		{
			manas.Add(new Mana());
		}
		while (bonuses.Count < bonusesSize())
		{
			bonuses.Add(1f);
		}
		cardState = default(UnityEngine.Random.State);
		chonkerState = default(UnityEngine.Random.State);
		cardsOn = false;
		cardsGenerated = 0;
		extraDeckSpace = 0;
	}

	public int bonusesSize()
	{
		return Enum.GetNames(typeof(cardBonus)).Length;
	}

	public int manaSize()
	{
		return 6;
	}

	public void deleteCard(int index)
	{
		if (index >= 0 && index < cards.Count)
		{
			cards.RemoveAt(index);
		}
	}

	public bool filtered(Card newCard)
	{
		return false;
	}

	public void updateCards()
	{
		while (bonuses.Count < bonusesSize())
		{
			bonuses.Add(1f);
		}
	}
}
