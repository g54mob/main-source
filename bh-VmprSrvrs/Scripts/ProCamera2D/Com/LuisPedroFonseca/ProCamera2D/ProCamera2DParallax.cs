using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-parallax/")]
	[ExecuteInEditMode]
	public class ProCamera2DParallax : BasePC2D, IPostMover
	{
		[CompilerGenerated]
		private sealed class _003CAnimate_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DParallax _003C_003E4__this;

			public float duration;

			public bool value;

			public EaseType easeType;

			private float[] _003CcurrentSpeeds_003E5__2;

			private float _003Ct_003E5__3;

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
			public _003CAnimate_003Ed__23(int _003C_003E1__state)
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

		public List<ProCamera2DParallaxLayer> ParallaxLayers;

		public bool ParallaxHorizontal;

		public bool ParallaxVertical;

		public bool ParallaxZoom;

		public Vector3 RootPosition;

		public int FrontDepthStart;

		public int BackDepthStart;

		public bool UseIndependentAxisSpeeds;

		public bool AutomaticallyConfigureCameraClearFlags;

		private float _initialOrtographicSize;

		private float[] _initialSpeeds;

		private Coroutine _animateCoroutine;

		private int _pmOrder;

		public int PMOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void PostMove(float deltaTime)
		{
		}

		public void CalculateParallaxObjectsOffset()
		{
		}

		private void Move()
		{
		}

		public void ToggleParallax(bool value, float duration = 2f, EaseType easeType = EaseType.EaseInOut)
		{
		}

		[IteratorStateMachine(typeof(_003CAnimate_003Ed__23))]
		private IEnumerator Animate(bool value, float duration, EaseType easeType)
		{
			return null;
		}
	}
}
