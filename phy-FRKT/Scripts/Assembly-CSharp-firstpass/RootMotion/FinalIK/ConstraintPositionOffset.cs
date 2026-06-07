using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class ConstraintPositionOffset : Constraint
	{
		public Vector3 offset;

		private Vector3 tks;

		private Vector3 tkt;

		private bool tku;

		private bool xpo => false;

		public override void jsq()
		{
		}

		public ConstraintPositionOffset()
		{
		}

		public ConstraintPositionOffset(Transform transform)
		{
		}
	}
}
