using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	public class BoundsCollider : CTSBehaviour
	{
		[SerializeField]
		[Layer]
		private int _colliderLayer = 13;

		private BoxCollider _collider;

		protected override void OnAwake()
		{
			base.OnAwake();
			SetupColliders(base.transform);
		}

		protected override void OnDisabled()
		{
			if ((bool)_collider)
			{
				Object.Destroy(_collider);
			}
		}

		private Bounds CalculateBounds(Renderer[] p_renderers)
		{
			if (p_renderers.Length == 0)
			{
				return default(Bounds);
			}
			Bounds bounds = p_renderers[0].bounds;
			for (int i = 1; i < p_renderers.Length; i++)
			{
				bounds.Encapsulate(p_renderers[i].bounds);
			}
			return bounds;
		}

		public void SetupColliders(Transform p_transform)
		{
			Vector3 position = p_transform.position;
			Quaternion rotation = p_transform.rotation;
			p_transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			if (!TryGetCollider())
			{
				GameObject gameObject = new GameObject("Collider");
				gameObject.transform.parent = p_transform;
				gameObject.layer = _colliderLayer;
				_collider = gameObject.AddComponent<BoxCollider>();
			}
			Bounds p_bounds = CalculateBounds(GetComponentsInChildren<Renderer>());
			DecalProjector[] componentsInChildren = GetComponentsInChildren<DecalProjector>();
			foreach (DecalProjector decalProjector in componentsInChildren)
			{
				p_bounds.Encapsulate(new Bounds(p_transform.position, decalProjector.transform.rotation * decalProjector.size));
			}
			_collider.isTrigger = true;
			_collider.AutoSet(p_bounds);
			p_transform.SetPositionAndRotation(position, rotation);
		}

		private bool TryGetCollider()
		{
			if (!_collider)
			{
				return TryGetComponent<BoxCollider>(out _collider);
			}
			return true;
		}
	}
}
