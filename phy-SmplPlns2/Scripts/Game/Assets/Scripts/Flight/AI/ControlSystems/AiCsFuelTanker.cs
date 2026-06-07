using Assets.Scripts.Craft;
using Assets.Scripts.Flight.AI.ControlFunctions;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AiCsFuelTanker : AiControlSystem
	{
		public const float SpeedLowerRange = 55f;

		public const float SpeedUpperRange = 125f;

		private const int CutoffActivationGroup = 8;

		private const float CutoffFuelPercent = 0.1f;

		private AiCfMaintainAltitude _altHold = new AiCfMaintainAltitude();

		private AiCfLevelWings _wingLevel = new AiCfLevelWings();

		public float TargetAltitude
		{
			get
			{
				return _altHold.TargetAltitude;
			}
			set
			{
				_altHold.TargetAltitude = value;
			}
		}

		public float TargetRoll
		{
			get
			{
				return _wingLevel.TargetRoll;
			}
			set
			{
				_wingLevel.TargetRoll = value;
			}
		}

		public float TargetSpeed { get; set; }

		public override float GetRoll()
		{
			_wingLevel.TargetRoll = TargetRoll;
			return _wingLevel.GetRoll();
		}

		public override float GetThrottle()
		{
			return Mathf.InverseLerp(55f, 125f, TargetSpeed);
		}

		public override void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			base.Initialize(aiControlledAircraft);
			SwitchActiveControlFunction(_altHold);
			_wingLevel.Initialize(this);
		}

		public override void OnFixedUpdate()
		{
			base.OnFixedUpdate();
			AircraftScript aiAircraftScript = base.AiControlledAircraft.AiAircraftScript;
			if (aiAircraftScript.Fuel / aiAircraftScript.InitialFuel > 0.1f != aiAircraftScript.Controls.GetActivationState(8))
			{
				aiAircraftScript.Controls.ActivateGroup(7);
			}
		}
	}
}
