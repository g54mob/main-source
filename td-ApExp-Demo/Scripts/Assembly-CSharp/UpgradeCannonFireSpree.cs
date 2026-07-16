using UnityEngine;

[CreateAssetMenu(fileName = "CannonFireSpree", menuName = "Upgrade/Cannon/FireSpree")]
public class UpgradeCannonFireSpree : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	private ModuleCannon cannon;

	private bool isStopped;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
		}
		cannon.cannon.OnFire += OnCannonFire;
		cannon.cannon.OnReleaseFire += OnCannonStopFiring;
		cannon.cannon.ReloadStart += OnCannonStartReload;
		cannon.OnInteractEndEvent += OnCannonStopFiring;
		cannon.cannon.OnUpgraded();
	}

	private void OnCannonStartReload()
	{
		OnCannonStopFiring();
	}

	private void OnCannonFire()
	{
		isStopped = false;
		appliedStatusEffect = cannon.StatsSO.ApplyStatusEffect(statusEffectSO);
	}

	private void OnCannonStopFiring()
	{
		if (!isStopped)
		{
			isStopped = true;
			cannon.StatsSO.RemoveStatusEffect(appliedStatusEffect);
		}
	}
}
