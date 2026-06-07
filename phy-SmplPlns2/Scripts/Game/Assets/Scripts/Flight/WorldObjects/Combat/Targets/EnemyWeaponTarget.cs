using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat.Targets
{
	public class EnemyWeaponTarget : Target
	{
		private bool _isDead;

		private Target _target;

		public AircraftScript Aircraft { get; private set; }

		public bool BeyondMaxRange { get; set; }

		public Collider Collider { get; private set; }

		public float Distance { get; set; }

		public override bool IsDead
		{
			get
			{
				if (!_isDead && !RigidBody.IsDead)
				{
					if (Aircraft != null)
					{
						return Aircraft.CriticallyDamaged;
					}
					return false;
				}
				return true;
			}
		}

		public ExclusiveLock Lock { get; private set; }

		public bool Occluded { get; set; }

		public override Vector3 Position
		{
			get
			{
				if (!(Collider != null))
				{
					return RigidBody.position;
				}
				return Collider.transform.position;
			}
		}

		public IRigidBody RigidBody { get; private set; }

		public override TargetType TargetType => TargetType.Air;

		public override Vector3 Velocity
		{
			get
			{
				if (Aircraft != null)
				{
					return Aircraft.Velocity;
				}
				if (RigidBody != null)
				{
					return RigidBody.velocity;
				}
				return Vector3.zero;
			}
		}

		public EnemyWeaponTarget(IRigidBody rigidBody, ExclusiveLock exclusiveLock = null)
			: base(1)
		{
			RigidBody = rigidBody;
			Lock = exclusiveLock;
		}

		public EnemyWeaponTarget(AircraftScript aircraft, ExclusiveLock exclusiveLock = null)
			: base(1)
		{
			Aircraft = aircraft;
			Collider = aircraft.MainCockpit.PrimaryPartCollider;
			RigidBody = aircraft.MainCockpit.Body.RigidBody;
			Lock = exclusiveLock;
		}

		public void MarkAsDead()
		{
			_isDead = true;
		}

		public void Update()
		{
			if (Aircraft != null && (RigidBody.IsDead || !RigidBody.activeSelf))
			{
				Collider = Aircraft.MainCockpit.PrimaryPartCollider;
				RigidBody = Aircraft.MainCockpit.Body.RigidBody;
			}
		}
	}
}
