using UnityEngine;

namespace Jundroo.Common.Physics
{
	[RequireComponent(typeof(Rigidbody))]
	public class ComOverride : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _centerOfMass = Vector3.zero;

		protected virtual void Start()
		{
			GetComponent<Rigidbody>().centerOfMass = _centerOfMass;
		}
	}
}
