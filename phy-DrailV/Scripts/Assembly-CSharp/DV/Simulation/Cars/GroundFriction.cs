using DV.Utils;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class GroundFriction
	{
		private const float FORCE = 12f;

		private TrainCar car;

		private Collider[] bogieColliders;

		private bool grounded;

		private bool subbedToColInfo;

		private int lastFrameAppliedForce = -1;

		private int groundedSetFixedTime = -1;

		private readonly ContactPoint[] points = new ContactPoint[5];

		public bool IsGrounded
		{
			get
			{
				if (car.derailed)
				{
					return grounded;
				}
				return true;
			}
		}

		public GroundFriction(TrainCar car, Transform bogieCollidersRoot)
		{
			this.car = car;
			bogieColliders = bogieCollidersRoot.GetComponentsInChildren<Collider>(includeInactive: true);
			if (bogieColliders.Length == 0)
			{
				Debug.LogError("Unexpected state: Missing bogie colliders on " + car.name + ". GroundFriction won't function properly!", car.gameObject);
			}
			car.OnDerailed += OnDerailed;
			car.OnRerailed += OnRerailed;
			CheckState();
		}

		private void OnDerailed(TrainCar derailedcar)
		{
			car.MovementStateChanged += CarOnMovementStateChanged;
			CheckState();
		}

		private void OnRerailed()
		{
			car.MovementStateChanged -= CarOnMovementStateChanged;
			CheckState();
		}

		public void ResetState()
		{
			grounded = false;
			subbedToColInfo = false;
			car.MovementStateChanged -= CarOnMovementStateChanged;
			car.CollisionInfoDispenser.CollisionStayInfo -= OnCollisionStayEvent;
			car.CollisionInfoDispenser.CollisionExitInfo -= OnCollisionExitEvent;
		}

		private void CarOnMovementStateChanged(bool _)
		{
			CheckState();
		}

		private void CheckState()
		{
			bool flag = !car.isStationary && car.derailed;
			if (flag != subbedToColInfo)
			{
				subbedToColInfo = flag;
				if (flag)
				{
					car.CollisionInfoDispenser.CollisionStayInfo += OnCollisionStayEvent;
					car.CollisionInfoDispenser.CollisionExitInfo += OnCollisionExitEvent;
				}
				else
				{
					car.CollisionInfoDispenser.CollisionStayInfo -= OnCollisionStayEvent;
					car.CollisionInfoDispenser.CollisionExitInfo -= OnCollisionExitEvent;
				}
			}
		}

		private void OnCollisionExitEvent(Collision collisionInfo, bool becausePause)
		{
			if (grounded && collisionInfo.contactCount == 0 && groundedSetFixedTime != SingletonBehaviour<FixedUpdateTick>.Instance.Tick)
			{
				grounded = false;
			}
		}

		private void OnCollisionStayEvent(Collision collisionInfo, bool becausePause)
		{
			if (!grounded)
			{
				for (int i = 0; i < collisionInfo.GetContacts(points); i++)
				{
					ContactPoint contactPoint = points[i];
					bool flag = false;
					Collider[] array = bogieColliders;
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j] == contactPoint.thisCollider)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						Vector3 point = contactPoint.point;
						if (car.transform.InverseTransformPoint(point).y < 0.45f)
						{
							grounded = true;
							groundedSetFixedTime = SingletonBehaviour<FixedUpdateTick>.Instance.Tick;
							break;
						}
					}
				}
			}
			if (grounded && lastFrameAppliedForce != SingletonBehaviour<FixedUpdateTick>.Instance.Tick)
			{
				lastFrameAppliedForce = SingletonBehaviour<FixedUpdateTick>.Instance.Tick;
				Vector3 position = car.transform.position;
				Vector3 pointVelocity = car.rb.GetPointVelocity(position);
				Vector3 direction = car.transform.InverseTransformDirection(pointVelocity);
				direction.y = 0f;
				direction.z = 0f;
				direction.x = (0f - direction.x) * 12f * Time.fixedDeltaTime;
				pointVelocity = car.transform.TransformDirection(direction);
				car.rb.AddForceAtPosition(pointVelocity, position, ForceMode.VelocityChange);
			}
		}
	}
}
