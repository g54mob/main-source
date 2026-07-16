using System;
using UnityEngine;

public class FixOverfillingStation : ToggleableBrokenHubStation, ISaveable
{
	private Action hideCoalGauge;

	protected override void OnUse()
	{
		if (!Train.Instance.IsOverfillEnabled)
		{
			Train.Instance.IsOverfillEnabled = true;
			ToggleOn();
		}
		else if (Train.Instance.IsOverfillEnabled)
		{
			Train.Instance.IsOverfillEnabled = false;
			ToggleOff();
		}
	}

	public override void Fix(PlayerController player, bool withSfx, bool isNewUnlock)
	{
		hideCoalGauge = (Action)Delegate.Combine(hideCoalGauge, (Action)delegate
		{
			UIManager.Instance.HUD.ShowCoalGauge(show: false);
			DialogueManager.Instance.onCompleteDialogue -= hideCoalGauge;
		});
		DialogueManager.Instance.onCompleteDialogue += hideCoalGauge;
		base.Fix(player, withSfx, isNewUnlock);
	}

	protected override void SetupFixedStation()
	{
		isFixed = true;
		GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
		if (!Train.Instance.IsOverfillEnabled)
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
			metaSave.isOverfillStationFixed = isFixed;
			metaSave.isOverfillStationReadyToUnlock = canBeBought;
			metaSave.isOverfillOn = Train.Instance.IsOverfillEnabled;
			Debug.Log("Saved Overfill Station");
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			isFixed = metaSave.isOverfillStationFixed;
			canBeBought = metaSave.isOverfillStationReadyToUnlock;
			Train.Instance.IsOverfillEnabled = metaSave.isOverfillOn;
			if (metaSave.isOverfillOn)
			{
				interactable.actionNameLocalized = enabledLocalizedKey;
			}
			if (GameManager.Instance.isDemo)
			{
				isFixed = false;
				Train.Instance.IsOverfillEnabled = false;
			}
			Debug.Log("Loaded Overfill Station");
		}
	}
}
