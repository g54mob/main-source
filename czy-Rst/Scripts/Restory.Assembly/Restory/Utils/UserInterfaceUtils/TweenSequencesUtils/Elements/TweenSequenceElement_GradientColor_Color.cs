using System;
using AppsTools;
using DG.Tweening;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_GradientColor_Color : TweenSequenceElement_Tween
	{
		protected static class GradientColorStyle
		{
			public const string GradientColorSettings = "Gradient Color Settings";
		}

		[SerializeField]
		private GradientColor gradientColor;

		[SerializeField]
		private Color endColorTop = Color.white;

		[SerializeField]
		private Color endColorBottom = Color.white;

		[SerializeField]
		private Color endColorLeft = Color.white;

		[SerializeField]
		private Color endColorRight = Color.white;

		[SerializeField]
		[Range(-1f, 1f)]
		private float endGradientOffsetVertical;

		[SerializeField]
		[Range(-1f, 1f)]
		private float endGradientOffsetHorizontal;

		public override Tween Tween
		{
			get
			{
				Sequence sequence = DOTween.Sequence();
				sequence.Append(DOTween.To(() => gradientColor.colorTop, delegate(Color x)
				{
					gradientColor.colorTop = x;
				}, endColorTop, base.sequenceElementDuration)).Join(DOTween.To(() => gradientColor.colorBottom, delegate(Color x)
				{
					gradientColor.colorBottom = x;
				}, endColorBottom, base.sequenceElementDuration)).Join(DOTween.To(() => gradientColor.colorLeft, delegate(Color x)
				{
					gradientColor.colorLeft = x;
				}, endColorLeft, base.sequenceElementDuration))
					.Join(DOTween.To(() => gradientColor.colorRight, delegate(Color x)
					{
						gradientColor.colorRight = x;
					}, endColorRight, base.sequenceElementDuration))
					.Join(DOTween.To(() => gradientColor.gradientOffsetVertical, delegate(float x)
					{
						gradientColor.gradientOffsetVertical = x;
					}, endGradientOffsetVertical, base.sequenceElementDuration))
					.Join(DOTween.To(() => gradientColor.gradientOffsetHorizontal, delegate(float x)
					{
						gradientColor.gradientOffsetHorizontal = x;
					}, endGradientOffsetHorizontal, base.sequenceElementDuration));
				return SetUpTween(sequence);
			}
		}
	}
}
