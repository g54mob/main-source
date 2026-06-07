using UnityEngine;

public class SphereVolume : Volume
{
	public float radius = 50f;

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(base.transform.position, radius);
	}

	public override bool IsWithin(Vector3 point)
	{
		return Vector3.SqrMagnitude(point - base.transform.position) < radius * radius;
	}
}
