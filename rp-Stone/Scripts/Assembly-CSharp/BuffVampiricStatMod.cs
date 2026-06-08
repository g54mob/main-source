using UnityEngine;

public class BuffVampiricStatMod : DebuffStatMod
{
	public float percentLifesteal = 0.2f;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.Owner != null && dmg.Owner == base.character && dmg.amount > 0)
		{
			int amount = Mathf.CeilToInt((float)dmg.amount * percentLifesteal);
			Damage damage = new Damage();
			damage.amount = amount;
			damage.tags.Add("potion");
			damage.tags.Add("lifesteal");
			base.character.ApplyHeal(damage);
			SfxController.singleton.Play("life_gain");
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.End();
	}
}
