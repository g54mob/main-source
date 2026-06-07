using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using Data.Variables;
using Events.Generic;
using Events.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

namespace Presentation.UI
{
	public class CursorUI : MonoBehaviour
	{
		[SerializeField]
		private SetCursorEvent _setCursorEvent;

		[SerializeField]
		private SetCursorTextEvent _setCursorTextEvent;

		[SerializeField]
		private RectTransform _container;

		[SerializeField]
		private TextMeshProUGUI _cursorText;

		[SerializeField]
		private InputActionReference _pointerPosition;

		[SerializeField]
		private Vector3 _offset = new Vector3(24f, 0f, 0f);

		[SerializeField]
		private BoolVariableSO _isCursorHoveringUI;

		[SerializeField]
		private InputActionReference _leftMouse;

		[SerializeField]
		private BoolEvent _toggleCursorVisibleEvent;

		[Header("Fading cursor text")]
		[SerializeField]
		private float _waitBeforeFadingTime = 0.5f;

		[SerializeField]
		private float _fadeTime = 0.5f;

		[SerializeField]
		private RectTransform _fadingTextContainer;

		[SerializeField]
		private CanvasGroup _fadingTextCanvasGroup;

		[SerializeField]
		private TextMeshProUGUI _fadingCursorText;

		[SerializeField]
		private SetCursorTextEvent _setFadingCursorTextEvent;

		[SerializeField]
		private float _textPunchScale = 0.25f;

		[SerializeField]
		private float _textPunchDuration = 0.1f;

		[Header("Textures")]
		[SerializeField]
		private Texture2D _defaultCursorTexture;

		[SerializeField]
		private Texture2D _hoveringUICursorTexture;

		[SerializeField]
		private SerializedDictionary<Texture2D, Texture2D> _clickedVersions;

		private int _uiLayer;

		private string _currentCursorText;

		private Texture2D _currentCursorTexture;

		private Vector2 _currentCursorOffset;

		private bool _wasPreviouslyHoveringUI;

		private bool _leftMouseDown;

		private bool _fadeTextCoroutineActive;

		private Coroutine _fadeTextCoroutine;

		private bool _currentShowContainer;

		private void Awake()
		{
			_setCursorEvent.Register(SetCursor);
			_setCursorTextEvent.Register(SetCursorText);
			_setFadingCursorTextEvent.Register(SetFadingCursorText);
			_uiLayer = LayerMask.NameToLayer("UI");
			_toggleCursorVisibleEvent.Register(ToggleCursorVisible);
			_leftMouse.action.started += HandleLeftMouseHeldStarted;
			_leftMouse.action.canceled += HandleLeftMouseHeldCancelled;
		}

		private void HandleLeftMouseHeldCancelled(InputAction.CallbackContext obj)
		{
			if (_leftMouseDown)
			{
				Cursor.SetCursor(_currentCursorTexture, _currentCursorOffset, CursorMode.Auto);
				_leftMouseDown = false;
			}
		}

		private void HandleLeftMouseHeldStarted(InputAction.CallbackContext obj)
		{
			if (_currentCursorTexture != null && _clickedVersions.TryGetValue(_currentCursorTexture, out var value))
			{
				_leftMouseDown = true;
				Cursor.SetCursor(value, _currentCursorOffset, CursorMode.Auto);
			}
		}

		private void OnDestroy()
		{
			_setCursorEvent.UnRegister(SetCursor);
			_setCursorTextEvent.UnRegister(SetCursorText);
			_setFadingCursorTextEvent.UnRegister(SetFadingCursorText);
			_toggleCursorVisibleEvent.UnRegister(ToggleCursorVisible);
			_leftMouse.action.started -= HandleLeftMouseHeldStarted;
			_leftMouse.action.canceled -= HandleLeftMouseHeldCancelled;
		}

		private void Update()
		{
			Vector3 vector = _pointerPosition.action.ReadValue<Vector2>();
			if (vector.x < 0f || vector.x > (float)Screen.width || vector.y < 0f || vector.y > (float)Screen.height)
			{
				_isCursorHoveringUI.SetValue(value: true);
				UpdateCursorWhenHoveringUI(isHoveringUI: true);
				return;
			}
			bool flag = CheckIfOverUI(vector);
			_isCursorHoveringUI.SetValue(flag);
			UpdateCursorWhenHoveringUI(flag);
			if (_container.gameObject.activeInHierarchy)
			{
				_container.position = vector + _offset;
			}
			if (_fadingTextContainer.gameObject.activeInHierarchy)
			{
				_fadingTextContainer.position = vector + _offset;
			}
		}

