using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.WorldMap
{
	public class HoverInfoUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private ScreenInteractableWorldArea _interactableWorldArea;

		[SerializeField]
		private float _fadingInTime = 0.25f;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		private float _currentFadeTime;

		private Coroutine _fadeCoroutine;

		private bool _isHovered;

		private bool _isGameUnlocked;

		private bool _isFadingOut;

		private bool _isMouseOver;

		public bool IsMouseOver => _isMouseOver;

		private void Start()
		{
			_interactableWorldArea.OnAreaIsHoveredOverAction += OnHover;
			_interactableWorldArea.OnAreaStopHoverAction += OnStopHover;
			base.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			_interactableWorldArea.OnAreaIsHoveredOverAction -= OnHover;
			_interactableWorldArea.OnAreaStopHoverAction -= OnStopHover;
		}

		public void OnCityUnlocked()
		{
			_isGameUnlocked = true;
			if (_isHovered)
			{
				OnHover();
			}
		}

		private void OnHover()
		{
			_isHovered = true;
			if (_isGameUnlocked)
			{
				base.gameObject.SetActive(value: true);
				StartNewFadingRoutine(fadeIn: true);
			}
		}

		private void OnStopHover()
		{
			_isHovered = false;
			if (_isGameUnlocked && !_isMouseOver)
			{
				StartNewFadingRoutine(fadeIn: false);
				_isFadingOut = true;
			}
		}

		private void StartNewFadingRoutine(bool fadeIn)
		{
			if (_fadeCoroutine != null)
			{
				StopCoroutine(_fadeCoroutine);
				_fadeCoroutine = null;
			}
			_fadeCoroutine = StartCoroutine(Fade(fadeIn));
		}

		private IEnumerator Fade(bool fadeIn)
		{
			_currentFadeTime = 0f;
			while (_currentFadeTime <= _fadingInTime)
			{
				_currentFadeTime += Time.deltaTime;
				float num = _currentFadeTime / _fadingInTime;
				if (!fadeIn)
				{
					num = 1f - num;
				}
				_canvasGroup.alpha = num;
				yield return null;
			}
			if (!fadeIn)
			{
				_isFadingOut = false;
				base.gameObject.SetActive(value: false);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_isMouseOver = false;
			if (!_isHovered)
			{
				StartNewFadingRoutine(fadeIn: false);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_isFadingOut)
			{
				StartNewFadingRoutine(fadeIn: true);
			}
			_isMouseOver = true;
		}
	}
}
