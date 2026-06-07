using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class RotationAction
	{
		[SerializeField]
		private bool enabled = true;

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

		[SerializeField]
		private Transform pivotObject;

		private Transform transform;

		private Vector3 actionVector = Vector3.zero;

		private float time;

		private bool isWaiting;

		public Vector3 ActionVector => actionVector;

		public void Initialize(Transform transform)
		{
			this.transform = transform;
		}

		public void Tick(float dt, ref Vector3 position, ref Quaternion rotation)
		{
			if (!enabled)
			{
				return;
			}
			time += dt;
			if (isWaiting)
			{
				if (time > waitDuration)
				{
					time = 0f;
					isWaiting = false;
				}
				actionVector = Vector3.zero;
			}
			else
			{
				if (!infiniteDuration && time > cycleDuration)
				{
					time = 0f;
					direction = -direction;
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
					actionVector = CustomUtilities.Multiply(direction, speed, dt);
				}
			}
			if (pivotObject != null)
			{
				RotateAround(ref position, ref rotation, dt);
			}
			else
			{
				rotation *= Quaternion.AngleAxis(speed * dt, direction);
			}
		}

		private void RotateAround(ref Vector3 position, ref Quaternion rotation, float dt)
		{
			Vector3 vector = position - pivotObject.position;
			Quaternion quaternion = Quaternion.AngleAxis(speed * dt, direction);
			vector = quaternion * vector;
			position = pivotObject.position + vector;
			rotation *= quaternion;
		}

		public void ResetTimer()
		{
			time = 0f;
		}
	}
}
