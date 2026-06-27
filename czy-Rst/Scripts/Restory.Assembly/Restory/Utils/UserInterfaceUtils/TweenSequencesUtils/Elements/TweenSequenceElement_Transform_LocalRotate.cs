using System;
using DG.Tweening;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Transform_LocalRotate : TweenSequenceElement_Tween
	{
		protected static class TransformRotateStyle
		{
			public const string TransformRotateSettings = "Transform Local Rotation Settings";
		}

		[SerializeField]
		private Transform targetTransform;

		[SerializeField]
		private Vector3 endValue;

		[SerializeField]
		private RotateMode rotationMode;

		public override Tween Tween => SetUpTween(targetTransform.DOLocalRotate(endValue, base.sequenceElementDuration, rotationMode));
	}
}
