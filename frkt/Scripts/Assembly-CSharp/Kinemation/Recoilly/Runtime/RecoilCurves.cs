using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kinemation.Recoilly.Runtime
{
	[Serializable]
	public struct RecoilCurves
	{
		public VectorCurve semiRotCurve;

		public VectorCurve semiLocCurve;

		public VectorCurve autoRotCurve;

		public VectorCurve autoLocCurve;

		private List<AnimationCurve> _curves;

		public static float dao(AnimationCurve a)
		{
			return 0f;
		}
	}
}
