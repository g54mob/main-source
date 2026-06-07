using UnityEngine;

namespace Rewired.Demos
{
	public class PressAnyButtonToJoinExample_GamePlayer : MonoBehaviour
	{
		public int playerId;

		public float moveSpeed;

		public float bulletSpeed;

		public GameObject bulletPrefab;

		private CharacterController cc;

		private Vector3 moveVector;

		private bool fire;

		private Player player => null;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void GetInput()
		{
		}

		private void ProcessInput()
		{
		}
	}
}
