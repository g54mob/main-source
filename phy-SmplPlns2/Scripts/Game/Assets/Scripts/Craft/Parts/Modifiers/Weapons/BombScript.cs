using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events;
using Assets.Scripts.Environment.Terrain;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class BombScript : ExplosiveWeaponScriptBase<BombData>, IBomb, IWeapon, IVariableOutput
	{
		private float _blastForceScale = 1f;

		private SimpleGuidanceSystem _guidanceSystem;

		private TerrainTunnelingPreventionScript _tunnelMaster;

		public override WeaponFunction Function => WeaponFunction.AirToSurface;

		public override bool IsArmed
		{
			get
			{
				if (!base.PartScript.Aircraft.DisableBombs)
				{
					return base.IsArmed;
				}
				return false;
			}
		}

		public bool LaunchedViaDetacher { get; set; }

		public override TargetingStyle TargetingStyle => base.Modifier.TargetingStyle;

		public override WeaponType Type => WeaponType.Bomb;

		[VariableOutput("Fired")]
		private float VariableFired
		{
			get
			{
				if (!Fired)
				{
					return 0f;
				}
				return 1f;
			}
		}

		public event EventHandler<BombExplodedEventArgs> Exploded;

		public BombScript()
			: base("BombExplosion")
		{
		}

		public override void OnDamaged(float damage, Vector3 position, Vector3 direction)
		{
			base.OnDamaged(damage, position, direction);
			if (Launched && damage > 10f)
			{
				Detonate(Vector3.up);
			}
		}

		public void ScaleBlastForce(float scale)
		{
			_blastForceScale *= scale;
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
			}
		}

		protected override void OnExplode(Rigidbody responsibleBody, Vector3? impactDirection, Vector3 blastDirection, ExplosiveWeaponImpactType impactType, ITarget target)
		{
			if (_guidanceSystem != null && CurrentTarget != null && CurrentTarget.Target != null)
			{
				Debug.Log($"Bomb exploded {(base.transform.position - CurrentTarget.Target.Position).magnitude:n1}m from target.");
			}
			FlightSceneScript.Instance.CreateExplosion(base.ExplosionPrefabName, base.transform.position, base.Modifier.ExplosionScale * _blastForceScale, blastDirection, base.PartScript.Aircraft.NetworkAircraft?.PlayerId, impactDirection, impactType);
			this.Exploded?.Invoke(this, new BombExplodedEventArgs(this, blastDirection, impactType));
		}

		protected override void OnFire()
		{
			if (!Launched)
			{
				DisconnectPart();
			}
			Fired = true;
			base.PartScript.Body.RigidBody.drag = 0.05f;
			base.PartScript.Aircraft.TargetingSystem.OnBombFired(this, CurrentTarget?.Target);
			if (CurrentTarget?.Target is LaserTarget target && base.Modifier.IsLaserGuided)
			{
				_guidanceSystem = new SimpleGuidanceSystem(base.RigidBody, target, new SimpleGuidanceSystem.SimpleGuidanceConfiguration
				{
					RotationSpeed = 10f,
					GuidanceDelay = 1f,
					MaxLift = 1000f,
					LiftScale = 0.01f * base.RigidBody.mass,
					AltitudeBoostMax = 500f,
					AltitudeBoostMin = 0f,
					AltitudeBoostRange = 5000f
				});
			}
			FinScript[] componentsInChildren = GetComponentsInChildren<FinScript>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ExtendFins();
			}
		}

		protected override void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			base.OnFixedUpdate(in frame);
			if (!Launched)
			{
				return;
			}
			if (!Fired && LaunchedViaDetacher)
			{
				Fire(base.PartScript.Aircraft.TargetingSystem.CurrentTrackedTarget);
			}
			if (base.PartScript.Body.Joints.Count == 0)
			{
				if (_guidanceSystem != null)
				{
					_guidanceSystem.Update();
				}
				else
				{
					AdjustFreeFallHeading();
				}
			}
		}

		protected override void OnStart(in CraftUpdateFrameData frame)
		{
			base.OnStart(in frame);
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				CheckIfAntiTunnelingShouldBeEnabled();
			}
		}

		private void CheckIfAntiTunnelingShouldBeEnabled()
		{
			if (base.PartScript.Aircraft.RemoteAircraft)
			{
				return;
			}
			List<BodyJoint> joints = base.PartScript.Body.Joints;
			if ((joints == null || joints.Count == 0) && _tunnelMaster == null)
			{
				_tunnelMaster = TerrainTunnelingPreventionScript.Create(base.PartScript, base.gameObject, delegate(Vector3 normal)
				{
					Detonate(normal);
				});
			}
		}

		private void OnAircraftStructureChanged()
		{
			CheckIfAntiTunnelingShouldBeEnabled();
		}
	}
}
