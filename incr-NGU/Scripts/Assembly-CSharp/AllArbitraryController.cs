using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllArbitraryController : MonoBehaviour
{
	public Character character;

	public Text shop1APDisplay;

	public Text shop2APDisplay;

	public Text shop3APDisplay;

	public Text shop4APDisplay;

	public Text shop5APDisplay;

	public Text kredsAPDisplay;

	public Text shop6APDisplay;

	public Text shop7APDisplay;

	public Text shop8APDisplay;

	public Text kreds2Display;

	public GameObject specialNews;

	public GameObject specialNews2;

	public ArbitraryController randomArbitraryController;

	public List<ArbitraryController> arbitraryPods;

	private void Update()
	{
		updateSpecialItems();
	}

	private void updateSpecialItems()
	{
		if (character.arbitrary.energyPotion1Time.totalseconds > 0.0)
		{
			character.arbitrary.energyPotion1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.magicPotion1Time.totalseconds > 0.0)
		{
			character.arbitrary.magicPotion1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.res3Potion1Time.totalseconds > 0.0)
		{
			character.arbitrary.res3Potion1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.lootcharm1Time.totalseconds > 0.0)
		{
			character.arbitrary.lootcharm1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.energyBarBar1Time.totalseconds > 0.0)
		{
			character.arbitrary.energyBarBar1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.magicBarBar1Time.totalseconds > 0.0)
		{
			character.arbitrary.magicBarBar1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.macGuffinBooster1Time.totalseconds > 0.0)
		{
			character.arbitrary.macGuffinBooster1Time.removeTime(Time.deltaTime);
		}
		if (character.arbitrary.mayoSpeedPotTime.totalseconds > 0.0)
		{
			character.arbitrary.mayoSpeedPotTime.removeTime(Time.deltaTime);
		}
	}

	public void reset()
	{
		character.arbitrary.energyPotion2InUse = false;
		character.arbitrary.magicPotion2InUse = false;
		character.arbitrary.res3Potion2InUse = false;
		character.arbitrary.macGuffinBooster1InUse = false;
	}

	public void updateMenu()
	{
		updateText();
		for (int i = 0; i < arbitraryPods.Count; i++)
		{
			if (!(arbitraryPods[i] == null) && arbitraryPods[i].menu == character.menuID)
			{
				arbitraryPods[i].updateMenu();
			}
		}
	}

	public void updateText()
	{
		string text = "You currently have " + character.arbitrary.curArbitraryPoints.ToString("###,##0") + " Arbitrary Points (AP)";
		if (character.menuID == 19)
		{
			shop1APDisplay.text = text;
		}
		if (character.menuID == 25)
		{
			shop2APDisplay.text = text;
			if (!character.arbitrary.boughtFashionPack1 && character.platform != platform.AG)
			{
				specialNews.SetActive(value: true);
			}
			else
			{
				specialNews.SetActive(value: false);
			}
			specialNews2.SetActive(value: false);
		}
		if (character.menuID == 27)
		{
			kredsAPDisplay.text = text;
		}
		if (character.menuID == 28)
		{
			shop3APDisplay.text = text;
		}
		if (character.menuID == 29)
		{
			shop4APDisplay.text = text;
		}
		if (character.menuID == 31)
		{
			shop5APDisplay.text = text;
		}
		if (character.menuID == 42)
		{
			shop6APDisplay.text = text;
		}
		if (character.menuID == 50)
		{
			shop7APDisplay.text = text;
		}
		if (character.menuID == 56)
		{
			shop8APDisplay.text = text;
		}
		if (character.menuID == 46)
		{
			kreds2Display.text = text;
		}
	}

	public float potionModifier()
	{
		float num = 2f;
		if (character.inventory.itemList.blueHeartComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float res3PotionModifier()
	{
		float num = 3f;
		if (character.inventory.itemList.blueHeartComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float pillModifier()
	{
		float num = 2f;
		if (character.inventory.itemList.blueHeartComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float poopModifier()
	{
		float num = 1.5f;
		if (character.inventory.itemList.blueHeartComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float butterModifier()
	{
		float num = 2f;
		if (character.inventory.itemList.blueHeartComplete)
		{
			num *= 1.1f;
		}
		return num;
	}
}
