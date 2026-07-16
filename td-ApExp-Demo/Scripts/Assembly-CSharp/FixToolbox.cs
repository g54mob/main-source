using UnityEngine;

public class FixToolbox : ToggleableBrokenHubStation, ISaveable
{
	protected override void OnUse()
	{
		if (!GameManager.Instance.isTimingMinigameEnabled)
		{
			GameManager.Instance.isTimingMinigameEnabled = true;
			ToggleOn();
		}
		else if (GameManager.Instance.isTimingMinigameEnabled)
		{
			GameManager.Instance.isTimingMinigameEnabled = false;
			ToggleOff();
		}
	}

	protected override void SetupFixedStation()
	{
		isFixed = true;
		if (!GameManager.Instance.isTimingMinigameEnabled)
		{
			sr.sprite = fixedSprite;
		}
		else
		{
			sr.sprite = activatedSprite;
		}
		interactable.actionNameLocalized = disabledLocalizedKey;
		if ((bool)bobbyGuide)
		{
			bobbyGuide.blockInteract = true;
		}
		base.gameObject.GetComponent<Outline>().Animate(play: false);
	}

	public void Save(SaveDataContext context)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			metaSave.isToolboxFixed = isFixed;
			metaSave.isToolboxReadyToUnlock = canBeBought;
			metaSave.isTimingMinigameOn = GameManager.Instance.isTimingMinigameEnabled;
			Debug.Log("Saved Toolbox");
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			isFixed = metaSave.isToolboxFixed;
			canBeBought = metaSave.isToolboxReadyToUnlock;
			GameManager.Instance.isTimingMinigameEnabled = metaSave.isTimingMinigameOn;
			if (metaSave.isTimingMinigameOn)
			{
				interactable.actionNameLocalized = enabledLocalizedKey;
			}
			if (GameManager.Instance.isDemo)
			{
				isFixed = false;
				GameManager.Instance.isTimingMinigameEnabled = false;
			}
			Debug.Log("Loaded Toolbox");
		}
	}
}
