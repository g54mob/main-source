using UnityEngine;

[CreateAssetMenu(fileName = "ClawDeflect", menuName = "Upgrade/Claw/Deflect")]
public class UpgradeClawDeflect : EnhancementUpgrade
{
	[SerializeField]
	[Range(0f, 100f)]
	private float deflectChance;

	private ModuleClaw moduleClaw;

	public override void ApplyUpgrade()
	{
		ModuleClaw moduleByType = Train.Instance.GetModuleByType<ModuleClaw>();
		if ((object)moduleByType != null)
		{
			moduleClaw = moduleByType;
			moduleClaw.SetIsDeflecting(val: true);
			moduleClaw.SetDeflectChance(deflectChance);
			moduleClaw.OnSecondClawCreated += Claw_OnSecondClawCreated;
		}
	}

	private void Claw_OnSecondClawCreated()
	{
		moduleClaw.SetIsDeflecting(val: true);
		moduleClaw.SetDeflectChance(deflectChance);
	}
}
