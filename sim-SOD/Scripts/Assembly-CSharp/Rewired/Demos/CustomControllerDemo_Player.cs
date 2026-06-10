using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	[RequireComponent(typeof(CharacterController))]
	public class CustomControllerDemo_Player : MonoBehaviour
	{
		public int playerId;

		public float speed;

		public float bulletSpeed;

		public GameObject bulletPrefab;

		private Player _player;

		private CharacterController cc;

		private Player player => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
