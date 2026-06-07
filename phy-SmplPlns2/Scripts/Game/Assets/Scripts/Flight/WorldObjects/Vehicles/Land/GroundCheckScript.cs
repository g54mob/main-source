using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class GroundCheckScript : MonoBehaviour
	{
		public bool IsGrounded => TimeOffGround <= 0.2f;

		public float TimeOffGround { get; private set; }

		protected virtual void FixedUpdate()
		{
			TimeOffGround += Time.deltaTime;
		}

		protected virtual void OnTriggerStay(Collider other)
		{
			if (other.gameObject.layer == 20)
			{
				TimeOffGround = 0f;
			}
		}
	}
}
