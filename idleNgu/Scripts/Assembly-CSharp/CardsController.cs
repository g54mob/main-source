using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardsController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public List<string> verbs;

	public List<string> verbed;

	public List<string> nouns;

	public List<Sprite> art;

	public List<string> adverbs;

	public List<string> adjectives;

	public List<string> ingverbs;

	public List<string> exclamations;

	public List<string> names;

	public List<string> suffixes;

	public List<string> manaNames;

	public List<Sprite> manaSprites;

	public Sprite noCardSprite;

	public Sprite unkownSprite;

	public Sprite endSprite;

	public Image cardArt;

	public Image cardBG;

	public Sprite normalBg;

	public Sprite foilbg;

	public Sprite chonkerBG;

	public Image[] manaIcons;

	public Text[] manaAmounts;

	public Image tierIcon;

	public Text tierText;

	public Text cardName;

	public Text cardDesc;

	public List<DeckPodUI> deckPods;

	public DeckPodUI ghost;

	public Sprite normalDeckBG;

	public Sprite foilDeckBG;

	public Sprite chonkerDeckBG;

	public Sprite normalProtectFrame;

	public Sprite foilProtectFrame;

	public Sprite chonkerProtectFrame;

	private int deckpageID;

	public List<Button> deckPageButtons;

	public List<ManaUI> manaUI;

	public List<TagUI> tagUI;

	public Text deckSpaceText;

	public Text manaGenText;

	public Text taggedBonusesText;

	public Text pagesText;

	public GameObject tagPanel;

	public GameObject tagAnchor;

	public GameObject bonusesPanel;

	public GameObject bonusesAnchor;

	public CardBonusListUI bonusListUI;

	public int curSelectedCard;

	public bool tagPanelShown;

	public bool bonusesPanelShown;

	public int curManaID;

	public int beginDrag = -1;

	public int endDrag = -1;

	public bool midDrag;

	private void Start()
	{
		InvokeRepeating("updateManaGens", 0f, 0.02f);
		hidePanel();
		hideBonusesPanel();
		initDeckPage();
	}

	private void Update()
	{
		if (character.cards.cardsOn)
		{
			if (character.cards.cardSpawnTimer.totalseconds < (double)cardSpawnTime())
			{
				character.cards.cardSpawnTimer.totalseconds += Time.deltaTime * totalCardSpeed();
			}
			if (character.cards.cardSpawnTimer.totalseconds >= (double)cardSpawnTime() && character.cards.cards.Count < maxDeckSize())
			{
				character.cards.cardSpawnTimer.reset();
				addCard();
			}
			if (character.cards.chonkerSpawnTimer.totalseconds < (double)chonkerSpawnTime() && unlockedChonkers())
			{
				character.cards.chonkerSpawnTimer.totalseconds += Time.deltaTime * totalCardSpeed();
			}
			if (character.cards.chonkerSpawnTimer.totalseconds >= (double)chonkerSpawnTime() && unlockedChonkers() && character.cards.cards.Count < maxDeckSize())
			{
				character.cards.chonkerSpawnTimer.reset();
				addChonkerCard();
			}
			if (midDrag)
			{
				character.cardsController.ghost.transform.position = new Vector3(Input.mousePosition.x - 6f, Input.mousePosition.y + 6f);
			}
			else if (character.cardsController.ghost.transform.position != new Vector3(-5000f, -5000f))
			{
				character.cardsController.ghost.transform.position = new Vector3(-5000f, -5000f);
			}
		}
	}

	public float cardSpawnTime()
	{
		return 3600f;
	}

	public float chonkerSpawnTime()
	{
		return 259200f;
	}

	public void trySetPage(int newid)
	{
		if (newid >= 0 && newid * deckPods.Count < character.cards.cards.Count)
		{
			setDeckPage(newid);
		}
	}

	public void initDeckPage()
	{
		int num = 0;
		foreach (DeckPodUI deckPod in deckPods)
		{
			deckPod.deckID = num;
			num++;
			deckPod.updatePod();
		}
		deckpageID = 0;
		updateText();
	}

	public void setDeckPage(int newid)
	{
		if (newid == deckpageID)
		{
			return;
		}
		int num = newid * deckPods.Count;
		foreach (DeckPodUI deckPod in deckPods)
		{
			deckPod.deckID = num;
			num++;
			deckPod.updatePod();
		}
		deckpageID = newid;
		updateText();
	}

	public void deckPageBack()
	{
		if (deckpageID > 0)
		{
			setDeckPage(deckpageID - 1);
		}
	}

	public void deckPageForward()
	{
		if ((deckpageID + 1) * deckPods.Count < character.cards.cards.Count)
		{
			setDeckPage(deckpageID + 1);
		}
	}

	public void updateDeckButtons()
	{
		if (character.menuID != 55)
		{
			return;
		}
		int num = Mathf.CeilToInt((float)character.cards.cards.Count / (float)deckPods.Count);
		for (int i = 0; i < deckPageButtons.Count; i++)
		{
			if (i >= num)
			{
				deckPageButtons[i].gameObject.SetActive(value: false);
			}
			else
			{
				deckPageButtons[i].gameObject.SetActive(value: true);
			}
		}
	}

	public void updateManaGens()
	{
		if (!character.cards.cardsOn)
		{
			return;
		}
		for (int i = 0; i < character.cards.manas.Count; i++)
		{
			if (character.cards.manas[i].running)
			{
				character.cards.manas[i].progress += manaGenProgressPerTick(i);
				if (character.cards.manas[i].progress >= 1f)
				{
					character.cards.manas[i].progress = 0f;
					character.cards.manas[i].amount++;
					updateManaPod(i);
				}
				else
				{
					updateManaBar(i);
				}
			}
		}
	}

	public float manaGenProgressPerTick()
	{
		float num = 5.555555E-06f;
		num *= totalMayoSpeed();
		if (curManaToggleCount() > 1)
		{
			num /= (float)curManaToggleCount();
		}
		return num;
	}

	public float manaGenProgressPerTick(int manaID)
	{
		if (manaID < 0 || manaID >= character.cards.manas.Count)
		{
			return 1E-08f;
		}
		float num = 5.555555E-06f;
		num *= totalMayoSpeed();
		if (curManaToggleCount() > 1)
		{
			num /= (float)curManaToggleCount();
		}
		return num;
	}

	public string timeToGen(int manaID)
	{
		if (manaID < 0 || manaID >= character.cards.manas.Count)
		{
			return "Error - tell 4G he screwed up";
		}
		float num = manaGenProgressPerTick(manaID);
		if (num == 0f)
		{
			return "Error - tell 4G he screwed up";
		}
		return NumberOutput.timeOutput((1f - character.cards.manas[manaID].progress) / num / 50f);
	}

	public void showManaGenTooltip(int manaID)
	{
		curManaID = manaID;
		InvokeRepeating("showManaGenTooltip", 0f, 0.1f);
	}

	public void showManaGenTooltip()
	{
		if (curManaID >= 0 && curManaID < character.cards.manas.Count)
		{
			string text = timeToGen(curManaID);
			if (character.cards.manas[curManaID].running)
			{
				tooltip.showTooltip("<b>" + getManaName(curManaID) + "</b>\n<b>Time Until Mayo Generates:</b> " + text);
			}
			else
			{
				tooltip.showTooltip("<b>" + getManaName(curManaID) + "</b>\n<b>Mayo Generator not running</b>\n<b>Time to Generate Mayo (if turned on):</b> " + text);
			}
		}
	}

	public void hideManaGenTooltip()
	{
		tooltip.hideTooltip();
		CancelInvoke("showManaGenTooltip");
	}

	public int maxDeckSize()
	{
		int num = 10;
		num += character.adventureController.itopod.totalDeckSizeBonus();
		num += character.beastQuestPerkController.totalDeckSizeBonus();
		num += character.wishesController.totalDeckSizeBonus();
		if (character.inventory.itemList.radComplete)
		{
			num += 5;
		}
		if (character.inventory.itemList.amalgamateComplete)
		{
			num += 10;
		}
		return num + character.arbitrary.deckSpaceBought;
	}

	public int hardCapTagSize()
	{
		return 4;
	}

	public int maxTagSize()
	{
		int num = 1;
		if (character.beastQuest.quirkLevel[151] >= 1)
		{
			num++;
		}
		if (character.wishes.wishes[168].level >= 1)
		{
			num++;
		}
		if (character.arbitrary.gotTagslot1)
		{
			num++;
		}
		if (num >= hardCapTagSize())
		{
			num = hardCapTagSize();
		}
		return num;
	}

	public int maxManaGenSize()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[211] >= 1)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[150] >= 1)
		{
			num++;
		}
		if (character.wishes.wishes[167].level >= 1)
		{
			num++;
		}
		num += character.arbitrary.mayoGenSlots;
		if (num < 1)
		{
			num = 1;
		}
		if (num > 6)
		{
			num = 6;
		}
		return num;
	}

	public void updateMenu()
	{
		updateCard();
		updateText();
		updateManaPods();
		updateTagPods();
		updateDeckPods();
		updateDeckButtons();
		updateManaGenText();
		updateTagPanelText();
		updateTotalBonuses();
	}

	public void toggleTag(int toToggle)
	{
		if (character.cards.taggedBonuses.Contains((cardBonus)toToggle))
		{
			character.cards.taggedBonuses.Remove((cardBonus)toToggle);
			updateTagCheckmark(toToggle);
			updateTagPanelText();
		}
		else if (character.cards.taggedBonuses.Count >= maxTagSize())
		{
			tooltip.showOverrideTooltip("You have the max number of Tagged Bonuses! Try Removing a Tag first!", 3f);
		}
		else
		{
			character.cards.taggedBonuses.Add((cardBonus)toToggle);
			updateTagCheckmark(toToggle);
			updateTagPanelText();
		}
	}

	public void togglePanel()
	{
		if (tagPanelShown)
		{
			tagPanel.transform.position = new Vector3(-5000f, -5000f);
			tagPanelShown = false;
			return;
		}
		if (bonusesPanelShown)
		{
			bonusesPanel.transform.position = new Vector3(-5000f, -5000f);
			bonusesPanelShown = false;
		}
		tagPanel.transform.position = tagAnchor.transform.position;
		tagPanelShown = true;
		updateTagPods();
		updateTagPanelText();
	}

	public void toggleBonusesPanel()
	{
		if (bonusesPanelShown)
		{
			bonusesPanel.transform.position = new Vector3(-5000f, -5000f);
			bonusesPanelShown = false;
			return;
		}
		if (tagPanelShown)
		{
			tagPanel.transform.position = new Vector3(-5000f, -5000f);
			tagPanelShown = false;
		}
		bonusesPanel.transform.position = bonusesAnchor.transform.position;
		bonusesPanelShown = true;
		updateTagPods();
		updateTagPanelText();
	}

	public void hidePanel()
	{
		tagPanel.transform.position = new Vector3(-5000f, -5000f);
		tagPanelShown = false;
	}

	public void hideBonusesPanel()
	{
		bonusesPanel.transform.position = new Vector3(-5000f, -5000f);
		bonusesPanelShown = false;
	}

	public void addCard()
	{
		Card item = generateCard(isChonker: false);
		if (character.cards.cards.Count < maxDeckSize())
		{
			character.cards.cards.Add(item);
			updateCard();
			updateText();
			int num = character.cards.cards.Count - 1;
			if (num >= 0 && num < character.cards.cards.Count)
			{
				updateDeckCard(num);
				updateDeckButtons();
			}
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic && UnityEngine.Random.value < 0.01f)
		{
			addEndCard();
		}
	}

	public void addChonkerCard()
	{
		Card item = generateCard(isChonker: true);
		if (character.cards.cards.Count < maxDeckSize())
		{
			character.cards.cards.Add(item);
			updateCard();
			updateText();
			int num = character.cards.cards.Count - 1;
			if (num >= 0 && num < character.cards.cards.Count)
			{
				updateDeckCard(num);
				updateDeckButtons();
			}
		}
	}

	public void addEndCard()
	{
		Card item = new Card(69, 1, "^!!;;;[4V OF #$^&*FEdXCUy ee44-*()", 1f, cardType.end, cardBonus.atkDefStats, rarity.Crappy, 99, 99, 99, 99, 99, 99);
		if (character.cards.cards.Count < maxDeckSize())
		{
			character.cards.cards.Add(item);
			updateCard();
			updateText();
			int num = character.cards.cards.Count - 1;
			if (num >= 0 && num < character.cards.cards.Count)
			{
				updateDeckCard(num);
				updateDeckButtons();
			}
		}
	}

	public Card generateCard(bool isChonker)
	{
		if (isChonker)
		{
			UnityEngine.Random.state = character.cards.chonkerState;
		}
		else
		{
			UnityEngine.Random.state = character.cards.cardState;
		}
		int nounID = getNounID();
		string text = generateCardName(nounID);
		cardBonus bonusType = generateBonusType();
		int num = generateCardTier(bonusType);
		if (character.arbitrary.cardTierUpperCount > 0)
		{
			num += 2;
			character.arbitrary.cardTierUpperCount--;
		}
		int[] array = ((!isChonker) ? generateManaCosts(minCardMana(), maxCardMana() + 1) : generateManaCosts(minChonkerMana(), maxChonkerMana() + 1));
		int totalCost = array.Sum();
		float variance = generateVariance();
		if (isChonker)
		{
			variance = getMaxVariance();
		}
		rarity rarity2 = generateRarity(variance, isChonker);
		float cardEffect = generateCardEffect(bonusType, num, totalCost, variance, isChonker);
		cardType cardType2 = generateCardType();
		Card card = new Card(num, nounID, text, cardEffect, cardType2, bonusType, rarity2, array[0], array[1], array[2], array[3], array[4], array[5]);
		character.cards.cardsGenerated++;
		if (isChonker)
		{
			card.isProtected = true;
		}
		if (isChonker)
		{
			character.cards.chonkerState = UnityEngine.Random.state;
		}
		else
		{
			character.cards.cardState = UnityEngine.Random.state;
		}
		return card;
	}

	public int minCardMana()
	{
		int num = 1;
		if (character.wishes.wishes[163].level >= 1)
		{
			num++;
		}
		if (character.wishes.wishes[221].level >= 1)
		{
			num++;
		}
		return num + character.wishes.wishes[228].level;
	}

	public int maxCardMana()
	{
		int num = 9;
		if (character.wishes.wishes[162].level >= 1)
		{
			num++;
		}
		if (character.wishes.wishes[220].level >= 1)
		{
			num++;
		}
		return num + character.wishes.wishes[227].level;
	}

	public int minChonkerMana()
	{
		return 21 + character.wishes.wishes[229].level;
	}

	public int maxChonkerMana()
	{
		return 29 + character.wishes.wishes[230].level;
	}

	public bool unlockedChonkers()
	{
		if (character.beastQuest.quirkLevel[149] > 0)
		{
			return true;
		}
		return false;
	}

	public cardBonus generateBonusType()
	{
		int max = Enum.GetNames(typeof(cardBonus)).Length;
		float value = UnityEngine.Random.value;
		cardBonus result = (cardBonus)UnityEngine.Random.Range(1, max);
		int a = curTagCount();
		for (int i = 0; i < Mathf.Min(a, maxTagSize()); i++)
		{
			if (value < tagEffect() * (float)(i + 1))
			{
				result = character.cards.taggedBonuses[i];
				break;
			}
		}
		return result;
	}

	public float tagEffect()
	{
		float num = 0.1f;
		num += character.wishesController.totalCardTagBonus();
		num += character.beastQuestPerkController.totalCardTagBonus();
		num += character.adventureController.itopod.totalCardTagBonus();
		if (character.inventory.itemList.beatingHeartComplete)
		{
			num += 0.01f;
		}
		if (num < 0.1f)
		{
			num = 0.1f;
		}
		if (num > 0.25f)
		{
			num = 0.25f;
		}
		return num;
	}

	public int generateCardTier(cardBonus bonusType)
	{
		int num = 1;
		switch (bonusType)
		{
		case cardBonus.energyNGUSpeed:
			return getEnergyNGUTier();
		case cardBonus.magicNGUSpeed:
			return getMagicNGUTier();
		case cardBonus.wandoosSpeed:
			return getWandoosTier();
		case cardBonus.augSpeed:
			return getAugsTier();
		case cardBonus.TMSpeed:
			return getTMTier();
		case cardBonus.hackSpeed:
			return getHackTier();
		case cardBonus.wishSpeed:
			return getWishTier();
		case cardBonus.atkDefStats:
			return getAtkDefTier();
		case cardBonus.adventureStat:
			return getAdvTier();
		case cardBonus.dropChance:
			return getDropChanceTier();
		case cardBonus.goldDrop:
			return getGoldDropTier();
		case cardBonus.dayCareSpeed:
			return getDaycareTier();
		case cardBonus.PP:
			return getPPTier();
		case cardBonus.QP:
			return getQPTier();
		default:
			return 1;
		}
	}

	public int getGlobalTierBonus()
	{
		int num = 0;
		if (character.inventory.itemList.rockLobsterComplete)
		{
			num++;
		}
		return num;
	}

	public int getEnergyNGUTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[169] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[182] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[195] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[103] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[116] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[129] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[161];
		if (character.wishes.wishes[115].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[128].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[141].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[174].level;
		num += character.wishes.wishes[205].level;
		return num + getGlobalTierBonus();
	}

	public int getMagicNGUTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[165] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[178] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[191] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[99] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[112] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[125] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[157];
		if (character.wishes.wishes[124].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[137].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[150].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[183].level;
		num += character.wishes.wishes[214].level;
		return num + getGlobalTierBonus();
	}

	public int getWandoosTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[171] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[184] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[197] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[105] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[118] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[131] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[163];
		if (character.wishes.wishes[117].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[130].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[143].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[176].level;
		num += character.wishes.wishes[207].level;
		return num + getGlobalTierBonus();
	}

	public int getAugsTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[161] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[174] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[187] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[108] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[121] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[134] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[166];
		if (character.wishes.wishes[120].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[133].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[146].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[179].level;
		num += character.wishes.wishes[210].level;
		return num + getGlobalTierBonus();
	}

	public int getTMTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[166] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[179] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[192] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[100] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[113] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[126] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[158];
		if (character.wishes.wishes[125].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[138].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[151].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[184].level;
		num += character.wishes.wishes[215].level;
		return num + getGlobalTierBonus();
	}

	public int getHackTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[173] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[186] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[199] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[107] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[120] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[133] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[165];
		if (character.wishes.wishes[119].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[132].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[145].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[178].level;
		num += character.wishes.wishes[209].level;
		return num + getGlobalTierBonus();
	}

	public int getWishTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[163] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[176] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[189] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[101] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[114] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[127] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[159];
		return num + getGlobalTierBonus();
	}

	public int getAtkDefTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[164] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[177] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[190] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[111] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[124] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[137] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[169];
		if (character.wishes.wishes[123].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[136].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[149].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[182].level;
		num += character.wishes.wishes[213].level;
		return num + getGlobalTierBonus();
	}

	public int getAdvTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[172] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[185] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[198] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[106] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[119] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[132] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[164];
		if (character.wishes.wishes[118].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[131].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[144].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[177].level;
		num += character.wishes.wishes[208].level;
		return num + getGlobalTierBonus();
	}

	public int getDropChanceTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[170] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[183] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[196] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[104] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[117] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[130] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[162];
		if (character.wishes.wishes[116].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[129].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[142].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[175].level;
		num += character.wishes.wishes[206].level;
		return num + getGlobalTierBonus();
	}

	public int getGoldDropTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[162] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[175] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[188] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[109] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[122] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[135] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[167];
		if (character.wishes.wishes[121].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[134].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[147].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[180].level;
		num += character.wishes.wishes[211].level;
		return num + getGlobalTierBonus();
	}

	public int getDaycareTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[168] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[181] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[194] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[102] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[115] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[128] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[160];
		if (character.wishes.wishes[127].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[140].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[153].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[186].level;
		num += character.wishes.wishes[217].level;
		return num + getGlobalTierBonus();
	}

	public int getPPTier()
	{
		int num = 1;
		if (character.beastQuest.quirkLevel[110] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[123] > 0)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[136] > 0)
		{
			num++;
		}
		num += (int)character.beastQuest.quirkLevel[168];
		if (character.wishes.wishes[122].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[135].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[148].level;
		num += character.wishes.wishes[181].level;
		num += character.wishes.wishes[212].level;
		return num + getGlobalTierBonus();
	}

	public int getQPTier()
	{
		int num = 1;
		if (character.adventure.itopod.perkLevel[167] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[180] > 0)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[193] > 0)
		{
			num++;
		}
		if (character.wishes.wishes[126].level > 0)
		{
			num++;
		}
		if (character.wishes.wishes[139].level > 0)
		{
			num++;
		}
		num += character.wishes.wishes[152].level;
		num += character.wishes.wishes[185].level;
		num += character.wishes.wishes[216].level;
		return num + getGlobalTierBonus();
	}

	public float generateVariance()
	{
		return UnityEngine.Random.Range(getMinVariance(), getMaxVariance());
	}

	public float getMinVariance()
	{
		float num = 0.8f;
		if (character.inventory.itemList.that70sComplete)
		{
			num += 0.05f;
		}
		return num;
	}

	public float getMaxVariance()
	{
		return 1.2f;
	}

	public rarity generateRarity(float variance, bool bigChonker)
	{
		if (bigChonker)
		{
			return rarity.BigChonker;
		}
		if (variance < 0.9f)
		{
			return rarity.Crappy;
		}
		if (variance < 1f)
		{
			return rarity.Bad;
		}
		if (variance < 1.08f)
		{
			return rarity.Meh;
		}
		if (variance < 1.14f)
		{
			return rarity.Okay;
		}
		if (variance < 1.17f)
		{
			return rarity.Good;
		}
		if (variance < 1.19f)
		{
			return rarity.Great;
		}
		return rarity.Damn;
	}

	public cardType generateCardType()
	{
		float value = UnityEngine.Random.value;
		if (character.arbitrary.boughtFoils && character.settings.foilsOn)
		{
			return cardType.foil;
		}
		if (value < 0.01f)
		{
			return cardType.foil;
		}
		return cardType.normal;
	}

	public int getNounID()
	{
		return UnityEngine.Random.Range(0, nouns.Count);
	}

	public int[] generateManaCosts(int minCost, int MaxCost)
	{
		int[] array = new int[6];
		int num = UnityEngine.Random.Range(minCost, MaxCost);
		while (num > 0)
		{
			int num2 = UnityEngine.Random.Range(0, array.Length);
			int num3 = 1;
			int num4 = Mathf.Min(UnityEngine.Random.Range(0, num), num - 1);
			num3 += num4;
			array[num2] += num3;
			num -= num3;
		}
		return array;
	}

	public string generateCardName(int nounID)
	{
		switch (UnityEngine.Random.Range(1, 16))
		{
		case 1:
			return sentence1(nounID);
		case 2:
			return sentence2(nounID);
		case 3:
			return sentence3(nounID);
		case 4:
			return sentence4(nounID);
		case 5:
			return sentence5(nounID);
		case 6:
			return sentence6(nounID);
		case 7:
			return sentence7(nounID);
		case 8:
			return sentence8(nounID);
		case 9:
			return sentence9(nounID);
		case 10:
			return sentence10(nounID);
		case 11:
			return sentence11(nounID);
		case 12:
			return sentence12(nounID);
		case 13:
			return sentence13(nounID);
		case 14:
			return sentence14(nounID);
		case 15:
			return sentence15(nounID);
		default:
			return sentence1(nounID);
		}
	}

	public string generateCardName()
	{
		int nounID = getNounID();
		return generateCardName(nounID);
	}

	public string sentence1(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getAdjective() + " " + getNoun(nounID) + " of " + getIngverb();
	}

	public string sentence2(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return "The " + getAdjective() + ", " + getAdjective() + ", " + getAdjective() + " " + getNoun(nounID);
	}

	public string sentence3(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getIngverb() + " " + getNoun(nounID) + " of " + getExclamation();
	}

	public string sentence4(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getNoun(nounID) + " of " + getExclamation();
	}

	public string sentence5(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getVerbed() + " " + getNoun(nounID) + " of " + getAdjective() + " " + getExclamation();
	}

	public string sentence6(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getAdjective() + " " + getNoun(nounID);
	}

	public string sentence7(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return "The " + getVerb() + "-" + getNoun(nounID);
	}

	public string sentence8(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getAdverb() + " " + getVerbed() + " " + getNoun(nounID) + " of " + getExclamation();
	}

	public string sentence9(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return "The " + getAdjective() + ", " + getAdjective() + " " + getNoun(nounID);
	}

	public string sentence10(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getName() + "'s " + getAdjective() + " " + getNoun(nounID);
	}

	public string sentence11(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getName() + ", " + getIngverb() + " " + getNoun(nounID) + " of " + getExclamation();
	}

	public string sentence12(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getAdjective() + " " + getName() + "'s " + getExclamation() + " " + getNoun(nounID);
	}

	public string sentence13(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getAdjective() + " " + getName() + "'s " + getNoun(nounID) + " of " + getAdjective() + " " + getExclamation();
	}

	public string sentence14(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getName() + ", " + getAdjective() + " " + getNoun(nounID) + getSuffix();
	}

	public string sentence15(int nounID)
	{
		if (nounID < 0 || nounID >= nouns.Count)
		{
			return "Big problem, tell 4G";
		}
		return getAdjective() + " " + getIngverb() + " " + getNoun(nounID);
	}

	public string getAdjective()
	{
		return adjectives[UnityEngine.Random.Range(0, adjectives.Count)];
	}

	public string getVerb()
	{
		return verbs[UnityEngine.Random.Range(0, verbs.Count)];
	}

	public string getVerbed()
	{
		return verbed[UnityEngine.Random.Range(0, verbed.Count)];
	}

	public string getIngverb()
	{
		return ingverbs[UnityEngine.Random.Range(0, ingverbs.Count)];
	}

	public string getAdverb()
	{
		return adverbs[UnityEngine.Random.Range(0, adverbs.Count)];
	}

	public string getNoun(int nounID)
	{
		if (nounID < 0 || nounID > nouns.Count)
		{
			return "Bad Noun";
		}
		return nouns[nounID];
	}

	public string getRandomNoun()
	{
		return nouns[UnityEngine.Random.Range(0, nouns.Count)];
	}

	public string getExclamation()
	{
		return exclamations[UnityEngine.Random.Range(0, exclamations.Count)];
	}

	public string getName()
	{
		return names[UnityEngine.Random.Range(0, names.Count)];
	}

	public string getSuffix()
	{
		return suffixes[UnityEngine.Random.Range(0, suffixes.Count)];
	}

	public void manaGenTest()
	{
		int[] array = new int[6];
		int[] array2 = new int[6];
		int[] array3 = new int[6];
		string text = "";
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 0;
		}
		for (int j = 0; j < 5000; j++)
		{
			int num = UnityEngine.Random.Range(25, 35);
			for (int k = 0; k < array.Length; k++)
			{
				array2[k] = array[k];
			}
			while (num > 0)
			{
				int num2 = UnityEngine.Random.Range(0, array.Length);
				int num3 = 1;
				int num4 = Mathf.Min(UnityEngine.Random.Range(0, num), num - 1);
				num3 += num4;
				array[num2] += num3;
				num -= num3;
			}
			for (int l = 0; l < array.Length; l++)
			{
				array3[l] = array[l] - array2[l];
			}
			text += array3[0];
			for (int m = 1; m < array.Length; m++)
			{
				text = text + "," + array3[m];
			}
			text = text + "," + (array3[0] + array3[1] + array3[2] + array3[3] + array3[4] + array3[5]);
			text += "\n";
		}
		text += array[0];
		for (int n = 1; n < array.Length; n++)
		{
			text = text + "," + array[n];
		}
		text = text + "," + (array[0] + array[1] + array[2] + array[3] + array[4] + array[5]);
		File.WriteAllText($"{Application.persistentDataPath}/ManaData.csv", text);
		Debug.Log("done");
	}

	public void cardNameTest()
	{
		string text = "";
		for (int i = 0; i < 1000; i++)
		{
			string text2 = generateCardName();
			text = text + text2 + "\n";
		}
		File.WriteAllText($"{Application.persistentDataPath}/CardNameData.txt", text);
		Debug.Log("done");
	}

	public void updateCard()
	{
		if (character.menuID != 55)
		{
			return;
		}
		if (character.cards.cards.Count == 0 || invalidID(curSelectedCard))
		{
			for (int i = 0; i < manaIcons.Length; i++)
			{
				manaIcons[i].gameObject.SetActive(value: false);
				manaAmounts[i].gameObject.SetActive(value: false);
			}
			cardBG.sprite = normalBg;
			cardArt.sprite = noCardSprite;
			cardName.text = "";
			cardDesc.text = "You have no cards! Hover over me to see when your next card drops!";
			cardDesc.alignment = TextAnchor.MiddleCenter;
			tierIcon.gameObject.SetActive(value: false);
		}
		else
		{
			updateCard(character.cards.cards[curSelectedCard]);
		}
	}

	public void updateCard(Card toShow)
	{
		if (character.menuID != 55)
		{
			return;
		}
		if (toShow.type == cardType.end)
		{
			cardBG.sprite = normalBg;
		}
		else if (toShow.cardRarity == rarity.BigChonker)
		{
			cardBG.sprite = chonkerBG;
		}
		else if (toShow.type == cardType.foil)
		{
			cardBG.sprite = foilbg;
		}
		else
		{
			cardBG.sprite = normalBg;
		}
		if (toShow.type == cardType.end)
		{
			cardArt.sprite = endSprite;
		}
		else if (toShow.artID < 0 || toShow.artID >= art.Count)
		{
			cardArt.sprite = unkownSprite;
		}
		else
		{
			cardArt.sprite = art[toShow.artID];
		}
		int num = 0;
		cardDesc.alignment = TextAnchor.MiddleCenter;
		for (int i = 0; i < manaIcons.Length; i++)
		{
			manaIcons[i].gameObject.SetActive(value: false);
			manaAmounts[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < toShow.manaCosts.Count; j++)
		{
			if (toShow.manaCosts[j] > 0)
			{
				manaIcons[num].gameObject.SetActive(value: true);
				manaAmounts[num].gameObject.SetActive(value: true);
				manaIcons[num].sprite = manaSprites[j];
				manaAmounts[num].text = toShow.manaCosts[j].ToString();
				num++;
			}
			else
			{
				num++;
			}
		}
		tierIcon.gameObject.SetActive(value: true);
		if (toShow.type == cardType.end)
		{
			tierText.text = toShow.tier.ToString();
			cardName.text = toShow.cardName;
			cardDesc.text = "!@#Df5g ^6h7JdCE RB5$%rd6hHB $4 &8DF9_+ :</RDe: ^4CHY Hyt";
		}
		else
		{
			tierText.text = toShow.tier.ToString();
			cardName.text = toShow.cardName;
			cardDesc.text = getCardDescription(toShow);
		}
	}

	public void updateText()
	{
		deckSpaceText.text = "Deck Size\n" + character.cards.cards.Count + " / " + maxDeckSize();
		pagesText.text = "Page " + (deckpageID + 1);
	}

	public void updateManaPods()
	{
		if (character.menuID == 55)
		{
			for (int i = 0; i < manaUI.Count; i++)
			{
				updateManaBar(i);
				updateManaAmount(i);
				updateManaToggles(i);
			}
		}
	}

	public void updateManaPod(int manaID)
	{
		if (character.menuID == 55 && manaID >= 0 && manaID <= manaUI.Count)
		{
			updateManaBar(manaID);
			updateManaAmount(manaID);
			updateManaToggles(manaID);
		}
	}

	public void updateManaBar(int manaID)
	{
		if (character.menuID == 55 && manaID >= 0 && manaID <= manaUI.Count)
		{
			manaUI[manaID].manaSlider.value = character.cards.manas[manaID].progress;
		}
	}

	public void updateManaAmount(int manaID)
	{
		if (character.menuID == 55 && manaID >= 0 && manaID <= manaUI.Count)
		{
			manaUI[manaID].manaCount.text = "<b>" + character.cards.manas[manaID].amount + "</b>";
		}
	}

	public void updateManaGenText()
	{
		if (character.menuID == 55)
		{
			manaGenText.text = "<b>" + curManaToggleCount() + " / " + maxManaGenSize() + " Mayo Generators Running</b>";
		}
	}

	public void updateManaToggles(int manaID)
	{
		if (character.menuID == 55 && manaID >= 0 && manaID <= manaUI.Count)
		{
			if (character.cards.manas[manaID].running)
			{
				manaUI[manaID].manaCheckmark.color = Color.white;
			}
			else
			{
				manaUI[manaID].manaCheckmark.color = Color.clear;
			}
		}
	}

	public void toggleManaGen(int manaID)
	{
		if (manaID >= 0 && manaID <= character.cards.manas.Count)
		{
			if (character.cards.manas[manaID].running)
			{
				character.cards.manas[manaID].running = false;
				updateManaPod(manaID);
				updateManaGenText();
			}
			else if (curManaToggleCount() >= maxManaGenSize())
			{
				tooltip.showOverrideTooltip("You have the max number of Mayo Generators running at once! Turn another Mayo Generator off first!", 3f);
			}
			else
			{
				character.cards.manas[manaID].running = true;
				updateManaPod(manaID);
				updateManaGenText();
			}
		}
	}

	public int curManaToggleCount()
	{
		int num = 0;
		for (int i = 0; i < character.cards.manas.Count; i++)
		{
			if (character.cards.manas[i].running)
			{
				num++;
			}
		}
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public void updateTagPods()
	{
		for (int i = 0; i < tagUI.Count; i++)
		{
			updateTagPod(i + 1);
		}
	}

	public void updateTagPod(int tagID)
	{
		updateTagCheckmark(tagID);
		updateTagText(tagID);
	}

	public void updateTagCheckmark(int tagID)
	{
		if (character.menuID == 55 && tagPanelShown)
		{
			if (character.cards.taggedBonuses.Contains((cardBonus)tagID))
			{
				tagUI[tagID - 1].tagCheckmark.color = Color.white;
			}
			else
			{
				tagUI[tagID - 1].tagCheckmark.color = Color.clear;
			}
		}
	}

	public void updateTagText(int tagID)
	{
		if (character.menuID == 55 && tagPanelShown)
		{
			string bonusName = getBonusName((cardBonus)tagID);
			tagUI[tagID - 1].tagText.text = bonusName + " (" + generateCardTier((cardBonus)tagID) + ")";
		}
	}

	public void updateTagPanelText()
	{
		if (character.menuID == 55)
		{
			taggedBonusesText.text = character.cards.taggedBonuses.Count + " / " + maxTagSize() + " Bonuses Tagged";
			Text text = taggedBonusesText;
			text.text = text.text + "\n\nTag Effect: " + (tagEffect() * 100f).ToString("#0.##") + "%";
		}
	}

	public int curTagCount()
	{
		return character.cards.taggedBonuses.Count;
	}

	public void updateTotalBonuses()
	{
		if (character.menuID == 55)
		{
			bonusListUI.updatePod();
		}
	}

	public void updateDeckPods()
	{
		if (character.menuID != 55)
		{
			return;
		}
		foreach (DeckPodUI deckPod in deckPods)
		{
			deckPod.updatePod();
		}
	}

	public void updateDeckPod(int deckPodID)
	{
		if (character.menuID == 55 && deckPodID >= 0 && deckPodID < deckPods.Count)
		{
			deckPods[deckPodID].updatePod();
		}
	}

	public void updateDeckCard(int cardID)
	{
		if (character.menuID == 55 && cardID >= 0 && cardID < character.cards.cards.Count)
		{
			int deckPodID = cardID - deckpageID * deckPods.Count;
			updateDeckPod(deckPodID);
		}
	}

	public void updateGhostPod()
	{
		if (character.menuID == 55)
		{
			ghost.updatePod();
		}
	}

	public string getRarityColorTag(rarity rarity)
	{
		switch (rarity)
		{
		case rarity.Crappy:
			return "<color=#5A1D05>";
		case rarity.Bad:
			return "<color=#A7421B>";
		case rarity.Meh:
			return "<color=#A77C2F>";
		case rarity.Okay:
			return "<color=#786B00>";
		case rarity.Good:
			return "<color=#748803>";
		case rarity.Great:
			return "<color=#3E7600>";
		case rarity.Damn:
			return "<color=#177600>";
		case rarity.BigChonker:
			return "<color=#7000A7>";
		default:
			return "<color=black>";
		}
	}

	public string getCardDescription(Card card)
	{
		return string.Concat(getBonusName(card.bonusType) + "\nEffect: +" + (card.effectAmount * 100f).ToString("###,##0.###") + " %", "\nRarity: ", getRarityName(card.cardRarity));
	}

	public string getBonusName(cardBonus type)
	{
		switch (type)
		{
		case cardBonus.adventureStat:
			return "Adventure Stats";
		case cardBonus.energyNGUSpeed:
			return "Energy NGU Speed";
		case cardBonus.magicNGUSpeed:
			return "Magic NGU Speed";
		case cardBonus.wandoosSpeed:
			return "Wandoos Speed";
		case cardBonus.augSpeed:
			return "Augment Speed";
		case cardBonus.TMSpeed:
			return "Time Machine Speed";
		case cardBonus.hackSpeed:
			return "Hack Speed";
		case cardBonus.wishSpeed:
			return "Wish Speed";
		case cardBonus.atkDefStats:
			return "Attack/Defense";
		case cardBonus.dropChance:
			return "Drop Chance";
		case cardBonus.goldDrop:
			return "Gold Drops";
		case cardBonus.PP:
			return "PP Gain";
		case cardBonus.QP:
			return "QP Gain";
		case cardBonus.dayCareSpeed:
			return "Daycare Speed";
		default:
			return type.ToString();
		}
	}

	public string getShortBonusName(cardBonus type)
	{
		switch (type)
		{
		case cardBonus.adventureStat:
			return "Adv";
		case cardBonus.energyNGUSpeed:
			return "E-NGU";
		case cardBonus.magicNGUSpeed:
			return "M-NGU";
		case cardBonus.wandoosSpeed:
			return "Wandoos";
		case cardBonus.augSpeed:
			return "Augs";
		case cardBonus.TMSpeed:
			return "TM";
		case cardBonus.hackSpeed:
			return "Hacks";
		case cardBonus.wishSpeed:
			return "Wishes";
		case cardBonus.atkDefStats:
			return "A/D";
		case cardBonus.dropChance:
			return "Drops";
		case cardBonus.goldDrop:
			return "Gold";
		case cardBonus.PP:
			return "PP";
		case cardBonus.QP:
			return "QP";
		case cardBonus.dayCareSpeed:
			return "Daycare";
		default:
			return type.ToString();
		}
	}

	public string getRarityName(rarity rarity)
	{
		switch (rarity)
		{
		case rarity.Crappy:
			return "Crappy";
		case rarity.Bad:
			return "Bad";
		case rarity.Meh:
			return "Meh";
		case rarity.Okay:
			return "Okay";
		case rarity.Good:
			return "Good";
		case rarity.Great:
			return "Great";
		case rarity.Damn:
			return "HOT DAMN";
		case rarity.BigChonker:
			return "BIG CHONKER";
		default:
			return "Buggy Rarity - tell 4G";
		}
	}

	public string getRarityNameShort(rarity rarity)
	{
		switch (rarity)
		{
		case rarity.Crappy:
			return "Crappy";
		case rarity.Bad:
			return "Bad";
		case rarity.Meh:
			return "Meh";
		case rarity.Okay:
			return "Okay";
		case rarity.Good:
			return "Good";
		case rarity.Great:
			return "Great";
		case rarity.Damn:
			return "Hot Damn";
		case rarity.BigChonker:
			return "CHONKER";
		default:
			return "Buggy Rarity - tell 4G";
		}
	}

	public string getManaName(int manaID)
	{
		if (manaID < 0 || manaID >= character.cards.manas.Count)
		{
			return "Bad Mana Name. Tell 4G.";
		}
		return manaNames[manaID];
	}

	public void tryConsumeCurrentCard()
	{
		tryConsumeCard(curSelectedCard);
	}

	public void tryConsumeCard(int cardID)
	{
		if (invalidID(cardID))
		{
			return;
		}
		if (character.cards.cards[cardID].isProtected)
		{
			tooltip.showOverrideTooltip("You need to turn OFF protection on this card before you can cast it!", 2f);
			return;
		}
		Card card = character.cards.cards[cardID];
		if (card.type == cardType.end && !character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip(" You need free inventory space to play this card!", 2f);
			return;
		}
		for (int i = 0; i < character.cards.manas.Count; i++)
		{
			if (card.manaCosts[i] > character.cards.manas[i].amount)
			{
				tooltip.showOverrideTooltip(" You need more " + getManaName(i) + " to play this card!", 2f);
				return;
			}
		}
		for (int j = 0; j < character.cards.manas.Count; j++)
		{
			if (card.manaCosts[j] >= 1)
			{
				character.cards.manas[j].amount -= card.manaCosts[j];
			}
		}
		if (card.type == cardType.end)
		{
			string message = "YOU BRING THE END NEARER.";
			character.itemInfo.makeLevelledLoot(492, 100);
			character.cards.deleteCard(cardID);
			updateCard();
			updateManaPods();
			updateDeckPods();
			updateDeckButtons();
			updateTotalBonuses();
			updateText();
			tooltip.showTooltip(message, 3f);
			return;
		}
		string message2 = "You Cast <b>" + card.cardName + "</b> and gain <b>+" + bonusAmountString(card.effectAmount) + " " + getBonusName(card.bonusType) + "</b>!";
		character.cards.bonuses[(int)card.bonusType] += card.effectAmount;
		character.cards.deleteCard(cardID);
		if (character.cards.cards.Count == 0)
		{
			curSelectedCard = 0;
		}
		else if (curSelectedCard >= character.cards.cards.Count)
		{
			curSelectedCard = character.cards.cards.Count - 1;
		}
		if (deckpageID > 0 && deckpageID > (character.cards.cards.Count - 1) / deckPods.Count)
		{
			deckPageBack();
		}
		updateCard();
		updateManaPods();
		updateDeckPods();
		updateDeckButtons();
		updateTotalBonuses();
		updateText();
		tooltip.showTooltip(message2, 3f);
	}

	public bool invalidID(int id)
	{
		if (id < 0 || id >= character.cards.cards.Count)
		{
			return true;
		}
		return false;
	}

	public void cardForward()
	{
		int cardID = curSelectedCard;
		if (curSelectedCard >= character.cards.cards.Count - 1)
		{
			curSelectedCard = 0;
		}
		else
		{
			curSelectedCard++;
		}
		updateCard();
		updateDeckCard(curSelectedCard);
		updateDeckCard(cardID);
	}

	public void cardBack()
	{
		int cardID = curSelectedCard;
		if (curSelectedCard <= 0)
		{
			curSelectedCard = character.cards.cards.Count - 1;
		}
		else
		{
			curSelectedCard--;
		}
		updateCard();
		updateDeckCard(curSelectedCard);
		updateDeckCard(cardID);
	}

	public void selectNewCard(int newID)
	{
		if (!invalidID(newID))
		{
			int cardID = curSelectedCard;
			curSelectedCard = newID;
			updateCard();
			updateDeckCard(curSelectedCard);
			updateDeckCard(cardID);
		}
	}

	public void protectCurrentCard()
	{
		if (!invalidID(curSelectedCard))
		{
			protectCard(curSelectedCard);
		}
	}

	public void protectCard(int cardID)
	{
		if (!invalidID(cardID))
		{
			character.cards.cards[cardID].isProtected = !character.cards.cards[cardID].isProtected;
			updateCard();
			updateDeckCard(cardID);
		}
	}

	public void trashCurrentCard()
	{
		if (character.cards.cards.Count != 0 && !invalidID(curSelectedCard))
		{
			trashCard(curSelectedCard);
		}
	}

	public void trashCard(int cardID)
	{
		if (character.cards.cards.Count == 0 || invalidID(cardID))
		{
			return;
		}
		if (character.cards.cards[cardID].isProtected)
		{
			character.tooltip.showOverrideTooltip("You're trying to yeet a protected card you maniac, unprotect it first!", 2f);
			return;
		}
		postYeetEffect(character.cards.cards[cardID]);
		character.cards.deleteCard(cardID);
		if (character.cards.cards.Count == 0)
		{
			curSelectedCard = 0;
		}
		else if (curSelectedCard >= character.cards.cards.Count)
		{
			curSelectedCard = character.cards.cards.Count - 1;
		}
		if (deckpageID > 0 && deckpageID > (character.cards.cards.Count - 1) / deckPods.Count)
		{
			deckPageBack();
		}
		updateCard();
		updateDeckPods();
		updateDeckButtons();
		updateText();
	}

	public void postYeetEffect(Card yeetedCard)
	{
		string text = "";
		text = ((character.adventure.itopod.perkLevel[216] < 1 && character.beastQuest.quirkLevel[156] < 1) ? ("You Yeeted <b>'" + yeetedCard.cardName + "'</b> from your deck!") : ("You Yeeted <b>'" + yeetedCard.cardName + "'</b> from your deck and:"));
		if (character.adventure.itopod.perkLevel[216] >= 1)
		{
			if (yeetedCard.cardRarity == rarity.BigChonker)
			{
				character.cards.chonkerSpawnTimer.advanceTime(chonkerSpawnTime() * 0.25f);
				text += "\nAdvanced your Chonker spawn timer by 25%!";
			}
			else
			{
				character.cards.cardSpawnTimer.advanceTime(cardSpawnTime() * 0.1f);
				text += "\nAdvanced your Card Spawn timer by 10%!";
			}
		}
		if (character.beastQuest.quirkLevel[156] >= 1)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < yeetedCard.manaCosts.Count; i++)
			{
				if (yeetedCard.manaCosts[i] > 0)
				{
					list.Add(i);
				}
			}
			int manaID = 0;
			if (list.Count > 0)
			{
				manaID = list[UnityEngine.Random.Range(0, list.Count)];
			}
			addBigManaProgress(0.2f, manaID);
			updateManaPod(manaID);
			text = text + "\nGained 20% progress on " + getManaName(manaID) + "!";
		}
		tooltip.showTooltip(text, 3f);
	}

	public void swapCards()
	{
		swapCards(beginDrag, endDrag);
		beginDrag = -1;
		endDrag = -1;
		midDrag = false;
		ghost.deckID = 0;
	}

	public void swapCards(int cardID1, int cardID2)
	{
		if (!invalidID(cardID1) && !invalidID(cardID2) && cardID1 != cardID2)
		{
			Card otherCard = new Card(character.cards.cards[cardID1]);
			character.cards.cards[cardID1] = new Card(character.cards.cards[cardID2]);
			character.cards.cards[cardID2] = new Card(otherCard);
			updateCard();
			updateDeckCard(cardID1);
			updateDeckCard(cardID2);
		}
	}

	public float generateCardEffect(cardBonus bonusType, int cardTier, int totalCost, float variance, bool bigChonker)
	{
		switch (bonusType)
		{
		case cardBonus.energyNGUSpeed:
			return calculateEnergyNGUEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.magicNGUSpeed:
			return calculateMagicNGUEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.wandoosSpeed:
			return calculateWandoosEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.augSpeed:
			return calculateAugEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.TMSpeed:
			return calculateTMEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.hackSpeed:
			return calculateHackEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.wishSpeed:
			return calculateWishEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.atkDefStats:
			return calculateStatEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.adventureStat:
			return calculateAdventureStatEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.dropChance:
			return calculateDropChanceEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.goldDrop:
			return calculateGoldDropEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.dayCareSpeed:
			return calculateDaycareSpeedEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.PP:
			return calculatePPEffect(cardTier, totalCost, variance, bigChonker);
		case cardBonus.QP:
			return calculateQPEffect(cardTier, totalCost, variance, bigChonker);
		default:
			return 0f;
		}
	}

	public float bigChonkerFactor()
	{
		return 2f;
	}

	public float getTierFactor(int cardTier, float quadFactor, float expFactor)
	{
		return 1f * Mathf.Pow(cardTier, quadFactor) * Mathf.Pow(expFactor, cardTier);
	}

	public float calculateEnergyNGUEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 1.2f, 1.03f);
		return 0.0003f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateMagicNGUEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.8f, 1.08f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateWandoosEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.8f, 1.1f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateAugEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.8f, 1.1f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateTMEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.8f, 1.15f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateHackEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.4f, 1.05f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateWishEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.5f, 1.05f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateStatEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 1.5f, 2f);
		return 0.05f * (float)totalCost + 0.01f * (float)totalCost * tierFactor * variance;
	}

	public float calculateAdventureStatEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.4f, 1.07f);
		return 0.0005f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateDropChanceEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 1f, 1.15f);
		return 0.0002f * (float)totalCost + 0.001f * (float)totalCost * tierFactor * variance;
	}

	public float calculateGoldDropEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.8f, 1.15f);
		return 0.001f * (float)totalCost + 0.005f * (float)totalCost * tierFactor * variance;
	}

	public float calculateDaycareSpeedEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.4f, 1.04f);
		return 5E-05f * (float)totalCost + 0.0002f * (float)totalCost * tierFactor * variance;
	}

	public float calculatePPEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.6f, 1.11f);
		return 0.0001f * (float)totalCost + 0.0002f * (float)totalCost * tierFactor * variance;
	}

	public float calculateQPEffect(int cardTier, int totalCost, float variance, bool bigChonker)
	{
		float tierFactor = getTierFactor(cardTier, 0.6f, 1.08f);
		return 0.0001f * (float)totalCost + 0.0002f * (float)totalCost * tierFactor * variance;
	}

	public string cardBonusAmountDeckPod(float amount)
	{
		if (amount < 1f)
		{
			return (amount * 100f).ToString("#0.###") + "%";
		}
		return (amount * 100f).ToString("###,###") + "%";
	}

	public string bonusAmountString(float amount)
	{
		if (amount < 2f)
		{
			return (amount * 100f).ToString("#0.###") + "%";
		}
		return (amount * 100f).ToString("###,###") + "%";
	}

	public string cardBonusString(cardBonus bonusType)
	{
		if (bonusType == cardBonus.none)
		{
			return cardBonusAmountDeckPod(1f);
		}
		return bonusAmountString(getBonus(bonusType));
	}

	public string cardBonusAmountDeckPod(Card toShow)
	{
		return cardBonusAmountDeckPod(toShow.effectAmount);
	}

	public void addBigManaProgress(float toAdd, int manaID)
	{
		if (manaID < 0 || manaID > character.cards.manas.Count)
		{
			return;
		}
		float num = character.cards.manas[manaID].progress + toAdd;
		if (num >= 1f)
		{
			int num2 = Mathf.FloorToInt(num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			character.cards.manas[manaID].amount += num2;
			num %= 1f;
		}
		character.cards.manas[manaID].progress = num;
	}

	public void giveTestMana()
	{
		for (int i = 0; i < character.cards.manas.Count; i++)
		{
			character.cards.manas[i].amount += 500;
		}
		updateManaPods();
	}

	public string cardBonusAmountBonusPod(float amount)
	{
		if (amount < 2f)
		{
			return (amount * 100f).ToString("##0.###") + "%";
		}
		return (amount * 100f).ToString("###,###") + "%";
	}

	public float getBonus(cardBonus bonusType)
	{
		if (!character.cards.cardsOn)
		{
			return 1f;
		}
		if (bonusType == cardBonus.none)
		{
			return 1f;
		}
		return character.cards.bonuses[(int)bonusType];
	}

	public float totalCardSpeed()
	{
		float num = 1f;
		num *= character.adventureController.itopod.totalCardSpeed();
		num *= character.beastQuestPerkController.totalCardSpeed();
		num *= character.wishesController.totalCardSpeed();
		if (character.inventory.itemList.rainbowHeartComplete)
		{
			num *= 1.1f;
		}
		if (character.inventory.itemList.duckComplete)
		{
			num *= 1.06f;
		}
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 5)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float totalMayoSpeed()
	{
		float num = 1f;
		num *= character.adventureController.itopod.totalMayoSpeed();
		num *= character.beastQuestPerkController.totalMayoSpeed();
		num *= character.wishesController.totalMayoSpeed();
		if (character.inventory.itemList.rainbowHeartComplete)
		{
			num *= 1.1f;
		}
		if (character.inventory.itemList.duckComplete)
		{
			num *= 1.06f;
		}
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 6)
		{
			num *= 1.1f;
		}
		num *= 1f + (float)(maxManaGenSize() - 1) * 0.02f;
		if (character.arbitrary.mayoSpeedPotTime.totalseconds > 0.0)
		{
			num *= character.allArbitrary.potionModifier();
		}
		return num;
	}

	public string timeToCardSpawn()
	{
		return "" + NumberOutput.timeOutput(((double)character.cardsController.cardSpawnTime() - character.cards.cardSpawnTimer.totalseconds) / (double)totalCardSpeed());
	}

	public string timeToChonkerSpawn()
	{
		return "" + NumberOutput.timeOutput(((double)character.cardsController.chonkerSpawnTime() - character.cards.chonkerSpawnTimer.totalseconds) / (double)totalCardSpeed());
	}

	public void tagBonusTooltip()
	{
		tooltip.showTooltip("When cards spawn, Tagged Bonuses receive a <b>" + (tagEffect() * 100f).ToString("#0.##") + "%</b> chance of automatically being selected!");
	}

	public void awardSomeMayoIGuess(int mayo1, int mayo2, int mayo3, int mayo4, int mayo5, int mayo6)
	{
		character.cards.manas[0].amount += mayo1;
		character.cards.manas[1].amount += mayo2;
		character.cards.manas[2].amount += mayo3;
		character.cards.manas[3].amount += mayo4;
		character.cards.manas[4].amount += mayo5;
		character.cards.manas[5].amount += mayo6;
		updateManaPods();
	}
}
