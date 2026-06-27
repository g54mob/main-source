using System;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public abstract class TweenSequenceElement_Transform_ScaleBase : TweenSequenceElement_Tween
	{
		protected static class TransformScaleStyle
		{
			public const string TransformScaleSettings = "Transform Scaling Settings";
		}

		[SerializeField]
		protected Transform targetTransform;

		[SerializeField]
		protected float endValue;
	}
}
