using System;
using System.Collections;
using UnityEngine;

public class TrainCarCollisions : MonoBehaviour
{
	public const float LATERAL_COLLISION_MODIFIER = 1.33f;

	private const float FORCE_MAGNITUDE_SCALER = 1E-06f;

	private const float MIN_COLLISION_FORCE_FOR_SPARK = 4f;

	private const float MAX_COLLISION_FORCE_FOR_SPARK = 15f;

	private const float MIN_SPARK_RANGE = 20f;

	private const float MAX_SPARK_RANGE = 40f;

	private const int SPARK_CHANCE = 90;

	public Action<float, Vector3> CarDamaged;

	private Collider[] overlapColliders = new Collider[16];

	private float ignitionStrength = 1f;

	private int sparkFrameDelay = 3;

	private void OnCollisionEnter(Collision collision)
	{
		if (!(collision.transform.root == base.transform.root))
		{
			float magnitude = (collision.impulse * 1E-06f / Time.fixedDeltaTime).magnitude;
			float t = Mathf.Abs(Vector3.Dot(base.transform.right, collision.relativeVelocity.normalized));
			magnitude *= Mathf.Lerp(1f, 1.33f, t);
			if (magnitude >= 4f)
			{
				StartCoroutine(CreateSpark(magnitude, collision.contacts[0].point));
			}
		}
	}

	public void ApplyExplosionForceAndDamage(float appliedExplosionForce, Vector3 forceDirection)
	{
		float arg = appliedExplosionForce * 1E-06f;
		CarDamaged?.Invoke(arg, forceDirection);
	}

	private IEnumerator CreateSpark(float collisionForce, Vector3 pos)
	{
		for (int i = 0; i < sparkFrameDelay; i++)
		{
			yield return null;
		}
		float t = Mathf.InverseLerp(4f, 15f, collisionForce);
		if (UnityEngine.Random.Range(0, 100) < 90)
		{
			float radius = Mathf.Lerp(20f, 40f, t);
			int num = Physics.OverlapSphereNonAlloc(pos, radius, overlapColliders, LayerMask.GetMask("Hazmat"));
			for (int j = 0; j < num; j++)
			{
				overlapColliders[j].GetComponentInParent<ICargoReaction>()?.TryIgniteExternally(ignitionStrength);
			}
		}
	}
}
