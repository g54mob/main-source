using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.CombatArena
{
	public class CombatRoll : MonoBehaviour
	{
		public float Damage;

		public Transform EndPosition;

		public float RollTime;

		public string RollSfx;

		private float _progress;

		private bool _isRolling;

		private Vector3 _startPosition;

		private Rigidbody _rigidBody;

		public void Awake()
		{
			_startPosition = base.transform.position;
			_rigidBody = GetComponent<Rigidbody>();
			_progress = 0f;
		}

		public void StartRolling()
		{
			_isRolling = true;
			AudioController.Play(RollSfx, base.transform);
		}

		public void FixedUpdate()
		{
			if (_isRolling)
			{
				_progress += Time.fixedDeltaTime / RollTime;
				_rigidBody.MovePosition(Vector3.Lerp(_startPosition, EndPosition.position, _progress));
			}
		}

		public void OnCollisionStay(Collision col)
		{
			if (col.gameObject != null)
			{
				col.gameObject.SendMessage("TakeDamage", new DamageInformation(Damage * Time.deltaTime, EDamageReason.Environment), SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
