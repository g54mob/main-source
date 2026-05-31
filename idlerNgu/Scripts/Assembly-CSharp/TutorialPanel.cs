using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
	public Character character;

	public TutorialPanel tutorial;

	public MenuSwapper swapper;

	public GameObject tut;

	public HoverTooltip tooltip;

	public GameObject playerStats;

	public GameObject energy;

	public GameObject magic;

	public GameObject energyMagicRequester;

	public GameObject features;

	public GameObject trainAttackDef;

	public GameObject boss;

	public GameObject otherFeatures;

	public GameObject HP;

	public GameObject attackStat;

	public GameObject defenseStat;

	public GameObject gold;

	public GameObject spendEXP;

	public GameObject quickSaveLoad;

	public GameObject saveLoad;

	public GameObject stats;

	public GameObject rebirth;

	public GameObject firstTrain;

	public GameObject bossFight;

	public GameObject advMoves;

	public GameObject advPlayerStats;

	public GameObject advEnemyStats;

	public GameObject specialExpOffer;

	public GameObject trainAttackMenu;

	public GameObject bossMenu;

	public GameObject expMenu;

	public GameObject adventure;

	private int tutorialState;

	private void Start()
	{
		if (!character.firstTimePlaying)
		{
			hideMenu();
			return;
		}
		tutorial.transform.localPosition = new Vector3(0f, 0f);
		turnOffAllPanels();
	}

	public void showTutorial()
	{
		if (character.firstTimePlaying)
		{
			tut.transform.localPosition = new Vector3(0f, 0f);
		}
		displayState();
	}

	public void hideMenu()
	{
		tut.transform.position = new Vector3(-2000f, -2000f);
		CanvasRenderer[] componentsInChildren = tutorial.GetComponentsInChildren<CanvasRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].SetAlpha(0f);
		}
		character.firstTimePlaying = false;
	}

	private void turnOffAllPanels()
	{
		energy.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		energy.transform.SetAsFirstSibling();
		playerStats.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		playerStats.transform.SetAsFirstSibling();
		magic.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		magic.transform.SetAsFirstSibling();
		energyMagicRequester.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		energyMagicRequester.transform.SetAsFirstSibling();
		features.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		features.transform.SetAsFirstSibling();
		trainAttackDef.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		trainAttackDef.transform.SetAsFirstSibling();
		boss.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		boss.transform.SetAsFirstSibling();
		otherFeatures.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		otherFeatures.transform.SetAsFirstSibling();
		HP.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		HP.transform.SetAsFirstSibling();
		attackStat.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		attackStat.transform.SetAsFirstSibling();
		defenseStat.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		defenseStat.transform.SetAsFirstSibling();
		gold.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		gold.transform.SetAsFirstSibling();
		spendEXP.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		spendEXP.transform.SetAsFirstSibling();
		quickSaveLoad.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		quickSaveLoad.transform.SetAsFirstSibling();
		saveLoad.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		saveLoad.transform.SetAsFirstSibling();
		stats.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		stats.transform.SetAsFirstSibling();
		rebirth.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		rebirth.transform.SetAsFirstSibling();
		firstTrain.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		firstTrain.transform.SetAsFirstSibling();
		bossFight.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		bossFight.transform.SetAsFirstSibling();
		advMoves.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		advMoves.transform.SetAsFirstSibling();
		advPlayerStats.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		advPlayerStats.transform.SetAsFirstSibling();
		advEnemyStats.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		advEnemyStats.transform.SetAsFirstSibling();
		specialExpOffer.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
		specialExpOffer.transform.SetAsFirstSibling();
	}

	public void next()
	{
		tutorialState++;
		displayState();
	}

	public void back()
	{
		if (tutorialState != 22 && tutorialState != 25 && tutorialState != 0)
		{
			tutorialState--;
			displayState();
		}
	}

	private void displayState()
	{
		turnOffAllPanels();
		_ = tutorialState;
		hideAllTooltips();
		hideMenu();
	}

	public void hideAllTooltips()
	{
		tooltip.hideTooltip();
	}

	public void turnOnPanel(GameObject panel)
	{
		panel.GetComponent<Image>().color = new Color32(byte.MaxValue, 237, 0, byte.MaxValue);
	}

	public void shutUpAndLetMePlay()
	{
		hideAllTooltips();
		hideMenu();
		character.firstTimePlaying = false;
	}

	public void startExpTutorial()
	{
	}

	public void startAdventureTutorial()
	{
	}

	public void startInventoryTutorial()
	{
	}
}
