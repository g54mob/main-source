using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public PossibleSpinRewardController rewardDisplay;

	public Text outcomeText;

	public Text rewardOutcomeTitle;

	public Image rarityBackground;

	public Image outcomeBorder;

	public Image rarity0;

	public Image rarity1;

	public Image rarity2;

	public Image rarity3;

	public Image rarity4;

	public Text timeText;

	public List<List<string>> rewardNames = new List<List<string>>();

	public List<List<int>> rewardRarity = new List<List<int>>();

	public bool inSpinLoop;

	public int spinCounter;

	public int oldOffset;

	public int newOffset;

	public PlayerTime spinnerTimer = new PlayerTime();

	private void Awake()
	{
		constructRewardNames();
	}

	public void Start()
	{
		InvokeRepeating("updateTimeText", 0f, 1f);
	}

	public float maxSpinTime()
	{
		if (character.arbitrary.hasExtendedSpinBank)
		{
			return 604800f;
		}
		return 129600f;
	}

	public float targetSpinTime()
	{
		return 86400f;
	}

	private void constructRewardNames()
	{
		rarity0.color = Color.white;
		rarity1.color = new Color(0.6f, 0.851f, 0.917f);
		rarity2.color = new Color(1f, 0.682f, 0.788f);
		rarity3.color = new Color(0.784f, 0.749f, 0.906f);
		rarity4.color = new Color(1f, 0.827f, 0.235f);
		while (rewardNames.Count < 8)
		{
			rewardNames.Add(new List<string>());
		}
		while (rewardRarity.Count < 8)
		{
			rewardRarity.Add(new List<int>());
		}
		rewardRarity[0].Add(0);
		rewardNames[0].Add("+" + character.checkAPAdded(50L) + "Arbitrary Points!");
		rewardRarity[0].Add(0);
		rewardNames[0].Add("+" + character.checkAPAdded(100L) + "Arbitrary Points!");
		rewardRarity[0].Add(1);
		rewardNames[0].Add("+" + character.checkAPAdded(500L) + "Arbitrary Points!");
		rewardRarity[1].Add(0);
		rewardNames[1].Add("+" + character.checkAPAdded(100L) + "Arbitrary Points!");
		rewardRarity[1].Add(0);
		rewardNames[1].Add("+" + character.checkAPAdded(200L) + "Arbitrary Points!");
		rewardRarity[1].Add(1);
		rewardNames[1].Add("+" + character.checkAPAdded(1000L) + "Arbitrary Points!");
		rewardRarity[1].Add(3);
		rewardNames[1].Add("+1 Energy Potion α!");
		rewardRarity[1].Add(3);
		rewardNames[1].Add("+1 Magic Potion α!");
		rewardRarity[2].Add(0);
		rewardNames[2].Add("+" + character.checkAPAdded(200L) + "Arbitrary Points!");
		rewardRarity[2].Add(0);
		rewardNames[2].Add("+" + character.checkAPAdded(400L) + "Arbitrary Points!");
		rewardRarity[2].Add(1);
		rewardNames[2].Add("+" + character.checkAPAdded(2000L) + "Arbitrary Points!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Energy Potion α!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Magic Potion α!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Energy Potion β!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Magic Potion β!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Lucky Charm!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Energy Bar Bar");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Magic Bar Bar");
		rewardRarity[3].Add(0);
		rewardNames[3].Add("+" + character.checkAPAdded(300L) + "Arbitrary Points!");
		rewardRarity[3].Add(0);
		rewardNames[3].Add("+" + character.checkAPAdded(600L) + "Arbitrary Points!");
		rewardRarity[3].Add(1);
		rewardNames[3].Add("+" + character.checkAPAdded(3000L) + "Arbitrary Points!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Energy Potion α!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Magic Potion α!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Energy Potion β!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Magic Potion β!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Lucky Charm!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Energy Bar Bar!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Magic Bar Bar!");
		rewardRarity[3].Add(2);
		rewardNames[3].Add("+20 Seeds!");
		rewardRarity[3].Add(2);
		rewardNames[3].Add("+2 poop!");
		rewardRarity[3].Add(4);
		rewardNames[3].Add("CONSUMABLES JACKPOT!");
		rewardRarity[3].Add(4);
		rewardNames[3].Add(character.checkAPAdded(50000L) + " AP! :o");
		rewardRarity[4].Add(0);
		rewardNames[4].Add("+" + character.checkAPAdded(500L) + "Arbitrary Points!");
		rewardRarity[4].Add(0);
		rewardNames[4].Add("+" + character.checkAPAdded(1000L) + "Arbitrary Points!");
		rewardRarity[4].Add(1);
		rewardNames[4].Add("+" + character.checkAPAdded(5000L) + "Arbitrary Points!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Energy Potion α!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Magic Potion α!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Energy Potion β!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Magic Potion β!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Lucky Charm!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Energy Bar Bar!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Magic Bar Bar!");
		rewardRarity[4].Add(2);
		rewardNames[4].Add("+100 Seeds!");
		rewardRarity[4].Add(2);
		rewardNames[4].Add("+5 poop!");
		rewardRarity[4].Add(4);
		rewardNames[4].Add("CONSUMABLES JACKPOT!");
		rewardRarity[4].Add(4);
		rewardNames[4].Add(character.checkAPAdded(75000L) + " AP! :o");
		rewardRarity[4].Add(4);
		rewardNames[4].Add("+1 Energy Potion δ!");
		rewardRarity[4].Add(4);
		rewardNames[4].Add("+1 Magic Potion δ!");
		rewardRarity[5].Add(0);
		rewardNames[5].Add("+" + character.checkAPAdded(800L) + "Arbitary Points!");
		rewardRarity[5].Add(0);
		rewardNames[5].Add("+" + character.checkAPAdded(1600L) + "Arbitrary Points!");
		rewardRarity[5].Add(1);
		rewardNames[5].Add("+" + character.checkAPAdded(8000L) + "Arbitrary Points!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Energy Potion α!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Magic Potion α!");
		rewardRarity[5].Add(3);
		rewardNames[5].Add("+1 Energy Potion β!");
		rewardRarity[5].Add(3);
		rewardNames[5].Add("+1 Magic Potion β!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Lucky Charm!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Energy Bar Bar!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Magic Bar Bar!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+400 Seeds!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+10 poop!");
		rewardRarity[5].Add(4);
		rewardNames[5].Add("CONSUMABLES JACKPOT!");
		rewardRarity[5].Add(4);
		rewardNames[5].Add(character.checkAPAdded(100000L) + "AP! :o");
		rewardRarity[5].Add(4);
		rewardNames[5].Add("+1 Energy Potion δ!");
		rewardRarity[5].Add(4);
		rewardNames[5].Add("+1 Magic Potion δ!");
		rewardRarity[6].Add(0);
		rewardNames[6].Add("+" + character.checkAPAdded(1200L) + "Arbitrary Points!");
		rewardRarity[6].Add(0);
		rewardNames[6].Add("+" + character.checkAPAdded(2400L) + "Arbitrary Points!");
		rewardRarity[6].Add(1);
		rewardNames[6].Add("+" + character.checkAPAdded(12000L) + "Arbitrary Points!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Energy Potion α!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Magic Potion α!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+2 Energy Potion β!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+2 Magic Potion β!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Lucky Charm!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Energy Bar Bar!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Magic Bar Bar!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2000 Seeds!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+25 poop!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+1 Energy Potion δ!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+1 Magic Potion δ!");
		rewardRarity[6].Add(4);
		rewardNames[6].Add("CONSUMABLES JACKPOT!");
		rewardRarity[6].Add(4);
		rewardNames[6].Add(character.checkAPAdded(150000L) + " AP! :o");
		rewardRarity[7].Add(0);
		rewardNames[7].Add("+" + character.checkAPAdded(1500L) + " Arbitrary Points!");
		rewardRarity[7].Add(0);
		rewardNames[7].Add("+" + character.checkAPAdded(3000L) + "Arbitrary Points!");
		rewardRarity[7].Add(1);
		rewardNames[7].Add("+" + character.checkAPAdded(15000L) + " Arbitrary Points!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Energy Potion α!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Magic Potion α!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+2 Energy Potion β!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+2 Magic Potion β!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Lucky Charm!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Energy Bar Bar!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Magic Bar Bar!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2000 Seeds!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+25 poop!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+1 Energy Potion δ!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+1 Magic Potion δ!");
		rewardRarity[7].Add(4);
		rewardNames[7].Add("CONSUMABLES JACKPOT!");
		rewardRarity[7].Add(4);
		rewardNames[7].Add("+" + character.checkAPAdded(175000L) + " AP! :o");
	}

	public void reConstructRewardNames()
	{
		rarity0.color = Color.white;
		rarity1.color = new Color(0.6f, 0.851f, 0.917f);
		rarity2.color = new Color(1f, 0.682f, 0.788f);
		rarity3.color = new Color(0.784f, 0.749f, 0.906f);
		rarity4.color = new Color(1f, 0.827f, 0.235f);
		rewardNames.Clear();
		rewardRarity.Clear();
		while (rewardNames.Count < 8)
		{
			rewardNames.Add(new List<string>());
		}
		while (rewardRarity.Count < 8)
		{
			rewardRarity.Add(new List<int>());
		}
		rewardRarity[0].Add(0);
		rewardNames[0].Add("+" + character.checkAPAdded(50L) + " Arbitrary Points!");
		rewardRarity[0].Add(0);
		rewardNames[0].Add("+" + character.checkAPAdded(100L) + " Arbitrary Points!");
		rewardRarity[0].Add(1);
		rewardNames[0].Add("+" + character.checkAPAdded(500L) + " Arbitrary Points!");
		rewardRarity[1].Add(0);
		rewardNames[1].Add("+" + character.checkAPAdded(100L) + " Arbitrary Points!");
		rewardRarity[1].Add(0);
		rewardNames[1].Add("+" + character.checkAPAdded(200L) + " Arbitrary Points!");
		rewardRarity[1].Add(1);
		rewardNames[1].Add("+" + character.checkAPAdded(1000L) + " Arbitrary Points!");
		rewardRarity[1].Add(3);
		rewardNames[1].Add("+1 Energy Potion α!");
		rewardRarity[1].Add(3);
		rewardNames[1].Add("+1 Magic Potion α!");
		rewardRarity[2].Add(0);
		rewardNames[2].Add("+" + character.checkAPAdded(200L) + " Arbitrary Points!");
		rewardRarity[2].Add(0);
		rewardNames[2].Add("+" + character.checkAPAdded(400L) + " Arbitrary Points!");
		rewardRarity[2].Add(1);
		rewardNames[2].Add("+" + character.checkAPAdded(2000L) + " Arbitrary Points!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Energy Potion α!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Magic Potion α!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Energy Potion β!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Magic Potion β!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Lucky Charm!");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Energy Bar Bar");
		rewardRarity[2].Add(3);
		rewardNames[2].Add("+1 Magic Bar Bar");
		rewardRarity[3].Add(0);
		rewardNames[3].Add("+" + character.checkAPAdded(300L) + " Arbitrary Points!");
		rewardRarity[3].Add(0);
		rewardNames[3].Add("+" + character.checkAPAdded(600L) + " Arbitrary Points!");
		rewardRarity[3].Add(1);
		rewardNames[3].Add("+" + character.checkAPAdded(3000L) + " Arbitrary Points!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Energy Potion α!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Magic Potion α!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Energy Potion β!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Magic Potion β!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Lucky Charm!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Energy Bar Bar!");
		rewardRarity[3].Add(3);
		rewardNames[3].Add("+1 Magic Bar Bar!");
		rewardRarity[3].Add(2);
		rewardNames[3].Add("+20 Seeds!");
		rewardRarity[3].Add(2);
		rewardNames[3].Add("+2 poop!");
		rewardRarity[3].Add(4);
		rewardNames[3].Add("CONSUMABLES JACKPOT!");
		rewardRarity[3].Add(4);
		rewardNames[3].Add(character.checkAPAdded(50000L) + " AP! :o");
		rewardRarity[4].Add(0);
		rewardNames[4].Add("+" + character.checkAPAdded(500L) + " Arbitrary Points!");
		rewardRarity[4].Add(0);
		rewardNames[4].Add("+" + character.checkAPAdded(1000L) + " Arbitrary Points!");
		rewardRarity[4].Add(1);
		rewardNames[4].Add("+" + character.checkAPAdded(5000L) + " Arbitrary Points!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Energy Potion α!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Magic Potion α!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Energy Potion β!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Magic Potion β!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Lucky Charm!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Energy Bar Bar!");
		rewardRarity[4].Add(3);
		rewardNames[4].Add("+1 Magic Bar Bar!");
		rewardRarity[4].Add(2);
		rewardNames[4].Add("+100 Seeds!");
		rewardRarity[4].Add(2);
		rewardNames[4].Add("+5 poop!");
		rewardRarity[4].Add(4);
		rewardNames[4].Add("CONSUMABLES JACKPOT!");
		rewardRarity[4].Add(4);
		rewardNames[4].Add(character.checkAPAdded(75000L) + " AP! :o");
		rewardRarity[4].Add(4);
		rewardNames[4].Add("+1 Energy Potion δ!");
		rewardRarity[4].Add(4);
		rewardNames[4].Add("+1 Magic Potion δ!");
		rewardRarity[5].Add(0);
		rewardNames[5].Add("+" + character.checkAPAdded(800L) + " Arbitary Points!");
		rewardRarity[5].Add(0);
		rewardNames[5].Add("+" + character.checkAPAdded(1600L) + " Arbitrary Points!");
		rewardRarity[5].Add(1);
		rewardNames[5].Add("+" + character.checkAPAdded(8000L) + " Arbitrary Points!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Energy Potion α!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Magic Potion α!");
		rewardRarity[5].Add(3);
		rewardNames[5].Add("+1 Energy Potion β!");
		rewardRarity[5].Add(3);
		rewardNames[5].Add("+1 Magic Potion β!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Lucky Charm!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Energy Bar Bar!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+1 Magic Bar Bar!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+400 Seeds!");
		rewardRarity[5].Add(2);
		rewardNames[5].Add("+10 poop!");
		rewardRarity[5].Add(4);
		rewardNames[5].Add("CONSUMABLES JACKPOT!");
		rewardRarity[5].Add(4);
		rewardNames[5].Add(character.checkAPAdded(100000L) + " AP! :o");
		rewardRarity[5].Add(4);
		rewardNames[5].Add("+1 Energy Potion δ!");
		rewardRarity[5].Add(4);
		rewardNames[5].Add("+1 Magic Potion δ!");
		rewardRarity[6].Add(0);
		rewardNames[6].Add("+" + character.checkAPAdded(1200L) + " Arbitrary Points!");
		rewardRarity[6].Add(0);
		rewardNames[6].Add("+" + character.checkAPAdded(2400L) + " Arbitrary Points!");
		rewardRarity[6].Add(1);
		rewardNames[6].Add("+" + character.checkAPAdded(12000L) + " Arbitrary Points!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Energy Potion α!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Magic Potion α!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+2 Energy Potion β!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+2 Magic Potion β!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Lucky Charm!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Energy Bar Bar!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2 Magic Bar Bar!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+2000 Seeds!");
		rewardRarity[6].Add(2);
		rewardNames[6].Add("+25 poop!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+1 Energy Potion δ!");
		rewardRarity[6].Add(3);
		rewardNames[6].Add("+1 Magic Potion δ!");
		rewardRarity[6].Add(4);
		rewardNames[6].Add("CONSUMABLES JACKPOT!");
		rewardRarity[6].Add(4);
		rewardNames[6].Add(character.checkAPAdded(150000L) + " AP! :o");
		rewardRarity[7].Add(0);
		rewardNames[7].Add("+" + character.checkAPAdded(1500L) + " Arbitrary Points!");
		rewardRarity[7].Add(0);
		rewardNames[7].Add("+" + character.checkAPAdded(3000L) + " Arbitrary Points!");
		rewardRarity[7].Add(1);
		rewardNames[7].Add("+" + character.checkAPAdded(15000L) + " Arbitrary Points!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Energy Potion α!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Magic Potion α!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+2 Energy Potion β!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+2 Magic Potion β!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Lucky Charm!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Energy Bar Bar!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2 Magic Bar Bar!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+2000 Seeds!");
		rewardRarity[7].Add(2);
		rewardNames[7].Add("+25 poop!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+1 Energy Potion δ!");
		rewardRarity[7].Add(3);
		rewardNames[7].Add("+1 Magic Potion δ!");
		rewardRarity[7].Add(4);
		rewardNames[7].Add("CONSUMABLES JACKPOT!");
		rewardRarity[7].Add(4);
		rewardNames[7].Add("+" + character.checkAPAdded(175000L) + " AP! :o");
	}

	public int getTier0RewardIndex(float rng)
	{
		if (rng < 0.6f)
		{
			return 0;
		}
		if (rng < 0.9f)
		{
			return 1;
		}
		if (rng < 0.1f)
		{
			return 2;
		}
		return 0;
	}

	public void tier0Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(50);
			break;
		case 1:
			character.addAP(100);
			break;
		case 2:
			character.addAP(500);
			break;
		}
	}

	public int getTier1RewardIndex(float rng)
	{
		if (rng < 0.5f)
		{
			return 0;
		}
		if (rng < 0.85f)
		{
			return 1;
		}
		if (rng < 0.95f)
		{
			return 2;
		}
		if (rng < 0.96f)
		{
			return 3;
		}
		if (rng < 0.97f)
		{
			return 4;
		}
		return 0;
	}

	public void tier1Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(100);
			break;
		case 1:
			character.addAP(200);
			break;
		case 2:
			character.addAP(1000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count++;
			break;
		case 4:
			character.arbitrary.magicPotion1Count++;
			break;
		}
	}

	public int getTier2RewardIndex(float rng)
	{
		if (rng < 0.45f)
		{
			return 0;
		}
		if (rng < 0.75f)
		{
			return 1;
		}
		if (rng < 0.85f)
		{
			return 2;
		}
		if (rng < 0.86f)
		{
			return 3;
		}
		if (rng < 0.87f)
		{
			return 4;
		}
		if (rng < 0.88f)
		{
			return 5;
		}
		if (rng < 0.89f)
		{
			return 6;
		}
		if (rng < 0.9f)
		{
			return 7;
		}
		if (rng < 0.91f)
		{
			return 8;
		}
		if (rng < 0.92f)
		{
			return 9;
		}
		return 0;
	}

	public void tier2Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(200);
			break;
		case 1:
			character.addAP(400);
			break;
		case 2:
			character.addAP(2000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count++;
			break;
		case 4:
			character.arbitrary.magicPotion1Count++;
			break;
		case 5:
			character.arbitrary.energyPotion2Count++;
			break;
		case 6:
			character.arbitrary.magicPotion2Count++;
			break;
		case 7:
			character.arbitrary.lootCharm1Count++;
			break;
		case 8:
			character.arbitrary.energyBarBar1Count++;
			break;
		case 9:
			character.arbitrary.magicBarBar1Count++;
			break;
		}
	}

	public int getTier3RewardIndex(float rng)
	{
		if (rng < 0.35f)
		{
			return 0;
		}
		if (rng < 0.6f)
		{
			return 1;
		}
		if (rng < 0.7f)
		{
			return 2;
		}
		if (rng < 0.72f)
		{
			return 3;
		}
		if (rng < 0.74f)
		{
			return 4;
		}
		if (rng < 0.75f)
		{
			return 5;
		}
		if (rng < 0.76f)
		{
			return 6;
		}
		if (rng < 0.78f)
		{
			return 7;
		}
		if (rng < 0.8f)
		{
			return 8;
		}
		if (rng < 0.82f)
		{
			return 9;
		}
		if (rng < 0.92f)
		{
			return 10;
		}
		if (rng < 0.97f)
		{
			return 11;
		}
		if (rng < 0.975f)
		{
			return 12;
		}
		if (rng < 0.98f)
		{
			return 13;
		}
		return 0;
	}

	public void tier3Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(300);
			break;
		case 1:
			character.addAP(600);
			break;
		case 2:
			character.addAP(3000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count++;
			break;
		case 4:
			character.arbitrary.magicPotion1Count++;
			break;
		case 5:
			character.arbitrary.energyPotion2Count++;
			break;
		case 6:
			character.arbitrary.magicPotion2Count++;
			break;
		case 7:
			character.arbitrary.lootCharm1Count++;
			break;
		case 8:
			character.arbitrary.energyBarBar1Count++;
			break;
		case 9:
			character.arbitrary.magicBarBar1Count++;
			break;
		case 10:
			character.yggdrasil.seeds += 20L;
			break;
		case 11:
			character.arbitrary.poop1Count += 2;
			break;
		case 12:
			character.arbitrary.energyPotion1Count++;
			character.arbitrary.energyPotion2Count++;
			character.arbitrary.magicPotion1Count++;
			character.arbitrary.magicPotion2Count++;
			character.arbitrary.lootCharm1Count++;
			character.arbitrary.energyBarBar1Count++;
			character.arbitrary.magicBarBar1Count++;
			character.arbitrary.poop1Count += 2;
			break;
		case 13:
			character.addAP(50000);
			break;
		}
	}

	public int getTier4RewardIndex(float rng)
	{
		if (rng < 0.35f)
		{
			return 0;
		}
		if (rng < 0.6f)
		{
			return 1;
		}
		if (rng < 0.7f)
		{
			return 2;
		}
		if (rng < 0.71f)
		{
			return 3;
		}
		if (rng < 0.72f)
		{
			return 4;
		}
		if (rng < 0.73f)
		{
			return 5;
		}
		if (rng < 0.74f)
		{
			return 6;
		}
		if (rng < 0.75f)
		{
			return 7;
		}
		if (rng < 0.76f)
		{
			return 8;
		}
		if (rng < 0.77f)
		{
			return 9;
		}
		if (rng < 0.82f)
		{
			return 10;
		}
		if (rng < 0.83f)
		{
			return 11;
		}
		if (rng < 0.835f)
		{
			return 12;
		}
		if (rng < 0.84f)
		{
			return 13;
		}
		if (rng < 0.845f)
		{
			return 14;
		}
		if (rng < 0.85f)
		{
			return 15;
		}
		return 0;
	}

	public void tier4Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(500);
			break;
		case 1:
			character.addAP(1000);
			break;
		case 2:
			character.addAP(5000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count++;
			break;
		case 4:
			character.arbitrary.magicPotion1Count++;
			break;
		case 5:
			character.arbitrary.energyPotion2Count++;
			break;
		case 6:
			character.arbitrary.magicPotion2Count++;
			break;
		case 7:
			character.arbitrary.lootCharm1Count++;
			break;
		case 8:
			character.arbitrary.energyBarBar1Count++;
			break;
		case 9:
			character.arbitrary.magicBarBar1Count++;
			break;
		case 10:
			character.yggdrasil.seeds += 100L;
			break;
		case 11:
			character.arbitrary.poop1Count += 5;
			break;
		case 12:
			character.arbitrary.energyPotion1Count++;
			character.arbitrary.energyPotion2Count++;
			character.arbitrary.energyPotion3Count++;
			character.arbitrary.magicPotion1Count++;
			character.arbitrary.magicPotion2Count++;
			character.arbitrary.magicPotion3Count++;
			character.arbitrary.lootCharm1Count++;
			character.arbitrary.energyBarBar1Count++;
			character.arbitrary.magicBarBar1Count++;
			character.arbitrary.poop1Count += 5;
			character.arbitrary.lootCharm2Count++;
			character.adventure.itopod.buffedKills += 1000L;
			break;
		case 13:
			character.addAP(75000);
			break;
		case 14:
			character.arbitrary.energyPotion3Count++;
			break;
		case 15:
			character.arbitrary.magicPotion3Count++;
			break;
		}
	}

	public int getTier5RewardIndex(float rng)
	{
		if (rng < 0.35f)
		{
			return 0;
		}
		if (rng < 0.6f)
		{
			return 1;
		}
		if (rng < 0.7f)
		{
			return 2;
		}
		if (rng < 0.72f)
		{
			return 3;
		}
		if (rng < 0.74f)
		{
			return 4;
		}
		if (rng < 0.75f)
		{
			return 5;
		}
		if (rng < 0.76f)
		{
			return 6;
		}
		if (rng < 0.78f)
		{
			return 7;
		}
		if (rng < 0.8f)
		{
			return 8;
		}
		if (rng < 0.82f)
		{
			return 9;
		}
		if (rng < 0.92f)
		{
			return 10;
		}
		if (rng < 0.97f)
		{
			return 11;
		}
		if (rng < 0.975f)
		{
			return 12;
		}
		if (rng < 0.98f)
		{
			return 13;
		}
		if (rng < 0.985f)
		{
			return 14;
		}
		if (rng < 0.99f)
		{
			return 15;
		}
		return 0;
	}

	public void tier5Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(800);
			break;
		case 1:
			character.addAP(1600);
			break;
		case 2:
			character.addAP(8000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count++;
			break;
		case 4:
			character.arbitrary.magicPotion1Count++;
			break;
		case 5:
			character.arbitrary.energyPotion2Count++;
			break;
		case 6:
			character.arbitrary.magicPotion2Count++;
			break;
		case 7:
			character.arbitrary.lootCharm1Count++;
			break;
		case 8:
			character.arbitrary.energyBarBar1Count++;
			break;
		case 9:
			character.arbitrary.magicBarBar1Count++;
			break;
		case 10:
			character.yggdrasil.seeds += 400L;
			break;
		case 11:
			character.arbitrary.poop1Count += 10;
			break;
		case 12:
			character.arbitrary.energyPotion1Count += 2;
			character.arbitrary.energyPotion2Count += 2;
			character.arbitrary.energyPotion3Count++;
			character.arbitrary.magicPotion1Count += 2;
			character.arbitrary.magicPotion2Count += 2;
			character.arbitrary.magicPotion3Count++;
			character.arbitrary.lootCharm1Count += 2;
			character.arbitrary.energyBarBar1Count += 2;
			character.arbitrary.magicBarBar1Count += 2;
			character.arbitrary.poop1Count += 10;
			character.arbitrary.lootCharm2Count++;
			character.adventure.itopod.buffedKills += 2000L;
			character.arbitrary.beastButterCount++;
			character.arbitrary.macGuffinBooster1Count++;
			break;
		case 13:
			character.addAP(100000);
			break;
		case 14:
			character.arbitrary.energyPotion3Count++;
			break;
		case 15:
			character.arbitrary.magicPotion3Count++;
			break;
		}
	}

	public int getTier6RewardIndex(float rng)
	{
		if (rng < 0.35f)
		{
			return 0;
		}
		if (rng < 0.6f)
		{
			return 1;
		}
		if (rng < 0.7f)
		{
			return 2;
		}
		if (rng < 0.72f)
		{
			return 3;
		}
		if (rng < 0.74f)
		{
			return 4;
		}
		if (rng < 0.75f)
		{
			return 5;
		}
		if (rng < 0.76f)
		{
			return 6;
		}
		if (rng < 0.78f)
		{
			return 7;
		}
		if (rng < 0.8f)
		{
			return 8;
		}
		if (rng < 0.82f)
		{
			return 9;
		}
		if (rng < 0.92f)
		{
			return 10;
		}
		if (rng < 0.97f)
		{
			return 11;
		}
		if (rng < 0.98f)
		{
			return 12;
		}
		if (rng < 0.99f)
		{
			return 13;
		}
		if (rng < 0.995f)
		{
			return 14;
		}
		if (rng < 1f)
		{
			return 15;
		}
		return 0;
	}

	public void tier6Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(1200);
			break;
		case 1:
			character.addAP(2400);
			break;
		case 2:
			character.addAP(12000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count += 2;
			break;
		case 4:
			character.arbitrary.magicPotion1Count += 2;
			break;
		case 5:
			character.arbitrary.energyPotion2Count += 2;
			break;
		case 6:
			character.arbitrary.magicPotion2Count += 2;
			break;
		case 7:
			character.arbitrary.lootCharm1Count += 2;
			break;
		case 8:
			character.arbitrary.energyBarBar1Count += 2;
			break;
		case 9:
			character.arbitrary.magicBarBar1Count += 2;
			break;
		case 10:
			character.yggdrasil.seeds += 2000L;
			break;
		case 11:
			character.arbitrary.poop1Count += 25;
			break;
		case 12:
			character.arbitrary.energyPotion3Count++;
			break;
		case 13:
			character.arbitrary.magicPotion3Count++;
			break;
		case 14:
			character.arbitrary.energyPotion1Count += 2;
			character.arbitrary.energyPotion2Count += 2;
			character.arbitrary.energyPotion3Count += 2;
			character.arbitrary.magicPotion1Count += 2;
			character.arbitrary.magicPotion2Count += 2;
			character.arbitrary.magicPotion3Count += 2;
			character.arbitrary.lootCharm1Count += 3;
			character.arbitrary.energyBarBar1Count += 3;
			character.arbitrary.magicBarBar1Count += 3;
			character.arbitrary.poop1Count += 25;
			character.arbitrary.lootCharm2Count += 2;
			character.arbitrary.beastButterCount += 2;
			character.arbitrary.macGuffinBooster1Count += 2;
			character.adventure.itopod.buffedKills += 3000L;
			break;
		case 15:
			character.addAP(150000);
			break;
		}
	}

	public int getTier7RewardIndex(float rng)
	{
		if (rng < 0.35f)
		{
			return 0;
		}
		if (rng < 0.6f)
		{
			return 1;
		}
		if (rng < 0.7f)
		{
			return 2;
		}
		if (rng < 0.72f)
		{
			return 3;
		}
		if (rng < 0.74f)
		{
			return 4;
		}
		if (rng < 0.75f)
		{
			return 5;
		}
		if (rng < 0.76f)
		{
			return 6;
		}
		if (rng < 0.78f)
		{
			return 7;
		}
		if (rng < 0.8f)
		{
			return 8;
		}
		if (rng < 0.82f)
		{
			return 9;
		}
		if (rng < 0.92f)
		{
			return 10;
		}
		if (rng < 0.97f)
		{
			return 11;
		}
		if (rng < 0.98f)
		{
			return 12;
		}
		if (rng < 0.99f)
		{
			return 13;
		}
		if (rng < 0.995f)
		{
			return 14;
		}
		if (rng < 1f)
		{
			return 15;
		}
		return 0;
	}

	public void tier7Reward(int rewardID)
	{
		switch (rewardID)
		{
		case 0:
			character.addAP(1500);
			break;
		case 1:
			character.addAP(3000);
			break;
		case 2:
			character.addAP(15000);
			break;
		case 3:
			character.arbitrary.energyPotion1Count += 2;
			break;
		case 4:
			character.arbitrary.magicPotion1Count += 2;
			break;
		case 5:
			character.arbitrary.energyPotion2Count += 2;
			break;
		case 6:
			character.arbitrary.magicPotion2Count += 2;
			break;
		case 7:
			character.arbitrary.lootCharm1Count += 2;
			break;
		case 8:
			character.arbitrary.energyBarBar1Count += 2;
			break;
		case 9:
			character.arbitrary.magicBarBar1Count += 2;
			break;
		case 10:
			character.yggdrasil.seeds += 5000L;
			break;
		case 11:
			character.arbitrary.poop1Count += 25;
			break;
		case 12:
			character.arbitrary.energyPotion3Count++;
			break;
		case 13:
			character.arbitrary.magicPotion3Count++;
			break;
		case 14:
			character.arbitrary.energyPotion1Count += 3;
			character.arbitrary.energyPotion2Count += 3;
			character.arbitrary.energyPotion3Count += 3;
			character.arbitrary.magicPotion1Count += 3;
			character.arbitrary.magicPotion2Count += 3;
			character.arbitrary.magicPotion3Count += 3;
			character.arbitrary.lootCharm1Count += 3;
			character.arbitrary.energyBarBar1Count += 3;
			character.arbitrary.magicBarBar1Count += 3;
			character.arbitrary.poop1Count += 25;
			character.arbitrary.lootCharm2Count += 3;
			character.adventure.itopod.buffedKills += 5000L;
			character.arbitrary.beastButterCount += 3;
			character.arbitrary.macGuffinBooster1Count += 3;
			break;
		case 15:
			character.addAP(175000);
			break;
		}
	}

	private void Update()
	{
		if (character.daily.spinTime.totalseconds < (double)maxSpinTime())
		{
			character.daily.spinTime.advanceTime(Time.deltaTime);
		}
		if (inSpinLoop)
		{
			updateSpinLoop();
		}
	}

	public int currentTier()
	{
		if (character.daily.totalSpins < 7)
		{
			return 0;
		}
		if (character.daily.totalSpins < 14)
		{
			return 1;
		}
		if (character.daily.totalSpins < 30)
		{
			return 2;
		}
		if (character.daily.totalSpins < 60)
		{
			return 3;
		}
		if (character.daily.totalSpins < 120)
		{
			return 4;
		}
		if (character.daily.totalSpins < 180)
		{
			return 5;
		}
		if (character.daily.totalSpins < 365)
		{
			return 6;
		}
		if (character.daily.totalSpins >= 365)
		{
			return 7;
		}
		return 6;
	}

	public void updateSpinLoop()
	{
		spinnerTimer.advanceTime(Time.deltaTime);
		if (spinnerTimer.totalseconds >= 5.0)
		{
			inSpinLoop = false;
			spinCounter = 0;
			spinnerTimer.reset();
			Random.state = character.daily.dailyRewardState;
			float value = Random.value;
			character.daily.dailyRewardState = Random.state;
			int rewardID = getRewardID(value);
			switch (currentTier())
			{
			case 0:
				tier0Reward(rewardID);
				break;
			case 1:
				tier1Reward(rewardID);
				break;
			case 2:
				tier2Reward(rewardID);
				break;
			case 3:
				tier3Reward(rewardID);
				break;
			case 4:
				tier4Reward(rewardID);
				break;
			case 5:
				tier5Reward(rewardID);
				break;
			case 6:
				tier6Reward(rewardID);
				break;
			case 7:
				tier7Reward(rewardID);
				break;
			}
			outcomeText.text = rewardNames[currentTier()][rewardID];
			rarityBackground.color = rarityColor(rewardRarity[currentTier()][rewardID]);
			character.daily.totalSpins++;
			outcomeBorder.gameObject.SetActive(value: true);
			Invoke("updateList", 5f);
		}
		else if (newSpinOutcome())
		{
			while (newOffset == oldOffset)
			{
				newOffset = getRewardID(Random.value);
			}
			oldOffset = newOffset;
			outcomeText.text = rewardNames[currentTier()][newOffset];
			rarityBackground.color = rarityColor(rewardRarity[currentTier()][newOffset]);
		}
	}

	public int getRewardID(float rng)
	{
		switch (currentTier())
		{
		case 0:
			return getTier0RewardIndex(rng);
		case 1:
			return getTier1RewardIndex(rng);
		case 2:
			return getTier2RewardIndex(rng);
		case 3:
			return getTier3RewardIndex(rng);
		case 4:
			return getTier4RewardIndex(rng);
		case 5:
			return getTier5RewardIndex(rng);
		case 6:
			return getTier6RewardIndex(rng);
		case 7:
			return getTier7RewardIndex(rng);
		default:
			return 0;
		}
	}

	public Color rarityColor(int id)
	{
		switch (id)
		{
		case 0:
			return Color.white;
		case 1:
			return new Color(0.6f, 0.851f, 0.917f);
		case 2:
			return new Color(1f, 0.682f, 0.788f);
		case 3:
			return new Color(0.784f, 0.749f, 0.906f);
		case 4:
			return new Color(1f, 0.827f, 0.235f);
		default:
			return Color.white;
		}
	}

	public int curTierRewardLength()
	{
		return rewardNames[currentTier()].Count;
	}

	public bool newSpinOutcome()
	{
		spinCounter++;
		if (spinCounter < 60)
		{
			if (spinCounter % 3 == 0)
			{
				return true;
			}
		}
		else if (spinCounter < 90)
		{
			if (spinCounter % 6 == 0)
			{
				return true;
			}
		}
		else if (spinCounter < 120)
		{
			if (spinCounter % 10 == 0)
			{
				return true;
			}
		}
		else if (spinCounter < 180)
		{
			if (spinCounter % 18 == 0)
			{
				return true;
			}
		}
		else if (spinCounter < 240 && spinCounter % 30 == 0)
		{
			return true;
		}
		return false;
	}

	public void startSpin()
	{
		if (canSpin() && !inSpinLoop)
		{
			if (character.daily.freeSpins > 0)
			{
				character.daily.freeSpins--;
			}
			else
			{
				character.daily.spinTime.setTime(character.daily.spinTime.totalseconds - 86400.0);
			}
			inSpinLoop = true;
			outcomeBorder.gameObject.SetActive(value: false);
			oldOffset = getRewardID(Random.value);
		}
		else if (canSpin() && inSpinLoop)
		{
			tooltip.showOverrideTooltip("You're ALREADY SPINNING, dumbass. Let it finish.", 2f);
		}
		else
		{
			tooltip.showOverrideTooltip("Yo, check the timer. Your daily spin isn't available yet!", 2f);
		}
	}

	public void startNoBullshitSpin()
	{
		if (canSpin() && !inSpinLoop)
		{
			if (character.daily.freeSpins > 0)
			{
				character.daily.freeSpins--;
			}
			else
			{
				character.daily.spinTime.setTime(character.daily.spinTime.totalseconds - 86400.0);
			}
			outcomeBorder.gameObject.SetActive(value: false);
			Random.state = character.daily.dailyRewardState;
			float value = Random.value;
			character.daily.dailyRewardState = Random.state;
			int rewardID = getRewardID(value);
			switch (currentTier())
			{
			case 0:
				tier0Reward(rewardID);
				break;
			case 1:
				tier1Reward(rewardID);
				break;
			case 2:
				tier2Reward(rewardID);
				break;
			case 3:
				tier3Reward(rewardID);
				break;
			case 4:
				tier4Reward(rewardID);
				break;
			case 5:
				tier5Reward(rewardID);
				break;
			case 6:
				tier6Reward(rewardID);
				break;
			case 7:
				tier7Reward(rewardID);
				break;
			}
			outcomeText.text = rewardNames[currentTier()][rewardID];
			rarityBackground.color = rarityColor(rewardRarity[currentTier()][rewardID]);
			outcomeBorder.gameObject.SetActive(value: true);
			character.daily.totalSpins++;
			Invoke("updateList", 5f);
		}
		else if (canSpin() && inSpinLoop)
		{
			tooltip.showOverrideTooltip("You're ALREADY SPINNING, Omega Idiot. Let it finish first!", 2f);
		}
		else
		{
			tooltip.showOverrideTooltip("Yo, check the timer. Your daily spin isn't available yet!", 2f);
		}
	}

	public bool canSpin()
	{
		if (!(character.daily.spinTime.totalseconds >= (double)targetSpinTime()))
		{
			return character.daily.freeSpins > 0;
		}
		return true;
	}

	public void refreshMenu()
	{
		rewardDisplay.updateList();
		rewardOutcomeTitle.text = "Tier " + currentTier() + " Daily Spin Reward Table";
	}

	public void updateList()
	{
		rewardDisplay.updateList();
	}

	public void showTimerTooltip()
	{
		InvokeRepeating("showTimeToNextSpin", 0f, 0.1f);
	}

	public void showTimeToNextSpin()
	{
		string text = "";
		text = ((!(character.daily.spinTime.totalseconds < 86400.0)) ? ("Go ahead and spin!\n\nYou have <b>" + NumberOutput.timeOutput(character.daily.spinTime.totalseconds - (double)targetSpinTime()) + "</b> of extra time banked for your next spin.") : ("<b>Time Until Next Spin:</b> " + NumberOutput.timeOutput((double)targetSpinTime() - character.daily.spinTime.totalseconds)));
		if (character.daily.freeSpins > 0)
		{
			text = text + "\n\nYou have <b>" + character.daily.freeSpins + "</b> FREE spins available!";
		}
		tooltip.showTooltip(text);
	}

	public void exitTooltip()
	{
		CancelInvoke("showTimeToNextSpin");
		tooltip.hideTooltip();
	}

	public void showTierTooltipInfo()
	{
		if (currentTier() >= 7)
		{
			tooltip.showTooltip("You have reached the max Daily Spin tier! Thanks for a year (or more) of playing NGU IDLE!");
			return;
		}
		tooltip.showTooltip("<b>Your total spin count is " + character.daily.totalSpins + ".\n\nYou will advance to the next tier of rewards in " + spinsToNextTier() + " spins!</b>");
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public long spinsToNextTier()
	{
		long totalSpins = character.daily.totalSpins;
		if (totalSpins < 7)
		{
			return 7 - totalSpins;
		}
		if (totalSpins < 14)
		{
			return 14 - totalSpins;
		}
		if (totalSpins < 30)
		{
			return 30 - totalSpins;
		}
		if (totalSpins < 60)
		{
			return 60 - totalSpins;
		}
		if (totalSpins < 120)
		{
			return 120 - totalSpins;
		}
		if (totalSpins < 180)
		{
			return 180 - totalSpins;
		}
		if (totalSpins < 365)
		{
			return 365 - totalSpins;
		}
		return 0L;
	}

	public void updateTimeText()
	{
		if (character.daily.spinTime.totalseconds >= (double)targetSpinTime())
		{
			timeText.text = "READY!";
		}
		else
		{
			timeText.text = "Time To Next Spin:\n" + NumberOutput.timeOutput((double)targetSpinTime() - character.daily.spinTime.totalseconds);
		}
	}
}
