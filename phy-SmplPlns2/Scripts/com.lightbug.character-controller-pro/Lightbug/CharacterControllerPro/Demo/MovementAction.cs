using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class MovementAction
	{
		[SerializeField]
		private bool enabled = true;

		[SerializeField]
		private bool useWorldCoordinates = true;

		[SerializeField]
		private bool infiniteDuration;

		[Min(0f)]
		[SerializeField]
		private float cycleDuration = 2f;

		[SerializeField]
		private bool waitAtTheEnd = true;

		[Min(0f)]
		[SerializeField]
		private float waitDuration = 1f;

		[SerializeField]
		private Vector3 direction = Vector3.up;

		[Min(0f)]
		[SerializeField]
		private float speed = 2f;

		private Transform transform;

		private Vector3 initialLocalDirection;

		private Vector3 actionVector = Vector3.zero;

		private float time;

		private bool isWaiting;

		public Vector3 ActionVector => actionVector;

		public void Initialize(Transform transform)
		{
			this.transform = transform;
			initialLocalDirection = transform.InverseTransformVectorUnscaled(direction);
		}

		public void Tick(float dt, ref Vector3 position)
		{
			if (!enabled)
			{
				return;
			}
			time += dt;
			if (isWaiting)
			{
				if (time >= waitDuration)
				{
					time = 0f;
					isWaiting = false;
				}
				actionVector = Vector3.zero;
			}
			else
			{
				if (!infiniteDuration && time >= cycleDuration)
				{
					time = 0f;
					if (useWorldCoordinates)
					{
						direction = -direction;
					}
					else
					{
						initialLocalDirection = -initialLocalDirection;
					}
					if (waitAtTheEnd)
					{
						isWaiting = true;
					}
				}
				if (isWaiting)
				{
					actionVector = Vector3.zero;
				}
				else
				{
					actionVector = CustomUtilities.Multiply(useWorldCoordinates ? direction : initialLocalDirection, speed, dt);
				}
			}
			position += actionVector;
		}

		public void ResetTimer()
		{
			time = 0f;
		}
	}
}
