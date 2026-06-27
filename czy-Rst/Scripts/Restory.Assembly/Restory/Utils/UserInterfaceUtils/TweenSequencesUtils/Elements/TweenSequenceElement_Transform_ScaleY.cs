using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_ScaleY : TweenSequenceElement_Transform_ScaleBase
	{
		public override Tween Tween => SetUpTween(targetTransform.DOScaleY(endValue, base.sequenceElementDuration));
	}
}
