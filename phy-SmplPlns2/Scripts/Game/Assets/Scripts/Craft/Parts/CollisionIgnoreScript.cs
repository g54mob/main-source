using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class CollisionIgnoreScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker Create = new ProfilerMarker("CollisionIgnoreScript.Create");

			public static readonly ProfilerMarker OnTriggerEnter = new ProfilerMarker("CollisionIgnoreScript.OnTriggerEnter");

			public static readonly ProfilerMarker Start = new ProfilerMarker("CollisionIgnoreScript.Start");

			public static readonly ProfilerMarker Update = new ProfilerMarker("CollisionIgnoreScript.Update");
		}

		private Collider _collider;

		private bool _fixedUpdateRan;

		private bool _isTrigger;

		private PartScript _partScript;

		private Rigidbody _tempRigidbody;

		public static CollisionIgnoreScript Create(PartColliderScript colliderScript, PartScript partScript)
		{
			using (Profile.Create.Auto())
			{
				CollisionIgnoreScript collisionIgnoreScript = colliderScript.gameObject.AddComponent<CollisionIgnoreScript>();
				collisionIgnoreScript._partScript = partScript;
				return collisionIgnoreScript;
			}
		}

		protected virtual void FixedUpdate()
		{
			_fixedUpdateRan = true;
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			using (Profile.OnTriggerEnter.Auto())
			{
				CollisionIgnoreScript component;
				PartScript partScript = (other.TryGetComponent<CollisionIgnoreScript>(out component) ? component._partScript : other.GetComponentInParent<PartScript>());
				if (partScript != null && partScript.Body != _partScript.Body && !HasDisabledConfig(this) && !HasDisabledConfig(other))
				{
					Physics.IgnoreCollision(_collider, other);
				}
			}
			static bool HasDisabledConfig(Component comp)
			{
				if (comp.TryGetComponent<ICollisionIgnoreConfiguration>(out var component2))
				{
					return !component2.Enabled;
				}
				return false;
			}
		}

		protected virtual void Start()
		{
			using (Profile.Start.Auto())
			{
				_tempRigidbody = base.gameObject.AddComponent<Rigidbody>();
				_tempRigidbody.isKinematic = true;
				_tempRigidbody.mass = 0f;
				_tempRigidbody.useGravity = false;
				_collider = GetComponent<Collider>();
				_isTrigger = _collider.isTrigger;
				_collider.isTrigger = true;
			}
		}

		protected virtual void Update()
		{
			using (Profile.Update.Auto())
			{
				if (_fixedUpdateRan)
				{
					_collider.isTrigger = _isTrigger;
					Object.Destroy(_tempRigidbody);
					Object.Destroy(this);
				}
			}
		}
	}
}
