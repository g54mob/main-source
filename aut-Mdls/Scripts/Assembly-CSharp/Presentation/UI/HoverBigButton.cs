using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class HoverBigButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private RawImage _polygonalImage;

		[SerializeField]
		private float targetAlphaHover = 0.3f;

		[SerializeField]
		private float fadeSpeed = 5f;

		[SerializeField]
		private float panningSpeed = 0.5f;

		[SerializeField]
		private float panningAmount = 0.1f;

		[SerializeField]
		private float uvMultiplier = 1.5f;

		private Coroutine fadeCoroutine;

		private Coroutine panningCoroutine;

		private void OnEnable()
		{
			SetImageAlpha(0f);
		}

		private void SetUIRect()
		{
			float height = _rectTransform.rect.height / _rectTransform.rect.width * uvMultiplier;
			_polygonalImage.uvRect = new Rect(0f, 0f, uvMultiplier, height);
		}

		private void OnDisable()
		{
			if (fadeCoroutine != null)
			{
				StopCoroutine(fadeCoroutine);
			}
			if (panningCoroutine != null)
			{
				StopCoroutine(panningCoroutine);
			}
			SetImageAlpha(0f);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			SetUIRect();
			if (fadeCoroutine != null)
			{
				StopCoroutine(fadeCoroutine);
			}
			if (panningCoroutine != null)
			{
				StopCoroutine(panningCoroutine);
			}
			fadeCoroutine = StartCoroutine(FadeTo(targetAlphaHover));
			panningCoroutine = StartCoroutine(PanTexture(isHovering: true));
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (fadeCoroutine != null)
			{
				StopCoroutine(fadeCoroutine);
			}
			if (panningCoroutine != null)
			{
				StopCoroutine(panningCoroutine);
			}
			fadeCoroutine = StartCoroutine(FadeTo(0f));
			panningCoroutine = StartCoroutine(PanTexture(isHovering: false));
		}

		private IEnumerator FadeTo(float targetAlpha)
		{
			float startAlpha = _polygonalImage.color.a;
			float time = 0f;
			while (time < 1f)
			{
				time += Time.deltaTime * fadeSpeed;
				float imageAlpha = Mathf.Lerp(startAlpha, targetAlpha, time);
				SetImageAlpha(imageAlpha);
				yield return null;
			}
			SetImageAlpha(targetAlpha);
		}

		private void SetImageAlpha(float alpha)
		{
			Color color = _polygonalImage.color;
			color.a = alpha;
			_polygonalImage.color = color;
		}

		private IEnumerator PanTexture(bool isHovering)
		{
			float initialOffsetX = _polygonalImage.uvRect.x;
			float targetOffsetX = (isHovering ? (initialOffsetX + panningAmount) : initialOffsetX);
			float time = 0f;
			while (time < 1f)
			{
				time += Time.deltaTime * panningSpeed;
				float x = Mathf.Lerp(initialOffsetX, targetOffsetX, time);
				Rect uvRect = _polygonalImage.uvRect;
				uvRect.x = x;
				_polygonalImage.uvRect = uvRect;
				yield return null;
			}
			if (!isHovering)
			{
				Rect uvRect2 = _polygonalImage.uvRect;
				uvRect2.x = initialOffsetX;
				_polygonalImage.uvRect = uvRect2;
			}
		}
	}
}
