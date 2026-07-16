using UnityEngine;

[CreateAssetMenu(fileName = "EMPFireOnDestroy", menuName = "Upgrade/EMP/FireOnDestroy")]
public class UpgradeEMPFireOnDestroy : EnhancementUpgrade
{
	[SerializeField]
	private float percentDurationReduction;

	private ModuleEMP emp;

	public override void ApplyUpgrade()
	{
		emp = Train.Instance.GetModuleByType<ModuleEMP>();
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		if (modulesByType != null)
		{
			for (int i = 0; i < modulesByType.Length; i++)
			{
				modulesByType[i].FullyBroken += OnModuleFullyBroken;
			}
		}
	}

	private void OnModuleFullyBroken()
	{
		emp.emergencyDurationReduction = percentDurationReduction;
		emp.Activate();
		emp.emergencyDurationReduction = 0f;
	}
}
