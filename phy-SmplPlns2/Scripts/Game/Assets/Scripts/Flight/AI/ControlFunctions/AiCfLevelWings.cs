using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfLevelWings : AiControlFunction
	{
		public float TargetRoll { get; set; }

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
			return 0f;
		}

		public override float GetRoll()
		{
			Transform orientedCenterOfMassRigidBodies = _aiControlSystem.AiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies;
			return Vector3.Dot(Quaternion.AngleAxis(TargetRoll, orientedCenterOfMassRigidBodies.forward) * Vector3.up, orientedCenterOfMassRigidBodies.right);
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
	}
}
