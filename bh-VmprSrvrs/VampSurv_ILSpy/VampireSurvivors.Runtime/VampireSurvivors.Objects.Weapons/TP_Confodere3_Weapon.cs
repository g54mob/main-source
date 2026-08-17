namespace VampireSurvivors.Objects.Weapons;

public class TP_Confodere3_Weapon : TP_Confodere1_Weapon
{
	protected override bool bigProjectileEnabled => true;

	protected override bool specialProjectileEnabled => true;

	public override float PInterval()
	{
		float num = base.PSpeed();
		float num2 = default(float);
		bool flag = !(1f < num2);
		float num3 = 1f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = base.PInterval();
		return num4 / num3;
	}
}
