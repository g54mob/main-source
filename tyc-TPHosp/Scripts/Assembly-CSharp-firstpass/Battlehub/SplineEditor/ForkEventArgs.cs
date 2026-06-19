using System;
using System.Collections.Generic;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public class ForkEventArgs
	{
		private SplineBase[] m_branches;

		private SplineBase m_spline;

		private int m_nextCurveIndex;

		public SplineBase[] Branches => m_branches;

		public SplineBase Spline => m_spline;

		public int NextCurveIndex => m_nextCurveIndex;

		public int SelectBranchIndex { get; set; }

		public ForkEventArgs(SplineBase spline, int pointIndex)
		{
			m_spline = spline;
			m_nextCurveIndex = pointIndex / 3;
			SplineBranch[] branches = spline.GetBranches(pointIndex);
			if (branches == null || branches.Length == 0)
			{
				m_branches = new SplineBase[0];
			}
			else
			{
				List<SplineBase> list = new List<SplineBase>();
				for (int i = 0; i < branches.Length; i++)
				{
					SplineBranch branch = branches[i];
					if (!branch.Inbound)
					{
						list.Add(spline.BranchToSpline(branch));
					}
				}
				m_branches = list.ToArray();
			}
			if (m_nextCurveIndex >= spline.CurveCount)
			{
				if (m_branches.Length != 0)
				{
					SelectBranchIndex = 0;
				}
				SelectBranchIndex = -1;
				m_nextCurveIndex = -1;
			}
			else
			{
				SelectBranchIndex = -1;
			}
		}
	}
}
