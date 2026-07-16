using UnityEngine;

[CreateAssetMenu(fileName = "RelicPassiveHeal", menuName = "Upgrade/Relic/PassiveHeal")]
public class RelicPassiveHeal : EnhancementUpgrade
{
	[SerializeField]
	private float timeInterval;

	[SerializeField]
	private float healAmount;

	private float timeElapsed;

	public override void UpdateUpgrade()
	{
		base.UpdateUpgrade();
		if (!LevelManager.Instance.IsPlaying)
		{
			return;
		}
		timeElapsed += Time.deltaTime;
		if (!(timeElapsed > timeInterval))
		{
			return;
		}
		timeElapsed = 0f;
		foreach (Module module in Train.Instance.Modules)
		{
			module.HealthComponent.Heal(healAmount, Train.Instance.GetModuleByType<ModuleFurnace>());
		}
	}
}
