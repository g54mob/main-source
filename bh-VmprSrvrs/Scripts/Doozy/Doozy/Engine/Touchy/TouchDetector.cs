using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Doozy.Engine.Touchy
{
	[AddComponentMenu("Doozy/Touchy/Touch Detector", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-200)]
	public class TouchDetector : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		private static TouchDetector s_instance;

		public Action<TouchInfo> OnTapAction;

		public Action<TouchInfo> OnLongTapAction;

		public Action<TouchInfo> OnSwipeAction;

		private Vector2 m_currentSwipe;

		private bool m_swipeEnded;

		private TouchInfo m_currentTouchInfo;

		private List<Touch> m_touches;

		private Touch m_touch;

		private PointerEventData m_pointerEventData;

		private List<RaycastResult> m_raycastResults;

		public static TouchDetector Instance => null;

		private static TouchySettings Settings => null;

		public static bool ApplicationIsQuitting { get; private set; }

		public static float SwipeLength => 0f;

		public static float LongTapDuration => 0f;

		private static bool DebugComponent => false;

		public bool TouchInProgress { get; private set; }

		public TouchInfo CurrentTouchInfo => default(TouchInfo);

		protected TouchDetector()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void SetDraggedObject(GameObject target)
		{
		}

		private void Initialize()
		{
		}

		private void DetectTouch()
		{
		}

		private void UpdateCurrentTouchInfo(Touch touch)
		{
		}

		private void HandleSwipe(TouchInfo touchInfo)
		{
		}

		private void HandleTap(TouchInfo touchInfo)
		{
		}

		private void HandleLongTap(TouchInfo touchInfo)
		{
		}

		public static void Init()
		{
		}

		public static Vector2 GetCardinalDirection(Swipe swipe)
		{
			return default(Vector2);
		}

		public static Swipe GetSwipe(SimpleSwipe simpleSwipe, bool reverse = false)
		{
			return default(Swipe);
		}

		public static SimpleSwipe GetSimpleSwipe(Swipe swipe, bool reverse = false)
		{
			return default(SimpleSwipe);
		}

		public static Swipe GetSwipeDirection(Vector2 direction)
		{
			return default(Swipe);
		}

		public static SimpleSwipe GetSimpleSwipeDirection(Vector2 direction)
		{
			return default(SimpleSwipe);
		}

		private static TouchDetector AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
