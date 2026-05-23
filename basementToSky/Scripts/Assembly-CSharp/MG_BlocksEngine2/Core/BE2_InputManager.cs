using System;
using System.Collections.Generic;
using System.Linq;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.EditorScript;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.Core
{
	public class BE2_InputManager : MonoBehaviour, I_BE2_InputManager
	{
		private static I_BE2_InputManager _instance;

		public KeyCode primaryKey = KeyCode.Mouse0;

		public KeyCode secondaryKey = KeyCode.Mouse1;

		public KeyCode deleteKey = KeyCode.Delete;

		public KeyCode auxKey0 = KeyCode.LeftControl;

		private BE2_EventsManager _mainEventsManager;

		private BE2_DragDropManager _dragDropManager;

		private float _holdCounter;

		private Vector2 _lastPosition;

		public static List<KeyCode> keyCodeList;

		public static I_BE2_InputManager Instance
		{
			get
			{
				if (_instance == null)
				{
					GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
					for (int i = 0; i < array.Length; i++)
					{
						_instance = array[i].GetComponent<I_BE2_InputManager>();
						if (_instance != null)
						{
							break;
						}
					}
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public Vector3 ScreenPointerPosition => Input.mousePosition;

		public Vector3 CanvasPointerPosition => GetCanvasPointerPosition();

		private BE2_Inspector _inspector => BE2_Inspector.Instance;

		private void OnEnable()
		{
			keyCodeList = new List<KeyCode>();
			keyCodeList.AddRange(Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>());
			_mainEventsManager = BE2_MainEventsManager.Instance;
			_dragDropManager = BE2_DragDropManager.Instance;
		}

		public void OnUpdate()
		{
			if (Input.GetKeyDown(primaryKey))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnPrimaryKeyDown);
			}
			if (Input.GetKeyDown(secondaryKey))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnSecondaryKeyDown);
			}
			if (_dragDropManager.CurrentDrag != null && !_dragDropManager.isDragging)
			{
				_holdCounter += Time.deltaTime;
				if (_holdCounter > 0.6f)
				{
					_mainEventsManager.TriggerEvent(BE2EventTypes.OnPrimaryKeyHold);
					_holdCounter = 0f;
				}
			}
			if (Input.GetKey(primaryKey))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnPrimaryKey);
				if (Vector2.Distance(_lastPosition, ScreenPointerPosition) > 0.5f && !BE2_UI_ContextMenuManager.instance.isActive)
				{
					_mainEventsManager.TriggerEvent(BE2EventTypes.OnDrag);
				}
			}
			if (Input.GetKeyUp(primaryKey))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnPrimaryKeyUp);
				_holdCounter = 0f;
			}
			if (Input.GetKeyUp(secondaryKey))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnSecondaryKeyUp);
			}
			if (Input.GetKeyDown(auxKey0))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnAuxKeyDown);
			}
			if (Input.GetKeyUp(auxKey0))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnAuxKeyUp);
			}
			if (Input.GetKeyDown(deleteKey))
			{
				_mainEventsManager.TriggerEvent(BE2EventTypes.OnDeleteKeyDown);
			}
			_lastPosition = ScreenPointerPosition;
		}

		private Vector3 GetCanvasPointerPosition()
		{
			Camera camera = _inspector.Camera;
			if (_inspector.CanvasRenderMode == RenderMode.ScreenSpaceOverlay)
			{
				return ScreenPointerPosition;
			}
			if (_inspector.CanvasRenderMode == RenderMode.ScreenSpaceCamera)
			{
				Vector3 screenPointerPosition = ScreenPointerPosition;
				screenPointerPosition.z = BE2_DragDropManager.DragDropComponentsCanvas.transform.position.z - camera.transform.position.z;
				return GetMouseInCanvas(screenPointerPosition);
			}
			if (_inspector.CanvasRenderMode == RenderMode.WorldSpace)
			{
				Vector3 screenPointerPosition2 = ScreenPointerPosition;
				screenPointerPosition2.z = BE2_DragDropManager.DragDropComponentsCanvas.transform.position.z - camera.transform.position.z;
				return GetMouseInCanvas(screenPointerPosition2);
			}
			return Vector3.zero;
		}

		private Vector3 GetMouseInCanvas(Vector3 position)
		{
			RectTransformUtility.ScreenPointToWorldPointInRectangle(BE2_DragDropManager.DragDropComponentsCanvas.transform as RectTransform, position, _inspector.Camera, out var worldPoint);
			return worldPoint;
		}
	}
}
