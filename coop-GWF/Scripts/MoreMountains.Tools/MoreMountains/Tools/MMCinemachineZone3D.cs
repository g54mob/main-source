using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(Collider))]
	public class MMCinemachineZone3D : MMCinemachineZone
	{
		protected Collider _collider;

		protected Collider _confinerCollider;

		protected Rigidbody _confinerRigidbody;

		protected BoxCollider _boxCollider;

		protected SphereCollider _sphereCollider;

		protected CinemachineConfiner3D _cinemachineConfiner;

		protected override void InitializeCollider()
		{
			_collider = GetComponent<Collider>();
			_boxCollider = GetComponent<BoxCollider>();
			_sphereCollider = GetComponent<SphereCollider>();
			_collider.isTrigger = true;
		}

		protected override void SetupConfiner()
		{
			_confinerRigidbody = _confinerGameObject.AddComponent<Rigidbody>();
			_confinerRigidbody.useGravity = false;
			_confinerRigidbody.gameObject.isStatic = true;
			_confinerRigidbody.isKinematic = true;
			CopyCollider();
			_confinerGameObject.transform.localPosition = Vector3.zero;
			_cinemachineConfiner = VirtualCamera.gameObject.MMGetComponentAroundOrAdd<CinemachineConfiner3D>();
			if (_boxCollider != null)
			{
				_cinemachineConfiner.BoundingVolume = _boxCollider;
			}
			if (_sphereCollider != null)
			{
				_cinemachineConfiner.BoundingVolume = _sphereCollider;
			}
		}

		protected virtual void CopyCollider()
		{
			if (_boxCollider != null)
			{
				BoxCollider boxCollider = _confinerGameObject.AddComponent<BoxCollider>();
				boxCollider.size = _boxCollider.size;
				boxCollider.center = _boxCollider.center;
				boxCollider.isTrigger = true;
			}
			if (_sphereCollider != null)
			{
				SphereCollider sphereCollider = _confinerGameObject.AddComponent<SphereCollider>();
				sphereCollider.isTrigger = true;
				sphereCollider.center = _sphereCollider.center;
				sphereCollider.radius = _sphereCollider.radius;
			}
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			if (TestCollidingGameObject(collider.gameObject) && TriggerMask.MMContains(collider.gameObject))
			{
				EnterZone();
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			if (TestCollidingGameObject(collider.gameObject) && TriggerMask.MMContains(collider.gameObject))
			{
				ExitZone();
			}
		}
	}
}
