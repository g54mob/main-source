using UnityEngine;

public class ParticleRndAngle : ParticleRndBase
{
	public bool relative;

	public float minAngle = -180f;

	public float maxAngle = 180f;

	public override void Init(AsciiParticle particle)
	{
		Quaternion quaternion = Quaternion.AngleAxis(Random.Range(minAngle, maxAngle), Vector3.back);
		Vector3 velocity = particle.velocity;
		if (relative)
		{
			velocity = quaternion * velocity;
		}
		else
		{
			float magnitude = velocity.magnitude;
			velocity = quaternion * Vector3.right * magnitude;
		}
		particle.velocity = velocity;
	}
}
