using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class BeastQuestPerkUIController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public BeastQuestPerkController beastQuestPerkController;

	public ConfirmationBox box;

	public Image itemGraphic;

	public Image itemBorder;

	public int id;

	private UnityAction yesaction;

	private UnityAction noAction;

	public void Start()
	{
		yesaction = doClick;
		noAction = cancel;
	}

	public void cancel()
	{
	}

	public void updateGraphic()
	{
		if (id >= character.beastQuest.quirkLevel.Count)
		{
			itemBorder.enabled = false;
			itemGraphic.enabled = false;
			return;
		}
		itemBorder.enabled = true;
		itemGraphic.enabled = true;
		if (character.beastQuest.quirkLevel[id] <= 0)
		{
			itemGraphic.color = Color.grey;
			itemBorder.color = Color.grey;
			itemGraphic.sprite = beastQuestPerkController.graphic[id];
		}
		else if (character.beastQuest.quirkLevel[id] < character.beastQuestPerkController.maxLevel[id])
		{
			itemGraphic.color = Color.white;
			itemBorder.color = Color.white;
			itemGraphic.sprite = beastQuestPerkController.graphic[id];
		}
		else
		{
			itemGraphic.color = Color.white;
			itemBorder.color = new Color(1f, 0.8f, 0f);
			itemGraphic.sprite = beastQuestPerkController.graphic[id];
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		yesaction = doClick;
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			levelAllEvent();
		}
		else if (character.beastQuest.quirkLevel[id] >= character.beastQuestPerkController.capLevel(id))
		{
			tooltip.showTooltip("Hey this Quirk is at the MAX level, can't you read? Jeez.", 2f);
		}
		else if (character.beastQuest.quirkPoints < character.beastQuestPerkController.quirkCost(id))
		{
			tooltip.showTooltip("Hey math genius, you don't have enough QP to level this Quirk up!", 2f);
		}
		else if (character.settings.rebirthDifficulty < character.beastQuestPerkController.quirkDifficultyReq[id])
		{
			tooltip.showOverrideTooltip(string.Concat("You can't buy this Quirk until you move to ", character.beastQuestPerkController.quirkDifficultyReq[id], " difficulty!"), 2f);
		}
		else if (character.settings.itopodConfirmation)
		{
			box.displayBox("Do you want to upgrade the Quirk '" + character.beastQuestPerkController.quirkName[id] + "' for " + character.beastQuestPerkController.cost[id] + " QP?", yesaction, noAction);
		}
		else
		{
			doClick();
		}
	}

	public void clickEvent()
	{
	}

	public void levelAllEvent()
	{
		yesaction = levelAll;
		if (character.beastQuest.quirkLevel[id] >= character.beastQuestPerkController.capLevel(id))
		{
			tooltip.showTooltip("Hey this Quirk is at the MAX level, can't you read? Jeez.", 2f);
		}
		else if (character.beastQuest.quirkPoints < character.beastQuestPerkController.quirkCost(id))
		{
			tooltip.showTooltip("Hey math genius, you don't have enough QP to level this Quirk up even once!", 2f);
		}
		else if (character.settings.rebirthDifficulty < character.beastQuestPerkController.quirkDifficultyReq[id])
		{
			tooltip.showOverrideTooltip(string.Concat("You can't buy this Quirk until you move to ", character.beastQuestPerkController.quirkDifficultyReq[id], " difficulty!"), 2f);
		}
		else if (character.settings.itopodConfirmation)
		{
			box.displayBox("Do you want to use ALL your QP to level up '" + character.beastQuestPerkController.quirkName[id] + "'?", yesaction, noAction);
		}
		else
		{
			levelAll();
		}
	}

	public void doClick()
	{
		beastQuestPerkController.tryLevelUp(id);
		updateGraphic();
	}

	public void levelAll()
	{
		beastQuestPerkController.tryLevelAll(id);
		updateGraphic();
	}

	public void enterEvent()
	{
		beastQuestPerkController.showTooltip(id);
	}

	public void exitEvent()
	{
		beastQuestPerkController.hideTooltip();
	}
}
