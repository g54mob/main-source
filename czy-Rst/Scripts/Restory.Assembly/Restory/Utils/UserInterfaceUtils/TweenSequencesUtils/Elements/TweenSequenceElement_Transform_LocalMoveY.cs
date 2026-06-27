using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_LocalMoveY : TweenSequenceElement_Transform_MoveByAxis
	{
		public override Tween Tween => SetUpTween(transformToMove.DOLocalMoveY(targetCoordinateValue, base.sequenceElementDuration));
	}
}
