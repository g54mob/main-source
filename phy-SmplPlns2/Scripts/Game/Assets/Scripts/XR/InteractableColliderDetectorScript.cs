using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.XR
{
	[ExecuteAlways]
	public class InteractableColliderDetectorScript : MonoBehaviour, IEnumerable<InteractableCollider>, IEnumerable, IReadOnlyList<InteractableCollider>, IReadOnlyCollection<InteractableCollider>
	{
		private readonly List<InteractableCollider> _thisFrameColliders = new List<InteractableCollider>();

		private Collider[] _colliderResults;

		[SerializeField]
		private LayerMask _layerMask;

		[SerializeField]
		private float _radius;

		public int Count => ((IReadOnlyCollection<InteractableCollider>)_thisFrameColliders).Count;

		public InteractableCollider this[int index] => ((IReadOnlyList<InteractableCollider>)_thisFrameColliders)[index];

		public IEnumerator<InteractableCollider> GetEnumerator()
		{
			return ((IEnumerable<InteractableCollider>)_thisFrameColliders).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_thisFrameColliders).GetEnumerator();
		}

		protected virtual void Awake()
		{
			_colliderResults = new Collider[30];
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Vector3 lossyScale = base.transform.lossyScale;
			Gizmos.DrawWireSphere(base.transform.position, _radius * Mathf.Max(lossyScale.x, lossyScale.y, lossyScale.z));
		}

		protected virtual void Update()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			Vector3 lossyScale = base.transform.lossyScale;
			float radius = _radius * Mathf.Max(Mathf.Max(lossyScale.x, lossyScale.y), lossyScale.z);
			int num = 0;
			do
			{
				if (num == _colliderResults.Length)
				{
					_colliderResults = new Collider[_colliderResults.Length * 2];
				}
				num = Physics.OverlapSphereNonAlloc(base.transform.position, radius, _colliderResults, _layerMask);
			}
			while (num == _colliderResults.Length);
			_thisFrameColliders.Clear();
			for (int i = 0; i < num; i++)
			{
				if (_colliderResults[i].TryGetComponent<InteractableCollider>(out var component))
				{
					_thisFrameColliders.Add(component);
				}
			}
		}
	}
}
