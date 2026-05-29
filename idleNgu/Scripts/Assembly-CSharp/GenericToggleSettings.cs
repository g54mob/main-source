using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericToggleSettings : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Button onButton;

	public Button offButton;

	public int id;

	public string tooltipMessage;

	private bool state;

	private void Start()
	{
		setState();
	}

	public void setState()
	{
		switch (id)
		{
		case 0:
			state = character.settings.antiFlickerBars;
			break;
		case 1:
			state = character.settings.syncTraining;
			break;
		case 2:
			state = character.settings.expPopups;
			break;
		case 3:
			state = character.settings.submitHighscores;
			break;
		case 4:
			state = character.settings.tooltipsOn;
			break;
		case 5:
			state = character.settings.specialAdvHpBars;
			break;
		case 6:
			state = character.settings.filterOn;
			break;
		case 7:
			state = character.settings.filterTitan;
			break;
		case 8:
			state = character.settings.timedTooltipsOn;
			break;
		case 9:
			state = character.settings.autoKillTitans;
			break;
		case 10:
			state = character.settings.autoboostRecycledBoosts;
			break;
		case 11:
			state = character.settings.unassignWhenSwapping;
			break;
		case 12:
			state = character.settings.shakeySales;
			break;
		case 13:
			state = character.settings.beardPopup;
			break;
		case 14:
			state = character.settings.fancyYggBars;
			break;
		case 15:
			state = character.settings.checkForUpdates;
			break;
		case 16:
			state = character.settings.simpleInvShortcuts;
			break;
		case 17:
			state = character.settings.itopodConfirmation;
			break;
		case 18:
			state = character.arbitrary.lazyITOPODOn;
			break;
		case 19:
			state = character.settings.autoNukeOn;
			break;
		case 20:
			state = character.settings.res3NameGeneratorOn;
			break;
		case 21:
			state = character.settings.assholeSetting;
			break;
		case 22:
			state = character.settings.invAutoMergeOn;
			break;
		case 23:
			state = character.settings.invAutoBoostOn;
			break;
		case 24:
			state = character.settings.foilsOn;
			break;
		default:
			state = false;
			break;
		}
		updateToggleStatus();
	}

	public void turnOn()
	{
		changeState(newstate: true);
		updateToggleStatus();
	}

	public void turnOff()
	{
		changeState(newstate: false);
		updateToggleStatus();
	}

	private void updateToggleStatus()
	{
		if (state)
		{
			onButton.interactable = false;
			offButton.interactable = true;
		}
		else
		{
			onButton.interactable = true;
			offButton.interactable = false;
		}
	}

	public void changeState(bool newstate)
	{
		switch (id)
		{
		default:
			return;
		case 0:
			character.settings.antiFlickerBars = newstate;
			break;
		case 1:
			character.settings.syncTraining = newstate;
			break;
		case 2:
			character.settings.expPopups = newstate;
			break;
		case 3:
			character.settings.submitHighscores = newstate;
			break;
		case 4:
			character.settings.tooltipsOn = newstate;
			break;
		case 5:
			character.settings.specialAdvHpBars = newstate;
			break;
		case 6:
			character.settings.filterOn = newstate;
			break;
		case 7:
			character.settings.filterTitan = newstate;
			break;
		case 8:
			character.settings.timedTooltipsOn = newstate;
			break;
		case 9:
			character.settings.autoKillTitans = newstate;
			break;
		case 10:
			character.settings.autoboostRecycledBoosts = newstate;
			break;
		case 11:
			character.settings.unassignWhenSwapping = newstate;
			break;
		case 12:
			character.settings.shakeySales = newstate;
			break;
		case 13:
			character.settings.beardPopup = newstate;
			break;
		case 14:
			character.settings.fancyYggBars = newstate;
			break;
		case 15:
			character.settings.checkForUpdates = newstate;
			break;
		case 16:
			character.settings.simpleInvShortcuts = newstate;
			break;
		case 17:
			character.settings.itopodConfirmation = newstate;
			break;
		case 18:
			character.arbitrary.lazyITOPODOn = newstate;
			break;
		case 19:
			character.settings.autoNukeOn = newstate;
			break;
		case 20:
			character.settings.res3NameGeneratorOn = newstate;
			break;
		case 21:
			character.settings.assholeSetting = newstate;
			break;
		case 22:
			character.settings.invAutoMergeOn = newstate;
			break;
		case 23:
			character.settings.invAutoBoostOn = newstate;
			break;
		case 24:
			character.settings.foilsOn = newstate;
			break;
		}
		state = newstate;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip(tooltipMessage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
