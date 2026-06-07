using System;
using Assets.Scripts.Flight.AI.ControlSystems;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfFlyToLocation : AiControlFunction
	{
		public float? AgressivenessOverride;

		private bool _previousLandingGearDown = true;

		public bool IsSufficientlyLaterallyOriented
		{
			get
			{
				float num = 10f;
				float distanceToTarget = _aiControlledAircraft.DistanceToTarget;
				if (distanceToTarget < 1000f)
				{
					num = 1000f / distanceToTarget * 10f;
				}
				Vector3 forward = _aiControlSystem.AiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.forward;
				Vector3 vector = new Vector3(forward.x, 0f, forward.z);
				Vector3 to = new Vector3(_aiControlledAircraft.VecToTarget.x, 0f, _aiControlledAircraft.VecToTarget.z);
				return Vector3.Angle(vector, to) < num;
			}
		}

		public bool IsSufficientlyOrientedOverall
		{
			get
			{
				float num = 5f;
				return Vector3.Angle(_aiControlSystem.AiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.forward, _aiControlledAircraft.VecToTarget) < num;
			}
		}

		public float? SuggestedTargetLead { get; set; }

		public override float GetBrake()
		{
			return 0f;
		}

		public override bool GetFireGuns()
		{
			return false;
		}

		public override bool GetFireWeapons()
		{
			return false;
		}

		public override bool GetLandingGearDown()
		{
			bool flag = _previousLandingGearDown;
			if (_checkLandingGear || _previousLandingGearDown)
			{
				flag = _aiControlledAircraft.AiAircraftScript.AltitudeAgl < 20f;
				_checkLandingGear = false;
			}
			_previousLandingGearDown = flag;
			return flag;
		}

		public override float GetLeadTarget()
		{
			if (SuggestedTargetLead.HasValue)
			{
				return SuggestedTargetLead.Value;
			}
			return 1f;
		}

		public override float GetPitch()
		{
			if (_pitchAsThrottle.HasValue && _pitchAsThrottle.Value)
			{
				return GetThrottle();
			}
			if (_aiControlledAircraft.GoUpToAvoidWater)
			{
				Vector3 vecToTarget = _aiControlledAircraft.VecToTarget;
				Vector3 rhs = (new Vector3(vecToTarget.x, 0f, vecToTarget.z).normalized + Vector3.up) / 2f;
				return 0f - Vector3.Dot(_aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.up, rhs);
			}
			float result = 0f;
			if (!Utilities.CompareFloats(_aiControlledAircraft.TargetRelativePosition.x, 0f))
			{
				result = 0f - Vector3.Dot(_aiControlledAircraft.VecToTarget.normalized, _aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.up);
			}
			return result;
		}

		public override float GetRoll()
		{
			if (_aiControlledAircraft.OrientedTargetTransform == null)
			{
				return 0f;
			}
			if (_aiControlledAircraft.GoUpToAvoidWater)
			{
				Vector3 normalized = Vector3.RotateTowards(_aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.forward, Vector3.up, MathF.PI / 2f, float.MaxValue).normalized;
				return Vector3.Dot(_aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.right, normalized);
			}
			Vector3 currentTargetPosition = _aiControlledAircraft.CurrentTargetPosition;
			Vector3 position = _aiControlledAircraft.AiRigidbody.transform.position;
			float distanceToTarget = _aiControlledAircraft.DistanceToTarget;
			Vector3 linearVelocity = _aiControlledAircraft.AiRigidbody.linearVelocity;
			Vector3 vector = position + _aiControlledAircraft.AiRigidbody.linearVelocity;
			Vector3 vecToTarget = _aiControlledAircraft.VecToTarget;
			float num = 1f;
			if (!AgressivenessOverride.HasValue)
			{
				float num2 = distanceToTarget / _aiControlledAircraft.ClosingSpeed;
				num2 = ((num2 < 0f) ? 300f : num2);
				float num3 = Mathf.Clamp01(Mathf.Abs(_aiControlledAircraft.ClosingSpeed) / 45f);
				float num4 = Mathf.Clamp01(Vector3.Angle(vecToTarget, linearVelocity.normalized) / 30f);
				float num5 = Mathf.Clamp01((num2 > 3f) ? 0f : (1f - num2 / 3f));
				float num6 = Mathf.Clamp01((distanceToTarget > 1000f) ? 0f : Mathf.Clamp01(distanceToTarget / 25f));
				float num7 = 0.5f;
				float num8 = 1f;
				float num9 = 0.25f;
				float num10 = 1f;
				float num11 = num7 + num8 + num9 + num10;
				num = Mathf.Clamp01((num3 * num7 + num4 * num8 + num6 * num9 + num5 * num10) / num11);
			}
			else
			{
				num = AgressivenessOverride.Value;
			}
			Vector3 a = position - _aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.up * (20f * (1f - num));
			Vector3 vector2 = currentTargetPosition + _aiControlledAircraft.OrientedTargetTransform.up * (20f * (1f - num));
			Vector3 vector3 = vector + _aiControlledAircraft.OrientedTargetTransform.up * 100f;
			Vector3 vector4 = vector2 - vector3;
			Vector3 b = vector3 + vector4 * num;
			return Vector3.Dot(-new Plane(a, b, vector).normal, _aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.up);
		}

		public override bool GetSwitchNextTarget()
		{
			return false;
		}

		public override bool GetSwitchNextWeapon()
		{
			return false;
		}

		public override bool GetSwitchPrevTarget()
		{
			return false;
		}

		public override bool GetSwitchPrevWeapon()
		{
			return false;
		}

		public override float GetThrottle()
		{
			return 1f;
		}

		public override float GetVtol()
		{
			if (_vtolAsThrottle.HasValue && _vtolAsThrottle.Value)
			{
				return GetThrottle();
			}
			return 0f;
		}

		public override float GetYaw()
		{
			if (_yawAsTurnInput.HasValue)
			{
				return GetRoll();
			}
			return 0f;
		}

		public override void Initialize(AiControlSystem aiControlSystem)
		{
			base.Initialize(aiControlSystem);
		}

		public override void OnDrawGizmos()
		{
		}

		public override void OnFirstFrameLateUpdate()
		{
			base.OnFirstFrameLateUpdate();
		}

		public override void OnShowDebugInfo()
		{
			base.OnShowDebugInfo();
		}
	}
}
