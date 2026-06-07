using UnityEngine;

public class PropScore
{
	public Prop nearby;

	public float dist;

	public float viewAngle;

	public static bool debug = false;

	public static readonly int raycastIgnoreLayerMaskAll = -1;

	private static RaycastHit[] raycastHits = new RaycastHit[1] { default(RaycastHit) };

	public bool valid
	{
		get
		{
			return nearby != null;
		}
	}

	public void Reset()
	{
		nearby = null;
		dist = 0f;
		viewAngle = 0f;
	}

	public void CopyFrom(PropScore other)
	{
		nearby = other.nearby;
		dist = other.dist;
		viewAngle = other.viewAngle;
	}

	public bool IsBetterThan(PropScore other)
	{
		if (!valid)
		{
			return false;
		}
		if (!other.valid)
		{
			return true;
		}
		if (viewAngle < other.viewAngle)
		{
			return true;
		}
		if (dist < other.dist)
		{
			return true;
		}
		return false;
	}

	public void Set(Prop nearby_, Matrix4x4 nearbyMatrix, Vector3 shoulderPosition, float reachRadius, Camera camera, float viewAngleMax, int raycastIgnoreLayerMask)
	{
		Reset();
		if (nearby_ == null)
		{
			return;
		}
		Vector3 t = nearbyMatrix.GetT();
		if ((t - camera.transform.position).sqrMagnitude < 0.16000001f)
		{
			return;
		}
		dist = Vector3.Distance(t, shoulderPosition);
		if (dist > reachRadius)
		{
			return;
		}
		viewAngle = Quaternion.Angle(camera.transform.rotation, Quaternion.LookRotation(t - camera.transform.position));
		if (!(viewAngle > viewAngleMax))
		{
			Vector3 vector = t;
			if (raycastIgnoreLayerMask == raycastIgnoreLayerMaskAll || Physics.SphereCastNonAlloc(shoulderPosition, 0.05f, (vector - shoulderPosition).normalized, raycastHits, Mathf.Min(reachRadius, Vector3.Distance(shoulderPosition, vector)) - 0.05f, ~raycastIgnoreLayerMask) <= 0)
			{
				nearby = nearby_;
			}
		}
	}
}
