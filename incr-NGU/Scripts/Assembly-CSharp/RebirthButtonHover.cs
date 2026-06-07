using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RebirthButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public CurrentChallengeInfo challengeInfo;

	public Text rebirthTimeText;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void Start()
	{
		InvokeRepeating("updateText", 0f, 0.1f);
	}

	public void updateText()
	{
		rebirthTimeText.text = "<b>Current Rebirth Time:</b>\n" + character.rebirthTime.timeDisplayColon();
		if (!character.settings.assholeSetting)
		{
			Text text = rebirthTimeText;
			text.text = text.text ?? "";
		}
		else if ((double)character.saveLoad.autoSaveTime() - character.saveLoad.autosaveTime.totalseconds <= 0.5 || (character.saveLoad.autosaveTime.totalseconds >= 0.0 && character.saveLoad.autosaveTime.totalseconds < 0.5))
		{
			rebirthTimeText.text += "\nSaving, please wait...";
		}
		else if (character.saveLoad.autosaveTime.totalseconds >= 0.5 && character.saveLoad.autosaveTime.totalseconds <= 1.5)
		{
			rebirthTimeText.text += "\nAutosaved!";
		}
		else
		{
			Text text2 = rebirthTimeText;
			text2.text = text2.text + "\nAutosave in " + NumberOutput.timeOutput((double)character.saveLoad.autoSaveTime() - character.saveLoad.autosaveTime.totalseconds);
		}
	}

	public void showTooltip()
	{
		if (character.challenges.inChallenge)
		{
			tooltip.showTooltip("<b>Current Rebirth Time:</b>\n" + character.rebirthTime.timeDisplayColon() + "\n\n" + challengeInfo.challengeInfoMessage());
		}
		else
		{
			tooltip.showTooltip("<b>Current Rebirth Time:</b>\n" + character.rebirthTime.timeDisplayColon());
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}
}
