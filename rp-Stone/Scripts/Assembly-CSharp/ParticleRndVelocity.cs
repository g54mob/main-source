using UnityEngine;

public class ParticleRndVelocity : ParticleRndBase
{
	public bool multiplyAllAxis = true;

	public float minMultiplier = 1f;

	public float maxMultiplier = 1f;

	public bool multiplyPerAxis;

	public Vector3 minMultiplyAxis = Vector3.one;

	public Vector3 maxMultiplyAxis = Vector3.one;

	public bool addAxis;

	public Vector3 minVelocityAdd = Vector3.zero;

	public Vector3 maxVelocityAdd = Vector3.zero;

	public override void Init(AsciiParticle particle)
	{
		Vector3 velocity = particle.velocity;
		if (multiplyAllAxis)
		{
			velocity *= Random.Range(minMultiplier, maxMultiplier);
		}
		if (multiplyPerAxis)
		{
			velocity.x *= Random.Range(minMultiplyAxis.x, maxMultiplyAxis.x);
			velocity.y *= Random.Range(minMultiplyAxis.y, maxMultiplyAxis.y);
			velocity.z *= Random.Range(minMultiplyAxis.z, maxMultiplyAxis.z);
		}
		if (addAxis)
		{
			velocity.x += Random.Range(minVelocityAdd.x, maxVelocityAdd.x);
			velocity.y += Random.Range(minVelocityAdd.y, maxVelocityAdd.y);
			velocity.z += Random.Range(minVelocityAdd.z, maxVelocityAdd.z);
		}
		particle.velocity = velocity;
	}
}
