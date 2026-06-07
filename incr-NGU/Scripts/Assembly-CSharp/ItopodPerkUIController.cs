using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItopodPerkUIController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public ItopodPerkController allPerkController;

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
		if (id >= character.adventure.itopod.perkLevel.Count)
		{
			itemBorder.enabled = false;
			itemGraphic.enabled = false;
			return;
		}
		itemBorder.enabled = true;
		itemGraphic.enabled = true;
		if (character.adventure.itopod.perkLevel[id] <= 0)
		{
			itemGraphic.color = Color.grey;
			itemBorder.color = Color.grey;
			itemGraphic.sprite = allPerkController.graphic[id];
		}
		else if (character.adventure.itopod.perkLevel[id] < character.adventureController.itopod.maxLevel[id])
		{
			itemGraphic.color = Color.white;
			itemBorder.color = Color.white;
			itemGraphic.sprite = allPerkController.graphic[id];
		}
		else
		{
			itemGraphic.color = Color.white;
			itemBorder.color = new Color(1f, 0.8f, 0f);
			itemGraphic.sprite = allPerkController.graphic[id];
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		yesaction = doClick;
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			levelAllEvent();
		}
		else if (character.adventure.itopod.perkLevel[id] >= character.adventureController.itopod.capLevel(id))
		{
			tooltip.showTooltip("Hey this perk is at the MAX level, can't you read? Jeez.", 2f);
		}
		else if (character.adventure.itopod.perkPoints < character.adventureController.itopod.perkCost(id))
		{
			tooltip.showTooltip("Hey math genius, you don't have enough PP to level this perk up!", 2f);
		}
		else if (character.settings.rebirthDifficulty < character.adventureController.itopod.perkDifficultyReq[id])
		{
			tooltip.showOverrideTooltip(string.Concat("You can't buy this Perk until you move to ", character.adventureController.itopod.perkDifficultyReq[id], " difficulty!"));
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.MacGuffin && !character.achievements.achievementComplete[145])
		{
			tooltip.showTooltip("Psst. You don't have MacGuffins yet. In fact, MacGuffins are classified information so I have to neuralyze you now. You won't remember this. ", 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.Wishes && !character.wishes.wishesOn)
		{
			tooltip.showTooltip("Psst. You don't have Wishes yet. In fact, Wishes is classified information so I have to neuralyze you now. You won't remember this.", 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.Cards && !character.cards.cardsOn)
		{
			tooltip.showTooltip("Psst. You don't have Cards yet. In fact, Cards are classified information so I have to neuralyze you now. You won't remember this.", 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.Hacks && !character.hacks.hacksOn)
		{
			tooltip.showTooltip("Psst. You don't have Hacks yet. In fact, Hacks is classified information so I have to neuralyze you now. You won't remember this.", 3f);
		}
		else if (character.settings.itopodConfirmation)
		{
			box.displayBox("Do you want to upgrade the perk '" + character.adventureController.itopod.getPerkName(id) + "' for " + character.adventureController.itopod.cost[id] + " PP?", yesaction, noAction);
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
		if (character.adventure.itopod.perkLevel[id] >= character.adventureController.itopod.capLevel(id))
		{
			tooltip.showTooltip("Hey this perk is at the MAX level, can't you read? Jeez.", 2f);
		}
		else if (character.adventure.itopod.perkPoints < character.adventureController.itopod.perkCost(id))
		{
			tooltip.showTooltip("Hey math genius, you don't have enough PP to level this perk up even once!", 2f);
		}
		else if (character.settings.rebirthDifficulty < character.adventureController.itopod.perkDifficultyReq[id])
		{
			tooltip.showOverrideTooltip(string.Concat("You can't buy this Perk until you move to ", character.adventureController.itopod.perkDifficultyReq[id], " difficulty!"), 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.MacGuffin && !character.achievements.achievementComplete[145])
		{
			tooltip.showTooltip("Psst. You don't have MacGuffins yet. In fact, MacGuffins are classified information so I have to neuralyze you now. You won't remember this. ", 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.Wishes && !character.wishes.wishesOn)
		{
			tooltip.showTooltip("Psst. You don't have Wishes yet. In fact, Wishes is classified information so I have to neuralyze you now. You won't remember this.", 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.Cards && !character.cards.cardsOn)
		{
			tooltip.showTooltip("Psst. You don't have Cards yet. In fact, Cards are classified information so I have to neuralyze you now. You won't remember this.", 3f);
		}
		else if (character.adventureController.itopod.perkType[id] == itopodPerk.Hacks && !character.hacks.hacksOn)
		{
			tooltip.showTooltip("Psst. You don't have Hacks yet. In fact, Hacks is classified information so I have to neuralyze you now. You won't remember this.", 3f);
		}
		else if (character.settings.itopodConfirmation)
		{
			box.displayBox("Do you want to use ALL your PP to level up '" + character.adventureController.itopod.getPerkName(id) + "?", yesaction, noAction);
		}
		else
		{
			levelAll();
		}
	}

	public void doClick()
	{
		allPerkController.tryLevelUp(id);
		updateGraphic();
	}

	public void levelAll()
	{
		allPerkController.tryLevelAll(id);
		updateGraphic();
	}

	public void enterEvent()
	{
		allPerkController.showTooltip(id);
	}

	public void exitEvent()
	{
		allPerkController.hideTooltip();
	}
}
