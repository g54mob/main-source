using System;
using Doozy.Engine.Orientation;
using Doozy.Engine.Progress;
using Doozy.Engine.Touchy;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/UI/UIDrawer", 2)]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Canvas))]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class UIDrawer : UIComponentBase<UIDrawer>, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
	{
		private const float AUTO_OPEN_IF_DRAGGED_OVER_VISIBILITY_PERCENT = 0.5f;

		private const float AUTO_CLOSE_IF_DRAGGED_UNDER_VISIBILITY_PERCENT = 0.5f;

		private const float AUTO_OPEN_OR_CLOSE_TERMINAL_SWIPE_VELOCITY = 800f;

		public static Action<UIDrawer, UIDrawerBehaviorType> OnUIDrawerBehavior;

		public UIDrawerArrow Arrow;

		public bool BlockBackButton;

		public UIDrawerBehavior CloseBehavior;

		public SimpleSwipe CloseDirection;

		public float CloseSpeed;

		public UIDrawerContainer Container;

		public Vector3 CustomStartAnchoredPosition;

		public bool CustomDrawerName;

		public string DrawerName;

		public bool DetectGestures;

		public UIDrawerBehavior DragBehavior;

		public bool HideOnBackButton;

		public ProgressEvent OnProgressChanged;

		public ProgressEvent OnInverseProgressChanged;

		public UIDrawerBehavior OpenBehavior;

		public float OpenSpeed;

		public UIContainer Overlay;

		public Progressor Progressor;

		public bool UseCustomStartAnchoredPosition;

		private Canvas m_canvas;

		private VisibilityState m_visibility;

		private float m_visibilityProgress;

		private Vector2 m_scaledCanvas;

		private bool m_availableForDrag;

		private Vector2 m_dragStartPosition;

		private const string GIZMOS_TEXTURE_PATH = "Doozy/UI/UIDrawer/";

		private const bool GIZMOS_ALLOW_SCALING = true;

		private const string ARROW_ROOT = "ArrowRoot";

		private const string ARROW_LEFT = "ArrowLeft";

		private const string ARROW_RIGHT = "ArrowRight";

		private const string ARROW_UP = "ArrowUp";

		private const string ARROW_DOWN = "ArrowDown";

		public static bool AnyDrawerOpened => false;

		public static string DefaultDrawerCategory => null;

		public static string DefaultDrawerName => null;

		public static UIDrawer DraggedDrawer { get; private set; }

		public static UIDrawer OpenedDrawer { get; private set; }

		private static TouchDetector Detector => null;

		public bool ArrowEnabled => false;

		public Canvas Canvas => null;

		public bool Closed => false;

		public bool HasArrow => false;

		public bool HasContainer => false;

		public bool HasOverlay => false;

		public float InverseVisibility => 0f;

		public bool IsClosing => false;

		public bool IsDragged { get; private set; }

		public bool IsOpening => false;

		public bool Opened => false;

		public VisibilityState Visibility => default(VisibilityState);

		public float VisibilityProgress
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		private bool DebugComponent => false;

		private void OnDrawGizmosSelected()
		{
		}

		protected override void Reset()
		{
		}

		public override void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		public void Close(bool instantAction = false)
		{
		}

		public void DisableGestureDetection()
		{
		}

		public void EnableGestureDetection()
		{
		}

		public void NotifySystemOfTriggeredBehavior(UIDrawerBehaviorType behaviorType)
		{
		}

		public void Open(bool instantAction = false)
		{
		}

		public void Toggle(bool instantAction = false)
		{
		}

		public void ToggleGestureDetection()
		{
		}

		public void UpdateArrowContainer()
		{
		}

		public void UpdateContainer()
		{
		}

		public void UpdateContainerSize()
		{
		}

		public void UpdateContainerSize(float fixedSize)
		{
		}

		public void UpdateContainerSize(float percentageOfScreen, float minimumSize)
		{
		}

		public void UpdateDrawerCloseDirection(SimpleSwipe hideDirection)
		{
		}

		private void InitiateOpen()
		{
		}

		private void FinalizeOpen()
		{
		}

		private void InitiateClose()
		{
		}

		private void FinalizeClose()
		{
		}

		private void MoveToCustomStartPosition()
		{
		}

		private void OnOrientationChanged(DetectedOrientation detectedOrientation)
		{
		}

		private void InitContainerPositions()
		{
		}

		private void UpdateContainerSize(UIDrawerContainerSize size, float percentageOfScreen, float minimumSize, float fixedSize)
		{
		}

		private Vector3 GetContainerClosedPosition()
		{
			return default(Vector3);
		}

		private void UpdateContainerAnimation()
		{
		}

		private void UpdateContainerVelocity()
		{
		}

		private void UpdateContainerDraggedPosition()
		{
		}

		private void UpdateShowProgress()
		{
		}

		private void InitArrow()
		{
		}

		private void UpdateArrow()
		{
		}

		private void UpdateOverlayAlpha(float value)
		{
		}

		private void UpdateContainerAlpha(float value)
		{
		}

		private void UpdateArrowActiveState()
		{
		}

		private float ScaledPositionX(float x)
		{
			return 0f;
		}

		private float ScaledPositionY(float y)
		{
			return 0f;
		}

		private Vector2 ScaledTouchPosition(Vector2 touchPosition)
		{
			return default(Vector2);
		}

		private void DebugOpenProgress()
		{
		}

		public static void Close(string drawerName, bool debug = false)
		{
		}

		public static bool Contains(string drawerName)
		{
			return false;
		}

		public static UIDrawer Get(string drawerName)
		{
			return null;
		}

		public static void Open(string drawerName, bool debug = false)
		{
		}

		public static void Toggle(string drawerName, bool debug = false)
		{
		}
	}
}
