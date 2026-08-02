using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic
{
	public class CurveData
	{
		public List<CurveKeyframeData> keys;

		public CurveData()
		{
		}

		public CurveData(List<CurveKeyframeData> keys)
		{
		}

		public Curve CreateCurve()
		{
			return null;
		}

		public static CurveData FromAnimationCurve(AnimationCurve curve)
		{
			return null;
		}
	}
}
