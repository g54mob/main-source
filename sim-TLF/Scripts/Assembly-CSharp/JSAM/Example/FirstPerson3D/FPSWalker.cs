using System.Collections;
using UnityEngine;

namespace JSAM.Example.FirstPerson3D
{
	public class FPSWalker : MonoBehaviour
	{
		[Header("Explore me for examples of sound looping!")]
		[Header("FPS Properties")]
		[SerializeField]
		private float sprintTimeToBreathe = 5f;

		private float breathTime;

		[SerializeField]
		private float moveSpeed = 5f;

		[SerializeField]
		private float runSpeedMultiplier = 3f;

		[SerializeField]
		private float crouchSpeedMultiplier = 0.75f;

		[SerializeField]
		private Vector3 gravity = new Vector3(0f, -9.81f, 0f);

		[SerializeField]
		private bool crouching;

		private bool canToggleCrouch = true;

		[Header("Object References")]
		[SerializeField]
		private CharacterController controller;

		[SerializeField]
		private Transform stand;

		[SerializeField]
		private FPSAnimator animator;

		private MovementStates moveState;

		public MovementStates CurrentState => moveState;

		private void Update()
		{
			float num = moveSpeed;
			Vector3 zero = Vector3.zero;
			if (crouching)
			{
				num *= crouchSpeedMultiplier;
			}
			else if (Input.GetKey(KeyCode.LeftShift))
			{
				num *= runSpeedMultiplier;
			}
			if (Input.GetKey(KeyCode.W))
			{
				zero += stand.transform.forward * num;
			}
			if (Input.GetKey(KeyCode.S))
			{
				zero -= stand.transform.forward * num;
			}
			if (Input.GetKey(KeyCode.A))
			{
				zero -= stand.transform.right * num;
			}
			if (Input.GetKey(KeyCode.D))
			{
				zero += stand.transform.right * num;
			}
			if (Input.GetKeyDown(KeyCode.C) && canToggleCrouch)
			{
				StartCoroutine(CrouchCooldown());
			}
			else if (crouching && Input.GetKey(KeyCode.LeftShift) && canToggleCrouch)
			{
				StartCoroutine(CrouchCooldown());
			}
			if (Input.GetKey(KeyCode.LeftShift) && moveState == MovementStates.Walking)
			{
				moveState = MovementStates.Running;
			}
			else if (!Input.GetKey(KeyCode.LeftShift) && zero.magnitude > 0f)
			{
				moveState = MovementStates.Walking;
			}
			else if (zero.magnitude == 0f)
			{
				moveState = MovementStates.Idle;
			}
			controller.Move((zero + gravity) * Time.deltaTime);
			PlayMovementSound();
		}

		public void PlayMovementSound()
		{
			switch (moveState)
			{
			case MovementStates.Idle:
				AudioManager.StopSoundIfPlaying(FPS3DSounds.Walk, base.transform);
				AudioManager.StopSoundIfPlaying(FPS3DSounds.Running, base.transform);
				breathTime = Mathf.Max(breathTime - Time.deltaTime, 0f);
				break;
			case MovementStates.Walking:
				AudioManager.StopSoundIfPlaying(FPS3DSounds.Running, base.transform);
				if (!AudioManager.IsSoundPlaying(FPS3DSounds.Walk))
				{
					AudioManager.PlaySound(FPS3DSounds.Walk, base.transform);
				}
				breathTime = Mathf.Max(breathTime - Time.deltaTime, 0f);
				break;
			case MovementStates.Running:
				AudioManager.StopSoundIfPlaying(FPS3DSounds.Walk, base.transform);
				if (!AudioManager.IsSoundPlaying(FPS3DSounds.Running))
				{
					AudioManager.PlaySound(FPS3DSounds.Running, base.transform);
				}
				breathTime = Mathf.Min(breathTime + Time.deltaTime, sprintTimeToBreathe);
				break;
			}
			if (breathTime >= sprintTimeToBreathe)
			{
				if (!AudioManager.IsSoundPlaying(FPS3DSounds.Breathing, base.transform))
				{
					AudioManager.PlaySound(FPS3DSounds.Breathing, base.transform);
				}
			}
			else if (breathTime <= 0f)
			{
				AudioManager.StopSoundIfPlaying(FPS3DSounds.Breathing);
			}
		}

		private IEnumerator CrouchCooldown()
		{
			crouching = !crouching;
			animator.InvokeOnCrouch(crouching);
			canToggleCrouch = false;
			yield return new WaitForSeconds(0.15f);
			canToggleCrouch = true;
		}

		public Vector3 Gravity()
		{
			return gravity;
		}
	}
}
