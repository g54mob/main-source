using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Generic3Toggle : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public List<Button> buttons;

	public int id;

	public string tooltipMessage;

	private int state;

	private void Start()
	{
		if (id == 0)
		{
			state = (int)character.settings.rebirthDifficulty;
			character.nextRebirthDifficulty = (difficulty)state;
		}
		else
		{
			state = 0;
		}
		updateToggleStatus();
	}

	private void updateToggleStatus()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].interactable = true;
		}
		buttons[state].interactable = false;
	}

	public void changeState(int newstate)
	{
		if (id == 0)
		{
			changeStateDifficulty(newstate);
		}
	}

	public void changeStateDifficulty(int newstate)
	{
		if (newstate >= 2 && character.highestHardBoss < 200)
		{
			tooltip.showTooltip("You need to have defeated Boss 200 at least once on a hard rebirth before even thinking of moving to SADISTIC difficulty! I'm protecting you from yourself!", 5f);
			return;
		}
		if (newstate >= 1 && character.highestBoss < 200)
		{
			tooltip.showTooltip("You need to have defeated Boss 200 at least once on a normal rebirth before even thinking of moving to hard difficulty! I'm protecting you from yourself!", 5f);
			return;
		}
		state = newstate;
		character.nextRebirthDifficulty = (difficulty)state;
		updateToggleStatus();
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
