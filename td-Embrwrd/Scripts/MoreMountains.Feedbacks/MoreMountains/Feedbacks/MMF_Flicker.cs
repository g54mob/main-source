using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Renderer/Flicker")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you flicker the color of a specified renderer (sprite, mesh, etc) for a certain duration, at the specified octave, and with the specified color. Useful when a character gets hit, for example (but so much more!).")]
	public class MMF_Flicker : MMF_Feedback
	{
		public enum Modes
		{
			Color = 0,
			PropertyName = 1
		}

		[CompilerGenerated]
		private sealed class _003CFlicker_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Renderer renderer;

			public MMF_Flicker _003C_003E4__this;

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
			public _003CFlicker_003Ed__31(int _003C_003E1__state)
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

		[Tooltip("the renderer to flicker when played")]
		[MMFInspectorGroup("Flicker", true, 61, true, false)]
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

		[ColorUsage(true, true)]
		[Tooltip("the color we should flicker the sprite to")]
		public Color FlickerColor;

		[Tooltip("the list of material indexes we want to flicker on the target renderer. If left empty, will only target the material at index 0")]
		public int[] MaterialIndexes;

		[Tooltip("if this is true, this component will use material property blocks instead of working on an instance of the material.")]
		public bool UseMaterialPropertyBlocks;

		[MMCondition("UseMaterialPropertyBlocks", true)]
		[Tooltip("if using material property blocks on a sprite renderer, you'll want to make sure the sprite texture gets passed to the block when updating it. For that, you need to specify your sprite's material's shader's texture property name. If you're not working with a sprite renderer, you can safely ignore this.")]
		public string SpriteRendererTextureProperty;

		protected const string _colorPropertyName = "_Color";

		protected Color[] _initialFlickerColors;

		protected int[] _propertyIDs;

		protected bool[] _propertiesFound;

		protected Coroutine[] _coroutines;

		protected MaterialPropertyBlock _propertyBlock;

		protected SpriteRenderer _spriteRenderer;

		protected Texture2D _spriteRendererTexture;

		protected bool _spriteRendererIsNull;

		public override bool HasAutomatedTargetAcquisition => false;

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

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}

		protected virtual void StoreSpriteRendererTexture()
		{
		}

		protected virtual void SetStoredSpriteRendererTexture(MaterialPropertyBlock block)
		{
		}

		[IteratorStateMachine(typeof(_003CFlicker_003Ed__31))]
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

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
