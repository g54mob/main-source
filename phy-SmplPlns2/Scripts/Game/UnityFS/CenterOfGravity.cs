using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Dynamics/Center Of Gravity")]
	public class CenterOfGravity : AircraftAttachment
	{
		private GameObject _parent;

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(base.transform.position, 0.1f);
		}

		protected virtual void Start()
		{
			_parent = base.gameObject.transform.root.gameObject;
		}

		protected virtual void Update()
		{
			if (_parent.TryGetComponent<Rigidbody>(out var component))
			{
				component.centerOfMass = base.gameObject.transform.localPosition;
			}
			Debug.DrawLine(base.gameObject.transform.position - base.gameObject.transform.up * 1f, base.gameObject.transform.position + base.gameObject.transform.up * 1f, Color.blue);
			Debug.DrawLine(base.gameObject.transform.position - base.gameObject.transform.right * 1f, base.gameObject.transform.position + base.gameObject.transform.right * 1f, Color.blue);
		}
	}
}
