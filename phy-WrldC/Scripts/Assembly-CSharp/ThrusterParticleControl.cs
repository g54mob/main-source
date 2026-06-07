using UnityEngine;

public class ThrusterParticleControl : MonoBehaviour
{
	private ParticleSystem smokeParticleSystem;

	public ParticleSystem MainParticleSystem { get; private set; }

	private void Awake()
	{
		MainParticleSystem = GetComponent<ParticleSystem>();
		smokeParticleSystem = base.transform.FindComponent<ParticleSystem>("DirSmoke", isRecursively: true);
	}

	public void SetStrength(float strength)
	{
		ParticleSystem.EmissionModule emission = MainParticleSystem.emission;
		emission.rateOverTime = strength * 2f;
		ParticleSystem.MainModule main = smokeParticleSystem.main;
		main.startColor = main.startColor.color.WithChange(null, null, null, strength);
	}
}
