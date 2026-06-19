using JSAM;
using StarterAssets;
using UnityEngine;
using Zenject;

namespace Player.Audio
{
	public class PlayerAudioJumper : MonoBehaviour
	{
		[SerializeField]
		private CharacterController _characterController;

		[SerializeField]
		private FirstPersonController _firstPersonController;

		[SerializeField]
		private SoundFileObject _jumpAudioFile;

		[SerializeField]
		private SoundFileObject _landAudioFile;

		private bool _wasGrounded = true;

		[SerializeField]
		private bool _isJumping;

		[Inject]
		private IPlayerInputService _playerInputService;

		private void OnEnable()
		{
			_playerInputService.OnJump += OnJump;
		}

		private void OnDisable()
		{
			_playerInputService.OnJump -= OnJump;
		}

		private void Update()
		{
			bool grounded = _firstPersonController.Grounded;
			if (!_wasGrounded && grounded)
			{
				AudioManager.PlaySound(_landAudioFile, base.transform);
				_isJumping = false;
			}
			_wasGrounded = grounded;
		}

		private void OnJump(bool obj)
		{
			if (!_isJumping)
			{
				_isJumping = true;
				AudioManager.PlaySound(_jumpAudioFile, base.transform);
			}
		}
	}
}
