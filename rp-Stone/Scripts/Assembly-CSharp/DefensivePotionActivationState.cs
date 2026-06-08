using UnityEngine;

public class DefensivePotionActivationState : BasePotionActivationState
{
	private int armorToGain;

	public override void Activate()
	{
		base.Activate();
		Hero hero = GameStates.Singleton.hero;
		armorToGain = hero.MaxHitpoints;
		SfxController.singleton.Play("potion_defensive");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState != PotionState.BottleMorphing)
		{
			return;
		}
		if (stateElapsedTics == 1)
		{
			ApplyHealing();
		}
		else if (stateElapsedTics == 15)
		{
			ShowArmorEffect();
		}
		else if (stateElapsedTics >= 25)
		{
			if (armorToGain <= 0)
			{
				SetState(State.Done);
				return;
			}
			armorToGain--;
			AddArmor(1);
		}
	}

	private void ApplyHealing()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.Hitpoints < hero.MaxHitpoints)
		{
			int b = hero.MaxHitpoints - hero.Hitpoints;
			int amount = Mathf.Min(hero.MaxHitpoints / 2, b);
			Damage damage = new Damage();
			damage.amount = amount;
			damage.tags.Add("potion");
			hero.ApplyHeal(damage);
			SfxController.singleton.Play("life_gain");
		}
	}

	private void ShowArmorEffect()
	{
		FloatingText floatingText = GameStates.Singleton.hero.ShowFloatingText("[" + armorToGain + ".0]");
		if (floatingText != null)
		{
			floatingText.Message.color = ColorConstants.grey;
		}
		SfxController.singleton.Play("metal_drop");
	}

	private void AddArmor(int amount)
	{
		GameStates.Singleton.hero.Armor += amount;
	}
}
