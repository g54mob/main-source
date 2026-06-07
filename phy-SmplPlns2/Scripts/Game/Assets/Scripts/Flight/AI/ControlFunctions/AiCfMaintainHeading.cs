using Assets.Scripts.Flight.AI.ControlSystems;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfMaintainHeading : AiControlFunction
	{
		private AiCfLevelWings _wingLeveler;

		public bool LevelWings { get; set; }

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
			return 0f - Vector3.Dot(_aiControlledAircraft.VecToTarget.normalized, _aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.up);
		}

		public override float GetRoll()
		{
			return _wingLeveler.GetRoll();
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
			_wingLeveler = new AiCfLevelWings();
			_wingLeveler.Initialize(aiControlSystem);
		}
	}
}
