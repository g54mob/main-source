using RotaryHeart.Lib.PhysicsExtension;
using UnityEngine;

public class Physics2DDebugPreview : MonoBehaviour
{
	public enum PhysicsType
	{
		BoxSingle = 0,
		BoxAll = 1,
		BoxNonAlloc = 2,
		CapsuleSingle = 3,
		CapsuleAll = 4,
		CapsuleNonAlloc = 5,
		CircleSingle = 6,
		CircleAll = 7,
		CircleNonAlloc = 8,
		LineSingle = 9,
		LineAll = 10,
		LineNonAlloc = 11,
		RaySingle = 12,
		RayAll = 13,
		RayNonAlloc = 14,
		OverlapAreaSingle = 15,
		OverlapAreaAll = 16,
		OverlapAreaNonAlloc = 17,
		OverlapBox = 18,
		OverlapBoxAll = 19,
		OverlapBoxNonAlloc = 20,
		OverlapCapsule = 21,
		OverlapCapsuleAll = 22,
		OverlapCapsuleNonAlloc = 23,
		OverlapCircle = 24,
		OverlapCircleAll = 25,
		OverlapCircleNonAlloc = 26,
		OverlapPoint = 27,
		OverlapPointAll = 28,
		OverlapPointNonAlloc = 29
	}

	public PhysicsType castType;

	public PreviewCondition preview = PreviewCondition.Editor;

	public CastDrawType castDrawType;

	public float drawDuration;

	public Color hitColor = Color.green;

	public Color noHitColor = Color.red;

	public float distance = 5f;

	public float angle;

	public Vector3 capsuleSize = new Vector2(3f, 6f);

	public CapsuleDirection2D capsuleDirection;

	private RaycastHit2D[] results = new RaycastHit2D[5];

	private Collider2D[] colliderResults = new Collider2D[5];

	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 up = base.transform.up;
		Vector3 vector = position + up * distance;
		switch (castType)
		{
		case PhysicsType.BoxSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.BoxCast(position, Vector3.one * 2f, angle, base.transform.up, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.BoxAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.BoxCastAll(position, Vector3.one, angle, base.transform.up, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.BoxNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.BoxCastNonAlloc(position, Vector3.one, angle, base.transform.up, results, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CapsuleSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.CapsuleCast(position, capsuleSize, capsuleDirection, angle, base.transform.up, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CapsuleAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.CapsuleCastAll(position, capsuleSize, capsuleDirection, angle, base.transform.up, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CapsuleNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.CapsuleCastNonAlloc(position, capsuleSize, capsuleDirection, angle, base.transform.up, results, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CircleSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.CircleCast(position, 1f, base.transform.up, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CircleAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.CircleCastAll(position, 1f, base.transform.up, distance, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.CircleNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.CircleCastNonAlloc(position, 1f, base.transform.up, results, preview, drawDuration, hitColor, noHitColor, drawDepth: false, castDrawType);
			break;
		case PhysicsType.LineSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.Linecast(position, vector, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.LineAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.LinecastAll(position, vector, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.LineNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.LinecastNonAlloc(position, vector, results, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.RaySingle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.Raycast(position, up, distance, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.RayAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.RaycastAll(position, up, distance, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.RayNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.RaycastNonAlloc(position, up, results, distance, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapAreaSingle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapArea(position - Vector3.right * 3f + Vector3.up * 3f, position + Vector3.right * 3f - Vector3.up * 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapAreaAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapAreaAll(position - Vector3.right * 3f + Vector3.up * 3f, position + Vector3.right * 3f - Vector3.up * 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapAreaNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapAreaNonAlloc(position - Vector3.right * 3f + Vector3.up * 3f, position + Vector3.right * 3f - Vector3.up * 3f, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapBox:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapBox(position, Vector3.one * 6f, angle, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapBoxAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapBoxAll(position, Vector3.one * 6f, angle, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapBoxNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapBoxNonAlloc(position, Vector3.one * 6f, angle, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCapsule:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapCapsule(position, capsuleSize, capsuleDirection, angle, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCapsuleAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapCapsuleAll(position, capsuleSize, capsuleDirection, angle, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCapsuleNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapCapsuleNonAlloc(position, capsuleSize, capsuleDirection, angle, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCircle:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapCircle(position, 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCircleAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapCircleAll(position, 3f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapCircleNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapCircleNonAlloc(position, 3f, colliderResults, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapPoint:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapPoint(position, 6f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapPointAll:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapPointAll(position, 6f, preview, drawDuration, hitColor, noHitColor);
			break;
		case PhysicsType.OverlapPointNonAlloc:
			RotaryHeart.Lib.PhysicsExtension.Physics2D.OverlapPointNonAlloc(position, colliderResults, 6f, preview, drawDuration, hitColor, noHitColor);
			break;
		}
	}
}
