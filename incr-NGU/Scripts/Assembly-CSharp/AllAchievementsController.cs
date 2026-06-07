using UnityEngine;
using UnityEngine.UI;

public class AllAchievementsController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Text achievementCountText;

	public Text achievementBPText;

	public AchievementController[] achievementsList = new AchievementController[108];

	public long[] achievementBP;

	public Sprite[] achievementSprite;

	public int page;

	public long totalBP;

	public long totalAchievementCount;

	public long maxBP;

	private void Start()
	{
		maxBP = calcMaxBP();
		refreshMenu();
		InvokeRepeating("checkAchievements", 0f, 1f);
	}

	public int currentPages()
	{
		return Mathf.FloorToInt(character.achievements.achievementComplete.Count / 108);
	}

	public int AchieveCount()
	{
		return 153;
	}

	public float bonusAP()
	{
		return 1f + (float)totalBP / 10000f;
	}

	public void calculateBP()
	{
		long num = 0L;
		for (int i = 0; i < character.achievements.achievementComplete.Count; i++)
		{
			if (i <= achievementBP.Length && character.achievements.achievementComplete[i])
			{
				num += achievementBP[i];
			}
		}
		totalBP = num;
	}

	public long calcMaxBP()
	{
		long num = 0L;
		for (int i = 0; i < achievementBP.Length; i++)
		{
			num += achievementBP[i];
		}
		return num;
	}

	public void pageUp()
	{
		int num = page + 1;
		if (num >= currentPages())
		{
			num = currentPages() - 1;
		}
		changePage(num);
	}

	public void pageDown()
	{
		int num = page - 1;
		if (num < 0)
		{
			num = 0;
		}
		changePage(num);
	}

	public void changePage(int pageID)
	{
		int num = pageID * 108;
		for (int i = 0; i < achievementsList.Length; i++)
		{
			if (!(achievementsList[i] == null))
			{
				achievementsList[i].id = num;
				num++;
				page = pageID;
				achievementsList[i].updateGraphic();
			}
		}
	}

	public void updateList()
	{
		for (int i = 0; i < achievementsList.Length; i++)
		{
			if (!(achievementsList[i] == null))
			{
				achievementsList[i].updateGraphic();
			}
		}
	}

	public void refreshMenu()
	{
		checkAchievements();
	}

	public void checkAchievements()
	{
		long num = 0L;
		int num2 = 0;
		for (int i = 0; i < character.achievements.achievementComplete.Count; i++)
		{
			if (character.achievements.achievementComplete[i])
			{
				num += achievementBP[i];
				num2++;
			}
			else if (achievementCondition(i))
			{
				character.achievements.achievementComplete[i] = true;
				num += achievementBP[i];
				num2++;
			}
		}
		totalBP = num;
		totalAchievementCount = num2;
		updateList();
		updateAchievementTotal();
	}

	public void updateAchievementTotal()
	{
		achievementCountText.text = "Total Achievements: " + totalAchievementCount + " / " + character.achievements.achievementComplete.Count;
		achievementBPText.text = "Total BP: " + totalBP + " / " + maxBP + " (+" + ((bonusAP() - 1f) * 100f).ToString("##0.##") + "% AP gained)";
	}

	public void markAchievementAsComplete(int id)
	{
		if (id == 145 && !character.achievements.achievementComplete[145])
		{
			tooltip.showOverrideTooltip("As you deliver the final blow to Walderp, dazzling rays of light erupt from his mouth! He explodes violently, shooting millions of small fragments from inside him throughout the universe! A nearby physicist does some frantic napkin math to see if this was even possible. It wasn't. But there's good news! You just unlocked <b>MACGUFFINS</b>! Search through all the zones in adventure to find these powerful artifacts, and equip them in the inventory menu!");
		}
		character.achievements.achievementComplete[id] = true;
	}

	public void macGuffinUnlockLog()
	{
	}

	public string achievementHint(int i)
	{
		switch (i)
		{
		case 0:
			return "Obtain 10 or more Energy Power!";
		case 1:
			return "Obtain 30 or more Energy Power!";
		case 2:
			return "Obtain 100 or more Energy Power!";
		case 3:
			return "Obtain 300 or more Energy Power!";
		case 4:
			return "Obtain 1,000 or more Energy Power!";
		case 5:
			return "Obtain 3,000 or more Energy Power!";
		case 6:
			return "Obtain 10,000 or more Energy Power!";
		case 7:
			return "Obtain 30,000 or more Energy Power!";
		case 8:
			return "Obtain 100,000 or more Energy Power!";
		case 9:
			return "Obtain 300,000 or more Energy Power!";
		case 10:
			return "Obtain 1,000,000 or more Energy Power!";
		case 11:
			return "Obtain 3,000,000 or more Energy Power!";
		case 12:
			return "Obtain 10,000,000 or more Energy Power!";
		case 13:
			return "Obtain 30,000,000 or more Energy Power!";
		case 14:
			return "Obtain 100,000,000 or more Energy Power!";
		case 15:
			return "Obtain 300,000,000 or more Energy Power!";
		case 16:
			return "Obtain 3 or more Magic Power!";
		case 17:
			return "Obtain 10 or more Magic Power!";
		case 18:
			return "Obtain 30 or more Magic Power!";
		case 19:
			return "Obtain 100 or more Magic Power!";
		case 20:
			return "Obtain 300 or more Magic Power!";
		case 21:
			return "Obtain 1,000 or more Magic Power!";
		case 22:
			return "Obtain 3,000 or more Magic Power!";
		case 23:
			return "Obtain 10,000 or more Magic Power!";
		case 24:
			return "Obtain 30,000 or more Magic Power!";
		case 25:
			return "Obtain 100,000 or more Magic Power!";
		case 26:
			return "Obtain 300,000 or more Magic Power!";
		case 27:
			return "Obtain 1,000,000 or more Magic Power!";
		case 28:
			return "Obtain 3,000,000 or more Magic Power!";
		case 29:
			return "Obtain 10,000,000 or more Magic Power!";
		case 30:
			return "Obtain 30,000,000 or more Magic Power!";
		case 31:
			return "Obtain 100,000,000 or more Magic Power!";
		case 32:
			return "Obtain A Total Energy Cap of 10,000 or more!";
		case 33:
			return "Obtain A Total Energy Cap of 100,000 or more!";
		case 34:
			return "Obtain A Total Energy Cap of 300,000 or more!";
		case 35:
			return "Obtain A Total Energy Cap of 1,000,000 or more!";
		case 36:
			return "Obtain A Total Energy Cap of 3,000,000 or more!";
		case 37:
			return "Obtain A Total Energy Cap of 10,000,000 or more!";
		case 38:
			return "Obtain A Total Energy Cap of 30,000,000 or more!";
		case 39:
			return "Obtain A Total Energy Cap of 100,000,000 or more!";
		case 40:
			return "Obtain A Total Energy Cap of 300,000,000 or more!";
		case 41:
			return "Obtain A Total Energy Cap of 1,000,000,000 or more!";
		case 42:
			return "Obtain A Total Energy Cap of 3,000,000,000 or more!";
		case 43:
			return "Obtain A Total Energy Cap of 10,000,000,000 or more!";
		case 44:
			return "Obtain A Total Energy Cap of 30,000,000,000 or more!";
		case 45:
			return "Obtain A Total Energy Cap of 100,000,000,000 or more!";
		case 46:
			return "Obtain A Total Energy Cap of 300,000,000,000 or more!";
		case 47:
			return "Obtain A Total Energy Cap of 1,000,000,000,000 or more!";
		case 48:
			return "Obtain A Total Magic Cap of 30,000 or more!";
		case 49:
			return "Obtain A Total Magic Cap of 100,000 or more!";
		case 50:
			return "Obtain A Total Magic Cap of 300,000 or more!";
		case 51:
			return "Obtain A Total Magic Cap of 1,000,000 or more!";
		case 52:
			return "Obtain A Total Magic Cap of 3,000,000 or more!";
		case 53:
			return "Obtain A Total Magic Cap of 10,000,000 or more!";
		case 54:
			return "Obtain A Total Magic Cap of 30,000,000 or more!";
		case 55:
			return "Obtain A Total Magic Cap of 100,000,000 or more!";
		case 56:
			return "Obtain A Total Magic Cap of 300,000,000 or more!";
		case 57:
			return "Obtain A Total Magic Cap of 1,000,000,000 or more!";
		case 58:
			return "Obtain A Total Magic Cap of 3,000,000,000 or more!";
		case 59:
			return "Obtain A Total Magic Cap of 10,000,000,000 or more!";
		case 60:
			return "Obtain A Total Magic Cap of 30,000,000,000 or more!";
		case 61:
			return "Obtain A Total Magic Cap of 100,000,000,000 or more!";
		case 62:
			return "Obtain A Total Magic Cap of 300,000,000,000 or more!";
		case 63:
			return "Obtain A Total Magic Cap of 1,000,000,000,000 or more!";
		case 64:
			return "Obtain Total Energy Bars of 3 or more!";
		case 65:
			return "Obtain Total Energy Bars of 10 or more!";
		case 66:
			return "Obtain Total Energy Bars of 30 or more!";
		case 67:
			return "Obtain Total Energy Bars of 100 or more!";
		case 68:
			return "Obtain Total Energy Bars of 300 or more!";
		case 69:
			return "Obtain Total Energy Bars of 1,000 or more!";
		case 70:
			return "Obtain Total Energy Bars of 3,000 or more!";
		case 71:
			return "Obtain Total Energy Bars of 10,000 or more!";
		case 72:
			return "Obtain Total Energy Bars of 30,000 or more!";
		case 73:
			return "Obtain Total Energy Bars of 100,000 or more!";
		case 74:
			return "Obtain Total Energy Bars of 300,000 or more!";
		case 75:
			return "Obtain Total Energy Bars of 1,000,000 or more!";
		case 76:
			return "Obtain Total Energy Bars of 3,000,000 or more!";
		case 77:
			return "Obtain Total Energy Bars of 10,000,000 or more!";
		case 78:
			return "Obtain Total Energy Bars of 30,000,000 or more!";
		case 79:
			return "Obtain Total Energy Bars of 100,000,000 or more!";
		case 80:
			return "Obtain Total Magic Bars of 3 or more!";
		case 81:
			return "Obtain Total Magic Bars of 10 or more!";
		case 82:
			return "Obtain Total Magic Bars of 30 or more!";
		case 83:
			return "Obtain Total Magic Bars of 100 or more!";
		case 84:
			return "Obtain Total Magic Bars of 300 or more!";
		case 85:
			return "Obtain Total Magic Bars of 1,000 or more!";
		case 86:
			return "Obtain Total Magic Bars of 3,000 or more!";
		case 87:
			return "Obtain Total Magic Bars of 10,000 or more!";
		case 88:
			return "Obtain Total Magic Bars of 30,000 or more!";
		case 89:
			return "Obtain Total Magic Bars of 100,000 or more!";
		case 90:
			return "Obtain Total Magic Bars of 300,000 or more!";
		case 91:
			return "Obtain Total Magic Bars of 1,000,000 or more!";
		case 92:
			return "Obtain Total Magic Bars of 3,000,000 or more!";
		case 93:
			return "Obtain Total Magic Bars of 10,000,000 or more!";
		case 94:
			return "Obtain Total Magic Bars of 30,000,000 or more!";
		case 95:
			return "Obtain Total Magic Bars of 100,000,000 or more!";
		case 96:
			return "Defeat Boss 10!";
		case 97:
			return "Defeat Boss 20!";
		case 98:
			return "Defeat Boss 30!";
		case 99:
			return "Defeat Boss 40!";
		case 100:
			return "Defeat Boss 50!";
		case 101:
			return "Defeat Boss 60!";
		case 102:
			return "Defeat Boss 70!";
		case 103:
			return "Defeat Boss 80!";
		case 104:
			return "Defeat Boss 90!";
		case 105:
			return "Defeat Boss 100!";
		case 106:
			return "Defeat Boss 110!";
		case 107:
			return "Defeat Boss 120!";
		case 108:
			return "Defeat Boss 130!";
		case 109:
			return "Defeat Boss 140!";
		case 110:
			return "Defeat Boss 150!";
		case 111:
			return "Defeat Boss 160!";
		case 112:
			return "Defeat Boss 170!";
		case 113:
			return "Defeat Boss 180!";
		case 114:
			return "Defeat Boss 190!";
		case 115:
			return "Defeat Boss 200!";
		case 116:
			return "Defeat Boss 210!";
		case 117:
			return "Defeat Boss 220!";
		case 118:
			return "Defeat Boss 230!";
		case 119:
			return "Defeat Boss 240!";
		case 120:
			return "Defeat Boss 250!";
		case 121:
			return "Defeat Boss 260!";
		case 122:
			return "Defeat Boss 270!";
		case 123:
			return "Defeat Boss 280!";
		case 124:
			return "Defeat Boss 290!";
		case 125:
			return "Defeat Boss 300!";
		case 126:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: You need to withstand a mighty blow.";
			}
			return "Survive an attack from an exploder enemy!";
		case 127:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: lol 69.";
			}
			return "Wear a set of Helmet, Chest, Legs, Boots, and Weapon, all at level 69";
		case 128:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Unlock the NGU menu!";
		case 129:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Unlock the Yggdrasil menu!";
		case 130:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Unlock the Beards menu!";
		case 131:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: Not even once.";
			}
			return "Defeat Gordon Ramsay Bolton before they can attack even once!";
		case 132:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: Not even once.";
			}
			return "Defeat Grand Corrupted Tree before they can attack even once!";
		case 133:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: Not even once.";
			}
			return "Defeat Jake From Accounting before they can attack even once!";
		case 134:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: Not even once.";
			}
			return "Defeat Uug The Unmentionable before they can attack even once!";
		case 135:
			return "Rebirth once!";
		case 136:
			return "Rebirth 3 times";
		case 137:
			return "Rebirth 10 times!";
		case 138:
			return "Rebirth 30 times!";
		case 139:
			return "Rebirth 100 times!";
		case 140:
			return "Rebirth 300 times!";
		case 141:
			return "Rebirth 1000 times!";
		case 142:
			return "Rebirth 3000 times!";
		case 143:
			return "Rebirth 10000 times!";
		case 144:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: You know it bothers you.";
			}
			return "Clicked the bottom right corner of the advanced training menu. There, are you happy now?";
		case 145:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Defeat WALDERP's final form!";
		case 146:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: Not even once.";
			}
			return "Defeat WALDERP's final form before they can attack even once!";
		case 147:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: It's mentioned in the WTF pages!";
			}
			return "Speedrun 3 times in a row with rebirths under 30 minutes each, with boss 37 defeated!";
		case 148:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Defeat THE BEAST V1!";
		case 149:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Defeat THE BEAST V2!";
		case 150:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Defeat THE BEAST V3!";
		case 151:
			if (!character.achievements.achievementComplete[i])
			{
				return "Hint: This will take a Titanic effort.";
			}
			return "Defeat THE BEAST V4!";
		case 152:
			return "Enter Evil difficulty for the first time.";
		default:
			return "You shouldn't be seeing this. Oh dear. Tell 4G About it please? <3";
		}
	}

	public bool achievementCondition(int i)
	{
		if (character.achievements.achievementComplete[i])
		{
			return true;
		}
		switch (i)
		{
		case 0:
			return character.totalEnergyPower() >= 10f;
		case 1:
			return character.totalEnergyPower() >= 30f;
		case 2:
			return character.totalEnergyPower() >= 100f;
		case 3:
			return character.totalEnergyPower() >= 300f;
		case 4:
			return character.totalEnergyPower() >= 1000f;
		case 5:
			return character.totalEnergyPower() >= 3000f;
		case 6:
			return character.totalEnergyPower() >= 10000f;
		case 7:
			return character.totalEnergyPower() >= 30000f;
		case 8:
			return character.totalEnergyPower() >= 100000f;
		case 9:
			return character.totalEnergyPower() >= 300000f;
		case 10:
			return character.totalEnergyPower() >= 1000000f;
		case 11:
			return character.totalEnergyPower() >= 3000000f;
		case 12:
			return character.totalEnergyPower() >= 10000000f;
		case 13:
			return character.totalEnergyPower() >= 30000000f;
		case 14:
			return character.totalEnergyPower() >= 100000000f;
		case 15:
			return character.totalEnergyPower() >= 300000000f;
		case 16:
			return character.totalMagicPower() >= 3f;
		case 17:
			return character.totalMagicPower() >= 10f;
		case 18:
			return character.totalMagicPower() >= 30f;
		case 19:
			return character.totalMagicPower() >= 100f;
		case 20:
			return character.totalMagicPower() >= 300f;
		case 21:
			return character.totalMagicPower() >= 1000f;
		case 22:
			return character.totalMagicPower() >= 3000f;
		case 23:
			return character.totalMagicPower() >= 10000f;
		case 24:
			return character.totalMagicPower() >= 30000f;
		case 25:
			return character.totalMagicPower() >= 100000f;
		case 26:
			return character.totalMagicPower() >= 300000f;
		case 27:
			return character.totalMagicPower() >= 1000000f;
		case 28:
			return character.totalMagicPower() >= 3000000f;
		case 29:
			return character.totalMagicPower() >= 10000000f;
		case 30:
			return character.totalMagicPower() >= 30000000f;
		case 31:
			return character.totalMagicPower() >= 100000000f;
		case 32:
			return character.totalCapEnergy() >= 10000;
		case 33:
			return (double)character.totalCapEnergy() >= 100000.0;
		case 34:
			return (double)character.totalCapEnergy() >= 300000.0;
		case 35:
			return (double)character.totalCapEnergy() >= 1000000.0;
		case 36:
			return (double)character.totalCapEnergy() >= 3000000.0;
		case 37:
			return (double)character.totalCapEnergy() >= 10000000.0;
		case 38:
			return (double)character.totalCapEnergy() >= 30000000.0;
		case 39:
			return (double)character.totalCapEnergy() >= 100000000.0;
		case 40:
			return (double)character.totalCapEnergy() >= 300000000.0;
		case 41:
			return (double)character.totalCapEnergy() >= 1000000000.0;
		case 42:
			return (double)character.totalCapEnergy() >= 3000000000.0;
		case 43:
			return (double)character.totalCapEnergy() >= 10000000000.0;
		case 44:
			return (double)character.totalCapEnergy() >= 30000000000.0;
		case 45:
			return (double)character.totalCapEnergy() >= 100000000000.0;
		case 46:
			return (double)character.totalCapEnergy() >= 300000000000.0;
		case 47:
			return (double)character.totalCapEnergy() >= 1000000000000.0;
		case 48:
			return character.totalCapMagic() >= 30000;
		case 49:
			return (double)character.totalCapMagic() >= 100000.0;
		case 50:
			return (double)character.totalCapMagic() >= 300000.0;
		case 51:
			return (double)character.totalCapMagic() >= 1000000.0;
		case 52:
			return (double)character.totalCapMagic() >= 3000000.0;
		case 53:
			return (double)character.totalCapMagic() >= 10000000.0;
		case 54:
			return (double)character.totalCapMagic() >= 30000000.0;
		case 55:
			return (double)character.totalCapMagic() >= 100000000.0;
		case 56:
			return (double)character.totalCapMagic() >= 300000000.0;
		case 57:
			return (double)character.totalCapMagic() >= 1000000000.0;
		case 58:
			return (double)character.totalCapMagic() >= 3000000000.0;
		case 59:
			return (double)character.totalCapMagic() >= 10000000000.0;
		case 60:
			return (double)character.totalCapMagic() >= 30000000000.0;
		case 61:
			return (double)character.totalCapMagic() >= 100000000000.0;
		case 62:
			return (double)character.totalCapMagic() >= 300000000000.0;
		case 63:
			return (double)character.totalCapMagic() >= 1000000000000.0;
		case 64:
			return character.totalEnergyBar() >= 3;
		case 65:
			return character.totalEnergyBar() >= 10;
		case 66:
			return character.totalEnergyBar() >= 30;
		case 67:
			return (double)character.totalEnergyBar() >= 100.0;
		case 68:
			return (double)character.totalEnergyBar() >= 300.0;
		case 69:
			return (double)character.totalEnergyBar() >= 1000.0;
		case 70:
			return (double)character.totalEnergyBar() >= 3000.0;
		case 71:
			return (double)character.totalEnergyBar() >= 10000.0;
		case 72:
			return (double)character.totalEnergyBar() >= 30000.0;
		case 73:
			return (double)character.totalEnergyBar() >= 100000.0;
		case 74:
			return (double)character.totalEnergyBar() >= 300000.0;
		case 75:
			return (double)character.totalEnergyBar() >= 1000000.0;
		case 76:
			return (double)character.totalEnergyBar() >= 3000000.0;
		case 77:
			return (double)character.totalEnergyBar() >= 10000000.0;
		case 78:
			return (double)character.totalEnergyBar() >= 30000000.0;
		case 79:
			return (double)character.totalEnergyBar() >= 100000000.0;
		case 80:
			return character.totalMagicBar() >= 3;
		case 81:
			return character.totalMagicBar() >= 10;
		case 82:
			return character.totalMagicBar() >= 30;
		case 83:
			return (double)character.totalMagicBar() >= 100.0;
		case 84:
			return (double)character.totalMagicBar() >= 300.0;
		case 85:
			return (double)character.totalMagicBar() >= 1000.0;
		case 86:
			return (double)character.totalMagicBar() >= 3000.0;
		case 87:
			return (double)character.totalMagicBar() >= 10000.0;
		case 88:
			return (double)character.totalMagicBar() >= 30000.0;
		case 89:
			return (double)character.totalMagicBar() >= 100000.0;
		case 90:
			return (double)character.totalMagicBar() >= 300000.0;
		case 91:
			return (double)character.totalMagicBar() >= 1000000.0;
		case 92:
			return (double)character.totalMagicBar() >= 3000000.0;
		case 93:
			return (double)character.totalMagicBar() >= 10000000.0;
		case 94:
			return (double)character.totalMagicBar() >= 30000000.0;
		case 95:
			return (double)character.totalMagicBar() >= 100000000.0;
		case 96:
			return character.bossID >= 10;
		case 97:
			return character.bossID >= 20;
		case 98:
			return character.bossID >= 30;
		case 99:
			return character.bossID >= 40;
		case 100:
			return character.bossID >= 50;
		case 101:
			return character.bossID >= 60;
		case 102:
			return character.bossID >= 70;
		case 103:
			return character.bossID >= 80;
		case 104:
			return character.bossID >= 90;
		case 105:
			return character.bossID >= 100;
		case 106:
			return character.bossID >= 110;
		case 107:
			return character.bossID >= 120;
		case 108:
			return character.bossID >= 130;
		case 109:
			return character.bossID >= 140;
		case 110:
			return character.bossID >= 150;
		case 111:
			return character.bossID >= 160;
		case 112:
			return character.bossID >= 170;
		case 113:
			return character.bossID >= 180;
		case 114:
			return character.bossID >= 190;
		case 115:
			return character.bossID >= 200;
		case 116:
			return character.bossID >= 210;
		case 117:
			return character.bossID >= 220;
		case 118:
			return character.bossID >= 230;
		case 119:
			return character.bossID >= 240;
		case 120:
			return character.bossID >= 250;
		case 121:
			return character.bossID >= 260;
		case 122:
			return character.bossID >= 270;
		case 123:
			return character.bossID >= 280;
		case 124:
			return character.bossID >= 290;
		case 125:
			return character.bossID >= 300;
		case 127:
			return all69();
		case 128:
			return character.settings.nguOn;
		case 129:
			return character.settings.yggdrasilOn;
		case 130:
			return character.settings.beardsOn;
		case 135:
			return character.stats.rebirthNumber >= 1;
		case 136:
			return character.stats.rebirthNumber >= 3;
		case 137:
			return character.stats.rebirthNumber >= 10;
		case 138:
			return character.stats.rebirthNumber >= 30;
		case 139:
			return character.stats.rebirthNumber >= 100;
		case 140:
			return character.stats.rebirthNumber >= 300;
		case 141:
			return character.stats.rebirthNumber >= 1000;
		case 142:
			return character.stats.rebirthNumber >= 3000;
		case 143:
			return character.stats.rebirthNumber >= 10000;
		case 147:
			return character.settings.gotSpeedrunSecret;
		default:
			return false;
		}
	}

	public bool all69()
	{
		if (character.inventory.head.level == 69 && character.inventory.chest.level == 69 && character.inventory.legs.level == 69 && character.inventory.boots.level == 69)
		{
			return character.inventory.weapon.level == 69;
		}
		return false;
	}
}
