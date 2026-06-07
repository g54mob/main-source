using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class AnimColor
	{
		private const float SMOOTH = 0.1f;

		public Color Current { get; set; }

		public Color Target { get; set; }

		public Vector3 SmoothRGB { get; set; }

		public float SmoothAlpha { get; set; }

		public AnimColor(Color value, float smooth = 0.1f)
		{
			Current = value;
			Target = value;
			SmoothRGB = Vector3.one * smooth;
			SmoothAlpha = smooth;
		}

		public AnimColor(Color value, Color target, float smooth)
			: this(value, smooth)
		{
			Target = target;
		}

		public void UpdateWithDelta(float deltaTime)
		{
			Current = new Color(UpdateAxis(Current.r, Target.r, SmoothRGB.x, deltaTime), UpdateAxis(Current.g, Target.g, SmoothRGB.y, deltaTime), UpdateAxis(Current.b, Target.b, SmoothRGB.z, deltaTime), UpdateAxis(Current.a, Target.a, SmoothAlpha, deltaTime));
		}

		public void UpdateWithDelta(Color target, float deltaTime)
		{
			Target = target;
			UpdateWithDelta(deltaTime);
		}

		public void UpdateWithDelta(Color target, float smooth, float deltaTime)
		{
			SmoothRGB = Vector3.one * smooth;
			SmoothAlpha = smooth;
			UpdateWithDelta(target, deltaTime);
		}

		public void Update()
		{
			float deltaTime = Time.deltaTime;
			Current = new Color(UpdateAxis(Current.r, Target.r, SmoothRGB.x, deltaTime), UpdateAxis(Current.g, Target.g, SmoothRGB.y, deltaTime), UpdateAxis(Current.b, Target.b, SmoothRGB.z, deltaTime), UpdateAxis(Current.a, Target.a, SmoothAlpha, deltaTime));
		}

		public void Update(Color target)
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
