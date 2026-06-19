#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using Cookieverse.CursorPos;
using JetBrains.Annotations;
using Rewired;
using TMPro;
using UnityConsole;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class InputManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public GameObject _rewiredInputManager;

			public float _quickMouseClickTime = 0.1f;
		}

		private struct DragInfo
		{
			public bool StartDragWasOverGui;

			public bool IsDragging;
		}

		private readonly Config _config;

		private bool _needsReset;

		private bool _enabled = true;

		private Player _rewiredPlayer;

		private readonly GameObject _rewiredInstance;

		private float _timeMouseMoved;

		private Vector3 _lastMousePos = Vector3.zero;

		private bool _isEditingText;

		private readonly float[] _quickClickStart = new float[3];

		private readonly bool[] _quickClick = new bool[3];

		private readonly float[] _quickClickOnSceneStart = new float[3];

		private readonly bool[] _quickClickOnScene = new bool[3];

		private readonly DragInfo[] _dragButtonInfo = new DragInfo[3];

		private PointerEventData _pointerEventData;

		private readonly List<RaycastResult> _raycastResults = new List<RaycastResult>();

		private readonly List<RaycastResult> _raycastResultsRaw = new List<RaycastResult>();

		private readonly EventSystem _eventSystem;

		private List<GraphicRaycaster> _graphicRaycasters = new List<GraphicRaycaster>();

		private Vector2 _screenResolution;

		private bool _fullScreen;

		private float _cursorConfineDelay;

		private bool _currentlyDraggingScrollbar;

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public float TimeMouseMoved => _timeMouseMoved;

		public bool IsMouseOverGui { get; private set; }

		public List<RaycastResult> RaycastResults => _raycastResults;

		public List<RaycastResult> RaycastResultsRaw => _raycastResultsRaw;

		public InputManager(Config config, EventSystem eventSystem)
		{
			_config = config;
			if ((bool)config._rewiredInputManager)
			{
				if (!Application.isFocused)
				{
					_needsReset = true;
				}
				_rewiredInstance = Object.Instantiate(config._rewiredInputManager);
				if (!ReInput.isReady)
				{
					Logging.Error(LogChannels.Unity, "Instantiated Rewired Prefab but rewired is still not ready");
				}
				if (ReInput.players == null)
				{
					Logging.Error(LogChannels.Unity, "Instantiated Rewired Prefab but ReInput.players is still null");
				}
			}
			CheckConfig();
			ConsoleCommandsDatabase.RegisterCommand("ResetRewired", "", "", ResetRewired_Debug);
			_eventSystem = eventSystem;
			_screenResolution = Vector2.zero;
			_fullScreen = Screen.fullScreen;
		}

		public void OnApplicationFocus(bool focus)
		{
			if (focus && _needsReset)
			{
				ReInput.Reset();
				_needsReset = false;
			}
		}

		private ConsoleCommandResult ResetRewired_Debug(params string[] args)
		{
			ReInput.Reset();
			return ConsoleCommandResult.Succeeded();
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ResetRewired");
			Object.Destroy(_rewiredInstance);
			base.Destroy();
		}

		public void AddGraphicRayCaster(GraphicRaycaster graphicRaycaster)
		{
			_graphicRaycasters.Add(graphicRaycaster);
		}

		public void RemoveGraphicRayCaster(GraphicRaycaster graphicRaycaster)
		{
			_graphicRaycasters.Remove(graphicRaycaster);
		}

		public void Update()
		{
			CheckConfig();
			if (!Application.isEditor)
			{
				CheckForResolutionChanges();
			}
			_isEditingText = false;
			GameObject currentSelectedGameObject = _eventSystem.currentSelectedGameObject;
			if (currentSelectedGameObject != null && currentSelectedGameObject.activeInHierarchy)
			{
				_isEditingText = currentSelectedGameObject.GetComponent<TMP_InputField>() != null || currentSelectedGameObject.GetComponent<InputField>() != null;
			}
			if (_pointerEventData == null)
			{
				_pointerEventData = new PointerEventData(_eventSystem);
			}
			_pointerEventData.position = Input.mousePosition;
			_raycastResults.Clear();
			foreach (GraphicRaycaster graphicRaycaster in _graphicRaycasters)
			{
				if (graphicRaycaster != null)
				{
					graphicRaycaster.Raycast(_pointerEventData, _raycastResults);
				}
			}
			_raycastResultsRaw.Clear();
			_raycastResultsRaw.AddRange(_raycastResults);
			_raycastResults.Sort((RaycastResult raycastResult1, RaycastResult raycastResult2) => raycastResult2.depth.CompareTo(raycastResult1.depth));
			IsMouseOverGui = _raycastResults.Count > 0;
			for (int num = 0; num < 3; num++)
			{
				if (Input.GetMouseButtonDown(num))
				{
					_dragButtonInfo[num].IsDragging = true;
					_dragButtonInfo[num].StartDragWasOverGui = IsMouseOverGui;
				}
				else if (Input.GetMouseButtonUp(num) || !Input.GetMouseButton(num))
				{
					_dragButtonInfo[num].IsDragging = false;
				}
			}
			Vector3 mousePosition = Input.mousePosition;
			if (Vector3.Distance(mousePosition, _lastMousePos) > 0f)
			{
				_timeMouseMoved = Time.unscaledTime;
			}
			_lastMousePos = mousePosition;
			for (int num2 = 0; num2 < 3; num2++)
			{
				if (Input.GetMouseButtonDown(num2))
				{
					_quickClickStart[num2] = Time.unscaledTime;
					if (!IsMouseOverGui)
					{
						_quickClickOnSceneStart[num2] = Time.unscaledTime;
					}
				}
				_quickClick[num2] = Input.GetMouseButtonUp(num2) && IsQuickClickDuration(Time.unscaledTime - _quickClickStart[num2]);
				_quickClickOnScene[num2] = !IsMouseOverGui && Input.GetMouseButtonUp(num2) && IsQuickClickDuration(Time.unscaledTime - _quickClickOnSceneStart[num2]);
			}
		}

		private void CheckForResolutionChanges()
		{
			if (_screenResolution.x != (float)Screen.width || _screenResolution.y != (float)Screen.height || _fullScreen != Screen.fullScreen)
			{
				_screenResolution.x = Screen.width;
				_screenResolution.y = Screen.height;
				_fullScreen = Screen.fullScreen;
				_cursorConfineDelay = 0.25f;
				Cursor.lockState = CursorLockMode.None;
			}
			if (!(_cursorConfineDelay > 0f))
			{
				return;
			}
			_cursorConfineDelay -= GameTime.unscaledDeltaTime;
			if (_cursorConfineDelay <= 0f)
			{
				if (Screen.fullScreen)
				{
					Cursor.lockState = CursorLockMode.Confined;
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
				}
			}
		}

		public void Flush()
		{
			for (int i = 0; i < 3; i++)
			{
				_quickClick[i] = false;
				_quickClickStart[i] = 0f;
				_quickClickOnScene[i] = false;
				_quickClickOnSceneStart[i] = 0f;
			}
		}

		private void CheckConfig()
		{
			if (ReInput.players == null || ReInput.players.playerCount == 0)
			{
				if (_enabled)
				{
					_enabled = false;
					Logging.Warning("No Rewired players found, disabling input");
				}
			}
			else
			{
				_rewiredPlayer = ReInput.players.GetPlayer(0);
			}
		}

		public bool IsMouseOverGuiOrDraggingScrollbar()
		{
			if (!IsMouseOverGui && !IsCurrentlyDraggingScrollbar())
			{
				return !IsMouseInsideWindow();
			}
			return true;
		}

		public bool IsMouseInsideWindow()
		{
			Vector2 mousePosNormalised = GetMousePosNormalised();
			if (mousePosNormalised.x >= 0f && mousePosNormalised.y >= 0f && mousePosNormalised.x <= 1f)
			{
				return mousePosNormalised.y <= 1f;
			}
			return false;
		}

		public bool IsCurrentlyDraggingScrollbar()
		{
			return _currentlyDraggingScrollbar;
		}

		public void NotifyScrollbarDrag(bool bState)
		{
			_currentlyDraggingScrollbar = bState;
		}

		public bool GetMouseUp(MouseButton mouseButton)
		{
			if (_enabled)
			{
				return Input.GetMouseButtonUp((int)mouseButton);
			}
			return false;
		}

		public bool GetMouseDown(MouseButton mouseButton)
		{
			if (_enabled)
			{
				return Input.GetMouseButtonDown((int)mouseButton);
			}
			return false;
		}

		public bool GetMouse(MouseButton mouseButton)
		{
			if (_enabled)
			{
				return Input.GetMouseButton((int)mouseButton);
			}
			return false;
		}

		private bool IsQuickClickDuration(float duration)
		{
			return duration < Mathf.Max(_config._quickMouseClickTime, Time.unscaledDeltaTime + 0.01f);
		}

		public bool GetMouseQuick(MouseButton mouseButton)
		{
			if (_enabled)
			{
				return _quickClick[(int)mouseButton];
			}
			return false;
		}

		public bool GetMouseQuickOnScene(MouseButton mouseButton)
		{
			if (_enabled && !IsMouseOverGui)
			{
				return _quickClickOnScene[(int)mouseButton];
			}
			return false;
		}

		public bool GetMouseUpOnScene(MouseButton mouseButton)
		{
			if (_enabled && !IsMouseOverGui)
			{
				return GetMouseUp(mouseButton);
			}
			return false;
		}

		public bool GetMouseDownOnScene(MouseButton mouseButton)
		{
			if (_enabled && !IsMouseOverGui)
			{
				return GetMouseDown(mouseButton);
			}
			return false;
		}

		public bool GetMouseOnScene(MouseButton mouseButton)
		{
			if (_enabled && !IsMouseOverGui)
			{
				return Input.GetMouseButton((int)mouseButton);
			}
			return false;
		}

		public bool GetMouseDrag(MouseButton mouseButton)
		{
			if (_enabled)
			{
				return _dragButtonInfo[(int)mouseButton].IsDragging;
			}
			return false;
		}

		public bool GetMouseDragOnScene(MouseButton mouseButton)
		{
			if (_enabled && !_dragButtonInfo[(int)mouseButton].StartDragWasOverGui)
			{
				return _dragButtonInfo[(int)mouseButton].IsDragging;
			}
			return false;
		}

		public float GetMouseWheel()
		{
			if (!_enabled || IsMouseOverGui)
			{
				return 0f;
			}
			return _rewiredPlayer.GetAxis(44);
		}

		public bool GetKey(KeyCode key)
		{
			if (_enabled && !_isEditingText)
			{
				return Input.GetKey(key);
			}
			return false;
		}

		public bool GetKeyDown(KeyCode key)
		{
			if (_enabled && !_isEditingText)
			{
				return Input.GetKeyDown(key);
			}
			return false;
		}

		public bool GetKeyUp(KeyCode key)
		{
			if (_enabled && !_isEditingText)
			{
				return Input.GetKeyUp(key);
			}
			return false;
		}

		public bool GetButton(int action)
		{
			if (_enabled && !_isEditingText)
			{
				return _rewiredPlayer.GetButton(action);
			}
			return false;
		}

		public bool GetButtonUp(int action)
		{
			if (_enabled && !_isEditingText)
			{
				return _rewiredPlayer.GetButtonUp(action);
			}
			return false;
		}

		public bool GetButtonDown(int action)
		{
			if (_enabled && !_isEditingText)
			{
				return _rewiredPlayer.GetButtonDown(action);
			}
			return false;
		}

		public float GetAxis(int axis)
		{
			if (!_enabled || _isEditingText)
			{
				return 0f;
			}
			return _rewiredPlayer.GetAxis(axis);
		}

		public Vector2 GetMousePos()
		{
			return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}

		public Vector2 GetMousePosNormalised()
		{
			return new Vector2(Input.mousePosition.x / (float)Screen.width, Input.mousePosition.y / (float)Screen.height);
		}

		public Vector2 GetCursorPos()
		{
			Vector2 vector = CursorPosition.Get();
			return new Vector2(vector.x, vector.y);
		}

		public void SetCursorPos(Vector2 position)
		{
			CursorPosition.Set(position);
		}
	}
}
