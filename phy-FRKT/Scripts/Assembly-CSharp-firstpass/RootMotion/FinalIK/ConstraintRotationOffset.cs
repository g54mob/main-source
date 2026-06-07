using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class ConstraintRotationOffset : Constraint
	{
		public Quaternion offset;

		private Quaternion tkv;

		private Quaternion tkw;

		private Quaternion tkx;

		private Quaternion tky;

		private bool tkz;

		private bool xpp => false;

		public override void jsq()
		{
		}

		public ConstraintRotationOffset()
		{
		}

		public ConstraintRotationOffset(Transform transform)
		{
		}
	}
}
