using JSAM;
using StarterAssets;
using UnityEngine;

namespace Player.Audio
{
	public class PlayerAudioWalker : MonoBehaviour
	{
		[SerializeField]
		private CharacterController _characterController;

		[SerializeField]
		private FirstPersonController _firstPersonController;

		[SerializeField]
		private SoundFileObject _walkSoundObject;

		[SerializeField]
		private float _stepSpeedMult = 0.5f;

		private float _stepTimer = 9999f;

		private void Update()
		{
			Vector3 velocity = _characterController.velocity;
			velocity.y = 0f;
			if (velocity.magnitude < 0.1f || !_firstPersonController.Grounded)
			{
				AudioManager.StopSoundIfPlaying(_walkSoundObject, base.transform);
				_stepTimer = 0f;
				return;
			}
			_stepTimer += Time.deltaTime;
			if (_stepTimer >= _stepSpeedMult / _firstPersonController.CurrentSpeed)
			{
				AudioManager.PlaySound(_walkSoundObject, base.transform);
				_stepTimer = 0f;
			}
		}
	}
}
