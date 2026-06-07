using Easing;
using Motorways;
using Motorways.Views;
using TMPro;
using UnityEngine;

public class NewsletterModal : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _emailInputField;

	[SerializeField]
	private GameOverScreen _gameOverScreen;

	[SerializeField]
	private MainMenuScreen _mainMenuScreen;

	private bool _isShowing;

	[SerializeField]
	private CanvasGroup _canvas;

	private Vector3 _activePosition;

	private RectTransform _rect;

	private string _emailToAdd = "";

	private TweenVector3 positionTween = new TweenVector3();

	private float _timeActive;

	private Vector3 HiddenPosition => _activePosition + Vector3.up * _rect.sizeDelta.y * 1f;

	private void Update()
	{
		if (positionTween.IsActive)
		{
			positionTween.Tick(Time.deltaTime);
			_rect.anchoredPosition = positionTween.Value;
		}
		else if (!_isShowing)
		{
			_canvas.alpha = 0f;
			_canvas.interactable = false;
			_canvas.blocksRaycasts = false;
		}
		if (_isShowing)
		{
			_timeActive += Time.deltaTime;
		}
		if (Input.anyKey || Input.touchCount > 0)
		{
			_timeActive = 0f;
		}
		if (_timeActive > 114f)
		{
			_timeActive = 0f;
			HideModal();
		}
	}

	public void OnEmailEntered(string email)
	{
		_emailToAdd = email;
	}

	public void OnConfirmSubscribe()
	{
		HideModal();
	}

	public void OnPrintSubscriptions()
	{
	}

	public void ShowModal()
	{
		if (Vector3.Distance(_rect.anchoredPosition, HiddenPosition) < 1f)
		{
			positionTween.Start(_rect.anchoredPosition, _activePosition, 0.5f, Easings.Functions.BackEaseOut);
			_isShowing = true;
			_timeActive = 0f;
			_emailInputField?.ActivateInputField();
			_canvas.alpha = 1f;
			_canvas.interactable = true;
			_canvas.blocksRaycasts = true;
		}
	}

	public void HideModal()
	{
		if (Vector3.Distance(_rect.anchoredPosition, _activePosition) < 1f)
		{
			positionTween.Start(_rect.anchoredPosition, HiddenPosition, 0.5f, Easings.Functions.BackEaseIn, 0.2f);
			if (_emailInputField != null)
			{
				_emailInputField.text = "";
			}
			_emailToAdd = "";
			_isShowing = false;
		}
		_emailInputField?.DeactivateInputField();
	}

	public void Awake()
	{
		_rect = GetComponent<RectTransform>();
		_activePosition = _rect.anchoredPosition;
		_rect.anchoredPosition = HiddenPosition;
		_canvas = _canvas ?? GetComponent<CanvasGroup>();
	}
}
