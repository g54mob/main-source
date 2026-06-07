using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public AllAchievementsController allAchievementsList;

	public Image itemGraphic;

	public Image itemBorder;

	public int id;

	public void updateGraphic()
	{
		if (character.menuID == 30)
		{
			if (id >= character.achievements.achievementComplete.Count)
			{
				itemBorder.enabled = false;
				itemGraphic.enabled = false;
			}
			else if (id >= character.allAchievements.AchieveCount())
			{
				itemBorder.enabled = false;
				itemGraphic.enabled = false;
			}
			else if (character.achievements.achievementComplete[id])
			{
				itemBorder.enabled = true;
				itemGraphic.enabled = true;
				itemGraphic.sprite = allAchievementsList.achievementSprite[id];
				itemGraphic.color = Color.white;
			}
			else
			{
				itemBorder.enabled = true;
				itemGraphic.enabled = true;
				itemGraphic.sprite = allAchievementsList.achievementSprite[id];
				itemGraphic.color = Color.grey;
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (id < character.achievements.achievementComplete.Count)
		{
			string text = character.allAchievements.achievementHint(id);
			if (character.achievements.achievementComplete[id])
			{
				text += " <b><color=green>COMPLETED! :D</color></b>";
			}
			text = text + "\n\nBP Value: " + allAchievementsList.achievementBP[id] + " Points!";
			tooltip.showTooltip(text);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
