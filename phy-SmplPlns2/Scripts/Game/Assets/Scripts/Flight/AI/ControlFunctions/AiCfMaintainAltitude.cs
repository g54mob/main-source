using Assets.Scripts.Flight.AI.ControlSystems;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfMaintainAltitude : AiControlFunction
	{
		private const float PitchIntegralPower = 0.001f;

		private float _pitchIntegral;

		public float TargetAltitude { get; set; }

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
			return false;
		}

		public override float GetPitch()
		{
			Transform orientedCenterOfMassRigidBodies = _aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies;
			float num = TargetAltitude - _aiControlledAircraft.AiAircraftScript.Altitude;
			if (Mathf.Abs(num) < 100f)
			{
				_pitchIntegral += num * Time.deltaTime * 0.001f;
			}
			else
			{
				num = Mathf.Clamp(num, -100f, 100f);
			}
			Vector3 forward = orientedCenterOfMassRigidBodies.forward;
			forward.y = 0f;
			forward.Normalize();
			return 0f - Vector3.Dot((new Vector3(0f, num + _pitchIntegral, 0f) + forward * 100f).normalized, orientedCenterOfMassRigidBodies.up);
		}

		public override float GetRoll()
		{
			return 0f;
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
			return 0f;
		}

		public override float GetYaw()
		{
			return 0f;
		}

		public override void Initialize(AiControlSystem aiControlSystem)
		{
			base.Initialize(aiControlSystem);
			TargetAltitude = _aiControlledAircraft.AiAircraftScript.Altitude;
		}
	}
}
