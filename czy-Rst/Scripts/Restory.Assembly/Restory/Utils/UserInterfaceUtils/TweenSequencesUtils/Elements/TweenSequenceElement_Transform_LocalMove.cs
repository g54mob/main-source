using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_LocalMove : TweenSequenceElement_Transform_MoveToTarget
	{
		public override Tween Tween => SetUpTween(transformToMove.DOLocalMove(base.targetPositionToUse, base.sequenceElementDuration));
	}
}
