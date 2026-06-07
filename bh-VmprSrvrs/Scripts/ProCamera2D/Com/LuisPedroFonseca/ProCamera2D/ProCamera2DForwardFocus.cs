using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-forward-focus/")]
	public class ProCamera2DForwardFocus : BasePC2D, IPreMover
	{
		[CompilerGenerated]
		private sealed class _003CEnable_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DForwardFocus _003C_003E4__this;

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
			public _003CEnable_003Ed__28(int _003C_003E1__state)
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

		private const float EPSILON = 0.001f;

		public bool Progressive;

		public float SpeedMultiplier;

		public float TransitionSmoothness;

		public bool MaintainInfluenceOnStop;

		public Vector2 MovementThreshold;

		[Range(0.001f, 0.5f)]
		public float LeftFocus;

		[Range(0.001f, 0.5f)]
		public float RightFocus;

		[Range(0.001f, 0.5f)]
		public float TopFocus;

		[Range(0.001f, 0.5f)]
		public float BottomFocus;

		private float _hVel;

		private float _hVelSmooth;

		private float _vVel;

		private float _vVelSmooth;

		private float _targetHVel;

		private float _targetVVel;

		private bool _isFirstHorizontalCameraMovement;

		private bool _isFirstVerticalCameraMovement;

		private bool __enabled;

		private int _prmOrder;

		public int PrMOrder
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

		public void PreMove(float deltaTime)
		{
		}

		public override void OnReset()
		{
		}

		[IteratorStateMachine(typeof(_003CEnable_003Ed__28))]
		private IEnumerator Enable()
		{
			return null;
		}

		private void ApplyInfluence(float deltaTime)
		{
		}
	}
}
