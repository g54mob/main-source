using System.Collections;
using Assets.Scripts.Flight.AI.ControlSystems;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfTakeoff : AiControlFunction
	{
		private const float TakeoffSpeed = 67f;

		private bool _ascending;

		private float _metersToGainInAltitude;

		private AiCfFlyToLocation _orientToLocation;

		private float _startingAltitude;

		private Vector3 _takeoffTarget;

		private float _targetAltitude;

		private AiCfLevelWings _wingLeveler;

		public bool TakeoffComplete { get; private set; }

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

		public override float GetPitch()
		{
			return _orientToLocation.GetPitch();
		}

		public override float GetRoll()
		{
			return _orientToLocation.GetRoll();
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
			return GetRoll();
		}

		public override void Initialize(AiControlSystem aiControlSystem)
		{
			base.Initialize(aiControlSystem);
			_metersToGainInAltitude = 450f;
			TakeoffComplete = false;
			_wingLeveler = new AiCfLevelWings();
			_wingLeveler.Initialize(_aiControlSystem);
			_orientToLocation = new AiCfFlyToLocation();
			_orientToLocation.Initialize(_aiControlSystem);
			_orientToLocation.AgressivenessOverride = 0f;
			Transform orientedCenterOfMassRigidBodies = _aiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies;
			_takeoffTarget = orientedCenterOfMassRigidBodies.position + orientedCenterOfMassRigidBodies.forward * 5000f;
			_aiControlledAircraft.SetTarget(_takeoffTarget, mainTarget: false);
			_startingAltitude = _aiControlledAircraft.AiAircraftScript.Altitude;
			_targetAltitude = _aiControlledAircraft.AiAircraftScript.Altitude + _metersToGainInAltitude;
			_aiControlledAircraft.StartCoroutine(CheckForUnflyableAircraft());
		}

		public override bool GetLandingGearDown()
		{
			return _aiControlledAircraft.AiAircraftScript.AltitudeAgl < 30f;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (!_ascending && _aiControlledAircraft.AiAircraftScript.AirSpeed > 67f)
			{
				_takeoffTarget += Vector3.up * (_targetAltitude * 2f);
				_aiControlledAircraft.SetTarget(_takeoffTarget, mainTarget: false);
				_ascending = true;
			}
			if (_aiControlledAircraft.AiAircraftScript.Altitude > _targetAltitude)
			{
				TakeoffComplete = true;
			}
			else if (_aiControlledAircraft.DistanceToTargetOnHorizontalPlane <= 0f)
			{
				TakeoffComplete = true;
			}
		}

		private IEnumerator CheckForUnflyableAircraft()
		{
			yield return new WaitForSeconds(10f);
			if (!TakeoffComplete && _aiControlledAircraft.AiAircraftScript.Altitude < _startingAltitude + 30f)
			{
				AiManagerScript.MarkAircraftAsNotAbleToTakeOff(_aiControlledAircraft);
			}
		}
	}
}
