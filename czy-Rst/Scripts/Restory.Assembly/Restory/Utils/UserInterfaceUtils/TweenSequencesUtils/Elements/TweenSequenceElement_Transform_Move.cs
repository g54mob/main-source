using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_Move : TweenSequenceElement_Transform_MoveToTarget
	{
		public override Tween Tween => SetUpTween(transformToMove.DOMove(base.targetPositionToUse, base.sequenceElementDuration));
	}
}
