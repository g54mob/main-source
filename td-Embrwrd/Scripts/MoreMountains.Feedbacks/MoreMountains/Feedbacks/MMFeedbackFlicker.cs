using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Renderer/Flicker")]
	[FeedbackHelp("This feedback lets you flicker the color of a specified renderer (sprite, mesh, etc) for a certain duration, at the specified octave, and with the specified color. Useful when a character gets hit, for example (but so much more!).")]
	[AddComponentMenu(null)]
	public class MMFeedbackFlicker : MMFeedback
	{
		public enum Modes
		{
			Color = 0,
			PropertyName = 1
		}

		[CompilerGenerated]
		private sealed class _003CFlicker_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Renderer renderer;

			public MMFeedbackFlicker _003C_003E4__this;

			public int materialIndex;

			public Color initialColor;

			public Color flickerColor;

			public float flickerDuration;

			public float flickerSpeed;

			private float _003CflickerStop_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFlicker_003Ed__22(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Flicker")]
		[Tooltip("the renderer to flicker when played")]
		public Renderer BoundRenderer;

		[Tooltip("the selected mode to flicker the renderer")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the name of the property to target")]
		public string PropertyName;

		[Tooltip("the duration of the flicker when getting damage")]
		public float FlickerDuration;

		[Tooltip("the frequency at which to flicker")]
		public float FlickerOctave;

		[Tooltip("the color we should flicker the sprite to")]
		[ColorUsage(true, true)]
		public Color FlickerColor;

		[Tooltip("the list of material indexes we want to flicker on the target renderer. If left empty, will only target the material at index 0")]
		public int[] MaterialIndexes;

		[Tooltip("if this is true, this component will use material property blocks instead of working on an instance of the material.")]
		public bool UseMaterialPropertyBlocks;

		protected const string _colorPropertyName = "_Color";

		protected Color[] _initialFlickerColors;

		protected int[] _propertyIDs;

		protected bool[] _propertiesFound;

		protected Coroutine[] _coroutines;

		protected MaterialPropertyBlock _propertyBlock;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}

		[IteratorStateMachine(typeof(_003CFlicker_003Ed__22))]
		public virtual IEnumerator Flicker(Renderer renderer, int materialIndex, Color initialColor, Color flickerColor, float flickerSpeed, float flickerDuration)
		{
			return null;
		}

		protected virtual void SetColor(int materialIndex, Color color)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
