using UnityEngine;

namespace HQFPSTemplate
{
	public struct DamageInfo
	{
		public float Delta { get; set; }

		public Entity Source { get; set; }

		public DamageType DamageType { get; set; }

		public Transform HitObject { get; set; }

		public Vector3 HitPoint { get; set; }

		public Vector3 HitDirection { get; set; }

		public float HitImpulse { get; set; }

		public Vector3 HitNormal { get; set; }

		public DamageInfo(float delta, Entity source = null, Transform hitObject = null)
		{
			Delta = delta;
			DamageType = DamageType.Generic;
			HitPoint = Vector3.zero;
			HitDirection = Vector3.zero;
			HitImpulse = 0f;
			HitNormal = Vector3.zero;
			Source = source;
			HitObject = hitObject;
		}

		public DamageInfo(float delta, DamageType damageType, Entity source = null, Transform hitObject = null)
		{
			Delta = delta;
			DamageType = damageType;
			HitPoint = Vector3.zero;
			HitDirection = Vector3.zero;
			HitImpulse = 0f;
			HitNormal = Vector3.zero;
			Source = source;
			HitObject = hitObject;
		}

		public DamageInfo(float delta, Vector3 hitPoint, Vector3 hitDirection, float hitImpulse, Entity source = null, Transform hitObject = null)
		{
			Delta = delta;
			DamageType = DamageType.Generic;
			HitPoint = hitPoint;
			HitDirection = hitDirection;
			HitImpulse = hitImpulse;
			HitNormal = Vector3.zero;
			Source = source;
			HitObject = hitObject;
		}

		public DamageInfo(float delta, DamageType damageType, Vector3 hitPoint, Vector3 hitDirection, float hitImpulse, Entity source = null, Transform hitObject = null)
		{
			Delta = delta;
			DamageType = damageType;
			HitPoint = hitPoint;
			HitDirection = hitDirection;
			HitImpulse = hitImpulse;
			HitNormal = Vector3.zero;
			Source = source;
			HitObject = hitObject;
		}

		public DamageInfo(float delta, Vector3 hitPoint, Vector3 hitDirection = default(Vector3), float hitImpulse = 0f, Vector3 hitNormal = default(Vector3), Entity source = null, Transform hitObject = null)
		{
			Delta = delta;
			DamageType = DamageType.Generic;
			HitPoint = hitPoint;
			HitDirection = hitDirection;
			HitImpulse = hitImpulse;
			HitNormal = hitNormal;
			Source = source;
			HitObject = hitObject;
		}

		public DamageInfo(float delta, DamageType damageType, Vector3 hitPoint = default(Vector3), Vector3 hitDirection = default(Vector3), float hitImpulse = 0f, Vector3 hitNormal = default(Vector3), Entity source = null, Transform hitObject = null)
		{
			Delta = delta;
			DamageType = damageType;
			HitPoint = hitPoint;
			HitDirection = hitDirection;
			HitImpulse = hitImpulse;
			HitNormal = hitNormal;
			Source = source;
			HitObject = hitObject;
		}
	}
}
