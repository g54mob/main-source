using System;
using FixMath;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public class ZoomParameters
	{
		public AnimationCurve velocity = new AnimationCurve();

		public Fix64 startSize = (Fix64)8L;

		public Fix64 endSize = (Fix64)20L;

		public Fix64 delayInDays = (Fix64)1L;

		public Fix64 durationInDays = (Fix64)69L;

		public Vector2 cameraEntryPosition = new Vector2(-100f, 0f);

		public Vector2 cameraEntrySplineHandle = new Vector2(-10f, 0f);
	}
}
