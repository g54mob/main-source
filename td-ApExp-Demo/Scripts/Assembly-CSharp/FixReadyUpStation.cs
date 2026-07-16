using UnityEngine;

public class FixReadyUpStation : BrokenHubStation, ISaveable
{
	[SerializeField]
	private GameObject bobbyTarot;

	protected override void SetupFixedStation()
	{
		base.SetupFixedStation();
		bobbyTarot.SetActive(value: true);
	}

	public override void Fix(PlayerController player, bool withSfx, bool isNewUnlock)
	{
		base.Fix(player, withSfx, isNewUnlock: false);
		bobbyTarot.SetActive(value: true);
	}

	public void Save(SaveDataContext context)
	{
		if (!GameManager.Instance.isDemo)
		{
			context.MetaSave.isReadyUpStationFixed = isFixed;
			Debug.Log("Saved Ready Up Station");
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			isFixed = metaSave.isReadyUpStationFixed;
			if (GameManager.Instance.isDemo)
			{
				isFixed = false;
			}
			Debug.Log("Loaded Ready Up Station");
		}
	}
}
