using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogListItem : SelectableButton, IPooledListItem
{
	public TextMeshProUGUI label;

	public Image iconImage;

	public Image background;

	public CanvasGroup canvas;

	public LogEntry displayedLogEntry;

	private Color FlashColor = new Color(0.52f, 0.88f, 1f, 1f);

	private Color RegularColor = new Color(0.15f, 0.27f, 0.27f, 0.95f);

	public void UpdateAnimationDisplay(float animationProgress)
	{
		background.color = Color.Lerp(RegularColor, FlashColor, animationProgress);
	}

	public void LoadLogEntry(LogEntry e)
	{
		displayedLogEntry = e;
		if (e.id.TryAsItem(out var i))
		{
			if (i == ItemType.TownExperiencePoint)
			{
				iconImage.sprite = IconManager.Instance.townLevel;
			}
			else
			{
				iconImage.sprite = IconManager.SpriteForItem(i);
			}
		}
		else
		{
			iconImage.sprite = IconManager.SpriteForEntity(e.id);
		}
		ReloadLabels();
	}

	public void ReloadLabels()
	{
		Town town = null;
		if (displayedLogEntry.townIndex < GameManager.Instance.towns.Count)
		{
			town = GameManager.Instance.towns[displayedLogEntry.townIndex];
		}
		BuildingType b;
		if (displayedLogEntry.id.TryAsResearch(out var i))
		{
			string localizedValue = Research.GetLabel(i, displayedLogEntry.level);
			string text = TextDisplay.FormattedKeyValue("ResearchComplete", localizedValue);
			label.text = text;
		}
		else if (displayedLogEntry.id.TryAsBuilding(out b))
		{
			label.text = TextDisplay.FormattedKeyValue("ConstructionComplete", TextDisplay.LabelForBuilding(b));
		}
		else
		{
			if (!displayedLogEntry.id.TryAsItem(out var i2) || i2 != ItemType.TownExperiencePoint)
			{
				return;
			}
			if (town != null)
			{
				string format = TextDisplay.LocalizedTwoValueFormat();
				if (LocalizationManager.IsEnglish())
				{
					label.text = "Town Level Up! " + town.townName + " reached Level " + TextDisplay.LocalizedNumber(displayedLogEntry.level);
					return;
				}
				string formattedLevel = TextDisplay.GetFormattedLevel(displayedLogEntry.level);
				string arg = string.Format(format, town.townName, formattedLevel);
				label.text = string.Format(format, "LevelUpExclamation".Localized(), arg);
			}
			else
			{
				label.text = "LevelUpExclamation".Localized();
			}
		}
	}

	public void SetVisible(bool visible)
	{
		if (null != canvas)
		{
			canvas.alpha = (visible ? 1f : 0f);
			canvas.interactable = visible;
			canvas.blocksRaycasts = visible;
		}
	}
}
