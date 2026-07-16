using UnityEngine;

[CreateAssetMenu(fileName = "FactoryLuckFactory", menuName = "Upgrade/Factory/FactoryLuckFactory")]
public class UpgradeFactoryLuckFactory : EnhancementUpgrade
{
	[SerializeField]
	private int locationsRequired = 3;

	private ModuleFactory factory;

	private int locationsCompleted;

	public override void ApplyUpgrade()
	{
		factory = Train.Instance.GetModuleByType<ModuleFactory>();
		locationsCompleted = 0;
		LevelManager.Instance.LevelCompleted += Instance_LevelCompleted;
	}

	private void Instance_LevelCompleted()
	{
		if (++locationsCompleted == locationsRequired)
		{
			factory.AddResource(1f, ResourceTypes.Rerolls);
			locationsCompleted = 0;
		}
	}
}
