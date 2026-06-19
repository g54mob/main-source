using Player.FSM;
using UnityEngine;

namespace Player
{
	public class PlayerBehaviour : MonoBehaviour
	{
		[SerializeField]
		private PlayerBehaviourStateMachine _stateMachine;

		[SerializeField]
		private CharacterController _characterController;

		[SerializeField]
		private Collider _characterCollider;

		[SerializeField]
		private Transform _cameraRoot;

		public PlayerBehaviourStateMachine StateMachine => _stateMachine;

		public CharacterController CharacterController => _characterController;

		public Transform CameraRoot => _cameraRoot;

		public void DisableControllerAndCollision(bool value)
		{
			_characterController.enabled = value;
			_characterCollider.enabled = value;
		}
	}
}
