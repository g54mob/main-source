public class EventObjectiveSightstoneSpecificFoe : EventObjectiveBase
{
	private string foeID;

	public EventObjectiveSightstoneSpecificFoe(int goal, string foeId, string foeName)
		: base("sightstone_foe", goal)
	{
		foeID = foeId;
		description = string.Format(Te.xt("tid_q_basic_sightstone_foe"), Te.xt("tid_relic_18"), TranslateIfTID(foeName));
	}

	public override void Init()
	{
		SightstoneWeapon.OnSightstoneActivated += HandleSightstoneActivated;
	}

	public override void End()
	{
		SightstoneWeapon.OnSightstoneActivated -= HandleSightstoneActivated;
	}

	private void HandleSightstoneActivated(Character c)
	{
		if (c.id == foeID)
		{
			AddProgress();
		}
	}
}
