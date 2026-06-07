using RotaryHeart.Lib.PhysicsExtension;
using UnityEngine;

public class Physics3DDebugPreview : MonoBehaviour
{
	public enum PhysicsType
	{
		BoxSingle = 0,
		BoxAll = 1,
		BoxNonAlloc = 2,
		CapsuleSingle = 3,
		CapsuleAll = 4,
		CapsuleNonAlloc = 5,
		Line = 6,
		RaySingle = 7,
		RayAll = 8,
		RayNonAlloc = 9,
		SphereSingle = 10,
		SphereAll = 11,
		SphereNonAlloc = 12,
		CheckBox = 13,
		CheckCapsule = 14,
		CheckSphere = 15,
		OverlapBox = 16,
		OverlapBoxNonAlloc = 17,
		OverlapCapsule = 18,
		OverlapCapsuleNonAlloc = 19,
		OverlapSphere = 20,
		OverlapSphereNonAlloc = 21
	}

	public PhysicsType castType;

	public PreviewCondition preview = PreviewCondition.Editor;

	public CastDrawType castDrawType;

	public float drawDuration;

	public Color hitColor = Color.green;

	public Color noHitColor = Color.red;

	public bool useRay;

	public float distance = 5f;

	private RaycastHit[] results = new RaycastHit[5];

	private Collider[] colliderResults = new Collider[5];

	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 forward = base.transform.forward;
		Vector3 vector = position + forward * distance;
		Ray ray = new Ray(position, forward);
		switch (castType)
		{
		case PhysicsType.BoxSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics.BoxCast(position, Vector3.one, forward, base.transform.rotation, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.BoxAll:
			RotaryHeart.Lib.PhysicsExtension.Physics.BoxCastAll(position, Vector3.one, forward, base.transform.rotation, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.BoxNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics.BoxCastNonAlloc(position, Vector3.one, forward, results, base.transform.rotation, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CapsuleSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics.CapsuleCast(position - base.transform.up * 0.5f, position + base.transform.up * 0.5f, 1f, forward, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CapsuleAll:
			RotaryHeart.Lib.PhysicsExtension.Physics.CapsuleCastAll(position - base.transform.up * 0.5f, position + base.transform.up * 0.5f, 1f, forward, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CapsuleNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics.CapsuleCastNonAlloc(position - base.transform.up * 0.5f, position + base.transform.up * 0.5f, 1f, forward, results, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.Line:
			RotaryHeart.Lib.PhysicsExtension.Physics.Linecast(position, vector, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.RaySingle:
			if (useRay)
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.Raycast(ray, distance, preview, drawDuration, hitColor, noHitColor);
			}
			else
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.Raycast(position, forward, distance, preview, drawDuration, hitColor, noHitColor);
			}
			break;
		case PhysicsType.RayAll:
			if (useRay)
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.RaycastAll(ray, distance, preview, drawDuration, hitColor, noHitColor);
			}
			else
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.RaycastAll(position, forward, distance, preview, drawDuration, hitColor, noHitColor);
			}
			break;
		case PhysicsType.RayNonAlloc:
			if (useRay)
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.RaycastNonAlloc(ray, results, distance, preview, drawDuration, hitColor, noHitColor);
			}
			else
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.RaycastNonAlloc(position, forward, results, distance, preview, drawDuration, hitColor, noHitColor);
			}
			break;
		case PhysicsType.SphereSingle:
			if (useRay)
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.SphereCast(ray, 1f, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			}
			else
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.SphereCast(position, 1f, forward, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			}
			break;
		case PhysicsType.SphereAll:
			if (useRay)
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.SphereCastAll(ray, 1f, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			}
			else
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.SphereCastAll(position, 1f, forward, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			}
			break;
		case PhysicsType.SphereNonAlloc:
			if (useRay)
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.SphereCastNonAlloc(ray, 1f, results, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			}
			else
			{
				RotaryHeart.Lib.PhysicsExtension.Physics.SphereCastNonAlloc(position, 1f, forward, results, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			}
			break;
		case PhysicsType.CheckBox:
			RotaryHeart.Lib.PhysicsExtension.Physics.CheckBox(position, Vector3.one * 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.CheckCapsule:
			RotaryHeart.Lib.PhysicsExtension.Physics.CheckCapsule(position, vector, 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.CheckSphere:
			RotaryHeart.Lib.PhysicsExtension.Physics.CheckSphere(position, 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapBox:
			RotaryHeart.Lib.PhysicsExtension.Physics.OverlapBox(position, Vector3.one * 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapBoxNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics.OverlapBoxNonAlloc(position, Vector3.one * 3f, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCapsule:
			RotaryHeart.Lib.PhysicsExtension.Physics.OverlapCapsule(position, vector, 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCapsuleNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics.OverlapCapsuleNonAlloc(position, vector, 3f, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapSphere:
			RotaryHeart.Lib.PhysicsExtension.Physics.OverlapSphere(position, 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapSphereNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics.OverlapSphereNonAlloc(position, 3f, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		}
	}
}
