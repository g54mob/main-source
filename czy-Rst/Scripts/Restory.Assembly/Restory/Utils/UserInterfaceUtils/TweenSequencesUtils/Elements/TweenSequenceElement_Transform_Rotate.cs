using System;
using DG.Tweening;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_Rotate : TweenSequenceElement_Tween
	{
		protected static class TransformRotateStyle
		{
			public const string TransformRotateSettings = "Transform Rotation Settings";
		}

		[SerializeField]
		private Transform targetTransform;

		[SerializeField]
		private Vector3 endValue;

		[SerializeField]
		private RotateMode rotationMode;

		public override Tween Tween => SetUpTween(targetTransform.DORotate(endValue, base.sequenceElementDuration, rotationMode));
	}
}
