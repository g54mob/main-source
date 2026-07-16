using UnityEngine;

[CreateAssetMenu(fileName = "RelicEnergyTransfer", menuName = "Upgrade/Relic/EnergyTransfer")]
public class RelicEnergyTransfer : EnhancementUpgrade
{
	[SerializeField]
	private int moduleUsesRequired = 5;

	private int moduleUses;

	private int damageIncreaseLevel;

	private ModuleCannon cannon;

	public override void ApplyUpgrade()
	{
		moduleUses = 0;
		damageIncreaseLevel = 0;
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
		}
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		foreach (Module module in modulesByType)
		{
			TrySubscribeToModuleStart(module);
		}
		Train.Instance.ModuleEnabled += OnModuleEnabled;
		LevelManager.Instance.LevelStarted += OnLevelStarted;
		LevelManager.Instance.LevelCompleted += OnLevelCompleted;
	}

	private void OnModuleEnabled(Module module)
	{
		TrySubscribeToModuleStart(module);
	}

	private void TrySubscribeToModuleStart(Module module)
	{
		if (module is ModuleMissile || module is ModuleOverdrive || module is ModuleHacking || module is ModuleEMP || module is ModuleDamageControl || module is ModuleNuke)
		{
			module.OnInteractStartEvent += Module_OnInteractStartEvent;
		}
	}

	private void Module_OnInteractStartEvent()
	{
		moduleUses++;
		if (moduleUses >= moduleUsesRequired + damageIncreaseLevel * moduleUsesRequired)
		{
			damageIncreaseLevel++;
			cannon.cannon.ApplyDamageBoost(1f);
		}
	}

	private void OnLevelStarted()
	{
		moduleUses = 0;
		damageIncreaseLevel = 0;
	}

	private void OnLevelCompleted()
	{
		cannon.cannon.ApplyDamageBoost(-damageIncreaseLevel);
		moduleUses = 0;
		damageIncreaseLevel = 0;
	}
}
