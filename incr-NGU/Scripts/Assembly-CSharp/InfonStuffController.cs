using UnityEngine;
using UnityEngine.UI;

public class InfonStuffController : MonoBehaviour
{
	public Character character;

	public Text infoText;

	public Button specialPrizeButton;

	public Button kartPromoButton;

	public Button kongBadgeButton;

	public Button steamDatabutton;

	public Text kartPromoText;

	public void updateMenu()
	{
		if (character.menuID == 26)
		{
			if (!character.purchases.hasSpecialPrize1)
			{
				specialPrizeButton.image.color = new Color(0.984f, 0.835f, 0.443f);
			}
			else
			{
				specialPrizeButton.image.color = Color.white;
			}
			if (character.platform != platform.Kartridge && character.platform != platform.Steam)
			{
				kartPromoButton.gameObject.SetActive(value: false);
			}
			else if (character.platform == platform.Steam)
			{
				kartPromoButton.gameObject.SetActive(value: true);
				kartPromoText.text = "Thanks for trying out NGU Idle on Steam! Click this button for some free stuff!";
			}
			else if (!character.settings.claimedKartPromo)
			{
				kartPromoButton.image.color = new Color(0.984f, 0.835f, 0.443f);
			}
			else
			{
				kartPromoButton.image.color = Color.white;
			}
			if (!character.settings.badge2Part4Complete && character.settings.badge2Started)
			{
				updateBadgeProgressText();
			}
			if (character.platform != platform.Kong && character.platform != platform.Kartridge)
			{
				kongBadgeButton.gameObject.SetActive(value: false);
			}
			else
			{
				kongBadgeButton.gameObject.SetActive(value: true);
			}
			if (character.platform != platform.Steam)
			{
				steamDatabutton.gameObject.SetActive(value: false);
			}
			else
			{
				steamDatabutton.gameObject.SetActive(value: true);
			}
		}
	}

	public void Start()
	{
		if (character.platform == platform.Kong)
		{
			kongIntro();
			if (!character.settings.badge2Part4Complete && character.settings.badge2Started)
			{
				updateBadgeProgressText();
			}
		}
		else if (character.platform == platform.AG)
		{
			AGIntro();
		}
		else if (character.platform == platform.Kartridge)
		{
			kartIntro();
		}
		else if (character.platform == platform.Steam)
		{
			steamIntro();
		}
	}

	public void specialThanks()
	{
		infoText.text = "<b>Special Thanks go to:</b>\n\nRyu82 (Denny Stöhr) for helping me with basically everything, and being a heavy inspiration for the game. Seriously, go play Idling to Rule the Gods!\n\nRoom 1 of Kongregate's ITRTG chat, and the Somethingawful Forums\n\nRiley Labrecque for making the Steamworks.Net C# API wrapper\n\nthePalindrome, and Room 5 of Kongregate's NGU Idle chat room for walking me through making the online save system, basically.\n\nMusluk for providing all the wonderful and goofy Boss Portraits.\n\nKuwaii, Ninjasamuraii, fluffychair, stb1762, Revenga849, SemperFi87, eineras, pixaal, Jiur, TBlazeWarriorT, Leux, Gem (lonekos), fbrauer\n\nand anyone that helped that I missed!";
	}

	public void kongIntro()
	{
		infoText.text = "Hey Kongregate!\n\nI hope you enjoy the game! NGU has been my big project over the last 5 months, and I finally feel comfortable enough giving it a public release. But, it's still pretty early, and its got bugs here and there. Any feedback, bug reports, complaints or compliments are welcomed and appreciated! You can use the forums, discord, send a raven, etc. I'll be sure to see it. NGU is still fully in development, so expect regular content updates!\n\n ok bye\n\n-4G\n\nPS: Rate 5 plz";
	}

	public void AGIntro()
	{
		infoText.text = "Hey Armor Games!\n\nI hope you enjoy the game! NGU has been a huge project of mine over the last year, and I'm so dang excited to let you get your hands on it! It's my first attempt at making a full and complex game, so its got bugs here and there. Any feedback, bug reports, complaints or compliments are welcomed and appreciated! You can use the forums, discord, send a raven, etc. I'll be sure to see it. NGU is still fully in development, so expect regular content updates!\n\n ok bye\n\n-4G";
	}

	public void kartIntro()
	{
		infoText.text = "Hey Kartridge!\n\nI hope you enjoy the game! NGU has been a huge project of mine over the last 2 years, and I'm so damn excited to let you get your hands on it! It's my first attempt at making a full and complex game, so its got bugs here and there. Any feedback, bug reports, complaints or compliments are welcomed and appreciated! You can use the forums, discord, send a raven, etc. I'll be sure to see it. NGU is still fully in development, so expect regular content updates!\n\n ok bye\n\n-4G";
	}

	public void steamIntro()
	{
		infoText.text = "Hey Steam!\n\nI hope you enjoy the game! NGU has been a huge project of mine over the last 2 years, and I'm so damn excited to let you get your hands on it! It's my first attempt at making a full and complex Idle/Incremental game, so its got bugs here and there. Any feedback, bug reports, complaints or compliments are welcomed and appreciated! You can use the forums, discord, send a raven, etc. I'll be sure to see it. NGU is still fully in development, so expect regular content updates!\n\n ok bye\n\n-4G";
	}

