using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors
{
	public class DraculaCutsceneTeleport : GameMonoBehaviour
	{
		public enum TeleportPosition
		{
			Throne = 0,
			Foreground = 1
		}

		[CompilerGenerated]
		private sealed class _003CColourTween_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpriteRenderer spriteRenderer;

			public Color startColour;

			public Color endColour;

			public float duration;

			private float _003Ctimer_003E5__2;

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
			public _003CColourTween_003Ed__31(int _003C_003E1__state)
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
		private sealed class _003CInnerColumnCoroutine_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutsceneTeleport _003C_003E4__this;

			public Action onScaleInComplete;

			private float _003Ctimer_003E5__2;

			private Vector3 _003CendScale_003E5__3;

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
			public _003CInnerColumnCoroutine_003Ed__28(int _003C_003E1__state)
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
		private sealed class _003COuterColumnCoroutine_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutsceneTeleport _003C_003E4__this;

			public Action onFadeToBlackComplete;

			public Action onComplete;

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
			public _003COuterColumnCoroutine_003Ed__29(int _003C_003E1__state)
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
		private sealed class _003CScaleTransform_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform transformToScale;

			public Vector3 startScale;

			public Vector3 endScale;

			public float duration;

			private float _003Ctimer_003E5__2;

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
			public _003CScaleTransform_003Ed__30(int _003C_003E1__state)
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
		private sealed class _003CWaitForSecondsPausable_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float seconds;

			private float _003Ctimer_003E5__2;

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
			public _003CWaitForSecondsPausable_003Ed__32(int _003C_003E1__state)
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

		[SerializeField]
		private Vector3 _ScaleAtThrone;

		[SerializeField]
		private Vector3 _ScaleInForeground;

		[SerializeField]
		private Vector3 _ThronePosition;

		[SerializeField]
		private Vector3 _ForeGroundPosition;

		[Header("Inner Column")]
		[SerializeField]
		private SpriteRenderer _InnerColumn;

		[Space]
		[SerializeField]
		private float _InnerColumnMoveInDuration;

		[SerializeField]
		private Vector3 _InnerColumnEndPosition;

		[Space]
		[SerializeField]
		private float _InnerColumnScaleInDuration;

		[SerializeField]
		private float _InnerColumnScaleInXScale;

		[Space]
		[SerializeField]
		private float _InnerColumnScaleOutDuration;

		[Header("Outer Column")]
		[SerializeField]
		private Transform _OuterColumnParent;

		[SerializeField]
		private SpriteRenderer _OuterColumn;

		[Space]
		[SerializeField]
		private float _OuterColumnScaleInDuration;

		[SerializeField]
		private float _OuterColumnScaleInYScale;

		[Space]
		[SerializeField]
		private float _OuterColumnAlphaInDuration;

		[SerializeField]
		private float _OuterColumnFadeToBlackDuration;

		[SerializeField]
		private float _OuterColumnWaitBeforeAlphaOut;

		[SerializeField]
		private float _OuterColumnAlphaOutDuration;

		private Vector3 _innerColumnStartPosition;

		private Vector3 _innerColumnStartScale;

		private Color _outerColumnStartColour;

		private const string GradientSpriteName = "Gradient2";

		private const string VfxTextureName = "vfx";

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Reset()
		{
		}

		public void PlayTeleportEffect(TeleportPosition position, Action onFadeToBlackComplete, Action onComplete)
		{
		}

		[IteratorStateMachine(typeof(_003CInnerColumnCoroutine_003Ed__28))]
		private IEnumerator InnerColumnCoroutine(Action onScaleInComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003COuterColumnCoroutine_003Ed__29))]
		private IEnumerator OuterColumnCoroutine(Action onFadeToBlackComplete, Action onComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CScaleTransform_003Ed__30))]
		private IEnumerator ScaleTransform(Transform transformToScale, Vector3 startScale, Vector3 endScale, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CColourTween_003Ed__31))]
		private IEnumerator ColourTween(SpriteRenderer spriteRenderer, Color startColour, Color endColour, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitForSecondsPausable_003Ed__32))]
		private IEnumerator WaitForSecondsPausable(float seconds)
		{
			return null;
		}
	}
}
