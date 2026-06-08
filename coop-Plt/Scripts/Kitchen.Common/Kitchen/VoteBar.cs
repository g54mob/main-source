using System;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class VoteBar : MonoBehaviour
	{
		public Rectangle Bar1;

		public Rectangle Bar2;

		public TextMeshPro Text1;

		public TextMeshPro Text2;

		public int Target1;

		public int Target2;

		public float Progress;

		public float LastUpdateTime;

		public float MaxWidth;

		public int LastValue1;

		public int LastValue2;

		public float LastProgress;

		public AnimationCurve BarCurve;

		public AnimationCurve TextCurve;

		public void SetValues(int v1, int v2, float progress)
		{
			if (v1 != Target1 || v2 != Target2 || !(Math.Abs(progress - LastProgress) < 0.01f))
			{
				LastUpdateTime = Time.realtimeSinceStartup;
				Progress = 0.5f + progress * 0.5f;
				LastValue1 = Target1;
				LastValue2 = Target2;
				LastProgress = progress;
				Target1 = v1;
				Target2 = v2;
			}
		}

		public void SetColour1(Color c1)
		{
			Bar1.Color = c1;
		}

		public void SetColour2(Color c2)
		{
			Bar2.Color = c2;
		}

		private void Update()
		{
			float value = (Time.realtimeSinceStartup - LastUpdateTime) / 1f;
			value = Mathf.Clamp01(value);
			float width = GetWidth(LastValue1, LastValue2);
			float width2 = GetWidth(LastValue2, LastValue1);
			Bar1.Width = width + BarCurve.Evaluate(value) * (GetWidth(Target1, Target2) - width);
			Bar2.Width = width2 + BarCurve.Evaluate(value) * (GetWidth(Target2, Target1) - width2);
			Text1.text = Mathf.CeilToInt((float)LastValue1 + TextCurve.Evaluate(value) * (float)(Target1 - LastValue1)).ToString();
			Text2.text = Mathf.CeilToInt((float)LastValue2 + TextCurve.Evaluate(value) * (float)(Target2 - LastValue2)).ToString();
		}

		private float GetWidth(int value, int other)
		{
			if (value == 0 && other == 0)
			{
				return 0f;
			}
			return Mathf.Clamp(MaxWidth * (float)value / (float)Mathf.Max(value, other) * Progress, 0f, MaxWidth);
		}
	}
}
