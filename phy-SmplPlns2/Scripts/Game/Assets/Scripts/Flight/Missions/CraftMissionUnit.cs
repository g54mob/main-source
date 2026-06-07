using Assets.Scripts.Craft;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.StartLocations;
using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public class CraftMissionUnit : MissionUnit
	{
		private AiControlledAircraftScript _ai;

		private string _craftID;

		private bool _hostile;

		private ushort _teamId;

		private IReferenceFrame _referenceFrame;

		public AircraftScript CraftScript { get; private set; }

		public override bool IsDead => CraftScript?.CriticallyDamaged ?? false;

		public override Vector3 Position
		{
			get
			{
				if (CraftScript != null)
				{
					return _referenceFrame.LocalToWorld(CraftScript.Position);
				}
				return base.Position;
			}
			set
			{
				if (CraftScript != null)
				{
					CraftScript.Position = _referenceFrame.WorldToLocal(value);
				}
				base.Position = value;
			}
		}

		public override Vector3 Velocity
		{
			get
			{
				if (CraftScript != null)
				{
					return CraftScript.Velocity;
				}
				return base.Position;
			}
			set
			{
				if (CraftScript != null)
				{
					CraftScript.SetVelocity(value);
				}
				base.Velocity = value;
			}
		}

		public CraftMissionUnit(AircraftScript craftScript, IReferenceFrame referenceFrame)
		{
			_referenceFrame = referenceFrame;
			CraftScript = craftScript;
			IsSpawned = true;
			_teamId = 3;
		}

		public CraftMissionUnit(string craftID, bool hostile, ReferenceFrame referenceFrame)
		{
			_craftID = craftID;
			_hostile = hostile;
			_referenceFrame = referenceFrame;
			_teamId = (ushort)(hostile ? 1 : 3);
		}

		public override void Destroy()
		{
			if (CraftScript != null && _ai != null)
			{
				AiManagerScript.Instance.DespawnAircraft(_ai, 0f);
				_ai = null;
				CraftScript = null;
			}
		}

		public override void Spawn()
		{
			base.Spawn();
			SpawnPlaneBasic(_craftID, _hostile, _teamId, AiCsSandboxAirTraffic.AiMode.Default);
		}

		public void SpawnPlaneBasic(string id, bool hostile, ushort teamId, AiCsSandboxAirTraffic.AiMode mode)
		{
			StartLocation location = new StartLocation(Position, Vector3.zero, 0f, null);
			AiManagerScript.Instance.SpawnSandboxAi(id, autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, mode, hostile, teamId, delegate(AiControlledAircraftScript ai)
			{
				_ai = ai;
				_ai.CurrentControlSystem.ControlFunction.RecheckLandingGearPosition();
				CraftScript = _ai.AiAircraftScript;
			});
		}
	}
}
