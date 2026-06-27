using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_Scale : TweenSequenceElement_Transform_ScaleBase
	{
		public override Tween Tween => SetUpTween(targetTransform.DOScale(endValue, base.sequenceElementDuration));
	}
}
