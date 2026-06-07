using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class AnimQuaternion
	{
		private const float SMOOTH = 0.1f;

		public Quaternion Current { get; set; }

		public Quaternion Target { get; set; }

		public float Smooth { get; set; }

		public AnimQuaternion(Quaternion value, float smooth = 0.1f)
		{
			Current = value;
			Target = value;
			Smooth = smooth;
		}

		public AnimQuaternion(Quaternion value, Quaternion target, float smooth)
			: this(value, smooth)
		{
			Target = target;
		}

		public void UpdateWithDelta(float deltaTime)
		{
			Current = UpdateRotation(Current, Target, deltaTime);
		}

		public void UpdateWithDelta(Quaternion target, float deltaTime)
		{
			Target = target;
			UpdateWithDelta(deltaTime);
		}

		public void UpdateWithDelta(Quaternion target, float smooth, float deltaTime)
		{
			Smooth = smooth;
			UpdateWithDelta(target, deltaTime);
		}

		public void Update()
		{
			float deltaTime = Time.deltaTime;
			Current = UpdateRotation(Current, Target, deltaTime);
		}

		public void Update(Quaternion target)
		{
			Target = target;
			Update();
		}

		private Quaternion UpdateRotation(Quaternion from, Quaternion to, float deltaTime)
		{
			if (!(Smooth > 0.001f))
			{
				return to;
			}
			return Quaternion.RotateTowards(from, to, deltaTime / Smooth);
		}
	}
}
