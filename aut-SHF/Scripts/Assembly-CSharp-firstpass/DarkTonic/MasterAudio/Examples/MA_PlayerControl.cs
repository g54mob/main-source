using UnityEngine;

namespace DarkTonic.MasterAudio.Examples
{
	public class MA_PlayerControl : MonoBehaviour
	{
		public GameObject ProjectilePrefab;

		public bool canShoot;

		private const float MoveSpeed = 10f;

		private Transform _trans;

		private float _lastMoveAmt;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void OnBecameInvisible()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void Update()
		{
		}
	}
}
