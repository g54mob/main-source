using System;
using System.Collections.Generic;

[Serializable]
public class Card
{
	public int tier;

	public int artID;

	public string cardName;

	public cardType type;

	public float effectAmount;

	public rarity cardRarity;

	public cardBonus bonusType;

	public List<int> manaCosts;

	public bool isProtected;

	public Card()
	{
		tier = 0;
		effectAmount = 0f;
		manaCosts = new List<int>(6);
		manaCosts[0] = 1;
		manaCosts[1] = 0;
		manaCosts[2] = 0;
		manaCosts[3] = 0;
		manaCosts[4] = 0;
		manaCosts[5] = 0;
		isProtected = false;
	}

	public Card(int cardTier, int art, string name, float cardEffect, cardType cardType, cardBonus cardBonus, rarity rarity, int mana1, int mana2, int mana3, int mana4, int mana5, int mana6)
	{
		tier = cardTier;
		artID = art;
		cardName = name;
		effectAmount = cardEffect;
		type = cardType;
		bonusType = cardBonus;
		cardRarity = rarity;
		manaCosts = new List<int>();
		manaCosts.Add(mana1);
		manaCosts.Add(mana2);
		manaCosts.Add(mana3);
		manaCosts.Add(mana4);
		manaCosts.Add(mana5);
		manaCosts.Add(mana6);
		isProtected = false;
	}

	public Card(Card otherCard)
	{
		tier = otherCard.tier;
		artID = otherCard.artID;
		cardName = otherCard.cardName;
		effectAmount = otherCard.effectAmount;
		type = otherCard.type;
		bonusType = otherCard.bonusType;
		cardRarity = otherCard.cardRarity;
		manaCosts = otherCard.manaCosts;
		isProtected = otherCard.isProtected;
	}
}
