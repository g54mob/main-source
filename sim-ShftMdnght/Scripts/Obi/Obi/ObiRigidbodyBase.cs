using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	public abstract class ObiRigidbodyBase : MonoBehaviour
	{
		public bool kinematicForParticles;

		protected ObiRigidbodyHandle rigidbodyHandle;

		public ObiRigidbodyHandle handle
		{
			get
			{
				if (rigidbodyHandle == null || !rigidbodyHandle.isValid)
				{
					ObiColliderWorld instance = ObiColliderWorld.GetInstance();
					rigidbodyHandle = instance.CreateRigidbody();
					rigidbodyHandle.owner = this;
				}
				return rigidbodyHandle;
			}
		}

		protected virtual void OnEnable()
		{
		}

		public void OnDisable()
		{
			ObiColliderWorld.GetInstance().DestroyRigidbody(handle);
		}

		public abstract void UpdateIfNeeded(float stepTime);

		public abstract void UpdateVelocities(Vector3 linearDelta, Vector3 angularDelta);
	}
}
