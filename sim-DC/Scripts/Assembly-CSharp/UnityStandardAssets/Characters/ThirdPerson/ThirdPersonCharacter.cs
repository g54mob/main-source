using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
		[SerializeField]
		private float m_MovingTurnSpeed;

		[SerializeField]
		private float m_StationaryTurnSpeed;

		[SerializeField]
		private float m_JumpPower;

		[SerializeField]
		private float m_RunCycleLegOffset;

		[SerializeField]
		private float m_MoveSpeedMultiplier;

		public float m_AnimSpeedMultiplier;

		[SerializeField]
		private float m_GroundCheckDistance;

		private Rigidbody m_Rigidbody;

		private Animator m_Animator;

		private bool m_IsGrounded;

		private float m_OrigGroundCheckDistance;

		private const float k_Half = 0.5f;

		private float m_TurnAmount;

		private float m_ForwardAmount;

		private Vector3 m_GroundNormal;

		private CapsuleCollider m_Capsule;

		private bool m_Crouching;

		private AudioSource m_AudioSource;

		[SerializeField]
		private AudioClip[] m_FootstepSounds;

		[Range(0f, 1f)]
		[SerializeField]
		private float footStepVolume;

		private void Awake()
		{
		}

		public void Move(Vector3 move, bool crouch, bool jump, bool onlyturn, bool backward)
		{
		}

		private void UpdateAnimator(Vector3 move)
		{
		}

		private void HandleGroundedMovement(bool crouch, bool jump)
		{
		}

		private void ApplyExtraTurnRotation()
		{
		}

		public void OnAnimatorMove()
		{
		}

		public void PlayStepSound()
		{
		}

		private AudioClip PlayRandomAudioClip(AudioClip[] audioClips, float volume)
		{
			return null;
		}

		public void OnAnimationEventFootStep()
		{
		}
	}
}
