using System.Collections.Generic;
using UnityEngine;

public class AdaptiveDefenseStatMod : DebuffStatMod
{
	public string defenseAgainst = "AEther";

	public float damageReductionPercent = 0.5f;

	private MultiplyDamageFromMagic damageMultiplyComponent;

	public override void Init()
	{
		base.Init();
		GameObject gameObject = base.character.gameObject;
		MultiplyDamageFromMagic[] components = gameObject.GetComponents<MultiplyDamageFromMagic>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].singleTag == defenseAgainst)
			{
				damageMultiplyComponent = components[i];
				break;
			}
		}
		if (damageMultiplyComponent == null)
		{
			damageMultiplyComponent = gameObject.AddComponent<MultiplyDamageFromMagic>();
			damageMultiplyComponent.singleTag = defenseAgainst;
			damageMultiplyComponent.multiplier = 1f;
		}
		damageMultiplyComponent.multiplier *= 1f - damageReductionPercent;
	}

	public override void End()
	{
		damageMultiplyComponent.multiplier /= 1f - damageReductionPercent;
		if (base.character != null && base.character.statModController != null && base.character.statModController.debuffs != null)
		{
			for (int i = 0; i < base.character.statModController.debuffs.Count; i++)
			{
				List<StatModifier> list = base.character.statModController.debuffs[i];
				if (list.Contains(this))
				{
					if (list.Count - 1 <= 0)
					{
						Object.Destroy(damageMultiplyComponent);
					}
					break;
				}
			}
		}
		damageMultiplyComponent = null;
		base.End();
	}
}
