using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class MobileConfig : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CApplyRoutine_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MobileConfig _003C_003E4__this;

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
			public _003CApplyRoutine_003Ed__33(int _003C_003E1__state)
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
		private bool _DEBUGTHIS;

		[SerializeField]
		private bool _ShouldDisableInPortrait;

		[SerializeField]
		private bool _ShouldDisableInLandscape;

		[SerializeField]
		protected bool _ShouldReparent;

		[SerializeField]
		protected bool _StealChildren;

		[SerializeField]
		protected bool _WaitForFormatBeforeScaling;

		[SerializeField]
		protected RectTransform _NewParent;

		[SerializeField]
		protected bool _SetAsFirstSibling;

		[SerializeField]
		protected bool _MatchSize;

		[SerializeField]
		protected bool _ForcePositionReset;

		[SerializeField]
		protected List<RectTransform> _ChildrenToSteal;

		[SerializeField]
		protected bool _ShouldScaleToFitWidth;

		[SerializeField]
		protected bool _ShouldForceRectTransformSize;

		[SerializeField]
		protected Vector2 _ForcedSize;

		[SerializeField]
		protected bool _ShouldAnchorPosFromRelativePosition;

		[SerializeField]
		protected Vector2 _RelativeAnchorPosition;

		[SerializeField]
		protected bool _ShouldExtendRectTransformToFillScreenY;

		[SerializeField]
		protected List<RectTransform> _objectsToExtend;

		[SerializeField]
		protected float _Padding;

		[SerializeField]
		protected float _MaxHeightPercentage;

		[SerializeField]
		protected float _MaxWidthPercentage;

		protected float _myWidth;

		protected float _screenWidth;

		protected float _scaleAmount;

		protected List<float> _baseHeights;

		protected Vector3 _baseScale;

		protected bool _IsPortrait;

		protected bool _hasInitialized;

		private bool _doLateFormat;

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public virtual void OnResolutionChanged(Vector2 newRes)
		{
		}

		[IteratorStateMachine(typeof(_003CApplyRoutine_003Ed__33))]
		private IEnumerator ApplyRoutine()
		{
			return null;
		}

		private void LateUpdate()
		{
		}

		protected virtual void Apply()
		{
		}

		public void Refresh()
		{
		}
	}
}
