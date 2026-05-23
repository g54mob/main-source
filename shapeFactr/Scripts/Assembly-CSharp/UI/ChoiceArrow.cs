using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DG.Tweening;
using UnityEngine;

namespace UI
{
	public class ChoiceArrow : MonoBehaviour
	{
		public enum ArrowDirection
		{
			None = 0,
			Upper = 1,
			Lower = 2,
			Right = 3,
			Left = 4,
			Named = 5
		}

		[Serializable]
		public struct ArrowObject
		{
			public ArrowDirection direction;

			public GameObject arrowObj;
		}

		public record initParam(ArrowDirection direction, Vector3? basePosition, float move = 5f, float duration = 0.5f, bool needChoice = false)
		{
			[CompilerGenerated]
			protected virtual Type EqualityContract
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
			}

			public ArrowDirection direction { get; set; }

			public Vector3? basePosition { get; set; }

			public float move { get; set; }

			public float duration { get; set; }

			public bool needChoice { get; set; }

			[CompilerGenerated]
			public override string ToString()
			{
				return null;
			}

			[CompilerGenerated]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				return false;
			}

			[CompilerGenerated]
			public virtual bool Equals(initParam? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected initParam(initParam original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out ArrowDirection direction, out Vector3? basePosition, out float move, out float duration, out bool needChoice)
			{
				direction = default(ArrowDirection);
				basePosition = null;
				move = default(float);
				duration = default(float);
				needChoice = default(bool);
			}
		}

		public List<ArrowObject> arrowObjects;

		public GameObject tweenTarget;

		public GameObject choiceImage;

		private Tween _tween;

		public void AnimationArrow(initParam param)
		{
		}
	}
}
