using Assets.Scripts.Craft;
using Assets.Scripts.Flight.AI.ControlFunctions;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Multiplayer;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AiCsFlyToLocationAndEngage : AiCsFlyToLocation<AiCfEngageWithGuns>
	{
		private TargetingSystem _targetingSystem;

		public void DestroyAllEnemies()
		{
			base.AiControlledAircraft.AiAircraftScript.TargetingSystem.AutoTargetEnemyPlayers = true;
		}

		public override bool GetSwitchNextTarget()
		{
			return false;
		}

		public override void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			base.Initialize(aiControlledAircraft);
			_targetingSystem = base.AiControlledAircraft.AiAircraftScript.TargetingSystem;
			_targetingSystem.TargetChanged += TargetChanged;
		}

		public override void OnLateUpdate()
		{
			base.OnLateUpdate();
			if (base.AiControlledAircraft.InputOverrideEnabled && _targetingSystem.CurrentTarget != null)
			{
				_targetingSystem.Mode = ((_targetingSystem.CurrentTarget.TargetType == TargetType.AirAndGround || _targetingSystem.CurrentTarget.TargetType == TargetType.Air) ? TargetingSystem.TargetingSystemMode.AirToAir : TargetingSystem.TargetingSystemMode.AirToGround);
				_targetingSystem.AutoSelectWeapon();
			}
		}

		public override void Unload()
		{
			base.Unload();
			if (_targetingSystem != null)
			{
				_targetingSystem.TargetChanged -= TargetChanged;
			}
		}

		private void TargetChanged(object sender, TargetingSystem.TargetChangedEventArgs e)
		{
			Target target = e.Target;
			AircraftScript aircraftScript = (target as PlayerTarget)?.Player?.Aircraft;
			if (aircraftScript != null)
			{
				base.AiControlledAircraft.SetTarget(aircraftScript, mainTarget: true);
			}
			else if (target != null)
			{
				base.AiControlledAircraft.SetTarget(target.Position, mainTarget: true);
			}
			else
			{
				base.AiControlledAircraft.SetTarget((Rigidbody)null, true);
			}
		}
	}
}
