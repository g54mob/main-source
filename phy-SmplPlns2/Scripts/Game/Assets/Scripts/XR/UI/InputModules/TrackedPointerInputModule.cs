using System;
using System.Collections.Generic;
using Assets.Scripts.Input.XR;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace Assets.Scripts.XR.UI.InputModules
{
	public class TrackedPointerInputModule : MonoBehaviour
	{
		private static readonly Comparison<RaycastResult> _raycastComparer = RaycastComparer;

		private InputAction _clickInput;

		[SerializeField]
		private bool _clickOnMouseDown;

		[SerializeField]
		private float _dragThresholdMultiplier = 4f;

		private ExtendedPointerEventData _eventData;

		private EventSystem _eventSystem;

		[SerializeField]
		private XRHandType _handType;

		private InputActionPhase _lastButtonPhase;

		[SerializeField]
		private Transform _pointerTransform;

		[SerializeField]
		private CustomTrackedDeviceRaycaster _raycaster;

		private List<RaycastResult> _raycastResultCache = new List<RaycastResult>();

		private InputAction _scrollInput;

		[SerializeField]
		private float _scrollMultiplier = 3f;

		[SerializeField]
		private bool _useAnyRaycaster;

		public RaycastResult? PointerCurrentRaycast => _eventData?.pointerCurrentRaycast;

		public void SetIsInteracting()
		{
			Game.Instance.UIInfo.SetIsInteracting();
		}

		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2)
		{
			if (g1 == null || g2 == null)
			{
				return null;
			}
			Transform parent = g1.transform;
			while (parent != null)
			{
				Transform parent2 = g2.transform;
				while (parent2 != null)
				{
					if (parent == parent2)
					{
						return parent.gameObject;
					}
					parent2 = parent2.parent;
				}
				parent = parent.parent;
			}
			return null;
		}

		protected virtual void Start()
		{
			_eventSystem = UnityEngine.Object.FindFirstObjectByType<EventSystem>();
			if (_eventSystem == null)
			{
				_eventSystem = new GameObject("EventSystem").AddComponent<EventSystem>();
			}
			if (Game.Instance.SceneManager.InFlightScene)
			{
				_clickInput = ((_handType == XRHandType.Left) ? XRInputs.Flight.UIClickLeft : XRInputs.Flight.UIClickRight);
				return;
			}
			_clickInput = ((_handType == XRHandType.Left) ? XRInputs.Menu.UIClickLeft : XRInputs.Menu.UIClickRight);
			_scrollInput = ((_handType == XRHandType.Left) ? XRInputs.Menu.UIScrollLeft : XRInputs.Menu.UIScrollRight);
		}

		protected virtual void Update()
		{
			ExtendedPointerEventData extendedPointerEventData = _eventData;
			if (extendedPointerEventData == null)
			{
				extendedPointerEventData = (_eventData = new ExtendedPointerEventData(_eventSystem));
				extendedPointerEventData.pointerId = (int)_handType;
			}
			if (_pointerTransform == null)
			{
				_pointerTransform = base.transform;
			}
			extendedPointerEventData.Reset();
			if (!_pointerTransform.gameObject.activeInHierarchy)
			{
				return;
			}
			extendedPointerEventData.pointerType = UIPointerType.Tracked;
			extendedPointerEventData.trackedDevicePosition = _pointerTransform.position;
			extendedPointerEventData.trackedDeviceOrientation = _pointerTransform.rotation;
			extendedPointerEventData.useDragThreshold = true;
			RaycastResult pointerCurrentRaycast = PerformRaycast(extendedPointerEventData);
			if (pointerCurrentRaycast.isValid)
			{
				SetIsInteracting();
			}
			extendedPointerEventData.pointerCurrentRaycast = pointerCurrentRaycast;
			extendedPointerEventData.delta = pointerCurrentRaycast.screenPosition - extendedPointerEventData.position;
			extendedPointerEventData.position = pointerCurrentRaycast.screenPosition;
			if (_scrollInput != null)
			{
				Vector2 scrollDelta = _scrollInput.ReadValue<Vector2>() * _scrollMultiplier;
				scrollDelta.x = 0f - scrollDelta.x;
				extendedPointerEventData.scrollDelta = scrollDelta;
			}
			ProcessMovement(extendedPointerEventData);
			ProcessScroll(extendedPointerEventData);
			extendedPointerEventData.button = PointerEventData.InputButton.Left;
			InputActionPhase phase = _clickInput.phase;
			if (phase != _lastButtonPhase)
			{
				if (phase == InputActionPhase.Started)
				{
					ProcessPointerPress(extendedPointerEventData);
				}
				else if (_lastButtonPhase == InputActionPhase.Started)
				{
					ProcessPointerRelease(extendedPointerEventData);
				}
				_lastButtonPhase = phase;
			}
			ProcessPointerDrag(extendedPointerEventData);
		}

		private static int RaycastComparer(RaycastResult lhs, RaycastResult rhs)
		{
			if (lhs.module != rhs.module)
			{
				Camera eventCamera = lhs.module.eventCamera;
				Camera eventCamera2 = rhs.module.eventCamera;
				if (eventCamera != null && eventCamera2 != null && eventCamera.depth != eventCamera2.depth)
				{
					if (eventCamera.depth < eventCamera2.depth)
					{
						return 1;
					}
					if (eventCamera.depth == eventCamera2.depth)
					{
						return 0;
					}
					return -1;
				}
				if (lhs.module.sortOrderPriority != rhs.module.sortOrderPriority)
				{
					return rhs.module.sortOrderPriority.CompareTo(lhs.module.sortOrderPriority);
				}
				if (lhs.module.renderOrderPriority != rhs.module.renderOrderPriority)
				{
					return rhs.module.renderOrderPriority.CompareTo(lhs.module.renderOrderPriority);
				}
			}
			if (lhs.sortingLayer != rhs.sortingLayer)
			{
				int layerValueFromID = SortingLayer.GetLayerValueFromID(rhs.sortingLayer);
				int layerValueFromID2 = SortingLayer.GetLayerValueFromID(lhs.sortingLayer);
				return layerValueFromID.CompareTo(layerValueFromID2);
			}
			if (lhs.sortingOrder != rhs.sortingOrder)
			{
				return rhs.sortingOrder.CompareTo(lhs.sortingOrder);
			}
			if (lhs.depth != rhs.depth && lhs.module.rootRaycaster == rhs.module.rootRaycaster)
			{
				return rhs.depth.CompareTo(lhs.depth);
			}
			if (lhs.distance != rhs.distance)
			{
				return lhs.distance.CompareTo(rhs.distance);
			}
			return lhs.index.CompareTo(rhs.index);
		}

		private RaycastResult PerformRaycast(ExtendedPointerEventData eventData)
		{
			if (_useAnyRaycaster)
			{
				_raycastResultCache.Clear();
				for (int i = 0; i < CustomTrackedDeviceRaycaster.Instances.Count; i++)
				{
					CustomTrackedDeviceRaycaster.Instances[i].PerformRaycast(eventData, _raycastResultCache);
				}
			}
			else
			{
				if (_raycaster == null)
				{
					return default(RaycastResult);
				}
				_raycastResultCache.Clear();
				_raycaster.PerformRaycast(eventData, _raycastResultCache);
			}
			if (_raycastResultCache.Count == 1)
			{
				return _raycastResultCache[0];
			}
			if (_raycastResultCache.Count > 1)
			{
				RaycastResult raycastResult = _raycastResultCache[0];
				for (int j = 1; j < _raycastResultCache.Count; j++)
				{
					if (RaycastComparer(raycastResult, _raycastResultCache[j]) == 1)
					{
						raycastResult = _raycastResultCache[j];
					}
				}
				return raycastResult;
			}
			if (eventData.pointerDrag != null && eventData.dragging && eventData.pointerPressRaycast.isValid)
			{
				RaycastResult pointerPressRaycast = eventData.pointerPressRaycast;
				Transform obj = eventData.pointerDrag.transform;
				Vector3 vector = -obj.forward;
				Vector3 position = obj.position;
				Ray ray = new Ray(eventData.trackedDevicePosition, eventData.trackedDeviceOrientation * Vector3.forward);
				if (new Plane(vector, position).Raycast(ray, out var enter))
				{
					Vector3 point = ray.GetPoint(enter);
					return new RaycastResult
					{
						worldPosition = point,
						worldNormal = vector,
						distance = enter,
						index = 0f,
						screenPosition = pointerPressRaycast.module.eventCamera.WorldToScreenPoint(point),
						gameObject = eventData.pointerDrag,
						depth = pointerPressRaycast.depth,
						module = pointerPressRaycast.module,
						sortingLayer = pointerPressRaycast.sortingLayer,
						sortingOrder = pointerPressRaycast.sortingOrder,
						displayIndex = pointerPressRaycast.displayIndex
					};
				}
			}
			return default(RaycastResult);
		}

		private void ProcessMovement(ExtendedPointerEventData eventData)
		{
			GameObject gameObject = eventData.pointerCurrentRaycast.gameObject;
			if (gameObject == null || eventData.pointerEnter == null)
			{
				for (int i = 0; i < eventData.hovered.Count; i++)
				{
					ExecuteEvents.Execute(eventData.hovered[i], eventData, ExecuteEvents.pointerExitHandler);
				}
				eventData.hovered.Clear();
				if (gameObject == null)
				{
					eventData.pointerEnter = null;
					return;
				}
			}
			if (eventData.pointerEnter == gameObject && (bool)gameObject)
			{
				return;
			}
			Transform transform = FindCommonRoot(eventData.pointerEnter, gameObject)?.transform;
			if (eventData.pointerEnter != null)
			{
				Transform parent = eventData.pointerEnter.transform;
				while (parent != null && parent != transform)
				{
					ExecuteEvents.Execute(parent.gameObject, eventData, ExecuteEvents.pointerExitHandler);
					eventData.hovered.Remove(parent.gameObject);
					parent = parent.parent;
				}
			}
			eventData.pointerEnter = gameObject;
			if (gameObject != null)
			{
				Transform parent2 = gameObject.transform;
				while (parent2 != null && parent2 != transform)
				{
					ExecuteEvents.Execute(parent2.gameObject, eventData, ExecuteEvents.pointerEnterHandler);
					eventData.hovered.Add(parent2.gameObject);
					parent2 = parent2.parent;
				}
			}
		}

		private void ProcessPointerDrag(ExtendedPointerEventData eventData)
		{
			if (!eventData.IsPointerMoving() || eventData.pointerDrag == null)
			{
				return;
			}
			if (!eventData.dragging && (!eventData.useDragThreshold || (double)(eventData.pressPosition - eventData.position).sqrMagnitude >= (double)_eventSystem.pixelDragThreshold * (double)_eventSystem.pixelDragThreshold * (double)_dragThresholdMultiplier * (double)_dragThresholdMultiplier))
			{
				ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.beginDragHandler);
				eventData.dragging = true;
			}
			if (eventData.dragging)
			{
				if (eventData.pointerPress != eventData.pointerDrag && eventData.pointerPress != null)
				{
					ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerUpHandler);
					eventData.eligibleForClick = false;
					eventData.pointerPress = null;
					eventData.rawPointerPress = null;
				}
				ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.dragHandler);
			}
		}

		private void ProcessPointerPress(ExtendedPointerEventData eventData)
		{
			GameObject gameObject = eventData.pointerCurrentRaycast.gameObject;
			eventData.delta = Vector2.zero;
			eventData.dragging = false;
			eventData.pressPosition = eventData.position;
			eventData.pointerPressRaycast = eventData.pointerCurrentRaycast;
			eventData.eligibleForClick = true;
			GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy(gameObject, eventData, ExecuteEvents.pointerDownHandler);
			float unscaledTime = Time.unscaledTime;
			if (gameObject2 == eventData.lastPress && unscaledTime - eventData.clickTime < 0.3f)
			{
				int clickCount = eventData.clickCount + 1;
				eventData.clickCount = clickCount;
			}
			else
			{
				eventData.clickCount = 1;
			}
			eventData.clickTime = unscaledTime;
			GameObject gameObject3 = null;
			if (gameObject2 == null || _clickOnMouseDown)
			{
				gameObject3 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
			}
			if (gameObject2 == null)
			{
				gameObject2 = gameObject3;
			}
			eventData.pointerPress = gameObject2;
			eventData.rawPointerPress = gameObject;
			if (_clickOnMouseDown)
			{
				ExecuteEvents.Execute(gameObject3, eventData, ExecuteEvents.pointerClickHandler);
				eventData.eligibleForClick = false;
			}
			eventData.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject);
			if (eventData.pointerDrag != null)
			{
				ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.initializePotentialDrag);
			}
		}

		private void ProcessPointerRelease(ExtendedPointerEventData eventData)
		{
			GameObject root = eventData.pointerCurrentRaycast.gameObject;
			ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerUpHandler);
			GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(root);
			if (eventData.pointerPress == eventHandler && eventData.eligibleForClick)
			{
				ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerClickHandler);
			}
			else if (eventData.dragging && eventData.pointerDrag != null)
			{
				ExecuteEvents.ExecuteHierarchy(root, eventData, ExecuteEvents.dropHandler);
			}
			eventData.eligibleForClick = false;
			eventData.pointerPress = null;
			eventData.rawPointerPress = null;
			if (eventData.dragging && eventData.pointerDrag != null)
			{
				ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.endDragHandler);
			}
			eventData.dragging = false;
			eventData.pointerDrag = null;
		}

		private void ProcessScroll(ExtendedPointerEventData eventData)
		{
			if (!Mathf.Approximately(eventData.scrollDelta.sqrMagnitude, 0f))
			{
				ExecuteEvents.ExecuteHierarchy(ExecuteEvents.GetEventHandler<IScrollHandler>(eventData.pointerEnter), eventData, ExecuteEvents.scrollHandler);
			}
		}
	}
}
