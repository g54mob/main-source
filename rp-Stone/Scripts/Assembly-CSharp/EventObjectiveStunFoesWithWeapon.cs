public class EventObjectiveStunFoesWithWeapon : EventObjectiveBase
{
	private string debuffId;

	private string weaponId;

	public EventObjectiveStunFoesWithWeapon(int goal, string debuffId, string weaponId, string weaponName)
		: base("stun_foes", goal)
	{
		this.debuffId = debuffId;
		this.weaponId = weaponId;
		description = string.Format(Te.xt("tid_q_basic_stun_foes"), TranslateIfTID(weaponName));
	}

	public override void Init()
	{
		StatModController.OnDebuffAdded += HandleDebuffAdded;
		StatModController.OnDebuffReset += HandleDebuffAdded;
	}

	public override void End()
	{
		StatModController.OnDebuffAdded -= HandleDebuffAdded;
		StatModController.OnDebuffReset -= HandleDebuffAdded;
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		if (debuff.id.Contains(debuffId) && debuff.sourceItem != null && debuff.sourceItem.id.Contains(weaponId))
		{
			AddProgress();
		}
	}
}
