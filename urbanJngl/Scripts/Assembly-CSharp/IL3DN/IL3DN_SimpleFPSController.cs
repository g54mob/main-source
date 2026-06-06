using UnityEngine;

namespace IL3DN
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(AudioSource))]
	public class IL3DN_SimpleFPSController : MonoBehaviour
	{
		[SerializeField]
		private bool m_IsWalking;

		[SerializeField]
		private float m_WalkSpeed = 2f;

		[SerializeField]
		private float m_RunSpeed = 5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_RunstepLenghten = 0.7f;

		[SerializeField]
		private float m_JumpSpeed = 5f;

		[SerializeField]
		private float m_StickToGroundForce = 10f;

		[SerializeField]
		private float m_GravityMultiplier = 2f;

		[SerializeField]
		private IL3DN_SimpleMouseLook m_MouseLook;

		[SerializeField]
		private float m_StepInterval = 2f;

		[SerializeField]
		private AudioClip[] m_FootstepSounds;

		[SerializeField]
		private AudioClip m_JumpSound;

		[SerializeField]
		private AudioClip m_LandSound;

		private Camera m_Camera;

		private bool m_Jump;

		private float m_YRotation;

		private Vector2 m_Input;

		private Vector3 m_MoveDir = Vector3.zero;

		private CharacterController m_CharacterController;

		private CollisionFlags m_CollisionFlags;

		private bool m_PreviouslyGrounded;

		private float m_StepCycle;

		private float m_NextStep;

		private bool m_Jumping;

		private AudioSource m_AudioSource;

		private AudioClip[] footStepsOverride;

		private AudioClip jumpSoundOverride;

		private AudioClip landSoundOverride;

		private bool isInSpecialSurface;

		private void Start()
		{
			m_CharacterController = GetComponent<CharacterController>();
			m_Camera = Camera.main;
			m_StepCycle = 0f;
			m_NextStep = m_StepCycle / 2f;
			m_Jumping = false;
			m_AudioSource = GetComponent<AudioSource>();
			m_MouseLook.Init(base.transform, m_Camera.transform);
		}

		private void Update()
		{
			RotateView();
			if (!m_Jump)
			{
				m_Jump = Input.GetButtonDown("Jump");
			}
			if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
			{
				PlayLandingSound();
				m_MoveDir.y = 0f;
				m_Jumping = false;
			}
			if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
			{
				m_MoveDir.y = 0f;
			}
			m_PreviouslyGrounded = m_CharacterController.isGrounded;
		}

		private void PlayLandingSound()
		{
			if (isInSpecialSurface)
			{
				m_AudioSource.clip = landSoundOverride;
			}
			else
			{
				m_AudioSource.clip = m_LandSound;
			}
			m_AudioSource.Play();
			m_NextStep = m_StepCycle + 0.5f;
		}

		private void FixedUpdate()
		{
			GetInput(out var speed);
			Vector3 vector = base.transform.forward * m_Input.y + base.transform.right * m_Input.x;
			Physics.SphereCast(base.transform.position, m_CharacterController.radius, Vector3.down, out var hitInfo, m_CharacterController.height / 2f, -1, QueryTriggerInteraction.Ignore);
			vector = Vector3.ProjectOnPlane(vector, hitInfo.normal).normalized;
			m_MoveDir.x = vector.x * speed;
			m_MoveDir.z = vector.z * speed;
			if (m_CharacterController.isGrounded)
			{
				m_MoveDir.y = 0f - m_StickToGroundForce;
				if (m_Jump)
				{
					m_MoveDir.y = m_JumpSpeed;
					PlayJumpSound();
					m_Jump = false;
					m_Jumping = true;
				}
			}
			else
			{
				m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
			}
			m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);
			ProgressStepCycle(speed);
			m_MouseLook.UpdateCursorLock();
		}

		private void PlayJumpSound()
		{
			if (isInSpecialSurface)
			{
				m_AudioSource.clip = jumpSoundOverride;
			}
			else
			{
				m_AudioSource.clip = m_JumpSound;
			}
			m_AudioSource.Play();
		}

		private void ProgressStepCycle(float speed)
		{
			if (m_CharacterController.velocity.sqrMagnitude > 0f && (m_Input.x != 0f || m_Input.y != 0f))
			{
				m_StepCycle += (m_CharacterController.velocity.magnitude + speed * (m_IsWalking ? 1f : m_RunstepLenghten)) * Time.fixedDeltaTime;
			}
			if (m_StepCycle > m_NextStep)
			{
				m_NextStep = m_StepCycle + m_StepInterval;
				PlayFootStepAudio();
			}
		}

		private void PlayFootStepAudio()
		{
			if (!m_CharacterController.isGrounded)
			{
				return;
			}
			if (!isInSpecialSurface)
			{
				int num = Random.Range(1, m_FootstepSounds.Length);
				m_AudioSource.clip = m_FootstepSounds[num];
				m_AudioSource.PlayOneShot(m_AudioSource.clip);
				m_FootstepSounds[num] = m_FootstepSounds[0];
				m_FootstepSounds[0] = m_AudioSource.clip;
				return;
			}
			int num2 = Random.Range(1, footStepsOverride.Length);
			if (num2 >= footStepsOverride.Length)
			{
				num2 = 0;
			}
			m_AudioSource.clip = footStepsOverride[num2];
			m_AudioSource.PlayOneShot(m_AudioSource.clip);
			footStepsOverride[num2] = footStepsOverride[0];
			footStepsOverride[0] = m_AudioSource.clip;
		}

		private void GetInput(out float speed)
		{
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			_ = m_IsWalking;
			m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
			speed = (m_IsWalking ? m_WalkSpeed : m_RunSpeed);
			m_Input = new Vector2(axis, axis2);
			if (m_Input.sqrMagnitude > 1f)
			{
				m_Input.Normalize();
			}
		}

		private void RotateView()
		{
			m_MouseLook.LookRotation(base.transform, m_Camera.transform);
		}

		private void OnTriggerEnter(Collider other)
		{
			IL3DN_ChangeWalkingSound component = other.GetComponent<IL3DN_ChangeWalkingSound>();
			if (component != null)
			{
				footStepsOverride = component.footStepsOverride;
				jumpSoundOverride = component.jumpSound;
				landSoundOverride = component.landSound;
				isInSpecialSurface = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			isInSpecialSurface = false;
		}
	}
}
