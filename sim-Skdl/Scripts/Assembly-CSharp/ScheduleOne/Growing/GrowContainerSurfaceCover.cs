using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Growing
{
	public class GrowContainerSurfaceCover : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CApplyPourOverTime_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GrowContainerSurfaceCover _003C_003E4__this;

			private Color[] _003Cpixels_003E5__2;

			private float _003CelapasedTime_003E5__3;

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
			public _003CApplyPourOverTime_003Ed__44(int _003C_003E1__state)
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
		private sealed class _003CCheckQueue_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GrowContainerSurfaceCover _003C_003E4__this;

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
			public _003CCheckQueue_003Ed__40(int _003C_003E1__state)
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

		public const int TextureSize = 128;

		public const int PourRadius = 32;

		public const int UpdatesPerSecond = 24;

		public const float CoveredPixelThreshold = 0.8f;

		public const float Delay = 0.35f;

		[Header("Settings")]
		public float SuccessfulCoverageThreshold;

		[Header("References")]
		public GrowContainer GrowContainer;

		public MeshRenderer MeshRenderer;

		public Texture2D PourMask;

		[SerializeField]
		[Header("Pour Over time Settings")]
		private float _applyPoutOverTimeDuration;

		[SerializeField]
		private AnimationCurve _applyPoutOverTimeCurve;

		public UnityEvent onSufficientCoverage;

		private bool queued;

		private Vector3 queuedWorldPos;

		private Texture2D mainTex;

		private Texture2D tempTex;

		private Vector3 relative;

		private Vector2 vector2;

		private Vector2 normalizedOffset;

		private Vector2 originPixel;

		private float _pourApplicationStrength;

		public float CurrentCoverage { get; private set; }

		public float PourApplicationStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool UseApplyOverTime { get; set; }

		private float _sideLength => 0f;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void ConfigureAppearance(Color col, float transparency)
		{
		}

		public void Reset()
		{
		}

		public void QueuePour(Vector3 worldSpacePosition)
		{
		}

		public float GetNormalizedProgress()
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CCheckQueue_003Ed__40))]
		private IEnumerator CheckQueue()
		{
			return null;
		}

		private void Blank()
		{
		}

		private void DelayedApplyPour(Vector3 worldSpace)
		{
		}

		private void ApplyPour(Vector3 worldSpace, bool applyOverTime = false)
		{
		}

		[IteratorStateMachine(typeof(_003CApplyPourOverTime_003Ed__44))]
		private IEnumerator ApplyPourOverTime()
		{
			return null;
		}

		private float GetPourMaskValue(int x, int y)
		{
			return 0f;
		}

		private float GetCoverage()
		{
			return 0f;
		}
	}
}
