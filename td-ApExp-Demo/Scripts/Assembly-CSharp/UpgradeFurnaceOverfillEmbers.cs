using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnaceOverfillEmbers", menuName = "Upgrade/Furnace/OverfillEmbers")]
public class UpgradeFurnaceOverfillEmbers : EnhancementUpgrade
{
	[SerializeField]
	private float cooldown;

	[SerializeField]
	private GameObject emberPrefab;

	private ModuleFurnace moduleFurnace;

	private float timer;

	private Unit target;

	public override void ApplyUpgrade()
	{
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		if ((object)moduleByType != null)
		{
			moduleFurnace = moduleByType;
			moduleByType.OverfillEffectEnabled = (Action)Delegate.Combine(moduleByType.OverfillEffectEnabled, new Action(OverfillEmbersEnabled));
			moduleByType.OverfillEffectDisabled = (Action)Delegate.Combine(moduleByType.OverfillEffectDisabled, new Action(OverfillEmbersDisabled));
			timer = cooldown;
		}
	}

	public override void UpdateUpgrade()
	{
		base.UpdateUpgrade();
		if (!Train.Instance.IsInOverfill || !moduleFurnace)
		{
			return;
		}
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			target = UnitHelper.GetRandomLiveEnemyUnit(moduleFurnace);
			if (!(target == null))
			{
				SpawnProjectile(target);
				timer = cooldown;
				target = null;
			}
		}
	}

	public void SpawnProjectile(Unit target)
	{
		UnityEngine.Object.Instantiate(emberPrefab, moduleFurnace.transform.position, Quaternion.identity, null).GetComponent<ProjectileFireEmber>().targetPos = target.transform.position;
	}

	public void OverfillEmbersEnabled()
	{
		timer = cooldown;
	}

	public void OverfillEmbersDisabled()
	{
	}
}
