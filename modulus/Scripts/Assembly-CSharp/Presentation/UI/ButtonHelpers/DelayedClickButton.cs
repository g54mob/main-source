using System;
using DG.Tweening;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Presentation.UI.ButtonHelpers
{
	public class DelayedClickButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField]
		private GameObject _objectWhileHovering;

		[SerializeField]
		private GameObject _objectWhileProgressing;

		[SerializeField]
		private RectTransform _progressBar;

		[SerializeField]
		private float _delayDuration = 2f;

		[SerializeField]
		private InputActionReference _leftClick;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private Vector2 _progressFullSize;

		private Vector2 _progressStartSize;

		public Action Callback;

		private bool _hasHoveringObject;

		private bool _hasProgressingObject;

		private void Awake()
		{
			_hasHoveringObject = _objectWhileHovering != null;
			_hasProgressingObject = _objectWhileProgressing != null;
			if (_hasHoveringObject)
			{
				_objectWhileHovering.SetActive(value: false);
			}
			if (_hasProgressingObject)
			{
				_objectWhileProgressing?.SetActive(value: false);
			}
			UpdateSizeParameters();
			_progressBar.gameObject.SetActive(value: false);
		}

		private void OnEnable()
		{
			_leftClick.action.performed += HandleLeftClickEnd;
			_leftClick.action.canceled += HandleLeftClickEnd;
		}

		private void OnDisable()
		{
			_leftClick.action.performed -= HandleLeftClickEnd;
			_leftClick.action.canceled -= HandleLeftClickEnd;
			_audioManagerLocator?.AudioManager.StopUnlocking(isComplete: false);
		}

		private void HandleLeftClickEnd(InputAction.CallbackContext obj)
		{
			_audioManagerLocator?.AudioManager.StopUnlocking(isComplete: false);
		}

		public void UpdateSize(Vector2 newSize)
		{
			_progressBar.sizeDelta = newSize;
			UpdateSizeParameters();
		}

		private void UpdateSizeParameters()
		{
			_progressFullSize = _progressBar.sizeDelta;
			_progressStartSize = new Vector2(0f, _progressBar.sizeDelta.y);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_hasHoveringObject)
			{
				_objectWhileHovering.SetActive(value: true);
			}
			_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_hasHoveringObject)
			{
				_objectWhileHovering.SetActive(value: false);
			}
			if (_hasProgressingObject)
			{
				_objectWhileHovering.SetActive(value: false);
			}
			_audioManagerLocator?.AudioManager.StopUnlocking(isComplete: false);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_hasHoveringObject)
			{
				_objectWhileHovering.SetActive(value: false);
			}
			if (_hasProgressingObject)
			{
				_objectWhileProgressing.SetActive(value: true);
			}
			_progressBar.gameObject.SetActive(value: true);
			_progressBar.sizeDelta = _progressStartSize;
			_progressBar.DOSizeDelta(_progressFullSize, _delayDuration).SetEase(Ease.OutQuad).OnComplete(OnDelayComplete);
			_audioManagerLocator?.AudioManager.PlayStartUnlocking();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (_hasHoveringObject)
			{
				_objectWhileHovering.SetActive(value: true);
			}
			if (_hasProgressingObject)
			{
				_objectWhileProgressing.SetActive(value: false);
			}
			KillTween();
			_audioManagerLocator?.AudioManager.StopUnlocking(isComplete: false);
		}

		private void KillTween()
		{
			_progressBar.DOKill();
			_progressBar.gameObject.SetActive(value: false);
		}

		private void OnDelayComplete()
		{
			if (_hasHoveringObject)
			{
				_objectWhileHovering.SetActive(value: false);
			}
			if (_hasProgressingObject)
			{
				_objectWhileProgressing.SetActive(value: false);
			}
			KillTween();
			Callback();
			_audioManagerLocator?.AudioManager.StopUnlocking(isComplete: true);
			_audioManagerLocator?.AudioManager.PlayTechtreeNodeUnlock();
		}
	}
}
