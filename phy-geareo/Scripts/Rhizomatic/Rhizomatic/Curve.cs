using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic
{
	[Serializable]
	public class Curve
	{
		public List<CurveKeyframe> keys;

		public AnimationCurve _curve;

		private bool dirty;

		public AnimationCurve GetCurve()
		{
			return null;
		}

		public void Load(CurveData data)
		{
		}

		public CurveData Save()
		{
			return null;
		}

		public void BringToFirst(CurvePoint point)
		{
		}

		public void AddKey(CurveKeyframe key)
		{
		}

		public void RemoveKey(CurveKeyframe Key)
		{
		}

		public void SetDirty()
		{
		}
	}
}
