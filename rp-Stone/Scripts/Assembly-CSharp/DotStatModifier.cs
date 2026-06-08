using UnityEngine;

public class DotStatModifier : DebuffStatMod
{
	public int ticPeriod = 30;

	public int damagePerPeriod = 1;

	private int dotElapsedTics;

	private int damageRemaining;

	public override void Init()
	{
		base.Init();
		ComputeDotProperties();
	}

	public override void ResetFromReapplying()
	{
		base.ResetFromReapplying();
		ComputeDotProperties();
	}

	private void ComputeDotProperties()
	{
		float num = ItemFactory.GetLevelDisplayValueForItem(base.sourceItem);
		if (base.abilityData != null && base.abilityData.applyRarity)
		{
			num += (float)base.sourceItem.GetRarityBonus();
		}
		damageRemaining = Mathf.FloorToInt(base.statData.Compute(num));
		int num2 = Mathf.CeilToInt((float)damageRemaining * (float)ticPeriod / (float)damagePerPeriod);
		ticDuration = num2 + 1;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		dotElapsedTics++;
		if (dotElapsedTics != ticPeriod)
		{
			return;
		}
		dotElapsedTics = 0;
		if (base.character.Alive && !base.character.IsInvulnerable())
		{
			int num = damagePerPeriod;
			if (ItemData.Counters(base.sourceItem.element) == base.character.GetElement())
			{
				num++;
			}
			Damage damage = new Damage();
			damage.amount = num;
			damage.type = Damage.Type.Dot;
			damage.Owner = base.sourceItem.Owner;
			damage.tags.Add("magic");
			damage.tags.Add(base.sourceItem.element.ToString());
			damage.showFloatingText = true;
			base.character.InflictDamage(damage);
		}
	}
}
