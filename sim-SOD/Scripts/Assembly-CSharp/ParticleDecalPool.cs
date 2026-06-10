using UnityEngine;

public class ParticleDecalPool : MonoBehaviour
{
	public int maxDecals;

	public float decalSizeMin;

	public float decalSizeMax;

	private ParticleSystem decalParticleSystem;

	private int particleDecalDataIndex;

	private ParticleDecalData[] particleData;

	private ParticleSystem.Particle[] particles;

	private void Start()
	{
	}

	public void ParticleHit(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	{
	}

	private void SetParticleData(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	{
	}

	private void DisplayParticles()
	{
	}
}
