using System;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public class Decayer
	{
		public float decaySpeed;

		public float magnitude;

		public AnimationCurve curve;

		[NonSerialized]
		public float value;

		[NonSerialized]
		public float valueInv;

		[NonSerialized]
		public float t;

		public void SetT(float v)
		{
			t = v;
		}

		public void Update()
		{
			t = Mathf.Max(0f, t - decaySpeed * Time.deltaTime);
			float num = ((curve.keys.Length != 0) ? curve.Evaluate(1f - t) : t);
			value = num * magnitude;
			valueInv = (1f - num) * magnitude;
		}
	}
}
