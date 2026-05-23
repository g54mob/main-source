using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Button _button;

	[SerializeField]
	private RawImage _checkerHover;

	[SerializeField]
	private Image _outlineHover;

	[SerializeField]
	private float _lerpSpeed = 5f;

	[SerializeField]
	private float _panningSpeed = 0.01f;

	[SerializeField]
	private float _panningAmount = 30f;

	private Coroutine _currentCoroutine;

	private Coroutine _panningCoroutine;

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		if (!_button || _button.interactable)
		{
			if (_currentCoroutine != null)
			{
				StopCoroutine(_currentCoroutine);
			}
			if (_panningCoroutine != null)
			{
				StopCoroutine(_panningCoroutine);
			}
			_currentCoroutine = StartCoroutine(LerpAlpha(0.05f, 1f));
			_panningCoroutine = StartCoroutine(PanTexture(isHovering: true));
		}
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		if (_currentCoroutine != null)
		{
			StopCoroutine(_currentCoroutine);
		}
		if (_panningCoroutine != null)
		{
			StopCoroutine(_panningCoroutine);
		}
		_currentCoroutine = StartCoroutine(LerpAlpha(0f, 0f));
		_panningCoroutine = StartCoroutine(PanTexture(isHovering: false));
	}

	private IEnumerator LerpAlpha(float targetAlphaChecker, float targetAlphaOutline)
	{
		Color startColorChecker = _checkerHover.color;
		Color startColorOutline = _outlineHover.color;
		float time = 0f;
		while (time < 1f)
		{
			time += Time.deltaTime * _lerpSpeed;
			float a = Mathf.Lerp(startColorChecker.a, targetAlphaChecker, time);
			float a2 = Mathf.Lerp(startColorOutline.a, targetAlphaOutline, time);
			_outlineHover.color = new Color(startColorOutline.r, startColorOutline.g, startColorOutline.b, a2);
			_checkerHover.color = new Color(startColorChecker.r, startColorChecker.g, startColorChecker.b, a);
			yield return null;
		}
	}

	private IEnumerator PanTexture(bool isHovering)
	{
		float initialOffsetY = _checkerHover.uvRect.y;
		float targetOffsetY = (isHovering ? (initialOffsetY + _panningAmount) : initialOffsetY);
		float time = 0f;
		while (time < 1f)
		{
			time += Time.deltaTime * _panningSpeed;
			float num = Mathf.Lerp(initialOffsetY, targetOffsetY, time);
			Rect uvRect = _checkerHover.uvRect;
			uvRect.y = 0f - num;
			_checkerHover.uvRect = uvRect;
			yield return null;
		}
		if (!isHovering)
		{
			Rect uvRect2 = _checkerHover.uvRect;
			uvRect2.y = initialOffsetY;
			_checkerHover.uvRect = uvRect2;
		}
	}
}
