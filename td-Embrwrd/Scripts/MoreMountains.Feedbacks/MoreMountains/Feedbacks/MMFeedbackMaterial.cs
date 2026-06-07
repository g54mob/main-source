using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Renderer/Material")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you change the material of the target renderer everytime it's played.")]
	public class MMFeedbackMaterial : MMFeedback
	{
		public enum Methods
		{
			Sequential = 0,
			Random = 1
		}

		[CompilerGenerated]
		private sealed class _003CTransitionMaterial_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackMaterial _003C_003E4__this;

			public Material originalMaterial;

			public Material newMaterial;

			public int materialIndex;

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
			public _003CTransitionMaterial_003Ed__25(int _003C_003E1__state)
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

		[Tooltip("the renderer to change material on")]
		[Header("Material")]
		public Renderer TargetRenderer;

		[FormerlySerializedAs("MaterialIndexes")]
		[Tooltip("the list of material indexes we want to change on the target renderer. If left empty, will only target the material at index 0")]
		public int[] RendererMaterialIndexes;

		[Tooltip("the selected method")]
		[Header("Material Change")]
		public Methods Method;

		[Tooltip("whether or not the sequential order should loop")]
		[MMFEnumCondition("Method", new int[] { 0 })]
		public bool Loop;

		[Tooltip("whether or not to always pick a new material in random mode")]
		[MMFEnumCondition("Method", new int[] { 1 })]
		public bool AlwaysNewMaterial;

		[Tooltip("the initial index to start with")]
		public int InitialIndex;

		[Tooltip("the list of materials to pick from")]
		public List<Material> Materials;

		[Header("Interpolation")]
		public bool InterpolateTransition;

		public float TransitionDuration;

		public AnimationCurve TransitionCurve;

		protected int _currentIndex;

		protected float _startedAt;

		protected Coroutine[] _coroutines;

		protected Material[] _tempMaterials;

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

		public virtual float GetTime()
		{
			return 0f;
		}

		public virtual float GetDeltaTime()
		{
			return 0f;
		}

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void ApplyMaterial(Material material)
		{
		}

		protected virtual void LerpMaterial(Material fromMaterial, Material toMaterial, float t, int materialIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionMaterial_003Ed__25))]
		protected virtual IEnumerator TransitionMaterial(Material originalMaterial, Material newMaterial, int materialIndex)
		{
			return null;
		}

		protected virtual int DetermineNextIndex()
		{
			return 0;
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
