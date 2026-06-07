using System.Collections.Generic;
using ModApi.Common.Extensions;
using ModApi.Common.Physics;
using ModApi.Craft;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using UnityEngine;

namespace Assets.Scripts.Levels.Requirements
{
	public class TerrainContactRequirement : LevelRequirement
	{
		public enum ContactType
		{
			AvoidImpact = 0,
			CraftImpact = 1,
			CraftLanded = 2
		}

		private Dictionary<IBodyScript, CollisionNotifier> _collisionNotifiers;

		private bool _isLanding;

		private double _timeHeldStill;

		public string ContactTarget { get; set; }

		public bool IncludeWaterAsContact { get; set; }

		public ContactType RequiredContactType { get; set; }

		public TerrainContactRequirement(ILevel level, ContactType requiredContactType, string contactTarget, bool includeWaterAsContact = true)
			: base(level)
		{
			_collisionNotifiers = new Dictionary<IBodyScript, CollisionNotifier>();
			RequiredContactType = requiredContactType;
			IncludeWaterAsContact = includeWaterAsContact;
			base.Level.PlayerCraft.CraftStructureChanged += PrepareBodiesForCollision;
			PrepareBodiesForCollision();
			ContactTarget = contactTarget;
			UpdateName();
			if (requiredContactType == ContactType.AvoidImpact)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			if (base.Level.PlayerCraft.FlightData.AltitudeAboveGroundLevel < 1.0)
			{
				OnContacted();
			}
			float num = 0.5f;
			if (IncludeWaterAsContact || RequiredContactType == ContactType.CraftLanded)
			{
				foreach (KeyValuePair<IBodyScript, CollisionNotifier> collisionNotifier in _collisionNotifiers)
				{
					if (collisionNotifier.Key.Disconnected || collisionNotifier.Key.CraftScript != base.Level.PlayerCraft)
					{
						continue;
					}
					if (IncludeWaterAsContact)
					{
						IBodyScript key = collisionNotifier.Key;
						if (key != null && key.WaterPhysics.IsInWater)
						{
							num = 6f;
							OnContacted();
						}
					}
					if (RequiredContactType == ContactType.CraftLanded && collisionNotifier.Key.CollidingWithTerrain)
					{
						_isLanding = true;
					}
				}
			}
			if (!_isLanding)
			{
				return;
			}
			if (base.Level.PlayerCraft.PrimaryCommandPod?.Part?.IsDestroyed ?? true)
			{
				base.Status = LevelRequirementStatus.Fail;
				return;
			}
			if (base.Level.PlayerCraft.SurfaceVelocity.magnitude <= num)
			{
				_timeHeldStill += base.Level.FlightScene.TimeManager.DeltaTime;
			}
			else
			{
				_timeHeldStill = 0.0;
			}
			if (_timeHeldStill > 1.0)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
		}

		private void OnBodyCollisionEnter(IBodyScript body, Collision collision)
		{
			if (base.DependenciesCurrentlySatisfied && !body.Disconnected && body.CraftScript == base.Level.PlayerCraft && (collision.gameObject.layer & 0x1A) != 0)
			{
				OnContacted();
			}
		}

		private void OnContacted()
		{
			switch (RequiredContactType)
			{
			case ContactType.AvoidImpact:
				base.Status = LevelRequirementStatus.Fail;
				break;
			case ContactType.CraftImpact:
				base.Status = LevelRequirementStatus.Pass;
				break;
			default:
				_isLanding = true;
				break;
			}
		}

		private void PrepareBodiesForCollision()
		{
			IBodyScript[] componentsInChildren = base.Level.PlayerCraft.Transform.GetComponentsInChildren<IBodyScript>();
			foreach (IBodyScript body in componentsInChildren)
			{
				if (!_collisionNotifiers.ContainsKey(body) && !body.Disconnected)
				{
					CollisionNotifier collisionNotifier = body.GameObject.AddMissingComponent<CollisionNotifier>();
					collisionNotifier.CollisionEnter.AddListener(delegate(Collision x)
					{
						OnBodyCollisionEnter(body, x);
					});
					_collisionNotifiers.Add(body, collisionNotifier);
				}
			}
		}

		private void UpdateName()
		{
			switch (RequiredContactType)
			{
			case ContactType.AvoidImpact:
				base.Name = $"Avoid impact with {ContactTarget}";
				break;
			case ContactType.CraftImpact:
				base.Name = $"Impact {ContactTarget}";
				break;
			default:
				base.Name = $"Land on {ContactTarget}";
				break;
			}
		}
	}
}
