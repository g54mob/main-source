using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using UnityEngine;

public class SkateboardController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeOutCoroutine_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AudioSource audioSource;

		public float duration;

		private float _003CstartVolume_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CFadeOutCoroutine_003Ed__59(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Skateboard Movement")]
	[SerializeField]
	[ReadOnly(new string[] { })]
	private float currentSpeed;

	[SerializeField]
	private float maxSpeed;

	[SerializeField]
	private float turn_speed;

	[SerializeField]
	private float pushForce;

	[SerializeField]
	private float pushBackForce;

	[SerializeField]
	private float pushInterval;

	[SerializeField]
	private float jumpForce;

	[SerializeField]
	private float jumpCooldown;

	[SerializeField]
	private float defaultDrag;

	[SerializeField]
	private float stoppingDrag;

	[SerializeField]
	private GameObject PlayerCoollider;

	[Header("Cinemachine")]
	[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
	[SerializeField]
	private GameObject CinemachineCameraTarget;

	[SerializeField]
	private GameObject CinemachineCamera;

	[Tooltip("Rotation speed of the character")]
	[SerializeField]
	private float RotationSpeed;

	[Header("Skateboard SFX")]
	[SerializeField]
	private AudioSource m_SkateboardSFX;

	[SerializeField]
	private AudioSource m_SkateboardOllieSFX;

	[SerializeField]
	private AudioSource m_SkateboardAccelerationSFX;

	[SerializeField]
	private float minVolume;

	[SerializeField]
	private float maxVolume;

	private bool isGrounded;

	private bool wasGrounded;

	private float groundCheckDistance;

	private Rigidbody rb;

	private Collider Collider;

	private bool can_collide;

	private readonly Vector3 gravity;

	private readonly float sideways_friction;

	private readonly float steez;

	private InputActions m_InputActions;

	private const float _threshold = 0.01f;

	private float _cinemachineTargetPitch;

	private float _rotationVelocity;

	private float _rotationVelocityX;

	private bool m_CachedMovementInteraction;

	private bool m_CachedCameraInteraction;

	private Vector3 defaultCameraPosition;

	private float pushPositionOffset;

	private bool isPushCameraEffectActive;

	private bool canPush;

	private float pushTimer;

	private bool canJump;

	private Vector3 previous_pos;

	private Quaternion previous_rot;

	private float speedRatio;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void FixedUpdate()
	{
	}

	public void EnableSkateboard()
	{
	}

	public void DisableSkateboard()
	{
	}

	private void HandleInteraction(InteractactableType interactactableType)
	{
	}

	private bool CheckIfGrounded()
	{
		return false;
	}

	private bool IsMovingForward()
	{
		return false;
	}

	private void OnSell(bool obj)
	{
	}

	private void Jump()
	{
	}

	private void ResetJump()
	{
	}

	private void Gravity(Vector3 local_velocity)
	{
	}

	private void PlaySkateboardAccelerationSFX()
	{
	}

	private void PlaySkateboardSFX()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeOutCoroutine_003Ed__59))]
	private IEnumerator FadeOutCoroutine(AudioSource audioSource, float duration)
	{
		return null;
	}

	private void PlaySkateboardOllieSFX()
	{
	}

	private void Movement(float h_input, float v_input, Vector3 local_velocity)
	{
	}

	private void PushSkateboard()
	{
	}

	private void PushBackSkateboard()
	{
	}

	private void PushCameraEffect()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnCollisionExit(Collision collision)
	{
	}
}
