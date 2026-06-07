using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-transitions-fx/")]
	public class ProCamera2DTransitionsFX : BasePC2D
	{
		[CompilerGenerated]
		private sealed class _003CTransitionRoutine_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTransitionsFX _003C_003E4__this;

			public float startValue;

			public Material material;

			public float endValue;

			public float delay;

			public float duration;

			public EaseType easeType;

			private float _003Ct_003E5__2;

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
			public _003CTransitionRoutine_003Ed__48(int _003C_003E1__state)
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

		public static string ExtensionName;

		public Action OnTransitionEnterStarted;

		public Action OnTransitionEnterEnded;

		public Action OnTransitionExitStarted;

		public Action OnTransitionExitEnded;

		public Action OnTransitionStarted;

		public Action OnTransitionEnded;

		private static ProCamera2DTransitionsFX _instance;

		public TransitionsFXShaders TransitionShaderEnter;

		public float DurationEnter;

		public float DelayEnter;

		public EaseType EaseTypeEnter;

		public Color BackgroundColorEnter;

		public TransitionFXSide SideEnter;

		public TransitionFXDirection DirectionEnter;

		[Range(2f, 128f)]
		public int BlindsEnter;

		public Texture TextureEnter;

		[Range(0f, 1f)]
		public float TextureSmoothingEnter;

		public TransitionsFXShaders TransitionShaderExit;

		public float DurationExit;

		public float DelayExit;

		public EaseType EaseTypeExit;

		public Color BackgroundColorExit;

		public TransitionFXSide SideExit;

		public TransitionFXDirection DirectionExit;

		[Range(2f, 128f)]
		public int BlindsExit;

		public Texture TextureExit;

		[Range(0f, 1f)]
		public float TextureSmoothingExit;

		public bool StartSceneOnEnterState;

		private Coroutine _transitionCoroutine;

		private float _step;

		private Material _transitionEnterMaterial;

		private Material _transitionExitMaterial;

		private BasicBlit _blit;

		private int _material_StepID;

		private int _material_BackgroundColorID;

		private string _previousEnterShader;

		private string _previousExitShader;

		public static ProCamera2DTransitionsFX Instance => null;

		protected override void Awake()
		{
		}

		public void TransitionEnter()
		{
		}

		public void TransitionExit()
		{
		}

		public void UpdateTransitionsShaders()
		{
		}

		public void UpdateTransitionsProperties()
		{
		}

		public void UpdateTransitionsColor()
		{
		}

		public void Clear()
		{
		}

		private void Transition(Material material, float duration, float delay, float startValue, float endValue, EaseType easeType)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionRoutine_003Ed__48))]
		private IEnumerator TransitionRoutine(Material material, float duration, float delay, float startValue, float endValue, EaseType easeType)
		{
			return null;
		}
	}
}
