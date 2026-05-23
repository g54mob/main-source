using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class ConstraintRotation : Constraint
	{
		public Quaternion rotation;

		public override void jsq()
		{
		}

		public ConstraintRotation()
		{
		}

		public ConstraintRotation(Transform transform)
		{
		}
	}
}
