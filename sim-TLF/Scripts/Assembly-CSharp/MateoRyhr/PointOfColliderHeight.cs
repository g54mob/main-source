using UnityEngine;

namespace MateoRyhr
{
	public class PointOfColliderHeight : MonoBehaviour
	{
		[SerializeField]
		private Collider _collider;

		private void FixedUpdate()
		{
			base.transform.position = _collider.transform.position + _collider.transform.up * _collider.bounds.size.y;
		}
	}
}
