using System.Collections.Generic;

namespace TriLib
{
	public class AnimationChannelData
	{
		public string NodeName;

		public Dictionary<string, AnimationCurveData> CurveData;

		public void SetCurve(string propertyName, AnimationCurveData animationCurve)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
