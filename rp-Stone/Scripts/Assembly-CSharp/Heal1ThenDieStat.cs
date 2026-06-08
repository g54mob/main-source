public class Heal1ThenDieStat : StatModifier
{
	public int healAmount = 1;

	public override void Init()
	{
		base.Init();
		if (base.character != null)
		{
			Damage damage = new Damage();
			damage.Owner = base.character;
			damage.amount = healAmount;
			base.character.ApplyHeal(damage);
		}
		base.End();
	}
}
