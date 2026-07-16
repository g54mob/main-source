using UnityEngine;

public class WeatherManager : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem windPs;

	private void Update()
	{
		GameManager instance = GameManager.Instance;
		if ((object)instance == null || instance.IsJourneyStarted)
		{
			UpdateWindParticles();
		}
	}

	private void UpdateWindParticles()
	{
		if (LevelManager.Instance.CurrentLevel != null && LevelManager.Instance.CurrentLevel.Index != 0)
		{
			if (!windPs.isPlaying)
			{
				windPs.Play();
			}
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = windPs.velocityOverLifetime;
			velocityOverLifetime.speedModifier = Train.Instance.SpeedCurrent;
			ParticleSystem.EmissionModule emission = windPs.emission;
			emission.rateOverTime = Train.Instance.SpeedCurrent / 2f;
		}
	}
}
