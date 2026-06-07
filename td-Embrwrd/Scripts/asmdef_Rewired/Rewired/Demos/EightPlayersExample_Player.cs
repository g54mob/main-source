using System;
using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	[RequireComponent(typeof(CharacterController))]
	public class EightPlayersExample_Player : MonoBehaviour
	{
		public int playerId;

		public float moveSpeed;

		public float bulletSpeed;

		public GameObject bulletPrefab;

		private Player player;

		private CharacterController cc;

		private Vector3 moveVector;

		private bool fire;

		[NonSerialized]
		private bool initialized;

		private void Awake()
		{
		}

		private void Initialize()
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
