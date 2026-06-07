using UnityEngine;

public class PlayerTrapIntensityHelper : MonoBehaviour
{
	public ParticleSystem targetParticles;

	public Vector2 maxSpeedRange;

	private void Awake()
	{
		ParticleSystem.MinMaxCurve startSpeed = targetParticles.main.startSpeed;
		startSpeed.constantMax = Mathf.Lerp(maxSpeedRange.x, maxSpeedRange.y, SpawnAttackOnCollision.lastTriggerProducitonProgress);
		ParticleSystem.MainModule main = targetParticles.main;
		main.startSpeed = startSpeed;
	}
}
