using UnityEngine;

[CreateAssetMenu(fileName = "StatusEffectProjectileMomentum", menuName = "Status Effects/ProjectileMomentum")]
public class StatusEffectProjMomentum : StatusEffectStats
{
	private float projSpeedIncrease;

	[SerializeField]
	private float speedIncreaseAtRegularMaxSpeed = 0.5f;

	public override void Update()
	{
		base.Update();
		if (Train.Instance.CurrentSpeedIndex() > 1f)
		{
			projSpeedIncrease = speedIncreaseAtRegularMaxSpeed * Train.Instance.CurrentSpeedIndex();
			statUpgrades[0] = new StatUpgrade(StatTypes.projectileSpeed, projSpeedIncrease, isPercent: false);
		}
	}
}
