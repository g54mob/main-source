using System.Collections;
using Assets.Scripts.Flight.AI.ControlFunctions;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AiCsTestFlyability : AiControlSystem
	{
		private const float DistToTargetForSuccess = 200f;

		public bool DoneTestingFlyability { get; private set; }

		public AiCsTestFlyability()
		{
			DoneTestingFlyability = false;
		}

		public override void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			base.Initialize(aiControlledAircraft);
			base.AiControlledAircraft.UseWaterAvoidance = false;
			base.AiControlledAircraft.UseGroundAvoidance = true;
			base.AiControlledAircraft.SetTarget(base.AiControlledAircraft.transform.position - base.AiControlledAircraft.AiAircraftScript.OrientedCenterOfMassRigidBodies.forward * 4000f + Vector3.down * 200f, mainTarget: true);
			SwitchActiveControlFunction(new AiCfFlyToLocation());
			base.AiControlledAircraft.StartCoroutine(CheckForUnflyable());
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.AiControlledAircraft.DistanceToTarget < 200f)
			{
				DoneTestingFlyability = true;
				base.AiControlledAircraft.AiAircraftInfo.AircraftIsFylable = true;
				base.AiControlledAircraft.AiAircraftInfo.Save();
			}
		}

		private IEnumerator CheckForUnflyable()
		{
			yield return new WaitForSeconds(30f);
			if (base.AiControlledAircraft.CurrentControlSystem != this)
			{
				yield break;
			}
			if (base.AiControlledAircraft.ClosingSpeed < 0f)
			{
				DoneTestingFlyability = true;
				base.AiControlledAircraft.AiAircraftInfo.AircraftIsFylable = false;
				base.AiControlledAircraft.AiAircraftInfo.Save();
				yield break;
			}
			yield return new WaitForSeconds(60f);
			if (base.AiControlledAircraft.CurrentControlSystem == this)
			{
				DoneTestingFlyability = true;
				base.AiControlledAircraft.AiAircraftInfo.AircraftIsFylable = false;
				base.AiControlledAircraft.AiAircraftInfo.Save();
			}
		}
	}
}
