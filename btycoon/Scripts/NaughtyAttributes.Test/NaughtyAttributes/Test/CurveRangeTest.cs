using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class CurveRangeTest : MonoBehaviour
	{
		[Serializable]
		public class CurveRangeNest1
		{
			[CurveRange(0f, 0f, 1f, 1f, EColor.Green)]
			public AnimationCurve curve;

			public CurveRangeNest2 nest2;
		}

		[Serializable]
		public class CurveRangeNest2
		{
			[CurveRange(0f, 0f, 5f, 5f, EColor.Blue)]
			public AnimationCurve curve;
		}

		[CurveRange(0f, 0f, 1f, 1f, EColor.Yellow)]
		public AnimationCurve[] curves;

		[CurveRange(-1f, -1f, 1f, 1f, EColor.Red)]
		public AnimationCurve curve;

		[CurveRange(EColor.Orange)]
		public AnimationCurve curve1;

		[CurveRange(0f, 0f, 10f, 10f, EColor.Clear)]
		public AnimationCurve curve2;

		public CurveRangeNest1 nest1;
	}
}
