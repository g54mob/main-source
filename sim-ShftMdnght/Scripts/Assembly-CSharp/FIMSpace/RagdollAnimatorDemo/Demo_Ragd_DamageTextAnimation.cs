using System;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_DamageTextAnimation : MonoBehaviour
	{
		public Vector3 OffsetPos = new Vector3(0f, 20f, 0f);

		public float Duration = 0.6f;

		public float DestroyAfter = 1.4f;

		private Vector3 StartPos;

		private float elapsed;

		private void Start()
		{
			StartPos = base.transform.position;
		}

		private void Update()
		{
			elapsed += Time.deltaTime;
			base.transform.position = Vector3.LerpUnclamped(StartPos, StartPos + OffsetPos, EaseOutElastic(0f, 1f, Mathf.Min(1f, elapsed / Duration)));
			if (elapsed > DestroyAfter)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public static float EaseOutElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num) == 1f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 * 0.25f;
			}
			else
			{
				num4 = num2 / (MathF.PI * 2f) * Mathf.Asin(end / num3);
			}
			return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * num - num4) * (MathF.PI * 2f) / num2) + end + start;
		}
	}
}
