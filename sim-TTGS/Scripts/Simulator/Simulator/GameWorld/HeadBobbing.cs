using Dhs5.Utility.Updates;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class HeadBobbing : MonoBehaviour
	{
		[SerializeField]
		private CinemachineBasicMultiChannelPerlin m_noise;

		[SerializeField]
		private Transform m_targetToSyncWith;

		private bool m_updateRegistered;

		public void SetEnable()
		{
			GameplayApplicationOptions.HeadBobbing.OnValueChanged += OnHeadBobbingValueChanged;
			OnHeadBobbingValueChanged(GameplayApplicationOptions.HeadBobbing.Value);
		}

		public void SetDisable()
		{
			GameplayApplicationOptions.HeadBobbing.OnValueChanged -= OnHeadBobbingValueChanged;
			OnHeadBobbingValueChanged(value: false);
		}

		private void OnHeadBobbingValueChanged(bool value)
		{
			RegisterToUpdate(value);
			if (!value)
			{
				m_noise.FrequencyGain = 0f;
				m_noise.AmplitudeGain = 0f;
			}
		}

		private void RegisterToUpdate(bool register)
		{
			if (m_updateRegistered == register)
			{
				return;
			}
			m_updateRegistered = register;
			Updater.RegisterChannelCallback(register, EUpdateChannel.MOVEMENT, OnUpdate);
			if (register)
			{
				if (m_targetToSyncWith != null)
				{
					CinemachineCore.CameraUpdatedEvent.AddListener(OnCinemachineUpdate);
				}
			}
			else if (m_targetToSyncWith != null)
			{
				CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCinemachineUpdate);
			}
		}

		private void OnUpdate(float deltaTime)
		{
			PlayerMovementSettings.NoiseParams noiseParamsByMovementMode = PlayerMovementSettings.GetNoiseParamsByMovementMode(World.PlayerCharacter.Movement.MovementMode);
			m_noise.FrequencyGain = noiseParamsByMovementMode.Frequency;
			m_noise.AmplitudeGain = noiseParamsByMovementMode.Amplitude;
		}

		private void OnCinemachineUpdate(CinemachineBrain brain)
		{
			Vector3 finalPosition = brain.State.GetFinalPosition();
			Vector3 position = Vector3.LerpUnclamped(m_targetToSyncWith.position, finalPosition, PlayerMovementSettings.NoiseInfluenceOnTargetToSyncWith);
			m_targetToSyncWith.position = position;
		}
	}
}