	public void legalStuff()
	{
		infoText.text = "Liberation Sans and Liberation Mono Fonts designed by Red Hat, licensed under SIL Open Font License Version 1.1.";
	}

	public void claimKartPromo()
	{
		if (character.platform == platform.Steam)
		{
			claimSteamPromo();
		}
		if (character.platform == platform.Kartridge)
		{
			if (character.settings.claimedKartPromo)
			{
				character.tooltip.showOverrideTooltip("Hey, you already claimed your free spins! Get outta here!", 3f);
				return;
			}
			character.daily.freeSpins += 7L;
			character.settings.claimedKartPromo = true;
			character.tooltip.showOverrideTooltip("Thanks for checking out NGU Idle on Kartridge! You've been given 7 free daily spins - you can use your free spins under the money pit menu! Daily spins can award you with a variety of free stuff, and the longer you play the better the prizes become!", 12f);
		}
	}

	public void claimSteamPromo()
	{
		if (character.platform == platform.Steam)
		{
			if (character.settings.claimedSteamPromo)
			{
				character.tooltip.showOverrideTooltip("Hey, you already claimed your free stuff! Get outta here!", 3f);
				return;
			}
			character.daily.freeSpins += 7L;
			character.portraits.portraitUnlocked[45] = true;
			character.portraits.portraitUnlocked[46] = true;
			character.settings.claimedSteamPromo = true;
			character.tooltip.showOverrideTooltip("Thanks for checking out NGU Idle on Steam -You've been awarded two special player portraits in the Fight Boss menu! You've also been given 7 free daily spins - you can use your free spins under the money pit menu! Daily spins can award you with a variety of free stuff, and the longer you play the better the prizes become!", 12f);
		}
	}

	public void steamDataNotice()
	{
		infoText.text = "PRIVACY POLICY: NGU Idle collects basic data about your Steam Account (such as your Steam ID or username) in order to and ONLY to operate the Sellout Shop. This data will not be used for any other purpose.";
	}

	public void claimMediumBadge()
	{
		if (character.platform != platform.Kong && character.platform != platform.Kartridge)
		{
			return;
		}
		if (character.settings.badge2Part1Complete && character.settings.badge2Part2Complete && character.settings.badge2Part3Complete && !character.settings.badge2Part4Complete)
		{
			character.settings.badge2Part4Complete = true;
			character.tooltip.showOverrideTooltip("Alright, you've proven yourself worthy of the Medium Badge, you should get it in just a moment!", 6f);
			character.API.submitBadgeProgress();
			updateBadgeProgressText();
		}
		else
		{
			if (!character.settings.badge2Started)
			{
				character.settings.badge2Started = true;
			}
			character.API.submitBadgeProgress();
			updateBadgeProgressText();
		}
		character.API.submitBadgeProgress();
	}

	public void updateBadgeProgressText()
	{
		if (character.menuID != 26)
		{
			return;
		}
		string text = "";
		if (character.settings.badge2Part4Complete)
		{
			text = "Alright, you've proven yourself worthy of the Medium Badge, you should get it in just a moment!";
			infoText.text = text;
		}
		else
		{
			if (!character.settings.badge2Started)
			{
				return;
			}
			text = "WOAH.\n\nWait a moment buddy, you think you can just walk into this game, click a single button, and get a badge? Huh? You gotta EARN IT! Go finish the following tasks for me and then click the button, and you'll get your badge. Plus you might actually enjoy this goofy idle game :o.\n\nYour objectives are as follows:\n";
			if (character.settings.badge2Part1Complete && character.settings.badge2Part2Complete && character.settings.badge2Part3Complete)
			{
				text += "\nYou're all done, just click the button again for the badge! I hope you had fun while earning it! <3";
			}
			else
			{
				if (!character.settings.badge2Part1Complete)
				{
					text += "\n<b>Collect one of every piece of gear in the Sewers zone! These items randomly drop off the boss in that zone. You can complete this task in the Adventure menu. You still need to find the following:\n";
					string text2 = "";
					if (!character.inventory.itemList.itemDropped[40])
					{
						text2 += "Helmet\n";
					}
					if (!character.inventory.itemList.itemDropped[41])
					{
						text2 += "Chest\n";
					}
					if (!character.inventory.itemList.itemDropped[42])
					{
						text2 += "Leggings\n";
					}
					if (!character.inventory.itemList.itemDropped[43])
					{
						text2 += "Boots\n";
					}
					if (!character.inventory.itemList.itemDropped[44])
					{
						text2 += "Weapon\n";
					}
					if (!character.inventory.itemList.itemDropped[45])
					{
						text2 += "Ring\n";
					}
					if (!character.inventory.itemList.itemDropped[46])
					{
						text2 += "Amulet\n";
					}
					if (text2 == "")
					{
						text2 = "You appear to have already gotten all the items! Just trigger an extra item drop from the Sewers to complete this objective!\n";
					}
					text += text2;
					text += "</b>";
				}
				if (!character.settings.badge2Part2Complete)
				{
					text += "\n<b>Collect at least 100,000 Gold at once, and throw it all into the Money Pit! Each kill in Adventure nets you some gold!</b>\n";
				}
				if (!character.settings.badge2Part3Complete)
				{
					text += "\n<b>Reach the Goblin in the 'Fight Boss' menu, and whack him in the crotch with your mouse! I hate that stupid goblin...</b>";
				}
			}
			infoText.text = text;
		}
	}
}
