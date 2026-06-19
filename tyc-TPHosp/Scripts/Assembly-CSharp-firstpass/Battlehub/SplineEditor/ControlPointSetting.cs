using System;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public struct ControlPointSetting
	{
		public Twist Twist;

		public Thickness Thickness;

		public SplineBranch[] Branches;

		public ControlPointSetting(Twist twist, Thickness thickness, SplineBranch[] connections)
		{
			Twist = twist;
			Thickness = thickness;
			Branches = connections;
		}

		public ControlPointSetting(Twist twist, Thickness thickness)
		{
			Twist = twist;
			Thickness = thickness;
			Branches = null;
		}
	}
}
