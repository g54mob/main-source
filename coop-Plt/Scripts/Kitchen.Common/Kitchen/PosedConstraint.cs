using System.Collections.Generic;
using KitchenData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen
{
	public class PosedConstraint : SerializedMonoBehaviour
	{
		public Transform ConstraintTarget;

		public Dictionary<ToolAttachPoint, Transform> Transforms;

		public bool ParentMode;

		public void SetPose(ToolAttachPoint pose)
		{
			if (!Transforms.TryGetValue(pose, out var value))
			{
				value = Transforms[ToolAttachPoint.Generic];
			}
			if (ParentMode)
			{
				ConstraintTarget.parent = value;
				ConstraintTarget.Reset();
			}
			else
			{
				ConstraintTarget.localPosition = value.localPosition;
				ConstraintTarget.localRotation = value.localRotation;
			}
		}
	}
}
