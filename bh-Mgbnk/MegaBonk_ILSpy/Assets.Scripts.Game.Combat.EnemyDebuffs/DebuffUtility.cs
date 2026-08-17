namespace Assets.Scripts.Game.Combat.EnemyDebuffs;

public class DebuffUtility
{
	public static readonly int debuffTicksPerSecond = 2;

	public static readonly float debuffCooldownSeconds;

	static DebuffUtility()
	{
		float num = 1f / (float)debuffTicksPerSecond;
		debuffCooldownSeconds = num;
	}
}
