using System;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public abstract class TweenSequenceElement_Transform_MoveToTarget : TweenSequenceElement_Transform_MoveBase
	{
		protected enum TargetType
		{
			Position = 0,
			Transform = 1
		}

		[SerializeField]
		protected TargetType targetType;

		[SerializeField]
		protected Vector3 targetPosition;

		[SerializeField]
		protected Transform targetTransformToMoveTo;

		protected Vector3 targetPositionToUse => targetType switch
		{
			TargetType.Position => targetPosition, 
			TargetType.Transform => targetTransformToMoveTo.position, 
			_ => default(Vector3), 
		};
	}
}
