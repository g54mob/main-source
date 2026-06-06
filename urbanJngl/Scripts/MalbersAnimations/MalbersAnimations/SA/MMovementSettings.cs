using System;
using UnityEngine;

namespace MalbersAnimations.SA
{
	[Serializable]
	public class MMovementSettings
	{
		public float ForwardSpeed = 8f;

		public float BackwardSpeed = 4f;

		public float StrafeSpeed = 4f;

		public float RunMultiplier = 2f;

		public InputRow RunKey = new InputRow("Shift", KeyCode.LeftShift, InputButton.Press);

		public float JumpForce = 30f;

		public AnimationCurve SlopeCurveModifier = new AnimationCurve(new Keyframe(-90f, 1f), new Keyframe(0f, 1f), new Keyframe(90f, 0f));

		[HideInInspector]
		public float CurrentTargetSpeed = 8f;

		private bool m_Running;

		public bool Running => m_Running;

		public void UpdateDesiredTargetSpeed(Vector2 input)
		{
			if (!(input == Vector2.zero))
			{
				if (input.x > 0f || input.x < 0f)
				{
					CurrentTargetSpeed = StrafeSpeed;
				}
				if (input.y < 0f)
				{
					CurrentTargetSpeed = BackwardSpeed;
				}
				if (input.y > 0f)
				{
					CurrentTargetSpeed = ForwardSpeed;
				}
				if (RunKey.GetValue)
				{
					CurrentTargetSpeed *= RunMultiplier;
					m_Running = true;
				}
				else
				{
					m_Running = false;
				}
			}
		}
	}
}
