using System;

[Serializable]
public class Arbitrary
{
	public int arbitraryPoints;

	public int lifetimePoints;

	public long curArbitraryPoints;

	public long curLifetimePoints;

	public int energyPotion1Count;

	public PlayerTime energyPotion1Time;

	public int energyPotion2Count;

	public bool energyPotion2InUse;

	public int magicPotion1Count;

	public PlayerTime magicPotion1Time;

	public int magicPotion2Count;

	public bool magicPotion2InUse;

	public int lootCharm1Count;

	public PlayerTime lootcharm1Time;

	public int energyBarBar1Count;

	public PlayerTime energyBarBar1Time;

	public int magicBarBar1Count;

	public PlayerTime magicBarBar1Time;

	public int macGuffinBooster1Count;

	public PlayerTime macGuffinBooster1Time = new PlayerTime();

	public bool macGuffinBooster1InUse;

	public PlayerTime nukeTimer = new PlayerTime();

	public bool boughtAutoNuke;

	public bool lootFilter;

	public bool improvedAutoBoostMerge;

	public bool instaTrain;

	public int inventorySpaces;

	public bool hasStarterPack;

	public bool hasAcc4;

	public bool hasAcc5;

	public bool hasAcc6;

	public bool hasAcc7;

	public bool hasAcc8;

	public bool hasAcc9;

	public bool hasYggdrasilReminder;

	public bool hasExtendedSpinBank;

	public int curLoadoutSlots;

	public int poop1Count;

	public int energyPotion3Count;

	public int magicPotion3Count;

	public int beardSlots;

	public bool hasCubeFilter;

	public int lootCharm2Count;

	public bool hasDaycareSpeed;

	public bool boughtNewbiePack;

	public bool boughtAscendedNewbiePack;

	public bool boughtAscendedNewbiePack2;

	public bool boughtAscendedNewbiePack3;

	public bool boughtAscendedNewbiePack4;

	public bool boughtFashionPack1;

	public bool boughtLazyITOPOD;

	public bool lazyITOPODOn = true;

	public bool boughtRes3Pack;

	public int diggerSlots;

	public int macguffinSlots;

	public int nameSlotsBought;

	public int beastButterCount;

	public bool hasQuestLight;

	public bool hasFasterQuests;

	public bool hasExtendedQuestBank;

	public bool boughtDaycareArt;

	public bool hasNGUCapModifier;

	public int res3Potion1Count;

	public PlayerTime res3Potion1Time;

	public int res3Potion2Count;

	public bool res3Potion2InUse;

	public int res3Potion3Count;

	public bool res3NameGeneratorBought;

	public bool wishSpeedBoster;

	public int wishSlotsBought;

	public bool boughtFoils;

	public bool gotTagslot1;

	public int mayoGenSlots;

	public int deckSpaceBought;

	public int mayoSpeedPotCount;

	public PlayerTime mayoSpeedPotTime;

	public int cardTierUpperCount;

	public int invMergeSlots;

	public bool advLightBought;

	public bool advAdvancerBought;

	public int advAdvancerZone;

	public bool goToQuestZoneBought;

	public Arbitrary()
	{
		arbitraryPoints = 0;
		lifetimePoints = 0;
		energyPotion1Count = 0;
		energyPotion1Time = new PlayerTime();
		energyPotion2Count = 0;
		energyPotion2InUse = false;
		magicPotion1Count = 0;
		magicPotion1Time = new PlayerTime();
		magicPotion2Count = 0;
		magicPotion2InUse = false;
		lootCharm1Count = 0;
		lootcharm1Time = new PlayerTime();
		energyBarBar1Count = 0;
		energyBarBar1Time = new PlayerTime();
		magicBarBar1Count = 0;
		magicBarBar1Time = new PlayerTime();
		macGuffinBooster1Count = 0;
		macGuffinBooster1Time = new PlayerTime();
		macGuffinBooster1InUse = false;
		lootFilter = false;
		improvedAutoBoostMerge = false;
		instaTrain = false;
		inventorySpaces = 0;
		hasStarterPack = false;
		hasAcc4 = false;
		hasAcc5 = false;
		hasAcc6 = false;
		hasAcc7 = false;
		hasAcc8 = false;
		hasAcc9 = false;
		poop1Count = 0;
		hasYggdrasilReminder = false;
		hasExtendedSpinBank = false;
		curLoadoutSlots = 0;
		energyPotion3Count = 0;
		magicPotion3Count = 0;
		beardSlots = 0;
		hasCubeFilter = false;
		lootCharm2Count = 0;
		hasDaycareSpeed = false;
		boughtNewbiePack = false;
		boughtAscendedNewbiePack = false;
		boughtAscendedNewbiePack2 = false;
		boughtAscendedNewbiePack3 = false;
		boughtAscendedNewbiePack4 = false;
		boughtFashionPack1 = false;
		boughtLazyITOPOD = false;
		lazyITOPODOn = false;
		diggerSlots = 0;
		macguffinSlots = 0;
		nameSlotsBought = 0;
		beastButterCount = 0;
		hasQuestLight = false;
		hasFasterQuests = false;
		hasExtendedQuestBank = false;
		boughtDaycareArt = false;
		hasNGUCapModifier = false;
		res3Potion1Count = 0;
		res3Potion1Time = new PlayerTime();
		res3Potion2Count = 0;
		res3Potion2InUse = false;
		res3Potion3Count = 0;
		res3NameGeneratorBought = false;
		wishSpeedBoster = false;
		wishSlotsBought = 0;
		boughtFoils = false;
		gotTagslot1 = false;
		mayoGenSlots = 0;
		mayoSpeedPotCount = 0;
		mayoSpeedPotTime = new PlayerTime();
		cardTierUpperCount = 0;
		deckSpaceBought = 0;
		invMergeSlots = 0;
		advLightBought = false;
		advAdvancerBought = false;
		advAdvancerZone = 0;
		goToQuestZoneBought = false;
	}
}
