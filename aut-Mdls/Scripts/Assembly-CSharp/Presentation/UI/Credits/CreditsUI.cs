using System;
using System.Collections;
using Data.Credits;
using Events.Generic;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Presentation.UI.Credits
{
	public class CreditsUI : UIMenu
	{
		[SerializeField]
		private GameObject _canvas;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private CreditsSO _creditsSO;

		[SerializeField]
		private Transform _creditsParent;

		[SerializeField]
		private ScrollRect _scrollView;

		[SerializeField]
		private RectTransform _content;

		[SerializeField]
		private InputActionReference _factoryScrollInput;

		[SerializeField]
		private InputActionReference _escapeAction;

		[SerializeField]
		private BoolEvent _toggleCursorVisibleEvent;

		private float _scrollSpeed = 0.01f;

		private float _resumeDelay = 3f;

		private Coroutine _autoScrollRoutine;

		private Coroutine _resumeRoutine;

		private Coroutine _fadeInRoutine;

		public event Action<CreditsUI> OnCloseCredits = delegate
		{
		};

		private void Awake()
		{
			_canvas.SetActive(value: false);
			BuildCredits();
		}

		private void BuildCredits()
		{
			for (int i = 0; i < _creditsSO.CreditsElements.Count; i++)
			{
				UnityEngine.Object.Instantiate(_creditsSO.CreditsElements[i].SegmentPrefab, _creditsParent).SetContent(_creditsSO.CreditsElements[i]);
			}
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			_factoryScrollInput.action.Disable();
			_canvas.SetActive(value: true);
			_scrollView.verticalNormalizedPosition = 1f;
			_fadeInRoutine = StartCoroutine(FadeIn());
			_escapeAction.action.performed += OnEscapeActionPerformed;
		}

		private IEnumerator FadeIn()
		{
			_canvasGroup.alpha = 0f;
			for (float t = 0f; t < 1f; t += Time.deltaTime)
			{
				_canvasGroup.alpha = Mathf.SmoothStep(0f, 1f, t);
				yield return null;
			}
			_autoScrollRoutine = StartCoroutine(AutoScroll());
		}

		public override void HideMenu()
		{
			if (_fadeInRoutine != null)
			{
				StopCoroutine(_fadeInRoutine);
			}
			if (_autoScrollRoutine != null)
			{
				StopCoroutine(_autoScrollRoutine);
			}
			if (_resumeRoutine != null)
			{
				StopCoroutine(_resumeRoutine);
			}
			_canvas.SetActive(value: false);
			this.OnCloseCredits(this);
			_factoryScrollInput.action.Enable();
			_escapeAction.action.performed -= OnEscapeActionPerformed;
		}

		public void OnScroll()
		{
			if (_autoScrollRoutine != null)
			{
				StopCoroutine(_autoScrollRoutine);
			}
			if (_resumeRoutine != null)
			{
				StopCoroutine(_resumeRoutine);
			}
			_resumeRoutine = StartCoroutine(ResumeAfterDelay());
		}

		private IEnumerator ResumeAfterDelay()
		{
			yield return new WaitForSeconds(_resumeDelay);
			if (_scrollView.verticalNormalizedPosition > 0f)
			{
				_autoScrollRoutine = StartCoroutine(AutoScroll());
			}
		}

		private IEnumerator AutoScroll()
		{
			while (_scrollView.verticalNormalizedPosition > 0f)
			{
				_scrollView.verticalNormalizedPosition -= _scrollSpeed * Time.deltaTime;
				yield return null;
			}
		}

		private void OnEscapeActionPerformed(InputAction.CallbackContext context)
		{
			_toggleCursorVisibleEvent.Fire(data: true);
		}
	}
}
