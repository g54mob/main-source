using System.Collections.Generic;

public class IgnitionStatMod : DebuffStatMod
{
	public int ticPeriod = 30;

	public int damagePerPeriod = 1;

	private int dotElapsedTics;

	public static List<IgnitionStatMod> allIgnitions = new List<IgnitionStatMod>();

	public override void Init()
	{
		base.Init();
		for (int i = 0; i < allIgnitions.Count; i++)
		{
			IgnitionStatMod ignitionStatMod = allIgnitions[i];
			if (ignitionStatMod != null)
			{
				ignitionStatMod.ElapsedTics = 0;
			}
		}
		allIgnitions.Add(this);
	}

	public override void End()
	{
		RemoveFromCollection();
		base.End();
	}

	protected override void OnDestroy()
	{
		RemoveFromCollection();
		base.OnDestroy();
	}

	private void RemoveFromCollection()
	{
		for (int num = allIgnitions.Count - 1; num >= 0; num--)
		{
			if (allIgnitions[num] == this || allIgnitions[num] == null)
			{
				allIgnitions.RemoveAt(num);
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		dotElapsedTics++;
		if (dotElapsedTics == ticPeriod)
		{
			dotElapsedTics = 0;
			if (base.character.Alive && !base.character.IsInvulnerable())
			{
				Damage damage = new Damage();
				damage.amount = damagePerPeriod;
				damage.type = Damage.Type.Dot;
				damage.Owner = base.sourceItem.Owner;
				damage.tags.Add("Ignition");
				damage.tags.Add("magic");
				damage.tags.Add(base.sourceItem.element.ToString());
				damage.showFloatingText = true;
				base.character.InflictDamage(damage);
			}
		}
	}
}