		private void UpdateCursorWhenHoveringUI(bool isHoveringUI)
		{
			if (_wasPreviouslyHoveringUI != isHoveringUI)
			{
				_wasPreviouslyHoveringUI = isHoveringUI;
				if (isHoveringUI)
				{
					ApplyCursorInternal(_hoveringUICursorTexture, Vector2.zero, CursorMode.Auto, string.Empty, showContainer: false);
					return;
				}
				_wasPreviouslyHoveringUI = false;
				ApplyCursorInternal((_currentCursorTexture != null) ? _currentCursorTexture : _defaultCursorTexture, _currentCursorOffset, CursorMode.Auto, _currentCursorText, !string.IsNullOrEmpty(_currentCursorText));
			}
		}

		private bool CheckIfOverUI(Vector3 mousePosition)
		{
			PointerEventData eventData = new PointerEventData(EventSystem.current)
			{
				position = mousePosition
			};
			List<RaycastResult> list = CollectionPool<List<RaycastResult>, RaycastResult>.Get();
			EventSystem.current.RaycastAll(eventData, list);
			foreach (RaycastResult item in list)
			{
				if (item.gameObject.layer == _uiLayer)
				{
					CollectionPool<List<RaycastResult>, RaycastResult>.Release(list);
					return true;
				}
			}
			CollectionPool<List<RaycastResult>, RaycastResult>.Release(list);
			return false;
		}

		private void SetCursorText(string text)
		{
			_currentCursorText = text;
			ApplyCursorInternal(_currentCursorTexture, _currentCursorOffset, CursorMode.Auto, text, !string.IsNullOrEmpty(text));
		}

		private void SetCursor((Texture2D texture, string text, Vector2 cursorOffset) args)
		{
			if (!(_currentCursorTexture == args.texture) || !(_currentCursorText == args.text))
			{
				_currentCursorText = args.text;
				(_currentCursorTexture, _, _currentCursorOffset) = args;
				if (!_wasPreviouslyHoveringUI)
				{
					ApplyCursorInternal(args.texture, args.cursorOffset, CursorMode.Auto, args.text, !string.IsNullOrEmpty(args.text));
				}
			}
		}

		private void ApplyCursorInternal(Texture2D texture, Vector2 offset, CursorMode cursorMode, string cursorText, bool showContainer)
		{
			Cursor.SetCursor(texture, offset, cursorMode);
			_cursorText.SetText(cursorText);
			_currentShowContainer = showContainer;
			_container.gameObject.SetActive(showContainer);
		}

		private void SetFadingCursorText(string text)
		{
			_fadingCursorText.text = text;
			if (_fadeTextCoroutineActive)
			{
				StopCoroutine(_fadeTextCoroutine);
				_fadeTextCoroutineActive = false;
				_fadingTextContainer.transform.DOKill();
				_fadingTextContainer.transform.localScale = Vector3.one;
				_fadingTextContainer.transform.DOPunchScale(Vector3.one * _textPunchScale, _textPunchDuration);
			}
			_fadeTextCoroutine = StartCoroutine(IFadeCursorText());
		}

		private IEnumerator IFadeCursorText()
		{
			_fadeTextCoroutineActive = true;
			_fadingTextCanvasGroup.alpha = 1f;
			_fadingTextContainer.gameObject.SetActive(value: true);
			yield return new WaitForSeconds(_waitBeforeFadingTime);
			for (float i = 0f; i < _fadeTime; i += Time.deltaTime)
			{
				float alpha = 1f - Mathf.Clamp01(i / _fadeTime);
				_fadingTextCanvasGroup.alpha = alpha;
				yield return null;
			}
			_fadingTextContainer.gameObject.SetActive(value: false);
			_fadingTextCanvasGroup.alpha = 0f;
			_fadeTextCoroutineActive = false;
		}

		public void ToggleCursorVisible(bool visible)
		{
			Cursor.visible = visible;
			_container.gameObject.SetActive(visible && _currentShowContainer);
		}
	}
}
