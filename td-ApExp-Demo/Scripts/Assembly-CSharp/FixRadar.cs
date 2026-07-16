using UnityEngine;

public class FixRadar : BrokenHubStation, ISaveable
{
	protected override void SetupFixedStation()
	{
		GetComponent<Animator>().enabled = true;
		interactable.actionNameLocalized = useStationLocalizedKey;
		isFixed = true;
	}

	public override void Fix(PlayerController player, bool withSfx, bool isNewUnlock)
	{
		GetComponent<Animator>().enabled = true;
		base.Fix(player, withSfx, isNewUnlock: false);
	}

	public void Save(SaveDataContext context)
	{
		if (!GameManager.Instance.isDemo)
		{
			context.MetaSave.isRadarFixed = isFixed;
			Debug.Log("Saved Radar");
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			isFixed = metaSave.isRadarFixed;
			if (GameManager.Instance.isDemo)
			{
				isFixed = false;
			}
			Debug.Log("Loaded Radar");
		}
	}
}
