using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Feel
{
	[AddComponentMenu("")]
	public class GettingStartedTutorialHeroReference : MonoBehaviour
	{
		[Header("Hero Settings")]
		public KeyCode ActionKey = KeyCode.Space;

		public float JumpForce = 8f;

		[Header("Feedbacks")]
		public MMFeedbacks JumpFeedback;

		public MMFeedbacks LandingFeedback;

		[Header("Events")]
		public UnityEvent OnJump;

		public UnityEvent OnLand;

		private const float _lowVelocity = 0.1f;

		private Rigidbody _rigidbody;

		private float _velocityLastFrame;

		private bool _jumping;

		private void Awake()
		{
			_rigidbody = base.gameObject.GetComponent<Rigidbody>();
			Physics.gravity = Vector3.down * 30f;
		}

		private void Update()
		{
			if (FeelDemosInputHelper.CheckMainActionInputPressedThisFrame() && !_jumping)
			{
				Jump();
			}
			if (_jumping && _velocityLastFrame < 0f && Mathf.Abs(_rigidbody.linearVelocity.y) < 0.1f)
			{
				_jumping = false;
				LandingFeedback?.PlayFeedbacks();
				if (OnLand != null)
				{
					OnLand.Invoke();
				}
			}
			_velocityLastFrame = _rigidbody.linearVelocity.y;
		}

		private void Jump()
		{
			_rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
			_jumping = true;
			JumpFeedback?.PlayFeedbacks();
			if (OnJump != null)
			{
				OnJump.Invoke();
			}
		}
	}
}
