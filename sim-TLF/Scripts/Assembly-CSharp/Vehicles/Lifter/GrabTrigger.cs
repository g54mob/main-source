using MyBox;
using UnityEngine;

namespace Vehicles.Lifter
{
	public class GrabTrigger : MonoBehaviour
	{
		[MustBeAssigned]
		[SerializeField]
		private Rigidbody _rigidbody;

		public Rigidbody Rigidbody => _rigidbody;
	}
}
