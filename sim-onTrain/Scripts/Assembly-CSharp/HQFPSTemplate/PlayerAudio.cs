using System;
using HQFPSTemplate.Surfaces;
using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerAudio : PlayerComponent
	{
		[Serializable]
		private struct PlayerMovementAudio
		{
			[Group]
			public SoundPlayer JumpAudio;

			[Group]
			public SoundPlayer CrouchAudio;

			[Group]
			public SoundPlayer ProneAudio;

			[Group]
			public SoundPlayer StandUpAudio;
		}

		[Serializable]
		private struct PlayerVitalsAudio
		{
			[BHeader("Health", true)]
			[Group]
			[Tooltip("The sounds that will be played when this entity receives damage.")]
			public SoundPlayer HurtAudio;

			[SerializeField]
			public float TimeBetweenScreams;

			[Space]
			[Group]
			public SoundPlayer FallDamageAudio;

			[Space]
			[Group]
			public SoundPlayer EarRingingAudio;

			[Range(0f, 1f)]
			public float EarRingVolumeDecrease;

			public float EarRingVolumeGainSpeed;

			[Space]
			[Group]
			public SoundPlayer DeathAudio;

			[BHeader("Stamina", true)]
			[Group]
			public SoundPlayer BreathingHeavyAudio;

			public float BreathingHeavyDuration;
		}

		[Serializable]
		private struct PlayerFootstepsAudio
		{
			public LayerMask GroundMask;

			[Range(0f, 1f)]
			public float RaycastDistance;

			[Range(0f, 10f)]
			[Tooltip("If the impact speed is higher than this threeshold, an effect will be played.")]
			public float FallImpactThreeshold;

			[Range(0f, 1f)]
			public float WalkVolume;

			[Range(0f, 1f)]
			public float CrouchVolume;

			[Range(0f, 1f)]
			public float ProneVolume;

			[Range(0f, 1f)]
			public float RunVolume;
		}

		[SerializeField]
		private AudioSource m_AudioSource;

		[Space]
		[SerializeField]
		[Group]
		private PlayerMovementAudio m_PlayerMovementAudio;

		[SerializeField]
		[Group]
		private PlayerVitalsAudio m_PlayerVitalsAudio;

		[SerializeField]
		[Group]
		private PlayerFootstepsAudio m_PlayerFootsteps;

		private float m_LastHeavyBreathTime;

		private float m_NextTimeCanScream;

		private bool m_IsBreathingSoundPlaying;

		private float m_StaminaThreshold = 5f;

		private void Start()
		{
			base.Player.MoveCycleEnded.AddListener(PlayFootstep);
			base.Player.FallImpact.AddListener(On_FallImpact);
			base.Player.Death.AddListener(delegate
			{
				m_PlayerVitalsAudio.DeathAudio.Play(m_AudioSource);
			});
			base.Player.Jump.AddStartListener(delegate
			{
				m_PlayerMovementAudio.JumpAudio.Play(m_AudioSource);
			});
			base.Player.Crouch.AddStartListener(delegate
			{
				m_PlayerMovementAudio.CrouchAudio.Play(m_AudioSource);
			});
			base.Player.Crouch.AddStopListener(delegate
			{
				m_PlayerMovementAudio.StandUpAudio.Play(m_AudioSource);
			});
			base.Player.Prone.AddStartListener(delegate
			{
				m_PlayerMovementAudio.ProneAudio.Play(m_AudioSource);
			});
			base.Player.Prone.AddStopListener(delegate
			{
				m_PlayerMovementAudio.StandUpAudio.Play(m_AudioSource);
			});
			base.Player.Health.AddChangeListener(OnChanged_Health);
			base.Player.Stamina.AddChangeListener(OnChanged_Stamina);
			ShakeManager.ShakeEvent.AddListener(OnShakeEvent);
		}

		private void Update()
		{
			AudioListener.volume = Mathf.MoveTowards(AudioListener.volume, 1f, m_PlayerVitalsAudio.EarRingVolumeGainSpeed * Time.deltaTime);
		}

		private void OnDestroy()
		{
			ShakeManager.ShakeEvent.RemoveListener(OnShakeEvent);
		}

		private void PlayFootstep()
		{
			if (base.Player.Velocity.Val.sqrMagnitude > 0.1f)
			{
				SurfaceEffects effectType = SurfaceEffects.SoftFootstep;
				if (base.Player.Run.Active)
				{
					effectType = SurfaceEffects.HardFootstep;
				}
				float audioVolume = m_PlayerFootsteps.WalkVolume;
				if (base.Player.Crouch.Active)
				{
					audioVolume = m_PlayerFootsteps.CrouchVolume;
				}
				else if (base.Player.Prone.Active)
				{
					audioVolume = m_PlayerFootsteps.ProneVolume;
				}
				else if (base.Player.Run.Active)
				{
					audioVolume = m_PlayerFootsteps.RunVolume;
				}
				if (CheckGround(out var hitInfo))
				{
					SurfaceManager.SpawnEffect(hitInfo, effectType, audioVolume);
				}
			}
		}

		private void On_FallImpact(float fallImpactSpeed)
		{
			if (Mathf.Abs(fallImpactSpeed) >= m_PlayerFootsteps.FallImpactThreeshold)
			{
				if (CheckGround(out var hitInfo))
				{
					SurfaceManager.SpawnEffect(hitInfo, SurfaceEffects.FallImpact, 1f);
				}
				if (base.Player.Health.GetPreviousValue() > base.Player.Health.Get())
				{
					m_PlayerVitalsAudio.FallDamageAudio.Play(ItemSelection.Method.Random, m_AudioSource);
				}
			}
		}

		private bool CheckGround(out RaycastHit hitInfo)
		{
			return Physics.Raycast(new Ray(base.transform.position + Vector3.up * 0.1f, Vector3.down), out hitInfo, m_PlayerFootsteps.RaycastDistance, m_PlayerFootsteps.GroundMask, QueryTriggerInteraction.Ignore);
		}

		private void OnShakeEvent(ShakeEventData shake)
		{
			if (shake.ShakeType == ShakeType.Explosion)
			{
				float sqrMagnitude = (base.transform.position - shake.Position).sqrMagnitude;
				float num = shake.Radius * shake.Radius;
				float num2 = 1f - Mathf.Clamp01(sqrMagnitude / num);
				AudioListener.volume = 1f - m_PlayerVitalsAudio.EarRingVolumeDecrease * num2;
				m_PlayerVitalsAudio.EarRingingAudio.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource, num2);
			}
		}

		private void OnChanged_Health(float health)
		{
			if (health - base.Entity.Health.GetPreviousValue() < 0f && Time.time > m_NextTimeCanScream)
			{
				m_PlayerVitalsAudio.HurtAudio.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource);
				m_NextTimeCanScream = Time.time + m_PlayerVitalsAudio.TimeBetweenScreams;
			}
		}

		private void OnChanged_Stamina(float stamina)
		{
			if (base.Player.Stamina.GetPreviousValue() == stamina)
			{
				return;
			}
			base.Player.Stamina.GetPreviousValue();
			if (stamina <= m_StaminaThreshold && !m_IsBreathingSoundPlaying)
			{
				if (Time.time - m_LastHeavyBreathTime > m_PlayerVitalsAudio.BreathingHeavyDuration)
				{
					m_LastHeavyBreathTime = Time.time;
					m_PlayerVitalsAudio.BreathingHeavyAudio.Play(m_AudioSource);
					m_IsBreathingSoundPlaying = true;
				}
			}
			else if (stamina > 30f && m_IsBreathingSoundPlaying)
			{
				m_IsBreathingSoundPlaying = false;
			}
		}
	}
}
