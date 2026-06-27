using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_ScaleX : TweenSequenceElement_Transform_ScaleBase
	{
		public override Tween Tween => SetUpTween(targetTransform.DOScaleX(endValue, base.sequenceElementDuration));
	}
}
