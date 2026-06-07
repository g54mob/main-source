using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class PlayerFootstepsAudio : MonoBehaviour
	{
		[SerializeField]
		private PlayerCharacterMovement m_playerCharacterMovement;

		[SerializeField]
		private GroundDetection m_groundDetection;

		private Collider m_currentGroundCollider;

		private EGroundType m_currentGroundType;

		private float m_stepTimer;

		private void OnEnable()
		{
			m_groundDetection.OnGrounded += OnGrounded;
			m_groundDetection.OnUnGrounded += OnUnGrounded;
		}

		private void OnDisable()
		{
			m_groundDetection.OnGrounded -= OnGrounded;
			m_groundDetection.OnUnGrounded -= OnUnGrounded;
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.MOVEMENT, UpdateCallback);
		}

		private void OnGrounded(Collider obj)
		{
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.MOVEMENT, UpdateCallback);
			Step(GetGroundType());
		}

		private void OnUnGrounded()
		{
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.MOVEMENT, UpdateCallback);
			ResetTimer();
		}

		private void UpdateCallback(float deltaTime)
		{
			if (m_playerCharacterMovement.CurrentMoveInput.IsNull())
			{
				ResetTimer();
				return;
			}
			EGroundType groundType = GetGroundType();
			if (groundType == EGroundType.NONE)
			{
				ResetTimer();
				return;
			}
			m_stepTimer += deltaTime;
			if (!(m_stepTimer < GetStepTime()))
			{
				OnTimerComplete(groundType);
			}
		}

		private void Step(EGroundType groundType)
		{
			PlayAudio(groundType);
		}

		private void PlayAudio(EGroundType groundType)
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.PlayerFootsteps(groundType));
		}

		private void ResetTimer()
		{
			m_stepTimer = 0f;
		}

		private void OnTimerComplete(EGroundType groundType)
		{
			ResetTimer();
			Step(groundType);
		}

		private EGroundType GetGroundType()
		{
			Collider groundCollider = m_groundDetection.GroundCollider;
			if (groundCollider == m_currentGroundCollider)
			{
				return m_currentGroundType;
			}
			if (groundCollider.TryGetComponent<GroundTypeHolder>(out var component))
			{
				m_currentGroundType = component.Get();
			}
			else
			{
				Debug.LogError(string.Format("{0} has no {1}.", groundCollider, "GroundTypeHolder"));
				m_currentGroundType = EGroundType.NONE;
			}
			return m_currentGroundType;
		}

		private float GetStepTime()
		{
			if (!m_playerCharacterMovement.IsSprinting)
			{
				return PlayerMovementSettings.TimeBetweenStepsWalking;
			}
			return PlayerMovementSettings.TimeBetweenStepsSprinting;
		}
	}
}
