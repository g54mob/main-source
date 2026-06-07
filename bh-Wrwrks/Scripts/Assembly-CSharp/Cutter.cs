public class Cutter : Weapon
{
	private int dmgBonus
	{
		get
		{
			if (owner.name == Module.Name.Cutter)
			{
				return 2;
			}
			return 1;
		}
	}

	private int dmgBonusUp
	{
		get
		{
			_ = owner.name;
			_ = 70;
			return 2;
		}
	}

	public override void HitTrigger(Monster monster)
	{
		bool flag = false;
		foreach (Module input in owner.inputs)
		{
			if (input.accel / 0.3f > 1f)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			monster.Hurt(owner.UPGRADED ? (dmgBonus + dmgBonusUp) : dmgBonus, null, noDeathrattle: false, 5, owner, "FFEB57");
		}
	}
}
