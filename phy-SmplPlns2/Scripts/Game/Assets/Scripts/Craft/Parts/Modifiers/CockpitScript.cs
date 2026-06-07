using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Environment.Terrain;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CockpitScript : PartModifierScript, IVariableOutput
	{
		private CockpitData _cockpit;

		private PartScript _part;

		private TerrainTunnelingPreventionScript _tunnelMaster;

		public CockpitData Cockpit => _cockpit;

		public bool PilotCanEnter { get; private set; }

		public bool PrimaryCockpit
		{
			get
			{
				return _cockpit.PrimaryCockpit;
			}
			set
			{
				_cockpit.PrimaryCockpit = value;
				if (value && _part != null)
				{
					_part.Aircraft.UpdateMainCockpit(_part);
				}
			}
		}

		[VariableOutput("Heading Angle")]
		private float Heading
		{
			get
			{
				Vector3 forward = base.transform.forward;
				return Mathf.Atan2(forward.x, forward.z) * 57.29578f % 360f;
			}
		}

		[VariableOutput("Pitch Angle")]
		private float PitchAngle => Mathf.DeltaAngle(0f, Mathf.Asin(base.transform.forward.y) * 57.29578f);

		[VariableOutput("Pitch Rate")]
		private float PitchRate => base.transform.InverseTransformDirection(base.PartScript.Body.RigidBody.angularVelocity).x * 57.29578f;

		[VariableOutput("Longitude")]
		private float PosX { get; set; }

		[VariableOutput("Altitude")]
		private float PosY { get; set; }

		[VariableOutput("Latitude")]
		private float PosZ { get; set; }

		[VariableOutput("Roll Angle")]
		private float RollAngle => Mathf.DeltaAngle(0f, base.transform.eulerAngles.z);

		[VariableOutput("Roll Rate")]
		private float RollRate => base.transform.InverseTransformDirection(base.PartScript.Body.RigidBody.angularVelocity).z * 57.29578f;

		[VariableOutput("Speed")]
		private float Speed => base.PartScript.Body.RigidBody.GetPointVelocity(base.transform.position).magnitude;

		[VariableOutput("Yaw Rate")]
		private float YawRate => base.transform.InverseTransformDirection(base.PartScript.Body.RigidBody.angularVelocity).y * 57.29578f;

		public void Initialize(CockpitData cockpit)
		{
			_cockpit = cockpit;
			PilotCanEnter = PrimaryCockpit;
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
		}

		private void CheckIfAntiTunnelingShouldBeEnabled()
		{
			if (!base.PartScript.Aircraft.RemoteAircraft)
			{
				List<BodyJoint> joints = base.PartScript.Body.Joints;
				if ((joints == null || joints.Count == 0) && _tunnelMaster == null)
				{
					_tunnelMaster = TerrainTunnelingPreventionScript.Create(base.PartScript, base.gameObject, null);
				}
			}
		}

		private void EjectPilot()
		{
			FlightScenePlayer player = base.PartScript.Aircraft.Player;
			if (player != null && player.IsPrimaryLocal)
			{
				player.ExitAircraft(null, 50f);
			}
		}

		private void OnAircraftStructureChanged()
		{
			CheckIfAntiTunnelingShouldBeEnabled();
			if (PrimaryCockpit && base.PartScript.Body.PartGroups.Count <= 1)
			{
				List<BodyJoint> joints = base.PartScript.Body.Joints;
				if ((joints == null || joints.Count == 0) && PilotCanEnter)
				{
					PilotCanEnter = false;
					EjectPilot();
				}
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			_part = base.transform.GetComponentInParent<PartScript>();
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				CheckIfAntiTunnelingShouldBeEnabled();
			}
		}

		void IVariableOutput.UpdateOutputs()
		{
			Vector3 vector = base.transform.position + GameWorld.Instance.FloatingOriginOffset;
			PosX = vector.x;
			PosY = vector.y;
			PosZ = vector.z;
			_ = base.transform.forward;
		}
	}
}
