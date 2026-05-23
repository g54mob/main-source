using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EnhancedUI.EnhancedScroller
{
	[RequireComponent(typeof(ScrollRect))]
	public class EnhancedScroller : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		public enum ScrollDirectionEnum
		{
			Vertical = 0,
			Horizontal = 1
		}

		public enum CellViewPositionEnum
		{
			Before = 0,
			After = 1
		}

		public enum ScrollbarVisibilityEnum
		{
			OnlyIfNeeded = 0,
			Always = 1,
			Never = 2
		}

		public enum LoopJumpDirectionEnum
		{
			Closest = 0,
			Up = 1,
			Down = 2
		}

		private enum ListPositionEnum
		{
			First = 0,
			Last = 1
		}

		public enum TweenType
		{
			immediate = 0,
			linear = 1,
			spring = 2,
			easeInQuad = 3,
			easeOutQuad = 4,
			easeInOutQuad = 5,
			easeInCubic = 6,
			easeOutCubic = 7,
			easeInOutCubic = 8,
			easeInQuart = 9,
			easeOutQuart = 10,
			easeInOutQuart = 11,
			easeInQuint = 12,
			easeOutQuint = 13,
			easeInOutQuint = 14,
			easeInSine = 15,
			easeOutSine = 16,
			easeInOutSine = 17,
			easeInExpo = 18,
			easeOutExpo = 19,
			easeInOutExpo = 20,
			easeInCirc = 21,
			easeOutCirc = 22,
			easeInOutCirc = 23,
			easeInBounce = 24,
			easeOutBounce = 25,
			easeInOutBounce = 26,
			easeInBack = 27,
			easeOutBack = 28,
			easeInOutBack = 29,
			easeInElastic = 30,
			easeOutElastic = 31,
			easeInOutElastic = 32
		}

		[CompilerGenerated]
		private sealed class _003CTweenPosition_003Ed__166 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TweenType tweenType;

			public float time;

			public EnhancedScroller _003C_003E4__this;

			public float start;

			public float end;

			public bool forceCalculateRange;

			public Action tweenComplete;

			private float _003CnewPosition_003E5__2;

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
			public _003CTweenPosition_003Ed__166(int _003C_003E1__state)
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

		public ScrollDirectionEnum scrollDirection;

		public float spacing;

		public RectOffset padding;

		[SerializeField]
		private bool loop;

		public bool loopWhileDragging;

		public float maxVelocity;

		[SerializeField]
		private ScrollbarVisibilityEnum scrollbarVisibility;

		public bool snapping;

		public float snapVelocityThreshold;

		public float snapWatchOffset;

		public float snapJumpToOffset;

		public float snapCellCenterOffset;

		public bool snapUseCellSpacing;

		public TweenType snapTweenType;

		public float snapTweenTime;

		public bool snapWhileDragging;

		private float _lookAheadBefore;

		private float _lookAheadAfter;

		public CellViewVisibilityChangedDelegate cellViewVisibilityChanged;

		public CellViewWillRecycleDelegate cellViewWillRecycle;

		public ScrollerScrolledDelegate scrollerScrolled;

		public ScrollerSnappedDelegate scrollerSnapped;

		public ScrollerScrollingChangedDelegate scrollerScrollingChanged;

		public ScrollerTweeningChangedDelegate scrollerTweeningChanged;

		public CellViewInstantiated cellViewInstantiated;

		public CellViewReused cellViewReused;

		private bool _initialized;

		private bool _updateSpacing;

		private ScrollRect _scrollRect;

		private RectTransform _scrollRectTransform;

		private Scrollbar _scrollbar;

		private RectTransform _container;

		private HorizontalOrVerticalLayoutGroup _layoutGroup;

		private IEnhancedScrollerDelegate _delegate;

		private bool _reloadData;

		private bool _refreshActive;

		private SmallList<EnhancedScrollerCellView> _recycledCellViews;

		private LayoutElement _firstPadder;

		private LayoutElement _lastPadder;

		private RectTransform _recycledCellViewContainer;

		private SmallList<float> _cellViewSizeArray;

		private SmallList<float> _cellViewOffsetArray;

		public float _scrollPosition;

		private SmallList<EnhancedScrollerCellView> _activeCellViews;

		private int _activeCellViewsStartIndex;

		private int _activeCellViewsEndIndex;

		private int _loopFirstCellIndex;

		private int _loopLastCellIndex;

		private float _loopFirstScrollPosition;

		private float _loopLastScrollPosition;

		private float _loopFirstJumpTrigger;

		private float _loopLastJumpTrigger;

		private float _lastScrollRectSize;

		private bool _lastLoop;

		private int _snapCellViewIndex;

		private int _snapDataIndex;

		private bool _snapJumping;

		private bool _snapInertia;

		private ScrollbarVisibilityEnum _lastScrollbarVisibility;

		private float _singleLoopGroupSize;

		private bool _snapBeforeDrag;

		private bool _loopBeforeDrag;

		private bool _ignoreLoopJump;

		private int _dragFingerCount;

		private float _tweenTimeLeft;

		public float lookAheadBefore
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float lookAheadAfter
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public IEnhancedScrollerDelegate Delegate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float ScrollPosition
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScrollSize => 0f;

		public float NormalizedScrollPosition => 0f;

		public bool Loop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ScrollbarVisibilityEnum ScrollbarVisibility
		{
			get
			{
				return default(ScrollbarVisibilityEnum);
			}
			set
			{
			}
		}

		public Vector2 Velocity
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float LinearVelocity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsScrolling { get; private set; }

		public bool IsTweening { get; private set; }

		public int StartCellViewIndex => 0;

		public int EndCellViewIndex => 0;

		public int StartDataIndex => 0;

		public int EndDataIndex => 0;

		public int NumberOfCells => 0;

		public ScrollRect ScrollRect => null;

		public float ScrollRectSize => 0f;

		public LayoutElement FirstPadder => null;

		public LayoutElement LastPadder => null;

		public RectTransform Container => null;

		public EnhancedScrollerCellView GetCellView(EnhancedScrollerCellView cellPrefab)
		{
			return null;
		}

		public void ReloadData(float scrollPositionFactor = 0f)
		{
		}

		public void RefreshActiveCellViews()
		{
		}

		public void ClearAll()
		{
		}

		public void ClearActive()
		{
		}

		public void ClearRecycled()
		{
		}

		public void ToggleLoop()
		{
		}

		public void IgnoreLoopJump(bool ignore)
		{
		}

		public void SetScrollPositionImmediately(float scrollPosition)
		{
		}

		public void JumpToDataIndex(int dataIndex, float scrollerOffset = 0f, float cellOffset = 0f, bool useSpacing = true, TweenType tweenType = TweenType.immediate, float tweenTime = 0f, Action jumpComplete = null, LoopJumpDirectionEnum loopJumpDirection = LoopJumpDirectionEnum.Closest, bool forceCalculateRange = false)
		{
		}

		public void Snap()
		{
		}

		public float GetScrollPositionForCellViewIndex(int cellViewIndex, CellViewPositionEnum insertPosition)
		{
			return 0f;
		}

		public float GetScrollPositionForDataIndex(int dataIndex, CellViewPositionEnum insertPosition)
		{
			return 0f;
		}

		public int GetCellViewIndexAtPosition(float position)
		{
			return 0;
		}

		public EnhancedScrollerCellView GetCellViewAtDataIndex(int dataIndex)
		{
			return null;
		}

		private void _Resize(bool keepPosition)
		{
		}

		private void _UpdateSpacing(float spacing)
		{
		}

		private float _AddCellViewSizes()
		{
			return 0f;
		}

		private void _DuplicateCellViewSizes(int numberOfTimes, int cellCount)
		{
		}

		private void _CalculateCellViewOffsets()
		{
		}

		private EnhancedScrollerCellView _GetRecycledCellView(EnhancedScrollerCellView cellPrefab)
		{
			return null;
		}

		private void _ResetVisibleCellViews()
		{
		}

		private void _RecycleAllCells()
		{
		}

		private void _RecycleCell(EnhancedScrollerCellView cellView)
		{
		}

		private void _AddCellView(int cellIndex, ListPositionEnum listPosition)
		{
		}

		private void _SetPadders()
		{
		}

		private void _RefreshActive()
		{
		}

		private void _CalculateCurrentActiveCellRange(out int startIndex, out int endIndex)
		{
			startIndex = default(int);
			endIndex = default(int);
		}

		private int _GetCellIndexAtPosition(float position, int startIndex, int endIndex)
		{
			return 0;
		}

		private void Awake()
		{
		}

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}

		private void Update()
		{
		}

		private void OnValidate()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void _ScrollRect_OnValueChanged(Vector2 val)
		{
		}

		private void SnapJumpComplete()
		{
		}

		[IteratorStateMachine(typeof(_003CTweenPosition_003Ed__166))]
		private IEnumerator TweenPosition(TweenType tweenType, float time, float start, float end, Action tweenComplete, bool forceCalculateRange)
		{
			return null;
		}

		private float linear(float start, float end, float val)
		{
			return 0f;
		}

		private static float spring(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInQuad(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutQuad(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutQuad(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInCubic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutCubic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutCubic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInQuart(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutQuart(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutQuart(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInQuint(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutQuint(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutQuint(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInSine(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutSine(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutSine(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInExpo(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutExpo(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutExpo(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInCirc(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutCirc(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutCirc(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInBounce(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutBounce(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutBounce(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInBack(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutBack(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutBack(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInElastic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutElastic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutElastic(float start, float end, float val)
		{
			return 0f;
		}
	}
}
