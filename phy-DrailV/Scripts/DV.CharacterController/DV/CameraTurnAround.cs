using DV.Interaction.Inputs;
using UnityEngine;

namespace DV
{
	public class CameraTurnAround : MonoBehaviour
	{
		private const float TIME_THRESHOLD = 0.2f;

		public CustomFirstPersonController controller;

		private float rotationValue;

		private float velocity;

		private bool shouldRotate;

		private bool latch;

		private bool flipDirection;

		private void Update()
		{
			if (Time.deltaTime != 0f)
			{
				UpdateShouldRotate();
				int num = (shouldRotate ? 180 : 0);
				float num2 = rotationValue;
				rotationValue = Mathf.SmoothDamp(rotationValue, num, ref velocity, 0.05f, float.MaxValue, Time.deltaTime);
				controller.RotateViewBy(Vector2.right * (rotationValue - num2) * (flipDirection ? 1 : (-1)));
				if (shouldRotate && Mathf.Approximately(rotationValue, 180f) && latch)
				{
					rotationValue = 0f;
					shouldRotate = false;
					latch = false;
					flipDirection = !flipDirection;
				}
			}
		}

		private void UpdateShouldRotate()
		{
			if (!InputManager.NewPlayer.GetButton(InputManager.Actions.TurnAround))
			{
				if (!latch)
				{
					shouldRotate = false;
				}
			}
			else if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.TurnAround))
			{
				if (!shouldRotate)
				{
					shouldRotate = true;
					latch = true;
				}
				else
				{
					latch = false;
				}
			}
			else if (InputManager.NewPlayer.GetAxisTimeActive(InputManager.Actions.TurnAround) > 0.20000000298023224)
			{
				latch = false;
			}
		}
	}
}
