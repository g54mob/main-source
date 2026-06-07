using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace FractureField.Rocks
{
	public class RockController : RComponent
	{
		[CompilerGenerated]
		private sealed class _003CAnimateHighlight_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool highlight;

			public RockController _003C_003E4__this;

			private Vector3 _003CtargetScale_003E5__2;

			private Vector3 _003CstartScale_003E5__3;

			private float _003Cduration_003E5__4;

			private float _003Celapsed_003E5__5;

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
			public _003CAnimateHighlight_003Ed__38(int _003C_003E1__state)
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
		private sealed class _003CHitEffect_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RockController _003C_003E4__this;

			private Vector3 _003CoriginalPos_003E5__2;

			private float _003CshakeDuration_003E5__3;

			private float _003CshakeAmount_003E5__4;

			private float _003Celapsed_003E5__5;

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
			public _003CHitEffect_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CNextLayerEffect_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RockController _003C_003E4__this;

			private float _003Cduration_003E5__2;

			private float _003Celapsed_003E5__3;

			private Vector3 _003CoriginalScale_003E5__4;

			private Color _003CoriginalColor_003E5__5;

			private Vector3 _003CoriginalShadowScale_003E5__6;

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
			public _003CNextLayerEffect_003Ed__35(int _003C_003E1__state)
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
		private sealed class _003CSpawnAnimation_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RockController _003C_003E4__this;

			private Vector3 _003CstartPos_003E5__2;

			private Vector3 _003CtargetPos_003E5__3;

			private Color _003CrockColor_003E5__4;

			private Color _003CshadowColor_003E5__5;

			private float _003Celapsed_003E5__6;

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
			public _003CSpawnAnimation_003Ed__36(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		private SortingGroup _sortingGroup;

		public SpriteRenderer rockSprite;

		public SpriteRenderer shadowSprite;

		public GameObject healthBarGO;

		public Image healthBarBackground;

		public Image healthBarFill;

		public SpriteRenderer bombTargetSprite;

		public CircleCollider2D _collider;

		[Header("Highlight")]
		public float highlightScale;

		[Header("Spawn Animation")]
		public float spawnDuration;

		public AnimationCurve spawnScaleCurve;

		public AnimationCurve spawnAlphaCurve;

		public float spawnBounceHeight;

		private bool _isHighlighted;

		private Vector3 _originalScale;

		private Vector3 _originalRockScale;

		private Coroutine _highlightCoroutine;

		private Coroutine _hitEffectCoroutine;

		private Coroutine _nextLayerEffectCoroutine;

		private RockLayerType _previousLayerType;

		public Rock Rock { get; private set; }

		protected override void Awake()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Cleanup()
		{
		}

		private void OnRockDestroyed()
		{
		}

		public void Initialize(Rock rock)
		{
		}

		private void UpdateVisuals()
		{
		}

		private void UpdateHealthBar()
		{
		}

		private void UpdateSortingOrder()
		{
		}

		public void OnRockHit()
		{
		}

		[IteratorStateMachine(typeof(_003CHitEffect_003Ed__34))]
		private IEnumerator HitEffect()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CNextLayerEffect_003Ed__35))]
		private IEnumerator NextLayerEffect()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSpawnAnimation_003Ed__36))]
		private IEnumerator SpawnAnimation()
		{
			return null;
		}

		public void SetHovered(bool hovered)
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateHighlight_003Ed__38))]
		private IEnumerator AnimateHighlight(bool highlight)
		{
			return null;
		}

		public void SetBombTargeted(bool targeted)
		{
		}

		private void StopAnimationCoroutines()
		{
		}
	}
}
