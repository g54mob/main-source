using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class AnimVector3
	{
		private const float SMOOTH = 0.1f;

		public Vector3 Current { get; set; }

		public Vector3 Target { get; set; }

		public Vector3 Smooth { get; set; }

		public AnimVector3(Vector3 value, float smooth = 0.1f)
		{
			Current = value;
			Target = value;
			Smooth = Vector3.one * smooth;
		}

		public AnimVector3(Vector3 value, Vector3 target, float smooth)
			: this(value, smooth)
		{
			Target = target;
		}

		public void UpdateWithDelta(float deltaTime)
		{
			Current = new Vector3(UpdateAxis(Current.x, Target.x, Smooth.x, deltaTime), UpdateAxis(Current.y, Target.y, Smooth.y, deltaTime), UpdateAxis(Current.z, Target.z, Smooth.z, deltaTime));
		}

		public void UpdateWithDelta(Vector3 target, float deltaTime)
		{
			Target = target;
			UpdateWithDelta(deltaTime);
		}

		public void UpdateWithDelta(Vector3 target, Vector3 smooth, float deltaTime)
		{
			Smooth = smooth;
			UpdateWithDelta(target, deltaTime);
		}

		public void Update()
		{
			float deltaTime = Time.deltaTime;
			Current = new Vector3(UpdateAxis(Current.x, Target.x, Smooth.x, deltaTime), UpdateAxis(Current.y, Target.y, Smooth.y, deltaTime), UpdateAxis(Current.z, Target.z, Smooth.z, deltaTime));
		}

		public void Update(Vector3 target)
		{
			Target = target;
			Update();
		}

		private float UpdateAxis(float current, float target, float smooth, float deltaTime)
		{
			if (smooth <= 0.001f)
			{
				return target;
			}
			float num = Math.Sign(target - current);
			current += deltaTime * num / smooth;
			if (num <= 0f)
			{
				current = Math.Max(current, target);
			}
			if (num >= 0f)
			{
				current = Math.Min(current, target);
			}
			return current;
		}
	}
}
