using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class ConstraintPosition : Constraint
	{
		public Vector3 position;

		public override void jsq()
		{
		}

		public ConstraintPosition()
		{
		}

		public ConstraintPosition(Transform transform)
		{
		}
	}
}
