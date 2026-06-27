using System;
using DG.Tweening;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class FlipAnimationSettings
	{
		[Range(0f, 2f)]
		public float Duration = 0.8f;

		public Vector3 TargetRotation;

		public Vector3 TargetOffset;

		public Ease Ease = Ease.InCirc;
	}
}
