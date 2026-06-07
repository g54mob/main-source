using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-cinematics/")]
	public class ProCamera2DCinematics : BasePC2D, IPositionOverrider, ISizeOverrider
	{
		[CompilerGenerated]
		private sealed class _003CEndCinematicRoutine_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DCinematics _003C_003E4__this;

			private float _003CinitialPosH_003E5__2;

			private float _003CinitialPosV_003E5__3;

			private float _003CcurrentCameraSize_003E5__4;

			private float _003Ct_003E5__5;

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
			public _003CEndCinematicRoutine_003Ed__50(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CGoToCinematicTargetRoutine_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CinematicTarget cinematicTarget;

			public ProCamera2DCinematics _003C_003E4__this;

			public int targetIndex;

			private float _003CinitialPosH_003E5__2;

			private float _003CinitialPosV_003E5__3;

			private float _003CcurrentCameraSize_003E5__4;

			private float _003Ct_003E5__5;

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
			public _003CGoToCinematicTargetRoutine_003Ed__49(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CStartCinematicRoutine_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DCinematics _003C_003E4__this;

			private int _003Ccount_003E5__2;

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
			public _003CStartCinematicRoutine_003Ed__48(int _003C_003E1__state)
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

		public UnityEvent OnCinematicStarted;

		public CinematicEvent OnCinematicTargetReached;

		public UnityEvent OnCinematicFinished;

		private bool _isPlaying;

		public List<CinematicTarget> CinematicTargets;

		public float EndDuration;

		public EaseType EndEaseType;

		public bool UseNumericBoundaries;

		public bool UseLetterbox;

		[Range(0f, 0.5f)]
		public float LetterboxAmount;

		public float LetterboxAnimDuration;

		public Color LetterboxColor;

		private float _initialCameraSize;

		private ProCamera2DNumericBoundaries _numericBoundaries;

		private bool _numericBoundariesPreviousState;

		private ProCamera2DLetterbox _letterbox;

		private Coroutine _startCinematicRoutine;

		private Coroutine _goToCinematicRoutine;

		private Coroutine _endCinematicRoutine;

		private bool _skipTarget;

		private Vector3 _newPos;

		private Vector3 _originalPos;

		private Vector3 _startPos;

		private float _newSize;

		private bool _paused;

		private int _poOrder;

		private int _soOrder;

		public bool IsPlaying => false;

		public int POOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SOOrder
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

		public Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
		{
			return default(Vector3);
		}

		public float OverrideSize(float deltaTime, float originalSize)
		{
			return 0f;
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		public void Toggle()
		{
		}

		public void GoToNextTarget()
		{
		}

		public void Pause()
		{
		}

		public void Unpause()
		{
		}

		public void AddCinematicTarget(Transform targetTransform, float easeInDuration = 1f, float holdDuration = 1f, float zoom = 1f, EaseType easeType = EaseType.EaseOut, string sendMessageName = "", string sendMessageParam = "", int index = -1)
		{
		}

		public void RemoveCinematicTarget(Transform targetTransform)
		{
		}

		[IteratorStateMachine(typeof(_003CStartCinematicRoutine_003Ed__48))]
		private IEnumerator StartCinematicRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGoToCinematicTargetRoutine_003Ed__49))]
		private IEnumerator GoToCinematicTargetRoutine(CinematicTarget cinematicTarget, int targetIndex)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEndCinematicRoutine_003Ed__50))]
		private IEnumerator EndCinematicRoutine()
		{
			return null;
		}

		private void SetupLetterbox()
		{
		}

		private void LimitToNumericBoundaries(ref float horizontalPos, ref float verticalPos)
		{
		}
	}
}
