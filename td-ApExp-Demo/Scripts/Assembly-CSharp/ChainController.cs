using System.Collections;
using UnityEngine;

public class ChainController : ExtendableLinksComponent
{
	public new bool Retracted;

	public Transform TargetTf => target;

	public override void OnLinkDamaged(HealthChangeInfo info)
	{
		health += info.HealthChange;
		LinkComponent[] array = linksLC;
		foreach (LinkComponent linkComponent in array)
		{
			if ((bool)linkComponent.flashEffect)
			{
				if (info.IsImmune)
				{
					linkComponent.flashEffect.Flash(FlashTypes.Invulnerability);
				}
				else if (info.IsCrit)
				{
					linkComponent.flashEffect.Flash(FlashTypes.Crit);
				}
				else if (info.IsDamageReduced)
				{
					linkComponent.flashEffect.Flash(FlashTypes.ReducedDamage);
				}
				else
				{
					linkComponent.flashEffect.Flash();
				}
			}
		}
		if (health <= 0f)
		{
			DestroyChainCoroutine();
		}
	}

	public IEnumerator RetractCoroutine()
	{
		IsLocked = false;
		while (expansion01 > 0f)
		{
			expansion01 -= Time.deltaTime * retractionSpeed;
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
