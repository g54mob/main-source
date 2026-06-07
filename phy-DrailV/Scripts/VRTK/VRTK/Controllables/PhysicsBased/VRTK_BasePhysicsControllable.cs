using UnityEngine;

namespace VRTK.Controllables.PhysicsBased
{
	public abstract class VRTK_BasePhysicsControllable : VRTK_BaseControllable
	{
		[Header("Physics Settings")]
		[Tooltip("The Rigidbody that the Controllable is connected to.")]
		public Rigidbody connectedTo;

		protected Rigidbody controlRigidbody;

		protected bool createCustomRigidbody;

		protected GameObject rigidbodyActivatorContainer;

		public virtual Rigidbody GetControlRigidbody()
		{
			return controlRigidbody;
		}

		public virtual GameObject GetControlActivatorContainer()
		{
			return rigidbodyActivatorContainer;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetupRigidbody();
			SetupRigidbodyActivator();
		}

		protected override void OnDisable()
		{
			if (createCustomRigidbody)
			{
				Object.Destroy(controlRigidbody);
			}
			base.OnDisable();
		}

		protected virtual void SetupRigidbodyActivator()
		{
			VRTK_ControllerRigidbodyActivator componentInChildren = GetComponentInChildren<VRTK_ControllerRigidbodyActivator>();
			rigidbodyActivatorContainer = ((componentInChildren != null) ? componentInChildren.gameObject : null);
		}

		protected virtual void SetupRigidbody()
		{
			controlRigidbody = GetComponent<Rigidbody>();
			createCustomRigidbody = false;
			if (controlRigidbody == null)
			{
				controlRigidbody = base.gameObject.AddComponent<Rigidbody>();
				createCustomRigidbody = true;
				ConfigueRigidbody();
			}
			SetRigidbodyKinematic(isKinematic: false);
		}

		protected virtual void ConfigueRigidbody()
		{
		}

		protected virtual void SetRigidbodyVelocity(Vector3 newVelocity)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.velocity = newVelocity;
			}
		}

		protected virtual void SetRigidbodyDrag(float givenDrag)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.drag = givenDrag;
			}
		}

		protected virtual void SetRigidbodyAngularDrag(float givenDrag)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.angularDrag = givenDrag;
			}
		}

		protected virtual void SetRigidbodyGravity(bool useGravity)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.useGravity = useGravity;
			}
		}

		protected virtual void SetRigidbodyKinematic(bool isKinematic)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.isKinematic = isKinematic;
			}
		}

		protected virtual void SetRigidbodyConstraints(RigidbodyConstraints newConstraints)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.constraints = newConstraints;
			}
		}

		protected virtual void SetRigidbodyCollisionDetectionMode(CollisionDetectionMode newDetectionMode)
		{
			if (controlRigidbody != null)
			{
				controlRigidbody.collisionDetectionMode = newDetectionMode;
			}
		}
	}
}
