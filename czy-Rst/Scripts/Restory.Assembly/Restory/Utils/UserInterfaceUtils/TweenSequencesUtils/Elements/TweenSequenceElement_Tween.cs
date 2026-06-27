using System;
using DG.Tweening;
using Mandragora.Utils;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public abstract class TweenSequenceElement_Tween : TweenSequenceElement
	{
		private static class TweenStyle
		{
			public const string GeneralTweenSettings = "General Tween Settings";

			public const string Loops = "General Tween Settings/Loops";
		}

		public enum TweenSequencingType
		{
			Append = 0,
			Insert = 1,
			Join = 2
		}

		[SerializeField]
		protected Ease ease = Ease.Linear;

		[SerializeField]
		private TweenSequencingType sequencingType;

		[SerializeField]
		private float insertPosition;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setTweenLoops;

		[SerializeField]
		private int loops;

		[SerializeField]
		private LoopType loopType;

		public abstract Tween Tween { get; }

		public override Sequence AddToSequence(Sequence sequence)
		{
			return sequencingType switch
			{
				TweenSequencingType.Append => sequence.Append(Tween), 
				TweenSequencingType.Insert => sequence.Insert(insertPosition, Tween), 
				TweenSequencingType.Join => sequence.Join(Tween), 
				_ => throw new NotImplementedException(), 
			};
		}

		protected Tween SetUpTween(Tween tween)
		{
			tween.SetEase(ease);
			if (setTweenLoops)
			{
				tween.SetLoops(loops, loopType);
			}
			return tween;
		}
	}
}
