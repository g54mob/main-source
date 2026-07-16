using UnityEngine;

[CreateAssetMenu(fileName = "EMPHack", menuName = "Upgrade/Mixed/EMPHack")]
public class UpgradeEMPHack : EnhancementUpgrade
{
	[SerializeField]
	private float hackProb = 0.05f;

	private ModuleHacking hack;

	public override void ApplyUpgrade()
	{
		hack = Train.Instance.GetModuleByType<ModuleHacking>();
		EnemyManager.Instance.EnemyEMPd += OnEnemyEMPd;
	}

	private void OnEnemyEMPd(EnemyBase enemy)
	{
		if (ProbUtils.CheckWithLuck(hackProb))
		{
			hack.HackEnemy(enemy);
		}
	}
}
