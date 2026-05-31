using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApPackDisplay : MonoBehaviour
{
	public Character character;

	public Text ap20K;

	public Text ap100K;

	public Text ap200K;

	public Text ap400K;

	public Text ap1M;

	public Text ap2M;

	public Text npp;

	public Text itopodNamePack;

	public Text itopodNameCost;

	public Text comingSoonText;

	public Text nppCost;

	public Text nppTitle;

	public List<Image> kredsImages;

	public List<Image> kredsButtonIcons;

	public Sprite kred;

	public Sprite cash;

	public Sprite darkAscended;

	public Sprite normalAscended;

	public Sprite darkAscended2;

	public Sprite normalAscended2;

	public Sprite darkAscended3;

	public Sprite normalAscended3;

	public Sprite darkAscended4;

	public Sprite normalAscended4;

	public Sprite darkNewbie;

	public Sprite normalNewbie;

	public GameObject SNP;

	public GameObject ItopodNamePod;

	public GameObject Resource3Pod;

	public Text res3Pack;

	public Text res3Cost;

	public GameObject fashionPod;

	public Text fashionPack;

	public Text fashionCost;

	public GameObject verify1;

	public GameObject verify2;

	public GameObject policy1;

	public GameObject policy2;

	public void Start()
	{
		refreshMenu();
	}

	public void updateImagesKong()
	{
		verify1.SetActive(value: true);
		verify2.SetActive(value: true);
		policy1.SetActive(value: false);
		policy2.SetActive(value: false);
		for (int i = 0; i < kredsImages.Count; i++)
		{
			kredsImages[i].gameObject.SetActive(value: true);
		}
	}

	public void updateImagesNotKong()
	{
		verify1.SetActive(value: true);
		verify2.SetActive(value: true);
		policy1.SetActive(value: false);
		policy2.SetActive(value: false);
		for (int i = 0; i < kredsImages.Count; i++)
		{
			kredsImages[i].gameObject.SetActive(value: false);
		}
	}

	public void updateImagesKartridge()
	{
		verify1.SetActive(value: false);
		verify2.SetActive(value: false);
		policy1.SetActive(value: false);
		policy2.SetActive(value: false);
		for (int i = 0; i < kredsImages.Count; i++)
		{
			kredsImages[i].gameObject.SetActive(value: false);
		}
	}

	public void updateImagesSteam()
	{
		verify1.SetActive(value: false);
		verify2.SetActive(value: false);
		policy1.SetActive(value: true);
		policy2.SetActive(value: true);
		for (int i = 0; i < kredsImages.Count; i++)
		{
			kredsImages[i].gameObject.SetActive(value: false);
		}
	}

	public void updateTextKong()
	{
		ap20K.text = character.checkAPAdded(20000L).ToString("###,##0") + " Arbitrary Points!\n\n:)\nCost: 10";
		ap100K.text = character.checkAPAdded(100000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(10000L).ToString("###,##0") + " Bonus AP!\nC:\nCost: 50";
		ap200K.text = character.checkAPAdded(200000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(25000L).ToString("###,##0") + " Bonus AP!\n:O\nCost: 100";
		ap400K.text = character.checkAPAdded(400000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(60000L).ToString("###,##0") + " Bonus AP!\n:D\nCost: 200";
		ap1M.text = character.checkAPAdded(1000000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(200000L).ToString("###,##0") + " Bonus AP!\n<3\nCost: 400";
		ap2M.text = character.checkAPAdded(2500000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(700000L).ToString("###,##0") + " Bonus AP!\n<3<3<3\nCost: 1000";
		if (character.arbitrary.nameSlotsBought == 0)
		{
			itopodNamePack.text = "Have your name (or contact 4G for a custom name) appear as an enemy in the ITOPOD for everyone to see!\nBonus: 1st purchase grants you " + character.checkAPAdded(1200000L).ToString("###,##0") + " AP!";
		}
		else
		{
			itopodNamePack.text = "Have your name (or contact 4G for a custom name) appear as an enemy in the ITOPOD for everyone to see! This can be purchased multiple times for extra name slots!";
		}
		itopodNameCost.text = "Cost: 565";
		comingSoonText.text = "";
		if (character.arbitrary.boughtRes3Pack || !character.res3.res3On)
		{
			Resource3Pod.SetActive(value: false);
		}
		else
		{
			Resource3Pod.SetActive(value: true);
			res3Pack.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nThe Grey Heart!\n+4 of all Resource 3 Consumables!\nResource 3 Colour Picker!\nA PERSONALIZED NUMBER!";
			res3Cost.text = "Cost: 225";
		}
		if (character.arbitrary.boughtFashionPack1)
		{
			fashionPod.SetActive(value: false);
		}
		else
		{
			fashionPod.SetActive(value: true);
			fashionPack.text = "Unlock TEN special player portraits, handcrafted by the mighty Musluk! Plus I'll throw in like " + character.checkAPAdded(200000L).ToString("###,##0") + "AP ;)";
			fashionCost.text = "Cost: 110";
		}
		if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2 && character.arbitrary.boughtAscendedNewbiePack3 && character.arbitrary.boughtAscendedNewbiePack4)
		{
			SNP.SetActive(value: false);
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2 && character.arbitrary.boughtAscendedNewbiePack3)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: 225";
			nppTitle.text = "ASCENDED^4 NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(300000L).ToString("###,##0") + " Arbitrary Points!\nThe Rainbow Heart!\nA Huge Consumables dump!\nPermanent Foil Cards!\nA PERSONALIZED WEIRD THING!";
			npp.color = Color.black;
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended4;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended4;
			}
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: 225";
			nppTitle.text = "ASCENDED^3 NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(500000L).ToString("###,##0") + " Arbitrary Points!\nThe Blue Heart!\nA Huge Consumables dump!\nFaster Wishes!\nA PERSONALIZED KITTY PIC\n OR VIDEO :D";
			npp.color = Color.black;
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended3;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended3;
			}
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: 225";
			nppTitle.text = "ASCENDED ASCENDED PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(700000L).ToString("###,##0") + " Arbitrary Points!\nFaster Questing!\nThe Orange Heart!\n4 of Every Consumable!\nUNLOCK THE GOLDEN KITTY!\nA PERSONALIZED PUN!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended2;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended2;
			}
		}
		else if (character.arbitrary.boughtNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: 225";
			nppTitle.text = "ASCENDED NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nLazy Itopod Shifter!\nThe Red Heart!\n4 of Every Consumable!\nUNLOCK TWO SEXY GOLDEN THEMES!\nA PERSONALIZED COMPLIMENT :O";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended;
			}
		}
		else
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: 100";
			nppTitle.text = "THE STUPID NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\n2 of Every Consumable!\n25 Poop! (See? Crap!)\nA PERSONALIZED INSULT!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkNewbie;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalNewbie;
			}
		}
	}

	public void updateTextNotKong()
	{
		npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\n2 of Every Consumable!\n25 Poop!(See ? Crap!)\nA PERSONALIZED INSULT!";
		ap20K.text = character.checkAPAdded(20000L).ToString("###,##0") + " Arbitrary Points!\n\n:)\nCost: $1.00";
		ap100K.text = character.checkAPAdded(100000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(10000L).ToString("###,##0") + " Bonus AP!\nC:\nCost: $5.00";
		ap200K.text = character.checkAPAdded(200000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(25000L).ToString("###,##0") + " Bonus AP!\n:O\nCost: $10.00";
		ap400K.text = character.checkAPAdded(400000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(60000L).ToString("###,##0") + " Bonus AP!\n:D\nCost: $20.00";
		ap1M.text = character.checkAPAdded(1000000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(200000L).ToString("###,##0") + " Bonus AP!\n<3\nCost: $40.00";
		ap2M.text = character.checkAPAdded(2500000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(700000L).ToString("###,##0") + " Bonus AP!\n<3<3<3\nCost: $100.00";
		ItopodNamePod.SetActive(value: false);
		comingSoonText.text = "Coming Soon :)";
		Resource3Pod.SetActive(value: false);
		fashionPod.SetActive(value: false);
		if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack)
		{
			SNP.SetActive(value: false);
		}
		else if (character.arbitrary.boughtNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22";
			nppTitle.text = "ASCENDED NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nLazy Itopod Shifter!\nThe Red Heart!\n4 of Every Consumable!\nUNLOCK TWO SEXY GOLDEN THEMES!\nA PERSONALIZED COMPLIMENT :O";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended;
			}
		}
		else
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $10.00";
			nppTitle.text = "THE STUPID NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\n2 of Every Consumable!\n25 Poop! (See? Crap!)\nA PERSONALIZED INSULT!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkNewbie;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalNewbie;
			}
		}
	}

	public void updateTextKartridge()
	{
		npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\n2 of Every Consumable!\n25 Poop!(See ? Crap!)\nA PERSONALIZED INSULT!";
		ap20K.text = character.checkAPAdded(20000L).ToString("###,##0") + " Arbitrary Points!\n\n:)\nCost: $1.00";
		ap100K.text = character.checkAPAdded(100000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(10000L).ToString("###,##0") + " Bonus AP!\nC:\nCost: $5.00";
		ap200K.text = character.checkAPAdded(200000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(25000L).ToString("###,##0") + " Bonus AP!\n:O\nCost: $10.00";
		ap400K.text = character.checkAPAdded(400000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(60000L).ToString("###,##0") + " Bonus AP!\n:D\nCost: $20.00";
		ap1M.text = character.checkAPAdded(1000000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(200000L).ToString("###,##0") + " Bonus AP!\n<3\nCost: $40.00";
		ap2M.text = character.checkAPAdded(2500000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(700000L).ToString("###,##0") + " Bonus AP!\n<3<3<3\nCost: $100.00";
		ItopodNamePod.SetActive(value: false);
		comingSoonText.text = "";
		if (character.arbitrary.boughtRes3Pack || !character.res3.res3On)
		{
			Resource3Pod.SetActive(value: false);
		}
		else
		{
			Resource3Pod.SetActive(value: true);
			res3Pack.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nThe Grey Heart!\n4 of Every Resource 3 Consumable!\nResource 3 Colour Picker!\nA PERSONALIZED NUMBER!";
			res3Cost.text = "Cost: $22.22";
		}
		if (character.arbitrary.boughtFashionPack1)
		{
			fashionPod.SetActive(value: false);
		}
		else
		{
			fashionPod.SetActive(value: true);
			fashionPack.text = "Unlock TEN special player portraits, handcrafted by the mighty Musluk! PLUS I'll throw in like " + character.checkAPAdded(200000L).ToString("###,##0") + "AP! ;)";
			fashionCost.text = "Cost: $11.11";
		}
		if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2 && character.arbitrary.boughtAscendedNewbiePack3 && character.arbitrary.boughtAscendedNewbiePack4)
		{
			SNP.SetActive(value: false);
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2 && character.arbitrary.boughtAscendedNewbiePack3)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22";
			nppTitle.text = "ASCENDED^4 NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(300000L).ToString("###,##0") + " Arbitrary Points!\nThe Rainbow Heart!\nA Huge Consumables dump!\nPermanent Foil Cards!\nA PERSONALIZED WEIRD THING!";
			npp.color = Color.black;
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended4;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended4;
			}
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22";
			nppTitle.text = "ASCENDED^3 PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(500000L).ToString("###,##0") + " Arbitrary Points!\nThe Blue Heart!\nA Huge Consumables dump!\nFaster Wishes!\nA PERSONALIZED KITTY PIC\n OR VIDEO :D";
			npp.color = Color.black;
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended3;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended3;
			}
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22";
			nppTitle.text = "ASCENDED ASCENDED PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(700000L).ToString("###,##0") + " Arbitrary Points!\nFaster Questing!\nThe Orange Heart!\n4 of Every Consumable!\nUNLOCK THE GOLDEN KITTY!\nA PERSONALIZED PUN!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended2;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended2;
			}
		}
		else if (character.arbitrary.boughtNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22";
			nppTitle.text = "ASCENDED NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nLazy Itopod Shifter!\nThe Red Heart!\n4 of Every Consumable!\nUNLOCK TWO SEXY GOLDEN THEMES!\nA PERSONALIZED COMPLIMENT :O";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended;
			}
		}
		else
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $10.00";
			nppTitle.text = "THE STUPID NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\n2 of Every Consumable!\n25 Poop! (See? Crap!)\nA PERSONALIZED INSULT!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkNewbie;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalNewbie;
			}
		}
	}

	public void updateTextSteam()
	{
		npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\nA Consumables dump!\n25 Poop!(See ? Crap!)\nA PERSONALIZED INSULT!";
		ap20K.text = character.checkAPAdded(20000L).ToString("###,##0") + " Arbitrary Points! :)\n\n\nCost: $1.00 USD";
		ap100K.text = character.checkAPAdded(100000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(10000L).ToString("###,##0") + " Bonus AP! C:\n\nCost: $5.00 USD";
		ap200K.text = character.checkAPAdded(200000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(25000L).ToString("###,##0") + " Bonus AP! :O\n\nCost: $10.00 USD";
		ap400K.text = character.checkAPAdded(400000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(60000L).ToString("###,##0") + " Bonus AP! :D\n\nCost: $20.00 USD";
		ap1M.text = character.checkAPAdded(1000000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(200000L).ToString("###,##0") + " Bonus AP! <3\n\nCost: $40.00 USD";
		ap2M.text = character.checkAPAdded(2500000L).ToString("###,##0") + " Arbitrary Points!\n+" + character.checkAPAdded(700000L).ToString("###,##0") + " Bonus AP! <3<3<3\n\nCost: $100.00 USD";
		if (character.arbitrary.nameSlotsBought == 0)
		{
			itopodNamePack.text = "Have your name (or contact 4G for a custom name) appear as an enemy in the ITOPOD for everyone to see!\nBonus: 1st purchase grants you " + character.checkAPAdded(1200000L).ToString("###,##0") + " AP!";
		}
		else
		{
			itopodNamePack.text = "Have your name (or contact 4G for a custom name) appear as an enemy in the ITOPOD for everyone to see! This can be purchased multiple times for extra name slots!";
		}
		itopodNameCost.text = "Cost: $60.00 USD";
		comingSoonText.text = "";
		if (character.arbitrary.boughtRes3Pack || !character.res3.res3On)
		{
			Resource3Pod.SetActive(value: false);
		}
		else
		{
			Resource3Pod.SetActive(value: true);
			res3Pack.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nThe Grey Heart!\n4 of Every Resource 3 Consumable!\nResource 3 Colour Picker!\nA PERSONALIZED NUMBER!";
			res3Cost.text = "Cost: $22.22 USD";
		}
		if (character.arbitrary.boughtFashionPack1)
		{
			fashionPod.SetActive(value: false);
		}
		else
		{
			fashionPod.SetActive(value: true);
			fashionPack.text = "Unlock TEN special player portraits, handcrafted by the mighty Musluk! PLUS I'll throw in like " + character.checkAPAdded(200000L).ToString("###,##0") + "AP! ;)";
			fashionCost.text = "Cost: $11.11 USD";
		}
		if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2 && character.arbitrary.boughtAscendedNewbiePack3 && character.arbitrary.boughtAscendedNewbiePack4)
		{
			SNP.SetActive(value: false);
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2 && character.arbitrary.boughtAscendedNewbiePack3)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22 USD";
			nppTitle.text = "ASCENDED^4 NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(300000L).ToString("###,##0") + " Arbitrary Points!\nThe Rainbow Heart!\nA Huge Consumables dump!\nPermanent Foil Cards!\nA PERSONALIZED WEIRD THING!";
			npp.color = Color.black;
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended4;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended4;
			}
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22 USD";
			nppTitle.text = "ASCENDED^3 PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(500000L).ToString("###,##0") + " Arbitrary Points!\nThe Blue Heart!\nA Huge Consumables Dump!\nFaster Wishes!\nA PERSONALIZED KITTY PIC\n OR VIDEO :D";
			npp.color = Color.black;
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended3;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended3;
			}
		}
		else if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22 USD";
			nppTitle.text = "ASCENDED ASCENDED PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(700000L).ToString("###,##0") + " Arbitrary Points!\nFaster Questing!\nThe Orange Heart!\nA Big Consumables Dump!\nUNLOCK THE GOLDEN KITTY!\nA PERSONALIZED PUN!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended2;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended2;
			}
		}
		else if (character.arbitrary.boughtNewbiePack)
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $22.22 USD";
			nppTitle.text = "ASCENDED NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(600000L).ToString("###,##0") + " Arbitrary Points!\nLazy Itopod Shifter!\nThe Red Heart!\nA Big Consumables Dump!\nUNLOCK TWO SEXY GOLDEN THEMES!\nA PERSONALIZED COMPLIMENT :O";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkAscended;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalAscended;
			}
		}
		else
		{
			SNP.SetActive(value: true);
			nppCost.text = "Cost: $10.00 USD";
			nppTitle.text = "THE STUPID NEWBIE PACK\n<= YOU GET ALL THIS CRAP!";
			npp.text = character.checkAPAdded(225000L).ToString("###,##0") + " Arbitrary Points!\nImproved Loot Filter!\n12 Inventory Spaces!\nA Consumables Dump!\n25 Poop! (See? Crap!)\nA PERSONALIZED INSULT!";
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				SNP.GetComponent<Image>().sprite = darkNewbie;
			}
			else
			{
				SNP.GetComponent<Image>().sprite = normalNewbie;
			}
		}
	}

	public void updateButtonsKong()
	{
		for (int i = 0; i < kredsButtonIcons.Count; i++)
		{
			kredsButtonIcons[i].sprite = kred;
		}
	}

	public void updateButtonsNotKong()
	{
		for (int i = 0; i < kredsButtonIcons.Count; i++)
		{
			kredsButtonIcons[i].sprite = cash;
		}
	}

	public void refreshMenu()
	{
		if (character.platform == platform.Steam)
		{
			updateTextSteam();
			updateImagesSteam();
			updateButtonsNotKong();
		}
		if (character.platform == platform.Kong)
		{
			updateTextKong();
			updateImagesKong();
			updateButtonsKong();
		}
		else if (character.platform == platform.AG)
		{
			updateTextNotKong();
			updateImagesNotKong();
			updateButtonsNotKong();
		}
		else if (character.platform == platform.Kartridge)
		{
			updateTextKartridge();
			updateImagesKartridge();
			updateButtonsNotKong();
		}
	}

	public void showNewbieTooltip()
	{
		if (!character.arbitrary.boughtNewbiePack)
		{
			character.tooltip.showOverrideTooltip("NOTE: If you already bought the Improved Loot Filter or Inventory Spaces, you'll get additional AP equal to their value when you buy this pack!");
		}
		else if (!character.arbitrary.boughtAscendedNewbiePack)
		{
			character.tooltip.showOverrideTooltip("NOTE: If you have the Red Heart filtered or maxed out, or you already bought the Lazy ITOPOD Shifter, you'll get additional AP equal to their value when you buy this pack!");
		}
	}

	public void hideNewbieTooltip()
	{
		character.tooltip.hideTooltip();
	}

	public void showOverlayReminderTooltip()
	{
		if (character.platform == platform.Steam)
		{
			character.tooltip.showTooltip("PROTIP: You'll need the Steam Overlay ENABLED in order for purchases from Steam to pop up!");
		}
	}

	public void hideTooltip()
	{
		if (character.platform == platform.Steam)
		{
			character.tooltip.hideTooltip();
		}
	}
}
