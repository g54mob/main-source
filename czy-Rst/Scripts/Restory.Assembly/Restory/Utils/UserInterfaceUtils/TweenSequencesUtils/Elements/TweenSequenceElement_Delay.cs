using System;
using DG.Tweening;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Delay : TweenSequenceElement
	{
		public override Sequence AddToSequence(Sequence sequence)
		{
			return sequence.AppendInterval(base.sequenceElementDuration);
		}
	}
}
