public class RobotBossAttackPushback : EntityMonoBehaviour
{
	public NukeAttackFX nukeFX;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (EntityUtility.IsNewlyCreatedObject(base.entity, base.world))
		{
			nukeFX.Play();
		}
	}
}
