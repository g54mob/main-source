using UnityEngine;

public class SwarmBrain : BaseEnemyBrain
{
	private const float STEALTH_DETECTION_RADIUS = 1.3f;

	public SwarmManager TheSwarmManager { get; private set; }

	public override int WANDERYNESS
	{
		get
		{
			return 50;
		}
	}

	public override float WANDER_CHECK_PERIOD
	{
		get
		{
			return 10f;
		}
	}

	public override BaseEnemy ThisEnemy
	{
		get
		{
			return TheSwarmManager.GetAlphaEnemy();
		}
	}

	public SwarmBrain(SwarmManager swarmManager)
		: base(null)
	{
		TheSwarmManager = swarmManager;
	}

	public override void BeginCuriousPause()
	{
		TheSwarmManager.SetIndividualFlightSpeed(0.75f);
	}

	public override void EndCuriousPause()
	{
		TheSwarmManager.SetIndividualFlightSpeed(3f);
	}

	public override bool BumpedIntoStealthDrone(ICombatTarget target)
	{
		if (target != null && ThisEnemy != null && !target.IsDead && target.IsHidden)
		{
			float num = Vector3.Distance(ThisEnemy.transform.position, target.Position);
			if (num < 1.3f)
			{
				return true;
			}
		}
		return false;
	}
}
